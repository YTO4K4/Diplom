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
using System.Windows.Controls;
using System.Windows.Forms;

namespace diplom
{
    public partial class BreakeLiquidForm : MaterialForm
    {
        public SqlConnection sqlConnection = null;
        string scon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\YTO4KA\OneDrive\Рабочий стол\дилпом\diplom\diplom\DiplomDB.mdf"";Integrated Security=True";
        private DataSet dataSet = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private SqlCommandBuilder sqlBuilder = null;
        public SqlCommand sqlCommand = null;
        int rowIndex = 0;
        public BreakeLiquidForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Blue800, Primary.Blue500, Accent.Blue200, TextShade.WHITE);
            sqlConnection = new SqlConnection(scon);
            sqlConnection.Open();
        }


        public void LoadData()
        {
            sqlDataAdapter = new SqlDataAdapter($"select  Breake.Id_b, Bus.GosNum as [Гос. номер], Bus.GarageNum as [Гаражынй номер], concat(Drivers.Surname, ' ', Left(Drivers.Name,1), '. ', Left(Drivers.Lastname,1), '.') as [ФИО водитля], Marks.Name as [Марка], \r\nMatCen.Name as [Что сломалось], MatCen.Type as [Тип], Breake.Povr as [Описание поврежденя],Breake.Dr_com as [Описание водителя], Breake.Otv as [ФИО ответсвенного], Breake.Time as [Время возврата]\r\nfrom Breake, Change, Drivers, Bus, Marks, MatCen\r\nwhere Change.Id_ch = {DataHolder.ID} and Change.Id_ch = Breake.Id_ch and Change.GarageNum = Bus.GarageNum and Change.Id_m = MatCen.Id_m and Bus.Id_dr = Drivers.Id_dr and Bus.Id_mark = Marks.Id_mark", sqlConnection);
            sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);
            dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "Breake");
            BreakeDVG.DataSource = dataSet.Tables["Breake"];
            BreakeDVG.Columns["Id_b"].Visible = false;

        }

        private void showAddPanelBtn_Click(object sender, EventArgs e)
        {
            addBreakePanel.Visible = true;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (addOtvTB.Text != "" && addDrCommTB.Text != "" && addOpisBreakeTB.Text != "" && addTimeTB.Text != "")
            {
                try
                {
                    SqlCommand command = new SqlCommand($"INSERT INTO Breake (Id_ch, Time, Povr, Dr_com,Otv) VALUES (@Id_ch, @Time, @Povr, @Dr_com,@Otv)", sqlConnection);

                    command.Parameters.AddWithValue("Id_ch", DataHolder.ID);
                    command.Parameters.AddWithValue("Time", addTimeTB.Text);
                    command.Parameters.AddWithValue("Povr", addOpisBreakeTB.Text);
                    command.Parameters.AddWithValue("Dr_com", addDrCommTB.Text);
                    command.Parameters.AddWithValue("Otv", addOtvTB.Text);

                    command.ExecuteNonQuery();


                    MaterialMessageBox.Show("Добавлено!");


                    addTimeTB.Text = "";
                    addOpisBreakeTB.Text = "";
                    addDrCommTB.Text = "";
                    addOtvTB.Text = "";
                    addBreakePanel.Visible = false;
                    LoadData();
                }
                catch (Exception ex) { MaterialMessageBox.Show("Проверьте введённые данные", "Ошибка"); }
            }
            else { MaterialMessageBox.Show("Заполните все поля", "Ошибка"); }
        }

        private void makeDocBtn_Click(object sender, EventArgs e)
        {
            string s = "";



            //Создаём новый Word.Application
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();

            //Загружаем документ
            Microsoft.Office.Interop.Word.Document doc = null;

            object fileName = @"C:\Users\YTO4KA\OneDrive\Рабочий стол\дилпом\diplom\Акт поломка жидкость.docx";
            object falseValue = false;
            object trueValue = true;
            object missing = Type.Missing;

            doc = app.Documents.Open(ref fileName, ref missing, ref falseValue,
            ref missing, ref missing, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing);


            //Очищаем параметры поиска
            app.Selection.Find.ClearFormatting();
            app.Selection.Find.Replacement.ClearFormatting();

            //Задаём параметры замены и выполняем замену.
            object findText = "<жидкость>";
            object replaceWith = BreakeDVG.CurrentRow.Cells[6].Value.ToString();
            object replace = 2;

            app.Selection.Find.Execute(ref findText, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing, ref missing, ref missing, ref replaceWith,
            ref replace, ref missing, ref missing, ref missing, ref missing);

            //Очищаем параметры поиска
            app.Selection.Find.ClearFormatting();
            app.Selection.Find.Replacement.ClearFormatting();

            //Задаём параметры замены и выполняем замену.
            findText = "<марка>";
            replaceWith = BreakeDVG.CurrentRow.Cells[4].Value.ToString();
            replace = 2;

            app.Selection.Find.Execute(ref findText, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing, ref missing, ref missing, ref replaceWith,
            ref replace, ref missing, ref missing, ref missing, ref missing);

            //Очищаем параметры поиска
            app.Selection.Find.ClearFormatting();
            app.Selection.Find.Replacement.ClearFormatting();

            findText = "<госном>";
            replaceWith = BreakeDVG.CurrentRow.Cells[2].Value.ToString();
            replace = 2;

            app.Selection.Find.Execute(ref findText, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing, ref missing, ref missing, ref replaceWith,
            ref replace, ref missing, ref missing, ref missing, ref missing);

            app.Visible = true;

            //Очищаем параметры поиска
            app.Selection.Find.ClearFormatting();
            app.Selection.Find.Replacement.ClearFormatting();

            //Задаём параметры замены и выполняем замену.
            findText = "<Время>";
            replaceWith = BreakeDVG.CurrentRow.Cells[10].Value.ToString();
            replace = 2;

            app.Selection.Find.Execute(ref findText, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing, ref missing, ref missing, ref replaceWith,
            ref replace, ref missing, ref missing, ref missing, ref missing);

            //Очищаем параметры поиска
            app.Selection.Find.ClearFormatting();
            app.Selection.Find.Replacement.ClearFormatting();

            //Задаём параметры замены и выполняем замену.
            findText = "<водитель>";
            replaceWith = BreakeDVG.CurrentRow.Cells[3].Value.ToString();
            replace = 2;

            app.Selection.Find.Execute(ref findText, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing, ref missing, ref missing, ref replaceWith,
            ref replace, ref missing, ref missing, ref missing, ref missing);


            //Очищаем параметры поиска
            app.Selection.Find.ClearFormatting();
            app.Selection.Find.Replacement.ClearFormatting();

            //Задаём параметры замены и выполняем замену.
            findText = "<повр>";
            replaceWith = BreakeDVG.CurrentRow.Cells[7].Value.ToString();
            replace = 2;

            app.Selection.Find.Execute(ref findText, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing, ref missing, ref missing, ref replaceWith,
            ref replace, ref missing, ref missing, ref missing, ref missing);

            //Очищаем параметры поиска
            app.Selection.Find.ClearFormatting();
            app.Selection.Find.Replacement.ClearFormatting();

            //Задаём параметры замены и выполняем замену.
            findText = "<Описание>";
            replaceWith = BreakeDVG.CurrentRow.Cells[8].Value.ToString();
            replace = 2;

            app.Selection.Find.Execute(ref findText, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing, ref missing, ref missing, ref replaceWith,
            ref replace, ref missing, ref missing, ref missing, ref missing);

            //Очищаем параметры поиска
            app.Selection.Find.ClearFormatting();
            app.Selection.Find.Replacement.ClearFormatting();

        }

        private void BreakeLiquidForm_Load(object sender, EventArgs e)
        {

            LoadData();
        }
    }
}
