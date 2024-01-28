using System.ComponentModel.DataAnnotations;

namespace University.Model;

public class Student
{
    [Key] 
    public long Id { get; set; }
    public string Name { get; set; }
    
    
    public IList<StudentSubjectLink> StudentSubjectLinks { get; set; }
}