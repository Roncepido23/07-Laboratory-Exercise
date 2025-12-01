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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SimpleCRUD
{
    public partial class FrmUpdateMember : Form
    {

        private int id;

        public FrmUpdateMember()
        {
            InitializeComponent();
        }

        private void FrmUpdateMember_Load(object sender, EventArgs e)
        {
            cbGender.Items.Add("Male");
            cbGender.Items.Add("Female");

            cbProgram.Items.Add("BSIT");
            cbProgram.Items.Add("BSCS");
        }

        public void SetData(int id, int studentId, string lastName, string firstName, string middleName, int age, string gender, string program)
        {
            this.id = id;
            cbStudentID.Items.Add(studentId);
            cbGender.Items.Add(gender);
            cbProgram.Items.Add(program);


            tbLastName.Text = lastName;
            tbFirstName.Text = firstName;
            tbMiddleName.Text = middleName;
            tbAge.Text = age.ToString();

            cbStudentID.SelectedItem = studentId;
            cbGender.SelectedItem = gender;
            cbProgram.SelectedItem = program;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            using (var connection = new SqlConnection(@"Server=(LocalDB)\MSSQLLocalDB;Integrated Security=True;AttachDbFilename=C:\Users\oncepido.257554\source\repos\07_Laboratory_Exercise_1\SimpleCRUD\mydb.mdf;"))
            {
                connection.Open();

                var sqlCommand = new SqlCommand("UPDATE dbo.ClubMembers SET StudentID = @StudentID, FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName, Age = @Age, Gender = @Gender, Program = @Program WHERE Id = @Id", connection);
                sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                sqlCommand.Parameters.Add("@StudentID", SqlDbType.BigInt).Value = Convert.ToInt32(cbStudentID.SelectedItem.ToString());
                sqlCommand.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = tbFirstName.Text;
                sqlCommand.Parameters.Add("@MiddleName", SqlDbType.VarChar).Value = tbMiddleName.Text;
                sqlCommand.Parameters.Add("@LastName", SqlDbType.VarChar).Value = tbLastName.Text;
                sqlCommand.Parameters.Add("@Age", SqlDbType.Int).Value = tbAge.Text.ToString();
                sqlCommand.Parameters.Add("@Gender", SqlDbType.VarChar).Value = cbGender.SelectedItem.ToString();
                sqlCommand.Parameters.Add("@Program", SqlDbType.VarChar).Value = cbProgram.SelectedItem.ToString();

                sqlCommand.ExecuteNonQuery();
                connection.Close();
            }


            this.Close();
        }
    }
}
