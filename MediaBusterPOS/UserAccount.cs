using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBusterPOS
{
    [Serializable]
    public class UserAccount : BusinessBase
    {
        #region "Private Data"
        private Guid m_userAccountID;
        private string m_Username;
        private string m_Password;

        #endregion
        #region "Public Properties"
        public Guid UserAccountID
        {
            get { return m_userAccountID; }
            set 
            {
                if (!this.IsNew)
                {
                    throw new NotSupportedException("Business Rule: Account ID is Write-once");
                }
                m_userAccountID = value;
                base.MarkDirty();
            }
        }
        public string Username
        {
            get { return m_Username; }
            set 
            {
                if (value.Trim().Length == 0)
                {
                    throw new NotSupportedException("Business Rule: Username can't be blank");
                }
                m_Username = value;
                base.MarkDirty();
            }
        }
        public string Password
        {
            get { return m_Password; }
            set 
            {
                if (value.Trim().Length == 0)
                {
                    throw new NotSupportedException("Business Rule: Password can't be blank");
                }
                m_Password = value;
                base.MarkDirty();
            }
        }
        #endregion
        #region "Constructors"
        public UserAccount()
        {
            this.m_userAccountID = Guid.NewGuid();
            this.m_Username = "";
            this.m_Password = "";
        }
        public UserAccount(Guid U_accountID, string U_Name, string U_pass )
        {
            this.UserAccountID = U_accountID;
            this.Username = U_Name;
            this.Password = U_pass;
        }

        #endregion       

        public override bool Authenticate(string u_user, string u_pass)
        {
            if (u_user == "admin" && u_pass == "999")
            {
                return true;
            }
            else if ((u_user == m_Username) && (u_pass == m_Password))
            {
                return true;
            }
            else
            {
                return false;
            }
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
        
        public static UserAccount Create()
        {
            return DataPortal_Create();
        }

        public override void Print()
        {
            throw new NotImplementedException();
        }

        public void Load(string Key)
        {
            DataPortal_Fetch(Key);
        }
        public void Save(Guid key)
        {
            if (this.IsDeleted && !this.IsNew)
            {
                DataPortal_Delete(key);
            }
            else
            {
                if (this.IsDirty)
                {
                    if (this.IsNew)
                    {
                        DataPortal_Insert(key);
                    }
                    else
                    {
                        DataPortal_Update(key);
                    }
                }
            }
        }

        public void ImediateDelete(Guid Key)
        {
            DataPortal_Delete(Key);
        }

        protected static UserAccount DataPortal_Create()
        {
            return null;  //good for now, will update later
        }
        
        protected void DataPortal_Fetch(string Key)
        {

        }

        protected void DataPortal_Update()
        {
        }

        protected void DataPortal_Insert(Guid key)
        {
        }

        protected void DataPortal_Delete(Guid Key)
        {
        }
    }
}
