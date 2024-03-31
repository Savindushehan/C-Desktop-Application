using bussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Sample
{
    public partial class Employee_Form : Form
    {
        public Employee_Form()
        {
            InitializeComponent();
        }
        Employee emp = new Employee();
        int age = 0;

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtDivisionCode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Employee_Form_Load(object sender, EventArgs e)
        {
            txtCompanyCode.DataSource = emp.ListCompany();
            txtCompanyCode.DisplayMember = "CompanyName";
            txtCompanyCode.ValueMember = "CompanyCode";

            txtDivisionCode.DataSource = emp.ListDivision();
            txtDivisionCode.DisplayMember = "DivisionName";
            txtDivisionCode.ValueMember = "DivisionID";
            DataTable dt = emp.ListEmployee();
            Data.DataSource = dt;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtEmpNo.Text == null)
            {
                MessageBox.Show("Can't Empty EmpNo");
            }
            else if (txtEmpName.Text == null)
            {
                MessageBox.Show("Can't Empty EmpNo");
            }else if (txtDivisionCode.Text==null)
            {
                MessageBox.Show("Can't Empty DivisionCode");

            }else if (txtCompanyCode.Text == null)
            {
                MessageBox.Show("Can't Empty CompanyCode");
            }else if (txtMobile.TextLength != 10)
            {
                MessageBox.Show("Phone Number Must 10 Digits");
            }
            else
            {
                emp.EmpNo = txtEmpNo.Text;
                emp.EmpName = txtEmpName.Text;
                emp.DateOfBirth = txtBirthday.MaxDate;
                emp.Age = Convert.ToInt32(txtAge.Text);
                emp.ActiveStatus = Convert.ToBoolean(txtActiveStatus.Text);
                emp.NIC = txtNIC.Text;
                emp.Email = txtEmail.Text;
                emp.CompanyCode = txtCompanyCode.SelectedValue.ToString();
                emp.Gender = txtGender.Text;
                emp.MobileNo = txtMobile.Text;
                emp.DivisionCode = txtDivisionCode.SelectedValue.ToString();
                emp.InsertEmployee();


                MessageBox.Show("Account Added Successfully");

                DataTable dt = emp.ListEmployee();
                Data.DataSource = dt;
                cleandata();

            }

        }

        private void txtBirthday_ValueChanged(object sender, EventArgs e)
        {
            if (txtBirthday.Value.Date.Year < DateTime.Now.Date.Year)
            {
                age = DateTime.Now.Date.Year - txtBirthday.Value.Date.Year;
                txtAge.Text = age.ToString();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtEmpNo.Text == null)
            {
                MessageBox.Show("EmpNo not provided");
            }
            else
            {
                emp.EmpNo = txtEmpNo.Text;
                emp.DeleteEmployee();

                MessageBox.Show("Successfully Deleted");
                DataTable dt = emp.ListEmployee();
                Data.DataSource = dt;
                cleandata();


            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtEmpNo.Text == null)
            {
                MessageBox.Show("Can't Empty EmpNo");
            }
            else if (txtEmpName.Text == null)
            {
                MessageBox.Show("Can't Empty EmpNo");
            }
            else if (txtDivisionCode.Text == null)
            {
                MessageBox.Show("Can't Empty DivisionCode");

            }
            else if (txtCompanyCode.Text == null)
            {
                MessageBox.Show("Can't Empty CompanyCode");
            }
            else if (txtMobile.TextLength != 10)
            {
                MessageBox.Show("Phone Number Must 10 Digits");
            }
            else
            {
                emp.EmpNo = txtEmpNo.Text;
                emp.EmpName = txtEmpName.Text;
                emp.DateOfBirth = txtBirthday.MaxDate;
                emp.Age = Convert.ToInt32(txtAge.Text);
                emp.ActiveStatus = Convert.ToBoolean(txtActiveStatus.Text);
                emp.NIC = txtNIC.Text;
                emp.Email = txtEmail.Text;
                emp.CompanyCode = txtCompanyCode.SelectedValue.ToString();
                emp.Gender = txtGender.Text;
                emp.MobileNo = txtMobile.Text;
                emp.DivisionCode = txtDivisionCode.SelectedValue.ToString();
                emp.UpdateEmployee();


                MessageBox.Show("Account Updated Successfully");

                DataTable dt = emp.ListEmployee();
                Data.DataSource = dt;
                cleandata();
            }
           
        }

        private void Data_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = e.RowIndex;
            txtEmpNo.Text = Data.Rows[index].Cells[0].Value.ToString();
            txtEmpName.Text = Data.Rows[index].Cells[1].Value.ToString();
            txtBirthday.Text = Data.Rows[index].Cells[2].Value.ToString();
            txtAge.Text = Data.Rows[index].Cells[3].Value.ToString();
            txtGender.Text = Data.Rows[index].Cells[4].Value.ToString();
            txtActiveStatus.Text = Data.Rows[index].Cells[5].Value.ToString();
            txtNIC.Text = Data.Rows[index].Cells[6].Value.ToString();
            txtMobile.Text = Data.Rows[index].Cells[7].Value.ToString();
            txtEmail.Text = Data.Rows[index].Cells[8].Value.ToString();
            txtCompanyCode.Text = Data.Rows[index].Cells[9].Value.ToString();
            txtDivisionCode.Text = Data.Rows[index].Cells[10].Value.ToString();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cleandata();
        }
        public void cleandata()
        {
            txtEmpNo.Text = null;
            txtEmpName.Text = null;
            txtBirthday.Text = null;
            txtAge.Text = null;
            txtGender.Text = null;
            txtActiveStatus.Text = null;
            txtNIC.Text = null;
            txtMobile.Text = null;
            txtEmail.Text = null;
            txtCompanyCode.Text = null;
            txtDivisionCode.Text = null;
        }
    }
}
