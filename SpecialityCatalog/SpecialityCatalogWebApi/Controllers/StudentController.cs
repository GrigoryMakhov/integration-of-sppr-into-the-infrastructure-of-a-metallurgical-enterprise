using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCData.Models;
using SpecialityCatalogWebApi.Data;

namespace SpecialityCatalogWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly StudentsDbContext _studentsDbContext;

        public StudentController(StudentsDbContext studentsDbContext)
        {
            _studentsDbContext = studentsDbContext;
        }

        [HttpGet]
        public List<Student> Get()
        {
            var students = _studentsDbContext.Students
                .Include(x=>x.Group)
                .Include(x => x.Direction)
                .ToList();

            return students;
        }


        [HttpGet("{id}")]
        public Student Get(int id)
        {
            var student = _studentsDbContext.Students.FirstOrDefault(x => x.Id == id);


            return student;
        }


        [HttpPost("{id}")]
        public IActionResult Post(int id, Student student)
        {
            var existStudent = _studentsDbContext.Students.FirstOrDefault(x => x.Id == id);

            if (existStudent == null)
            {
                return NotFound();
            }

            existStudent.LastName = student.LastName;
            existStudent.FirstName = student.FirstName;
            existStudent.MiddleName = student.MiddleName;
            existStudent.GroupId = student.GroupId;
            existStudent.DirectionId = student.DirectionId;

            _studentsDbContext.Students.Update(existStudent);
            _studentsDbContext.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Student student)
        {
            _studentsDbContext.Students.Add(student);
            _studentsDbContext.SaveChanges();

            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existStudent = _studentsDbContext.Students.FirstOrDefault(x => x.Id == id);

            if (existStudent == null)
            {
                return NotFound();
            }

            _studentsDbContext.Students.Remove(existStudent);
            _studentsDbContext.SaveChanges();

            return Ok();
        }
    }
}