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
        static void Main(string[] args)
        {
            // This is as of now is just logging
            Console.WriteLine("Basic database application");

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlite("Data Source=app.db");

            using ( var dbContext = new AppDbContext(optionsBuilder.Options) ) 
            {
                TaskRepository repository = new TaskRepository(dbContext);
                Console.WriteLine("DB Context got created successfully");

                if( args.Length == 0 ) 
                {
                    foreach( var todoTaskItem in repository.GetTasks() )
                    {
                        Console.WriteLine(todoTaskItem);
                    }
                }
                else if( args.Length == 1 ) 
                {
                    Console.WriteLine("Adding {0} as task " , args[0]);
                    int taskId = repository.AddTask(args[0]);
                    Console.WriteLine("Task added with ID {0}", taskId);
                }              
            }
        }
    }
}
