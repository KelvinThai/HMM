using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HMM.DataModels
{
    public class Employee
    {
        #region Variables & Properties
        public string uid { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Birthday { get; set; }
        public string BirthPlaceCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string AreaCode { get; set; }
        public string ContractID { get; set; }
        public string StationID { get; set; }
        public string Status { get; set; }
        public string Role { get; set; }

        public string EmployeeType { get; set; }
        public string EmployeeContract { get; set; }

        public string DepartmentID { get; set; }

        public string EmployeeImage { get; set; }

        public string EmployeeID { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public string Luong { get; set; }
        public string Address { get; set; }

        public EmployeeContract emplContact = new EmployeeContract();

        public EmployeeType emplType = new EmployeeType();
        #endregion

        #region Business Logic
        public void Reset()
        {
            uid = "";
            FirstName = "";
            MiddleName = "";
            LastName = "";
            UserName = "";
            Password = "";
            Birthday = "";
            BirthPlaceCode = "";
            PhoneNumber = "";
            Gender = "";
            AreaCode = "";
            ContractID = "";
            StationID = "";
            Status = "";
            Role = "";
            DepartmentID = "";
            EmployeeImage = "";
        }
        #endregion


    }
    public class EmployeeContract
    {
        #region Variables & Properties
        public string ID { get; set; }
        public string Content { get; set; }
        public string ContractDate { get; set; }
        public string ContractType { get; set; }
        public string EmployeeTypeID { get; set; }
        #endregion

        #region Business Logic
        public void Reset()
        {
            ID = "";
            Content = "";
            ContractDate = "";
            ContractType = "";
            EmployeeTypeID = "";
        }
        #endregion


    }
    public class EmployeeType
    {
        #region Variables & Properties
        public string ID { get; set; }
        public string Description { get; set; }
        public string Level { get; set; }
        #endregion

        #region Business Logic
        public void Reset()
        {
            ID = "";
            Description = "";
            Level = "";
        }
        #endregion


    }
    public class Gender
    {
        #region Variables & Properties
        public string ID { get; set; }
        public string Description { get; set; }
        #endregion

        #region Business Logic
        public void Reset()
        {
            ID = "";
            Description = "";
        }
        #endregion


    }
}
