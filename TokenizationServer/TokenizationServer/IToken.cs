using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TokenizationServer
{
    [ServiceContract]
    public interface IToken
    {
        [OperationContract]
        bool ValidationAndLuhnCheck(string cardID);

        [OperationContract]
        string CreateToken(string cardID);

        [OperationContract]
        bool IsRegistered(string username);

        [OperationContract]
        bool IsValidLog(string username, string password);

        [OperationContract]
        string LoadCardID(string token);

        [OperationContract]
        void XMLUserSave(string user, string pass, int access);

        [OperationContract]
        void XMLTokenSave(string tokenID, string CardID);

        [OperationContract]
        bool IsTokenInSystem(string token);

        [OperationContract]
        void SortByToken();

        [OperationContract]
        void SortByCardID();
    }

    [DataContract]
    public class Token
    {
        private string tokenID; // ID of the token
        private string cardID; // ID of the card

        [DataMember]
        public string TokenID
        {
            get
            {
                return tokenID;
            }
            set
            {
                if (value != null)
                {
                    tokenID = value;
                }
                else
                {
                    tokenID = "";
                }
            }
        }

        [DataMember]
        public string CardID
        {
            get
            {
                return cardID;
            }
            set
            {
                if (value != null)
                {
                    cardID = value;
                }
                else
                {
                    cardID = "";
                }
            }
        }

        //general purpose constructor
        public Token(string tID, string cID)
        {
            TokenID = tID;
            CardID = cID;
        }

        public Token() : this("1234243434269991", "4563960122019991") { }

        //method ToString()
        public override string ToString()
        {
            return String.Format("Token: {0} < -- > {1} :Card ID", tokenID, cardID);
        }
    }

    [DataContract]
    public enum UserAccess
    {
        NONE = 0,
        CLIENT = 1,
        EMPLOYEE = 2
    };

    [DataContract]
    public class User
    {
        private string userName; //User's name
        private string password; //User's password
        private int permissions; //User's permissions

        [DataMember]
        //property for User's username
        public string UserName
        {
            get
            {
                return userName;
            }//end get
            set
            {
                if (value != null)
                {
                    userName = value;
                }
                else
                {
                    userName = "";
                }
            }//end set
        }//end property

        [DataMember]
        //property for User's password
        public string Password
        {
            get
            {
                return password;
            }//end get
            set
            {
                if (value != null)
                {
                    password = value;
                }
                else
                {
                    password = "";
                }
            }//end set
        }//end property

        [DataMember]
        //property for User's permissions
        public UserAccess Permissions
        {
            get
            {
                return (UserAccess)permissions;
            }//end get
            set
            {
                if (value >= UserAccess.NONE && value <= UserAccess.EMPLOYEE)
                {
                    permissions = (int)value;
                }
                else
                {
                    permissions = (int)UserAccess.NONE;
                }
            }//end set
        }//end property

        //general purpose constructor
        public User(string userN, string pass, UserAccess perm)
        {
            UserName = userN;
            Password = pass;
            Permissions = perm;
        }//end constructor

        public User() : this("root", "root", (UserAccess)1) { } //default constructor
    }
}
