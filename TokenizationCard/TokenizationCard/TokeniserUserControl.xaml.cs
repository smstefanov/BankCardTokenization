using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TokenizationCard
{
    /// <summary>
    /// Interaction logic for TokeniserUserControl.xaml
    /// </summary>
    public partial class TokeniserUserControl : UserControl
    {
        public event GenerateTokenEventHandler TokenRequested;
        public event GenerateTokenEventHandler CardIDRequested;
        public event GenerateTokenEventHandler ButtonClearAll;
        public TokeniserUserControl()
        {
            InitializeComponent();
        }

        //property for the text box where user inputs Token or Card ID
        public string TokenOrID
        {
            get
            {
                return txtRequest.Text;
            }//end get
            set
            {
                if (value != null)
                {
                    txtRequest.Text = value;
                }
                else
                {
                    txtRequest.Text = "";
                }
            }//end set
        }//end property


        //when user is clicked on "Generate Token"
        private void btnToken_Click(object sender, RoutedEventArgs e)
        {
            if(TokenRequested != null)
            {
                TokenRequested(this, new GenerateTokenEventArgs(TokenOrID));
            }
        }

        //when user is clicked on "Generate Card ID"
        private void btnCardID_Click(object sender, RoutedEventArgs e)
        {
            if(CardIDRequested != null)
            {
                CardIDRequested(this, new GenerateTokenEventArgs(TokenOrID));
            }
        }

        //Clear results
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            if(ButtonClearAll!=null)
            {
                txtRequest.Text = "";
                ButtonClearAll(this, new GenerateTokenEventArgs(TokenOrID));
            } 
        }
    }
}
