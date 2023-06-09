using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCData.Models;
using SpecialityCatalogWebApi.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static SpecialityCatalogWebApi.Controllers.GroupController;

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

        public class StudentFilter
        {
            public int? StudentId { get; set; }
            public int? GroupId { get; set; }
            public int? DirectionId { get; set; }
            public int? InstituteId { get; set; }
            public string? LastName { get; set; }

            public string? FirstName { get; set; }

            public string? MiddleName { get; set; }

            public string? GroupName { get; set; }

            public string? DirectionName { get; set; }
            public string? InstituteName { get; set; }



        }


        [HttpPost]
        [Route("[action]")]
        public List<Student> Index([FromBody] StudentFilter filter)
        {

            var quaery = _studentsDbContext.Students.AsQueryable();

            if (filter.StudentId != null) quaery = quaery.Where(x => x.Id == filter.StudentId);

            if (!string.IsNullOrEmpty(filter.LastName)) quaery = quaery.Where(x => x.LastName.Contains(filter.LastName));
            if (!string.IsNullOrEmpty(filter.FirstName)) quaery = quaery.Where(x => x.FirstName.Contains(filter.FirstName));
            if (!string.IsNullOrEmpty(filter.MiddleName)) quaery = quaery.Where(x => x.MiddleName.Contains(filter.MiddleName));
            if (!string.IsNullOrEmpty(filter.GroupName)) quaery = quaery.Where(x => x.Group.Name.Contains(filter.GroupName));
            if (!string.IsNullOrEmpty(filter.DirectionName)) quaery = quaery.Where(x => x.Direction.Name.Contains(filter.DirectionName));
            if (!string.IsNullOrEmpty(filter.InstituteName)) quaery = quaery.Where(x => x.Institute.Name.Contains(filter.InstituteName));

            var students = quaery
            .Include(x=>x.Group)
                .Include(x => x.Direction)
                .Include(x => x.Institute)
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
            existStudent.InstituteId = student.InstituteId;

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