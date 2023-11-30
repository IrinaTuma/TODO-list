using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;



namespace TODO_list
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            DatabaseLoad();
        }


        //ADD
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            //Check the quantity of the chosen strings
            if (dataGridImportantUrgent.SelectedRows.Count != 1)
            {
                MessageBox.Show("Choose only one string!", "Attention");
                return;
            }


            //Remember the chosen string
            int index = dataGridImportantUrgent.SelectedRows[0].Index;

            //Check the data in the table
            if (dataGridImportantUrgent.Rows[index].Cells[0].Value == null ||
                dataGridImportantUrgent.Rows[index].Cells[1].Value == null)
            {
                MessageBox.Show("Not all data was written", "Attention");
                return;
            }


            //Read the data
            string id = dataGridImportantUrgent.Rows[index].Cells[0].Value.ToString();
            string title = dataGridImportantUrgent.Rows[index].Cells[1].Value.ToString();

            //Create the connection
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb"; //String for connection
            OleDbConnection dbConnection = new OleDbConnection(connectionString); //Creating of connection

            //Running a database query
            dbConnection.Open(); //Open connection

            string query = "INSERT INTO base1 VALUES (" + id + ",'" + title + "')"; //srting of query
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection); //command

            //Create a query
            if (dbCommand.ExecuteNonQuery() != 1)
            {
                MessageBox.Show("Mistake of the query", "Mistake!");
            }
            else
            {
                MessageBox.Show("Data was added", "Attention"); //Delete the string from the form's table
            }

            //Close the connection with DataBase
            dbConnection.Close();

        }



        private void btnDelete_Click(object sender, EventArgs e)
        {

        }



        //LOAD
        //This function writes vertical text for label lbImportant "tärkeä" 
        private void lbImportant_Paint(object sender, PaintEventArgs e)
        {
            Font myfont = new Font("Microsoft Sans Serif", 16);
            Brush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            e.Graphics.TranslateTransform(30, 170);
            e.Graphics.RotateTransform(-90);
            e.Graphics.DrawString("tärkeää", myfont, myBrush, 0, 0);

        }


        //This function writes vertical text for label lbNotImportant "ei tärkeä"
        private void lbNotImportant_Paint(object sender, PaintEventArgs e)
        {
            Font myfont = new Font("Microsoft Sans Serif", 16);
            Brush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            e.Graphics.TranslateTransform(30, 170);
            e.Graphics.RotateTransform(-90);
            e.Graphics.DrawString("ei tärkeää", myfont, myBrush, 0, 0);
        }


        //Functio: Load Database
        private void DatabaseLoad()
        {
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb"; //String for connection
            OleDbConnection dbConnection = new OleDbConnection(connectionString); //Creating of connection

            //Running a database query
            dbConnection.Open(); //Open connection

            string query = "SELECT * FROM base1"; //srting of query
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection); //comand
            OleDbDataReader dbReader = dbCommand.ExecuteReader(); //Read data


            //Check data
            if (dbReader.HasRows == false)
            {
                MessageBox.Show("Data wasn,t found!", "Mistake");
            }
            else
            {
                //Write data to the form's table
                while (dbReader.Read())
                {
                    dataGridImportantUrgent.Rows.Add(dbReader["id"], dbReader["Title"]);
                }

            }

            //Close the connection
            dbReader.Close();
            dbConnection.Close();


        }



    }
}