using Microsoft.AspNetCore.Mvc;
using University.Data;
using University.Model;

namespace University.Controllers;

public class StudentSubjectController : Controller
{
    private readonly AppDbContext _context;

    public StudentSubjectController(AppDbContext context)
    {
        _context = context;
    }
    [HttpPost("AddStudentToSubjectOrClass")]
    public IActionResult AddStudentToSubjectOrClass([FromBody] StudentSubjectLinkDto studentSubjectLinkDto)
    {

        var objekt = new StudentSubjectLink(); // E kriojmi si objekt 
        objekt.SubjectId = studentSubjectLinkDto.SubjectId;
        objekt.StudentId = studentSubjectLinkDto.StudentId;
        objekt.Progress = 0;
        _context.StudentSubjectLinks.Add(objekt);
        _context.SaveChanges();
        return Ok();
    }
    
    [HttpGet("GetAllStudentSubject")]
    public IActionResult GetAllStudentSubject()
    {
        var allStudentSubject = _context.StudentSubjectLinks.ToList();
    
        return Ok(allStudentSubject);
    }

}