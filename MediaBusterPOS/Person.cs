using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBusterPOS
{
    public abstract class Person
    {
        #region "Private Data"
        private string m_SSNumber;
        private string m_FirstName;
        private string m_LastName;
        private DateTime m_BirthDay;
        private int m_Age;
        private string m_Address;
        private string m_PhoneNumber;
        private static int m_Count = 0;
        #endregion

        #region "Public Properties"
        public string SSNumber
        {
            get {return m_SSNumber;}
            set { m_SSNumber = value; }
        }
        public string FirstName
        {
            get { return m_FirstName;}
            set { m_FirstName = value; }
        }
        public string LastName
        {
            get { return m_LastName; }
            set { m_LastName = value; }
        }
        public virtual DateTime BirthDate
        {
            get { return m_BirthDay; }
            set {
                m_BirthDay = value;
                m_Age = (DateTime.Today.Year - m_BirthDay.Year);
            }
        }
        public int Age
        {
            get { return m_Age; }
        }
        public string Address
        {
            get { return m_Address; }
            set { m_Address = value; }
        }
        public string PhoneNumber
        {
            get { return m_PhoneNumber; }
            set { m_PhoneNumber = value; }
        }

        public static int Count
        {
            get { return m_Count; }
        }
        #endregion

        #region "Constructors"

        protected Person()
        {
            this.m_SSNumber = "";
            this.m_FirstName = "";
            this.m_LastName = "";
            this.m_BirthDay = DateTime.Parse("1900,01,01");
            this.m_Age = 0;
            this.m_Address = "";
            this.m_PhoneNumber = "";
            m_Count = m_Count + 1;
            
        }

        protected Person(string s_Number, string F_Name, string L_Name, DateTime B_Date, string A_Address, string P_Number )
        {
            this.SSNumber = s_Number;
            this.FirstName = F_Name;
            this.LastName = L_Name;
            this.BirthDate = B_Date;
            this.Address = A_Address;
            this.PhoneNumber = P_Number;
            m_Count = m_Count + 1;

        }

        #endregion
        public abstract void Print();
        public abstract bool Authenticate(string u_user, string u_pass);
    }
}
