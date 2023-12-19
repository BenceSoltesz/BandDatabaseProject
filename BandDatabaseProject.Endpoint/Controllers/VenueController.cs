using BandDatabaseProject.Client.Models;
using BandDatabaseProject.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BandDatabaseProject.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenueController : ControllerBase
    {
        [Route("[controller]")]
        [ApiController]
        public class VenueController : ControllerBase
        {

            IVenueLogic logic;

            public VenueController(IVenueLogic logic)
            {
                this.logic = logic;
            }


            [HttpGet]
            public IEnumerable<Venue> ReadAll()
            {
                return this.logic.ReadAll();
            }


            [HttpGet("{id}")]
            public Venue Read(int id)
            {
                return this.logic.Read(id);
            }

            [HttpPost]
            public void Create([FromBody] Venue value)
            {
                this.logic.Create(value);
            }

            [HttpPut]
            public void Update([FromBody] Venue value)
            {
                this.logic.Update(value);
            }


            [HttpDelete("{id}")]
            public void Delete(int id)
            {
                this.logic.Delete(id);
            }
        }
    }
