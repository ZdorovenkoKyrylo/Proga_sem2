using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for AdditionalPoints.xaml
    /// </summary>
    public partial class AdditionalPoints : Window
    {
        public AdditionalPoints()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String q = $"SELECT ApplicantID From Applicant WHERE FullName ='{Name.Text}'";
            DataTable dt = Vladdick.GetDataTable(q);
            int ID = (int)dt.Rows[0]["ApplicantID"];
            String q1 = $"SELECT PilgID as ID From PilgApplicant WHERE ApplicantID ='{ID}'";
            DataTable dt1 = Vladdick.GetDataTable(q1);
            int ID1 = (int)dt1.Rows[0]["ID"];
            String q2 = $"SELECT [Percent] as per From Pilg WHERE PilgID={ID1}";
            DataTable dt2 = Vladdick.GetDataTable(q2);
            Decimal Perce = (Decimal)dt2.Rows[0]["per"];
            PilgPoints.Content = Perce.ToString();

            String q3 = $"SELECT ApplicantID From Applicant WHERE FullName ='{Name.Text}'";
            DataTable dt3 = Vladdick.GetDataTable(q3);
            int ID3 = (int)dt3.Rows[0]["ApplicantID"];
            String q4 = $"SELECT RewardID as ID From RewardsApplicant WHERE ApplicantID ='{ID3}'";
            DataTable dt4 = Vladdick.GetDataTable(q4);
            int ID4 = (int)dt4.Rows[0]["ID"];
            String q5 = $"SELECT PercentofReward as per From Rewards WHERE RewardID={ID4}";
            DataTable dt5 = Vladdick.GetDataTable(q5);
            int Percen = (int)dt5.Rows[0]["per"];
            RewardsPoints.Content = Percen.ToString();

            int Sum = Percen + Decimal.ToInt32(Perce);
            Summ.Content = Sum.ToString();

        }
    }
}
