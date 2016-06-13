using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenizationCard
{
    public delegate void GenerateTokenEventHandler(object sender, GenerateTokenEventArgs args);
    public class GenerateTokenEventArgs : EventArgs
    {
        public string TokenOrID { get; set; } //autoimplemented property for the text box where user inputs Token or Card ID 
        public GenerateTokenEventArgs(string tokOrID) //constructor for general purpose
        {
            TokenOrID = tokOrID;
        }
    }
}
