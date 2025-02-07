using Microsoft.AspNetCore.Mvc;
using TaskAPI.Dto;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;

namespace TaskAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private TaskDBContext _dbContext;

        public TaskController(TaskDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<TaskDto> GetTask(int id)
        {
            var task = await _dbContext.Tasks.Where(c => c.Id == id).FirstOrDefaultAsync();
            return await MapTaskDTO(task);
        }

        [HttpPut]
        public async Task<TaskDto> UpdateTask(TaskDto input)
        {
            var taskInput = new Models.Task
            {
                AssignedTo = input.AssignedTo,
                Color = input.Color,
                DueDate = input.DueDate,
                Id = input.Id,
                Name = input.Name,
                Status = input.Status,
                Tags = input.Tags
            };
            var result =  _dbContext.Tasks.Update(taskInput);

            return await MapTaskDTO(result.Entity);
        }

        [HttpPost]
        public async Task<TaskDto> CreateTask(TaskDto input)
        {
            var taskInput = new Models.Task
            {
                AssignedTo = input.AssignedTo,
                Color = input.Color,
                DueDate = input.DueDate,
                Id = input.Id,
                Name = input.Name,
                Status = input.Status,
                Tags = input.Tags
            };
            var result = await _dbContext.Tasks.AddAsync(taskInput);

            return await MapTaskDTO(result.Entity);
        }



        [HttpDelete]
        public async Task DeleteTask(int id)
        {
            var result = _dbContext.Tasks.FirstOrDefault(t => t.Id == id);
            if (result != null)
            {
                _dbContext.Remove(result);
                await _dbContext.SaveChangesAsync();
            }
        }


        [HttpGet]
        public async Task<List<Models.Task>> GetTaskList()
        {
            var tasks = await _dbContext.Tasks.ToListAsync();
            return  tasks;
        }

        private async Task<TaskDto> MapTaskDTO(Models.Task input)
        {
            var taskDto = new TaskDto
            {
                AssignedTo = input.AssignedTo,
                Color = input.Color,
                DueDate = input.DueDate,
                Id = input.Id,
                Name = input.Name,
                Status = input.Status,
                Tags = input.Tags
            };

            return taskDto;
        }
    }
}
