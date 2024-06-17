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

namespace TestDemo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DBcon dBcon = new DBcon();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            var Login = TB_Login.Text;
            var Password = PB_Password.Password;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            dBcon.OpenCon();

            string query = $"SELECT * FROM Сотрудники_отделов WHERE id = '1'";

            SqlCommand sqlCommand = new SqlCommand(query, dBcon.GetSqlConnection());

            adapter.SelectCommand = sqlCommand;
            adapter.Fill(table);

            dBcon.CloseCon();

            if (table.Rows.Count == 1)
            {
                int id = Convert.ToInt32(table.Rows[0].ItemArray[0]);

                Window1 window1 = new Window1(id);
                window1.Show();
                this.Close();
            }
        }
    }
}
