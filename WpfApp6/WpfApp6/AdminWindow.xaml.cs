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
namespace WpfApp6
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        string ConnectionString = null;
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;
        public static int allowprompts = 3;
        public AdminWindow()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            InitializeComponent();
            P.IsEnabled=false;
            N.IsEnabled=false;
            _ref.IsEnabled=false;
            UserAdd.IsEnabled=false;
            ExitfromSystem.IsEnabled=false;
            auth.IsEnabled=true;
            currentadminpass.IsEnabled=false;
            newadminpass.IsEnabled =false;
            usermame.IsEnabled=false;
            usersurname.IsEnabled=false;
            log.IsEnabled=false;
            stat.IsEnabled=false;
            rest.IsEnabled=false;
            akt.IsEnabled=false;
            addloginuser.IsEnabled=false;
        }
        private void GetandShowData(string SQLQuery, DataGrid dataGrid)
        {
            connection = new SqlConnection(ConnectionString);
            connection.Open();

            command = new SqlCommand(SQLQuery, connection);
            adapter = new SqlDataAdapter(command);
            DataTable Table = new DataTable();
            adapter.Fill(Table);
            dataGrid.ItemsSource = Table.DefaultView;

            connection.Close();
        }
        private void GetAccountsData()
        {
            string SQLQuery = "SELECT Surname as [Прізвище]," +
                              "Name as [Ім'я]," +
                              "Login as [Логін]," +
                              "Status as [Статус]" +
                              "From Autentification;";
            try
            {
                GetandShowData(SQLQuery, Acc);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new MainWindow().Show();
        }
        static int usedpromptsofenteringpassword = 0;
        private void Authprization_Click(object sender, RoutedEventArgs e)
        {
            String SQLQuery = "SELECT Password FROM Autentification WHERE Login = 'ADMIN'";
            connection = new SqlConnection(ConnectionString);
            connection.Open();
            command = new SqlCommand(SQLQuery, connection);
            adapter = new SqlDataAdapter(command);
            DataTable tab = new DataTable();
            adapter.Fill(tab);
            connection.Close();
            String password = tab.Rows[0]["Password"].ToString();
            if (adminpass.Text.ToString() == password)
            {
                adminpass.IsEnabled = false;                
                try
                {
                    P.IsEnabled = true;
                    N.IsEnabled = true;
                    _ref.IsEnabled = true;
                    UserAdd.IsEnabled = true;
                    ExitfromSystem.IsEnabled = true;
                    auth.IsEnabled = true;
                    currentadminpass.IsEnabled = true;
                    newadminpass.IsEnabled = true;
                    usermame.IsEnabled = true;
                    usersurname.IsEnabled = true;
                    log.IsEnabled = true;
                    stat.IsEnabled = true;
                    rest.IsEnabled = true;
                    akt.IsEnabled = true;
                    addloginuser.IsEnabled = true;
                    auth.IsEnabled = false;
                    adminpass.Text = "";
                    GetAccountsData();
                    MessageBox.Show("You are admin!");
                    CreatingOfUserCombo();
                }
                catch (Exception m)
                {
                    MessageBox.Show(m.Message);
                }
            }
            else
            {
                usedpromptsofenteringpassword++;
                adminpass.Text = "";
                MessageBox.Show($"Wrong input " + ";usedpromptsofenteringpassword " + usedpromptsofenteringpassword.ToString());
                if (usedpromptsofenteringpassword == 3)
                {
                    new MainWindow().Show();
                    this.Close();
                }

            }
        }

        private void ExitfromSystem_Click(object sender, RoutedEventArgs e)
        {
            P.IsEnabled = false;
            N.IsEnabled = false;
            _ref.IsEnabled = false;
            UserAdd.IsEnabled = false;
            ExitfromSystem.IsEnabled = false;
            auth.IsEnabled = true;
            currentadminpass.IsEnabled = false;
            newadminpass.IsEnabled = false;
            usermame.IsEnabled = false;
            usersurname.IsEnabled = false;
            log.IsEnabled = false;
            stat.IsEnabled = false;
            rest.IsEnabled = false;
            akt.IsEnabled = false;
            addloginuser.IsEnabled = false;
            auth.IsEnabled = true;
        }

        private void adminRefresh_Click(object sender, RoutedEventArgs e)
        {
            String SQLQuery = "SELECT Password FROM Autentification WHERE Login = 'Admin'";
            SqlConnection connection1 = new SqlConnection(ConnectionString);
            connection1.Open();
            SqlCommand command1 = new SqlCommand(SQLQuery, connection);
            command1.ExecuteNonQuery();
            String strQ;
            String RealPass = currentadminpass.Text.ToString();
            String NewPass = newadminpass.Text.ToString();
            if (!UserWindow.checkoffPasswordAvailibility(NewPass) || RealPass != command1.ExecuteScalar().ToString())
            {
                MessageBox.Show("Wrong password or incorrect one. It should consist of at least 3 symbols");
                return;
            }
                
            else
            {               
                strQ = "UPDATE Autentification SET Password ='" + NewPass + "'WHERE Login = 'ADMIN'; ";
                SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand(SQLQuery, connection);

       
                command = new SqlCommand(strQ, connection);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Your password was replaced successfully");
                currentadminpass.Text = "";
                newadminpass.Text = "";
            }
 

        }
        private void CreatingOfUserCombo()
        {
            rest.Items.Clear();
            try
            {
                connection = new SqlConnection(ConnectionString);
                connection.Open();
                string query = "SELECT Login FROM Autentification;";

                command = new SqlCommand(query, connection);
                var t = command.ExecuteReader();
                while (t.Read())
                {
                    for (int i = 0; i < t.FieldCount; i++)
                    {
                        rest.Items.Add(t.GetString(i));
                    }
                }
                t.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
        }
        private void update()
        {
            connection = new SqlConnection(ConnectionString);
            connection.Open();
            String SQLQuery = "SELECT Name, Surname, Login, Status FROM Autentification;";
            command = new SqlCommand(SQLQuery, connection);
            if (connection.State == System.Data.ConnectionState.Open)
            {
                adapter = new SqlDataAdapter(command);              

                DataTable dT = new DataTable("Користувачі системи");
                adapter.Fill(dT);
                var LenTable = dT.Rows.Count;               
                Acc.ItemsSource = dT.DefaultView;
            }
            connection.Close();
        }
        private void UserAdd_Click(object sender, RoutedEventArgs e)
        {
            connection = new SqlConnection(ConnectionString);
            connection.Open();
            String strQ;
            String UserLogin = addloginuser.Text;
            int check = akt.IsChecked == true? 1 : 0;
            try
            {
                strQ = $"INSERT INTO Autentification (Name, Surname, Login, Password, Status) values('user', 'Khaidurov', '" + UserLogin + "', '12345', '" + check + "'); ";
                command = new SqlCommand(strQ, connection);
                command.ExecuteNonQuery();

                update();
            }
            catch(Exception et)
            {
                MessageBox.Show(et.Message);
            }
            connection.Close();
        }
        private void P_Click(object sender, RoutedEventArgs e)
        {    
            int index = rest.SelectedIndex;
            if (index>=1)
            {
                connection = new SqlConnection(ConnectionString);
                connection.Open();
                string SQLQuery = "SELECT Surname as [Прізвище]," +
                                  "Name as [Ім'я]," +
                                  "Login as [Логін]," +
                                  "Status as [Статус]" +
                                  "From Autentification;";
                command = new SqlCommand(SQLQuery, connection);
                adapter = new SqlDataAdapter(command);
                DataTable Table = new DataTable();
                adapter.Fill(Table);
                connection.Close();
                if (index==1)
                {
                    usersurname.Text = "";
                    usermame.Text = "";
                    log.Text = "";
                    stat.Text = "";
                    MessageBox.Show("The next user is admin");
                    return;
                }
                index--;
                usersurname.Text = "";
                usermame.Text = "";
                log.Text = "";
                stat.Text = "";
                rest.SelectedIndex = index--;
                usersurname.Text = Table.Rows[index+1][0].ToString();
                usermame.Text = Table.Rows[index+1][1].ToString();
                log.Text = Table.Rows[index+1][2].ToString();
                stat.Text = Table.Rows[index+1][3].ToString();              
            }            
            
        }

        private void N_Click(object sender, RoutedEventArgs e)
        {
            connection = new SqlConnection(ConnectionString);
            connection.Open();
            string SQLQuery = "SELECT Surname as [Прізвище]," +
                              "Name as [Ім'я]," +
                              "Login as [Логін]," +
                              "Status as [Статус]" +
                              "From Autentification;";
            command = new SqlCommand(SQLQuery, connection);
            adapter = new SqlDataAdapter(command);
            DataTable Table = new DataTable();
            adapter.Fill(Table);
            connection.Close();
            int index = rest.SelectedIndex;
            if (index < Table.Rows.Count +1)
            {
           
                if (index == Table.Rows.Count-1)
                {
                    usersurname.Text = "";
                    usermame.Text = "";
                    log.Text = "";
                    stat.Text = "";
                    MessageBox.Show("Current user is last one. You can add another if you want");
                    return;
                }
                index++;
                usersurname.Text = "";
                usermame.Text = "";
                log.Text = "";
                stat.Text = "";
                rest.SelectedIndex = index++;
                usersurname.Text = Table.Rows[index-1][0].ToString();
                usermame.Text = Table.Rows[index-1][1].ToString();
                log.Text = Table.Rows[index-1][2].ToString();
                stat.Text = Table.Rows[index-1][3].ToString();

            }
        }
    }
}
