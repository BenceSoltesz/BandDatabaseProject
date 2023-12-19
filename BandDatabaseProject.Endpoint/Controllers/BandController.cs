using BandDatabaseProject.Client.Models;
using BandDatabaseProject.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BandDatabaseProject.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BandController : ControllerBase
    {

        IBandLogic logic;

        public BandController(IBandLogic bandLogic)
        {
            this.logic = bandLogic;
        }


        [HttpGet]
        public IEnumerable<Band> ReadAll()
        {
            return this.logic.ReadAll();
        }


        [HttpGet("{id}")]
        public Band Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Band value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] Band value)
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
