﻿using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
   
    [ApiController]
    [Route("api/[controller]")]
    public class TesteController : ControllerBase
    {
        // GET: api/<TesteController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TesteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TesteController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TesteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TesteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
