using Microsoft.AspNetCore.Mvc;
using SCData.Models;
using SpecialityCatalogWebApi.Data;

namespace SpecialityCatalogWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DirectionController : ControllerBase
    {
        private readonly StudentsDbContext _studentsDbContext;

        public DirectionController(StudentsDbContext studentsDbContext)
        {
            _studentsDbContext = studentsDbContext;
        }

        [HttpGet]
        public List<Direction> Get()
        {
            var directions = _studentsDbContext.Directions.ToList();


            return directions;
        }


        [HttpGet ("{id}")]
        public Direction Get(int id)
        {
            var direction = _studentsDbContext.Directions.FirstOrDefault(x => x.Id == id);


            return direction;
        }


        [HttpPost("{id}")]
        public IActionResult Post(int id, Direction direction)
        {
           var existDirection = _studentsDbContext.Directions.FirstOrDefault(x => x.Id ==id);
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
