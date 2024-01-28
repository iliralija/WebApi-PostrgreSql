using Microsoft.AspNetCore.Mvc;
using University.Data;
using University.Model;

namespace University.Controllers;

public class StudentController : Controller
{
    private readonly AppDbContext _context;

    public StudentController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("AddStudent")]
    public IActionResult AddStudent([FromBody] Student student)
    {
        student.Id = 0;
        var addStudent =  _context.Students.Add(student);
        if (addStudent == null || student.Id != 0)
        {
            return BadRequest();
        }
    
        _context.SaveChanges();
        return Ok(addStudent.Entity);
    }
    
    [HttpGet("GetAllStudents")]
    public IActionResult GetAllStudents()
    {
        var allStudents = _context.Students.ToList();
    
        return Ok(allStudents);
    }
    
    [HttpDelete("DeleteStudent/{id:int}")]
    public IActionResult DeleteStudent(int id)
    {
        var selectedStudent = _context.Students.FirstOrDefault(x => x.Id == id);
        if (selectedStudent == null)
        {
            return BadRequest();
        }
        _context.Students.Remove(selectedStudent);
        _context.SaveChanges();
        return Ok("Operation was succesfully commited");
    }
    
    
}