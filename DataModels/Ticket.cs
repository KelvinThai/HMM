using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HMM.DataModels
{
    public class Ticket
    {
        #region Variables & Properties
        public string TicketID { get; set; }
        public string GuestID { get; set; }
        public string ShiftID { get; set; }
        public string SeatNumber { get; set; }
        public string PickupPointID { get; set; }
        public string CustomPickupPoint { get; set; }
        public string DropoffPointID { get; set; }
        public string Note { get; set; }

        public string PaymentTransactionID { get; set; }
        public string CustomDropoffPoint { get; set; }

        public string DepartureDate { get; set; }

        public string NumOfSeat { get; set; }

        public string Seats { get; set; }

        public string DepartureTime { get; set; }

        public string VerhicleID { get; set; }

        public string Plate { get; set; }

        public string CarType { get; set; }
        public string GuestName { get; set; }

        public string GuestPhoneNumber { get; set; }

        public string Status { get; set; }

        public string Color { get; set; }
        public string ScheduleID { get; set; }

        public string TicketTypeID { get; set; }

        public string SubStationID { get; set; }
        public string Price { get; set; }
        public string CreatedLocation { get; set; }
        public string CreatedBy { get; set; }
        public string IsBeforeStation { get; set; }
        public string PromotionCode { get; set; }
        public string PromotionID { get; set; }
        public string CashBasic { get; set; }
        public string FromWebArea { get; set; }
        public string ToWebArea { get; set; }
        public string SeatCap { get; set; }
        public string IsAfterPrinted { get; set; }
        public string Revenue { get; set; }
        public string CommentID { get; set; }

        #endregion

        #region Business Logic

        #endregion

    }
    public class TicketInfo
    {
        public int TicketID;
        public int NoOfSeat;
    }
}
