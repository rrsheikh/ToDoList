using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ChecklistAPI.Model;
using ChecklistAPI.Repository;

namespace ChecklistAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChecklistController : ControllerBase
    {
        private IUserTaskRepository checklist; 
        public ChecklistController(IUserTaskRepository checklist)
        {
            this.checklist = checklist;
        }

        [HttpGet("GetChecklist")]
        public IActionResult Get()
        {
            return Ok(this.checklist.GetChecklist());
        }

        [HttpPost("AddTask")]
        public IActionResult AddTask(UserTask task)
        {
            this.checklist.AddTask(task);
            return Ok(this.checklist.GetChecklist());
        }
    }
}
