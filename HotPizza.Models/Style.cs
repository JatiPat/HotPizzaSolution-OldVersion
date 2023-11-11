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
        [MaxLength(50)] //max length of text
        public string Name { get; set; } = null!; //added to get rid of nullable warning
        [DisplayName("Display Order")] //For Display in Create page
        [Range(0, 100,ErrorMessage ="Must be between 1-100 and no duplicates")] //value must be between 0 to 100
        public int DisplayOrder { get; set; }
    }
}
