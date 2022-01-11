using HMM.DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Web;
using System.Windows.Forms;

namespace HMM.Support
{
    class API
    {

        #region Variables & Properties
        static List<VerhicleType> listVerhicleType;
        public static List<VerhicleType> GetVerhicleType
        {
            get
            {
                LoadVerhicleType();
                return listVerhicleType;
            }
        }
        #endregion

        #region Business Logic
        private static void LoadVerhicleType()
        {
            listVerhicleType = new List<VerhicleType>();


            DataTable dt = new DataTable();
            dt = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spGetVerhicleType", new System.Data.SqlClient.SqlParameter[] { });
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    VerhicleType objVT = new VerhicleType();
                    objVT.TypeID = row["TypeID"].ToString();
                    objVT.Description = row["Description"].ToString();
                    objVT.SeatCapacity = row["SeatCapacity"].ToString();
                    objVT.WeightLoad = row["WeightLoad"].ToString();
                    listVerhicleType.Add(objVT);
                }
            }
        }

        static List<CarManufacture> listCarManufacture;
        public static List<CarManufacture> GetCarManufacture
        {
            get
            {
                LoadCarManufacture();
                return listCarManufacture;
            }
        }

        private static void LoadCarManufacture()
        {
            listCarManufacture = new List<CarManufacture>();


            DataTable dt = new DataTable();
            dt = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spGetCarManufacture", new System.Data.SqlClient.SqlParameter[] { new SqlParameter("@ID", "0") });
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    CarManufacture objCM = new CarManufacture();
                    objCM.ID = row["ID"].ToString();
                    objCM.ManufactorName = row["ManufactorName"].ToString();
                    listCarManufacture.Add(objCM);
                }
            }
        }

        static List<GuestTrip> listGuestTrip;
        public static List<GuestTrip> GetGuestTrip
        {
            get
            {
                LoadGuestTripByDate();
                return listGuestTrip;
            }
        }
        private static void LoadGuestTripByDate()
        {
            listGuestTrip = new List<GuestTrip>();
            DataTable dt = new DataTable();
            //dt = InstanceManagement.SQLHelperInstance.SQLite_GetGuestTripByDate(DateTime.Now.ToString("yyyyMMdd"));
            //if (dt.Rows.Count > 0)
            //{
            //    foreach (DataRow row in dt.Rows)
            //    {
            //        GuestTrip objGT = new GuestTrip();
            //        objGT.ID = row["ID"].ToString();
            //        objGT.PhoneNumber = row["PhoneNumber"].ToString();
            //        objGT.FirstName = row["FirstName"].ToString();
            //        objGT.LastName = row["LastName"].ToString();
            //        objGT.FromStationID = row["FromStationID"].ToString();
            //        objGT.ToStationID = row["ToStationID"].ToString();
            //        objGT.Date = row["TripDate"].ToString();
            //        objGT.Address = row["Address"].ToString();
            //        listGuestTrip.Add(objGT);
            //    }
            //}
        }

        static List<VerhicleTrip> listVerhicleTrip;
        public static List<VerhicleTrip> GetVerhicleTrip
        {
            get
            {
                LoadVerhicleTrip();
                return listVerhicleTrip;
            }
        }
        private static void LoadVerhicleTrip()
        {
            listVerhicleTrip = new List<VerhicleTrip>();


            DataTable dt = new DataTable();
            dt = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spGetVehicleTrip", new System.Data.SqlClient.SqlParameter[] { });
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    VerhicleTrip objCM = new VerhicleTrip();
                    objCM.TripID = row["TripID"].ToString();
                    objCM.FromAreaCode = row["FromAreaCode"].ToString();
                    objCM.ToAreaCode = row["ToAreaCode"].ToString();
                    objCM.Description = row["Description"].ToString();
                    objCM.Status = row["Status"].ToString();
                    listVerhicleTrip.Add(objCM);
                }
            }
        }

        static List<EmployeeType> listEmployeeType;
        public static List<EmployeeType> GetEmployeeType
        {
            get
            {
                LoadEmployeeType();
                return listEmployeeType;
            }
        }
        private static void LoadEmployeeType()
        {
            listEmployeeType = new List<EmployeeType>();
            DataTable dt = new DataTable();
            dt = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spGetEmployeeType", new System.Data.SqlClient.SqlParameter[] { new SqlParameter("@TypeID", "0") });
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    EmployeeType objVT = new EmployeeType();
                    objVT.ID = row["ID"].ToString();
                    objVT.Description = row["Description"].ToString();
                    objVT.Level = row["Level"].ToString();
                    listEmployeeType.Add(objVT);
                }
            }
        }

        static List<EmployeeContract> listEmployeeContract;
        public static List<EmployeeContract> GetEmployeeContract
        {
            get
            {
                LoadEmployeeContract();
                return listEmployeeContract;
            }
        }
        private static void LoadEmployeeContract()
        {
            listEmployeeContract = new List<EmployeeContract>();
            DataTable dt = new DataTable();
            dt = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spGetEmployeeContract", new System.Data.SqlClient.SqlParameter[] { new SqlParameter("@ID", "0") });
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    EmployeeContract objVT = new EmployeeContract();
                    objVT.ID = row["ID"].ToString();
                    objVT.Content = row["Content"].ToString();
                    objVT.EmployeeTypeID = row["EmployeeTypeID"].ToString();
                    listEmployeeContract.Add(objVT);
                }
            }
        }

        static List<Station> listStation;
        public static List<Station> GetStation
        {
            get
            {
                LoadStation();
                return listStation;
            }
        }
        private static void LoadStation()
        {
            listStation = new List<Station>();
            DataTable dt = new DataTable();
            dt = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spGetStation", new System.Data.SqlClient.SqlParameter[] { new SqlParameter("@ID", "0") });
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Station objVT = new Station();
                    objVT.StationID = row["MaTram"].ToString();
                    objVT.Description = row["DiaChi"].ToString();
                    objVT.StationName = row["DiaChi"].ToString();
                    //objVT.Status = row["Status"].ToString();
                    listStation.Add(objVT);
                }
            }
        }

        public static Boolean AddNewVerhicle(Verhicle objVerhicle)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spAddNewVerhicle",
                    new System.Data.SqlClient.SqlParameter[] { new SqlParameter("@VTypeID", objVerhicle.VTypeID),
                        new SqlParameter("@Plate", objVerhicle.Plate),new SqlParameter("@LicenseNumber", objVerhicle.LicenseNumber),
                        new SqlParameter("@LicenseIssueDate", objVerhicle.LicenseIssuedDate),new SqlParameter("@LastRegistrationDate", objVerhicle.LastRegistrationDate),
                        new SqlParameter("@ManufactorID", objVerhicle.ManufactorID),new SqlParameter("@TripID", objVerhicle.TripID),new SqlParameter("@ServiceDate", objVerhicle.ServiceDate),
                        new SqlParameter("@LicenseExpiryDate", objVerhicle.LicenseExpiryDate),
                        new SqlParameter("@VOperationType",objVerhicle.VOperationTypeID)
                    });
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static Boolean EditVerhicle(Verhicle objVerhicle)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spEditVerhicle",
                    new System.Data.SqlClient.SqlParameter[] { new SqlParameter("@ID", objVerhicle.ID),new SqlParameter("@VTypeID", objVerhicle.VTypeID),
                        new SqlParameter("@Plate", objVerhicle.Plate),new SqlParameter("@LicenseNumber", objVerhicle.LicenseNumber),
                        new SqlParameter("@LicenseIssueDate", objVerhicle.LicenseIssuedDate),new SqlParameter("@LastRegistrationDate", objVerhicle.LastRegistrationDate),
                        new SqlParameter("@ManufactorID", objVerhicle.ManufactorID),new SqlParameter("@TripID", objVerhicle.TripID),new SqlParameter("@ServiceDate", objVerhicle.ServiceDate),
                        new SqlParameter("@LicenseExpiryDate", objVerhicle.LicenseExpiryDate),
                        new SqlParameter("@VOperationType",objVerhicle.VOperationTypeID)});
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static Boolean AddNewScheduleShift(Schedule objSchedule)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spAddScheduleShift",
                    new System.Data.SqlClient.SqlParameter[] { new SqlParameter("@Date", objSchedule.ScheduleDate),
                        new SqlParameter("@ShiftID", objSchedule.TimeShiftID),new SqlParameter("@VerhicleID", objSchedule.VerhicleID),
                        new SqlParameter("@DriverID", objSchedule.DriverID),new SqlParameter("@CreatedBy", objSchedule.CreatedBy),
                        new SqlParameter("@CreatedTime", objSchedule.CreatedTime),new SqlParameter("@Note", objSchedule.Note), new SqlParameter("@TripID", objSchedule.TripID),
                        new SqlParameter("@FromStation", objSchedule.FromStation),new SqlParameter("@ToStation", objSchedule.ToStation)
                    //Update by Thanh Trung 20211130: Add param IsForOnline
                   ,new SqlParameter("@IsForOnline", objSchedule.IsForOnline)
                   //End
                    });
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static Boolean RemoveScheduleShift(Schedule objSchedule)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spRemoveSchedule",
                    new System.Data.SqlClient.SqlParameter[] { new SqlParameter("@ScheduleDate", objSchedule.ScheduleDate),
                        new SqlParameter("@ShiftID", objSchedule.TimeShiftID),new SqlParameter("@VehicleID", objSchedule.VerhicleID),
                        new SqlParameter("@FromStation", objSchedule.FromStation),new SqlParameter("@ToStation", objSchedule.ToStation)});

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static Boolean AddNewGuest(GuestProfile objGuest)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spAddNewGuest",
                    new System.Data.SqlClient.SqlParameter[] { new SqlParameter("@PhoneNumber", objGuest.PhoneNumber),
                    new SqlParameter("@FirstName", objGuest.FirstName),new SqlParameter("@MiddleName", objGuest.MiddleName),
                    new SqlParameter("@LastName", objGuest.LastName),new SqlParameter("@Birthday", objGuest.Birthday),
                    new SqlParameter("@Gender", objGuest.Gender),new SqlParameter("@AreaCode", objGuest.AreaCode),
                    new SqlParameter("@Address", objGuest.Address)});
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static Boolean UpdateGuest(GuestProfile objGuest)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spUpdateGuestProfile",
                new System.Data.SqlClient.SqlParameter[] { new SqlParameter("@PhoneNumber", objGuest.PhoneNumber),new SqlParameter("@ID", objGuest.ID),
                    new SqlParameter("@FirstName", objGuest.FirstName),new SqlParameter("@LastName", objGuest.LastName)});
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static Boolean AddNewGuestLocal(GuestProfile objGuest, int GuestTripID, string fromStationID, string toStationID)
        {
            try
            {
                DataTable dt = new DataTable();
               // InstanceManagement.SQLHelperInstance.SQLite_InsertNewGuestTrip(GuestTripID.ToString(), objGuest.PhoneNumber, objGuest.FirstName, objGuest.LastName, fromStationID, toStationID, DateTime.Now.ToString("yyyyMMdd"), objGuest.Address);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = null;

            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }

            return pingable;
        }
        public static Boolean AddNewEmployee(Employee objEmployee)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spAddEmployee",
                    new System.Data.SqlClient.SqlParameter[] { 
                        new SqlParameter("@FullName", objEmployee.FirstName+' '+objEmployee.MiddleName+' '+objEmployee.LastName),
                        new SqlParameter("@StartDate", objEmployee.StartDate),
                        new SqlParameter("@Luong", objEmployee.Luong),
                        new SqlParameter("@Gender", objEmployee.Gender),    
                        new SqlParameter("@PhoneNumber", objEmployee.PhoneNumber),
                        new SqlParameter("@Address", objEmployee.Address),
                        new SqlParameter("@StationID",objEmployee.StationID)});
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static Boolean EditEmployee(Employee objEmployee)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spUpdateEmployee",
                    new System.Data.SqlClient.SqlParameter[] {new SqlParameter("@ID", objEmployee.uid),
                        new SqlParameter("@FullName", objEmployee.FirstName+' '+objEmployee.MiddleName+' '+objEmployee.LastName),
                        new SqlParameter("@StartDate", objEmployee.StartDate),
                        new SqlParameter("@Luong", objEmployee.Luong),
                        new SqlParameter("@Gender", objEmployee.Gender),
                        new SqlParameter("@PhoneNumber", objEmployee.PhoneNumber),
                        new SqlParameter("@Address", objEmployee.Address),
                        new SqlParameter("@StationID",objEmployee.StationID)});

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static DataTable LoadArea()
        {
            //listStation = new List<Station>();
            DataTable dt = new DataTable();
            dt = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spGetArea", new System.Data.SqlClient.SqlParameter[] { });


            return dt;
        }

        public static string AddNewTicket(Ticket objTicket)
        {
            try
            {
                var rs = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetFirstValue("spAddNewTicket",
                     new System.Data.SqlClient.SqlParameter[] { new SqlParameter("@GuestID", objTicket.GuestID),
                        new SqlParameter("@ScheduleId", objTicket.ScheduleID),
                        new SqlParameter("@ShiftID", objTicket.ShiftID),new SqlParameter("@SeatNumber", objTicket.SeatNumber),
                        new SqlParameter("@PickupPointID", objTicket.PickupPointID),new SqlParameter("@CustomPickupPoint", objTicket.CustomPickupPoint),
                        new SqlParameter("@DropoffPointID", objTicket.DropoffPointID),new SqlParameter("@CustomDropoffPoint", objTicket.CustomDropoffPoint),
                        new SqlParameter("@Note", objTicket.Note), new SqlParameter("@PaymentTransactionID", objTicket.@PaymentTransactionID),
                        new SqlParameter("@DepartureDate", objTicket.DepartureDate), new SqlParameter("@NumOfSeat", objTicket.NumOfSeat),
                        new SqlParameter("@Seats", objTicket.Seats),new SqlParameter("@VehicleID", objTicket.VerhicleID),
                        new SqlParameter("@GuestName", objTicket.GuestName),
                        new SqlParameter("@GuestPhoneNumber", objTicket.GuestPhoneNumber),
                        new SqlParameter("@Status",objTicket.Status),
                        new SqlParameter("@Color",objTicket.Color),
                        new SqlParameter("@TicketTypeID",objTicket.TicketTypeID),
                        new SqlParameter("@SubStationID",objTicket.SubStationID),
                        new SqlParameter("@Price",objTicket.Price),
                        new SqlParameter("@CreatedBy",objTicket.CreatedBy),
                        new SqlParameter("@CreatedLocation",objTicket.CreatedLocation),
                        new SqlParameter("@PromotionCode",objTicket.PromotionCode),
                        new SqlParameter("@PromotionID",objTicket.PromotionID),
                        new SqlParameter("@CashBasic",objTicket.CashBasic),
                        new SqlParameter("@FromWebArea",objTicket.FromWebArea),
                        new SqlParameter("@ToWebArea",objTicket.ToWebArea),
                        new SqlParameter("@IsPrinted",objTicket.IsAfterPrinted),
                        new SqlParameter("@Revenue",objTicket.Revenue),
                        new SqlParameter("@CommentID",objTicket.CommentID)
                     });
                return rs;
            }
            catch (Exception e)
            {
                return "";
            }
        }

        public static Boolean UpdateTicket(Ticket objTicket)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spUpdateTicket",
                new System.Data.SqlClient.SqlParameter[] { new SqlParameter("@TicketID", objTicket.TicketID),
                        new SqlParameter("@GuestID", objTicket.GuestID),
                        new SqlParameter("@ShiftID", objTicket.ShiftID),
                        new SqlParameter("@SeatNumber", objTicket.SeatNumber),
                        new SqlParameter("@PickupPointID", objTicket.PickupPointID),
                        new SqlParameter("@CustomPickupPoint", objTicket.CustomPickupPoint),
                        new SqlParameter("@DropoffPointID", objTicket.DropoffPointID),
                        new SqlParameter("@CustomDropoffPoint", objTicket.CustomDropoffPoint),
                        new SqlParameter("@Note", objTicket.Note),
                        new SqlParameter("@PaymentTransactionID", objTicket.@PaymentTransactionID),
                        new SqlParameter("@DepartureDate", objTicket.DepartureDate),
                        new SqlParameter("@NumOfSeat", objTicket.NumOfSeat),
                        new SqlParameter("@VehicleID", objTicket.VerhicleID),
                        new SqlParameter("@GuestName", objTicket.GuestName),
                        new SqlParameter("@GuestPhoneNumber", objTicket.GuestPhoneNumber),
                        new SqlParameter("@Price",objTicket.Price),
                        new SqlParameter("@Color",objTicket.Color),
                        //add by Doc Ly
                        new SqlParameter("@PromotionCode",objTicket.PromotionCode),
                        new SqlParameter("@PromotionID",objTicket.PromotionID),
                        new SqlParameter("@CashBasic",objTicket.CashBasic),
                        new SqlParameter("@FromWebArea",objTicket.FromWebArea),
                        new SqlParameter("@ToWebArea",objTicket.ToWebArea),
                        new SqlParameter("@TicketType",objTicket.TicketTypeID),
                        new SqlParameter("@Revenue",objTicket.Revenue),
                        new SqlParameter("@CommentID",objTicket.CommentID)
                });

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static Boolean InventoryImport(ItemDefinition objImport, int StoreID)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spINV_AddImport",
                    new System.Data.SqlClient.SqlParameter[] { new SqlParameter("@Description", objImport.Desc),new SqlParameter("@ImportTime", DateTime.Now.ToString()),
                        new SqlParameter("@ImportedBy", InstanceManagement.UserLoginInstance.UID),new SqlParameter("@StoreID", StoreID)});
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static Boolean InventoryImportDetail(ItemDefinition objImport, int ImportID)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spINV_AddImportDetail",
                    new System.Data.SqlClient.SqlParameter[] { new SqlParameter("@ImportID", ImportID),new SqlParameter("@ItemDefID", objImport.ID),
                        new SqlParameter("@Quantity", objImport.Qty)});
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static Boolean InventoryExport(ItemInventory objExport, int iExportedTo, int FromStore, int ToStore)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spINV_AddExport",
                    new System.Data.SqlClient.SqlParameter[] { new SqlParameter("@Description", objExport.Desc),new SqlParameter("@ExportTime", DateTime.Now.ToString()),
                        new SqlParameter("@ExportedBy", InstanceManagement.UserLoginInstance.UID), new SqlParameter("@ExportedTo", iExportedTo),
                         new SqlParameter("@FromStoreID", FromStore), new SqlParameter("@ToStoreID", ToStore)});
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static Boolean InventoryExportDetail(ItemInventory objExport, int ExportID)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spINV_AddExportDetail",
                    new System.Data.SqlClient.SqlParameter[] { new SqlParameter("@ExportID", ExportID),new SqlParameter("@ItemDefID", objExport.ItemDefID),
                        new SqlParameter("@Quantity", objExport.Quantity)});
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static Boolean NewStore(Store objStore)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spAddNewINVStore",
                    new System.Data.SqlClient.SqlParameter[] { new SqlParameter("@StoreName", objStore.StoreName) });
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static Boolean UpdateStore(Store objStore)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spUpdateINVStore",
                    new System.Data.SqlClient.SqlParameter[] { new SqlParameter("@ID", objStore.ID), new SqlParameter("@StoreName", objStore.StoreName) });
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static Boolean NewCategory(Category objCate)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spAddNewINVCategory",
                    new System.Data.SqlClient.SqlParameter[] { new SqlParameter("@CategoryName", objCate.CategoryName) });
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static Boolean UpdateCategory(Category objCate)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spUpdateINVCategory",
                    new System.Data.SqlClient.SqlParameter[] { new SqlParameter("@ID", objCate.ID), new SqlParameter("@CategoryName", objCate.CategoryName) });
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static Boolean NewItemDef(ItemDefinition objItem)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spAddNewItemDef",
                    new System.Data.SqlClient.SqlParameter[] { new SqlParameter("@ItemName", objItem.ItemName), new SqlParameter("@UnitID", objItem.UnitID),
                        new SqlParameter("@CategoryID", objItem.CategoryID),new SqlParameter("@ThumbnailImagePath", objItem.ThumbnailImagePath),new SqlParameter("@LargeImagePath", objItem.LargeImagePath)});
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static Boolean UpdateItemDef(ItemDefinition objItem)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spUpdateItemDef",
                    new System.Data.SqlClient.SqlParameter[] { new SqlParameter("@ID", objItem.ID),new SqlParameter("@ItemName", objItem.ItemName), new SqlParameter("@UnitID", objItem.UnitID),
                        new SqlParameter("@CategoryID", objItem.CategoryID),new SqlParameter("@ThumbnailImagePath", objItem.ThumbnailImagePath),new SqlParameter("@LargeImagePath", objItem.LargeImagePath)});
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static void PrintDocument(string szSourceFilePath, string szFileName)
        {

            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            // szFilePath = @"C:\1.xls";
            // Open the Workbook:
            Microsoft.Office.Interop.Excel.Workbook wb = excelApp.Workbooks.Open(
               szSourceFilePath,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            // Get the first worksheet.
            // (Excel uses base 1 indexing, not base 0.)
            //Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];

            foreach (Microsoft.Office.Interop.Excel.Worksheet ws1 in wb.Worksheets)
            {
                ws1.PageSetup.Zoom = false;
                ws1.PageSetup.FitToPagesWide = 1;
                ws1.PageSetup.FitToPagesTall = false;
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(ws1);
            }

            //FileFormat : 0 = pdf
            //             1 = xps
            wb.ExportAsFixedFormat(0, szFileName,
                                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                    Type.Missing, Type.Missing, Type.Missing);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            wb.Close(false, Type.Missing, Type.Missing);
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(wb);

            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(excelApp);
        }

        public static Boolean UpdateScheduleNote(Schedule objSchedule)
        {
            try
            {
                InstanceManagement.SQLHelperInstance.ExecStoreProcedure("spUpdateScheduleNote",
                new System.Data.SqlClient.SqlParameter[] { new SqlParameter("@Note", objSchedule.Note),new SqlParameter("@IsBroken", objSchedule.IsBroken),
                    new SqlParameter("@IsAccident", objSchedule.IsAccident),new SqlParameter("@ScheduleID", objSchedule.ID),new SqlParameter("@IsContracted", objSchedule.IsContracted),new SqlParameter("@ContractedPrice", objSchedule.ContractedPrice),
                    new SqlParameter("@IsTakenOff", objSchedule.IsTakenOff),
                    new SqlParameter("@IsTakenOffFull", objSchedule.IsTakenOffFull),
                    //add by Doc Ly
                    new SqlParameter("@CashBasic", objSchedule.CashBasic)
                    //End
                });
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static Boolean UpdateScheduleShiftNote(TimeShift objTimeShift)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spUpdateScheduleShiftNote",
                new System.Data.SqlClient.SqlParameter[] { new SqlParameter("@Note", objTimeShift.Note),new SqlParameter("@ShiftID", objTimeShift.ShiftID),
                    new SqlParameter("@ScheduleDate", objTimeShift.ScheduleDate),new SqlParameter("@FromStation", objTimeShift.FromStation),new SqlParameter("@ToStation", objTimeShift.ToStation)});
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static Boolean DeleteScheduleShiftNote(String NoteID)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spDeleteScheduleShiftNote",
                new System.Data.SqlClient.SqlParameter[] { new SqlParameter("@NoteID", NoteID) });
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static Boolean AssignDriverSchedule(int ScheduleID, int DriverID, int AssignedBy)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spAssignDriverSchedule",
                new System.Data.SqlClient.SqlParameter[] { new SqlParameter("@ScheduleID",ScheduleID),new SqlParameter("@DriverID", DriverID),
                    new SqlParameter("@AssignedBy", AssignedBy)});
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static Boolean UpdateScheduleVehicle(int ScheduleID, int VehicleID)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spUpdateScheduleVehicle",
                new System.Data.SqlClient.SqlParameter[] { new SqlParameter("@ScheduleID", ScheduleID), new SqlParameter("@VehicleID", VehicleID) });
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static Int16 CheckApplicationVersion()
        {
            try
            {
                //get current version from file
                string path = Directory.GetCurrentDirectory();
                string strCurVersion = "";
                var fileStream = new FileStream(path + "\\Version.txt", FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    strCurVersion = streamReader.ReadLine();
                }

                //Get Lastest version from DB and compare
                DataTable dt = new DataTable();
                dt = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spGetApplicationVersion",
                new System.Data.SqlClient.SqlParameter[] { });
                if (dt.Rows.Count > 0)
                {
                    string strLatestVersion = dt.Rows[0][0].ToString();
                    var version1 = new Version(strCurVersion);
                    var version2 = new Version(strLatestVersion);

                    var result = version1.CompareTo(version2);
                    if (result < 0)
                        // new version is detected
                        return 1;
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    //Cannot get lastest version 
                    return -1;
                }
            }
            catch (Exception e)
            {
                //Load version fail
                return -2;
            }
        }

        public static void TranslationHeader(DataGridView dg, string strObjName)
        {
            switch (strObjName)
            {
                case "VerhicleForm":
                    for (int i = 0; i < dg.Columns.Count; i++)
                    {
                        if (dg.Columns[i].Name == "Plate") dg.Columns[i].HeaderText = "Biển số";
                        else if (dg.Columns[i].Name == "LicenseNumber") dg.Columns[i].HeaderText = "Số đăng ký";
                        else if (dg.Columns[i].Name == "LicenseIssuedDate") dg.Columns[i].HeaderText = "Ngày đăng ký";
                        else if (dg.Columns[i].Name == "LastRegistrationDate") dg.Columns[i].HeaderText = "Lần đăng kiểm trước";
                        else if (dg.Columns[i].Name == "BirthPlace") dg.Columns[i].HeaderText = "Nơi sinh";
                        else if (dg.Columns[i].Name == "Birthday") dg.Columns[i].HeaderText = "Ngày sinh";
                        else if (dg.Columns[i].Name == "StationName") dg.Columns[i].HeaderText = "Trạm";
                        else if (dg.Columns[i].Name == "CurrentDriverID") dg.Columns[i].HeaderText = "Tài xế hiện tại";
                        else if (dg.Columns[i].Name == "ManufactorID") dg.Columns[i].HeaderText = "Hãng xe";
                        else if (dg.Columns[i].Name == "Status") dg.Columns[i].HeaderText = "Tình trạng";
                        else if (dg.Columns[i].Name == "VTypeID") dg.Columns[i].HeaderText = "Loại xe";
                        else if (dg.Columns[i].Name == "VOperationTypeID") dg.Columns[i].HeaderText = "Dạng xe";
                        else if (dg.Columns[i].Name == "ServiceDate") dg.Columns[i].HeaderText = "Ngày bảo hiểm";
                        else if (dg.Columns[i].Name == "Description") dg.Columns[i].HeaderText = "Hãng xe";
                        else if (dg.Columns[i].Name == "LicenseExpiryDate") dg.Columns[i].HeaderText = "Ngày hết hạn phù hiệu";
                        else dg.Columns[i].Visible = false;
                    }
                    break;
                case "PurchaseTicketForm":
                    for (int i = 0; i < dg.Columns.Count; i++)
                    {
                        if (dg.Columns[i].Name == "From") dg.Columns[i].HeaderText = "Từ";
                        else if (dg.Columns[i].Name == "To") dg.Columns[i].HeaderText = "Đến";
                        else if (dg.Columns[i].Name == "CreatedTime") dg.Columns[i].HeaderText = "Thời điểm đăng ký";
                        else if (dg.Columns[i].Name == "Time") dg.Columns[i].HeaderText = "Chuyến";
                        else if (dg.Columns[i].Name == "CustomPickupPoint") dg.Columns[i].HeaderText = "Điểm đón";
                        else if (dg.Columns[i].Name == "PhoneNumber") dg.Columns[i].HeaderText = "Sđt";
                        else if (dg.Columns[i].Name == "OriginalPhoneNumber") dg.Columns[i].HeaderText = "Sđt đặt";
                        else if (dg.Columns[i].Name == "GuestPhoneNumber") dg.Columns[i].HeaderText = "Sđt đi";
                        else if (dg.Columns[i].Name == "SeatNumber") dg.Columns[i].HeaderText = "Ghế";
                        else if (dg.Columns[i].Name == "StationName") dg.Columns[i].HeaderText = "Trạm";
                        else if (dg.Columns[i].Name == "SubStationCode") dg.Columns[i].HeaderText = "Trạm BS";
                        else if (dg.Columns[i].Name == "CreatedBy") dg.Columns[i].HeaderText = "Mã NV";
                        else if (dg.Columns[i].Name == "CreatedLocation") dg.Columns[i].HeaderText = "Nơi đặt";
                        else if (dg.Columns[i].Name == "DepartureDate") dg.Columns[i].HeaderText = "Ngày đi";
                        else dg.Columns[i].Visible = false;
                    }
                    break;
                case "InvMgm_Store":
                    for (int i = 0; i < dg.Columns.Count; i++)
                    {
                        if (dg.Columns[i].Name == "ID") dg.Columns[i].HeaderText = "Mã kho";
                        else if (dg.Columns[i].Name == "StoreName") dg.Columns[i].HeaderText = "Tên kho";
                        else dg.Columns[i].Visible = false;
                    }
                    break;
                case "InvMgm_Category":
                    for (int i = 0; i < dg.Columns.Count; i++)
                    {
                        if (dg.Columns[i].Name == "ID") dg.Columns[i].HeaderText = "Mã danh mục";
                        else if (dg.Columns[i].Name == "CategoryName") dg.Columns[i].HeaderText = "Tên danh mục";
                        else dg.Columns[i].Visible = false;
                    }
                    break;
                case "InvMgm_Item":
                    for (int i = 0; i < dg.Columns.Count; i++)
                    {
                        if (dg.Columns[i].Name == "ID") dg.Columns[i].HeaderText = "Mã kho";
                        else if (dg.Columns[i].Name == "ItemName") dg.Columns[i].HeaderText = "Tên";
                        else if (dg.Columns[i].Name == "CategoryName") dg.Columns[i].HeaderText = "Danh mục";
                        else if (dg.Columns[i].Name == "UnitName") dg.Columns[i].HeaderText = "Đơn vị";
                        else if (dg.Columns[i].Name == "CreatedDate") dg.Columns[i].HeaderText = "Ngày khởi tạo";
                        else dg.Columns[i].Visible = false;
                    }
                    break;
                case "InventoryForm":
                    for (int i = 0; i < dg.Columns.Count; i++)
                    {
                        if (dg.Columns[i].Name == "ID") dg.Columns[i].HeaderText = "Mã";
                        else if (dg.Columns[i].Name == "ItemName") dg.Columns[i].HeaderText = "Tên";
                        else if (dg.Columns[i].Name == "Quantity") dg.Columns[i].HeaderText = "Số lượng";
                        else if (dg.Columns[i].Name == "CategoryName") dg.Columns[i].HeaderText = "Phân loại hàng";
                        else if (dg.Columns[i].Name == "UnitName") dg.Columns[i].HeaderText = "Đơn vị";
                        else dg.Columns[i].Visible = false;
                    }
                    break;
                case "GuestAssignmentForm":
                    for (int i = 0; i < dg.Columns.Count; i++)
                    {
                        if (dg.Columns[i].Name == "SeatNumber") dg.Columns[i].HeaderText = "Ghế xếp";
                        //else if (dg.Columns[i].Name == "Plate") dg.Columns[i].HeaderText = "Bảng số xe";
                        else if (dg.Columns[i].Name == "Time") dg.Columns[i].HeaderText = "Giờ";
                        else if (dg.Columns[i].Name == "CustomPickupPoint") dg.Columns[i].HeaderText = "Địa chỉ đón";
                        else if (dg.Columns[i].Name == "GuestPhoneNumber") dg.Columns[i].HeaderText = "SDT";
                        else if (dg.Columns[i].Name == "FirstSeat") dg.Columns[i].HeaderText = "Ghế chọn";
                        //add by Doc Ly
                        else if (dg.Columns[i].Name == "Color") dg.Columns[i].HeaderText = "Số hiển thị";
                        //End
                        else dg.Columns[i].Visible = false;
                    }
                    break;
                case "EmployeeForm":
                    for (int i = 0; i < dg.Columns.Count; i++)
                    {
                        if (dg.Columns[i].Name == "LastName") dg.Columns[i].HeaderText = "Họ";
                        else if (dg.Columns[i].Name == "FirstName") dg.Columns[i].HeaderText = "Tên";
                        else if (dg.Columns[i].Name == "PhoneNumber") dg.Columns[i].HeaderText = "Số điện thoại";
                        else if (dg.Columns[i].Name == "BirthPlace") dg.Columns[i].HeaderText = "Nơi sinh";
                        else if (dg.Columns[i].Name == "Birthday") dg.Columns[i].HeaderText = "Ngày sinh";
                        else if (dg.Columns[i].Name == "StationName") dg.Columns[i].HeaderText = "Trạm";
                        else if (dg.Columns[i].Name == "AreaDesc") dg.Columns[i].HeaderText = "Nơi làm việc";
                        else if (dg.Columns[i].Name == "EmployeeType") dg.Columns[i].HeaderText = "Chức vụ";
                        else if (dg.Columns[i].Name == "Department") dg.Columns[i].HeaderText = "Phòng ban";
                        else if (dg.Columns[i].Name == "EmployeeID") dg.Columns[i].HeaderText = "Mã nhân viên";
                        else if (dg.Columns[i].Name == "btnDel") dg.Columns[i].HeaderText = "Xóa";
                        else if (dg.Columns[i].Name == "MiddleName") dg.Columns[i].HeaderText = "Tên Lót";
                        else if (dg.Columns[i].Name == "UserName") dg.Columns[i].HeaderText = "Tài khoản";
                        else if (dg.Columns[i].Name == "GenderString") dg.Columns[i].HeaderText = "Giới tính";
                        //else if (dg.Columns[i].Name == "BirthPlaceCode") dg.Columns[i].HeaderText = "Mã nơi sinh";
                        else if (dg.Columns[i].Name == "Role") dg.Columns[i].HeaderText = "Chức vụ";
                        else if (dg.Columns[i].Name == "StatusString") dg.Columns[i].HeaderText = "Trạng thái";
                        //else if (dg.Columns[i].Name == "ContractID") dg.Columns[i].HeaderText = "Mã hợp đồng";
                        //else if (dg.Columns[i].Name == "StationID") dg.Columns[i].HeaderText = "Mã trạm";
                        //else if (dg.Columns[i].Name == "AreaCode") dg.Columns[i].HeaderText = "Mã khu vực";
                        else if (dg.Columns[i].Name == "Area") dg.Columns[i].HeaderText = "Khu vực";
                        else if (dg.Columns[i].Name == "EmployeeTypeID") dg.Columns[i].HeaderText = "Mã loại nhân viên";
                        else if (dg.Columns[i].Name == "EmployeeID") dg.Columns[i].HeaderText = "Mã nhân viên";
                        else if (dg.Columns[i].Name == "StartDate") dg.Columns[i].HeaderText = "Ngày bắt đầu làm việc";
                        else if (dg.Columns[i].Name == "EndDate") dg.Columns[i].HeaderText = "Ngày nghỉ việc";
                        else dg.Columns[i].Visible = false;
                    }
                    break;
                case "DriverForm":
                    for (int i = 0; i < dg.Columns.Count; i++)
                    {
                        if (dg.Columns[i].Name == "ID") dg.Columns[i].HeaderText = "Mã";
                        else if (dg.Columns[i].Name == "FirstName") dg.Columns[i].HeaderText = "Họ";
                        else if (dg.Columns[i].Name == "MiddleName") dg.Columns[i].HeaderText = "Tên đệm";
                        else if (dg.Columns[i].Name == "LastName") dg.Columns[i].HeaderText = "Tên";
                        else if (dg.Columns[i].Name == "BirthDay") dg.Columns[i].HeaderText = "Ngày sinh";
                        else if (dg.Columns[i].Name == "PhoneNumber") dg.Columns[i].HeaderText = "Số DT";
                        else if (dg.Columns[i].Name == "Gender") dg.Columns[i].HeaderText = "Giới tính";
                        else if (dg.Columns[i].Name == "Status") dg.Columns[i].HeaderText = "Trạng thái";
                        else if (dg.Columns[i].Name == "JoinnedDate") dg.Columns[i].HeaderText = "Ngày tham gia";
                        else if (dg.Columns[i].Name == "BirthPlace") dg.Columns[i].HeaderText = "Nơi sinh";
                        else if (dg.Columns[i].Name == "Plate") dg.Columns[i].HeaderText = "Bảng số xe";
                        else if (dg.Columns[i].Name == "StationName") dg.Columns[i].HeaderText = "Trạm";
                        else if (dg.Columns[i].Name == "LicenseDate") dg.Columns[i].HeaderText = "Ngày cấp bằng lái";
                        else if (dg.Columns[i].Name == "HealthCheckDate") dg.Columns[i].HeaderText = "Ngày k.tra s.khỏe";
                        else if (dg.Columns[i].Name == "LicenseExpiryDate") dg.Columns[i].HeaderText = "Ngày hết hạn chứng chỉ";
                        else if (dg.Columns[i].Name == "NoteTrip") dg.Columns[i].HeaderText = "Tuyến xe thường chạy";
                        else dg.Columns[i].Visible = false;
                    }
                    break;
                case "DriverSchedule":
                    for (int i = 0; i < dg.Columns.Count; i++)
                    {
                        if (dg.Columns[i].Name == "ScheduleDate") dg.Columns[i].HeaderText = "Ngày khởi hành";
                        else if (dg.Columns[i].Name == "DriverName") dg.Columns[i].HeaderText = "Tên tài xế";
                        else if (dg.Columns[i].Name == "FromTime") dg.Columns[i].HeaderText = "Giờ khởi hành";
                        //else if (dg.Columns[i].Name == "ToTime") dg.Columns[i].HeaderText = "Giờ đến dự kiến";
                        //else if (dg.Columns[i].Name == "FromStation") dg.Columns[i].HeaderText = "Điểm khởi hành";
                        //else if (dg.Columns[i].Name == "ToStation") dg.Columns[i].HeaderText = "Điểm đến";
                        else if (dg.Columns[i].Name == "EmployeeName") dg.Columns[i].HeaderText = "Nv xếp lịch";
                        else if (dg.Columns[i].Name == "Plate") dg.Columns[i].HeaderText = "Bảng số xe";
                        else if (dg.Columns[i].Name == "STT") dg.Columns[i].HeaderText = "STT";
                        else if (dg.Columns[i].Name == "TicketNum") dg.Columns[i].HeaderText = "Số lượng ghế";
                        else dg.Columns[i].Visible = false;
                    }
                    break;
                case "TicketHistory":
                    for (int i = 0; i < dg.Columns.Count; i++)
                    {
                        if (dg.Columns[i].Name == "ID") dg.Columns[i].HeaderText = "Mã vé";
                        else if (dg.Columns[i].Name == "LastName") dg.Columns[i].HeaderText = "Họ";
                        else if (dg.Columns[i].Name == "FirstName") dg.Columns[i].HeaderText = "Tên";
                        else if (dg.Columns[i].Name == "ScheduleDate") dg.Columns[i].HeaderText = "Ngày khởi hành";
                        else if (dg.Columns[i].Name == "From") dg.Columns[i].HeaderText = "Từ";
                        else if (dg.Columns[i].Name == "To") dg.Columns[i].HeaderText = "Đến";
                        else if (dg.Columns[i].Name == "CreatedTime") dg.Columns[i].HeaderText = "Thời điểm mua vé";
                        //Add by Thanh Trung -20210201
                        else if (dg.Columns[i].Name == "DepartureDate") dg.Columns[i].HeaderText = "Ngày khách đi";
                        //End
                        else if (dg.Columns[i].Name == "Note") dg.Columns[i].HeaderText = "Ghi chú";
                        else if (dg.Columns[i].Name == "CustomPickupPoint") dg.Columns[i].HeaderText = "Điểm đón";
                        else if (dg.Columns[i].Name == "StatusText") dg.Columns[i].HeaderText = "Trạng thái";
                        else if (dg.Columns[i].Name == "Status") dg.Columns[i].HeaderText = "Mã trạng thái";
                        else if (dg.Columns[i].Name == "StoreName") dg.Columns[i].HeaderText = "Tên";
                        else if (dg.Columns[i].Name == "StoreName") dg.Columns[i].HeaderText = "Tên";
                        else if (dg.Columns[i].Name == "CreatedByName") dg.Columns[i].HeaderText = "NV đặt";
                        else if (dg.Columns[i].Name == "CancelByName") dg.Columns[i].HeaderText = "NV hủy";
                        else dg.Columns[i].Visible = false;
                    }
                    break;
                case "InvExport_Item":
                    for (int i = 0; i < dg.Columns.Count; i++)
                    {
                        if (dg.Columns[i].Name == "ID") dg.Columns[i].HeaderText = "Mã hàng";
                        else if (dg.Columns[i].Name == "ItemName") dg.Columns[i].HeaderText = "Tên";
                        else if (dg.Columns[i].Name == "Quantity") dg.Columns[i].HeaderText = "Số lượng tồn kho";
                        else dg.Columns[i].Visible = false;
                    }
                    break;
                case "InvExport_SelectedItem":
                    for (int i = 0; i < dg.Columns.Count; i++)
                    {
                        if (dg.Columns[i].Name == "ID") dg.Columns[i].HeaderText = "Mã hàng";
                        else if (dg.Columns[i].Name == "ItemName") dg.Columns[i].HeaderText = "Tên";
                        else if (dg.Columns[i].Name == "Quantity") dg.Columns[i].HeaderText = "Số lượng xuất kho";
                        else dg.Columns[i].Visible = false;
                    }
                    break;
                case "Int_History":
                    for (int i = 0; i < dg.Columns.Count; i++)
                    {
                        if (dg.Columns[i].Name == "ID") dg.Columns[i].HeaderText = "Mã";
                        else if (dg.Columns[i].Name == "Description") dg.Columns[i].HeaderText = "Miêu tả";
                        else if (dg.Columns[i].Name == "ImportedBy") dg.Columns[i].HeaderText = "NV nhập";
                        else if (dg.Columns[i].Name == "ExportedBy") dg.Columns[i].HeaderText = "NV xuất";
                        else if (dg.Columns[i].Name == "TransactionTime") dg.Columns[i].HeaderText = "Thời gian";
                        else if (dg.Columns[i].Name == "ExportedTo") dg.Columns[i].HeaderText = "NV nhận";
                        else if (dg.Columns[i].Name == "Quantity") dg.Columns[i].HeaderText = "Số lượng";
                        else dg.Columns[i].Visible = false;
                    }
                    break;
                case "InvImport_Item":
                    for (int i = 0; i < dg.Columns.Count; i++)
                    {
                        if (dg.Columns[i].Name == "ID") dg.Columns[i].HeaderText = "Mã hàng";
                        else if (dg.Columns[i].Name == "ItemName") dg.Columns[i].HeaderText = "Tên";
                        else dg.Columns[i].Visible = false;
                    }
                    break;
                case "InvImport_SelectedItem":
                    for (int i = 0; i < dg.Columns.Count; i++)
                    {
                        if (dg.Columns[i].Name == "ID") dg.Columns[i].HeaderText = "Mã hàng";
                        else if (dg.Columns[i].Name == "ItemName") dg.Columns[i].HeaderText = "Tên";
                        else if (dg.Columns[i].Name == "Quantity") dg.Columns[i].HeaderText = "Số lượng nhập kho";
                        else dg.Columns[i].Visible = false;
                    }
                    break;
                case "44":
                    for (int i = 0; i < dg.Columns.Count; i++)
                    {
                        if (dg.Columns[i].Name == "ID") dg.Columns[i].HeaderText = "Mã";
                        else if (dg.Columns[i].Name == "StoreName") dg.Columns[i].HeaderText = "Tên";
                        else dg.Columns[i].Visible = false;
                    }
                    break;
                case "2233":
                    for (int i = 0; i < dg.Columns.Count; i++)
                    {
                        if (dg.Columns[i].Name == "ID") dg.Columns[i].HeaderText = "Mã";
                        else if (dg.Columns[i].Name == "StoreName") dg.Columns[i].HeaderText = "Tên";
                        else dg.Columns[i].Visible = false;
                    }
                    break;
                case "3113":
                    for (int i = 0; i < dg.Columns.Count; i++)
                    {
                        if (dg.Columns[i].Name == "ID") dg.Columns[i].HeaderText = "Mã";
                        else if (dg.Columns[i].Name == "StoreName") dg.Columns[i].HeaderText = "Tên";
                        else dg.Columns[i].Visible = false;
                    }
                    break;
                case "CentralPointForm":
                    for (int i = 0; i < dg.Columns.Count; i++)
                    {
                        if (dg.Columns[i].Name == "From") dg.Columns[i].HeaderText = "Từ";
                        else if (dg.Columns[i].Name == "To") dg.Columns[i].HeaderText = "Đến";
                        else if (dg.Columns[i].Name == "CreatedTime") dg.Columns[i].HeaderText = "Thời điểm đăng ký";
                        else if (dg.Columns[i].Name == "Time") dg.Columns[i].HeaderText = "Chuyến";
                        else if (dg.Columns[i].Name == "CustomPickupPoint") dg.Columns[i].HeaderText = "Điểm đón";
                        else if (dg.Columns[i].Name == "PhoneNumber") dg.Columns[i].HeaderText = "Sđt";
                        else if (dg.Columns[i].Name == "OriginalPhoneNumber") dg.Columns[i].HeaderText = "Sđt đặt";
                        else if (dg.Columns[i].Name == "GuestPhoneNumber") dg.Columns[i].HeaderText = "Sđt đi";
                        else if (dg.Columns[i].Name == "SeatNumber") dg.Columns[i].HeaderText = "Ghế";
                        else if (dg.Columns[i].Name == "StationName") dg.Columns[i].HeaderText = "Trạm";
                        else if (dg.Columns[i].Name == "SubStationCode") dg.Columns[i].HeaderText = "Trạm BS";
                        else if (dg.Columns[i].Name == "CreatedBy") dg.Columns[i].HeaderText = "Mã NV";
                        else if (dg.Columns[i].Name == "CreatedLocation") dg.Columns[i].HeaderText = "Nơi đặt";
                        else if (dg.Columns[i].Name == "DepartureDate") dg.Columns[i].HeaderText = "Ngày đi";
                        else if (dg.Columns[i].Name == "CashBasic") dg.Columns[i].HeaderText = "Thực thu";
                        else dg.Columns[i].Visible = false;
                    }
                    break;
            }

            dg.Refresh();
            dg.RefreshEdit();
        }


        public static System.Windows.Forms.Control GetOwnerControlOfContextMenu(object sender)
        {
            ToolStripItem menuItem = sender as ToolStripItem;
            if (menuItem != null)
            {
                // Retrieve the ContextMenuStrip that owns this ToolStripItem
                ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
                if (owner != null)
                {
                    // Get the control that is displaying this context menu
                    return owner.SourceControl;
                }
            }

            return null;
        }

        // add by Doc Ly
        public static Boolean CheckTicketExist(Ticket objTicket, string isAssiged = "0")
        {
            try
            {
                var isExist = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetFirstValue("spCheckBookingExisted",
                new System.Data.SqlClient.SqlParameter[] {
                new SqlParameter("@DepartureDate",objTicket.DepartureDate),
                new SqlParameter("@ShiftID", objTicket.ShiftID),
                new SqlParameter("@VehicleID", objTicket.VerhicleID),
                new SqlParameter("@SeatNumber", objTicket.SeatNumber),
                new SqlParameter("@FromStation", objTicket.PickupPointID),
                new SqlParameter("@ToStation", objTicket.DropoffPointID),
                new SqlParameter("@IsAssign", isAssiged),
                });
                return isExist == "1";
            }
            catch { }
            return true;
        }

        public static Boolean CheckScheduleExist(string ScheduleID, string VehicleID)
        {
            try
            {
                var isExist = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetFirstValue("spCheckScheduleExist",
                new System.Data.SqlClient.SqlParameter[] {
                new SqlParameter("@scheduleID",ScheduleID),
                new SqlParameter("@VehicleID",VehicleID)
                });
                return isExist == "1";
            }
            catch { }
            return false;
        }

        public static Boolean CheckSchedulePrinted(string ScheduleID)
        {
            try
            {
                var isExist = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetFirstValue("spCheckScheduleIsPrinted",
                new System.Data.SqlClient.SqlParameter[] {
                new SqlParameter("@ScheduleId",ScheduleID)
                });
                return isExist == "1";
            }
            catch { }
            return false;
        }

        public static void writeLog(string PhoneNumber, string Action,
            string FromStation, string ToStation, string note, string DepartureDate)
        {
            try
            {
                var UserID = InstanceManagement.UserLoginInstance.UID;
                var content = string.Format("{0}: Hành động:{3}; Ngày khởi hành:{7}; SĐT Khách:{1};Nhân viên: {2}; Điểm đi:{4}; Điểm đến:{5}; Ghi chú:{6}",
                    DateTime.Now.ToString("dd/MM/yyy HH:mm:ss"),
                    PhoneNumber, UserID, Action, FromStation, ToStation, note, DepartureDate);
                var path = Path.Combine(Application.StartupPath, "Log");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                var Fullpath = Path.Combine(Application.StartupPath, string.Format("Log/{0}.txt", DateTime.Today.ToString("yyyyMMdd")));

                var fs = new FileStream(Fullpath, FileMode.OpenOrCreate, FileAccess.Write);
                fs.Seek(0, SeekOrigin.End);
                var sw = new StreamWriter(fs);
                sw.WriteLine(content);
                sw.Flush();
                sw.Close();
                fs.Close();
            }
            catch (Exception)
            {
            }

        }

        public static void writeLogSchedule(string action, string content)
        {
            try
            {
                var UserID = InstanceManagement.UserLoginInstance.UID;
                var strcontent = string.Format("{0}: Hành động:{1}; {2}",
                    DateTime.Now.ToString("dd/MM/yyy HH:mm:ss"), action, content);
                var path = Path.Combine(Application.StartupPath, "Log");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                var Fullpath = Path.Combine(Application.StartupPath, string.Format("Log/{0}_Schedule.txt", DateTime.Today.ToString("yyyyMMdd")));

                var fs = new FileStream(Fullpath, FileMode.OpenOrCreate, FileAccess.Write);
                fs.Seek(0, SeekOrigin.End);
                var sw = new StreamWriter(fs);
                sw.WriteLine(strcontent);
                sw.Flush();
                sw.Close();
                fs.Close();
            }
            catch (Exception)
            {
            }

        }

        public static bool UpdateTicketAddressCash(string ticketID, string address, string cashBasic)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spUpdateTicketAddressCash",
                new System.Data.SqlClient.SqlParameter[] {
                        new SqlParameter("@TicketID", ticketID),
                        //add by Doc Ly
                        new SqlParameter("@Address",address),
                        new SqlParameter("@CashBasic",cashBasic),
                        new SqlParameter("@ModifyBy",InstanceManagement.UserLoginInstance.UID)
                });

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool UpdateTicketInVehicle(string ticketID, string isInVehicle)
        {

            try
            {
                DataTable dt = new DataTable();
                dt = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spUpdateTicketInVehicle",
                new System.Data.SqlClient.SqlParameter[] {
                        new SqlParameter("@TicketID", ticketID),
                        //add by Doc Ly
                        new SqlParameter("@IsInVehicle",isInVehicle)
                });
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static DataTable getDriver(string DriverID)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spGetDriver",
                new System.Data.SqlClient.SqlParameter[] {
                        new SqlParameter("@DriverID", DriverID)
                });
            }
            catch (Exception e)
            {
            }
            return dt;
        }

        public static bool SendSMS(string Phone, string Message)
        {
            try
            {
                var client = new HttpClient();
                var url = string.Format("http://115.75.20.247:6969/SendBrandNameOTP.aspx?phone={0}&text={1}", Phone, HttpUtility.UrlEncode(Message));
                // List data response.
                HttpResponseMessage response = client.GetAsync(url).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
                client.Dispose();
                if (response.StatusCode.ToString() == "200" || response.StatusCode.ToString() == "OK")
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool AddNewTicketNotification(string stationID, string content,
            string ticketID, string guestPhone, string departureDate)
        {
            try
            {
                var dt = new DataTable();
                dt = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spAddNewTicketNotification",
                new System.Data.SqlClient.SqlParameter[] {
                        new SqlParameter("@StationID", stationID),
                        //add by Doc Ly
                        new SqlParameter("@Content",content),
                        new SqlParameter("@TicketID",ticketID),
                        new SqlParameter("@GuestPhone",guestPhone),
                        new SqlParameter("@DepartureDate",departureDate)
                });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static DataTable GetTicketNotification()
        {
            var dt = new DataTable();
            try
            {
                dt = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spGetTicketNotification",
                new System.Data.SqlClient.SqlParameter[] {
                        new SqlParameter("@UserID", InstanceManagement.UserLoginInstance.UID)
                });
            }
            catch (Exception ex)
            {
            }
            return dt;
        }

        public static bool UpdateTicketNotificationRead(string ID)
        {
            try
            {
                var dt = new DataTable();
                dt = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spUpdateTicketNotificationRead",
                new System.Data.SqlClient.SqlParameter[] {
                        new SqlParameter("@ID", ID),
                        new SqlParameter("@UserID", InstanceManagement.UserLoginInstance.UID)
                });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static Employee GetCurrentUser()
        {
            var em = new Employee();
            try
            {
                var dt = new DataTable();
                dt = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spGetEmployee",
                new System.Data.SqlClient.SqlParameter[] {
                        new SqlParameter("@ID", InstanceManagement.UserLoginInstance.UID)
                });
                if (dt.Rows.Count > 0)
                {
                    var r = dt.AsEnumerable().First();
                    em.uid = r["uid"].ToString();
                    em.UserName = r["UserName"].ToString();
                    em.FirstName = r["FirstName"].ToString();
                    em.MiddleName = r["MiddleName"].ToString();
                    em.LastName = r["LastName"].ToString();
                }
                return em;
            }
            catch (Exception ex)
            {
                return em;
            }
        }

        public static bool UpdateCentralPointNote(string scheduleId, string note)
        {
            try
            {
                InstanceManagement.SQLHelperInstance.ExecStoreProcedure("spCentralPointUpdateScheduleNote",
                    new SqlParameter[]{
                        new SqlParameter(@"ScheduleID",scheduleId),
                        new SqlParameter(@"Note",note)
                });
                if (string.IsNullOrEmpty(InstanceManagement.SQLHelperInstance.ErrorMessage))
                    return true;
                else return false;
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        public static bool IsVehicleHasTicket(string ScheduleID)
        {
            //Check if schedule has ticket associated
            DataTable tmp = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spGetTicketBySchedule",
                new SqlParameter[] { new SqlParameter("@ScheduleID", ScheduleID) });
            if (tmp.Rows.Count > 0)
            {
                return true;
            }
            //--------------------------------------------
            return false;
        }

        public static bool SetSendSMS(string ticketID)
        {
            //Check if schedule has ticket associated
            DataTable tmp = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spUpdateTicketSendSMS",
                new SqlParameter[] { new SqlParameter("@TicketID", ticketID) });
            if (string.IsNullOrEmpty(InstanceManagement.SQLHelperInstance.ErrorMessage))
            {
                return true;
            }
            //--------------------------------------------
            return false;
        }
        public static DataTable GetSendSMSStatus(string ticketID)
        {
            //Check if schedule has ticket associated
            DataTable tmp = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spGetTicketSendSMSStatus",
                new SqlParameter[] { new SqlParameter("@TicketID", ticketID) });
            return tmp;
        }

        public static bool CheckVehicleExistInSchedule(string departureDate, string fromStation,
            string toStation, string timeshiftid, string vehicleID)
        {
            try
            {
                //Check if schedule has ticket associated
                DataTable tmp = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spCheckVehicleExistInSchedule",
                    new SqlParameter[] {
                        new SqlParameter("@TimeShiftID", timeshiftid),
                        new SqlParameter("@FromStation", fromStation),
                        new SqlParameter("@ToStation", toStation),
                        new SqlParameter("@DepartureDate", departureDate),
                        new SqlParameter("@VehicleID", vehicleID)
                    });
                if (tmp.Rows[0]["EXIST"].ToString() == "1")
                {
                    return true;
                }
                //--------------------------------------------
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        // End

        #endregion
    }
}
