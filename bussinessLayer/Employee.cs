using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace bussinessLayer
{
    public class Employee
    {
        private String empNo;
        public String EmpNo
        {
            get { return empNo; }
            set { empNo = value; }
        }
        private String empName;
        public String EmpName
        {
            get { return empName; }
            set { empName = value; }
        }
        private DateTime dateOfBirth;
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }
        private int age;
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        private String gender;
        public String Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        private bool activeStatus;
        public bool ActiveStatus
        {
            get { return activeStatus; }
            set { activeStatus = value; }
        }
        private String nic;
        public String NIC
        {
            get { return nic; }
            set { nic = value; }
        }
        private String mobileNo;
        public String MobileNo
        {
            get { return mobileNo; }
            set { mobileNo = value; }
        }
        private String email;
        public String Email
        {
            get { return email; }
            set { email = value; }
        }
        private String companyCode;
        public String CompanyCode
        {
            get { return companyCode; }
            set { companyCode = value; }
        }
        private String companyName;
        public String CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }
        private String divisionCode;
        public String DivisionCode
        {
            get { return divisionCode; }
            set { divisionCode = value; }
        }
        private String divisionName;
        public String DivisionName
        {
            get { return divisionName; }
            set { divisionName = value; }
        }
        public DataTable ListEmployee()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("EmpNo"));
            dt.Columns.Add(new DataColumn("EmpName"));
            dt.Columns.Add(new DataColumn("DateOfBirth"));
            dt.Columns.Add(new DataColumn("Age"));
            dt.Columns.Add(new DataColumn("Gender"));
            dt.Columns.Add(new DataColumn("ActiveStatus"));
            dt.Columns.Add(new DataColumn("NIC"));
            dt.Columns.Add(new DataColumn("MobileNo"));
            dt.Columns.Add(new DataColumn("Email"));
            dt.Columns.Add(new DataColumn("CompanyCode"));
            dt.Columns.Add(new DataColumn("DivisionCode"));


            SqlDataReader Sdr;
            DataRow dtRow;


            Sdr = SQLHelper.ExecuteReader("SELECT EmpNo, EmpName,DateOfBirth,Age,Gender,ActiveStatus,NIC,MobileNo,Email,CompanyCode,DivisionCode FROM Employee", CommandType.Text);
            while (Sdr.Read())
            {
                dtRow = dt.NewRow();
                if (!Sdr.IsDBNull(0))
                {
                    dtRow[0] = Sdr.GetString(0);
                }
                if (!Sdr.IsDBNull(1))
                {
                    dtRow[1] = Sdr.GetString(1);
                }
                if (!Sdr.IsDBNull(2))
                {
                    dtRow[2] = Sdr.GetDateTime(2);
                }
                if (!Sdr.IsDBNull(3))
                {
                    dtRow[3] = Sdr.GetInt32(3);
                }
                if (!Sdr.IsDBNull(4))
                {
                    dtRow[4] = Sdr.GetString(4);
                }
                if (!Sdr.IsDBNull(5))
                {
                    dtRow[5] = Sdr.GetBoolean(5);
                }
                if (!Sdr.IsDBNull(6))
                {
                    dtRow[6] = Sdr.GetString(6);
                }
                if (!Sdr.IsDBNull(7))
                {
                    dtRow[7] = Sdr.GetString(7);
                }
                if (!Sdr.IsDBNull(8))
                {
                    dtRow[8] = Sdr.GetString(8);
                }
                if (!Sdr.IsDBNull(9))
                {
                    dtRow[9] = Sdr.GetString(9);
                }
                if (!Sdr.IsDBNull(10))
                {
                    dtRow[10] = Sdr.GetString(10);
                }
                dt.Rows.Add(dtRow);
            }
            Sdr.Close();
            return dt;
        }
        public void InsertEmployee()
        {
            SQLHelper.ExecuteNonQuery("Insert into Employee(EmpNo, EmpName,DateOfBirth,Age,Gender,ActiveStatus,NIC,MobileNo,Email,CompanyCode,DivisionCode)Values('" + EmpNo + "','" + EmpName + "','" + DateOfBirth + "','" + Age + "','" + Gender + "','" + ActiveStatus + "','" + NIC + "','" + MobileNo + "','" + email + "','" + CompanyCode + "','" + DivisionCode + "')", CommandType.Text);
        }
        public DataTable ListCompany()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("CompanyCode"));
            dt.Columns.Add(new DataColumn("CompanyName"));

            SqlDataReader Sdr;
            DataRow dtRow;


            Sdr = SQLHelper.ExecuteReader("SELECT CompanyCode, CompanyName FROM Company", CommandType.Text);
            while (Sdr.Read())
            {
                dtRow = dt.NewRow();
                if (!Sdr.IsDBNull(0))
                {
                    dtRow[0] = Sdr.GetString(0);
                }
                if (!Sdr.IsDBNull(1))
                {
                    dtRow[1] = Sdr.GetString(1);
                }

                dt.Rows.Add(dtRow);
            }
            Sdr.Close();
            return dt;
        }
        public DataTable ListDivision()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("DivisionID"));
            dt.Columns.Add(new DataColumn("DivisionName"));

            SqlDataReader Sdr;
            DataRow dtRow;


            Sdr = SQLHelper.ExecuteReader("SELECT DivisionID, DivisionName FROM Division", CommandType.Text);
            while (Sdr.Read())
            {
                dtRow = dt.NewRow();
                if (!Sdr.IsDBNull(0))
                {
                    dtRow[0] = Sdr.GetString(0);
                }
                if (!Sdr.IsDBNull(1))
                {
                    dtRow[1] = Sdr.GetString(1);
                }

                dt.Rows.Add(dtRow);
            }
            Sdr.Close();
            return dt;
        }

        public void UpdateEmployee()
        {
            SQLHelper.ExecuteNonQuery("Update Employee set  EmpNo='" + EmpNo + "', EmpName='" + EmpName + "', DateOfBirth='" + DateOfBirth + "', Age='" + Age + "', Gender='" + Gender + "', ActiveStatus='" + ActiveStatus + "', NIC='" + NIC + "',MobileNo='" + MobileNo + "', Email='" + Email + "',CompanyCode='" + CompanyCode + "',DivisionCode='" + DivisionCode + "'  Where EmpNo='" + EmpNo + "'", CommandType.Text);
        }

        public void DeleteEmployee()
        {
            SQLHelper.ExecuteNonQuery("Delete From Employee Where EmpNo='" + EmpNo + "'", CommandType.Text);
        }


    }
}
