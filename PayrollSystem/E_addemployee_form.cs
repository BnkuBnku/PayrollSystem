using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace PayrollSystem
{
    public partial class E_addemployee_form : Form
    {
        Connection connect = new Connection();
        SqlConnection conn;
        SqlCommand cmd;

        public E_addemployee_form()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = connect.getConnect();
            conn.Open();
            cmd = new SqlCommand("use PayrollSystemWInsert execute InsertEmployee '" 
                                                        + addE_tbFN.Text + // varchar
                                                    "','" + addE_LN.Text + //varchar
                                                    "', '" + addE_age.Text + //int
                                                    "', '" + addE_P.Text + //varchar
                                                    "', '" + addE_bank.Text +  //int
                                                    "', '" + add_TBDeductType.Text + //varchar
                                                    "', '" + add_rTBDescrip.Text + "' ", conn); //varchar
            try
            {
                cmd.ExecuteNonQuery();

                MessageBox.Show("Saved");

                //auto clear the textbox
                addE_tbFN.Text = "";
                addE_LN.Text = "";
                addE_age.Text = "";
                addE_P.Text = "";
                addE_bank.Text = "";
                add_rTBDescrip.Text = "";
                add_TBDeductType.Text = "";
            }
            catch (Exception x)
            {
                MessageBox.Show("Failed to Add \n" + x.Message);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }

    }
}
