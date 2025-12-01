using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.SqlServer.Server;

namespace SimpleCRUD
{
    public partial class FrmClubRegistration : Form
    {

        private ClubRegistrationQuery clubRegistrationQuery;
        private int ID, StudentID, Age, count;
        private string FirstName, MiddleName, LastName, Gender, Program;

        private void btnRefreh_Click(object sender, EventArgs e)
        {
            RefreshListOfClubMembers();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //dgvMembers.Select

            var rowRow = dgvMembers.CurrentRow;

            var updateMember = new FrmUpdateMember();

            ID = Convert.ToInt32(rowRow.Cells["ID"].Value.ToString());
            StudentID = Convert.ToInt32(rowRow.Cells["StudentID"].Value.ToString());
            Age = Convert.ToInt32(rowRow.Cells["Age"].Value.ToString());
            FirstName = rowRow.Cells["FirstName"].Value.ToString();
            MiddleName = rowRow.Cells["MiddleName"].Value.ToString();
            LastName = rowRow.Cells["LastName"].Value.ToString();
            Gender = rowRow.Cells["Gender"].Value.ToString();
            Program = rowRow.Cells["Program"].Value.ToString();

            updateMember.SetData(ID, StudentID, LastName, FirstName, MiddleName, Age, Gender, Program);
            updateMember.ShowDialog();
        }

        private void dgvMembers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private long StudentId;

        public FrmClubRegistration()
        {
            InitializeComponent();
        }

        public void RefreshListOfClubMembers()
        {
            
            clubRegistrationQuery.DisplayList();
            dgvMembers.DataSource = clubRegistrationQuery.bindingSource;
        }

        private void FrmClubRegistration_Load(object sender, EventArgs e)
        {
            clubRegistrationQuery = new ClubRegistrationQuery();

            cbGender.Items.Add("Male");
            cbGender.Items.Add("Female");

            cbProgram.Items.Add("IT");
            cbProgram.Items.Add("CS");

            RefreshListOfClubMembers();
        }

        public int RegistrationID()
        {
            ID = 0;
            var studentId = long.Parse(tbStudentID.Text.Trim());
            var firstName = tbFirstName.Text.Trim();
            var middleName = tbMiddleName.Text.Trim();
            var lastName = tbLastName.Text.Trim();

            if (!int.TryParse(cbAge.Text, out int age))
            {
                MessageBox.Show("Please enter a valid age.");
                return -1;
            }

            var gender = cbGender.SelectedItem?.ToString() ?? "";
            var program = cbProgram.SelectedItem?.ToString() ?? "";

            var isSuccess = clubRegistrationQuery.RegisterStudent(ID, studentId, firstName, middleName, lastName, age, gender, program);

            if (!isSuccess)
            {
                return -1;
            }

            return ID;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegistrationID();

            ID += 1;

            RefreshListOfClubMembers();
        }

    }
}
