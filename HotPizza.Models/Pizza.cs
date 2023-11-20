using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotPizza.Models
{
    public class Pizza
    {
        [Key]
        public int Id { get; set; }
       
        [Required]
        [MaxLength(100)]
        [DisplayName("Pizza Name")]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        [Range(0, 100)]
        public double Price { get; set; }

        public int StyleId { get; set; }
        [ForeignKey("StyleId")]
        public Style Style { get; set; }

        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }


    }
}
