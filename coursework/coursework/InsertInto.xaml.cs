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

namespace coursework
{
    /// <summary>
    /// Interaction logic for InsertInto.xaml
    /// </summary>
    public partial class InsertInto : Window
    {
        public InsertInto()
        {
            InitializeComponent();
        }
        private void WriteAppInfo()
        {
            String S = "SELECT MAX(ApplicantID) as max From Applicant";
            int ID = 1 + (int)Vladdick.GetDataTable(S).Rows[0]["max"];
            String SQLQuery = "INSERT INTO Applicant VALUES" +
                   $"(" +
                   $"'{ID}', " +
                   $"'{dateofbirth.Text}', " +
                   $"'{phonenumber.Text}', " +
                   $"'{adress.Text}', " +
                   $"(SELECT CityID FROM City WHERE Name = '{city.Text}'), " +
                   $"(SELECT SchoolID FROM School WHERE Name = '{school.Text}'), " +
                   $"'{fullname.Text}'" +
                   ");";
            Vladdick.GetDataTable(SQLQuery);
        }
        private void WriteExamInfo()
        {
            String S = $"SELECT ApplicantID as max From Applicant WHERE Applicant.FullName = '{fullname.Text}'";
            int ID = (int)Vladdick.GetDataTable(S).Rows[0]["max"];
            TextBox[] tbarr = new TextBox[5] { Mark1, Mark2, Mark3, Mark4, Mark5 };
            ComboBox[] arr = new ComboBox[5] { CB1, CB2, CB3, CB4, CB5 };
            for (int i = 0; i < 5; i++)
            {
                if (arr[i].SelectedItem == null)
                    continue;

                String sq = "SELECT MAX(ApplicantTakeID) as max FROM ApplicantTake" ;
                int currApplicantTake = (int)Vladdick.GetDataTable(sq).Rows[0]["max"]+1;
               
                String SQ = "INSERT INTO ApplicantTake Values" +
                "(" +
                $"'{currApplicantTake}', " +
                $"(SELECT ApplicantID From Applicant WHERE Applicant.FullName = '{fullname.Text}')," +
                $"(SELECT SubjectID From Subject WHERE Subject.Name = '{arr[i].SelectedItem.ToString().Substring(arr[i].SelectedItem.ToString().IndexOf(" ") + 1)}')," +
                $"'2022', " +
                $"'{tbarr[i].Text}' " +
                ");";
                Vladdick.Execute(SQ);

               

                sq = "SELECT MAX(ApplicantPlaceID) as max FROM ApplicantPlace";
                int currApplicantPlace = (int)Vladdick.GetDataTable(sq).Rows[0]["max"]+1;

                SQ = "INSERT INTO ApplicantPlace Values" +
                "(" +
                $"{currApplicantPlace}, " +
                $"'{currApplicantTake}'," +
                $"(SELECT SchoolID FROM School WHERE Name = '{school.Text}'), " +
                $"'{new Random().Next(1, 100)}'," +
                $"'{new Random().Next(1, 51)}' " +
                ");";
                Vladdick.Execute(SQ);

                MessageBox.Show($"AppTake = {currApplicantTake}\tAppPlace = {currApplicantPlace}");
            }                       
        }
        private void WriteRewardsAndPilgsInfo()
        {
            if (CB_Pilga.SelectedItem == null || CB_Reward.SelectedItem == null)
            {
                return;
            }             
            String SQ = "INSERT INTO PilgApplicant Values" +
                           "(" +
                           $"(SELECT PilgID From Pilg WHERE Pilg.Type = '{CB_Pilga.SelectedItem.ToString().Substring(CB_Pilga.SelectedItem.ToString().IndexOf(" ") + 1)}')," +
                           $"(SELECT ApplicantID From Applicant WHERE Applicant.FullName = '{fullname.Text}') " +
                           ");";
            Vladdick.Execute(SQ);

            SQ = "INSERT INTO RewardsApplicant Values" +
                           "(" +
                           $"(SELECT ApplicantID From Applicant WHERE Applicant.FullName = '{fullname.Text}')," +
                           $"(SELECT RewardID From Rewards WHERE Rewards.Name = '{CB_Reward.SelectedItem.ToString().Substring(CB_Reward.SelectedItem.ToString().IndexOf(" ") + 1)}')" +                          
                           ");";
            Vladdick.Execute(SQ);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WriteAppInfo();
            WriteExamInfo();
            WriteRewardsAndPilgsInfo();        
        }
    }
}
