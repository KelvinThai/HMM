using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HMM.DataModels
{
    public class GuestProfile
    {
        #region Variables & Properties
        public string uid { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string AreaCode { get; set; }
        public string Address { get; set; }

        public string ID { get; set; }
        #endregion

        #region Business Logic
        public void Reset()
        {
            uid = "";
            FirstName = "";
            MiddleName = "";
            LastName = "";
            Birthday = "";
            PhoneNumber = "";
            Gender = "";
            AreaCode = "";
        }
        #endregion



    }
    public class GuestTrip
    {
        #region Variables & Properties
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public string FromStationID { get; set; }
        public string ToStationID { get; set; }
        public string Date { get; set; }

        public string Address { get; set; }

        #endregion

        #region Business Logic
        public void Reset()
        {
            ID = "";
            FirstName = "";
            LastName = "";
            PhoneNumber = "";
            FromStationID = "";
            ToStationID = "";
            Date = "";
        }
        #endregion


    }
}
