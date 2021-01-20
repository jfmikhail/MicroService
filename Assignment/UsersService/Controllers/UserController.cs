using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserBusiness;
using UserBusiness.ViewModels;

namespace UsersService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;

        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        // GET: api/User
        [HttpGet]
        public IActionResult Get()
        {
            var result = _userBusiness.GetAllUsers();
            if(result.Status == ServiceResponseDtoStatus.Error)
                return StatusCode(StatusCodes.Status500InternalServerError, result.FormatedMessage);
            return Ok(new { data = result.Data });
            //return new string[] { "value1", "value2" };
        }

        
        // POST: api/User
        [HttpPost]
        public IActionResult Post([FromBody] UserVm userVm)
        {
            var result = _userBusiness.CreateUser(userVm);
            if (result.Status == ServiceResponseDtoStatus.Error)
                return StatusCode(StatusCodes.Status500InternalServerError, result.FormatedMessage);
            return Ok(new { data = result.Data });
        }

        // PUT: api/User/5
        [HttpPut]
        public IActionResult Put([FromBody] UserVm userVm)
        {
            var result = _userBusiness.UpdateUser(userVm);
            if (result.Status == ServiceResponseDtoStatus.Error)
                return StatusCode(StatusCodes.Status500InternalServerError, result.FormatedMessage);
            return Ok(new { data = result.Data });
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _userBusiness.DeleteUser(id);
            if (result.Status == ServiceResponseDtoStatus.Error)
                return StatusCode(StatusCodes.Status500InternalServerError, result.FormatedMessage);
            return Ok(new { data = result.Data });
        }
    }
}
