using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMM.Support
{
    class clsNotification : IDisposable
    {
        private string strConnection;
        private string command;
        private Action Act;
        public clsNotification(Action obj, string cmd, string strcon)
        {
            Act = obj;
            command = cmd;
            strConnection = strcon;
            SqlDependency.Start(strcon);
        }
        public void loadData()
        {
            try
            {
                using (var con = new SqlConnection(strConnection))
                {
                    con.Open();
                    var cmd = new SqlCommand(command, con);
                    var de = new SqlDependency(cmd);
                    de.OnChange += new OnChangeEventHandler(de_Onchange);
                    cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    Act?.Invoke();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void de_Onchange(object sender, SqlNotificationEventArgs e)
        {
            var de = sender as SqlDependency;
            de.OnChange -= de_Onchange;
            loadData();
        }

        public void Dispose()
        {
            SqlDependency.Stop(strConnection);
        }
    }
}
