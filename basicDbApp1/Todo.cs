using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace basicDbApp1
{
    public class Todo 
    {
        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}

        [Required]
        public string Name {get; set;}
        
        public string Description {get; set;}
        public DateTime TaskStarted {get; set;}
        public DateTime TaskFinished {get; set;}

        public override string ToString()
        { 
            var output = "Task ID:" + Id + " \'"; 
            output += Name + "\' ";
            output += " is added on " + TaskStarted.ToString();

            return output;
        }  
    }
}