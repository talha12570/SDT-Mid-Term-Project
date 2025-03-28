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
    public partial class Form4 : Form
    {
        private string isbn;
        public Form4(string selectedISBN)
        {
            InitializeComponent();
            isbn = selectedISBN;
            
        }

        private void Form4_Load(object sender, EventArgs e)
        {
           String strcon = @"Data Source=.\sqlexpress;Initial Catalog=LBMS;Integrated Security=true;";
            SqlConnection myDbCon = new SqlConnection(strcon);
            myDbCon.Open();

            string select = "SELECT ISBN, BookName, Author FROM Books WHERE ISBN = @ISBN";
            SqlCommand cmd = new SqlCommand(select, myDbCon);
            cmd.Parameters.AddWithValue("@ISBN", isbn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                textBox1.Text = reader["ISBN"].ToString();
                textBox2.Text = reader["BookName"].ToString();
                textBox3.Text = reader["Author"].ToString();
            }
            reader.Close();
            myDbCon.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //ISBN
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //Booname
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //Author
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SaveChanges
            String strcon = @"Data Source=.\sqlexpress;Initial Catalog=LBMS;Integrated Security=true;";
            SqlConnection myDbCon = new SqlConnection(strcon);
            myDbCon.Open();
            string sqlUpdate = @"UPDATE Books 
                     SET BookName = '" + textBox2.Text +
                               "', Author = '" + textBox3.Text +
                               "' WHERE ISBN = '" + textBox1.Text + "'";

            SqlCommand cmd = new SqlCommand(sqlUpdate, myDbCon);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Book data has been updated successfully!");

            Form3 viewBooksForm = new Form3();
            viewBooksForm.Show();
            this.Close();
        }
    }
}
