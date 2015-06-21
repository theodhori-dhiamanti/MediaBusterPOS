using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MediaBusterPOS
{
    class Employee : Person
    {
        [Serializable]
        private const string strConn = "Data Source=\\SQLEXPRESS;Initial Catalog=MediaBusters.mdf;Integrated Security=True";
        #region "Private Data"
        private string m_JobTitle;
        private UserAccount m_objUserAccount;

        #endregion

        #region "Public Properties"
        public string JobTitle
        {
            get { return m_JobTitle; }
            set 
            { 
                if (value.Trim().Length == 0)
                {
                    throw new NotSupportedException("Business Rule: Job Title can not be blank");
                }
                if (value.Length > 30)
                {
                    throw new NotSupportedException("Business Rule: Job Title can not be longet that 25 characters");
                }
                m_JobTitle = value; 
                base.MarkDirty();
            }
        }

        public UserAccount Child_UserAccount
        {
            get { return m_objUserAccount; }
            set 
            {
                m_objUserAccount = value;
                base.MarkDirty();
            }
        }

        public override DateTime BirthDate
        {
            get { return base.BirthDate; }
            set
            {
                if ((DateTime.Now.Year - base.BirthDate.Year) >= 16)
                {
                    base.BirthDate = value;
                    base.MarkDirty();
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

        #region "Constructors"
        public Employee()
        {
            m_objUserAccount = new UserAccount();
            this.m_JobTitle = "";
            Person.Count = Person.Count + 1;
        }
        public Employee(string S_number, string F_name, string L_name, DateTime B_date, string A_dress, string P_number, string J_title, Guid A_countId, string U_name, string P_assword): base(S_number,F_name, L_name, B_date, A_dress, P_number)
        {
            m_JobTitle = J_title;
            this.Child_UserAccount.UserAccountID = A_countId;
            this.Child_UserAccount.Username = U_name;
            this.Child_UserAccount.Password = P_assword;
            Person.Count = Person.Count + 1;
        }

        #endregion

        public override bool Authenticate(string u_user, string u_pass)
        {
            SecurityAlert(u_user, u_pass);
            bool bln_result;
            bln_result = m_objUserAccount.Authenticate(u_user, u_pass);
            if (bln_result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Print()
        {
            try
            {
                StreamWriter objPrinter = new StreamWriter("networkPrinter.txt", true);
                objPrinter.WriteLine("Printing Employee");
                objPrinter.WriteLine("The Employee\'s SS Number is {0}", SSNumber);
                objPrinter.Close();
            }
            catch (Exception X)
            {
                
                throw new Exception("Print Method Error: " + X.Message );
            }
        }
        public virtual void Product_Rental()
        {
            throw new NotSupportedException("This is a violation of curent company policy");
        }
        public virtual void Product_Return()
        {
            throw new NotSupportedException("This is a violation of curent company policy");
        }

        public static Employee Create()
        {
            return DataPortal_Create();
        }

        
        public void Load(string key)
        {
            DataPortal_Fetch(key);
        }

        public void Save()
        {
            if (this.IsDeleted && this.IsNew)
            {
                DataPortal_Delete(SSNumber); //change ssn to GUID ID
            }
            else
            {
                if (this.IsDirty)
                {
                    if (this.IsNew)
                    {
                        DataPortal_Insert();
                    }
                    else
                    {
                        DataPortal_Update();
                    }
                }
            }
            this.Child_UserAccount.Save(this.SSNumber);  //change to GUID ID
        }

        public void ImmediateDelete(string key)
        {
            DataPortal_Delete(key);
        }
        protected static Employee DataPortal_Create()
        {
            return null; //fix me asap
        }

        protected void DataPortal_Fetch(string key)
        {
            SqlConnection objConn = new SqlConnection(strConn);
            try
            {
                objConn.Open();
                string strSQL = "ups_Employee_GetALL";
                SqlCommand objCMD = new SqlCommand(strSQL, objConn);
                objCMD.CommandType = CommandType.StoredProcedure;
                objCMD.Parameters.Add("@Employee_ID", SqlDbType.NVarChar).Value = key;
                SqlDataReader objDR = objCMD.ExecuteReader();
                if (objDR.HasRows)
                {
                    objDR.Read();

                }
            }
            catch (Exception)
            {
                
                throw;
            }

        }
    }
}

 