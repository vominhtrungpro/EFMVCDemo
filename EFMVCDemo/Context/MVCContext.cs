using EFMVCDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EFMVCDemo.Context
{
    public class MVCContext : DbContext
    {
        public MVCContext(DbContextOptions options):base(options)
        {

        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<StudentSubject>()
        //.HasKey(c => new { c.StudentId, c.SubjectId });
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentSubject>()
                .HasOne(sub => sub.subject)
                .WithMany(ss => ss.StudentSubjects)
                .HasForeignKey(subid => subid.SubjectId);

            modelBuilder.Entity<StudentSubject>()
                .HasOne(stu => stu.student)
                .WithMany(ss => ss.StudentSubjects)
                .HasForeignKey(stuid => stuid.StudentId);
        }

        public DbSet<Student> Students { get; set; }
        
        public DbSet<Subject> Subject { get; set; }

    public DbSet<StudentSubject> StudentSubjects { get; set; }



}
}
