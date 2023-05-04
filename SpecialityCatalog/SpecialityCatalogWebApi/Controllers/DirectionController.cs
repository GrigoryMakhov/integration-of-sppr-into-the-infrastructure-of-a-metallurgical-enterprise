using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCData.Models;
using SpecialityCatalogWebApi.Data;

namespace SpecialityCatalogWebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DirectionController : ControllerBase
    {
        private readonly StudentsDbContext _studentsDbContext;

        public DirectionController(StudentsDbContext studentsDbContext)
        {
            _studentsDbContext = studentsDbContext;
        }

        public class DirectionFilter
        {
            public int? DirectionId { get; set; }
            public string? Name { get; set; }
            
            
        }

        [HttpPost]
        [Route("[action]")]
        public List<Direction> Index([FromBody] DirectionFilter filter)
        {
            var quaery = _studentsDbContext.Directions.AsQueryable();

            if (filter.DirectionId != null) quaery = quaery.Where(x => x.Id == filter.DirectionId);
            if (!string.IsNullOrEmpty(filter.Name)) quaery = quaery.Where(x => x.Name.Contains(filter.Name));

            var directions = quaery.ToList();
            return directions;
        }


        [HttpGet("{id}")]
        public Direction Get(int id)
        {
            var direction = _studentsDbContext.Directions.FirstOrDefault(x => x.Id == id);


            return direction;
        }


        [HttpPost("{id}")]
        public IActionResult Post(int id, Direction direction)
        {
            var existDirection = _studentsDbContext.Directions.FirstOrDefault(x => x.Id == id);
            if (existDirection == null)
            {
                return NotFound();
            }

            existDirection.Name = direction.Name;


            _studentsDbContext.Directions.Update(existDirection);
            _studentsDbContext.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Direction direction)
        {
            _studentsDbContext.Directions.Add(direction);
            _studentsDbContext.SaveChanges();

            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existDirection = _studentsDbContext.Directions.FirstOrDefault(x => x.Id == id);
            if (existDirection == null)
            {
                return NotFound();
            }

            _studentsDbContext.Directions.Remove(existDirection);
            _studentsDbContext.SaveChanges();

            return Ok();
        }
    }
}
