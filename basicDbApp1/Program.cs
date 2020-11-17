/*
    To build this program clone this repository first then 
    use "dotnet build"

    To Run the application use this command "dotnet run"
*/

using System;
using Microsoft.EntityFrameworkCore;

namespace basicDbApp1
{
    class Program
    {
        private static void AddTodo(AppDbContext dbContext, string justTitle) 
        {
            // Adding a simple Task
            Todo newTask = new Todo 
            {
                Description = justTitle,
                Name = justTitle,
                TaskStarted = DateTime.Now
            };

            dbContext.RecordedTasks.Add(newTask);
            dbContext.SaveChanges();

            Console.WriteLine("Saved the records");
            DisplayRecords(dbContext);  
        }

        private static void DisplayRecords(AppDbContext dbContext) 
        {
            foreach( var todoTaskItem in dbContext.RecordedTasks )
            {
                var output = "Task ID:" + todoTaskItem.Id + " \'"; 
                output += todoTaskItem.Name + "\' ";
                output += " is added on " + todoTaskItem.TaskStarted.ToString();

                Console.WriteLine(output);
            }
        }

        static void Main(string[] args)
        {
            // This is as of now is just logging
            Console.WriteLine("Basic database application");

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlite("Data Source=app.db");

            using ( var dbContext = new AppDbContext(optionsBuilder.Options) ) 
            {
                Console.WriteLine("DB Context got created successfully");

                if( args.Length == 0 ) 
                {
                    DisplayRecords(dbContext);
                }
                else if( args.Length == 1 ) 
                {
                    Console.WriteLine("Adding {0} as task " , args[0]);
                    AddTodo(dbContext, args[0]);
                }              
            }
        }
    }
}
