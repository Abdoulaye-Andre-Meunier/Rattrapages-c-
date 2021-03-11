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
    public partial class EmployeForm : Form
    {
        public EmployeForm()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ANDRE_a_MEUNIER\Documents\BDglobal.mdf;Integrated Security=True;Connect Timeout=30");

        public object idEmp { get; private set; }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }
private void fillcombo()
        {
            Con.Open();
            SqlCommand cmd =new SqlCommand("select nameCat from TblServices", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("libSer", typeof(string));
            dt.Load(rdr);
            CatCb.ValueMember = "libSer";
            CatCb.DataSource = dt;
            Con.Close();
        }
        private void EmployeForm_Load(object sender, EventArgs e)
        {
            fillcombo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmServices cat = new FrmServices();
            cat.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open()
                string query = "insert into TblEmploye values(" + idEmp.Text + ",'" + nameEmp + "'," + dateEmp.Text + ")";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Employe Added");
                Con.Close();
                //populate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
private void populate()
        {
            Con.Open();
            string query = "select * from TblEmploye";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            int v = sda.Fill(ds);
            Prodview.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idEmp.Text = Empview.SelectedRows[0].Cells[0].Value.ToString();
            nameEmp.Text = Empview.SelectedRows[0].Cells[1].Value.ToString();
            dateEmp.Text = Prodview.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void CatCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServicesForm sellersForm = new ServicesForm();
            ServicesForm sel = serviceForm;
            ser.Show();
            this.Hide();
        }
    }
}
