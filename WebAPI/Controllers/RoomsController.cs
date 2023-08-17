using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet("GetAllRoom")]
        public IActionResult GetAll()
        {

            var result = _roomService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetByIdRoom")]
        public IActionResult GetById(int id)
        {
            var result = _roomService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("UpdateRoom")]
        public IActionResult Update(Room room)
        {
            var result = _roomService.Update(room);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("Delete Room By Id")]

        public IActionResult DeleteById(int id)
        {
            var result = _roomService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpPost("AddRoom")]

        public IActionResult Post(Room room)
        {
            var result = _roomService.Add(room);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
