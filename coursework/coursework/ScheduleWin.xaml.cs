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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace coursework
{
    /// <summary>
    /// Interaction logic for ScheduleWin.xaml
    /// </summary>
    public partial class ScheduleWin : Window
    {     
        public ScheduleWin()
        {
            InitializeComponent();
        }

        private void Output_Click(object sender, RoutedEventArgs e)
        {
            ExamDate.Content = new Page6();
        }
        private bool CheckofValidityTime()
        {
            try
            {
                TimeSpan.Parse(ChangeStTime.Text);
                TimeSpan.Parse(ChangeFnTime.Text);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (Combo.SelectedItem == null)
                return;
            else if (!CheckofValidityTime())
                return;
            String ChangeSubject = Combo.Text.ToString();
            MessageBox.Show(ChangeSubject);
            DateTime dt1 = d1.SelectedDate.Value; 
            TimeSpan CChangeStTime = TimeSpan.Parse(ChangeStTime.Text);
            TimeSpan CChangeFnTime = TimeSpan.Parse(ChangeFnTime.Text);
            String query = "Update dbo.Subject " +
               $"Set StartTime = '{CChangeStTime}', FinishTime = '{CChangeFnTime}', DateofPass = '{dt1}' " +
               $"WHERE Name = '{ChangeSubject}';";
            Vladdick.GetDataTable(query);
        }
    }
}
