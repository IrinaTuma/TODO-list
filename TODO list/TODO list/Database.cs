using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TODO_list
{
    class Database
    {
        /*protected OleDbConnection conn = null;

        public Database(string connectionString)
        {
            try
            {
                conn = new OleDbConnection(connectionString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //region Protected Methods
        protected void Connect()
        {

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

        }

        protected void Disconnect()
        {
            conn.Close();
        }

        protected void ExecuteSimpleQuery(OleDbCommand command)
        {
            lock (conn)
            {
                Connect();
                command.Connection = conn;
                try
                {
                    command.ExecuteNonQuery();
                }
                finally
                {
                    Disconnect();
                }

            }

        }

        protected int ExecuteScalarIntQuery(OleDbCommand command)
        {
            int ret = -1;
            lock (conn)
            {
                Connect();
                command.Connection = conn;
                try
                {
                    ret = (int)command.ExecuteScalar();
                }
                finally
                {
                    Disconnect() ;
                }
            }
            return ret;
        }





        protected DataSet GetMultipleQuery(OleDbCommand command)
        {
            DataSet dataset = new DataSet();
            lock (conn)
            {
                Connect();
                command.Connection = conn;

                try
                {
                    OleDbDataAdapter adapter = new OleDbDataAdapter();
                    adapter.SelectCommand = command;
                    adapter.Fill(dataset);
                }
                catch (TypedDataSetGeneratorException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (DataException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Disconnect();
                }
            }
            return dataset;
        }
        */

    }
}
