using DaniaDaisy.DataAccess.Common.Logger;
using DaniaDaisy.DataAccess.Common.Model;

namespace DaniaDaisy.DataAccess.Common.Core.Logger
{
    public static class LoggerHelper
    {
        public static void Log(DataAccessLoggerType type, ILoggerSink sink, DataAccessFootprint logData)
        {
            if(sink != null)
            {
                switch (type)
                {
                    case DataAccessLoggerType.Console:
                        new ConsoleLogger(sink).Log(logData);
                        break;
                    case DataAccessLoggerType.Database:
                        new DatabaseLogger(sink).Log(logData);
                        break;
                    case DataAccessLoggerType.EventLog:
                        new EventLogLogger(sink).Log(logData);
                        break;
                    case DataAccessLoggerType.AzureTable:
                        new AzureTableLogger(sink).Log(logData);
                        break;
                    case DataAccessLoggerType.File:
                        new FileLogger(sink).Log(logData);
                        break;
                    default:
                        return;
                }
            }
            else
            {
                new ConsoleLogger().Log(logData);
            }
        }
      
    }
}
