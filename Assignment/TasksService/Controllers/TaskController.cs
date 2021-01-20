using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskBusiness;
using TaskBusiness.ViewModels;

namespace TasksService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskBusiness _taskBusiness;

        public TaskController(ITaskBusiness userBusiness)
        {
            _taskBusiness = userBusiness;
        }

        // GET: api/Task?userId=5
        [HttpGet]
        public IActionResult Get(int userId)
        {
            var result = _taskBusiness.GetUserTasks(userId);
            if (result.Status == ServiceResponseDtoStatus.Error)
                return StatusCode(StatusCodes.Status500InternalServerError, result.FormatedMessage);
            return Ok(new { data = result.Data });
        }


        // POST: api/Task
        [HttpPost]
        public IActionResult Post([FromBody] TaskVm taskVm)
        {
            var result = _taskBusiness.CreateTask(taskVm);
            if (result.Status == ServiceResponseDtoStatus.Error)
                return StatusCode(StatusCodes.Status500InternalServerError, result.FormatedMessage);
            return Ok(new { data = result.Data });
        }

        // PUT: api/Task
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] TaskVm taskVm)
        {
            var result = _taskBusiness.UpdateTask(taskVm);
            if (result.Status == ServiceResponseDtoStatus.Error)
                return StatusCode(StatusCodes.Status500InternalServerError, result.FormatedMessage);
            return Ok(new { data = result.Data });
        }

        // GET: api/Task?userId=5
        [HttpDelete]
        public IActionResult Delete(int userId)
        {
            var result = _taskBusiness.DeleteUserTasks(userId);
            if (result.Status == ServiceResponseDtoStatus.Error)
                return StatusCode(StatusCodes.Status500InternalServerError, result.FormatedMessage);
            return Ok(new { data = result.Data });
        }

    }
}
