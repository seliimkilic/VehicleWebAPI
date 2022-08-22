using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VehicleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {

        private readonly DataContext _context;
        public VehicleController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Vehicle>>> Get()
        {
            return Ok(await _context.Vehicles.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Vehicle>>> Get(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle==null)
            {
                return BadRequest("Vehicle Not Found!");
            }
            return Ok(vehicle);
        }

        [HttpPost]
        public async Task<ActionResult<List<Vehicle>>> AddVehicle(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();

            return Ok(await _context.Vehicles.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Vehicle>>> UpdateVehicle( Vehicle request)
        {
            var dbVehicle = await _context.Vehicles.FindAsync(request.Id);
            if (dbVehicle == null)
            {
                return BadRequest("Vehicle Not Found!");
            }
            dbVehicle.Name = request.Name;
            dbVehicle.Color=request.Color;

            await _context.SaveChangesAsync();

            return Ok(await _context.Vehicles.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Vehicle>>> Delete(int id)
        {
            var dbVehicle = await _context.Vehicles.FindAsync(id);
            if (dbVehicle == null)
            {
                return BadRequest("Vehicle Not Found!");
            }
            _context.Vehicles.Remove(dbVehicle);
            await _context.SaveChangesAsync();
            return Ok(await _context.Vehicles.ToListAsync());
        }
    };


    
}
