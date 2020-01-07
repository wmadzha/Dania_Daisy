

namespace DaniaDaisy.DataAccess.Common.DataAccessResults
{

    public class DeleteDataAccessResult : DataAccessResult
    {
        public DeleteDataAccessResult(string methodname, string message, bool issuccess)
        : base(new Model.DataAccessFootprint(DataAccessOperation.Delete, methodname, message, issuccess))
        {
        }
        public DeleteDataAccessResult(string methodname, string message, bool issuccess, ILoggerSink sink)
       : base(new Model.DataAccessFootprint(DataAccessOperation.Delete, methodname, message, issuccess), sink)
        {
        }
    }
}
