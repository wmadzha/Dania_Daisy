using System;
namespace DaniaDaisy.DataAccess.Common
{
    public abstract class DataAccessLoggerSink : ILoggerSink
    {
        public string SourceMachineName { get; set; }
        public string SourceApplicationDomainName { get; set; }
        public string ReferralLibrary { get; set; }
        public DataAccessLoggerSink(DataAccessLoggerSinks sinkDetails)
        {
            this.SourceMachineName = sinkDetails.SourceMachineName;
            this.SourceApplicationDomainName = sinkDetails.SourceApplicationDomainName;
            this.ReferralLibrary = sinkDetails.ReferralLibrary;
        }
    }
    public class AzureTableSink : DataAccessLoggerSink
    {
        public AzureTableSink(
            DataAccessLoggerSinks sinkdetails,
            string azuretablename,
            string azurestorageaccountname,
            string azurestoragekey
            ) :base(sinkdetails)
        {
            this.AzureTableName = azuretablename;
            this.AzureStorageAccountName = azurestorageaccountname;
            this.AzureStorageKey = azurestoragekey;
        }
        public string AzureTableName { get; set; }
        public string AzureStorageKey { get; set; }
        public string AzureStorageAccountName { get; set; }
    }
    public class ConsoleSink : DataAccessLoggerSink
    {
        public ConsoleColor ForegroundColor { get; set; }
        public ConsoleSink(DataAccessLoggerSinks sinkdetails) :base(sinkdetails)
        {
            this.ForegroundColor = ConsoleColor.Black;
        }
        public ConsoleSink(DataAccessLoggerSinks sinkdetails, ConsoleColor color) : base(sinkdetails)
        {
            this.ForegroundColor = color;
        }
    }
    public class DatabaseSink : DataAccessLoggerSink
    {
        public DatabaseSink(DataAccessLoggerSinks sinkdetails, string connectionstring) : base(sinkdetails)
        {
            this.DatabaseConnectionString = connectionstring;
            this.DestinationTableName = "DataAccessLogger";
        }
        public DatabaseSink(DataAccessLoggerSinks sinkdetails, 
            string connectionstring,
            string destinationtablename
            ) : this (sinkdetails ,connectionstring)
        {
            this.DestinationTableName = destinationtablename;
        }
        public string DatabaseConnectionString { get; set; }
        public string DestinationTableName { get; set; }

    }
    public class FileSink : DataAccessLoggerSink
    {
        public FileSink(DataAccessLoggerSinks sinkdetails, string filepath) : base(sinkdetails)
        {
            this.FilePath = filepath;
        }
        public string FilePath { get; set; }
    }
    public class EventLogSink : DataAccessLoggerSink
    {
        public EventLogSink(DataAccessLoggerSinks sinkdetails) : base(sinkdetails)
        {

        }
    }
   
}
