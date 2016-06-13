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

namespace LoginUserControl
{
    public partial class LoginUserControl : UserControl
    {
        public event LoginEventHandler Login;
        public event LoginEventHandler Register;
        public LoginUserControl()
        {
            InitializeComponent();
        }
        //property for Username
        public string Username
        {
            get
            {
                return txtUsername.Text;
            }//end get
            set
            {
                if(value!=null)
                {
                    txtUsername.Text = value;
                }
                else
                {
                    txtUsername.Text = "";
                }
            }//end set
        }//end property Username

        //property for Password
        public string Password
        {
            get
            {
                return pswPassword.Password;
            }//end get
            set
            {
                if (value != null)
                {
                    pswPassword.Password = value;
                }
                else
                {
                    pswPassword.Password = "";
                }
            }//end set
        }//end property Password

        //property for ListBoxChoices
        public int ListBoxChoices
        {
            get
            {
                ListBoxItem current = lbxChoices.SelectedItem as ListBoxItem;
                if(current == null)
                {
                    return -1;
                }
                return Convert.ToInt32(current.Tag);
            }//end get
        }//end property for ListBoxChoices

        //method for btnLogin
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(Login != null)
            {
                Login(this, new LoginEventArgs(Username, Password, ListBoxChoices));
            }
        }

        //method for btnRegister
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if(Register != null)
            {
                Register(this, new LoginEventArgs(Username, Password, ListBoxChoices));
            }
        }

        //method for CheckBox if it is checked
        private void chkRegister_Checked(object sender, RoutedEventArgs e)
        {
            lbxChoices.Visibility = Visibility.Visible;
            btnRegister.Visibility = Visibility.Visible;
        }

        //method for CheckBox if it is unchecked
        private void chkRegister_Unchecked(object sender, RoutedEventArgs e)
        {
            lbxChoices.Visibility = Visibility.Hidden;
            btnRegister.Visibility = Visibility.Hidden;
        }//end method
    }
}
