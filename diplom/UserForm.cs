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
using Excel = Microsoft.Office.Interop.Excel;


namespace diplom
{
    public partial class UserForm : MaterialForm
    {
        public SqlConnection sqlConnection = null;
        string scon = @"";
        private DataSet dataSet = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private SqlCommandBuilder sqlBuilder = null;
        public SqlCommand sqlCommand = null;
        int rowIndex = 0;
        DateTime dateTime = DateTime.Now;
        public UserForm()
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
            sqlDataAdapter = new SqlDataAdapter("select id_ch, concat(Bus.GosNum, '(', Marks.Name,')') as [Автобус],MatCen.Name as [Предмет замены], MatCen.Type as [Тип], MatCen.Categ as [Категория],format(Change.Date_ch,'dd.MM.yyyy') as [Дата замены], Change.Reason as [Причина], Bus.GarageNum, MatCen.Id_m\r\nfrom Change, Bus, MatCen, Marks\r\nWhere Change.GarageNum = Bus.GarageNum and Bus.Id_mark = Marks.Id_mark and Change.Id_m = MatCen.Id_m", sqlConnection);
            sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);
            dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "Change");
            ChangeDVG.DataSource = dataSet.Tables["Change"];
            ChangeDVG.Columns["Id_ch"].Visible = false;
            ChangeDVG.Columns["GarageNum"].Visible = false;
            ChangeDVG.Columns["Id_m"].Visible = false;
            ChangeDVG.Columns[1].Width = 120;
            ChangeDVG.Columns[3].Width = 150;
            SqlCommand cmd1 = new SqlCommand("Select GarageNum, concat(Bus.GosNum, '(', Marks.Name,')') as [Автобус] from Bus, Marks where Bus.Id_mark= Marks.Id_mark", sqlConnection);
            DataTable tbl1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(tbl1);
            BusChangeCB.DataSource = tbl1;
            BusChangeCB.DisplayMember = "Автобус";// столбец для отображения
            BusChangeCB.ValueMember = "GarageNum";//столбец с id
            BusChangeCB.SelectedIndex = -1;
            changeBusChangeCB.DataSource = tbl1;
            changeBusChangeCB.DisplayMember = "Автобус";// столбец для отображения
            changeBusChangeCB.ValueMember = "GarageNum";//столбец с id
            changeBusChangeCB.SelectedIndex = -1;
            SqlCommand cmd2 = new SqlCommand("Select Id_m, CONCAT(MatCen.Name,'(', MatCen.Type, ')') as [МЦ] from MatCen", sqlConnection);
            DataTable tbl2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(tbl2);
            MCChangeCB.DataSource = tbl2;
            MCChangeCB.DisplayMember = "МЦ";// столбец для отображения
            MCChangeCB.ValueMember = "Id_m";//столбец с id
            MCChangeCB.SelectedIndex = -1;
            ChangeMCChangeCB.DataSource = tbl2;
            ChangeMCChangeCB.DisplayMember = "МЦ";// столбец для отображения
            ChangeMCChangeCB.ValueMember = "Id_m";//столбец с id
            ChangeMCChangeCB.SelectedIndex = -1;
            ReasonChangeCB.SelectedIndex = -1;
        }
        private void UserForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void openAddChangePanelBtn_Click(object sender, EventArgs e)
        {
            addChangePanel.Visible = true;
        }

        private void materialButton4_Click(object sender, EventArgs e)
        {
            ChangeChangePanel.Visible = true;

        }

        private void ShowFilterChangeBtn_Click(object sender, EventArgs e)
        {
            filterPanel.Visible = true;
        }

        private void materialButton17_Click(object sender, EventArgs e)
        {
            if (ChangeDVG.CurrentRow.Cells[6].Value.ToString() == "Поломка" && ChangeDVG.CurrentRow.Cells[4].Value.ToString() == "Агрегат")
            {
                BreakeAgrForm form = new BreakeAgrForm();
                form.Show();
            }
            else if (ChangeDVG.CurrentRow.Cells[6].Value.ToString() == "Поломка" && ChangeDVG.CurrentRow.Cells[4].Value.ToString() == "ТЖ")
            {
                BreakeLiquidForm form = new BreakeLiquidForm();
                form.Show();
            }
            else if (ChangeDVG.CurrentRow.Cells[6].Value.ToString() == "ТО")
            {
                TOForm form = new TOForm();
                form.Show();
            }

        }
        private void ExportToExcel()
        {
            // Создание нового объекта Excel
            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = null;

            try
            {
                worksheet = workbook.ActiveSheet;

                int columnCount = 1;
                // Вывод названий колонок в Excel, исключая первый и последний столбец
                for (int i = 1; i < ChangeDVG.Columns.Count - 1; i++)
                {
                    worksheet.Cells[1, columnCount] = ChangeDVG.Columns[i].HeaderText;
                    columnCount++;
                }

                int rowCount = 2;
                // Заполнение данных из DataGridView в Excel, исключая первый и последний столбец
                for (int i = 0; i < ChangeDVG.Rows.Count; i++)
                {
                    columnCount = 1;
                    for (int j = 1; j < ChangeDVG.Columns.Count - 1; j++)
                    {
                        worksheet.Cells[rowCount, columnCount] = ChangeDVG.Rows[i].Cells[j].Value;
                        columnCount++;
                    }
                    rowCount++;
                }

                // Отображение Excel и сохранение файла
                excel.Visible = true;
                excel.UserControl = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при экспорте в Excel: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Освобождение ресурсов Excel
                worksheet = null;
                workbook = null;
                excel = null;
            }
        }

        private void materialButton18_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        private void DeleteChangeBtn_Click(object sender, EventArgs e)
        {
            if (MaterialMessageBox.Show("Вы точно хотите удалить выбранную запись!", "Внимание!", MessageBoxButtons.YesNo, UseRichTextBox: true) == DialogResult.Yes)
            {
                SqlCommand command = new SqlCommand("DELETE FROM Change WHERE Id_ch = @Id", sqlConnection);
                int id = int.Parse(ChangeDVG.CurrentRow.Cells[0].Value.ToString());
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

        private void materialButton16_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void filterReasonBtn_Click(object sender, EventArgs e)
        {
            sqlDataAdapter = new SqlDataAdapter($"select id_ch, concat(Bus.GosNum, '(', Marks.Name,')') as [Автобус],MatCen.Name as [Предмет замены], MatCen.Type as [Тип], MatCen.Categ as [Категория],format(Change.Date_ch,'dd.MM.yyyy') as [Дата замены], Change.Reason, Bus.GarageNum, MatCen.Id_m\r\nfrom Change, Bus, MatCen, Marks\r\nWhere Change.GarageNum = Bus.GarageNum and Bus.Id_mark = Marks.Id_mark and Change.Id_m = MatCen.Id_m and Reason = N'{filterReasonCB.Text}'", sqlConnection);
            sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);
            dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "Change");
            ChangeDVG.DataSource = dataSet.Tables["Change"];
            ChangeDVG.Columns["Id_ch"].Visible = false;
            ChangeDVG.Columns["GarageNum"].Visible = false;
            ChangeDVG.Columns["Id_m"].Visible = false;
            ChangeDVG.Columns[1].Width = 120;
            ChangeDVG.Columns[3].Width = 150;
            filterDatePanel.Visible = false;
        }

        private void showFilterDatePanelBtn_Click(object sender, EventArgs e)
        {
            filterDatePanel.Visible = true;
            filterPanel.Visible = false;
        }

        private void showFilterReasonPanelBtn_Click(object sender, EventArgs e)
        {
            filterReasonPanel.Visible = true;
            filterPanel.Visible = false;
        }

        private void showFilterCatPanelBtn_Click(object sender, EventArgs e)
        {
            filterCatPanel.Visible = true;
            filterPanel.Visible = false;
        }

        private void filterDateBtn_Click(object sender, EventArgs e)
        {
            sqlDataAdapter = new SqlDataAdapter($"select id_ch, concat(Bus.GosNum, '(', Marks.Name,')') as [Автобус],MatCen.Name as [Предмет замены], MatCen.Type as [Тип], MatCen.Categ as [Категория],format(Change.Date_ch,'dd.MM.yyyy') as [Дата замены], Change.Reason, Bus.GarageNum, MatCen.Id_m\r\nfrom Change, Bus, MatCen, Marks\r\nWhere Change.GarageNum = Bus.GarageNum and Bus.Id_mark = Marks.Id_mark and Change.Id_m = MatCen.Id_m and Date_ch between '{filterDateSDtp.Value.Date.ToString("yyyyMMdd")}' and '{filterDateEndDtp.Value.Date.ToString("yyyyMMdd")}'", sqlConnection);
            sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);
            dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "Change");
            ChangeDVG.DataSource = dataSet.Tables["Change"];
            ChangeDVG.Columns["Id_ch"].Visible = false;
            ChangeDVG.Columns["GarageNum"].Visible = false;
            ChangeDVG.Columns["Id_m"].Visible = false;
            ChangeDVG.Columns[1].Width = 120;
            ChangeDVG.Columns[3].Width = 150;
            filterDatePanel.Visible = false;
        }

        private void filterCatBtn_Click(object sender, EventArgs e)
        {
            sqlDataAdapter = new SqlDataAdapter($"select id_ch, concat(Bus.GosNum, '(', Marks.Name,')') as [Автобус],MatCen.Name as [Предмет замены], MatCen.Type as [Тип], MatCen.Categ as [Категория],format(Change.Date_ch,'dd.MM.yyyy') as [Дата замены], Change.Reason, Bus.GarageNum, MatCen.Id_m\r\nfrom Change, Bus, MatCen, Marks\r\nWhere Change.GarageNum = Bus.GarageNum and Bus.Id_mark = Marks.Id_mark and Change.Id_m = MatCen.Id_m and MatCen.Categ = N'{filterCatCB.Text}'", sqlConnection);
            sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);
            dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "Change");
            ChangeDVG.DataSource = dataSet.Tables["Change"];
            ChangeDVG.Columns["Id_ch"].Visible = false;
            ChangeDVG.Columns["GarageNum"].Visible = false;
            ChangeDVG.Columns["Id_m"].Visible = false;
            ChangeDVG.Columns[1].Width = 120;
            ChangeDVG.Columns[3].Width = 150;
            filterDatePanel.Visible = false;
        }

        private void ChangeDVG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
            if (rowIndex != -1)
            {
                changeBusChangeCB.SelectedValue = (ChangeDVG.Rows[rowIndex].Cells[7].Value.ToString());
                ChangeMCChangeCB.SelectedValue = Convert.ToInt32(ChangeDVG.Rows[rowIndex].Cells[8].Value.ToString());
                ChangeReasonChangeCB.Text = ChangeDVG.Rows[rowIndex].Cells[6].Value.ToString();
                ChangeChangeDateDtp.Value = Convert.ToDateTime(ChangeDVG.Rows[rowIndex].Cells[5].Value);
                DataHolder.ID = int.Parse(ChangeDVG.CurrentRow.Cells[0].Value.ToString());
            }
        }

        private void addChangeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand($"INSERT INTO Change (GarageNum, Id_m, Reason, Date_ch) VALUES (@GarageNum, @Id_m, @Reason,@Date)", sqlConnection);

                command.Parameters.AddWithValue("GarageNum", BusChangeCB.SelectedValue);
                command.Parameters.AddWithValue("Id_m", MCChangeCB.SelectedValue);
                command.Parameters.AddWithValue("Reason", ReasonChangeCB.Text);
                command.Parameters.AddWithValue("Date", dateTime);

                command.ExecuteNonQuery();


                MaterialMessageBox.Show("Добавлено!");
                LoadData();
                BusChangeCB.SelectedIndex = -1;
                MCChangeCB.SelectedIndex = -1;
                ReasonChangeCB.SelectedIndex = -1;
                addChangePanel.Visible = false;

            }
            catch (Exception ex) { MaterialMessageBox.Show("Проверьте введённые данные", "Ошибка"); }
        }
    }
}