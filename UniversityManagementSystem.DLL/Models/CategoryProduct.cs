using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityManagementSystem.API.Models
{
    [Table("CategoryProducts")]
    public class CategoryProduct
    { 
       public int ProductId {  get; set; }
       public Product Product { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
