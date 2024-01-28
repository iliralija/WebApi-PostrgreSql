using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University.Data;
using University.Model;

namespace University.Controllers;

public class TeacherController : ControllerBase
{
    private readonly AppDbContext _context;

    public TeacherController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("CreateTeacher")]
    public async Task<IActionResult> CreateTeacher([FromBody] Teacher? teacher)
    {
        if (teacher == null)
        {
            return BadRequest();
        }
        
        _context.Teachers.Add(teacher);

        await _context.SaveChangesAsync();
      
        return Ok();
    }
    
    [HttpGet("GetAllTeachers")]
    public IActionResult GetAllTeachers()
    {
        var allTeachers = _context.Teachers
            .Include(tch => tch.Subject).ThenInclude(s => s!.Lectures)
            .Include(tch => tch.Subject).ThenInclude(s => s!.StudentSubjectLinks)
            .ToList();
        return Ok(allTeachers);
    }
    
}