using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMM.Constants
{
    public static class Def
    {

        public const string Domain = "HTPVTG";

        public static string[] colors = { "Red", "Green", "Blue", "Yellow", "LightPink", "Cyan", "DarkBlue", "DarkGoldenrod", "Brown" };
        public enum Permissions
        {
            COUNTER_OPEN_CLOSE_SHIFT = 1,
            PURCHAS_EELS_FUNCTION = 3,
            CANCEL_TRANSACTION = 4,
            OUTSTANDING_LEVY_FUNCTION = 5,
            CHECK_PATRON_LEVY_TRANSACTION = 6,
            VOID_FUNCTION = 7,
            REPRINT_RECEIPT = 8,
            ADD_and_DELETE_USER = 9,
            ADD_and_DELETE_PERMISSION = 11,
            SETUP_COUNTER = 13,
            OPEN_CLOSE_COUNTER = 14,
            SETUP_LEVY_CONFIGURATION_TYPE = 15,
            CHANGE_REASON_FOR_VOIDING = 16,
            SETUP_SHIFT_TIME = 17,
            PATRON_MONITORING = 18,
            MANUAL_CHECK_IN_and_OUT = 19,
            MONITOR_TRADING_DAY = 21,
            ROLL_SHIFT = 22,
            DAILY_LEVY_SALES_PAYMENT_REPORT = 23,
            DAILY_LEVY_SALES_SHIFT_REPORT = 24,
            DAILY_VOID_DETAILS_REPORT = 25,
            SUMMARY_VOID_LEVY_SALES_REPORT = 26,
            INDIVIDUAL_PATRON_LEVY_SALES_REPORT = 27,
            PATRON_INOUT_REPORT = 28,
            MONTHLY_LEVY_SALES_SUMMARY_REPORT = 29,
            DETAILED_MONTHLY_SALE_REPORT = 30,
            AUDIT_TRAIL = 31,
            //-- Permission for station display
            STA_FROM = 32,
            STA_TO = 33,
            //-- Permission for vehicle pool access
            VPOOL = 34,
            //-- Permission for function access
            FEATURE_VEHICLE = 35,
            FEATURE_CUSTOMER = 36,
            FEATURE_DRIVER,
            FEATURE_EMPLOYEE,
            FEATURE_SCHEDULE,
            FEATURE_TICKET,
            FEATURE_GUEST_ASSIGNMENT,
            FEATURE_INVENTORY,
            PRINTSIZE,
            //Add by Doc Ly
            FEATURE_CENTRALPOINT
            //End
        }

        public enum RolesEnum
        {
            Admin = 1,
            ShiftManager = 2,
            Supervisor = 3,
            Cashier = 4,
            SrCashier = 5,
            Audit = 6
        }

        public enum PermissionTypeEnum
        {
            PTYPE_STA = 1,
            PTYPE_VPOOL = 2,
            PTYPE_FEATURE = 3
        }

        public enum VehiclePoolEnum
        {
            BENTHANH = 1,
            MIENDONG = 2,
            VIP = 3,
            TANGCUONG = 4
        }



        public enum PermissionLevel
        {
            READONLY,
            FULL,
            NONE
        }

        public enum VehicleType
        {
            SEAT9 = 9,
            SEAT16 = 16,
            SEAT20 = 20,
            SEAT29 = 29,
            SEAT34 = 34,
            SEAT46 = 46
        }

        public static readonly string[] Roles = { "Admin", "ShiftManager", "Supervisor", "Cashier", "Sr. Cashier", "Audit" };

        public static string FULLDATEFORMAT = "yyyy-MM-dd hh:mm:ss";
        public static string SHOFTDATEFORMAT = "yyyy-MM-dd";


    }
}
