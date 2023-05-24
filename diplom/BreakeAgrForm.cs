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
    public partial class BreakeAgrForm : MaterialForm
    {
        public SqlConnection sqlConnection = null;
        string scon = @"";
        private DataSet dataSet = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private SqlCommandBuilder sqlBuilder = null;
        public SqlCommand sqlCommand = null;
        int rowIndex = 0;
        public BreakeAgrForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Blue800, Primary.Blue500, Accent.Blue200, TextShade.WHITE);
            sqlConnection = new SqlConnection(scon);
            sqlConnection.Open();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //materialLabel1.Text = Convert.ToString(DataHolder.ID);
            addTimeDtp.Format = DateTimePickerFormat.Custom;
            addTimeDtp.CustomFormat = "HH:mm";
            addTimeDtp.ShowUpDown = true;
            LoadData();
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

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (addOtvTB.Text != "" && addDrCommTB.Text != "" && addOpisBreakeTB.Text != "")
            {
                try
                {
                    SqlCommand command = new SqlCommand($"INSERT INTO Breake (Id_ch, Time, Povr, Dr_com,Otv) VALUES (@Id_ch, @Time, @Povr, @Dr_com,@Otv)", sqlConnection);

                    command.Parameters.AddWithValue("Id_ch", DataHolder.ID);
                    command.Parameters.AddWithValue("Time", addTimeDtp.Value.ToString());
                    command.Parameters.AddWithValue("Povr", addOpisBreakeTB.Text);
                    command.Parameters.AddWithValue("Dr_com", addDrCommTB.Text);
                    command.Parameters.AddWithValue("Otv", addOtvTB.Text);

                    command.ExecuteNonQuery();


                    MaterialMessageBox.Show("Добавлено!");


                    addTimeDtp.Value = DateTime.Now;
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

        private void materialButton13_Click(object sender, EventArgs e)
        {
            addBreakePanel.Visible = false;
        }

        private void showAddPanelBtn_Click(object sender, EventArgs e)
        {
            addBreakePanel.Visible = true;   
        }
        //Это что вобще за хрень?????????????
        private void makeDocBtn_Click(object sender, EventArgs e)
        {
            string s = "";

           

            //Создаём новый Word.Application
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();

            //Загружаем документ
            Microsoft.Office.Interop.Word.Document doc = null;

            object fileName = @"C:\Users\YTO4KA\OneDrive\Рабочий стол\дилпом\diplom\Акт поломка.docx";
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
            object findText = "<номер>";
            object replaceWith = BreakeDVG.CurrentRow.Cells[0].Value.ToString();
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
            replaceWith = BreakeDVG.CurrentRow.Cells[1].Value.ToString();
            replace = 2;

            app.Selection.Find.Execute(ref findText, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing, ref missing, ref missing, ref replaceWith,
            ref replace, ref missing, ref missing, ref missing, ref missing);

            app.Visible = true;

            //Очищаем параметры поиска
            app.Selection.Find.ClearFormatting();
            app.Selection.Find.Replacement.ClearFormatting();

            //Задаём параметры замены и выполняем замену.
            findText = "<гарном>";
            replaceWith = BreakeDVG.CurrentRow.Cells[2].Value.ToString();
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

        private void materialButton3_Click(object sender, EventArgs e)
        {
            if (MaterialMessageBox.Show("Вы точно хотите удалить выбранную запись!", "Внимание!", MessageBoxButtons.YesNo, UseRichTextBox: true) == DialogResult.Yes)
            {
                SqlCommand command = new SqlCommand("DELETE FROM Breake WHERE Id_b = @Id", sqlConnection);
                int id = int.Parse(BreakeDVG.CurrentRow.Cells[0].Value.ToString());
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    command.ExecuteNonQuery();
                    MaterialMessageBox.Show("Запись удалена!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MaterialMessageBox.Show("Не удалось удалить запись!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            LoadData();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
