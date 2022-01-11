using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace HMM.Support
{
    class sqlHelper
    {
        #region Variables & Properties
        public SqlConnection sqlCn;
        private string strErrorMessage;
        private int intErrorNumber;
        private string mErrorMsg;
        private int mErrorCode;
        public string sConnectionString;
        private string sqlLiteConnectionString;
      //  private SQLiteConnection sqliteCn;
        public string ConnectionString
        {
            get
            {
                return sConnectionString;
            }
            set
            {
                sConnectionString = value;
            }
        }

        /// <summary>
        /// String: Câu thông báo lỗi khi truy cập SQL
        /// </summary>
        /// 
        public string ErrorMessage
        {
            get
            {
                return strErrorMessage;
            }
        }
        /// <summary>
        /// int: Số lỗi khi truy cập SQL
        /// </summary>
        public int ErrorNumber
        {
            get
            {
                return intErrorNumber;
            }
        }

        /// <summary>
        /// Ham KetNoiCSDL
        /// </summary>
        /// <return>
        /// DataTable
        /// </return>>
        public SqlConnection OpenConnection()
        {
            SqlConnection sqlCn = new SqlConnection(ConnectionString);
            try
            {
                sqlCn.Open();
            }
            catch
            {
                return null;
            }
            return sqlCn;
        }

        public void CloseConnection(SqlConnection sqlCn)
        {
            if (sqlCn != null)
            {
                if (sqlCn.State == ConnectionState.Open)
                    sqlCn.Close();
                sqlCn.Dispose();
            }
        }
        #endregion

        #region Form Events

        #endregion

        #region Business Logic
        public sqlHelper()
        {
            //sConnectionString = @"Data Source=115.75.20.247;Initial Catalog=HMMNGT_web;User Id=sa; Password=Passgidayt@;";
            //sConnectionString = @"Data Source=113.161.143.226;Initial Catalog=HMMNGT;User Id=sa; Password=Passgidayt";App.User
            sConnectionString = @"Data Source=" + ConfigurationManager.AppSettings["server"] + ",44343" + " ;Initial Catalog=HMMNGT;User Id=Test.User; Password=0902978543;";
            //sConnectionString = @"Data Source=" + ConfigurationManager.AppSettings["server"] + ";Initial Catalog=HMMNGTDev;User Id=sa; Password=Passgidayt@;";
            //sConnectionString = @"Data Source=DESKTOP-DB7O88I;Initial Catalog=HMMNGT;User Id=sa; Password=123456;";
            sqlLiteConnectionString = @"Data Source=local.db;Version=3;New=False;Compress=True;";
        }


        protected DataTable SP_TO_DataTable(
            string TenStoreProcedure,
            SqlParameter[] sqlParam)
        {
            DataTable dtbTmp = new DataTable();
            try
            {
                sqlCn = OpenConnection();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandTimeout = 2000;
                sqlCmd.Connection = sqlCn;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = TenStoreProcedure;
                for (int i = 0; i < sqlParam.Length; i++)
                {
                    sqlCmd.Parameters.Add(sqlParam[i]);
                }
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = sqlCmd;
                sqlDA.Fill(dtbTmp);
                CloseConnection(sqlCn);
            }
            catch (SqlException sqlEx)
            {
                strErrorMessage = sqlEx.Message;
                intErrorNumber = sqlEx.Number;
            }
            finally
            {
                if (sqlCn.State == ConnectionState.Open)
                    sqlCn.Close();
                sqlCn.Dispose();

            }
            return dtbTmp;
        }
        //Thuc thi store procedue khong tham so
        protected DataTable SP_To_DataTable_WithOut_Paras(
               string TenStoreProcedure)
        {
            DataTable dtbTmp = new DataTable();
            try
            {
                sqlCn = OpenConnection();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandTimeout = 2000;
                sqlCmd.Connection = sqlCn;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = TenStoreProcedure;
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = sqlCmd;
                sqlDA.Fill(dtbTmp);
                CloseConnection(sqlCn);
            }
            catch (SqlException sqlEx)
            {
                strErrorMessage = sqlEx.Message;
                intErrorNumber = sqlEx.Number;
            }
            finally
            {
                if (sqlCn.State == ConnectionState.Open)
                    sqlCn.Close();
                sqlCn.Dispose();

            }
            return dtbTmp;
        }
        /// <summary>
        /// Thuc thi 1 store tra ve du lieu la dataset
        /// </summary>
        /// <param name="TenStoreProcedure"></param>
        /// <param name="sqlParam"></param>
        /// <returns></returns>
        protected DataSet SP_To_DataSet(
            string TenStoreProcedure,
            SqlParameter[] sqlParam)
        {
            DataSet dtbTmp = new DataSet();
            try
            {
                sqlCn = OpenConnection();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandTimeout = 2000;
                sqlCmd.Connection = sqlCn;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = TenStoreProcedure;
                for (int i = 0; i < sqlParam.Length; i++)
                {
                    sqlCmd.Parameters.Add(sqlParam[i]);
                }
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = sqlCmd;
                sqlDA.Fill(dtbTmp);
                CloseConnection(sqlCn);
            }
            catch (SqlException sqlEx)
            {
                strErrorMessage = sqlEx.Message;
                intErrorNumber = sqlEx.Number;
            }
            finally
            {
                if (sqlCn.State == ConnectionState.Open)
                    sqlCn.Close();
                sqlCn.Dispose();

            }
            return dtbTmp;
        }

        /// <summary>
        /// Thực thi 1 StoreProcedure không trả lại giá trị
        /// </summary>
        public void ExecStoreProcedure(string TenStoreProcedure, SqlParameter[] sqlParam, SqlConnection cnn = null, bool keepSqlConnection = false)
        {
            try
            {
                SqlCommand sqlCmd;
                if (cnn == null || cnn.State == ConnectionState.Closed) //not input sqlconnection , so try to init new one
                {
                    sqlCn = OpenConnection();
                }
                else//use passed sqlconnection
                {
                    sqlCn = cnn;
                }
                if (sqlCn == null)
                    return;

                sqlCmd = new SqlCommand();
                sqlCmd.CommandTimeout = 2000;

                sqlCmd.Connection = sqlCn;

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = TenStoreProcedure;
                for (int i = 0; i < sqlParam.Length; i++)
                {
                    sqlCmd.Parameters.Add(sqlParam[i]);
                }
                sqlCmd.ExecuteNonQuery();
                strErrorMessage = string.Empty;
                intErrorNumber = 0;
                mErrorCode = 0;
                mErrorMsg = "";
            }
            catch (SqlException sqlEx)
            {
                strErrorMessage = sqlEx.Message;
                intErrorNumber = sqlEx.Number;
            }

            finally
            {
                if (!keepSqlConnection)
                    CloseConnection(sqlCn); //close connection if dont want to keep it
            }
        }

        /// <summary>
        /// Thực thi 1 StoreProcedure return first value
        /// </summary>
        public string ExecStoreProcedure_GetFirstValue(string TenStoreProcedure, SqlParameter[] sqlParam)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandTimeout = 2000;
            sqlCn = OpenConnection();
            sqlCommand.Connection = sqlCn;
            sqlCommand.Parameters.Clear();
            sqlCommand.CommandText = TenStoreProcedure;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < sqlParam.Length; i++)
            {
                sqlCommand.Parameters.Add(sqlParam[i]);
            }

            string Result = "";
            try
            {
                object objResult = sqlCommand.ExecuteScalar();
                if (objResult != null)
                {
                    Result = objResult.ToString();
                }


                mErrorCode = 0;
                mErrorMsg = "";
                CloseConnection(sqlCn);
            }
            catch (SqlException ex)
            {
                intErrorNumber = ex.Number;
                mErrorMsg = ex.Message;
                System.Console.Write(ex.StackTrace);
            }
            finally
            {
                if (sqlCn.State == ConnectionState.Open)
                    sqlCn.Close();
                sqlCn.Dispose();
            }
            return Result;

        }

        /// <summary>
        /// Thực thi 1 StoreProcedure return datatable
        /// </summary>
        public DataTable ExecStoreProcedure_GetDataTable(string TenStoreProcedure, SqlParameter[] sqlParam)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandTimeout = 2000;
            sqlCn = OpenConnection();
            sqlCommand.Connection = sqlCn;
            sqlCommand.Parameters.Clear();
            sqlCommand.CommandText = TenStoreProcedure;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < sqlParam.Length; i++)
            {
                sqlCommand.Parameters.Add(sqlParam[i]);
            }

            SqlDataAdapter Adapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            try
            {
                Adapter.Fill(dt);
                CloseConnection(sqlCn);
            }
            catch (Exception E)
            {
                string strDescriptionError = E.Message;
            }
            finally
            {
                if (sqlCn.State == ConnectionState.Open)
                    sqlCn.Close();
                sqlCn.Dispose();
            }
            return dt;

        }

        /// <summary>
        /// Thực thi 1 câu lệnh SQL dạng select có trả về dữ liệu là 1 bảng
        /// </summary>
        /// <return>
        /// DataTable
        /// </return>>
        public DataTable SQL_query_to_DataTable(string strSQL)
        {
            sqlCn = OpenConnection();
            SqlDataAdapter Adapter = new SqlDataAdapter(strSQL, sqlCn);
            DataTable ds = new DataTable();
            try
            {
                Adapter.Fill(ds);
                CloseConnection(sqlCn);
            }
            catch (SqlException E)
            {
                string strDescriptionError = E.Message;
            }
            finally
            {
                if (sqlCn.State == ConnectionState.Open)
                    sqlCn.Close();
                sqlCn.Dispose();
            }
            return ds;

        }
        /// <summary>
        /// Thực thi 1 câu lệnh SQL dạng select có trả về dữ liệu là DataSet
        /// </summary>
        /// <return>
        /// DataSet
        /// </return>>
        public DataSet SQL_query_ToDataSet(string strSQL)
        {
            sqlCn = OpenConnection();
            SqlDataAdapter Adapter = new SqlDataAdapter(strSQL, sqlCn);
            DataSet ds = new DataSet();
            try
            {
                Adapter.Fill(ds);
                CloseConnection(sqlCn);
            }
            catch (SqlException E)
            {
                string strDescriptionError = E.Message;
            }
            return ds;
        }
        /// <summary>
        /// Thực thi 1 câu lệnh SQL dạng select không trả lại giá trị
        /// </summary>
        public string ExecSQL(string strSQL)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandTimeout = 2000;
            sqlCn = OpenConnection();
            sqlCommand.Connection = sqlCn;
            sqlCommand.Parameters.Clear();
            sqlCommand.CommandText = strSQL;
            sqlCommand.CommandType = CommandType.Text;
            try
            {
                intErrorNumber = sqlCommand.ExecuteNonQuery();
                mErrorCode = 0;
                mErrorMsg = "";
                CloseConnection(sqlCn);
            }
            catch (SqlException ex)
            {
                intErrorNumber = ex.Number;
                mErrorMsg = ex.Message;
                System.Console.Write(ex.StackTrace);
            }
            finally
            {
                if (sqlCn.State == ConnectionState.Open)
                    sqlCn.Close();
                sqlCn.Dispose();
            }
            return mErrorMsg;

        }

        public string ExecSQL_GetFirstValue(string strSQL)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandTimeout = 2000;
            sqlCn = OpenConnection();
            sqlCommand.Connection = sqlCn;
            sqlCommand.Parameters.Clear();
            sqlCommand.CommandText = strSQL;
            sqlCommand.CommandType = CommandType.Text;
            string Result = "";
            try
            {
                object objResult = sqlCommand.ExecuteScalar();
                if (objResult != null)
                {
                    Result = objResult.ToString();
                }


                mErrorCode = 0;
                mErrorMsg = "";
                CloseConnection(sqlCn);
            }
            catch (SqlException ex)
            {
                intErrorNumber = ex.Number;
                mErrorMsg = ex.Message;
                System.Console.Write(ex.StackTrace);
            }
            finally
            {
                if (sqlCn.State == ConnectionState.Open)
                    sqlCn.Close();
                sqlCn.Dispose();
            }
            return Result;

        }


        public string ExecFunction(string fnc, SqlParameter[] sqlParams)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandTimeout = 2000;
            sqlCn = OpenConnection();
            sqlCommand.Connection = sqlCn;
            sqlCommand.Parameters.Clear();
            sqlCommand.CommandText = "SELECT dbo." + fnc + "(";
            sqlCommand.CommandType = CommandType.Text;

            //add parameters and build command text
            for (int i = 0; i < sqlParams.Length; i++)
            {
                SqlParameter param = sqlParams[i];
                sqlCommand.Parameters.Add(param);
                if (i == 0)
                    sqlCommand.CommandText += param.ParameterName;
                else
                    sqlCommand.CommandText += "," + param.ParameterName;
            }

            sqlCommand.CommandText += ")";

            string Result = "";
            try
            {
                object objResult = sqlCommand.ExecuteScalar();
                if (objResult != null)
                {
                    Result = objResult.ToString();
                }


                mErrorCode = 0;
                mErrorMsg = "";
                CloseConnection(sqlCn);
            }
            catch (SqlException ex)
            {
                intErrorNumber = ex.Number;
                mErrorMsg = ex.Message;
                System.Console.Write(ex.StackTrace);
            }
            finally
            {
                if (sqlCn.State == ConnectionState.Open)
                    sqlCn.Close();
                sqlCn.Dispose();
            }
            return Result;

        }
        #endregion

        //#region SQL Lite

        //public SQLiteConnection SQLiteOpenConnection()
        //{
        //    SQLiteConnection sqlite_Cn = new SQLiteConnection(sqlLiteConnectionString);
        //    try
        //    {
        //        sqlite_Cn.Open();
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //    return sqlite_Cn;
        //}

        //public void SQLiteCloseConnection(SQLiteConnection sqliteCn)
        //{
        //    if (sqliteCn != null)
        //    {
        //        if (sqliteCn.State == ConnectionState.Open)
        //            sqliteCn.Close();
        //        sqliteCn.Dispose();
        //    }
        //}

        //public DataTable SQLite_ExecStoreProcedure_GetDataTable(string storedProcedureName, SqlParameter[] sqlParam)
        //{
        //    SQLiteCommand sqliteCommand = new SQLiteCommand();
        //    sqliteCommand.CommandTimeout = 2000;
        //    sqliteCn = SQLiteOpenConnection();
        //    sqliteCommand.Connection = sqliteCn;
        //    sqliteCommand.Parameters.Clear();
        //    sqliteCommand.CommandText = storedProcedureName;
        //    sqliteCommand.CommandType = CommandType.StoredProcedure;
        //    for (int i = 0; i < sqlParam.Length; i++)
        //    {
        //        sqliteCommand.Parameters.Add(sqlParam[i]);
        //    }

        //    SQLiteDataAdapter Adapter = new SQLiteDataAdapter(sqliteCommand);
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        Adapter.Fill(dt);
        //        SQLiteCloseConnection(sqliteCn);
        //    }
        //    catch (Exception E)
        //    {
        //        string strDescriptionError = E.Message;
        //    }
        //    finally
        //    {
        //        if (sqliteCn.State == ConnectionState.Open)
        //            sqliteCn.Close();
        //        sqliteCn.Dispose();
        //    }
        //    return dt;

        //}

        //public void SQLite_InsertNewGuestTrip(string ID, string phoneNumber, string firstName, string LastName, string fromStationID, string toStationID, string tripDate, string address)
        //{
        //    SQLiteCommand sqliteCommand = new SQLiteCommand();
        //    //sqliteCommand.CommandTimeout = 2000;
        //    sqliteCn = SQLiteOpenConnection();
        //    sqliteCommand.Connection = sqliteCn;
        //    sqliteCommand.Parameters.Clear();
        //    sqliteCommand.CommandText = string.Format("Insert into GuestTrip(ID, PhoneNumber, FirstName, LastName, FromStationID, ToStationID, TripDate, AlreadySync, Address) Values({0}, {1}, '{2}', '{3}', {4}, {5}, '{6}', {7}, '{8}')", ID, phoneNumber, firstName, LastName, fromStationID, toStationID, tripDate, 0, address);
        //    sqliteCommand.CommandType = CommandType.Text;

        //    try
        //    {
        //        sqliteCommand.ExecuteNonQuery();
        //        SQLiteCloseConnection(sqliteCn);
        //    }
        //    catch (Exception E)
        //    {
        //        string strDescriptionError = E.Message;
        //    }
        //    finally
        //    {
        //        //if (sqliteCn.State == ConnectionState.Open)
        //        //    sqliteCn.Close();
        //        sqliteCn.Dispose();
        //    }
        //}

        //public int SQLite_GetLastGuestTripID()
        //{
        //    SQLiteCommand sqliteCommand = new SQLiteCommand();
        //    sqliteCommand.CommandTimeout = 2000;
        //    sqliteCn = SQLiteOpenConnection();
        //    sqliteCommand.Connection = sqliteCn;
        //    sqliteCommand.Parameters.Clear();
        //    sqliteCommand.CommandText = string.Format("Select max(ID) from GuestTrip");
        //    sqliteCommand.CommandType = CommandType.Text;
        //    int Result = 0;
        //    try
        //    {
        //        SQLiteDataReader myReader = sqliteCommand.ExecuteReader();

        //        if (myReader.Read())
        //        {
        //            Result = Convert.ToInt16(myReader.GetValue(0));
        //        }
        //        SQLiteCloseConnection(sqliteCn);
        //        // return Result;
        //    }
        //    catch (Exception E)
        //    {
        //        string strDescriptionError = E.Message;
        //    }
        //    finally
        //    {
        //        //if (sqliteCn.State == ConnectionState.Open)
        //        //    sqliteCn.Close();
        //        sqliteCn.Dispose();

        //    }
        //    return Result;
        //}

        ///// <summary>
        ///// Get guest trip by date
        ///// </summary>
        ///// <param name="date">format YYYYMMDD</param>
        ///// <returns></returns>
        //public DataTable SQLite_GetGuestTripByDate(string date)
        //{
        //    SQLiteCommand sqliteCommand = new SQLiteCommand();
        //    sqliteCommand.CommandTimeout = 2000;
        //    sqliteCn = SQLiteOpenConnection();
        //    sqliteCommand.Connection = sqliteCn;
        //    sqliteCommand.Parameters.Clear();
        //    sqliteCommand.CommandText = string.Format("select * from GuestTrip Where TripDate = '{0}'", date);
        //    sqliteCommand.CommandType = CommandType.Text;

        //    SQLiteDataAdapter Adapter = new SQLiteDataAdapter(sqliteCommand);
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        Adapter.Fill(dt);
        //        SQLiteCloseConnection(sqliteCn);
        //    }
        //    catch (Exception E)
        //    {
        //        string strDescriptionError = E.Message;
        //    }
        //    finally
        //    {
        //        //if (sqliteCn.State == ConnectionState.Open)
        //        //    sqliteCn.Close();
        //        sqliteCn.Dispose();
        //    }
        //    return dt;

        //}

        //public DataTable SQLite_GetGuestTripNotSync()
        //{
        //    SQLiteCommand sqliteCommand = new SQLiteCommand();
        //    sqliteCommand.CommandTimeout = 2000;
        //    sqliteCn = SQLiteOpenConnection();
        //    sqliteCommand.Connection = sqliteCn;
        //    sqliteCommand.Parameters.Clear();
        //    sqliteCommand.CommandText = string.Format("select * from GuestTrip Where AlreadySync = 0");
        //    sqliteCommand.CommandType = CommandType.Text;

        //    SQLiteDataAdapter Adapter = new SQLiteDataAdapter(sqliteCommand);
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        Adapter.Fill(dt);
        //        SQLiteCloseConnection(sqliteCn);
        //    }
        //    catch (Exception E)
        //    {
        //        string strDescriptionError = E.Message;
        //    }
        //    finally
        //    {
        //        //if (sqliteCn.State == ConnectionState.Open)
        //        //    sqliteCn.Close();
        //        sqliteCn.Dispose();
        //    }
        //    return dt;

        //}


        //public string SQLite_UpdateTripAlreadySync(string tripIDs)
        //{
        //    SQLiteCommand sqliteCommand = new SQLiteCommand();
        //    sqliteCommand.CommandTimeout = 2000;
        //    sqliteCn = SQLiteOpenConnection();
        //    sqliteCommand.Connection = sqliteCn;
        //    sqliteCommand.Parameters.Clear();
        //    sqliteCommand.CommandText = string.Format("Update GuestTrip set AlreadySync = 1 where ID in ({0})", tripIDs);
        //    sqliteCommand.CommandType = CommandType.Text;

        //    try
        //    {
        //        sqliteCommand.ExecuteNonQuery();
        //        SQLiteCloseConnection(sqliteCn);
        //    }
        //    catch (Exception E)
        //    {
        //        return E.Message;
        //    }
        //    finally
        //    {
        //        //if (sqliteCn.State == ConnectionState.Open)
        //        //    sqliteCn.Close();
        //        sqliteCn.Dispose();
        //    }
        //    return "";

        //}


        //public DataTable SQLite_GetAllGuestProfile()
        //{
        //    SQLiteCommand sqliteCommand = new SQLiteCommand();
        //    sqliteCommand.CommandTimeout = 2000;
        //    sqliteCn = SQLiteOpenConnection();
        //    sqliteCommand.Connection = sqliteCn;
        //    sqliteCommand.Parameters.Clear();
        //    sqliteCommand.CommandText = string.Format("select distinct PhoneNumber, FirstName, LastName, Address from GuestTrip");
        //    sqliteCommand.CommandType = CommandType.Text;

        //    SQLiteDataAdapter Adapter = new SQLiteDataAdapter(sqliteCommand);
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        Adapter.Fill(dt);
        //        SQLiteCloseConnection(sqliteCn);
        //    }
        //    catch (Exception E)
        //    {
        //        string strDescriptionError = E.Message;
        //    }
        //    finally
        //    {
        //        //if (sqliteCn.State == ConnectionState.Open)
        //        //    sqliteCn.Close();
        //        sqliteCn.Dispose();
        //    }
        //    return dt;

        //}

        ////add by Doc Ly 2020/10/09
        //public DataTable SQLite_GetTicketUnassignment()
        //{
        //    SQLiteCommand sqliteCommand = new SQLiteCommand();
        //    sqliteCommand.CommandTimeout = 2000;
        //    sqliteCn = SQLiteOpenConnection();
        //    sqliteCommand.Connection = sqliteCn;
        //    sqliteCommand.Parameters.Clear();
        //    sqliteCommand.CommandText = string.Format("select * from tblTicketUnAssignment");
        //    sqliteCommand.CommandType = CommandType.Text;

        //    SQLiteDataAdapter Adapter = new SQLiteDataAdapter(sqliteCommand);
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        Adapter.Fill(dt);
        //        SQLiteCloseConnection(sqliteCn);
        //    }
        //    catch (Exception E)
        //    {
        //        string strDescriptionError = E.Message;
        //    }
        //    finally
        //    {
        //        sqliteCn.Dispose();
        //    }
        //    return dt;

        //}

        //public void SQLite_InsertTicketUnassignment(string ticketID)
        //{
        //    SQLiteCommand sqliteCommand = new SQLiteCommand();
        //    sqliteCommand.CommandTimeout = 2000;
        //    sqliteCn = SQLiteOpenConnection();
        //    sqliteCommand.Connection = sqliteCn;
        //    sqliteCommand.Parameters.Clear();
        //    sqliteCommand.CommandText = string.Format("INSERT INTO tblTicketUnAssignment(ID) VALUES({0});", ticketID);
        //    sqliteCommand.CommandType = CommandType.Text;

        //    try
        //    {
        //        sqliteCommand.ExecuteNonQuery();
        //        SQLiteCloseConnection(sqliteCn);
        //    }
        //    catch (Exception E)
        //    {
        //        string strDescriptionError = E.Message;
        //    }
        //    finally
        //    {
        //        sqliteCn.Dispose();
        //    }

        //}

        //public void SQLite_DeleteTicketUnassignment(string ticketID)
        //{
        //    SQLiteCommand sqliteCommand = new SQLiteCommand();
        //    sqliteCommand.CommandTimeout = 2000;
        //    sqliteCn = SQLiteOpenConnection();
        //    sqliteCommand.Connection = sqliteCn;
        //    sqliteCommand.Parameters.Clear();
        //    sqliteCommand.CommandText = string.Format("DELETE FROM tblTicketUnAssignment WHERE ID = {0} ", ticketID);
        //    sqliteCommand.CommandType = CommandType.Text;

        //    try
        //    {
        //        sqliteCommand.ExecuteNonQuery();
        //        SQLiteCloseConnection(sqliteCn);
        //    }
        //    catch (Exception E)
        //    {
        //        string strDescriptionError = E.Message;
        //    }
        //    finally
        //    {
        //        sqliteCn.Dispose();
        //    }

        //}

        ////End

        //#endregion

        //#region Data Sync
        //public void DataSync()
        //{
        //    DataTable dt = SQLite_GetGuestTripNotSync();
        //    DataTable tempdt;
        //    string IDs = "";
        //    if (dt != null && dt.Rows.Count > 0)
        //    {

        //        foreach (DataRow r in dt.Rows)
        //        {
        //            //Insert this row to server >>>>>>>>>>>>>> spAddNewGuestTrip
        //            InstanceManagement.SQLHelperInstance.ExecStoreProcedure("spAddNewGuestTrip", new System.Data.SqlClient.SqlParameter[] { new SqlParameter("@PhoneNumber", r["PhoneNumber"].ToString()),
        //                new SqlParameter("@FirstName", r["FirstName"].ToString()),new SqlParameter("@MiddleName", ""),new SqlParameter("@LastName", r["LastName"].ToString()),
        //                new SqlParameter("@FromStationID", r["FromStationID"].ToString()),new SqlParameter("@ToStationID", r["ToStationID"].ToString()),new SqlParameter("@TripDate", r["TripDate"].ToString()),
        //                new SqlParameter("@Address", r["Address"].ToString())});

        //            //Save ID to array, separated by ',' >>>>> 
        //            IDs += r["ID"].ToString() + ",";
        //        }



        //    }
        //    //Update AlreadySync = 1 to local db >>>>>>>>>>>>>> SQLite_UpdateTripAlreadySync
        //    if (IDs.Length > 0)
        //    {
        //        IDs = IDs.Substring(0, IDs.Length - 1);
        //        SQLite_UpdateTripAlreadySync(IDs);
        //    }

        //}


        //#endregion
    }
}
