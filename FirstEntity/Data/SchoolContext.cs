using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FirstEntity.Entity.Views;

public class SchoolContext : DbContext
{
    public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }

    public DbSet<Person> People { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }

    public DbSet<TeacherSubjectView> TeacherSubjects { get; set; }
    public DbSet<StudentInfo> StudentInfos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TeacherSubjectView>(e =>
        {
            e.HasNoKey();
            e.ToView("V_Teacher_Subject");
        });

        modelBuilder.Entity<StudentInfo>(e =>
        {
            e.HasNoKey();
        });

        modelBuilder.Entity<Student>().HasKey(s => s.StudentNumber);

        modelBuilder.Entity<Student>()
            .HasOne(s => s.Person)
            .WithMany()
            .HasForeignKey(s => s.PersonId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Teacher>()
            .HasOne(t => t.Person)
            .WithMany()
            .HasForeignKey(t => t.PersonId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Teacher>()
            .HasOne(t => t.Subject)
            .WithMany()
            .HasForeignKey(t => t.SubjectId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Class>()
            .HasOne(c => c.Teacher)
            .WithMany()
            .HasForeignKey(c => c.TeacherId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Student)
            .WithMany()
            .HasForeignKey(e => e.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Class)
            .WithMany()
            .HasForeignKey(e => e.ClassId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    public async Task<List<StudentInfo>> GetStudentByStudentNumberAsync(int studentNumber)
    {
        return await StudentInfos
            .FromSqlRaw("EXEC GetStudentByStudentNumber @StudentNumber = {0}", studentNumber)
            .ToListAsync();
    }
}