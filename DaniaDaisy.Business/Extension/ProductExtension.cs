using System;
using DaniaDaisy.EntityFramework;
using DaniaDaisy.Business.DTO;
namespace DaniaDaisy.Business
{
    public static class ProductExtension
    {
        public static bool Validate(this ProductAddDTO dto)
        {
            dto.IsValidated = true;
            if (string.IsNullOrEmpty(dto.ProductName))
            {
                dto.IsValidated = false;
                dto.ValidationErrors.Add("Product Name Cannot Be Empty");
            }
            if (string.IsNullOrEmpty(dto.ProductCategory))
            {
                dto.IsValidated = false;
                dto.ValidationErrors.Add("Product Category Cannot Be Empty");
            }
            return dto.IsValidated;
        }
        public static Products ToAddEntity(this ProductAddDTO dto)
        {
            return new Products()
            {
                IsOnline = dto.IsOnline,
                ProductCategory = dto.ProductCategory,
                ProductId = Guid.NewGuid(),
                ProductName = dto.ProductName,
            };
        }
        public static bool Validate(this ProductUpdateDTO dto)
        {
            dto.IsValidated = true;
            if (string.IsNullOrEmpty(dto.ProductName))
            {
                dto.IsValidated = false;
                dto.ValidationErrors.Add("Product Name Cannot Be Empty");
            }
            if (string.IsNullOrEmpty(dto.ProductCategory))
            {
                dto.IsValidated = false;
                dto.ValidationErrors.Add("Product Category Cannot Be Empty");
            }
            return dto.IsValidated;
        }
        public static Products ToUpdateEntity(this ProductUpdateDTO dto, Products dbdata)
        {
            dbdata.IsOnline = dto.IsOnline;
            dbdata.ProductCategory = dto.ProductCategory;
            dbdata.ProductName = dto.ProductName;
            return dbdata;
        }
        
    }
}
