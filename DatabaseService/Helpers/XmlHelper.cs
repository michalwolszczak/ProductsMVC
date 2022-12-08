using DatabaseService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DatabaseService.Services
{
    public interface IHtmlHelper
    {
        XDocument CreateXmlDocument();
        ICollection<Product> GetProductsFromXml(XDocument xml);
    }

    public class XmlHelper : IHtmlHelper
    {
        public XDocument CreateXmlDocument()
        {
            List<XElement> productElements = new List<XElement>();

            for(int i = 0; i<3; i++)
            {
                var product = DataGenerator.CreateProduct();
                productElements.Add(new XElement("Product", 
                    new XElement("Id", product.Id),
                    new XElement("Name", product.Name),
                    new XElement("Description", product.Description),
                    new XElement("Price", product.Price)
                    ));
            }

            XDocument doc = new XDocument(new XElement("Products", productElements));

            return doc;
        }

        public ICollection<Product> GetProductsFromXml(XDocument xml)
        {
            List<Product> products = new List<Product>();

            foreach(var element in xml.Descendants())
            {
                if(element.Name.LocalName == "Product")
                {
                    var product = new Product();
                    foreach (var productElement in element.Descendants())
                    {
                        switch (productElement.Name.LocalName)
                        {
                            case "Name":
                                product.Name = productElement.Value;
                                break;
                            case "Description":
                                product.Description = productElement.Value;
                                break;
                            case "Price":
                                product.Price = productElement.Value;
                                break;
                        }
                    }
                    products.Add(product);
                }                                
            }

            return products;
        }
    }
}
