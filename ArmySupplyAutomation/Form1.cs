using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ASSAS_DataAccessLayer;



namespace ArmySupplyAutomation
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Users users_db = new Users();
            if (reg_pano.TextLength > 3 &&
                reg_username.TextLength > 3 &&
                reg_pwd.Text == reg_pwd_confirm.Text && reg_pwd_confirm.TextLength > 5 &&
                comboBox1.SelectedText != null)
            {
                try
                {

                    users_db.AddNewUser(reg_pano.Text, reg_username.Text,Convert.ToInt32(comboBox1.SelectedValue), reg_pwd.Text, comboBox1.SelectedText);
                    MessageBox.Show("User Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch
                {
                    MessageBox.Show("Add User Failed... Fill Complete Details and Try Again", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Fill Complete Details Correctly and Try Again", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Users users_db = new Users();
            if (users_db.Login(username.Text, password.Text, "") > 0)
            {
                MessageBox.Show("Successfully Logged  Inn", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Invalid Credentials", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Users users_db = new Users();
            if (canapprove.SelectedText != null && appt_title.TextLength>3 && processing_time.TextLength>1)
            {

                int approve = Check();
                if (appt_list.SelectedValue == null)
                {
                    approve = 1;
                    appt_list.SelectedValue = 0;
                }
                if (users_db.Add_Appts(appt_title.Text +" - "+ Titleofappt.Text, approve, Convert.ToInt32(appt_list.SelectedValue), processing_time.Text))
                {
                    MessageBox.Show("Appoitment Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Add Appointment Failed... Fill Complete Details and Try Again", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }

            else
            {
                MessageBox.Show("Fill Complete Details and Try Again", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }
            
        }

        int Check()
        {
            if (canapprove.SelectedText.ToLower() == "yes")
                return 1;
            else
                return 0;
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void units_TextChanged(object sender, EventArgs e)
        {
            //Initializing Appointments DropDown for Add Appointments
            Users users_db = new Users();
            appt_list.DataSource = users_db.Get_Appts(units.Text).Tables[0];
            appt_list.DisplayMember = "Appointment";
            appt_list.ValueMember = "id";
            
        }

        private void unit_TextChanged(object sender, EventArgs e)
        {
            Users users_db = new Users();
            //Initializing Appointments DropDown for Signup
            comboBox1.DataSource = users_db.Get_Appts(unit.Text).Tables[0];
            comboBox1.DisplayMember = "Appointment";
            comboBox1.ValueMember = "id";
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

       
    }
}
