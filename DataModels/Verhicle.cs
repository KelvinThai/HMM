using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HMM.DataModels
{
    public class Verhicle
    {
        #region Variables & Properties
        public string ID { get; set; }
        public string VTypeID { get; set; }

        public string Plate { get; set; }
        public string LicenseNumber { get; set; }
        public string LicenseIssuedDate { get; set; }
        public string LastRegistrationDate { get; set; }
        public string CurrentDriverID { get; set; }
        public string ManufactorID { get; set; }
        public string ServiceDate { get; set; }

        public string TripID { get; set; }

        public string LicenseExpiryDate { get; set; }

        public string VOperationTypeID { get; set; }
        public int Index { get; set; }

        public VerhicleDriverHistory VDH = new VerhicleDriverHistory();
        #endregion

        #region Business Logic
        public void Reset()
        {
            ID = "";
            VTypeID = "";
            Plate = "";
            LicenseNumber = "";
            LicenseIssuedDate = "";
            LastRegistrationDate = "";
            CurrentDriverID = "";
            ManufactorID = "";
            ServiceDate = "";
            TripID = "";
        }
        #endregion
    }
    public class VerhicleDriverHistory
    {
        #region Variables & Properties
        public string ID { get; set; }
        public string VerhicleID { get; set; }
        public string DriverID { get; set; }
        public string AssignedDate { get; set; }
        public string ScheduleID { get; set; }
        public string Note { get; set; }
        #endregion

        #region Business Logic
        public void Reset()
        {
            ID = "";
            VerhicleID = "";
            DriverID = "";
            AssignedDate = "";
            ScheduleID = "";
            Note = "";
        }
        #endregion

    }
    public class VerhicleSeatMap
    {
        #region Variables & Properties
        public string MapID { get; set; }
        public string VerhicleTypeID { get; set; }
        public string MapPicturePath { get; set; }

        public VerhicleType VerhicleType = new VerhicleType();
        #endregion

        #region Business Logic
        public void Reset()
        {
            MapID = "";
            VerhicleTypeID = "";
            MapPicturePath = "";
        }
        #endregion


    }
    public class VerhicleType
    {
        #region Variables & Properties
        public string TypeID { get; set; }
        public string Description { get; set; }
        public string SeatCapacity { get; set; }
        public string WeightLoad { get; set; }
        #endregion

        #region Business Logic
        public void Reset()
        {
            TypeID = "";
            Description = "";
            SeatCapacity = "";
            WeightLoad = "";
        }
        #endregion


    }
}
