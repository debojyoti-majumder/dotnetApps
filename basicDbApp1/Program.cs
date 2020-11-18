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

            using (var dbContext = new AppDbContext(optionsBuilder.Options))
            {
                TaskRepository repository = new TaskRepository(dbContext);
                string targetCommand = args[0];
                targetCommand = targetCommand.ToLower();

                switch (targetCommand)
                {
                    case "addtodo":
                        {
                            int taskId = repository.AddTask(args[1]);
                            Console.WriteLine("Task added with ID {0}", taskId);
                            break;
                        }

                    case "listtodo":
                        {
                            foreach (var todoTaskItem in repository.GetTasks())
                                Console.WriteLine(todoTaskItem);

                            break;
                        }

                    case "deltodo":
                    {
                        int taskId = Int32.Parse(args[1]);
                        Console.WriteLine("Removed Return code: {0}", repository.RemoveTask(taskId));
                        break;
                    }

                    case "fintodo":
                    {
                        int taskId = Int32.Parse(args[1]);
                        Console.WriteLine("Task updated: {0}", repository.MarkCompleted(taskId));
                        break;
                    }

                    default:
                        {
                            Console.WriteLine("{0} Invalid command", targetCommand);
                            break;
                        }
                }
            }
        }
    }
}
