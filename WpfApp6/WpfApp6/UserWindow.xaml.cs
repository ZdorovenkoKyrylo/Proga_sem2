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
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace WpfApp6
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        string ConnectionString = null;
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;  
        int usedpromts = 0;
        public UserWindow()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            InitializeComponent();
            GetAccountsData();
            ExitfromSystem.IsEnabled = false;
            refresh.IsEnabled = false;
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
                GetandShowData(SQLQuery, Ac);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void Add_User_Click(object sender, RoutedEventArgs e)
        {
            if (!checkoffLoginAvailibility(nameadding.Text.ToString())||!checkoffPasswordAvailibility(passwordadding.Text))
            {
                return;
            }
            else
            {
                String SQLQuery = "INSERT INTO Autentification VALUES" +
                    "(" + "'" + nameadding.Text.ToString() + "', '" + surnameadding.Text.ToString() + "', '" + loginadding.Text.ToString() + "', '" + passwordadding.Text.ToString() + "', '1');";
                connection = new SqlConnection(ConnectionString);
                connection.Open();
                try
                {
                    SqlCommand c = new SqlCommand(SQLQuery, connection);
                    c.ExecuteNonQuery();
                    nameadding.Clear();
                    surnameadding.Clear();
                    loginadding.Clear();
                    passwordadding.Clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }                
            }
        }
        private bool checkoffLoginAvailibility(String log)
        {
            bool b = true;
            if (log == null)
                return b = false;
            connection = new SqlConnection(ConnectionString);
            connection.Open();
            string S = $"SELECT Count (*) From Autentification where Login = '{log}'";
            command = new SqlCommand(S, connection);
            if ((int)command.ExecuteScalar()==1)
            {
                return b=false;
            }
            return b;    
        }
        public static int minnumber = 5;
        static  public bool checkoffPasswordAvailibility(String password)
        {
            string symbols = "/*-+!@#$%^&";
            bool b = true;
            if (password.Length < 3)
            {
                MessageBox.Show("Your password is too short. It must be at least of 3 symbols");
                return false;
            }    
            foreach (var item in password)
            {
                if (symbols.Contains(item))
                    return false;              
            }
            return b;
        }
        private void Authorization_Click(object sender, RoutedEventArgs e)
        {
            String login = loginauthorization.Text.ToString();
            if (login == null)
                return;
            string SQ = "SELECT Status " +
                  "From Autentification WHERE Login = '" + loginauthorization.Text.ToString() + "';";
            connection = new SqlConnection(ConnectionString);
            connection.Open();
            command = new SqlCommand(SQ, connection);
            adapter = new SqlDataAdapter(command);
            DataTable Table = new DataTable();
            adapter.Fill(Table);
            connection.Close();
            if ((bool)Table.Rows[0]["Status"] == false)
            {
                MessageBox.Show("Admin disconnected your account");
                return;
            }
            else  if(login == "Admin")
            {
                MessageBox.Show("You authorize like admin. You should go to the adminwindow");
                loginauthorization.Text = "";
                passwordauthorization.Text = "";
                return;
            }
            else 
            {
                String password = passwordadding.Text.ToString();
                connection = new SqlConnection(ConnectionString);
                connection.Open();
                string SQLQuery = $"SELECT Count (*) From Autentification where Login = '{loginauthorization.Text}' AND Password = '{passwordauthorization.Text}' AND Status = 1";
                command = new SqlCommand(SQLQuery, connection);    
                if ((int)command.ExecuteScalar() == 1)
                {
                    MessageBox.Show("You can rename your accout if you want");
                    loginauthorization.Text = "";
                    passwordauthorization.Text = "";
                    refresh.IsEnabled = true;
                    ExitfromSystem.IsEnabled = true;
                    authoriz.IsEnabled = false;
                    Registration.IsEnabled = false;
                }
                else
                {
                    usedpromts++;
                    if (AdminWindow.allowprompts - usedpromts==0)
                    {
                        this.Close();
                        new MainWindow().Show();
                    }
                    else
                    {
                        MessageBox.Show("Try again!");
                        loginauthorization.Clear();
                        passwordauthorization.Clear();
                    }
                }
            }
            Registration.IsEnabled = false;
        }

        private void ExitfromSystem_Click(object sender, RoutedEventArgs e)
        {
            authoriz.IsEnabled = true;
            ExitfromSystem.IsEnabled = false;
            refresh.IsEnabled = false;
            Registration.IsEnabled = true;
            //Grid grid = new Grid();
            loginauthorization.Clear();
            passwordauthorization.Clear();
            nameadding.Clear();
            surnameadding.Clear();
            loginadding.Clear();
            passwordadding.Clear();


        }

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            string name = namechanging.Text.ToString();
            string surname = surnamechanging.Text.ToString();
            string newpass_ch = passwchanging.Text.ToString();
            string log = loginchan.Text.ToString();
            if (name == null || surname == null)
                return;
            if (!checkoffPasswordAvailibility(newpass_ch))
            {
                return;
            }
            connection = new SqlConnection(ConnectionString);
            connection.Open();
            string Q =
                        "UPDATE Autentification " +
                        "SET Surname = '" + surname + "', " +
                        "Name = '" + name + "', " +                        
                        "Password = '" + newpass_ch + "'" +                       
                        "WHERE Login = '" + loginchan.Text.ToString() + "';";
            try
            {
                command = new SqlCommand(Q, connection);
                command.ExecuteNonQuery();
                loginauthorization.Text = loginchan.Text.ToString();
                passwordauthorization.Text = passwchanging.Text.ToString();
                namechanging.Text = "";
                loginchan.Text = "";
                surnamechanging.Text = "";
                passwchanging.Text = "";
                connection.Close();
            }
            catch (Exception et)
            {
                MessageBox.Show(et.Message);
            }

        }

        private void CloseUser_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new MainWindow().Show();
        }
    }
}
