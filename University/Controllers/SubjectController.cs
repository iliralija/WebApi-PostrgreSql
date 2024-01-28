using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University.Data;
using University.Model;

namespace University.Controllers;

public class SubjectController : Controller
{
    private readonly AppDbContext _context;

    public SubjectController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("AddSubject")]
    public async Task<IActionResult> AddSubject([FromBody] Subject subject)
    {
        _context.Subjects.Add(subject);
        await _context.SaveChangesAsync();
        return Ok();
    }
    
    [HttpGet("GetAllSubjects")]
    public IActionResult GetAllSubjects()
    {
        var allSubjects = _context.Subjects
            .Include(s => s.StudentSubjectLinks)
            .ThenInclude(ssl => ssl.Student)
            .ToList();
        
        return Ok(allSubjects);
    }

}