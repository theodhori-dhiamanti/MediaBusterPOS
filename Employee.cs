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

        #region "Public Properties"
        public string JobTitle
        {
            get { return m_JobTitle; }
            set { m_JobTitle = value; }
        }

        public UserAccount UserAccount
        {
            get { return m_objUserAccount; }
            set { m_objUserAccount = value; }
        }

        public override DateTime BirthDate
        {
            get
            {
                return base.BirthDate;
            }
            set
            {
                if ((DateTime.Now.Year - base.BirthDate.Year) >= 16)
                {
                    base.BirthDate = value;
                }
                else
                {
                    throw new System.Exception("Employee must be 16 years or older");
                }

            }
        }

        #endregion
        public event SecurityAlertEventHandler SecurityAlert;
        public delegate void SecurityAlertEventHandler(string username, string password);



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
