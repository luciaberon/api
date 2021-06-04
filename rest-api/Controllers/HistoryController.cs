using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rest_api.Context;
using rest_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rest_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly AppDbContext context;
        public HistoryController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<History>Get()
        {
            return context.History.ToList();
        }

        [HttpPost]
        public ActionResult Post([FromBody]History history)
        {
            try
            {
            context.History.Add(history);
            context.SaveChanges();
                return Ok();
            } catch(Exception ex)
            {
                return BadRequest();
            } 
            

        }
    }
}
