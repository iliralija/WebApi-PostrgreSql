using Microsoft.EntityFrameworkCore;
using University.Model;

namespace University.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions option) : base(option)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        
        base.OnModelCreating(modelBuilder);
        
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Lecture> Lectures { get; set; }

    public DbSet<StudentSubjectLink> StudentSubjectLinks { get; set; }
}