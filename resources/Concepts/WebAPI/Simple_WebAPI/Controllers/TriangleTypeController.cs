using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUtils.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TriangleTypeController : ControllerBase
    {
        //// GET: api/TriangleType
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/TriangleType/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/TriangleType
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/TriangleType/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet]
        public ActionResult<string> Get([FromQuery(Name = "a")] int a, [FromQuery(Name = "b")] int b, [FromQuery(Name = "c")] int c)
        {
            if( a <= 0 || b <= 0 || c <= 0)
            {
                return Ok("Error");
            }

            else if( (long)(a+b) <= c || (long)(a+c) <= b || (long)(b+c) <= a )
            {
                return Ok("Error");
            }

            else if (a == b && a == c)
            {
                return Ok("Equilateral");
            }
            else if (a == b || a == c || b == c)
            {
                return Ok("Isosceles");
            }

            return Ok("Scalene");

        }



        //[Route("api/controller/{a}/{b}/{c}")]
        //[HttpGet("{a}/{b}/{c}")]
       
        //public string Get([Required] int a, [Required]int b, [Required] int c)
        //{
        //    int biggestNumber = 0;
        //    if( a == b && b == c )
        //    {
        //        return "Equilateral Triangle";
        //    }
        //    else if( a == b || a==c || b==c )
        //    {
        //        return "Isosceles Triangle";
        //    }

        //    biggestNumber = a > b ? (a > c ? a : c) : (b > c ? b : c);

        //    if (biggestNumber != 0)
        //    {
        //        if (a == biggestNumber)
        //        {
        //            if (a * a == (b * b + c * c))
        //            {
        //                return "Right Angle Triangle";
        //            }
        //        }
        //        if (b == biggestNumber)
        //        {
        //            if (b * b == (a * a + c * c))
        //            {
        //                return "Right Angle Triangle";
        //            }
        //        }

        //        if (c * c == (a * a + b * b))
        //        {
        //            return "Right Angle Triangle";
        //        }
        //    }

        //    return "Scalene Triangle";
     
        //}

    }
 }
