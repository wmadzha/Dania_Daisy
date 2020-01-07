using System;
using System.Collections.Generic;
using System.Text;

namespace DaniaDaisy.Business.DTO
{
    public abstract class ProductDTO : Dto
    {
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public Boolean? IsOnline { get; set; }
    }
}
