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

namespace Gestion_Employe
{
    public partial class FrmServices : Form
    {
        public FrmServices()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ANDRE_a_MEUNIER\Documents\BDglobal.mdf;Integrated Security=True;Connect Timeout=30");
        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                string query = "insert into TblService values(" + idSER.Text + ",'" + libSer.Text + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Success");
                Con.Close();
                populate();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
private void populate()
        {
            Con.Open();
            string query = "select * from TblService";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            int v = sda.Fill(ds);
            Catview.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idSer.Text = Serview.SelectedRows[0].Cells[0].Value.ToString();
            libSer.Text = Serview.SelectedRows[0].Cells[1].Value.ToString();
            
        }

        private void FrmServiceForm_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if(idSer.Text == "")
                {
                    MessageBox.Show("select the Service");
                }
                else
                {
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                if(idSer.Text=="" || libSer.Text=="" )
                {
                    MessageBox.Show("missing information");
                }
                else
                {
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EmployeForm prod = new EmployeForm();
            ser.Show();
            this.Hide();
        }
    }
}
