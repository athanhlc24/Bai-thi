using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Bai_thi.Entities
{
    [Table("add_new_pages")]
    public class AddNewPage
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }

        [Required]
        public DateTime start_time { get; set; }

        [Required]
        public DateTime exam_date { get; set; }

        [Required]
        public string exam_duration { get; set; }

      
    }
}
