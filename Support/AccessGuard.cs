using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMM.Constants;
using System.Data;
using System.Security.Cryptography;
using HMM.DataModels;
using static HMM.Constants.Def;
namespace HMM.Support
{
    class AccessGuard
    {
        List<Permission> permissionList = null;


        /// <summary>
        /// Check & enable station From and station To of user
        /// </summary>
        /// <param name="dtStationInput"></param>
        /// <param name="username"></param>
        /// <param name="stationPermission">STA_FROM or STA_TO</param>
        /// <param name="dbColumnToCheck">StationFrom or StationTo</param>
        /// <returns></returns>
        public DataTable RestrictStation(DataTable dtStationInput, string username, Def.Permissions stationPermission)
        {
            DataTable result = dtStationInput.Clone();
            //Get user permission list if haven't got yet
            if (permissionList == null || permissionList.Count == 0)
                permissionList = GetUserPermissionList(username);

            //Filter Station From permission and restrict access
            var StationFromPermission = permissionList.Where(p => p.PermissionCode == stationPermission.ToString()).ToList<Permission>();
            foreach (Permission p in StationFromPermission)
            {
                foreach (DataRow r in dtStationInput.Rows)
                    if (r["StationID"].ToString() == p.Value)
                    {
                        //Station from found from  definition in database, add it to output
                        result.Rows.Add(r.ItemArray);
                    }
            }

            return result;
        }

        public bool CanAccessVehiclePool(Def.VehiclePoolEnum vPool, string username)
        {
            //Get user permission list if haven't got yet
            if (permissionList == null || permissionList.Count == 0)
                permissionList = GetUserPermissionList(username);

            var VPoolPermission = permissionList.Where(p => p.PermissionCode == Def.Permissions.VPOOL.ToString() && p.Value == vPool.ToString()).ToList<Permission>();
            if (VPoolPermission == null || VPoolPermission.Count == 0)
                return false;
            else
                return true;
        }

        public bool CanUserAccessFunction(string username, Def.Permissions permission)
        {
            //Get user permission list if haven't got yet
            if (permissionList == null || permissionList.Count == 0)
                permissionList = GetUserPermissionList(username);

            var p1 = permissionList.Where(p => p.PermissionCode == permission.ToString()).ToList<Permission>();

            return (p1 != null && p1.Count != 0);
        }

        public string GetStationPrintingSize(string username)
        {
            if (permissionList == null || permissionList.Count == 0)
                permissionList = GetUserPermissionList(username);

            var p1 = permissionList.Where(p => p.PermissionCode == Def.Permissions.PRINTSIZE.ToString()).ToList<Permission>();

            if (p1 != null && p1.Count != 0)
                return p1[0].Value;
            else
                return "A4";    //Default printing size

        }

        public PermissionLevel WhatFunctionAccessLevelUserHas(string username, Def.Permissions permission)
        {
            //Get user permission list if haven't got yet
            if (permissionList == null || permissionList.Count == 0)
                permissionList = GetUserPermissionList(username);

            var p1 = permissionList.Where(p => p.PermissionCode == permission.ToString()).ToList<Permission>();

            if (p1 == null && p1.Count == 0)
                return PermissionLevel.NONE;
            else
            {
                if ((p1[0] as Permission).Value.ToString() == Def.PermissionLevel.FULL.ToString())
                    return Def.PermissionLevel.FULL;
                if ((p1[0] as Permission).Value.ToString() == Def.PermissionLevel.READONLY.ToString())
                    return Def.PermissionLevel.READONLY;
            }

            return Def.PermissionLevel.NONE;
        }


        public List<Permission> GetUserPermissionList(string username)
        {
            List<Permission> result = new List<Permission>();

            DataTable dt = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spGetPermissionList", new System.Data.SqlClient.SqlParameter[] { new System.Data.SqlClient.SqlParameter("UserName", username) });
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow r = dt.Rows[i];
                    result.Add(new Permission() { UserGroupID = r["UserGroupID"].ToString(), PermissionCode = r["PermissionCode"].ToString(), TypeCode = r["TypeCode"].ToString(), Value = r["Value"].ToString() });
                }
            }

            return result;
        }

        public void Reset()
        {
            permissionList = null;
        }

        public string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }



    }
}
