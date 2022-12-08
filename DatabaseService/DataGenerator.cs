using Bogus;
using DatabaseService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseService
{
    public static class DataGenerator
    {
        public static Product CreateProduct()
        {
            var prodcutsGenerator = new Faker<Product>()
                .RuleFor(i => i.Id, f => f.IndexGlobal)
                .RuleFor(n => n.Name, f => f.Commerce.ProductName())
                .RuleFor(d => d.Description, f => f.Commerce.ProductDescription())
                .RuleFor(p => p.Price, f => f.Commerce.Price());
                
            return prodcutsGenerator.Generate();
        }
    }
}
