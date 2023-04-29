using Microsoft.AspNetCore.Mvc;
using SCData.Models;
using SpecialityCatalogWebApi.Data;

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

        [HttpGet]
        public List<Institute> Get()
        {
            var institutes = _studentsDbContext.Institutes.ToList();


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
