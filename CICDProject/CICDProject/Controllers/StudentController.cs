using CICDProject.Data;
using CICDProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CICDProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(StudentRepository.Students);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var student = StudentRepository.Students
                .FirstOrDefault(x => x.Id == id);

            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            student.Id = StudentRepository.Students.Max(x => x.Id) + 1;

            StudentRepository.Students.Add(student);

            return CreatedAtAction(nameof(Get),
                new { id = student.Id },
                student);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Student student)
        {
            var existing = StudentRepository.Students
                .FirstOrDefault(x => x.Id == id);

            if (existing == null)
                return NotFound();

            existing.Name = student.Name;
            existing.Age = student.Age;
            existing.City = student.City;

            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = StudentRepository.Students
                .FirstOrDefault(x => x.Id == id);

            if (student == null)
                return NotFound();

            StudentRepository.Students.Remove(student);

            return NoContent();
        }
    }
}
