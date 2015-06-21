using System;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;

namespace MediaBusterPOS
{
    [Serializable]
    public abstract class BusinessBase
    {
        #region "Private Data"
        private bool m_flgIsDirty = true;
        private bool m_flgIsNew = true;
        private bool m_flgIsDeleted = false;
        #endregion

        #region "Public Properties"
        public bool IsNew
        {
            get {return m_flgIsNew;}
            
        }
        public virtual bool IsDirty
        {
            get { return m_flgIsDirty; }
        }
        public virtual bool IsDeleted
        {
            get { return m_flgIsDeleted; }
        }
	    #endregion
        #region "Private and Protected Methods"
        protected void MarkDirty()
        {
            m_flgIsDirty = true;
        }
        private void MarkClean()
        {
            m_flgIsDirty = false;
        }
        protected void MarkNew()
        {
            m_flgIsNew = true;
            m_flgIsDeleted = false;
            MarkDirty();
        }

        protected void MarkOld()
        {
            m_flgIsNew = false;
            MarkClean();
        }

        protected void MarkDeleted()
        {
            m_flgIsDeleted = true;
            MarkDirty();
        }
        #endregion

        #region "Public Methods"

        public void DeferredDelete()
        {
            MarkDeleted();
        }


        #endregion



    }
}
