using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramwork.CodeFirst.KütüphaneDb.Models.Entitys
{
    public sealed class Book
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public Process? Process { get; set; }
        [Required,MaxLength(50)]
        public string? BookName { get; set; }
        [Required]
        public Author? Author { get; set; }
        [Required]
        public Types? Type { get; set; }
        [Required, MaxLength(15)]
        public float PageCount { get; set; }
        [Required, MaxLength(50)]
        public int Bookpoint { get; set; }
    }
}