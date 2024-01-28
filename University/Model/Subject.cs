using System.ComponentModel.DataAnnotations;

namespace University.Model;

public class Subject
{
   [Key] 
    public long Id { get; set; }
    public string Name { get; set; }
    
    public long TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    public IList<Lecture> Lectures { get; set; }
    public IList<StudentSubjectLink> StudentSubjectLinks { get; set; }
}