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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //ISBN
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //BOOKNAME
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
         //Author 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Add button
            String strcon = @"Data Source=.\sqlexpress;Initial Catalog=LBMS;Integrated Security=true;";
            SqlConnection myDbCon = new SqlConnection(strcon);
            myDbCon.Open();
            string isbn = textBox1.Text;
            string BookName = textBox2.Text;
            string Author = textBox3.Text;

            string insert = "INSERT INTO Books (ISBN, BookName, Author) VALUES ('" + isbn + "', '" + BookName + "', '" + Author + "')";
            SqlCommand cmd = new SqlCommand(insert, myDbCon);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Book added successfully!");

            // Clear textboxes
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

            myDbCon.Close();
   
        }
    }
}
