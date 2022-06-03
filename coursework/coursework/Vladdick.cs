using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace coursework
{
    internal class Vladdick
    {
        public static DataTable cropDate(DataTable Table, int dateColumn)
        {
            DataTable dtCloned = Table.Clone();
            dtCloned.Columns[dateColumn].DataType = typeof(string);
            foreach (DataRow row in Table.Rows)
            {
                DataRow temp = dtCloned.NewRow();
                for (int i = 0; i < Table.Columns.Count; i++)
                {
                    if (i == dateColumn)
                        temp[i] = row[dateColumn].ToString().Split(' ')[0];
                    else
                        temp[i] = row[i];
                }
                dtCloned.Rows.Add(temp);
            }
            return dtCloned;
        }
        public static DataTable GetDataTable(string q)
        {
            DataTable dt = new DataTable();           
            try
            {
                var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                connection.Open();

                var command = new SqlCommand(q, connection);
                var adapter = new SqlDataAdapter(command);
                
                adapter.Fill(dt);

                
                connection.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }
        public static void Execute(string query)
        {
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            connection.Open();
            new SqlCommand(query, connection).ExecuteNonQuery();
            connection.Close();
        }
        
    }
}
