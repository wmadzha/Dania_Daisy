using System;
using System.Collections.Generic;
using System.Text;

namespace DaniaDaisy.Business.DTO
{
    public interface IDtoValidations
    {
        bool IsValidated { get; set; }
        List<string> ValidationErrors { get; set; }
    }
}
