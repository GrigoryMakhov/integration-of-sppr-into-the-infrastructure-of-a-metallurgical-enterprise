using Microsoft.AspNetCore.Mvc;
using SCData.Models;
using SpecialityCatalogWebApi.Data;
using static SpecialityCatalogWebApi.Controllers.StudentController;

namespace SpecialityCatalogWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstituteController : ControllerBase
    {
        private readonly StudentsDbContext _studentsDbContext;

        public InstituteController(StudentsDbContext studentsDbContext)
        {
            _studentsDbContext = studentsDbContext;
        }


        public class InstitutetFilter
        {
            public int? InstitutetId { get; set; }
            public string? Name { get; set; }

            


        }

        [HttpPost]
        [Route("[action]")]
        public List<Institute> Index([FromBody] InstitutetFilter filter)
        {
            var quaery = _studentsDbContext.Institutes.AsQueryable();

            if (filter.InstitutetId != null) quaery = quaery.Where(x => x.Id == filter.InstitutetId);
            if (!string.IsNullOrEmpty(filter.Name)) quaery = quaery.Where(x => x.Name.Contains(filter.Name));

            var institutes = quaery.ToList();
            return institutes;
        }


        [HttpGet ("{id}")]
        public Institute Get(int id)
        {
            var institute = _studentsDbContext.Institutes.FirstOrDefault(x => x.Id == id);


            return institute;
        }


        [HttpPost("{id}")]
        public IActionResult Post(int id, Institute institute)
        {
           var existInstitute = _studentsDbContext.Institutes.FirstOrDefault(x => x.Id ==id);
            if (existInstitute == null)
            {
                return NotFound();
            }

            existInstitute.Name = institute.Name;
           

            _studentsDbContext.Institutes.Update(existInstitute);
            _studentsDbContext.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Institute institute)
        {
            _studentsDbContext.Institutes.Add(institute);
            _studentsDbContext.SaveChanges();

            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existInstitute = _studentsDbContext.Institutes.FirstOrDefault(x => x.Id == id);
            if (existInstitute == null)
            {
                return NotFound();
            }

            _studentsDbContext.Institutes.Remove(existInstitute);
            _studentsDbContext.SaveChanges();
            
            return Ok();
        }
    }
}
