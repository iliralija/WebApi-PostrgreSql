namespace University.Model;

public class Lecture
{
    public long Id { get; set; }
    public string Title { get; set; }
    
    public long SubjectId { get; set; }
    public Subject Subject { get; set; }
}