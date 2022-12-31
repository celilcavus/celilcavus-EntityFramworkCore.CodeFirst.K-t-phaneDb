using EntityFramwork.CodeFirst.KütüphaneDb.Models.Entitys;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace EntityFramwork.CodeFirst.KütüphaneDb.Models.AppDatabase
{
    internal class DatabaseContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Classes> Classes { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Types> Types { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            StreamReader st = new StreamReader("D:\\Software\\EF\\EntityFramwork.CodeFirst.KütüphaneDb\\EntityFramwork.CodeFirst.KütüphaneDb\\Models\\JsonConnectionString\\ConnString.json");
            var jsondata = st.ReadToEnd();
            Connstring con = JsonConvert.DeserializeObject<Connstring>(jsondata)!;
            optionsBuilder.UseSqlServer(con.connectionString!.ToString());
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Random random = new Random();
            using (DatabaseContext db = new DatabaseContext())
            {
                for (int i = 0; i < 10; i++)
                {
                    Author author = new Author();
                    author.AuthorName = FakeData.NameData.GetFirstName();
                    author.AuthorSurname = FakeData.NameData.GetSurname();
                    db.Authors.Add(author);
                    db.SaveChanges();

                    Book bk = new Book();
                    bk.BookName = FakeData.TextData.GetNumeric(random.Next(10, 50));
                    bk.PageCount = FakeData.NumberData.GetNumber(10, 10000);
                    bk.Bookpoint = FakeData.NumberData.GetNumber(0, 100);
                    db.Books.Add(bk);
                    db.SaveChanges();

                    Classes cs = new Classes();
                    cs.ClassName = string.Format(FakeData.NumberData.GetNumber(9, 12) + ".Sınıf");
                    db.Classes.Add(cs);
                    db.SaveChanges();

                    Process pro = new Process();
                    pro.ADate = FakeData.DateTimeData.GetDatetime();
                    pro.VDate = FakeData.DateTimeData.GetDatetime();
                    db.Processes.Add(pro);
                    db.SaveChanges();

                    Student st = new Student();
                    st.StudentName = FakeData.NameData.GetFirstName();
                    st.StudentLastName = FakeData.NameData.GetSurname();
                    st.gender = FakeData.EnumData.GetElement<Gender>();
                    st.date = FakeData.DateTimeData.GetDatetime();
                    db.Students.Add(st);
                    db.SaveChanges();
                   
                }
                for (int k = 0; k < 2; k++)
                {
                    Types tp = new Types();
                    string[] type = { "Roman", "Hikaye","Destan"};
                    for (int i = 0; i <= type.Length; i++)
                    {
                        tp.TypeName = type[i];
                        db.Types.Add(tp);
                    }
                    db.SaveChanges();
                }
            }
           
        }
    }
}
