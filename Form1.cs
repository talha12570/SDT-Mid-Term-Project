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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDataIntoGridView();
            /*String strcon = @"Data Source=.\sqlexpress;Initial Catalog=LBMS;Integrated Security=true;";
            SqlConnection myDbCon = new SqlConnection(strcon);
            myDbCon.Open();
            DataTable table = new DataTable();
            table.Columns.Add("ISBN", typeof(string));
            table.Columns.Add("BookName", typeof(string));
            table.Columns.Add("Author", typeof(string));
            table.Columns.Add("StudentID", typeof(int));
            table.Columns.Add("StudentName", typeof(string));
            table.Columns.Add("IssueDate", typeof(DateTime));
            table.Columns.Add("ReturnDate", typeof(DateTime));
            dataGridView1.DataSource = table;*/
            
        }
        private void LoadDataIntoGridView()
        {
            String strcon = @"Data Source=.\sqlexpress;Initial Catalog=LBMS;Integrated Security=true;";
            SqlConnection myDbCon = new SqlConnection(strcon);
            myDbCon.Open();

            string select = @"SELECT BI.IssueId, B.ISBN, B.BookName, B.Author, 
                             BI.StudentId, BI.StudentName, BI.IssueDate, BI.ReturnDate
                      FROM BookIssues BI
                      JOIN Books B ON BI.ISBN = B.ISBN";
            SqlDataAdapter da = new SqlDataAdapter(select, myDbCon);

            DataTable table = new DataTable();
            da.Fill(table);

            dataGridView1.DataSource = table;
            myDbCon.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            //ReturnDate Input
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ADD BOOK Buttton
            Form2 addBookForm = new Form2();

            
            addBookForm.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //ISBN Input
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //BookName Input
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //Author Input
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //StudentID Input
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            //Student Name Input
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //Issuedate input
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 ViewBookform = new Form3();


            ViewBookform.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String strcon = @"Data Source=.\sqlexpress;Initial Catalog=LBMS;Integrated Security=true;";
            SqlConnection myDbCon = new SqlConnection(strcon);
            myDbCon.Open();
            string isbn = textBox1.Text;
            
            int studentId = Convert.ToInt32(textBox4.Text);
            string studentName = textBox5.Text;
            DateTime issue = Convert.ToDateTime(dateTimePicker1.Text);
            DateTime Return = Convert.ToDateTime(dateTimePicker2.Text);

            string insert = "INSERT INTO BookIssues (ISBN, StudentId, StudentName, IssueDate, ReturnDate) " +
                "VALUES ('" + isbn + "', " + studentId + ", '" + studentName + "', '" + issue.ToString("yyyy-MM-dd") + "', '" + Return.ToString("yyyy-MM-dd") + "')";
            SqlCommand cmd = new SqlCommand(insert, myDbCon);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Book issued successfully!");
            textBox1.Clear();
            
            textBox4.Clear();
            textBox5.Clear();

            LoadDataIntoGridView();
            myDbCon.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            String strcon = @"Data Source=.\sqlexpress;Initial Catalog=LBMS;Integrated Security=true;";
            SqlConnection myDbCon = new SqlConnection(strcon);
            myDbCon.Open();
            int issueId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["IssueId"].Value);
            string delete = "DELETE FROM BookIssues WHERE IssueId = @IssueId";
            SqlCommand cmd = new SqlCommand(delete, myDbCon);
            cmd.Parameters.AddWithValue("@IssueId", issueId);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Book returned successfully!");
            LoadDataIntoGridView();
            myDbCon.Close();
        }
    }
}
