using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImportExcel.Models
{
    public class StudentList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int stuId { get; set; }
        public string name { get; set;}
        public int standard { get; set;}
        public string phone { get; set;}
    }
}