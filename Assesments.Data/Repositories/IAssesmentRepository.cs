namespace Assesments.Data
{
    public interface IAssesmentRepository
    {
        Task<IEnumerable<Assesment>> GetTasksAsync();
        Task<Assesment?> GetTaskByIdAsync(int id);
        Task<Assesment> AddTaskAsync(Assesment task);
        Task UpdateTaskAsync(Assesment task);
        Task DeleteTaskAsync(int id);
        Task MarkTaskAsCompletedAsync(int id);
        Task<List<Priority>> GetPriorities();
    }
}