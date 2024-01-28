using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University.Data;
using University.Model;

namespace University.Controllers;

public class LectureController : Controller
{
    private readonly AppDbContext _context;

    public LectureController(AppDbContext context)
    {
        _context = context;
    }
    
        [HttpPost("AddLectureInSpecificSubject/{id:int}")]
        public async Task<IActionResult> AddLecture([FromRoute] int id, [FromBody] Lecture? lecture)
        {
           
            if (lecture == null)
            {
                return BadRequest();
            }
            lecture.SubjectId = id;
            _context.Lectures.Add(lecture);
            var res = await _context.SaveChangesAsync();
            return Ok();
        }

    
    
    [HttpGet("GetLectureBySubject/{id:int}")]
    public IActionResult GetLectureBySubject([FromQuery] Lecture lecture)
    {
        var lectureBySubject = _context.Lectures.ToList().FirstOrDefault();
        return Ok(lectureBySubject);
    }
}