using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Bai_thi.Entities
{
    [Table("subjects")]
    public class Subject
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(255)]
        public string name { get; set; }
    }
}
