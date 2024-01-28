using System.ComponentModel.DataAnnotations;

namespace University.Model;

public class StudentSubjectLink
{
    [Key]
    public long Id { get; set; }
    
    public long Progress { get; set; }
    public Grade? Grade { get; set; }
    
    public long StudentId { get; set; }
    public  Student Student { get; set; }
    
    public long SubjectId { get; set; }
    public  Subject Subject { get; set; }
    
}

public enum Grade
{
    Bad = 1,
    NotBad =2,
    Okay = 3,
    Good = 4,
    Best = 5
}