using DatabaseService.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseServiceTests.Helpers
{
    [TestClass]
    public class XmlHelperTests
    {
        [TestMethod]
        public void CreateXmlDocument_WhenExecutionSuccessful_ReturnXmlDocument()
        {
            //Arrange
            var xmlHelper = new XmlHelper();

            //Act
            var result = xmlHelper.CreateXmlDocument();

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetProductsFromXml_WhenExecutionSuccessful_ReturnListOfProducts()
        {
            //Arrange
            var xmlHelper = new XmlHelper();
            var xmlDoc = xmlHelper.CreateXmlDocument();

            //Act
            var result = xmlHelper.GetProductsFromXml(xmlDoc);

            //Assert
            Assert.IsTrue(result.Count > 0);
        }
    }
}
