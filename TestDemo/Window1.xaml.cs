using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace TestDemo
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public int _id;
        DBcon dBcon = new DBcon();

        public Window1(int id)
        {
            _id = id;
            InitializeComponent();

            BindDataGrid();
            CheckUser();
        }

        public void CheckUser()
        {
            if (_id == 1)
            {
                qwe.Content = "Правильно";
            }
            else
            {
                qwe.Content = "Неправильно";
            }

            dBcon.OpenCon();

            string query = $"SELECT Login FROM Сотрудники_отделов WHERE id = @_id";
            SqlCommand command = new SqlCommand(query, dBcon.GetSqlConnection());
            command.Parameters.AddWithValue("@_id", _id);
            string Log = command.ExecuteScalar().ToString();
            if ( Log == "Admin")
            {
                btn_123.IsEnabled = false;
            }

            dBcon.CloseCon();
        }

        public void BindDataGrid()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable("Сотрудники");

            dBcon.OpenCon();

            string query = $"SELECT id, ФИО, Login From Сотрудники_отделов";

            SqlCommand command = new SqlCommand(query, dBcon.GetSqlConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            DataGrid1.ItemsSource = table.DefaultView;

            dBcon.CloseCon();
        }
    }
}
