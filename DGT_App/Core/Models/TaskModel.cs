using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGT_App.Core.Models
{
    public class TaskModel
    {
        public int TaskID { get; set; } // Unique identifier for the task.
        public string Title { get; set; } // Title of the task.
        public string Description { get; set; } // Description of the task.
        public string Code { get; set; } // Code associated with the task.
        public string Language { get; set; } // Programming language for the task.
        public int MemoryLimit { get; set; } // Memory limit for task execution in megabytes.
        public int RuntimeLimit { get; set; } // Runtime limit for task execution in milliseconds.
        public string Status { get; set; } // Current execution status of the task (e.g., "pending", "running", "completed", "error").
    }
}
