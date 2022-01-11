using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace HMM.DataModels
{
    class ApplicationSettingObject
    {
        #region Variables & Properties
        public Bitmap Logo
        { get; set; }

        public string DBUserName
        {
            get { return "levy.user"; }
        }

        public string DBPassword
        {
            get { return "P@ssword1"; }
        }

        public string DBName
        {
            get { return "LevyEntry"; }
        }

        public string ServerName
        {
            get { return "10.21.1.26"; }
        }
        #endregion

        #region Business Logic

        #endregion
    }
}
