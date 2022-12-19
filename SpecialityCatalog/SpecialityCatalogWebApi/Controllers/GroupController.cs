using Microsoft.AspNetCore.Mvc;
using SCData.Models;
using SpecialityCatalogWebApi.Data;

namespace SpecialityCatalogWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly StudentsDbContext _studentsDbContext;

        public GroupController(StudentsDbContext studentsDbContext)
        {
            _studentsDbContext = studentsDbContext;
        }

        [HttpGet]
        public List<Group> Get()
        {
            var groups = _studentsDbContext.Groups.ToList();


            return groups;
        }


        [HttpGet ("{id}")]
        public Group Get(int id)
        {
            var group = _studentsDbContext.Groups.FirstOrDefault(x => x.Id == id);


            return group;
        }


        [HttpPost("{id}")]
        public IActionResult Post(int id, Group group)
        {
           var existGroup = _studentsDbContext.Groups.FirstOrDefault(x => x.Id ==id);
            if (existGroup == null)
            {
                return NotFound();
            }

            existGroup.Name = group.Name;
            existGroup.Type = group.Type;

            _studentsDbContext.Groups.Update(existGroup);
            _studentsDbContext.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Group group)
        {
            _studentsDbContext.Groups.Add(group);
            _studentsDbContext.SaveChanges();

            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existGroup = _studentsDbContext.Groups.FirstOrDefault(x => x.Id == id);
            if (existGroup == null)
            {
                return NotFound();
            }

            _studentsDbContext.Groups.Remove(existGroup);
            _studentsDbContext.SaveChanges();
            
            return Ok();
        }
    }
}
