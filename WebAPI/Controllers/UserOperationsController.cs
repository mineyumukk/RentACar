using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationsController : ControllerBase
    {
        IUserOperationService _userOperationService;
        public UserOperationsController(IUserOperationService userOperationService)
        {
            _userOperationService = userOperationService;
        }

        [HttpGet("getbymail")]
        public IActionResult GetByMail(string mail)
        {
            var result = _userOperationService.GetByMail(mail);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(UserOperation userOperation)
        {
            var result = _userOperationService.Add(userOperation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(UserOperation userOperation)
        {
            var result = _userOperationService.Delete(userOperation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(UserOperation userOperation)
        {
            var result = _userOperationService.Update(userOperation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
