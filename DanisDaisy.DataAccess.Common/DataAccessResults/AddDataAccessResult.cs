using System;
using System.Collections.Generic;
using System.Text;

namespace DaniaDaisy.DataAccess.Common.DataAccessResults
{
    public class AddDataAccessResult : DataAccessResult
    {
        public AddDataAccessResult(string methodname, string message, bool issuccess)
        : base(new Model.DataAccessFootprint(DataAccessOperation.Add, methodname, message, issuccess))
        {
        }
        public AddDataAccessResult(string methodname, string message, bool issuccess , ILoggerSink sink)
       : base(new Model.DataAccessFootprint(DataAccessOperation.Add, methodname, message, issuccess),sink)
        {
        }
    }
}
