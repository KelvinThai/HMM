using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMM.DataModels
{
    class UserloginStatus
    {
        #region Variables & Properties
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        /// <summary>
        /// 1: logged in 0: not logged in
        /// </summary>
        public bool Status { get; set; }

        public int UID { get; set; }

        public string StationName { get; set; }

        //add by Doc Ly
        public int CentralPointID { get; set; }

        #endregion

        #region Business Logic
        public void Reset()
        {
            Username = "";
            Password = "";
            Role = "";
            Status = false;
            UID = 0;

        }
        #endregion
    }
}
