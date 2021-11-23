using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PayrollSystem
{
    public partial class E_updateEmployee : Form
    {
        private Employee employee;

        Connection connect = new Connection();
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;

        public E_updateEmployee()
        {
            InitializeComponent();
        }

        public E_updateEmployee(Employee employee) : this()
        {
            this.employee = employee;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = connect.getConnect();
            conn.Open();
            cmd = new SqlCommand("use PayrollSystemWInsert execute UpdateEmployee '" + IDNO.Text +
                                                    "','" + tb_First.Text +
                                                    "','" + tB_Last.Text +
                                                    "', '" + tB_age.Text +
                                                    "', '" + tB_pos.Text +
                                                    "', '" + tB_Bank.Text +
                                                    "', '" + up_TBDeductType.Text +
                                                    "', '" + up_rTBDescrip.Text + "' ", conn);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Updated");

            cmd.Dispose();
            conn.Close();

            this.Close();
        }

  
    }
}
