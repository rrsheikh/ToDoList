using System.Collections.Generic;
using ChecklistAPI.Model;

namespace ChecklistAPI.Repository
{
    public interface IUserTaskRepository
    {
        List<UserTask> GetChecklist();
        void AddTask(UserTask task);
    }
}