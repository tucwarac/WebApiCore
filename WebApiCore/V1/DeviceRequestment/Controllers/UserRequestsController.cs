using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCore.ModelShared;
using WebApiCore.V1.DeviceRequestment.Helpers;

namespace WebApiCore.V1.DeviceRequestment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRequestsController : ControllerBase
    {
        private readonly DataContext _context;

        public UserRequestsController(DataContext context)
        {
            _context = context;
        }

        RequestmentHelper requestmentHelper = new RequestmentHelper();

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Response>>> Get(string id)
        {
            SystemCode systemCode = new SystemCode();
            Response response = new Response();

            try
            {
                if (!_context.Database.CanConnect())
                {
                    response.Description = "Can't connect database";
                    response.Status = systemCode.ResponseStatus[0];
                    response.ResponseCode = systemCode.ResponseCode[001];
                }

                response.Data = await requestmentHelper.UserRequestGet(_context, id);

                response.Status = systemCode.ResponseStatus[1];
                response.ResponseCode = systemCode.ResponseCode[100];
            }
            catch (Exception ex)
            {
                response.Description = ex.Message;
                response.Status = systemCode.ResponseStatus[0];
                response.ResponseCode = systemCode.ResponseCode[000];
            }

            return Ok(response);
        }
    }
}
