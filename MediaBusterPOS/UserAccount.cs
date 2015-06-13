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
            throw new NotImplementedException();
        }
    }
}
