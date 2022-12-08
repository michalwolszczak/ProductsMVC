using DatabaseService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DatabaseService.Helpers
{
    public interface IXmlHelper
    {
        XDocument CreateXmlDocument();
        ICollection<Product> GetProductsFromXml(XDocument xml);
    }

    public class XmlHelper : IXmlHelper
    {
        public XDocument CreateXmlDocument()
        {
            var productElements = Enumerable.Range(0, 3)
               .Select(i => DataGenerator.CreateProduct())
               .Select(p => new XElement("Product",
                   new XElement("Id", p.Id),
                   new XElement("Name", p.Name),
                   new XElement("Description", p.Description),
                   new XElement("Price", p.Price)
               ));

            return new XDocument(new XElement("Products", productElements));
        }

        public ICollection<Product> GetProductsFromXml(XDocument xml)
        {
            return xml.Descendants("Product")
                .Select(p => new Product
                {
                    Name = (string)p.Element("Name"),
                    Description = (string)p.Element("Description"),
                    Price = (string)p.Element("Price")
                }).ToList();
        }
    }
}
