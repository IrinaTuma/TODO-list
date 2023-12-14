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


            AddFunction("baseImportantUrgent", "dataGridImportantUrgent");
        }

        private void btnGreen_Click(object sender, EventArgs e)
        {
            AddFunction("baseImportantNotUrgent", "dataGridImportantNotUrgent");
        }

        private void btnOrange_Click(object sender, EventArgs e)
        {
            AddFunction("baseNotImportantUrgent", "dataGridNotImportantUrgent");
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            AddFunction("baseNotImportantNotUrgent", "dataGridNotImportantNotUrgent");
        }


        //FUNCTION for Add Buttons
        private void AddFunction(string databaseTable, string dataGridName)
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


                //Clean the DataGridView
                // Find the element DataGridView by its name
                //DataGridView dataGridView = Controls.Find(dataGridName, true).FirstOrDefault() as DataGridView;

                // If the element DataGridView was found, clean it
                /*
                if (dataGridView != null)
                {
                    if (dataGridView.InvokeRequired)
                    {
                        dataGridView.Invoke(new MethodInvoker(delegate { dataGridView.Rows.Clear(); }));
                    }
                    else
                    {
                        dataGridView.Rows.Clear();
                    }
                }
                */

                if (dataGridName == "dataGridImportantUrgent")
                {
                    dataGridImportantUrgent.Rows.Clear();
                    TableLoad("baseImportantUrgent", "dataGridImportantUrgent");//Load DataBase

                }
                else if (dataGridName == "dataGridImportantNotUrgent")
                {
                    dataGridImportantNotUrgent.Rows.Clear();
                    TableLoad("baseImportantNotUrgent", "dataGridImportantNotUrgent");//Load DataBase

                }
                else if (dataGridName == "dataGridNotImportantUrgent")
                {
                    dataGridNotImportantUrgent.Rows.Clear();
                    TableLoad("baseNotImportantUrgent", "dataGridNotImportantUrgent");//Load DataBase

                }
                else if (dataGridName == "dataGridNotImportantNotUrgent")
                {
                    dataGridNotImportantNotUrgent.Rows.Clear();
                    TableLoad("baseNotImportantNotUrgent", "dataGridNotImportantNotUrgent");//Load DataBase

                }


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

        //dataGridImportantUrgent
        private void dataGridImportantUrgent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
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
                        string updateQuery = "UPDATE baseImportantUrgent SET [Check] = (@isChecked) WHERE ID = (@id)"; // Замените CheckBoxColumn на ваше поле с CheckBox
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
            */
        }

        //dataGridImportantNotUrgent
        private void dataGridImportantNotUrgent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            if (e.ColumnIndex == dataGridImportantNotUrgent.Columns["checkDone"].Index && e.RowIndex >= 0)
            {
                DataGridViewCheckBoxCell cell = dataGridImportantNotUrgent.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;



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
                        string updateQuery = "UPDATE baseImportantNotUrgent SET [Check] = (@isChecked) WHERE ID = (@id)"; // Замените CheckBoxColumn на ваше поле с CheckBox
                        using (OleDbCommand updateCommand = new OleDbCommand(updateQuery, dbConnection))
                        {
                            updateCommand.Parameters.AddWithValue("@isChecked", isChecked);
                            updateCommand.Parameters.AddWithValue("@id", dataGridImportantNotUrgent.Rows[e.RowIndex].Cells["ID"].Value); // Замените "ID" на ваше поле с ID

                            try
                            {
                                dbConnection.Open();

                                Console.WriteLine(updateCommand.ExecuteScalar());

                                int rowsAffected = updateCommand.ExecuteNonQuery();

                                dbConnection.Close();

                                if (rowsAffected == 1)
                                {
                                    dataGridImportantNotUrgent.Rows.Clear(); //Clean the dataGridImportantNotUrgent
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
            */
        }

        //dataGridNotImportantUrgent
        private void dataGridNotImportantUrgent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            if (e.ColumnIndex == dataGridNotImportantUrgent.Columns["checkDone"].Index && e.RowIndex >= 0)
            {
                DataGridViewCheckBoxCell cell = dataGridNotImportantUrgent.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;



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
                        string updateQuery = "UPDATE baseNotImportantUrgent SET [Check] = (@isChecked) WHERE ID = (@id)"; // Замените CheckBoxColumn на ваше поле с CheckBox
                        using (OleDbCommand updateCommand = new OleDbCommand(updateQuery, dbConnection))
                        {
                            updateCommand.Parameters.AddWithValue("@isChecked", isChecked);
                            updateCommand.Parameters.AddWithValue("@id", dataGridNotImportantUrgent.Rows[e.RowIndex].Cells["ID"].Value); // Замените "ID" на ваше поле с ID

                            try
                            {
                                dbConnection.Open();

                                Console.WriteLine(updateCommand.ExecuteScalar());

                                int rowsAffected = updateCommand.ExecuteNonQuery();

                                dbConnection.Close();

                                if (rowsAffected == 1)
                                {
                                    dataGridNotImportantUrgent.Rows.Clear(); //Clean the dataGridNotImportantUrgent
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
            */
        }

        //dataGridNotImportantNotUrgent
        private void dataGridNotImportantNotUrgent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            if (e.ColumnIndex == dataGridNotImportantNotUrgent.Columns["checkDone"].Index && e.RowIndex >= 0)
            {
                DataGridViewCheckBoxCell cell = dataGridNotImportantNotUrgent.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;



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
                        string updateQuery = "UPDATE baseNotImportantNotUrgent SET [Check] = (@isChecked) WHERE ID = (@id)"; // Замените CheckBoxColumn на ваше поле с CheckBox
                        using (OleDbCommand updateCommand = new OleDbCommand(updateQuery, dbConnection))
                        {
                            updateCommand.Parameters.AddWithValue("@isChecked", isChecked);
                            updateCommand.Parameters.AddWithValue("@id", dataGridNotImportantNotUrgent.Rows[e.RowIndex].Cells["ID"].Value); // Замените "ID" на ваше поле с ID

                            try
                            {
                                dbConnection.Open();

                                Console.WriteLine(updateCommand.ExecuteScalar());

                                int rowsAffected = updateCommand.ExecuteNonQuery();

                                dbConnection.Close();

                                if (rowsAffected == 1)
                                {
                                    dataGridNotImportantNotUrgent.Rows.Clear(); //Clean the dataGridNotImportantNotUrgent
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
            */
        }



        //LOAD
        //Loading of Database
        private void DatabaseLoad()
        {
            TableLoad("baseImportantUrgent", "dataGridImportantUrgent");
            TableLoad("baseImportantNotUrgent", "dataGridImportantNotUrgent");
            TableLoad("baseNotImportantUrgent", "dataGridNotImportantUrgent");
            TableLoad("baseNotImportantNotUrgent", "dataGridNotImportantNotUrgent");
        }


        //FUNCTION: Loading of Database and sorting it by "Check" column
        private void TableLoad(string databaseTable, string dataGridName)
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


                            //adding the rows in Data Grid, changing the color for titles with checkbox = true, clearing the selection
                            if (dataGridName == "dataGridImportantUrgent")
                            {

                                dataGridImportantUrgent.Rows.Add(dbReader["ID"], dbReader["Title"], dbReader["Check"]); //Add Data from Database in DataGridView
                                //dataGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridImportantUrgent_CellFormatting);
                                dataGridImportantUrgent.ClearSelection();
                            }
                            else if (dataGridName == "dataGridNotImportantUrgent")
                            {

                                dataGridNotImportantUrgent.Rows.Add(dbReader["ID"], dbReader["Title"], dbReader["Check"]); //Add Data from Database in DataGridView
                                //dataGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridNotImportantUrgent_CellFormatting);
                                dataGridNotImportantUrgent.ClearSelection();
                            }
                            else if (dataGridName == "dataGridImportantNotUrgent")
                            {

                                dataGridImportantNotUrgent.Rows.Add(dbReader["ID"], dbReader["Title"], dbReader["Check"]); //Add Data from Database in DataGridView
                                //dataGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridImportantNotUrgent_CellFormatting);
                                dataGridImportantNotUrgent.ClearSelection();
                            }
                            else if (dataGridName == "dataGridNotImportantNotUrgent")
                            {

                                dataGridNotImportantNotUrgent.Rows.Add(dbReader["ID"], dbReader["Title"], dbReader["Check"]); //Add Data from Database in DataGridView
                                //dataGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridNotImportantNotUrgent_CellFormatting);
                                dataGridNotImportantNotUrgent.ClearSelection();
                            }


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







        //VERTICAL TEXT FUNCTION
        private void VerticalText(PaintEventArgs e, string word)
        {
            Font myfont = new Font("Microsoft Sans Serif", 16);
            Brush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.DimGray);
            e.Graphics.TranslateTransform(30, 170);
            e.Graphics.RotateTransform(-90);
            e.Graphics.DrawString(word, myfont, myBrush, 0, 0);
        }


        //Writes vertical text for label lbImportant "tärkeä" 
        private void lbImportant_Paint(object sender, PaintEventArgs e)
        {
            string word = "tärkeää";
            VerticalText(e, word);

        }

        //Writes vertical text for label lbNotImportant "ei tärkeä"
        private void lbNotImportant_Paint(object sender, PaintEventArgs e)
        {
            string word = "ei tärkeää";
            VerticalText(e, word);
        }




        //FUNCTIONS: COLOR CHANGING FOR TITLES
        //Color changing for titles, if checkbox = true (dataGridImportantUrgent)
        private void dataGridImportantUrgent_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            /*
            //Color for Title
            if (e.ColumnIndex == dataGridImportantUrgent.Columns["Title"].Index && e.RowIndex >= 0)
            {
                // Check the value of CheckBox in the row
                DataGridViewCheckBoxCell checkBoxCell = dataGridImportantUrgent.Rows[e.RowIndex].Cells["checkDone"] as DataGridViewCheckBoxCell;
                if (checkBoxCell != null && (bool)checkBoxCell.Value)
                {
                    // If CheckBox == true, change the color for column Title and for CheckBox
                    e.CellStyle.ForeColor = CustomColor.ColorIU;

                }
                else
                {
                    // In other way use default color
                    e.CellStyle.ForeColor = dataGridImportantUrgent.DefaultCellStyle.ForeColor;
                }

            }
            */
        }

        //Color changing for titles, if checkbox = true (dataGridNotImportantUrgent)
        private void dataGridNotImportantUrgent_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            /*
            //Color for Title
            if (e.ColumnIndex == dataGridNotImportantUrgent.Columns["Title"].Index && e.RowIndex >= 0)
            {
                // Check the value of CheckBox in the row
                DataGridViewCheckBoxCell checkBoxCell = dataGridNotImportantUrgent.Rows[e.RowIndex].Cells["checkDone"] as DataGridViewCheckBoxCell;
                if (checkBoxCell != null && (bool)checkBoxCell.Value)
                {
                    // If CheckBox == true, change the color for column Title and for CheckBox
                    e.CellStyle.ForeColor = CustomColor.ColorNIU;

                }
                else
                {
                    // In other way use default color
                    e.CellStyle.ForeColor = dataGridNotImportantUrgent.DefaultCellStyle.ForeColor;
                }

            }
            */
        }

        //Color changing for titles, if checkbox = true (dataGridImportantNotUrgent)
        private void dataGridImportantNotUrgent_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            /*
            //Color for Title
            if (e.ColumnIndex == dataGridNotImportantUrgent.Columns["Title"].Index && e.RowIndex >= 0)
            {
                // Check the value of CheckBox in the row
                DataGridViewCheckBoxCell checkBoxCell = dataGridNotImportantUrgent.Rows[e.RowIndex].Cells["checkDone"] as DataGridViewCheckBoxCell;
                if (checkBoxCell != null && (bool)checkBoxCell.Value)
                {
                    // If CheckBox == true, change the color for column Title and for CheckBox
                    e.CellStyle.ForeColor = CustomColor.ColorNIU;

                }
                else
                {
                    // In other way use default color
                    e.CellStyle.ForeColor = dataGridNotImportantUrgent.DefaultCellStyle.ForeColor;
                }

            }
            */
        }

        //Color changing for titles, if checkbox = true (dataGridNotImportantNotUrgent)
        private void dataGridNotImportantNotUrgent_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            /*
            //Color for Title
            if (e.ColumnIndex == dataGridNotImportantNotUrgent.Columns["Title"].Index && e.RowIndex >= 0)
            {
                // Check the value of CheckBox in the row
                DataGridViewCheckBoxCell checkBoxCell = dataGridNotImportantNotUrgent.Rows[e.RowIndex].Cells["checkDone"] as DataGridViewCheckBoxCell;
                if (checkBoxCell != null && (bool)checkBoxCell.Value)
                {
                    // If CheckBox == true, change the color for column Title and for CheckBox
                    e.CellStyle.ForeColor = CustomColor.ColorNINU;

                }
                else
                {
                    // In other way use default color
                    e.CellStyle.ForeColor = dataGridNotImportantNotUrgent.DefaultCellStyle.ForeColor;
                }

            }
            */
        }





        //FUNCTIONS: Selecting an entire line
        private void dataGridImportantUrgent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Deselect the previous line
                if (dataGridImportantUrgent.CurrentRow != null)
                {
                    dataGridImportantUrgent.CurrentRow.Selected = false;
                }

                //Select the entry line clicked on
                dataGridImportantUrgent.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dataGridImportantNotUrgent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Deselect the previous line
                if (dataGridImportantNotUrgent.CurrentRow != null)
                {
                    dataGridImportantNotUrgent.CurrentRow.Selected = false;
                }

                //Select the entry line clicked on
                dataGridImportantNotUrgent.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dataGridNotImportantUrgent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Deselect the previous line
                if (dataGridNotImportantUrgent.CurrentRow != null)
                {
                    dataGridNotImportantUrgent.CurrentRow.Selected = false;
                }

                //Select the entry line clicked on
                dataGridNotImportantUrgent.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dataGridNotImportantNotUrgent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Deselect the previous line
                if (dataGridNotImportantNotUrgent.CurrentRow != null)
                {
                    dataGridNotImportantNotUrgent.CurrentRow.Selected = false;
                }

                //Select the entry line clicked on
                dataGridNotImportantNotUrgent.Rows[e.RowIndex].Selected = true;
            }
        }
    }

}