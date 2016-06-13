using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using wox.serial;
using System.Collections;
using System.IO;


namespace TokenizationServer
{
    public class TokenServer : IToken
    {
        private string regUsersXML = "D:\\RegisteredUsers.xml"; //xml file for users
        private string tokenXML = "D:\\Token-CardID.xml"; //xml file for tokens
        ArrayList userFile = new ArrayList(); // a buffer where all users will be saved in
        ArrayList tokensIn = new ArrayList(); // a buffer where all tokens will be saved in
        public bool ValidationAndLuhnCheck(string cardID)
        {
            if (cardID.Length > 16 || cardID.Length < 16) //validate the leghth of Card ID (must be 16)
            {
                return false;
            }
            //Luhn Check
            int[] num = new int[cardID.Length];

            for (int i = 0; i < cardID.Length; i++)
            {
                num[i] = Convert.ToInt32(cardID[i].ToString());
            }
            //validate first digit of the card ID
            if (num[0] < 3 || num[0] > 6)
            {
                return false;
            }
            int sum = 0;

            for (int i = 0; i < num.Length; i++)
            {
                if (i % 2 == 0)
                {
                    num[i] *= 2;
                }
                if (num[i] > 9)
                {
                    num[i] = (num[i] / 10) + (num[i] % 10);
                }
                sum += num[i];
            }

            return (sum % 10 == 0);
        }
        public string CreateToken(string cardID)
        {
            int[] temp = new int[cardID.Length]; //cardID values
            int[] token = new int[cardID.Length]; //token number
            Random rand = new Random();
            int sum = 0;
            string tokenResult = ""; //variable for the token result

            for (int i = 0; i < cardID.Length; i++)
            {
                temp[i] = Convert.ToInt32(cardID[i].ToString());
            }

            //generate first 11 digits in the token array with random digits
            //first digit must be [3,6] and next digits must be different from card id digits
            for (int i = 0; i < token.Length - 5; i++)
            {
                token[i] = rand.Next(0, 10);
                while ((token[0] >= 3 && token[0] <= 6) || token[0] == 0)
                {
                    token[0] = rand.Next(1, 10);
                }

                while (token[i] == temp[i])
                {
                    token[i] = rand.Next(0, 10);
                }
                sum += token[i];
            }
            //add last 4 digits to token array which are the same as the card Id
            for (int i = token.Length - 4; i < token.Length; i++)
            {
                token[i] = temp[i];
                sum += token[i];
            }
            //12-th digit is generated with random number
            token[token.Length - 5] = rand.Next(0, 10);
            //if 12-digit + (sum % 10) is equal to 10 or 12-th element of token is equal to 12-th element of card ID then generate new digit
            while (((token[token.Length - 5] + (sum % 10)) == 10) || (token[token.Length - 5] == temp[temp.Length - 5]))
            {
                token[token.Length - 5] = rand.Next(0, 10);
            }

            for (int i = 0; i < token.Length; i++)
            {
                tokenResult += token[i].ToString();
            }
            return tokenResult;
        }

        //load some users in arraylist userFile
        private void AddUsers()
        {
            /*userFile.Add(new User("root", "root", UserAccess.EMPLOYEE));
            userFile.Add(new User("Ivan", "vankata", UserAccess.CLIENT));
            userFile.Add(new User("Peter", "pesho", UserAccess.NONE));
            Easy.save(userFile, regUsers);*/
            userFile = (ArrayList)Easy.load(regUsersXML);
        }//end method

        //check if username is in the system
        public bool IsRegistered(string username)
        {
            AddUsers();
            foreach (User item in userFile)
            {
                if (item.UserName == username)
                {
                    return true;
                }
            }
            return false;
        }//end method

        //save new registered user in xml
        public void XMLUserSave(string user, string pass, int access)
        {
            AddUsers();
            userFile.Add(new User(user, pass, (UserAccess)access));
            Easy.save(userFile, regUsersXML);
            WritePermissionsToFile((UserAccess)access); //get user permissions
        }//end method

        //check if username and password are correct
        public bool IsValidLog(string username, string password)
        {
            AddUsers();
            foreach (User item in userFile)
            {
                if (item.UserName == username)
                {
                    if (item.Password == password)
                    {
                        WritePermissionsToFile(item.Permissions);
                        return true;
                    }
                }
            }
            return false;
        }//end method

        //load a token in arraylist tokenIn
        private void AddTokens()
        {
            /*tokensIn.Add(new Token("1234243434269991", "4563960122019991"));
            Easy.save(tokensIn, tokenXML);*/
            tokensIn = (ArrayList)Easy.load(tokenXML);
        }

        public bool IsTokenInSystem(string token)
        {
            AddTokens();
            foreach (Token item in tokensIn)
            {
                if (item.TokenID == token)
                {
                    return true;
                }
            }
            return false;
        }

        //save new token in xml
        public void XMLTokenSave(string tokenID, string CardID)
        {
            AddTokens();
            tokensIn.Add(new Token(tokenID, CardID));
            Easy.save(tokensIn, tokenXML);
        }//end method


        // return Card ID if user has access and if it wa generated token in xml earlier
        public string LoadCardID(string token)
        {
            AddTokens();
            UserAccess lastLoginPermissions = ReadPermissionsFromFile();
            if (lastLoginPermissions == UserAccess.EMPLOYEE)
            {
                foreach (Token item in tokensIn)
                {
                    if (item.TokenID == token)
                    {
                        return item.CardID;
                    }
                }
            }
            return null;
        }//end method

        //write last user login permissions to file
        private void WritePermissionsToFile(UserAccess permission)
        {
            string file = "D:\\Permissions.txt";

            using (StreamWriter outputfile = new StreamWriter(file,false))
            {
                outputfile.WriteLine((int)permission);
            }
        }

        //read last user login permissions from file
        private UserAccess ReadPermissionsFromFile()
        {
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader("D:\\Permissions.txt"))
                {
                    String line = sr.ReadToEnd();
                    return (UserAccess)Convert.ToInt32(line);
                }
            }
            catch (Exception e)
            {
                return UserAccess.NONE;
            }
        }

        //sort by token in file
        public void SortByToken()
        {
            AddTokens();
            var items = tokensIn.ToArray().OfType<Token>().OrderBy(t => ((Token)t).TokenID).ToArray();

            string mydoc = "D:\\SortedTokens.txt";

            using (StreamWriter outputFile = new StreamWriter(mydoc))
            {
                foreach (var item in items)
                {
                    outputFile.WriteLine(item.ToString());
                }
            }
        }

        //sort by card id in file
        public void SortByCardID()
        {
            AddTokens();
            var items = tokensIn.ToArray().OfType<Token>().OrderBy(c => ((Token)c).CardID).ToArray();

            string mydoc = "D:\\SortedCards.txt";

            using (StreamWriter outputFile = new StreamWriter(mydoc))
            {
                foreach (var item in items)
                {
                    outputFile.WriteLine(item.ToString());
                }
            }
        }
    }
}
