using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using MediaBusterPOS;
using System.Linq;
using System.Text;

namespace MediaBusterPOS
{
    class EmployeeList : DictionaryBase
    {
        public bool AdminBool = false;
       
        public new int Count
        {
            get { return base.Dictionary.Count; }
        }

        public Employee this[Employee key]
        {
            get
            {
                try
                {
                    return ((Employee)Dictionary[key]);
                }
                catch (Exception OBJe)
                {
                    throw new System.Exception("Item Error: " + OBJe.Message);
                }
            }
            set
            {
                try
                {
                    if (base.Dictionary.Contains(key))
                    {
                        Dictionary[key] = value;
                    }
                    else
                    {
                        throw new ArgumentException("Employee not found, SET Failed");
                    }
                }
                catch (ArgumentException objE)
                {
                    throw new System.ArgumentException(objE.Message);
                }
                catch (Exception objB)
                {
                    throw new ApplicationException("Item Property Error" + objB.Message);
                }

            }
        }

        public void Add(string key, Employee objectEmployee)
        {
            try
            {
                base.Dictionary.Add(key, objectEmployee);
            }
            catch (ArgumentNullException objA)
            {
                throw new System.ArgumentNullException("Invalid Key Error" + objA.Message);
            }
            catch (ArgumentException objB)
            {
                throw new System.ArgumentException("Duplicate Key Error" + objB.Message);
            }
            catch (Exception objE)
            {
                throw new System.Exception("Add Method Error" + objE.Message);
            }
        }

        public void Add(string SSNumber, string f_name, string l_Name, DateTime b_date, string a_ddress, string p_number, string j_obTitle, string A_ccountID, string U_sername, string P_assword)
        {
            try
            {
                Employee AddTempEmployee = new Employee();
                AddTempEmployee.SSNumber = SSNumber;
                AddTempEmployee.FirstName = f_name;
                AddTempEmployee.LastName = l_Name;
                AddTempEmployee.BirthDate = b_date;
                AddTempEmployee.Address = a_ddress;
                AddTempEmployee.PhoneNumber = p_number;
                AddTempEmployee.JobTitle = j_obTitle;
                AddTempEmployee.UserAccount.Password = P_assword;
                AddTempEmployee.UserAccount.UserAccountID = A_ccountID;
                AddTempEmployee.UserAccount.Username = U_sername;
                base.Dictionary.Add(AddTempEmployee.SSNumber, AddTempEmployee);
            }

            catch (ArgumentNullException objY)
            {
                throw new System.ArgumentNullException("Invalid key Error" + objY.Message);
            }
            catch (ArgumentException objX)
            {
                throw new System.ArgumentException("Duplicate key Error:" + objX.Message);
            }
            catch (Exception objz)
            {
                throw new System.Exception("Add Method Error" + objz.Message);
            }


        }

        public bool Edit(string key, Employee objEmployee)
        {
            try
            {
                Employee objEditItem;
                objEditItem = ((Employee)(base.Dictionary[key]));
                if (objEditItem == null)
                {
                    return false;
                }
                else
                {
                    objEditItem.SSNumber = objEmployee.SSNumber;
                    objEditItem.FirstName = objEmployee.FirstName;
                    objEditItem.LastName = objEmployee.LastName;
                    objEditItem.Address = objEmployee.Address;
                    objEditItem.PhoneNumber = objEmployee.PhoneNumber;
                    objEditItem.JobTitle = objEmployee.JobTitle;
                    return true;
                }
            }
            catch (ArgumentNullException objE)
            {
                throw new System.ArgumentNullException("Invalid Key Error: " + objE.Message);
            }
            catch (Exception E)
            {
                throw new System.Exception("Edit Item Error: " + E.Message);
            }
            
        }

        public bool Edit(string SSNum, string f_name, string l_name, DateTime b_date, string a_ddress, string p_number, string j_obTitle, string A_ccountID, string U_sername, string P_assword)
        {
            try
            {
                Employee objEditItem;
                objEditItem = ((Employee)(base.Dictionary[SSNum]));
                if (objEditItem == null)
                {
                    return false;
                }
                else  {
                    objEditItem.SSNumber = SSNum;
                    objEditItem.FirstName = f_name;
                    objEditItem.LastName = l_name;
                    objEditItem.BirthDate = b_date;
                    objEditItem.Address = a_ddress;
                    objEditItem.PhoneNumber = p_number;
                    objEditItem.JobTitle = j_obTitle;
                    objEditItem.UserAccount.UserAccountID = A_ccountID;
                    objEditItem.UserAccount.Username = U_sername;
                    objEditItem.UserAccount.Password = P_assword;
                    return true;
                }
                return false;  //Why
            }
            catch (ArgumentNullException N)
            {
                throw new ArgumentNullException("Invalid Key Error: " + N.Message);
            }
            catch (Exception E)
            {
                throw new Exception("Edit Item Error: " + E.Message);
            }
                
                
            

        }
        public bool Remove(string key)
        {

            try
            {
                if (base.Dictionary.Contains(key))
                {
                    base.Dictionary.Remove(key);
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (ArgumentNullException N)
            {

                throw new System.ArgumentNullException("Invalid Key Error: " + N.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Remove Error: " + ex.Message);
            }
        }

        public bool Print(string key)
        {
            try
            {
                Employee objPrint;
                objPrint = ((Employee)(base.Dictionary[key]));
                if (objPrint == null)
                {
                    return false;
                }
                else
                {
                    objPrint.Print();
                    return true;
                }
            }
            catch (Exception ex)
            {
                
                throw new ApplicationException("Print method Error: " + ex.Message);
            }
        }

        public void PrintAll()
        {
            try
            {
                DictionaryEntry objdictionaryEntry = default(DictionaryEntry);
                Employee objPrintItem = default(Employee);
                foreach (DictionaryEntry objdictionaryEntry_loop in base.Dictionary)
                {
                    objdictionaryEntry = objdictionaryEntry_loop;
                    objPrintItem = ((Employee)(objdictionaryEntry.Value));
                    objPrintItem.Print();
                }
            }
            catch (Exception ex)
            {
                
                throw new System.Exception("Print All Method Error: " + ex.Message);
            }
        }
        public new void Clear()
        {
            try
            {
                base.Dictionary.Clear();
            }
            catch (Exception ex)
            {

                throw new System.Exception("Unexpected Error clearing list: " + ex.Message);
            }
        }
        public bool Authenticate(string strUser, string strPass)
        {
            try
            {
                Load();
                DictionaryEntry dictEntry = default(DictionaryEntry);
                Employee objEmployee = default(Employee);
                if ((strUser == "admin") && (strPass == "999"))
                {
                    AdminBool = true;
                    base.Dictionary.Clear();
                    return true;
                }
                else
                {
                    foreach (DictionaryEntry dictEntry_loop in base.Dictionary)
                    {
                        dictEntry = dictEntry_loop;
                        objEmployee = (Employee)dictEntry.Value;
                        if (objEmployee.Authenticate(strUser, strPass))
                        {
                            base.Dictionary.Clear();
                            return true;
                        }
                    }
                }
                base.Dictionary.Clear();
                return false;
            }
            catch (Exception ex)
            {
                
                throw new System.Exception("Problem with Authenticate Method" + ex.Message);
            }
        }

        public void Load()
        {
            try
            {
                Employee objEmployee = default(Employee);
                //Get Employee data from file for now
                if (!File.Exists("EmployeeData.txt"))
                {
                    StreamWriter objFile = new StreamWriter("EmployeeData.txt", true);
                    objFile.Close();
                }
                StreamReader objDataFile = new StreamReader("EmployeeData.txt");
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
