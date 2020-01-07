using System;
namespace DaniaDaisy.DataAccess.Common.Model
{
    public class DataAccessFootprint  : DataAccessLoggerSinks
    {
        public DataAccessOperation Operation { get; set; }
        public string MethodName { get; set; }
        public string Message { get; set; }
        public Guid DataAccessTransactionId { get; set; }
        public bool IsSuccess { get; set; }
        public DataAccessFootprint(DataAccessOperation operation, string methodname , string message, bool issuccess)
        {
            this.Operation = operation;
            this.MethodName = methodname;
            this.Message = message;
            this.IsSuccess = issuccess;
        }
        public DataAccessFootprint AddSink(ILoggerSink sink)
        {
            this.ReferralLibrary = sink.ReferralLibrary;
            this.SourceApplicationDomainName = sink.SourceApplicationDomainName;
            this.SourceMachineName = sink.SourceMachineName;
            return this;
        }
    }
}
