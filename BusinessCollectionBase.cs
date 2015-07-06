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
    public abstract class BusinessCollectionBase : DictionaryBase
    {
        #region "Dirty Object Logic"
        public bool IsDirty {
            get 
            {
                DictionaryEntry objDEntry = default(DictionaryEntry);
                BusinessBase objItem = default(BusinessBase);
                foreach (DictionaryEntry objDEntry_loop in base.Dictionary)
                {
                    objDEntry = objDEntry_loop;
                    objItem = (BusinessBase)objDEntry.Value;
                    if (objItem.IsDirty)
                        return true;
                }
                return false;
            }
        }


        #endregion

        public abstract bool DeferredDelete(string key);
    }
}
