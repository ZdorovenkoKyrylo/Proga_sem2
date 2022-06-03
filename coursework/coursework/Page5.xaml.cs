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
    /// Interaction logic for Page5.xaml
    /// </summary>
    public partial class Page5 : Page
    {

        public Page5()
        {
            InitializeComponent();
            CB.SelectedIndex = 0;

        }
        
        
        

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
                                          "FullName as [FullName], " +
                                          "dbo.ApplicantTake.Year," +
                                          "dbo.ApplicantTake.Mark," +
                                          "dbo.Subject.Name as [SN] " +
                                          "From dbo.Applicant " +
                                          "LEFT OUTER JOIN dbo.ApplicantTake " +
                                          "ON dbo.Applicant.ApplicantID =dbo.ApplicantTake.ApplicantID " +
                                          "LEFT OUTER JOIN dbo.Subject " +
                                          "ON dbo.ApplicantTake.SubjectID = dbo.Subject.SubjectID " +
                                          $"WHERE Subject.Name LIKE '%{selected}%';";

            dt1.ItemsSource = Vladdick.cropDate(Vladdick.GetDataTable(query),1).DefaultView;
        }

        private void Calculus_Click(object sender, RoutedEventArgs e)
        {
            Calculus win = new Calculus();
            win.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdditionalPoints ad = new AdditionalPoints();
            ad.Show();
        }
    }
}
