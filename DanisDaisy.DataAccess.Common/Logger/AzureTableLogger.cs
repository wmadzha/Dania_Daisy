using System;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using DaniaDaisy.DataAccess.Common.Model;
namespace DaniaDaisy.DataAccess.Common.Logger
{
    public class AzureTableLogger : DataAccessLogger
    {
        private AzureTableSink _Sink { get; set; }
        public AzureTableLogger(ILoggerSink sink)
        {
            _Sink = sink as AzureTableSink;
        }
        public override async void Log(DataAccessFootprint logDetails)
        {
                if(_Sink == null)
                Console.WriteLine("There is no Azure Table Sink being setup");
                else
                {
                    try
                    {
                        AzureTableDataAccessLogger azuretabledata = new AzureTableDataAccessLogger(logDetails);
                        CloudTable azuretable = this.SetupAccount()
                            .CreateCloudTableClient()
                            .GetTableReference(_Sink.AzureTableName);
                        await azuretable.CreateIfNotExistsAsync();
                    await azuretable.ExecuteAsync(TableOperation.InsertOrReplace(azuretabledata));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Data Access Sink Error : Azure Table Sink , Error : "+ex.Message);
                    }
                }

        }
        internal  CloudStorageAccount SetupAccount()
        {
            StorageCredentials cred = new StorageCredentials(_Sink.AzureStorageAccountName, _Sink.AzureStorageKey);
            return new CloudStorageAccount(cred, _Sink.AzureStorageAccountName, "core.windows.net", true);
        }
    }   
    internal class AzureTableDataAccessLogger : TableEntity
    {
        public AzureTableDataAccessLogger()
        {

        }
        public AzureTableDataAccessLogger(DataAccessFootprint Data)
        {
            this.Operation = Data.Operation.ToString();
            this.MethodName = Data.MethodName;
            this.Message = Data.Message;
            this.PartitionKey = "DataAccesLogging";
            this.ReferralLibrary = Data.ReferralLibrary;
            this.RowKey = Data.DataAccessTransactionId.ToString();
            this.DataAccessTransactionId = Data.DataAccessTransactionId;
            this.SourceApplicationDomainName = Data.SourceApplicationDomainName;
            this.SourceMachineName = Data.SourceMachineName;
            this.Timestamp = DateTime.UtcNow;
        }
        public string Operation { get; set; }
        public string MethodName { get; set; }
        public string Message { get; set; }
        public string SourceMachineName { get; set; }
        public string SourceApplicationDomainName { get; set; }
        public string ReferralLibrary { get; set; }
        public Guid DataAccessTransactionId { get; set; }
    }
}
