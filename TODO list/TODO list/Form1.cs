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


            dataGridNotImportantUrgent.RowTemplate.Height = 34; //height of the rows in DataGridView
            this.dataGridNotImportantUrgent.Columns[0].Visible = false; //hide this column with id


            dataGridImportantNotUrgent.RowTemplate.Height = 34; //height of the rows in DataGridView
            this.dataGridImportantNotUrgent.Columns[0].Visible = false; //hide this column with id

            dataGridNotImportantNotUrgent.RowTemplate.Height = 34; //height of the rows in DataGridView
            this.dataGridNotImportantNotUrgent.Columns[0].Visible = false; //hide this column with id



            DatabaseLoad(); //Loading of Database 


        }


        //ADD
        private void btnRed_Click(object sender, EventArgs e)
        {
            AddFunction(dataGridImportantUrgent, "baseImportantUrgent");
        }

        private void btnGreen_Click(object sender, EventArgs e)
        {
            AddFunction(dataGridImportantNotUrgent, "baseImportantNotUrgent");
        }

        private void btnOrange_Click(object sender, EventArgs e)
        {
            AddFunction(dataGridNotImportantUrgent, "baseNotImportantUrgent");
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            AddFunction(dataGridNotImportantNotUrgent, "baseNotImportantNotUrgent");
        }


        //FUNCTION for Add Buttons
        private void AddFunction(DataGridView dataGridView, string databaseTable)
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
            string query = "INSERT INTO " + databaseTable + " (Title) VALUES (@title)"; //srting of query
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


                dataGridView.Rows.Clear();
                TableLoad(dataGridView, databaseTable);//Load DataBase



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

            // Check that the row exists
            if (dataGridImportantUrgent.SelectedRows.Count > 0)
            {

                // To do the same for each chosen row
                foreach (DataGridViewRow row in dataGridImportantUrgent.SelectedRows)
                {

                    // Recieve the data from the cell
                    string title = row.Cells["title"].Value.ToString();

                    // Create the connection with DataBase
                    string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb";
                    using (OleDbConnection dbConnection = new OleDbConnection(connectionString))
                    {
                        string query = "DELETE FROM baseImportantUrgent WHERE Title = @title"; // query of deletion
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
                                    dataGridImportantUrgent.Rows.Remove(row);
                                }
                                else
                                {
                                    MessageBox.Show("No data deleted", "Attention");
                                }

                                dataGridImportantUrgent.ClearSelection();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Mistake of the query: " + ex.Message, "Mistake!");
                            }
                        }
                    }
                }

                MessageBox.Show("Selected rows deleted", "Success");
            }
            else
            {
                MessageBox.Show("Select rows to delete", "Attention");
            }


        }




        //CHECKBOX

        private void dataGridImportantUrgent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CheckBoxCellClicked(e, dataGridImportantUrgent, "baseImportantUrgent");
        }


        private void dataGridImportantNotUrgent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CheckBoxCellClicked(e, dataGridImportantNotUrgent, "baseImportantNotUrgent");
        }


        private void dataGridNotImportantUrgent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CheckBoxCellClicked(e, dataGridNotImportantUrgent, "baseNotImportantUrgent");
        }


        private void dataGridNotImportantNotUrgent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CheckBoxCellClicked(e, dataGridNotImportantNotUrgent, "baseNotImportantNotUrgent");
        }


        //FUNCTION for Checkboxes
        private void CheckBoxCellClicked(DataGridViewCellEventArgs e, DataGridView dataGridView, string tableName)
        {
            if (e.ColumnIndex == 2 && e.RowIndex >= 0)
            {
                DataGridViewCheckBoxCell cell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;

                if (cell != null)
                {
                    bool isChecked = !(bool)cell.Value;

                    string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb";
                    using (OleDbConnection dbConnection = new OleDbConnection(connectionString))
                    {
                        string updateQuery = $"UPDATE {tableName} SET [Check] = (@isChecked) WHERE ID = (@id)";
                        using (OleDbCommand updateCommand = new OleDbCommand(updateQuery, dbConnection))
                        {
                            updateCommand.Parameters.AddWithValue("@isChecked", isChecked);
                            updateCommand.Parameters.AddWithValue("@id", dataGridView.Rows[e.RowIndex].Cells[0].Value);

                            try
                            {
                                dbConnection.Open();
                                int rowsAffected = updateCommand.ExecuteNonQuery();
                                dbConnection.Close();

                                if (rowsAffected == 1)
                                {
                                    dataGridView.Rows.Clear();
                                    TableLoad(dataGridView, tableName);
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









        //LOAD
        //Loading of Database
        private void DatabaseLoad()
        {

            TableLoad(dataGridImportantUrgent, "baseImportantUrgent");
            TableLoad(dataGridImportantNotUrgent, "baseImportantNotUrgent");
            TableLoad(dataGridNotImportantUrgent, "baseNotImportantUrgent");
            TableLoad(dataGridNotImportantNotUrgent, "baseNotImportantNotUrgent");

        }


        //FUNCTION: Loading of Database and sorting it by "Check" column
        private void TableLoad(DataGridView dataGridView, string databaseTable)
        {
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb";  //String for connection
            string query = "SELECT * FROM " + databaseTable + " ORDER BY IIF(Check = true, 1, 0)"; //string of query with sorting by "Check"

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


                            dataGridView.Rows.Add(dbReader["ID"], dbReader["Title"], dbReader["Check"]); //Add Data from Database in DataGridView



                            //changing the color for titles with checkbox = true, clearing the selection
                            if (dataGridView.Name == "dataGridImportantUrgent")
                            {
                                dataGridImportantUrgent.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridImportantUrgent_CellFormatting); //this function changes the color for titles with checkbox = true
                            }
                            else if (dataGridView.Name == "dataGridNotImportantUrgent")
                            {
                                dataGridNotImportantUrgent.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridNotImportantUrgent_CellFormatting); //this function changes the color for titles with checkbox = true
                            }
                            else if (dataGridView.Name == "dataGridImportantNotUrgent")
                            {
                                dataGridImportantNotUrgent.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridImportantNotUrgent_CellFormatting); //this function changes the color for titles with checkbox = true
                            }
                            else if (dataGridView.Name == "dataGridNotImportantNotUrgent")
                            {
                                dataGridNotImportantNotUrgent.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridNotImportantNotUrgent_CellFormatting); //this function changes the color for titles with checkbox = true
                            }

                            dataGridView.ClearSelection();


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




        //VERTICAL TEXT

        //Writes vertical text for label lbImportant "tärkeä" 
        private void lbImportant_Paint(object sender, PaintEventArgs e)
        {
            VerticalText(e, "tärkeää");
        }

        //Writes vertical text for label lbNotImportant "ei tärkeä"
        private void lbNotImportant_Paint(object sender, PaintEventArgs e)
        {
            VerticalText(e, "ei tärkeää");
        }


        //FUNCTION for vertical text
        private void VerticalText(PaintEventArgs e, string word)
        {
            Font myfont = new Font("Microsoft Sans Serif", 16);
            Brush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.DimGray);
            e.Graphics.TranslateTransform(30, 170);
            e.Graphics.RotateTransform(-90);
            e.Graphics.DrawString(word, myfont, myBrush, 0, 0);
        }




        //COLOR CHANGING FOR TITLES

        private void dataGridImportantUrgent_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ChangeTitleColor(e, dataGridImportantUrgent, CustomColor.ColorIU);
        }


        private void dataGridImportantNotUrgent_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ChangeTitleColor(e, dataGridImportantNotUrgent, CustomColor.ColorINU);
        }


        private void dataGridNotImportantUrgent_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ChangeTitleColor(e, dataGridNotImportantUrgent, CustomColor.ColorNIU);
        }


        private void dataGridNotImportantNotUrgent_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ChangeTitleColor(e, dataGridNotImportantNotUrgent, CustomColor.ColorNINU);
        }



        //FUNCTION for title color changing
        private void ChangeTitleColor(DataGridViewCellFormattingEventArgs e, DataGridView dataGridView, Color colorIfChecked)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                DataGridViewCheckBoxCell checkBoxCell = dataGridView.Rows[e.RowIndex].Cells[2] as DataGridViewCheckBoxCell;
                if (checkBoxCell != null && (bool)checkBoxCell.Value)
                {
                    e.CellStyle.ForeColor = colorIfChecked;
                }
                else
                {
                    e.CellStyle.ForeColor = dataGridView.DefaultCellStyle.ForeColor;
                }
            }
        }






        //SELECTION AN ENTIRE LINE

        private void dataGridImportantUrgent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LineSelection(e, dataGridImportantUrgent);
        }

        private void dataGridImportantNotUrgent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LineSelection(e, dataGridImportantNotUrgent);
        }

        private void dataGridNotImportantUrgent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LineSelection(e, dataGridNotImportantUrgent);
        }

        private void dataGridNotImportantNotUrgent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LineSelection(e, dataGridNotImportantNotUrgent);
        }



        //FUNCTIONS for selecting an entire line

        private void LineSelection(DataGridViewCellEventArgs e, DataGridView dataGridView)
        {
            if (e.RowIndex >= 0)
            {
                //Deselect the previous line
                if (dataGridView.CurrentRow != null)
                {
                    dataGridView.CurrentRow.Selected = false;
                }

                //Select the entry line clicked on
                dataGridView.Rows[e.RowIndex].Selected = true;
            }
        }


    }

}