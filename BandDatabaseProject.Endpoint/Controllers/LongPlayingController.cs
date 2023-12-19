using BandDatabaseProject.Client.Models;
using BandDatabaseProject.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BandDatabaseProject.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]


    public class LongPlayingController : ControllerBase
    {

        ILongPlayingLogic logic;

        public LongPlayingController(ILongPlayingLogic logic)
        {
            this.logic = logic;
        }


        [HttpGet]
        public IEnumerable<LongPlaying> ReadAll()
        {
            return this.logic.ReadAll();
        }


        [HttpGet("{id}")]
        public LongPlaying Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] LongPlaying value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] LongPlaying value)
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
