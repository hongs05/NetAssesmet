
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Assesments.Data;

public class AssesmentRepository : IAssesmentRepository
{
    private readonly ApplicationDbContext _context;

    public AssesmentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Assesment> AddTaskAsync(Assesment assesment)
    {
        try
        {
            assesment.CreatedAt = DateTime.UtcNow;
            await _context.Assesments.AddAsync(assesment);
            await _context.SaveChangesAsync();
            return assesment;
        }
        catch (Exception ex)
        {

            throw new Exception("Failed to save assesments from the database.", ex);
        }

    }

    public async Task DeleteTaskAsync(int id)
    {
        try
        {
            var task = await _context.Assesments.FindAsync(id);
            if (task == null)
            {
                throw new KeyNotFoundException("Task not found");
            }

            task.Deleted = true;
            _context.Assesments.Update(task);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {

            throw new Exception("Failed to delete assesments from the database.", ex);
        }

    }

    public async Task<List<Priority>> GetPriorities()
    {

        try
        {
            return await _context.Priorities.ToListAsync();


        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public async Task<Assesment?> GetTaskByIdAsync(int id)
    {

        return await _context.Assesments
                .Include(t => t.Priority)  // Including related Priority data
                .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<IEnumerable<Assesment>> GetTasksAsync()
    {
        try
        {
            return await _context.Assesments
                            .Include(t => t.Priority)  // Assuming Task has a Priority relation
                            .ToListAsync();
        }
        catch (Exception ex)
        {

            throw new Exception("An error occurred while retrieving tasks.", ex);
        }

    }

    public async Task MarkTaskAsCompletedAsync(int id)
    {
        try
        {
            var assesment = await _context.Assesments.Where(t => t.Id == id).FirstOrDefaultAsync();
            assesment.Ended = true;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while updating tasks.", ex);
        }
    }

    public async Task UpdateTaskAsync(Assesment task)
    {
        var existingTask = await _context.Assesments.FindAsync(task.Id);
        if (existingTask == null)
        {
            throw new KeyNotFoundException("Task not found");
        }
        try
        {
            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.EndDate = task.EndDate;
            existingTask.Ended = task.Ended;
            existingTask.Deleted = task.Deleted;
            existingTask.Tags = task.Tags;
            existingTask.PriorityId = task.PriorityId;
            existingTask.UpdatedAt = DateTime.UtcNow;

            _context.Assesments.Update(existingTask);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {

            throw new Exception("An error occurred while retrieving tasks.", ex);
        }

    }
}
