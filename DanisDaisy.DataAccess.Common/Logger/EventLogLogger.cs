using DaniaDaisy.DataAccess.Common.Model;
using System;
using System.Diagnostics;
namespace DaniaDaisy.DataAccess.Common.Logger
{

    public class EventLogLogger : DataAccessLogger
    {
        private EventLogSink _Sink { get; set; }
        public EventLogLogger(ILoggerSink sink)
        {
            _Sink = sink as EventLogSink;
        }
        public override void Log(DataAccessFootprint logDetails)
        {
            lock (logLocker)
            {
                if (_Sink == null)
                {
                    Console.WriteLine("There is no Event Log sink being setup");
                }
                else
                {
                    try
                    {
                        EventLog events = new EventLog();
                        events.Source = logDetails.ReferralLibrary;
                        events.MachineName = logDetails.SourceMachineName;
                        events.WriteEntry("Method Name : " + logDetails.MethodName
                                   + ", Message : " + logDetails.Message
                                   + ", Operation : " + logDetails.Operation
                                   + ", ReferralLibrary : " + logDetails.ReferralLibrary
                                   + ", SourceApplicationDomainName : " + logDetails.SourceApplicationDomainName
                                   + ", SourceMachineName : " + logDetails.SourceMachineName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Data Access Sink Error : Event Log Sink , Error : " + ex.Message);
                    }
                }
            }
        }

    }
}
