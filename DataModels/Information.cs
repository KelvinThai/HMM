using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HMM.DataModels
{
    class GuestSeatByScheduleMap
    {
        #region Variables & Properties
        public string ScheduleID { get; set; }
        public string GuestID { get; set; }
        public string SeatNumber { get; set; }
        public string Status { get; set; }
        public string SelectedDate { get; set; }
        #endregion

        #region Business Logic
        public void Reset()
        {
            ScheduleID = "";
            GuestID = "";
            SeatNumber = "";
            Status = "";
            SelectedDate = "";
        }
        #endregion


    }
    public class Schedule : ICloneable
    {
        #region Variables & Properties
        public string ID { get; set; }
        public string ScheduleDate { get; set; }
        public string TripID { get; set; }
        public string VerhicleID { get; set; }

        public string VerhiclePlate { get; set; }
        public string DriverID { get; set; }

        public string TimeShiftID { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public string CreatedTime { get; set; }
        public string LastModifiedTime { get; set; }
        public string Note { get; set; }
        public string FromStation { get; set; }
        public string ToStation { get; set; }

        public string IsBroken { get; set; }

        public string IsAccident { get; set; }

        public string IsContracted { get; set; }

        public string ContractedPrice { get; set; }

        public string IsTakenOff { get; set; }

        public string IsTakenOffFull { get; set; }

        public string CashBasic { get; set; }
        public int Index { get; set; }
        //Add by Thanh Trung 20211130
        public string IsForOnline { get; set; }
        //End
        #endregion

        #region Business Logic

        public void Init(string szID, string szTimeShiftID, string szVerhicleID, string szFromStation, string szToStation, string szCreatedBy, string szNote, string szTripID, string szDriverID,
                        string szLastModifiedBy, string szLastModifiedTime, string szScheduleDate, string szVerhiclePlate, string szIsBroken, string szIsAccident,
                        string szIsContracted, string szIsTakenOff, int iIndex)
        {
            ID = szID;
            TimeShiftID = szTimeShiftID;
            VerhicleID = szVerhicleID;
            FromStation = szFromStation;
            ToStation = szToStation;
            CreatedBy = szCreatedBy;
            Note = szNote;
            TripID = szTripID;
            DriverID = szDriverID;
            LastModifiedBy = szLastModifiedBy;
            LastModifiedTime = szLastModifiedTime;
            ScheduleDate = szScheduleDate;
            VerhiclePlate = szVerhiclePlate;
            IsBroken = szIsBroken;
            IsAccident = szIsAccident;
            IsContracted = szIsContracted;
            IsTakenOff = szIsTakenOff;
            Index = iIndex;
        }


        public Schedule Clone()
        {

            return new Schedule
            {
                ID = this.ID,
                TimeShiftID = this.TimeShiftID,
                VerhicleID = this.VerhicleID,
                FromStation = this.FromStation,
                ToStation = this.ToStation,
                CreatedBy = this.CreatedBy,
                Note = this.Note,
                TripID = this.TripID,
                DriverID = this.DriverID,
                LastModifiedBy = this.LastModifiedBy,
                LastModifiedTime = this.LastModifiedTime,
                ScheduleDate = this.ScheduleDate,
                VerhiclePlate = this.VerhiclePlate,
                IsBroken = this.IsBroken,
                IsAccident = this.IsAccident,
                IsContracted = this.IsContracted,
                IsTakenOff = this.IsTakenOff,
                Index = this.Index,
                //Add by Thanh Trung 20211130
                //Add param IsForOnline
                IsForOnline = this.IsForOnline
                //End
            };

            throw new NotImplementedException();
        }

        object ICloneable.Clone()
        {
            return new Schedule
            {
                ID = this.ID,
                TimeShiftID = this.TimeShiftID,
                VerhicleID = this.VerhicleID,
                FromStation = this.FromStation,
                ToStation = this.ToStation,
                CreatedBy = this.CreatedBy,
                Note = this.Note,
                TripID = this.TripID,
                DriverID = this.DriverID,
                LastModifiedBy = this.LastModifiedBy,
                LastModifiedTime = this.LastModifiedTime,
                ScheduleDate = this.ScheduleDate,
                VerhiclePlate = this.VerhiclePlate,
                IsBroken = this.IsBroken,
                IsAccident = this.IsAccident,
                IsContracted = this.IsContracted,
                IsTakenOff = this.IsTakenOff,
                Index = this.Index
            };
            throw new NotImplementedException();
        }
        #endregion


    }
    class Station
    {
        #region Variables & Properties
        public string StationID { get; set; }
        public string StationName { get; set; }
        public string OperationStartTime { get; set; }
        public string OperationEndTime { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        #endregion

        #region Business Logic
        public void Reset()
        {
            StationID = "";
            StationName = "";
            OperationStartTime = "";
            OperationEndTime = "";
            Description = "";
            Status = "";
        }
        #endregion



    }
    class TimeShift
    {
        #region Variables & Properties
        public string ShiftID { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public string Note { get; set; }
        public string NoteID { get; set; }
        public string Status { get; set; }
        public string ScheduleDate { get; set; }
        public string FromStation { get; set; }
        public string ToStation { get; set; }
        #endregion

        #region Business Logic
        public void Reset()
        {
            ShiftID = "";
            FromTime = "";
            ToTime = "";
            Note = "";
            Status = "";
            FromStation = "";
            ToStation = "";
            ScheduleDate = "";
            NoteID = "";
        }
        #endregion


    }
    class TripDefinition
    {
        #region Variables & Properties
        public string TripID { get; set; }
        public string FromAreaCode { get; set; }
        public string ToAreaCode { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        #endregion

        #region Business Logic
        public void Reset()
        {
            TripID = "";
            FromAreaCode = "";
            ToAreaCode = "";
            Description = "";
            Status = "";
        }
        #endregion



    }

    class VerhicleTrip
    {
        #region Variables & Properties
        public string TripID { get; set; }
        public string FromAreaCode { get; set; }
        public string ToAreaCode { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        #endregion

        #region Business Logic
        public void Reset()
        {
            TripID = "";
            FromAreaCode = "";
            ToAreaCode = "";
            Description = "";
            Status = "";
        }
        #endregion



    }
    class Area
    {
        #region Variables & Properties
        public string AreaCode { get; set; }
        public string Description { get; set; }
        #endregion

        #region Business Logic
        public void Reset()
        {
            AreaCode = "";
            Description = "";
        }
        #endregion


    }

    class CarManufacture
    {
        #region Variables & Properties
        public string ID { get; set; }
        public string ManufactorName { get; set; }
        #endregion

        #region Business Logic
        public void Reset()
        {
            ID = "";
            ManufactorName = "";
        }
        #endregion


    }
}
