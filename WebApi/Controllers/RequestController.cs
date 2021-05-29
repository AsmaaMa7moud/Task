using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.Interfaces;

namespace WebApi.Controllers
{
    [RoutePrefix("api/v1/requests")]
    public class RequestController : ApiController
    {
        private readonly IRequestService _requestService;
        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }
       
       
        [HttpPost]
        [Route("AddRequest")]
      public async Task<IHttpActionResult> AddRequest([FromBody]int MobilNumber)
        {
            try
            {
                var result = await _requestService.AddRequest(MobilNumber);

                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
