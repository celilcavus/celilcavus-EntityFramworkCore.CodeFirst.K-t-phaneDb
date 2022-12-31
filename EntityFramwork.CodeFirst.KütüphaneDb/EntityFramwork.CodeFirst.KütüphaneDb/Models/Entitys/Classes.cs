using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramwork.CodeFirst.KütüphaneDb.Models.Entitys
{
    public sealed class Classes
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required,MaxLength(30)]
        public string? ClassName { get; set; }
    }
}