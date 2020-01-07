using System;
using System.Collections.Generic;
using System.Text;

namespace DaniaDaisy.DataAccess.Common.DataAccessResults
{

    public class UpdateDataAccessResult : DataAccessResult
    {
        public UpdateDataAccessResult(string methodname, string message, bool issuccess)
        : base(new Model.DataAccessFootprint(DataAccessOperation.Update, methodname, message, issuccess))
        {
        }
        public UpdateDataAccessResult(string methodname, string message, bool issuccess, ILoggerSink sink)
       : base(new Model.DataAccessFootprint(DataAccessOperation.Update, methodname, message, issuccess), sink)
        {
        }
    }
}
