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
    public partial class DTR_search_form : Form
    {
        Connection connect = new Connection();
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;

        public DTR_search_form()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            d_label.Text = DateTime.Now.ToString("yyyy / MM / dd");
            time_label.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            SearchLoadList();
        }

        private void DTR_search_form_Load(object sender, EventArgs e)
        {
            timer1.Start();
            LoadList();
        }

        private void LoadList()
        {
            conn = connect.getConnect();
            conn.Open();

            dataGridView1.Rows.Clear();
            cmd = new SqlCommand("use PayrollSystemWInsert execute DTRReport",conn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4]);
            }

            dr.Close();
            cmd.Dispose();
            conn.Close();
        }

        private void SearchLoadList()
        {
            conn = connect.getConnect();
            conn.Open();

            dataGridView1.Rows.Clear();
            cmd = new SqlCommand("use PayrollSystemWInsert execute SearchDTR '"+tb_EmpID.Text+"'",conn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4]);
            }

            MessageBox.Show("Search Completed");
            dr.Close();
            cmd.Dispose();
            conn.Close();
        }

        private void deletebutton_Click(object sender, EventArgs e)
        {

        }
    }
}
