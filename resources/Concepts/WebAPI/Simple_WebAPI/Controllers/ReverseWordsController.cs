using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUtils.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReverseWordsController : ControllerBase
    {
        // GET: api/ReverseWords
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { ""};
        //}

        //// GET: api/ReverseWords/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/ReverseWords
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/ReverseWords/5
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
        public ActionResult<string> Get([FromQuery(Name = "sentence")] string sentence)
        {
            if (sentence.Length > 0)
            {
                
                StringBuilder reverseSentence = new StringBuilder(sentence.Length);
                string[] words = sentence.Split(' ');

               foreach(string word in words)
               {
                   StringBuilder builder = new StringBuilder(word.Length);
              
                   for (int i = word.Length - 1; i >= 0; i--)
                   {
                       builder.Append(word[i]);
                   }
                   reverseSentence.Append(builder);
                   reverseSentence.Append(" ");
               }

                reverseSentence.Length--;


                return Ok(string.Format("\"{0}\"", reverseSentence.ToString()));
            }
           
            else
            {
                return Ok("");
            }
        }

        //[Route("api/[controller]/{sentence}")]
        //[HttpGet("{sentence}")]
        //public string Get(string sentence)
        //{
        //    string reverseSentence = "";
        //    if (sentence.Length > 0)
        //    {
        //        string[] words = sentence.Split(' ');

        //        foreach (string word in words)
        //        {
        //            char[] charArray = word.ToCharArray();
        //            Array.Reverse(charArray);
        //            reverseSentence += new string(charArray);
        //            reverseSentence += " ";
        //        }
        //    }
        //    return reverseSentence;
        //}
    }
}
