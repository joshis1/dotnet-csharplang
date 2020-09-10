using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUtils.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FibonacciController : ControllerBase
    {
        // GET: api/Fibonacci
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Fibonacci/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Fibonacci
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Fibonacci/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        static void SwapNum(ref long a, ref long b, ref long temp)
        {

            temp = a;
            a = b;
            b = temp + b;
        }

        [HttpGet]
        public ActionResult<long> Get([FromQuery(Name = "n")] long n)
        {
            long a = 0;
            long b = 1;
            long temp = 0;
            long val = 0;

            if (n > 92 || n < -92)
            {
                return BadRequest("");
            }

            if( n < 0)
            {
                val = n * (-1);
            }

            Parallel.For(0, val, i => 
            {
                SwapNum(ref a, ref b, ref temp);
            });

            if( n < 0 )
            {
                a = a * -1;
            }

            return Ok(a);
            
        }


        //[Route("api/[controller]?{n}")]
        //[HttpGet("{n}")]
        //public string Get(long n)
        //{
        //    if (n < 0)
        //    {
        //        return "0";
        //    }
        //    ulong lastItem = (ulong)n;
        //    ulong a = 0;
        //    ulong b = 1;
        //    for (ulong i = 0; i < lastItem; i++)
        //    {
        //        ulong temp = a;
        //        a = b;
        //        b = temp + b;
        //    }
        //    return a.ToString();
        //}
    }
}
