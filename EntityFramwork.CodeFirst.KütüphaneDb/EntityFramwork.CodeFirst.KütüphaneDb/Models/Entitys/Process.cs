using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramwork.CodeFirst.KütüphaneDb.Models.Entitys
{
    public sealed class Process
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public Student? student { get; set; }
        [Required]
        public List<Book>? book { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime ADate { get; set; } = DateTime.Now;// Alış Tarihi
        [DataType(DataType.DateTime)]
        public DateTime VDate { get; set; } = DateTime.Now;// Veriliş Tarih
    }
}
