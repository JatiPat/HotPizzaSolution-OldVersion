using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HotPizza.Models
{
    public class Style
    {
        [Key] //I know I don't need to add this, but it's always useful for readablity
        public int Id { get; set; }
        [Required]
        [DisplayName("Pizza Style")] //For Display in Create page
        public string Name { get; set; } = null!; //added to get rid of nullable warning
        [DisplayName("Display Order")] //For Display in Create page
        public int DisplayOrder { get; set; }
    }
}
