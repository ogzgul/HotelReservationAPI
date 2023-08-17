using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
        IStaffService _staffService;

        public StaffsController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet("GetAllStaff")]
        public IActionResult GetAll()
        {

            var result = _staffService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetByIdStaff")]
        public IActionResult GetById(int id)
        {
            var result = _staffService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("UpdateStaff")]
        public IActionResult Update(Staff staff)
        {
            var result = _staffService.Update(staff);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("Delete Staff By Id")]

        public IActionResult DeleteById(int id)
        {
            var result = _staffService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpPost("AddStaff")]

        public IActionResult Post(Staff staff)
        {
            var result = _staffService.Add(staff);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
