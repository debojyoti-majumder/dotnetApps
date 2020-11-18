using System;
using System.Collections.Generic;

namespace basicDbApp1
{
    public class TaskRepository
    {
        AppDbContext dbContext;

        public TaskRepository(AppDbContext ctx)
        {
            dbContext = ctx;
        } 

        public int AddTask(string taskName) 
        {
            int taskId = -1;

            // This is some data validation might be good to move this logic to DB
            if( taskName.Length <= 3 ) return taskId;

            // Building the task
            Todo newTask = new Todo 
            {
                Description = "This is simple description which would be altered later",
                TaskStarted = DateTime.Now,
                Name = taskName
            };

            // Adding the new task returning the ID
            dbContext.RecordedTasks.Add(newTask);
            dbContext.SaveChanges();
            taskId = newTask.Id;
            
            return taskId;
        }

        public IEnumerable<Todo> GetTasks() 
        {
            return dbContext.RecordedTasks;          
        }
    }
}