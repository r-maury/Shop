using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop.core.Models {
    public class ProductCategory {
        public int Id { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
