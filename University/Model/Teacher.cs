using System.ComponentModel.DataAnnotations;

namespace University.Model;

public class Teacher
{
    [Key] 
    public long Id { get; set; }
    public string Name { get; set; }
    
    public Subject? Subject { get; set; }
}