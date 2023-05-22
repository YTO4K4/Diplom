using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace diplom
{
    public partial class LoginForm : MaterialForm
    {
        public SqlConnection sqlConnection = null;
        string scon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\YTO4KA\OneDrive\Рабочий стол\дилпом\diplom\diplom\DiplomDB.mdf"";Integrated Security=True";
        public static bool IsAdmin;
        public LoginForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Blue800, Primary.Blue500, Accent.Blue200, TextShade.WHITE);
            sqlConnection = new SqlConnection(scon);
            sqlConnection.Open();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            if (UsernameTB.Text != "" && PasswordTB.Text != "")
            {


                var loginUser = UsernameTB.Text;

                SqlCommand sqlCommand = new SqlCommand($"select distinct IsAdmin from Users where UserName ='{loginUser}' and Password = '{PasswordTB.Text}'", sqlConnection);

                if (sqlCommand.ExecuteScalar() == null)
                {
                    MaterialMessageBox.Show("Введите правильный логин!", "Оишбка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    IsAdmin = (bool)sqlCommand.ExecuteScalar();
                }

                if (IsAdmin == true)
                {
                    var loginUser1 = UsernameTB.Text;
                    var passUser = PasswordTB.Text;

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    DataTable table = new DataTable();

                    string querystring = $"SELECT Id, Username, Password FROM Users WHERE Username = '{loginUser1}' and Password = '{passUser}'";

                    SqlCommand command = new SqlCommand(querystring, sqlConnection);

                    adapter.SelectCommand = command;
                    adapter.Fill(table);

                    if (table.Rows.Count == 1)
                    {
                        MaterialMessageBox.Show("Вы успешно вошли!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        AdminForm form1 = new AdminForm();
                        this.Hide();
                        form1.ShowDialog();
                    }
                    else
                        MaterialMessageBox.Show("Такого аккаунта не существует!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (IsAdmin == false)
                {
                    var loginUser1 = UsernameTB.Text;
                    var passUser = PasswordTB.Text;

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    DataTable table = new DataTable();

                    string querystring = $"SELECT Id, UserName, Password FROM Users WHERE UserName = '{loginUser1}' and Password = '{passUser}'";

                    SqlCommand command = new SqlCommand(querystring, sqlConnection);

                    adapter.SelectCommand = command;
                    adapter.Fill(table);

                    if (table.Rows.Count == 1)
                    {
                        MaterialMessageBox.Show("Вы успешно вошли!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UserForm form1 = new UserForm();
                        this.Hide();
                        form1.ShowDialog();

                    }
                    else
                    {
                        MaterialMessageBox.Show("Такого аккаунта не существует!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MaterialMessageBox.Show("Заполните корректно все поля!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
