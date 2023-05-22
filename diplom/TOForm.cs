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
    public partial class TOForm : MaterialForm
    {
        public SqlConnection sqlConnection = null;
        string scon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\YTO4KA\OneDrive\Рабочий стол\дилпом\diplom\diplom\DiplomDB.mdf"";Integrated Security=True";
        private DataSet dataSet = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private SqlCommandBuilder sqlBuilder = null;
        public SqlCommand sqlCommand = null;
        int rowIndex = 0;
        public TOForm()
        {

            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Blue800, Primary.Blue500, Accent.Blue200, TextShade.WHITE);
            sqlConnection = new SqlConnection(scon);
            sqlConnection.Open();
        }

        private void TOForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            sqlDataAdapter = new SqlDataAdapter($"select  [TO].Id_to, concat(Drivers.Surname, ' ', Left(Drivers.Name,1), '. ', Left(Drivers.Lastname,1), '.') as [ФИО водитля],MatCen.Name as [Что сломалось], MatCen.Type as [Тип],[TO].Izm as [Единица измерения],[TO].Kolvo_z as [Кол-во затребовано], [TO].Kolvo_o as [Кол-во отпущено], [TO].Prcie as [Цена], [TO].Prcie * [TO].Kolvo_o as [Сумма], [TO].Otv as [ФИО ответственного] \r\nfrom [TO], Change, Drivers,Bus,  MatCen\r\nwhere [TO].Id_ch = {DataHolder.ID} and Change.Id_ch = [TO].Id_ch and Change.Id_m = MatCen.Id_m and Change.GarageNum = Bus.GarageNum and Bus.Id_dr = Drivers.Id_dr", sqlConnection);
            sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);
            dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "TO");
            TODVG.DataSource = dataSet.Tables["TO"];
            TODVG.Columns["Id_to"].Visible = false;

        }

        private void showAddPanelBtn_Click(object sender, EventArgs e)
        {
            addTOPanel.Visible = true;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (addOtvTB.Text != "" && AddEdIzvTB.Text != "" && addPriceTB.Text != "" && addKoloVoZTB.Text != "" && addKolVoOTB.Text != "")
            {
                //try
                //{
                    SqlCommand command = new SqlCommand($"INSERT INTO [TO]  (Id_ch, Otv, Izm, Kolvo_z,Kolvo_o,Prcie) VALUES (@Id_ch, @Otv, @Izm, @Kolvo_z,@Kolvo_o,@Prcie)", sqlConnection);

                    command.Parameters.AddWithValue("Id_ch", DataHolder.ID);
                    command.Parameters.AddWithValue("Otv", addOtvTB.Text);
                    command.Parameters.AddWithValue("Izm", AddEdIzvTB.Text);
                    command.Parameters.AddWithValue("kolvo_z", addKoloVoZTB.Text);
                    command.Parameters.AddWithValue("kolvo_o", addKolVoOTB.Text);
                    command.Parameters.AddWithValue("Prcie", addPriceTB.Text);

                    command.ExecuteNonQuery();


                    MaterialMessageBox.Show("Добавлено!");


                    addOtvTB.Text = "";
                    AddEdIzvTB.Text = "";
                    addPriceTB.Text = "";
                    addKoloVoZTB.Text = "";
                    addKolVoOTB.Text = "";
                    addTOPanel.Visible = false;
                    LoadData();
                //}
                //catch (Exception ex) { MaterialMessageBox.Show("Проверьте введённые данные", "Ошибка"); }
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

            object fileName = @"C:\Users\YTO4KA\OneDrive\Рабочий стол\дилпом\diplom\ТО.docx";
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
            object findText = "<Номер>";
            object replaceWith = TODVG.CurrentRow.Cells[0].Value.ToString();
            object replace = 2;

            app.Selection.Find.Execute(ref findText, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing, ref missing, ref missing, ref replaceWith,
            ref replace, ref missing, ref missing, ref missing, ref missing);

            //Очищаем параметры поиска
            app.Selection.Find.ClearFormatting();
            app.Selection.Find.Replacement.ClearFormatting();

            //Задаём параметры замены и выполняем замену.
            findText = "<Водила>";
            replaceWith = TODVG.CurrentRow.Cells[1].Value.ToString();
            replace = 2;

            app.Selection.Find.Execute(ref findText, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing, ref missing, ref missing, ref replaceWith,
            ref replace, ref missing, ref missing, ref missing, ref missing);

            //Очищаем параметры поиска
            app.Selection.Find.ClearFormatting();
            app.Selection.Find.Replacement.ClearFormatting();

            findText = "<Отв>";
            replaceWith = TODVG.CurrentRow.Cells[9].Value.ToString();
            replace = 2;

            app.Selection.Find.Execute(ref findText, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing, ref missing, ref missing, ref replaceWith,
            ref replace, ref missing, ref missing, ref missing, ref missing);

            app.Visible = true;

            //Очищаем параметры поиска
            app.Selection.Find.ClearFormatting();
            app.Selection.Find.Replacement.ClearFormatting();

            //Задаём параметры замены и выполняем замену.
            findText = "<Что>";
            replaceWith = TODVG.CurrentRow.Cells[3].Value.ToString() + TODVG.CurrentRow.Cells[2].Value.ToString();
            replace = 2;

            app.Selection.Find.Execute(ref findText, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing, ref missing, ref missing, ref replaceWith,
            ref replace, ref missing, ref missing, ref missing, ref missing);

            //Очищаем параметры поиска
            app.Selection.Find.ClearFormatting();
            app.Selection.Find.Replacement.ClearFormatting();

            //Задаём параметры замены и выполняем замену.
            findText = "<ЕдИзм>";
            replaceWith = TODVG.CurrentRow.Cells[4].Value.ToString();
            replace = 2;

            app.Selection.Find.Execute(ref findText, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing, ref missing, ref missing, ref replaceWith,
            ref replace, ref missing, ref missing, ref missing, ref missing);


            //Очищаем параметры поиска
            app.Selection.Find.ClearFormatting();
            app.Selection.Find.Replacement.ClearFormatting();

            //Задаём параметры замены и выполняем замену.
            findText = "<КолвоЗ>";
            replaceWith = TODVG.CurrentRow.Cells[5].Value.ToString();
            replace = 2;

            app.Selection.Find.Execute(ref findText, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing, ref missing, ref missing, ref replaceWith,
            ref replace, ref missing, ref missing, ref missing, ref missing);

            //Очищаем параметры поиска
            app.Selection.Find.ClearFormatting();
            app.Selection.Find.Replacement.ClearFormatting();

            //Задаём параметры замены и выполняем замену.
            findText = "<КолвоО>";
            replaceWith = TODVG.CurrentRow.Cells[6].Value.ToString();
            replace = 2;

            app.Selection.Find.Execute(ref findText, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing, ref missing, ref missing, ref replaceWith,
            ref replace, ref missing, ref missing, ref missing, ref missing);

            //Очищаем параметры поиска
            app.Selection.Find.ClearFormatting();
            app.Selection.Find.Replacement.ClearFormatting();
            //Задаём параметры замены и выполняем замену.
            findText = "<Цена>";
            replaceWith = TODVG.CurrentRow.Cells[7].Value.ToString();
            replace = 2;

            app.Selection.Find.Execute(ref findText, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing, ref missing, ref missing, ref replaceWith,
            ref replace, ref missing, ref missing, ref missing, ref missing);

            //Очищаем параметры поиска
            app.Selection.Find.ClearFormatting();
            app.Selection.Find.Replacement.ClearFormatting();
            //Задаём параметры замены и выполняем замену.
            findText = "<Сумма>";
            replaceWith = TODVG.CurrentRow.Cells[8].Value.ToString();
            replace = 2;

            app.Selection.Find.Execute(ref findText, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing, ref missing, ref missing, ref replaceWith,
            ref replace, ref missing, ref missing, ref missing, ref missing);

            //Очищаем параметры поиска
            app.Selection.Find.ClearFormatting();
            app.Selection.Find.Replacement.ClearFormatting();

        }

        private void materialButton13_Click(object sender, EventArgs e)
        {
            addTOPanel.Visible = false;
        }
    }
}
