using System;
using System.Collections.Generic;
using System.Text;

namespace DaniaDaisy.Business.DTO
{
    public abstract class Dto : IDto , IDtoValidations
    {
        public Guid UserId { get; set; }
        public Guid TransactionRequestId { get; set; }
        public string ApplicationName { get; set; }
        public bool IsValidated { get; set; }
        public List<string> ValidationErrors { get; set; }
        public Dto()
        {
            this.ValidationErrors = new List<string>();
        }
    }
}
