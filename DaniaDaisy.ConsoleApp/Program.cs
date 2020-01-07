using System;
using DaniaDaisy.Business;
using DaniaDaisy.Business.DTO;
using DaniaDaisy.Business.ProductService;
using DaniaDaisy.DataAccess.Common;

namespace DaniaDaisy.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebApi svc;

            string fakeConnectionstring = "Fake Connetion String";

            // Setup Product DTO
            ProductAddDTO product = new ProductAddDTO();
            product.ProductName = "Sample ProductName";
            product.ProductCategory = "Sample Product Category";
            product.IsOnline = true;



            Console.WriteLine("--> Assuming The Data Access Library Are calling From Singapore" +Environment.NewLine);
            // Assuming For each http request each dto is tagged with the appication name when the dto arrived at 
            // Web Api instance
            product.ApplicationName = "Web Api Singapore";
            // Instantiate the Transaction ID
            product.TransactionRequestId = Guid.NewGuid();
            product.UserId = Guid.NewGuid();
            
            svc = new WebAPISingapore(fakeConnectionstring);
            Console.WriteLine("-- ? Centralized Data Access Logger Sink Will Have below Data" + Environment.NewLine);
            svc.AddProduct(product);
            Console.WriteLine("-- > End Of Singapore Web Api Instance"+Environment.NewLine);

            svc = null;

            Console.WriteLine("--> Assuming The Data Access Library Are calling From Europe" + Environment.NewLine);
            // Assuming For each http request each dto is tagged with the appication name when the dto arrived at 
            // Web Api instance
            product.ApplicationName = "Web Api Europe";
            // Instantiate the Transaction ID
            product.TransactionRequestId = Guid.NewGuid();
            product.UserId = Guid.NewGuid();

            svc = new WebAPIEurope(fakeConnectionstring);
            Console.WriteLine("-- ? Centralized Data Access Logger Sink Will Have below Data" + Environment.NewLine);
            svc.AddProduct(product);
            Console.WriteLine("-- > End Of Europe Web Api Instance" + Environment.NewLine);


            Console.WriteLine("--> Assuming The Data Access Library Are calling From Middle East" + Environment.NewLine);
            // Assuming For each http request each dto is tagged with the appication name when the dto arrived at 
            // Web Api instance
            product.ApplicationName = "Web Api Middle East";
            // Instantiate the Transaction ID
            product.TransactionRequestId = Guid.NewGuid();
            product.UserId = Guid.NewGuid();

            svc = new WebAPIMiddleEast(fakeConnectionstring);
            Console.WriteLine("-- ? Centralized Data Access Logger Sink Will Have below Data" + Environment.NewLine);
            svc.AddProduct(product);
            Console.WriteLine("-- > End Of Middle East Web Api Instance" + Environment.NewLine);
        }
    }

    public interface IWebApi
    {
        void AddProduct(ProductAddDTO Data);
    }

    public  class WebAPISingapore : IWebApi
    {
        private string _ConnectionString { get; set; }
        private DataAccessLoggerSinks _Sink { get; set; }
        public WebAPISingapore(string con)
        {
            _Sink = new DataAccessLoggerSinks()
            {
                ReferralLibrary = "ConsoleApp",
                SourceApplicationDomainName = "Console Test",
                SourceMachineName = "WEB_API_SG",
            };
            _ConnectionString = con;
        }
        public void AddProduct(ProductAddDTO Data)
        {
            ConsoleSink sink = new ConsoleSink(this._Sink,ConsoleColor.Red);
            ProductService svc = new ProductService(_ConnectionString, sink);
            if(svc.Add(Data))
            {
                Console.WriteLine("-- ! WebApi Singapore Say Success Add Product" + Environment.NewLine);
            }
            else
            {
                Console.WriteLine("-- ! WebApi Singapore Say Failed Add Product" + Environment.NewLine);
            }
        }
    }
    public class WebAPIEurope : IWebApi
    {
        private string _ConnectionString { get; set; }
        private DataAccessLoggerSinks _Sink { get; set; }
        public WebAPIEurope(string con)
        {
            _Sink = new DataAccessLoggerSinks()
            {
                ReferralLibrary = "ConsoleApp",
                SourceApplicationDomainName = "Console Test",
                SourceMachineName = "WEB_API_EU",
            };
            _ConnectionString = con;
        }
        public void AddProduct(ProductAddDTO Data)
        {
            ConsoleSink sink = new ConsoleSink(this._Sink,ConsoleColor.Blue);
            ProductService svc = new ProductService(_ConnectionString, sink);
            if (svc.Add(Data))
            {
                Console.WriteLine("-- ! WebApi Europe Say Success Add Product" + Environment.NewLine);
            }
            else
            {
                Console.WriteLine("-- ! WebApi Europe Say Failed Add Product" + Environment.NewLine);
            }
        }
    }
    public class WebAPIMiddleEast : IWebApi
    {
        private string _ConnectionString { get; set; }
        private DataAccessLoggerSinks _Sink { get; set; }
        public WebAPIMiddleEast(string con)
        {
            _Sink = new DataAccessLoggerSinks()
            {
                ReferralLibrary = "ConsoleApp",
                SourceApplicationDomainName = "Console Test",
                SourceMachineName = "WEB_API_ME",
            };
            _ConnectionString = con;
        }
        public void AddProduct(ProductAddDTO Data)
        {
            ConsoleSink sink = new ConsoleSink(this._Sink, ConsoleColor.Green);
            ProductService svc = new ProductService(_ConnectionString, sink);
            if (svc.Add(Data))
            {
                Console.WriteLine("-- ! WebApi Europe Say Success Add Product" + Environment.NewLine);
            }
            else
            {
                Console.WriteLine("-- ! WebApi Europe Say Failed Add Product" + Environment.NewLine);
            }
        }
    }
}
