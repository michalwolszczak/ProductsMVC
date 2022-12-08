using AutoMapper;
using DatabaseService.Entities;
using DatabaseService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DatabaseService.Services
{
    public interface IProductService
    {
        int Create(CreateProductDto dto);
        void CreateAll(IEnumerable<ProductDto> productsDto);
        void DeleteById(int id);
        ProductDto GetById(int id);       
        IEnumerable<ProductDto> GetAll();               
    }

    public class ProductService : IProductService
    {
        private readonly ProductsDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly Configuration _config;
        private readonly XmlHelper _xmlHelper;

        public ProductService()
        {
            _dbContext = new ProductsDbContext();
            _config = Configuration.GetInstance();
            _mapper = _config.MapperConfiguration.CreateMapper();
            _xmlHelper = new XmlHelper();
            SetupXml();
        }

        private void SetupXml()
        {
            var document = _xmlHelper.CreateXmlDocument();
            _dbContext.AddRange(_xmlHelper.GetProductsFromXml(document));
            _dbContext.SaveChanges();
        }

        public void CreateAll(IEnumerable<ProductDto> productsDto)
        {
            var products = _mapper.Map<Product>(productsDto);
            _dbContext.Products.AddRange(products);
            _dbContext.SaveChanges();
        }

        public int Create(CreateProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();

            return product.Id;
        }

        public IEnumerable<ProductDto> GetAll()
        {
            var products = _mapper.Map<List<ProductDto>>(_dbContext.Products);

            return products;
        }

        public ProductDto GetById(int id)
        {
            var product = _dbContext.Products.Find(id);
            if (product is null)
                throw new Exception("Product not found");

            var productDto = _mapper.Map<ProductDto>(product);

            return productDto;
        }

        public void DeleteById(int id)
        {
            var product = _dbContext.Products.Find(id);
            if (product is null)
                throw new Exception("Product not found");

            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
        }
    }
}
