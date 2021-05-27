using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HopClassLib;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HopWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HopsController : ControllerBase
    {
        private static int _nextId = 1;
        public static List<Hop> HopData = new List<Hop>()
        {
            new Hop{Id = _nextId++, Name = "1", AlphaAcid = 11, HarvestYear = 1, Price = 1},
            new Hop{Id = _nextId++, Name = "2", AlphaAcid = 22, HarvestYear = 2, Price = 2},
            new Hop{Id = _nextId++, Name = "3", AlphaAcid = 33, HarvestYear = 3, Price = 3}
        };


        // GET: api/<HopsController>
        [HttpGet]
        public IEnumerable<Hop> Get()
        {
            return HopData;
        }

        // GET api/<HopsController>/5
        [HttpGet("{id}")]
        public Hop GetById(int id)
        {
            return HopData.Find(hop => hop.Id == id);
        }

        // POST api/<HopsController>
        [HttpPost]
        public Hop Add(Hop newHop)
        {
            newHop.Id = _nextId++;
            HopData.Add(newHop);
            return newHop;
        }

        // DELETE api/<HopsController>/5
        [HttpDelete("{id}")]
        public Hop Delete(int Id)
        {
            Hop hop = HopData.Find(Hop1 => Hop1.Id == Id);
            if (hop == null) return null;
            HopData.Remove(hop);
            return hop;
        }
    }
}
