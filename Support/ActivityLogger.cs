using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMM.Support
{
    class ActivityLogger
    {
        #region Variables & Properties

        #endregion

        #region Business Logic
        public void WriteLog(int actionID, int userID, string valueBefore, string valueAfter, string desc, string counterID)
        {
            InstanceManagement.SQLHelperInstance.ExecStoreProcedure("spAddActivityLog", new System.Data.SqlClient.SqlParameter[]{
                    new SqlParameter("ActionID", actionID),
                    new SqlParameter("UserID", userID),
                    new SqlParameter("ValueBefore", valueBefore),
                    new SqlParameter("ValueAfter", valueAfter),
                    new SqlParameter("Desc", desc),
                    new SqlParameter("CounterID", counterID)
                });

        }
        #endregion
    }
}
