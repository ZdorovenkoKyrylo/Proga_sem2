using System;
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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
     
        public Page1()
        {
            InitializeComponent();
            SortInfo();
        }              
        private void SortInfo()
        {
            String Q = "SELECT " +
                "ApplicantID as [Номер]," +
                "FullName as [FullName]," +
                             "DateofBirth as [DateofBirth]," +
                             "PhoneNumber as [PhoneNumber]," +
                              "Adress as [Adress]," +
                              "City.Name as [CityName]," +
                              "School.Name as [SchoolName] " +                              
                              "From dbo.Applicant " +
                              "Left OUTER JOIN School " +
                              "ON Applicant.SchoolID = School.SchoolID " +
                              "Left OUTER JOIN City " +
                              "ON Applicant.CityID = City.CityID "+
                              "ORDER BY FullName";
            dt_sort.ItemsSource = Vladdick.cropDate(Vladdick.GetDataTable(Q),2).DefaultView;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var nm = (string)((DataRowView)dt_sort.SelectedItem)["FullName"];
            String Q = "DELETE " +
                        "From dbo.Applicant " +                    
                        $"WHERE FullName = '{nm}'";
            Vladdick.Execute(Q);
            SortInfo();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            InsertInto ins = new InsertInto();
            ins.Show();
        }
    }
}
