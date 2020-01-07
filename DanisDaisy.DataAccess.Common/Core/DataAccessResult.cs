using DaniaDaisy.DataAccess.Common.Core.Logger;
using DaniaDaisy.DataAccess.Common.Model;
using System.Collections.Generic;

namespace DaniaDaisy.DataAccess.Common
{
    public abstract class DataAccessResult : IDataAccessResult
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public List<DataAccessOperationObjects> Objects { get; set; }
        protected DataAccessOperation Operation { get; set; }
        protected DataAccessLoggerType LoggerType { get; set; }
        protected ILoggerSink Sink { get; set; }
        public DataAccessFootprint LogData { get; set; }

        #region Constructors
        public DataAccessResult(DataAccessFootprint footprint)
        {        
            this.Operation = footprint.Operation;
            this.Message = footprint.Message;
            this.IsSuccess = footprint.IsSuccess;
            this.Objects = new List<DataAccessOperationObjects>();
            this.LogData = footprint;
        }
        public DataAccessResult(DataAccessFootprint footprint , ILoggerSink sink)
        {
            this.Operation = footprint.Operation;
            this.Message = footprint.Message;
            this.IsSuccess = footprint.IsSuccess;
            this.Objects = new List<DataAccessOperationObjects>();
            this.LogData = footprint.AddSink(sink);
            this.Sink = sink;
        }
        #endregion
        public void AddDataAccessObject(DataAccessOperationObjects data)
        {
            this.Objects.Add(data);
        }
        public virtual void LogOperation()
        {
            if (this.Sink != null)
            {
                System.Type type = Sink.GetType();
                if (type == typeof(AzureTableSink))
                {
                    LoggerHelper.Log(DataAccessLoggerType.AzureTable, Sink, this.LogData);
                }
                if (type == typeof(ConsoleSink))
                {
                    LoggerHelper.Log(DataAccessLoggerType.Console, Sink, this.LogData);
                }
                if (type == typeof(DatabaseSink))
                {
                    LoggerHelper.Log(DataAccessLoggerType.Database, Sink, this.LogData);
                }
                if (type == typeof(EventLogSink))
                {
                    LoggerHelper.Log(DataAccessLoggerType.EventLog, Sink, this.LogData);
                }
                if (type == typeof(FileSink))
                {
                    LoggerHelper.Log(DataAccessLoggerType.File, Sink, this.LogData);
                }
            }
            else
            {
                LoggerHelper.Log(DataAccessLoggerType.Console,null, this.LogData);
            }
        }
    }
}
