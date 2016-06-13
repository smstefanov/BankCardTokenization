using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginUserControl
{    
    public delegate void LoginEventHandler(object sender, LoginEventArgs args);
    public class LoginEventArgs : EventArgs
    {
        public string Username { get; set; } //autoimplemented property for username
        public string Password { get; set; } //autoimplemented property for password
        public int ListBoxChoices { get; set; } //autoimplemented property user's choice of rights

        public LoginEventArgs(string userName, string pass, int lbChoices) //constructor for general purpose
        {
            Username = userName;
            Password = pass;
            ListBoxChoices = lbChoices;
        }
    }
}
