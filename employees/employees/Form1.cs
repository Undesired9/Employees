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

namespace employees
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Employees;Integrated Security=True");
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            int empid = int.Parse(textBox1.Text);
            string empname = textBox2.Text;
            string city = textBox3.Text;
            string contact = textBox5.Text;
            string Gender = "";
            double age = double.Parse(textBox4.Text);
            if (radioButton1.Checked == true)
            { Gender = "Male"; }
            else { Gender = "Female"; }
            con.Open();
            SqlCommand c = new SqlCommand("exec UpdateEmp_SA '" + empid + "','" + empname + "','" + city + "','" + age + "','" + Gender + "','" + contact + "'", con);
            
     c.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully inserted..."+textBox1.Text);
            GetEmplist();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }
        void GetEmplist()
        {
            SqlCommand c = new SqlCommand("exec ListEmp_SA",con);
            SqlDataAdapter sd = new SqlDataAdapter(c);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetEmplist();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            int empid = int.Parse(textBox1.Text);
            string empname = textBox2.Text;
            string city = textBox3.Text;
            string contact = textBox5.Text;
            string Gender = "";
            double age = double.Parse(textBox4.Text);
            if (radioButton1.Checked == true)
            { Gender = "Male"; }
            else { Gender = "Female"; }
            con.Open();
            SqlCommand c = new SqlCommand("exec UpdateEmp_SA '" + empid + "','" + empname + "','" + city + "','" + age + "','" + Gender + "','" + contact + "'", con);
            
                c.ExecuteNonQuery();
            
            con.Close();
            MessageBox.Show("Successfully Updated..."+textBox1.Text);
            GetEmplist();

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure you want to delete?", "Delete "+textBox1.Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int empid = int.Parse(textBox1.Text);

                con.Open();
                SqlCommand c = new SqlCommand("exec DeleteEmp_SA'" + empid + "'", con);

                c.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Deleted..."+textBox1.Text);
                GetEmplist();

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int empid = int.Parse(textBox1.Text);

            SqlCommand c = new SqlCommand("exec LoadEmp_SA'" + empid + "'", con);
            SqlDataAdapter sd = new SqlDataAdapter(c);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }
    }
}
