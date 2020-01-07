using DaniaDaisy.DataAccess.Common.Model;
namespace DaniaDaisy.DataAccess.Common
{
    public abstract class DataAccessLogger
    {
        protected readonly object logLocker = new object();
        public abstract void Log(DataAccessFootprint logDetails);
    }
}
