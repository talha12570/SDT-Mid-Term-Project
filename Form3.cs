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

namespace Library_Management_System
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            String strcon = @"Data Source=.\sqlexpress;Initial Catalog=LBMS;Integrated Security=true;";
            SqlConnection myDbCon = new SqlConnection(strcon);
            myDbCon.Open();
            string select = "Select * from Books;";
            SqlDataAdapter da = new SqlDataAdapter(select, myDbCon);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            myDbCon.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //update book
            string selectedISBN = dataGridView1.SelectedRows[0].Cells["ISBN"].Value.ToString();
            Form4 updateBook=new Form4(selectedISBN);
            updateBook.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //delete book
            String strcon = @"Data Source=.\sqlexpress;Initial Catalog=LBMS;Integrated Security=true;";
            SqlConnection myDbCon = new SqlConnection(strcon);
            myDbCon.Open();
            string isbn = dataGridView1.SelectedRows[0].Cells["ISBN"].Value.ToString();
            string delete = "DELETE FROM Books WHERE ISBN = @ISBN";
            SqlCommand cmd = new SqlCommand(delete, myDbCon);
            cmd.Parameters.AddWithValue("@ISBN", isbn);
            cmd.ExecuteNonQuery();
            myDbCon.Close();
            MessageBox.Show("Book deleted successfully!");
            Form3_Load(sender, e);
        }
    }
}
