using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribesController : ControllerBase
    {
        ISubscribeService _subscribeService;

        public SubscribesController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }

        [HttpGet("GetAllSubscribe")]
        public IActionResult GetAll()
        {

            var result = _subscribeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetByIdSubscribe")]
        public IActionResult GetById(int id)
        {
            var result = _subscribeService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("UpdateSubscribe")]
        public IActionResult Update(Subscribe subscribe)
        {
            var result = _subscribeService.Update(subscribe);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("Delete Subscribe By Id")]

        public IActionResult DeleteById(int id)
        {
            var result = _subscribeService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpPost("AddSubscribe")]

        public IActionResult Post(Subscribe subscribe)
        {
            var result = _subscribeService.Add(subscribe);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
