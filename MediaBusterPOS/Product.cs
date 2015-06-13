using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBusterPOS
{
    public abstract class Product
    {
        #region "Private Data"
        private string m_IDNumber;
        private string m_Title;
        private string m_Description;
        private GlobalDeclarations.Rating m_enumRating;
        private bool m_Available;
        private decimal m_salePrice;
        private decimal m_RentalRate;
        private decimal m_LateFee;

        #endregion

        #region "Public Properties"
        public string IDNumber
        {
            get { return m_IDNumber; }
            set { m_IDNumber = value; }
        }
        public string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }



        #endregion
    }
}
