using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DatabaseService.Models
{
    public class CreateProductDto
    {        
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }

    }
}
