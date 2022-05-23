﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace coursework
{
    /// <summary>
    /// Interaction logic for Page5.xaml
    /// </summary>
    public partial class Page5 : Page
    {
        string ConnectionString = null;
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;
        public Page5()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            InitializeComponent();
            //Applicant_ZNO();
            CB.SelectedIndex = 0;

        }
        private void GetandShowData(string SQLQuery, DataGrid dataGrid)
        {
            connection = new SqlConnection(ConnectionString);
            connection.Open();

            command = new SqlCommand(SQLQuery, connection);
            adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);


            dataGrid.ItemsSource = dt.DefaultView;
            connection.Close();
        }
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
        //private void Applicant_ZNO()
        //{
        //    String query = "SELECT " +
        //        "Applicant.ApplicantID as [Номер]," +
        //                     "DateofBirth as [DateofBirth]," +
        //                     "PhoneNumber as [PhoneNumber]," +
        //                      "Adress as [Adress]," +
        //                      "Applicant.SchoolID as [SchoolID]," +
        //                      "FullName as [FullName], " +
        //                      "dbo.ApplicantTake.SubjectID," +
        //                      "dbo.ApplicantTake.Year," +
        //                      "dbo.ApplicantTake.Mark," +
        //                      "dbo.Subject.Name as [SN] " +
        //                      "From dbo.Applicant " +
        //                      "LEFT OUTER JOIN dbo.ApplicantTake " +
        //                      "ON dbo.Applicant.ApplicantID =dbo.ApplicantTake.ApplicantID " +
        //                      "LEFT OUTER JOIN dbo.Subject " +
        //                      "ON dbo.ApplicantTake.SubjectID = dbo.Subject.SubjectID ";


        //    try
        //    {
        //        connection = new SqlConnection(ConnectionString);
        //        connection.Open();

        //        command = new SqlCommand(query, connection);
        //        adapter = new SqlDataAdapter(command);
        //        DataTable dt = new DataTable();
        //        adapter.Fill(dt);

        //        var temp = cropDate(dt, 1);

        //        dt1.ItemsSource = temp.DefaultView;
        //        connection.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message);
        //    }
        //}

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String selected = CB.SelectedItem.ToString().Substring(CB.SelectedItem.ToString().IndexOf(" ") + 1);
            if (selected == "Все")
                selected = "";
            String query = "SELECT " +
                            "Applicant.ApplicantID as [Номер]," +
                                         "DateofBirth as [DateofBirth]," +
                                         "PhoneNumber as [PhoneNumber]," +
                                          "Adress as [Adress]," +
                                          "Applicant.SchoolID as [SchoolID]," +
                                          "FullName as [FullName], " +
                                          "dbo.ApplicantTake.SubjectID," +
                                          "dbo.ApplicantTake.Year," +
                                          "dbo.ApplicantTake.Mark," +
                                          "dbo.Subject.Name as [SN] " +
                                          "From dbo.Applicant " +
                                          "LEFT OUTER JOIN dbo.ApplicantTake " +
                                          "ON dbo.Applicant.ApplicantID =dbo.ApplicantTake.ApplicantID " +
                                          "LEFT OUTER JOIN dbo.Subject " +
                                          "ON dbo.ApplicantTake.SubjectID = dbo.Subject.SubjectID " +
                                          $"WHERE Subject.Name LIKE '%{selected}%';";
            try
            {
                connection = new SqlConnection(ConnectionString);
                connection.Open();

                var command = new SqlCommand(query, connection);
                var adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                var temp = cropDate(dt, 1);

                dt1.ItemsSource = temp.DefaultView;
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
