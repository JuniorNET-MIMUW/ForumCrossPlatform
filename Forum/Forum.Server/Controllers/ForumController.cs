using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Forum.Server.Models;

namespace Forum.Server.Controllers
{
    [RoutePrefix("api/forum")]
    public class ForumController : ApiController
    {
        [Route("all")]
        public IHttpActionResult GetAllThreads() 
            => Ok(new FilesParser().AllFileNames());

        [Route("get/{name}")]
        public IHttpActionResult GetThreadByName(string name)
        {
            var parser = new FilesParser();
            var thread = parser.GetThreadByName(name, out ErrorMessage message);
            if (message.IsOk) return Ok(thread);

            return BadRequest(message.Message);
        }
    }
}