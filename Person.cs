using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaBusterPOS;

namespace MediaBusterPOS
{
    [Serializable]
    public abstract class Person : BusinessBase
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
            set {
                if (value.Trim().Length == 0)
                {
                    throw new NotSupportedException("Business Rule: SS Number cannot be blank");
                }
                if (this.IsNew)
                {
                    throw new NotSupportedException("Business Rule: SS Number can only be written once");
                }
                if (value.Trim().Length != 11)
                {
                    throw new NotSupportedException("Business Rule: SS Number needs to be 11 numbers in length");
                }
                m_SSNumber = value;
                base.MarkDirty();
            }
        }

        public string FirstName
        {
            get { return m_FirstName;}
            set 
            {
                if (value.Trim().Length == 0)
                {
                    throw new NotSupportedException("Business Rule: First Name can't be blank");
                }
                if (value.Length > 25)
                {
                    throw new NotSupportedException("Business Rule: First Name is too long");
                }
                m_FirstName = value;
                base.MarkDirty();
            }
        }

        public string LastName
        {
            get { return m_LastName; }
            set 
            {
                if (value.Trim().Length == 0)
                {
                    throw new NotSupportedException("Business Rule: LAst Name can't be blank");
                }
                if (value.Length > 25)
                {
                    throw new NotSupportedException("Business Rule: Last Name is too long");
                }
                 m_LastName = value; 
                base.MarkDirty();
               
            }
        }

        public virtual DateTime BirthDate
        {
            get { return m_BirthDay; }
            set {
                m_BirthDay = value;
                m_Age = (DateTime.Today.Year - m_BirthDay.Year);
                base.MarkDirty();
            }
        }

        public int Age
        {
            get { return m_Age; }
        }

        public string Address
        {
            get { return m_Address; }
            set 
            {
                if (value.Trim().Length == 0)
                {
                    throw new NotSupportedException("Business Rule: Address can't be blank");
                }
                m_Address = value; 
            }
        }
        public string PhoneNumber
        {
            get { return m_PhoneNumber; }
            set { m_PhoneNumber = value; }
        }

        public static int Count
        {
            get { return m_Count; }
            set { m_Count = value; }
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

        protected Person(string S_Number, string F_Name, string L_Name, DateTime B_Date, string A_Address, string P_Number )
        {
            this.SSNumber = S_Number;
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
