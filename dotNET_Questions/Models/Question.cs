using System.ComponentModel.DataAnnotations;

namespace dotNET_Questions.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Problem { get; set; }
        public string Answer { get; set; }
    }
}
