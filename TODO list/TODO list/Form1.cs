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
using System.Linq.Expressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection;

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

            dataGridImportantUrgent.RowTemplate.Height = 34; //height of the rows in DataGridView
            this.dataGridImportantUrgent.Columns[0].Visible = false; //hide this column with id


            DatabaseLoad(); //Loading of Database 


        }


        //ADD
        private void btnAdd_Click_1(object sender, EventArgs e)
        {

            // Set the max length for TextBox
            textBoxTitle.MaxLength = 55;

            // Check that Text Box is not empty and not longer that 50 symbols
            if (string.IsNullOrWhiteSpace(textBoxTitle.Text) || textBoxTitle.Text.Length > textBoxTitle.MaxLength)
            {
                MessageBox.Show("Enter data in the TextBox up to 55 characters!", "Attention");
                return;
            }


            //Read the data
            string title = textBoxTitle.Text;

            //Create the connection
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb"; //String for connection
            OleDbConnection dbConnection = new OleDbConnection(connectionString); //Creating of connection

            //Running a database query
            string query = "INSERT INTO base1 (Title) VALUES (@title)"; //srting of query
            //string query = "INSERT INTO base1 VALUES (" + id + ",'" + title + "')"; //string of query
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection); //command
            dbCommand.Parameters.AddWithValue("@title", title);



            //Create a query
            try
            {
                dbConnection.Open(); //Open connection
                int rowsAffected = dbCommand.ExecuteNonQuery();


                //Close the connection with DataBase
                dbConnection.Close();

                //Clean the text box
                textBoxTitle.Clear();

                dataGridImportantUrgent.Rows.Clear(); //Clean the dataGridImportantUrgent
                DatabaseLoad();//Load DataBase
                MessageBox.Show("Data was added", "Attention");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mistake of the query: " + ex.Message, "Mistake!");
            }

        }



        //DELETE
        private void btnDelete_Click(object sender, EventArgs e)
        {

            // Check that the cell exists
            if (dataGridImportantUrgent.CurrentCell != null &&
                dataGridImportantUrgent.CurrentCell.Value != null)
            {
                // Recieve the data fron the cell
                string title = dataGridImportantUrgent.CurrentCell.Value.ToString();

                // Create the connection with DataBase
                string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb";
                using (OleDbConnection dbConnection = new OleDbConnection(connectionString))
                {
                    string query = "DELETE FROM base1 WHERE Title = @title";
                    using (OleDbCommand dbCommand = new OleDbCommand(query, dbConnection))
                    {
                        dbCommand.Parameters.AddWithValue("@title", title);

                        try
                        {
                            dbConnection.Open();
                            int rowsAffected = dbCommand.ExecuteNonQuery();
                            dbConnection.Close();

                            if (rowsAffected > 0)
                            {


                                // Delete the string from DataGridView
                                dataGridImportantUrgent.Rows.RemoveAt(dataGridImportantUrgent.CurrentCell.RowIndex);
                                MessageBox.Show("Data was deleted", "Attention");
                            }
                            else
                            {
                                MessageBox.Show("No data deleted", "Attention");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Mistake of the query: " + ex.Message, "Mistake!");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No cell selected", "Attention");
            }


        }


        //CHECKBOX
        private void dataGridImportantUrgent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridImportantUrgent.Columns["checkDone"].Index && e.RowIndex >= 0)
            {
                DataGridViewCheckBoxCell cell = dataGridImportantUrgent.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;

                // Change CheckBox
                if (cell != null)
                {
                    bool isChecked = !(bool)cell.Value;

                    // logic, when CheckBox changes
                    // isChecked contains new state of CheckBox (true - chosen, false - not chosen)

                    // Update value CheckBox in Database
                    string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb";
                    using (OleDbConnection dbConnection = new OleDbConnection(connectionString))
                    {
                        string updateQuery = "UPDATE base1 SET [Check] = (@isChecked) WHERE ID = (@id)"; // Замените CheckBoxColumn на ваше поле с CheckBox
                        using (OleDbCommand updateCommand = new OleDbCommand(updateQuery, dbConnection))
                        {
                            updateCommand.Parameters.AddWithValue("@isChecked", isChecked);
                            updateCommand.Parameters.AddWithValue("@id", dataGridImportantUrgent.Rows[e.RowIndex].Cells["ID"].Value); // Замените "ID" на ваше поле с ID

                            try
                            {
                                dbConnection.Open();

                                Console.WriteLine(updateCommand.ExecuteScalar());

                                int rowsAffected = updateCommand.ExecuteNonQuery();




                                dbConnection.Close();

                                if (rowsAffected == 1)
                                {
                                    dataGridImportantUrgent.Rows.Clear(); //Clean the dataGridImportantUrgent
                                    DatabaseLoad();
                                    MessageBox.Show("Database updated!", "Success");
                                }
                                else
                                {
                                    MessageBox.Show("No rows updated!", "Error");
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Database update error: " + ex.Message, "Error");
                            }
                        }
                    }
                }
            }
        }


        //VERTICAL TEXT FUNCTION
        private void VerticalText(PaintEventArgs e)
        {
            Font myfont = new Font("Microsoft Sans Serif", 16);
            Brush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            e.Graphics.TranslateTransform(30, 170);
            e.Graphics.RotateTransform(-90);
            e.Graphics.DrawString("tärkeää", myfont, myBrush, 0, 0);
        }


        //FUNCTION: writes vertical text for label lbImportant "tärkeä" 
        private void lbImportant_Paint(object sender, PaintEventArgs e)
        {
            VerticalText(e);

        }

        //FUNCTION: writes vertical text for label lbNotImportant "ei tärkeä"
        private void lbNotImportant_Paint(object sender, PaintEventArgs e)
        {
            VerticalText(e);
        }



        //LOAD
        //FUNCTION: Loading of Database and sorting it by "Check" column
        private void DatabaseLoad()
        {
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb";  //String for connection
            string query = "SELECT * FROM base1 ORDER BY IIF(Check = true, 1, 0)"; //string of query

            using (OleDbConnection dbConnection = new OleDbConnection(connectionString))
            {
                OleDbCommand dbCommand = new OleDbCommand(query, dbConnection); //command

                try
                {
                    dbConnection.Open(); //Open connection
                    OleDbDataReader dbReader = dbCommand.ExecuteReader(); //Read data

                    if (dbReader.HasRows)
                    {
                        while (dbReader.Read()) //while there are still rows to add
                        {
                            dataGridImportantUrgent.Rows.Add(dbReader["ID"], dbReader["Title"], dbReader["Check"]); //Add Data from Database in DataGridView
                            dataGridImportantUrgent.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridImportantUrgent_CellFormatting); //this function shanges the color for titles with checkbox = true

                        }
                    }
                    else
                    {
                        MessageBox.Show("Data wasn't found!", "Mistake");
                    }

                    //Close the connection
                    dbReader.Close();
                    dbConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Mistake of the query: " + ex.Message, "Mistake!");
                }

            }
        }



        //Color changing for titles, if checkbox = true
        private void dataGridImportantUrgent_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            //Color for Title
            if (e.ColumnIndex == dataGridImportantUrgent.Columns["Title"].Index && e.RowIndex >= 0)
            {
                // Check the value of CheckBox in the row
                DataGridViewCheckBoxCell checkBoxCell = dataGridImportantUrgent.Rows[e.RowIndex].Cells["checkDone"] as DataGridViewCheckBoxCell;
                if (checkBoxCell != null && (bool)checkBoxCell.Value)
                {
                    // Если CheckBox == true, change the color for column Title and for CheckBox
                    e.CellStyle.ForeColor = CustomColor.Color1;

                }
                else
                {
                    // In other way use default color
                    e.CellStyle.ForeColor = dataGridImportantUrgent.DefaultCellStyle.ForeColor;
                }

            }

        }





    }
}