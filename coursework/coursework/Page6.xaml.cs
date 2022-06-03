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
    /// Interaction logic for Page6.xaml
    /// </summary>
    public partial class Page6 : Page
    {


        public Page6()
        {
            InitializeComponent();
            Applicant_ExamInfo();
        }
        
        private void Applicant_ExamInfo()
        {
            String query = "SELECT * " +
                "From dbo.Subject";


            dt1.ItemsSource = Vladdick.cropDate(Vladdick.GetDataTable(query), 4).DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ScheduleWin sw = new ScheduleWin();
            sw.Show();
        }
    }
}
