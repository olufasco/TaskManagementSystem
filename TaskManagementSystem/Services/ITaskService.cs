using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Services
{
    public interface ITaskService
    {
        Task<List<TaskItem>> GetUserTasks(string userId);
        Task CreateTask(TaskItem task);
        Task UpdateTask(TaskItem task);
        Task DeleteTask(int taskId);
    }
}