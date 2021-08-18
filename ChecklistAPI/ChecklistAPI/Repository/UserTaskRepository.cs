using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChecklistAPI.Model;

namespace ChecklistAPI.Repository
{
    public class UserTaskRepository : IUserTaskRepository
    {
        private List<UserTask> checklist = new List<UserTask>();
        //{
        //    new UserTask { Description = "one", Completed = true },
        //    new UserTask { Description = "two", Completed = true },
        //    new UserTask { Description = "three", Completed = false },
        //    new UserTask { Description = "four", Completed = false },
        //    new UserTask { Description = "five", Completed = false }
        //};

        public List<UserTask> GetChecklist()
        {
            return this.checklist;
        }

        public void AddTask(UserTask task)
        {
            this.checklist.Add(task);
        }

    }
}
