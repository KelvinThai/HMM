using System.Collections;

namespace HMM.DataModels
{
     class LinePrint
    {
        #region Variables & Properties
        public ArrayList Items
        {
            get;
            set;
        }

        #endregion

        #region Business Logic
        public LinePrint()
        {
            Items = new ArrayList();
        }
        #endregion


    }
}