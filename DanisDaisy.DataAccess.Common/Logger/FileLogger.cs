using DaniaDaisy.DataAccess.Common.Model;
using System;
using System.IO;
namespace DaniaDaisy.DataAccess.Common.Logger
{


    public class FileLogger : DataAccessLogger
    {
        private FileSink _Sink { get; set; }
        public FileLogger(ILoggerSink sink)
        {
           _Sink = sink as FileSink;
        }
        public override void Log(DataAccessFootprint logDetails)
        {
            lock (logLocker)
            {
                if (_Sink == null)
                {
                    Console.WriteLine("There is no File sink being setup");
                }
                else
                {
                    try
                    {
                        using (StreamWriter streamWriter = new StreamWriter(_Sink.FilePath))
                        {
                            streamWriter.WriteLine("Method Name : " + logDetails.MethodName
                                   + ", Message : " + logDetails.Message
                                   + ", Operation : " + logDetails.Operation
                                   + ", ReferralLibrary : " + logDetails.ReferralLibrary
                                   + ", SourceApplicationDomainName : " + logDetails.SourceApplicationDomainName
                                   + ", SourceMachineName : " + logDetails.SourceMachineName);
                            streamWriter.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Data Access Sink Error : File Sink , Error : " + ex.Message);
                    }
                }
            }
        }

    }
}
