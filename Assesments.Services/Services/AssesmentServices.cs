using Assesments.Data;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.VisualBasic;

namespace Assesments.Services;

public class AssesmentServices
{
    private readonly IAssesmentRepository _taskRepository;
    private readonly IUserRepository _userRepository;
    public AssesmentServices(IAssesmentRepository assesmentRepository, IUserRepository userRepository)
    {
        _taskRepository = assesmentRepository;
        _userRepository = userRepository;
    }
    // Get all tasks
    public async Task<IEnumerable<AsssesmentDto>> GetAllTasksAsync()
    {
        try
        {
            var assesments = await _taskRepository.GetTasksAsync();
            return assesments.Select(t => new AsssesmentDto
            {
                Id = t.Id,
                UserId = t.UserId,
                Title = t.Title,
                Description = t.Description,
                EndDate = t.EndDate,
                Tags = t.Tags,
                PriorityId = t.PriorityId,
                CreatedAt = t.CreatedAt,
                UpdatedAt = t.UpdatedAt,
                PriorityName = t.Priority.Name

            }).ToList();
        }
        catch (Exception ex)
        {
            // Handle the exception, log, or rethrow it with a custom message
            throw new Exception("An error occurred while retrieving tasks.", ex);
        }



    }
    public async Task<List<AsssesmentDto>> GetTasksByUserAsync(int UserId)
    {
        var assesments = await _taskRepository.GetTasksAsync();
        return assesments.Select(c => new AsssesmentDto
        {
            UserId = c.UserId,
            PriorityId = c.PriorityId,
            Title = c.Title,
            Description = c.Description,
            EndDate = c.EndDate,
            Tags = c.Tags,
            PriorityName = c.Priority.Name,
            CreatedAt = c.CreatedAt,
            UpdatedAt = c.UpdatedAt,
        }).Where(t => t.UserId == UserId).ToList();


    }
    public async Task<List<Priority>> GetAllPrioritiesAsync()
    {
        var priorities = await _taskRepository.GetPriorities();
        return priorities;



    }
    public async Task<User> GetUserByIdAsync(int id)
    {
        return await _userRepository.GetUserByIdAsync(id);
    }

    // Get task by ID
    public async Task<Assesment?> GetTaskByIdAsync(int id)
    {
        try
        {
            return await _taskRepository.GetTaskByIdAsync(id);
        }
        catch (Exception ex)
        {
            // Handle the exception, log, or rethrow it with a custom message
            throw new Exception("An error occurred while retrieving tasks.", ex);
        }


    }

    // Create a new task
    public async Task<Assesment> CreateTaskAsync(Assesment assesment)
    {
        try
        {
            assesment.CreatedAt = DateTime.Now;
            assesment.UpdatedAt = DateTime.Now;
            assesment.Deleted = false;
            return await _taskRepository.AddTaskAsync(assesment);

        }
        catch (Exception ex)
        {

            throw new Exception("An error occurred while creating tasks.", ex);
        }

    }
    public async Task MarkTaskAsCompletedAsync(int taskId)
    {
        try
        {
            await _taskRepository.MarkTaskAsCompletedAsync(taskId);
        }
        catch (Exception ex)
        {

            throw new Exception("An error occurred while creating tasks.", ex);
        }


    }

    // Update an existing task
    public async Task UpdateTaskAsync(Assesment assesment)
    {
        await _taskRepository.UpdateTaskAsync(assesment);
    }

    // Soft delete a task
    public async Task DeleteTaskAsync(int id)
    {
        await _taskRepository.DeleteTaskAsync(id);
    }



}
