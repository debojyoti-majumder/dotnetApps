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
                Console.WriteLine("DB Context got created successfully");

                // Adding a simple Task
                Todo newTask = new Todo 
                {
                    Description = "This is for Demo purpouse",
                    Name = "Understanding Migrations",
                    TaskStarted = DateTime.Now
                };

                dbContext.RecordedTasks.Add(newTask);
                dbContext.SaveChanges();

                Console.WriteLine("Saved the records");                
            }
        }
    }
}
