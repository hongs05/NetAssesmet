using Assesments.Api;
using Assesments.Data;
using Assesments.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize(AuthenticationSchemes = "ApiKey")]
[ApiController]
[Route("api/[controller]")]
public class AssesmentsController : ControllerBase
{
    // private readonly IAssesmentRepository _taskRepository;
    // private readonly IUserRepository _userRepository;

    // public TasksController(ITaskRepository taskRepository, IUserRepository userRepository)
    // {
    //     _taskRepository = taskRepository;
    //     _userRepository = userRepository;
    // }
    private readonly AssesmentServices _assesmentServices;

    public AssesmentsController(AssesmentServices assesmentServices)
    {
        _assesmentServices = assesmentServices;
    }

    [HttpGet]
    public async Task<IActionResult> GetTasks()
    {
        try
        {
            var assesments = await _assesmentServices.GetAllTasksAsync();
            return Ok(assesments);

        }
        catch (Exception ex)
        {

            return StatusCode(500, "Internal server error. " + ex.Message);

        }

    }

    // Get task by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTask(int id)
    {
        var task = await _assesmentServices.GetTaskByIdAsync(id);
        if (task == null)
            return NotFound();

        return Ok(task);
    }

    // Create a new task and assign to user
    [HttpPost]
    public async Task<IActionResult> AddTask([FromBody] CreateAssesmentDto assesmentDto)
    {
        try
        {

            if (assesmentDto == null || assesmentDto.UserId <= 0)
                return BadRequest("Invalid task or user ID.");

            try
            {
                var createdTask = await _assesmentServices.CreateTaskAsync(new Assesment
                {
                    UserId = assesmentDto.UserId,
                    Title = assesmentDto.Title,
                    Description = assesmentDto.Description,
                    EndDate = assesmentDto.EndDate,
                    PriorityId = assesmentDto.PriorityId,
                    Tags = assesmentDto.Tags
                });
                return CreatedAtAction(nameof(GetTask), new { id = createdTask.Id }, createdTask);
            }
            catch (System.Exception)
            {

                throw;
            }


        }
        catch (Exception ex)
        {

            return StatusCode(500, "Failed to create task. " + ex.Message);
        }

    }

    // Update an existing task
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTask(int id, [FromBody] Assesment task)
    {
        if (id != task.Id || task == null)
            return BadRequest();


        try
        {
            await _assesmentServices.UpdateTaskAsync(task);
            return NoContent();
        }
        catch (Exception ex)
        {

            return StatusCode(500, "Failed to update task. " + ex.Message);
        }


    }
    // Delete a task (soft delete)
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        await _assesmentServices.DeleteTaskAsync(id);
        return NoContent();
    }


}