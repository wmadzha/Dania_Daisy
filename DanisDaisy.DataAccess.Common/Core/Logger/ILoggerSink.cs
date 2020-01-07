

namespace DaniaDaisy.DataAccess.Common
{
    public interface ILoggerSink
    {
        public string SourceMachineName { get; set; }
        public string SourceApplicationDomainName { get; set; }
        public string ReferralLibrary { get; set; }

    }
}
