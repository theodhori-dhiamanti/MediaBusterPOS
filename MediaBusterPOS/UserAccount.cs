using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBusterPOS
{
    public class UserAccount : Person
    {
        #region "Private Data"
        private string m_userAccountID;
        private string m_Username;
        private string m_Password;

        #endregion
        #region "Public Properties"

        #endregion
        public override void Print()
        {
            throw new NotImplementedException();
        }

        public override bool Authenticate(string u_user, string u_pass)
        {
           
        }

        private string credsToSha512(string Credentials)
        {
             System.Security.Cryptography.SHA512CryptoServiceProvider Encrypt = new System.Security.Cryptography.SHA512CryptoServiceProvider();
            byte[] ByteString = System.Text.Encoding.ASCII.GetBytes(Credentials);
            ByteString = Encrypt.ComputeHash(ByteString);
            string Result = null;
            foreach (byte bt in ByteString)
            {
                Result += bt.ToString("x2"); 
            }
            return Result.ToUpper();
        
        }
        
    }
}
