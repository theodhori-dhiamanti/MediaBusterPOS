using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBusterPOS
{
    class Employee : Person
    {
        #region "Private Data"
        private string m_JobTitle;
        private UserAccount m_objUserAccount;

        #endregion
        public override bool Authenticate(string u_user, string u_pass)
        {
            throw new NotImplementedException();
        }

        public override void Print()
        {
            throw new NotImplementedException();
        }
    }
}
