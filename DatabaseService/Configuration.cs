using AutoMapper;
using DatabaseService.Entities;
using DatabaseService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseService
{
    public sealed class Configuration
    {
        private static Configuration _instance;
        public MapperConfiguration MapperConfiguration;

        private Configuration() 
        {
            MapperConfiguration = new MapperConfiguration(cfg => {
                cfg.CreateMap<Product, ProductDto>();
                cfg.CreateMap<CreateProductDto, Product>();
            });
        }

        public static Configuration GetInstance()
        {
            if (_instance is null)
                _instance = new Configuration();

            return _instance;
        }
    }
}
