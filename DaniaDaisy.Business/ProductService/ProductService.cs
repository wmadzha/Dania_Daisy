using DaniaDaisy.Business.DTO;
using DaniaDaisy.DataAccess.Common;
using DaniaDaisy.DataAccess.Common.DataAccessResults;
using DaniaDaisy.DataAccess.Common.Model;
using DaniaDaisy.EntityFramework;
using System;
namespace DaniaDaisy.Business.ProductService
{
    public class ProductService
    {
        private string _BusinessDataConnectionString { get; set; }
        private DataAccessOperationObjects _DtoObjects { get; set; }
        private ILoggerSink _Sink { get; set; }
        public ProductService(string connectionString)
        {
            _BusinessDataConnectionString = connectionString;
        }
        public ProductService(string connectionString, ILoggerSink sink):this(connectionString)
        {
            _Sink = sink;
        }
        public bool Add (ProductAddDTO dto )
        {
            string MethodName = "AddProduct";
            _DtoObjects = new DataAccessOperationObjects()
            {
                DataAccessObject = dto,
                ObjectContext = "Products",
                ObjectName = "ProductAddDTO",
            };
            if (dto.Validate())
            {
                try
                {
                    /// Disabled For Testing Purpose - Logger Simulation

                    //ProductContext db = new ProductContext(_BusinessDataConnectionString);
                    // db.Products.Add(dto.ToAddEntity());
                    // db.SaveChanges();
                    AddDataAccessResult result = new AddDataAccessResult(MethodName, "Successfully Add Product", true, _Sink);
                    result.AddDataAccessObject(_DtoObjects);
                    result.LogOperation();
                    return true;
                }
                catch (Exception ex)
                {
                    AddDataAccessResult result = new AddDataAccessResult(MethodName, "Error Adding Products : "+ex.Message, false, _Sink);
                    result.AddDataAccessObject(_DtoObjects);
                    result.LogOperation();
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
