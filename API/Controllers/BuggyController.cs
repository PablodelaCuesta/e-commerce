using Core.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        public BuggyController(StoreContext context)
        {
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundResult()
        {
            return Ok();
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return Ok();
        }
        
        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {
            return Ok();
        }

        
    }
}