using HMM.DataModels;
using HMM.Support;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;

namespace HMM
{
    static class InstanceManagement
    {
        #region Variables & Properties
        static Main f;
        public static Main MainFormInstance
        {
            get
            {
                if (f == null)
                    f = new Main();
                return f;
            }
        }

        static UserloginStatus userLogin;
        public static UserloginStatus UserLoginInstance
        {
            get
            {
                if (userLogin == null)
                    userLogin = new UserloginStatus();
                return userLogin;
            }
        }

        static sqlHelper sqlhelper;
        public static sqlHelper SQLHelperInstance
        {
            get
            {
                if (sqlhelper == null)
                    sqlhelper = new sqlHelper();
                return sqlhelper;
            }
        }


        static PrinterHelper printerHelper;
        public static PrinterHelper PrinterHelperInstance
        {
            get
            {
                if (printerHelper == null)
                    printerHelper = new PrinterHelper();
                return printerHelper;
            }
        }

        static ActivityLogger activityLogger;
        public static ActivityLogger ActivityLoggerInstance
        {
            get
            {
                if (activityLogger == null)
                    activityLogger = new ActivityLogger();
                return activityLogger;
            }
        }

        static ApplicationSettingObject appSetting;
        public static ApplicationSettingObject AppSettings
        {
            get
            {
                if (appSetting == null)
                    appSetting = new ApplicationSettingObject();
                return appSetting;
            }
        }

        static AccessGuard accessGuard;
        public static AccessGuard AccessGuard
        {
            get
            {
                if (accessGuard == null)
                    accessGuard = new AccessGuard();
                return accessGuard;
            }
        }

        static ExportData exportData;
        public static ExportData ExportDataInstance
        {
            get
            {
                if (exportData == null)
                    exportData = new ExportData();
                return exportData;
            }
        }

        public static WindowsIdentity WindowsIdentity
        { get; set; }

        public static WindowsImpersonationContext ImpersonationContext
        { get; set; }

        public static HMM.Pages.LoginForm.SafeTokenHandle safeTokenHandle
        { get; set; }


        public static T ToObject<T>(this DataRow dataRow) where T : new()
        {
            T item = new T();
            foreach (DataColumn column in dataRow.Table.Columns)
            {
                PropertyInfo property = item.GetType().GetProperty(column.ColumnName);

                if (property != null && dataRow[column] != DBNull.Value)
                {
                    object result = Convert.ChangeType(dataRow[column], property.PropertyType);
                    property.SetValue(item, result, null);
                }
            }

            return item;
        }
        #endregion

        #region Form Events

        #endregion

        #region Business Logic

        #endregion
    }
}
