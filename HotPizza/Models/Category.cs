using System.ComponentModel.DataAnnotations;

namespace HotPizza.Models
{
    public class Category
    {
        [Key] //I know I don't need to add this, but it's always useful for readablity
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!; //added to get rid of nullable warning
        public int DisplayOrder { get; set; }
    }
}
