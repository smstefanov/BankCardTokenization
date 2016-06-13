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
using System.Text.RegularExpressions;
using System.Collections;
using System.Linq;

namespace TokenizationClient
{
    public partial class TokenClient : Window
    {
        private ServiceReference.TokenClient client; //object which connect clients with server

        //default constructor
        public TokenClient()
        {
            InitializeComponent();
            client = new ServiceReference.TokenClient();
        }//end constructor

        //validate username with regular expression
        public bool IsUsernameValid(string userName)
        {
            return Regex.Match(userName, "^[a-zA-Z][a-zA-Z0-9_]*$").Success;
        }//end method

        //
        private void LoginUserControl_Login(object sender, LoginUserControl.LoginEventArgs args)
        {
            if(!IsUsernameValid(args.Username))
            {
                MessageBox.Show("Invalid Username!");
            }
            else if (args.Password == "")
            {
                MessageBox.Show("Please insert password!");
            }
            else
            {
                if(client.IsValidLog(args.Username,args.Password))
                {
                    MessageBox.Show("You have been logged in");
                    LogOrReg.Visibility = Visibility.Hidden;
                    Tokeniser.Visibility = Visibility.Visible;
                    btnSaveToFile.Visibility = Visibility.Visible;
                }
                else
                {
                    MessageBox.Show("Your password or your username is wrong!");
                }
            }
        }

        private void LoginUserControl_Register(object sender, LoginUserControl.LoginEventArgs args)
        {
            if (!IsUsernameValid(args.Username))
            {
                MessageBox.Show("Invalid Username!");
            }
            else if (args.Password == "")
            {
                MessageBox.Show("Please insert password!");
            }
            else
            {
                if(client.IsRegistered(args.Username))
                {
                    MessageBox.Show("This username is already registered!");
                }
                else
                {
                    client.XMLUserSave(args.Username, args.Password, args.ListBoxChoices);
                    MessageBox.Show("You have been registrated");
                    LogOrReg.Visibility = Visibility.Hidden;
                    Tokeniser.Visibility = Visibility.Visible;
                    btnSaveToFile.Visibility = Visibility.Visible;
                }     
            }
        }

        private void Tokeniser_CardIDRequested(object sender, TokenizationCard.GenerateTokenEventArgs args)
        {
            if(client.IsTokenInSystem(args.TokenOrID))
            {
                if(client.LoadCardID(args.TokenOrID) != null)
                {
                    lblCardID.Visibility = Visibility.Visible;
                    txtCardID.Visibility = Visibility.Visible;
                    txtCardID.Text = client.LoadCardID(args.TokenOrID);
                }
                else
                {
                    MessageBox.Show("No permissions to see Card ID!");
                }
            }
            else
            {
                MessageBox.Show("No Card ID for this Token!");
            }
        }

        private void Tokeniser_TokenRequested(object sender, TokenizationCard.GenerateTokenEventArgs args)
        {

            if (!(client.ValidationAndLuhnCheck(args.TokenOrID)))
            {
                MessageBox.Show("Invalid Card ID");
            }
            else
            {
                lblToken.Visibility = Visibility.Visible;
                txtToken.Visibility = Visibility.Visible;
                txtToken.Text = client.CreateToken(args.TokenOrID);
                while(client.IsTokenInSystem(txtToken.Text))
                {
                    txtToken.Text = client.CreateToken(args.TokenOrID);
                }
                client.XMLTokenSave(txtToken.Text, args.TokenOrID);
            }
        }

        private void Tokeniser_ButtonClearAll(object sender, TokenizationCard.GenerateTokenEventArgs args)
        {
            lblToken.Visibility = Visibility.Hidden;
            lblCardID.Visibility = Visibility.Hidden;
            txtCardID.Text = "";
            txtCardID.Visibility = Visibility.Hidden;
            txtToken.Text = "";
            txtToken.Visibility = Visibility.Hidden;
        }

        private void btnSaveToFile_Click(object sender, RoutedEventArgs e)
        {
            client.SortByCardID();
            client.SortByToken();
            MessageBox.Show("Data is been saved to files!");
        } 
    }
}
