using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGT_App.Core.Models
{
    public class UserModel
    {
        public int UserID { get; set; } // Unique identifier for the user.
        public string Username { get; set; } // User's username.
        public string Email { get; set; } // User's email address.
    }
}
