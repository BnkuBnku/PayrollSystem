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
    public partial class DateTimeRecord_form : Form
    {
        Connection connect = new Connection();
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;

        string datetime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff");
        public DateTimeRecord_form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_form login = new Login_form();
            login.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            date_label.Text = DateTime.Now.ToString("MMM dd yyyy");
            day_label.Text = DateTime.Now.ToString("dddd");
            Time_label.Text = DateTime.Now.ToString("HH:mm");

        }

        private void DateTimeRecord_form_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void DTRLoad()
        {
            conn = connect.getConnect();
            conn.Open();

            dataGridView1.Rows.Clear();
            cmd = new SqlCommand("use PayrollSystemWInsert execute DisplayDTR", conn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3]);
            }

            dr.Close();
            cmd.Dispose();
            conn.Close();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            conn = connect.getConnect();
            conn.Open();

            cmd = new SqlCommand("use PayrollSystemWInsert execute DisplayDtrEmployee '"+ Tb_InID.Text + "' ",conn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Tb_empID.Text = dr[0].ToString();
                Tb_FN.Text = dr[1].ToString();
                Tb_LN.Text = dr[2].ToString();
                Tb_Pos.Text = dr[3].ToString();
            }

            dr.Close();
            cmd.Dispose();
            conn.Close();
        }

        private void InButton_Click(object sender, EventArgs e)
        {
            conn = connect.getConnect();
            conn.Open();

            cmd = new SqlCommand("use PayrollSystemWInsert execute InTimeEmp '" + Tb_empID.Text + "', '"+ datetime + "'",conn );
            cmd.ExecuteNonQuery();

            MessageBox.Show("Time In Success");
            cmd.Dispose();
            conn.Close();

            DTRLoad();
        }

        private void OutButton_Click(object sender, EventArgs e)
        {
            conn = connect.getConnect();
            conn.Open();

            cmd = new SqlCommand("use PayrollSystemWInsert execute OutTimeEmp '" + Tb_empID.Text + "', '" + datetime + "'", conn);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Time Out Success");
            cmd.Dispose();
            conn.Close();

            DTRLoad();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Tb_InID.Clear();
            Tb_FN.Clear();
            Tb_LN.Clear();
            Tb_empID.Clear();
            Tb_Pos.Clear();
        }

        private void LeaveButton_Click(object sender, EventArgs e)
        {

        }
    }
}
