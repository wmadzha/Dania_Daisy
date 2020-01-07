using System;
using DaniaDaisy.DataAccess.Common.Model;

namespace DaniaDaisy.DataAccess.Common.Logger
{
    public class ConsoleLogger : DataAccessLogger
    {
        private ConsoleSink _Sink { get; set; }
        public ConsoleLogger(ILoggerSink sink)
        {
            _Sink = sink as ConsoleSink;
        }
        public ConsoleLogger()
        {
            
        }
        public override void Log(DataAccessFootprint logDetails)
        {
            lock (logLocker)
            {
                if(_Sink != null)
                {
                    Console.ForegroundColor = _Sink.ForegroundColor;
                }
                Console.WriteLine("Method Name : " + logDetails.MethodName
                               + ", Message : " + logDetails.Message
                               + ", Operation : " + logDetails.Operation
                               + ", ReferralLibrary : " + logDetails.ReferralLibrary
                               + ", SourceApplicationDomainName : " + logDetails.SourceApplicationDomainName
                               + ", SourceMachineName : " + logDetails.SourceMachineName+Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }   
    }
}
