using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramwork.CodeFirst.KütüphaneDb.Models.Entitys
{
    public sealed class Student
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string? StudentName { get; set; }
        [Required, MaxLength(50)]
        public string? StudentLastName { get; set; }
        [Required]
        public Gender gender { get; set; } = Gender.Erkek;
        [DataType(DataType.DateTime)]
        public DateTime date { get; set; }
        [Required]
        public Classes? classes { get; set; }
    }
    public enum Gender
    {
        Erkek,
        Kadın
    }
}
