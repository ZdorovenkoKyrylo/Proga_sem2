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
using System.IO;

namespace coursework
{
    /// <summary>
    /// Interaction logic for Calculus.xaml
    /// </summary>
    public partial class Calculus : Window
    {
        string ConnectionString = null;
        SqlConnection connection = null;
        public Calculus()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            InitializeComponent();

        }
        
        private void Image(int ID)
        {
            BitmapImage image;
            try
            {   
                image = LoadImage((byte[])Vladdick.GetDataTable($"SELECT Image FROM dbo.ImageApplicant WHERE ApplicantID = {ID}").Rows[0]["Image"]);
            }
            catch (Exception) 
            { 
                image = null;
            }
            im.Source = image;
        }
        public static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String query = "SELECT " +
                "Applicant.ApplicantID as [Номер]," +
                             "dbo.Subject.Name as [SubName], " +
                             "dbo.ApplicantTake.Mark as [Mark], " +
                             "dbo.ApplicantTake.Year as [Year] " +
                              

                              "From dbo.Applicant " +
                              "LEFT OUTER JOIN dbo.ApplicantTake " +
                              "ON dbo.Applicant.ApplicantID =dbo.ApplicantTake.ApplicantID " +
                              "LEFT OUTER JOIN dbo.Subject " +
                              "ON dbo.ApplicantTake.SubjectID = dbo.Subject.SubjectID " +
                              $"Where dbo.Applicant.FullName = '{FullName.Text}'";
            String query2 = "SELECT " +
                                "dbo.Rewards.PercentofReward, " +
                                "dbo.Pilg.[Percent] " +
                                "From dbo.Applicant " +
                                "LEFT OUTER JOIN dbo.RewardsApplicant " +
                                "ON dbo.Applicant.ApplicantID =dbo.RewardsApplicant.ApplicantID " +
                                "LEFT OUTER JOIN dbo.Rewards " +
                                "ON dbo.RewardsApplicant.RewardID = dbo.Rewards.RewardID " +
                                "LEFT OUTER JOIN dbo.PilgApplicant " +
                                "ON dbo.Applicant.ApplicantID =dbo.PilgApplicant.ApplicantID " +
                                "LEFT OUTER JOIN dbo.Pilg " +
                                "ON dbo.PilgApplicant.PilgID = dbo.Pilg.PilgID " +
                                $"Where dbo.Applicant.FullName = '{FullName.Text}'";

            try
            {
                connection = new SqlConnection(ConnectionString);
                connection.Open();

                var command = new SqlCommand(query, connection);
                var command2 = new SqlCommand(query2, connection);
                var adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                DataTable dt2 = new DataTable();
                new SqlDataAdapter(command2).Fill(dt2);
                adapter.Fill(dt);
                Image((int)dt.Rows[0]["Номер"]);


                dt1.ItemsSource = dt.DefaultView;
                connection.Close();

                var total = 0;
                foreach (DataRow row in dt.Rows)
                    total += (int)row["Mark"];
                AvPoint.Content = 1.0 * total / dt.Rows.Count;

                total = (int)dt2.Rows[0]["PercentofReward"] + Decimal.ToInt32((decimal)dt2.Rows[0]["Percent"]);
                double x = Convert.ToDouble(AvPoint.Content.ToString());
                ReitPoint.Content = (total + x).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }       
    }
}
