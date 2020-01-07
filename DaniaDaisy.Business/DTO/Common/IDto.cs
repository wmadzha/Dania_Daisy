using System;
using System.Collections.Generic;
using System.Text;

namespace DaniaDaisy.Business.DTO
{
    public interface IDto
    {
        Guid UserId { get; set; }
        Guid TransactionRequestId { get; set; }
        string ApplicationName { get; set; }
    
    }
}
