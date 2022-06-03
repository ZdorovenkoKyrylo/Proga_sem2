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
    /// Interaction logic for Page4.xaml
    /// </summary>
    public partial class Page4 : Page
    {
        string ConnectionString = null;
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;
        public Page4()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            InitializeComponent();
            Applicant_LivingInfo();


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
        private void Applicant_LivingInfo()
        {
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
                              "dbo.ApplicantPlace.SchoolID," +
                              "dbo.ApplicantPlace.StartTime," +
                              "dbo.ApplicantPlace.FinishTime," +
                              "dbo.ApplicantPlace.Audience," +
                              "dbo.Responsible.Name " +
                              "From dbo.Applicant " +
                              "LEFT OUTER JOIN dbo.ApplicantTake " +
                              "ON dbo.Applicant.ApplicantID =dbo.ApplicantTake.ApplicantID " +
                              "LEFT OUTER JOIN dbo.ApplicantPlace " +
                              "ON dbo.ApplicantTake.ApplicantTakeID = dbo.ApplicantPlace.ApplicantTakeID " +
                              "LEFT OUTER JOIN dbo.Responsible " +
                              "ON dbo.ApplicantPlace.ResponsibleID = dbo.Responsible.ResponsibleID";

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
