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
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        string ConnectionString = null;
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;

        public Page2()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            InitializeComponent();
            Applicant_RewardsInfo();

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
        private void Applicant_RewardsInfo()
        {
            String query = "SELECT " +
                "Applicant.ApplicantID as [Номер]," +
                             "DateofBirth as [DateofBirth]," +
                             "PhoneNumber as [PhoneNumber]," +
                              "Adress as [Adress]," +
                              "CityID as [CityID]," +
                              "SchoolID as [SchoolID]," +
                              "FullName as [FullName], " +
                              "dbo.Rewards.Name, " +
                              "dbo.Rewards.PercentofReward " +
                              "From dbo.Applicant " +
                              "LEFT OUTER JOIN dbo.RewardsApplicant " +
                              "ON dbo.Applicant.ApplicantID =dbo.RewardsApplicant.ApplicantID " +
                              "LEFT OUTER JOIN dbo.Rewards " +
                              "ON dbo.RewardsApplicant.RewardID = dbo.Rewards.RewardID;";
            try
            {
                GetandShowData(query, dt);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
