using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace diplom
{
    public partial class Form1 : MaterialForm
    {
        public SqlConnection sqlConnection = null;
        string scon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\YTO4KA\OneDrive\Рабочий стол\дилпом\diplom\diplom\DiplomDB.mdf"";Integrated Security=True";
        private DataSet dataSet = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private SqlCommandBuilder sqlBuilder = null;
        public SqlCommand sqlCommand = null;
        int rowIndex = 0;
        public Form1()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Blue800, Primary.Blue500, Accent.Blue200, TextShade.WHITE);
            sqlConnection = new SqlConnection(scon);
            sqlConnection.Open();
            LoadData();
        }
        public void LoadData()
        {
            try
            {
                
                if (materialTabControl1.SelectedIndex == 4)
                {
                    sqlDataAdapter = new SqlDataAdapter("select Id_mark, Name AS [Наименование]  from Marks", sqlConnection);
                    sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);
                    dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet, "Marks");
                    MarksDVG.DataSource = dataSet.Tables["Marks"];
                    MarksDVG.Columns["Id_mark"].Visible = false;
                    MarksDVG.Columns[1].Width = 150;
                }
                else if (materialTabControl1.SelectedIndex == 3)
                {
                    sqlDataAdapter = new SqlDataAdapter("select Id_dr, Surname as [Фамилия], Name as [Имя], Lastname as [Отчество]  from Drivers", sqlConnection);
                    sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);
                    dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet, "Drivers");
                    DriversDVG.DataSource = dataSet.Tables["Drivers"];
                    DriversDVG.Columns["Id_dr"].Visible = false;
                    DriversDVG.Columns[3].Width = 150;
                }
                else if (materialTabControl1.SelectedIndex == 2)
                {
                    sqlDataAdapter = new SqlDataAdapter("select GarageNum as [Гаражный номер], GosNum as [Гос.Номер], concat(Drivers.Surname, ' ', Left(Drivers.Name,1), '. ', Left(Drivers.Lastname,1), '.') as [ФИО],\r\nMarks.Name as [Марка], Bus.Id_dr, Bus.Id_mark from Bus, Drivers, Marks where Bus.Id_dr = Drivers.Id_dr and Bus.Id_mark = Marks.Id_mark", sqlConnection);
                    sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);
                    dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet, "Bus");
                    BusDVG.DataSource = dataSet.Tables["Bus"];
                    BusDVG.Columns[3].Width = 70;
                    BusDVG.Columns["Id_mark"].Visible = false;
                    BusDVG.Columns["Id_dr"].Visible = false;
                    SqlCommand cmd1 = new SqlCommand("Select Id_dr, concat(Drivers.Surname, ' ', Left(Drivers.Name,1), '. ', Left(Drivers.Lastname,1), '.') as [ФИО] from Drivers", sqlConnection);
                    DataTable tbl1 = new DataTable();
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                    da1.Fill(tbl1);
                    driverBusCM.DataSource = tbl1;
                    driverBusCM.DisplayMember = "ФИО";// столбец для отображения
                    driverBusCM.ValueMember = "Id_dr";//столбец с id
                    driverBusCM.SelectedIndex = -1;
                    changeDriverBusCB.DataSource = tbl1;
                    changeDriverBusCB.DisplayMember = "ФИО";// столбец для отображения
                    changeDriverBusCB.ValueMember = "Id_dr";//столбец с id
                    changeDriverBusCB.SelectedIndex = -1;
                    SqlCommand cmd2 = new SqlCommand("Select Id_mark, Name as [Марка] from Marks", sqlConnection);
                    DataTable tbl2 = new DataTable();
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                    da2.Fill(tbl2);
                    markBusCB.DataSource = tbl2;
                    markBusCB.DisplayMember = "Марка";// столбец для отображения
                    markBusCB.ValueMember = "Id_mark";//столбец с id
                    markBusCB.SelectedIndex = -1;
                    changeMarkBusCB.DataSource = tbl2;
                    changeMarkBusCB.DisplayMember = "Марка";// столбец для отображения
                    changeMarkBusCB.ValueMember = "Id_mark"; //столбец с id
                    changeMarkBusCB.SelectedIndex = -1;
                }
                else if (materialTabControl1.SelectedIndex == 1)
                {
                    sqlDataAdapter = new SqlDataAdapter("select Id_m, Name as [Наименование], Type as [Тип], Categ as [Категория]  from MatCen", sqlConnection);
                    sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);
                    dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet, "MatCen");
                    MCDVG.DataSource = dataSet.Tables["MatCen"];
                    MCDVG.Columns["Id_m"].Visible = false;
                    MCDVG.Columns[1].Width = 120;
                    CatMCCB.SelectedIndex = -1;
                    typeMCCB.SelectedIndex = -1;
                }
                else if (materialTabControl1.SelectedIndex == 0)
                {
                    sqlDataAdapter = new SqlDataAdapter("select id_ch, concat(Bus.GosNum, '(', Marks.Name,')') as [Автобус],MatCen.Name as [Предмет замены], MatCen.Type as [Тип], MatCen.Categ as [Категория],format(Change.Date_ch,'dd.MM.yyyy') as [Дата замены], Change.Reason, Bus.GarageNum, MatCen.Id_m\r\nfrom Change, Bus, MatCen, Marks\r\nWhere Change.GarageNum = Bus.GarageNum and Bus.Id_mark = Marks.Id_mark and Change.Id_m = MatCen.Id_m", sqlConnection);
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


            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show(ex.Message, "Ошибка!");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            sqlConnection = new SqlConnection(scon);
            sqlConnection.Open();
            LoadData();
        }

        private void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void addMarkBtn_Click(object sender, EventArgs e)
        {
            if (nameMarkTB.Text != "")
            {
                try
                {
                    SqlCommand command = new SqlCommand($"INSERT INTO Marks (Name) VALUES (@Name)", sqlConnection);

                    command.Parameters.AddWithValue("Name", nameMarkTB.Text);

                    command.ExecuteNonQuery();


                    MaterialMessageBox.Show("Добавлено!");
                    LoadData();
                    nameMarkTB.Text = "";
                    AddMarkPanel.Visible = false;
                }
                catch (Exception ex) { MaterialMessageBox.Show("Проверьте введённые данные", "Ошибка"); }
            }
            else { MaterialMessageBox.Show("Заполните все поля", "Ошибка"); }
        }

        private void changeMarkBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (changeNameMarkTB.Text != "")
                {

                    SqlCommand sqlCommand = new SqlCommand($"update Marks set Name = N'{changeNameMarkTB.Text}' WHERE Id_mark = {MarksDVG[0, MarksDVG.CurrentRow.Index].Value}", sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    LoadData();

                    changeNameMarkTB.Text = "";
                    ChangeMarkPanel.Visible=false;

                }
                else
                {
                    MessageBox.Show("Заполните все строки");
                }
            }
            catch (Exception ex) { MaterialMessageBox.Show(ex.Message, "Ошибка!"); }
        }

        private void MarksDVG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
            if (rowIndex != -1)
            {
                changeNameMarkTB.Text = MarksDVG.Rows[rowIndex].Cells[1].Value.ToString();

            }
        }

        private void deleteMarkBtn_Click(object sender, EventArgs e)
        {
            if (MaterialMessageBox.Show("Вы точно хотите удалить выбранную запись!", "Внимание!", MessageBoxButtons.YesNo, UseRichTextBox: true) == DialogResult.Yes)
            {
                SqlCommand command = new SqlCommand("DELETE FROM Marks WHERE Id_mark = @Id", sqlConnection);
                int id = int.Parse(MarksDVG.CurrentRow.Cells[0].Value.ToString());
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

        private void UpdateMarksBtn_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void searchMatksTB_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < MarksDVG.RowCount; i++)
            {
                MarksDVG.Rows[rowIndex].Selected = false;
                for (int j = 0; j < MarksDVG.ColumnCount; j++)
                    if (MarksDVG.Rows[i].Cells[j].Value != null)
                        if (MarksDVG.Rows[i].Cells[j].Value.ToString().Contains(searchMatksTB.Text))
                        {
                            MarksDVG.Rows[i].Selected = true;
                            break;
                        }
            }
        }

        private void addDriverBtn_Click(object sender, EventArgs e)
        {
            if (nameDriverTB.Text != "" && surnameDriverTB.Text != "" && lastnameDriverTB.Text != "")
            {
                try
                {
                    SqlCommand command = new SqlCommand($"INSERT INTO Drivers (Name,Surname,Lastname) VALUES (@Name,@Surname,@Lastname)", sqlConnection);

                    command.Parameters.AddWithValue("Name", nameDriverTB.Text);
                    command.Parameters.AddWithValue("Surname", surnameDriverTB.Text);
                    command.Parameters.AddWithValue("Lastname", lastnameDriverTB.Text);

                    command.ExecuteNonQuery();


                    MaterialMessageBox.Show("Добавлено!");
                    LoadData();
                    nameDriverTB.Text = "";
                    surnameDriverTB.Text = "";
                    lastnameDriverTB.Text = "";
                    AddDriverPanel.Visible = false;
                }
                catch (Exception ex) { MaterialMessageBox.Show("Проверьте введённые данные", "Ошибка"); }
            }
            else { MaterialMessageBox.Show("Заполните все поля", "Ошибка"); }
        }

        private void DriversDVG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
            if (rowIndex != -1)
            {
                changeSurnameDriverTB.Text = DriversDVG.Rows[rowIndex].Cells[1].Value.ToString();
                changeNameDriverTB.Text = DriversDVG.Rows[rowIndex].Cells[2].Value.ToString();
                changeLastnameDriverTB.Text = DriversDVG.Rows[rowIndex].Cells[3].Value.ToString();

            }
        }

        private void changeDriverBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (changeNameDriverTB.Text != "" && changeSurnameDriverTB.Text != "" && changeLastnameDriverTB.Text != "")
                {

                    SqlCommand sqlCommand = new SqlCommand($"update Drivers set Name = N'{changeNameDriverTB.Text}', Surname = N'{changeSurnameDriverTB.Text}', Lastname = N'{changeLastnameDriverTB.Text}' WHERE Id_dr = {DriversDVG[0, DriversDVG.CurrentRow.Index].Value}", sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    LoadData();

                    changeSurnameDriverTB.Text = "";
                    changeNameDriverTB.Text = "";
                    changeLastnameDriverTB.Text = "";


                }
                else
                {
                    MessageBox.Show("Заполните все строки");
                }
            }
            catch (Exception ex) { MaterialMessageBox.Show(ex.Message, "Ошибка!"); }
        }

        private void deleteDriverBtn_Click(object sender, EventArgs e)
        {
            if (MaterialMessageBox.Show("Вы точно хотите удалить выбранную запись!", "Внимание!", MessageBoxButtons.YesNo, UseRichTextBox: true) == DialogResult.Yes)
            {
                SqlCommand command = new SqlCommand("DELETE FROM Drivers WHERE Id_dr = @Id", sqlConnection);
                int id = int.Parse(DriversDVG.CurrentRow.Cells[0].Value.ToString());
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

        private void updateDriversBtn_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void searchDriverTB_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < DriversDVG.RowCount; i++)
            {
                DriversDVG.Rows[rowIndex].Selected = false;
                for (int j = 0; j < DriversDVG.ColumnCount; j++)
                    if (DriversDVG.Rows[i].Cells[j].Value != null)
                        if (DriversDVG.Rows[i].Cells[j].Value.ToString().Contains(searchDriverTB.Text))
                        {
                            DriversDVG.Rows[i].Selected = true;
                            break;
                        }
            }
        }

        private void searchDriverTB_Click(object sender, EventArgs e)
        {

        }

        private void addBusBtn_Click(object sender, EventArgs e)
        {
            if (garnumBusTB.Text != "" && gosnumBusTB.Text != "" && driverBusCM.SelectedIndex != -1 && markBusCB.SelectedIndex != -1)
            {
                try
                {
                    SqlCommand command = new SqlCommand($"INSERT INTO Bus (GarageNum, GosNum, Id_dr, Id_mark) VALUES (@GarageNum, @GosNum, @Id_dr, @Id_mark)", sqlConnection);

                    command.Parameters.AddWithValue("GarageNum", garnumBusTB.Text);
                    command.Parameters.AddWithValue("GosNum", gosnumBusTB.Text);
                    command.Parameters.AddWithValue("Id_dr", driverBusCM.SelectedValue);
                    command.Parameters.AddWithValue("Id_mark", markBusCB.SelectedValue);

                    command.ExecuteNonQuery();


                    MaterialMessageBox.Show("Добавлено!");
                    LoadData();
                    gosnumBusTB.Text = "";
                    garnumBusTB.Text = "";
                    driverBusCM.SelectedIndex = -1;
                    markBusCB.SelectedIndex = -1;
                    AddBusPanel.Visible = false;
                }
                catch (Exception ex) { MaterialMessageBox.Show("Проверьте введённые данные", "Ошибка"); }
            }
            else { MaterialMessageBox.Show("Заполните все поля", "Ошибка"); }
        }

        private void BusDVG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
            if (rowIndex != -1)
            {
                changeGarnumBusTB.Text = BusDVG.Rows[rowIndex].Cells[0].Value.ToString();
                changeGosnumBusTB.Text = BusDVG.Rows[rowIndex].Cells[1].Value.ToString();
                changeDriverBusCB.SelectedValue = Convert.ToInt32(BusDVG.Rows[rowIndex].Cells[4].Value.ToString());
                changeMarkBusCB.SelectedValue = Convert.ToInt32(BusDVG.Rows[rowIndex].Cells[5].Value.ToString());
            }
        }

        private void deleteBusBtn_Click(object sender, EventArgs e)
        {
            if (MaterialMessageBox.Show("Вы точно хотите удалить выбранную запись!", "Внимание!", MessageBoxButtons.YesNo, UseRichTextBox: true) == DialogResult.Yes)
            {
                SqlCommand command = new SqlCommand("DELETE FROM Bus WHERE GarageNum = @Id", sqlConnection);
                int id = int.Parse(BusDVG.CurrentRow.Cells[0].Value.ToString());
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

        private void materialButton15_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void materialTextBox24_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < BusDVG.RowCount; i++)
            {
                BusDVG.Rows[i].Selected = false;
                for (int j = 0; j < BusDVG.ColumnCount; j++)
                    if (BusDVG.Rows[i].Cells[j].Value != null)
                        if (BusDVG.Rows[i].Cells[j].Value.ToString().Contains(materialTextBox24.Text))
                        {
                            BusDVG.Rows[i].Selected = true;
                            break;
                        }
            }
        }

        private void changeBusBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (changeGarnumBusTB.Text != "" && changeGosnumBusTB.Text != "" && changeDriverBusCB.SelectedIndex != -1 && changeMarkBusCB.SelectedIndex != -1)
                {

                    SqlCommand sqlCommand = new SqlCommand($"update Bus set GarageNum = N'{changeGarnumBusTB.Text}', GosNum = N'{changeGosnumBusTB.Text}', Id_dr = N'{changeDriverBusCB.SelectedValue}', Id_mark = N'{changeMarkBusCB.SelectedValue}' WHERE GarageNum = N'{BusDVG[0, BusDVG.CurrentRow.Index].Value}'", sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    LoadData();

                    changeGarnumBusTB.Text = "";
                    changeGosnumBusTB.Text = "";
                    changeDriverBusCB.SelectedIndex = -1;
                    changeMarkBusCB.SelectedIndex = -1;
                    ChangeBusPanel.Visible = false;
                }
                else
                {
                    MessageBox.Show("Заполните все строки");
                }
            }
            catch (Exception ex) { MaterialMessageBox.Show(ex.Message, "Ошибка!"); }
        }

        private void CatMCCB_TextChanged(object sender, EventArgs e)
        {
            typeMCCB.Items.Clear();
            string[] items = { "Моторное масло", "Трансмиссионное масло", "Антифриз", "Тормнозная жидкость" };
            string[] items1 = { "Аккумулятор", "Масленный фильтр", "Топливный фильтр", "Воздушный фильтр", "Тормозные колодки" };
            if (CatMCCB.Text == "ТЖ")
            {
                
                typeMCCB.Items.AddRange(items);
            }
            else if (CatMCCB.Text == "Агрегат")
            {
                
                typeMCCB.Items.AddRange(items1);

            }
        }

        private void addMCBtn_Click(object sender, EventArgs e)
        {
            if (nameMCTB.Text != "" && CatMCCB.SelectedIndex != -1 && typeMCCB.SelectedIndex != -1 && anotherSwitch.Checked == false)
            {
                try
                {
                    SqlCommand command = new SqlCommand($"INSERT INTO MatCen (Name, Categ, Type) VALUES (@Name, @Categ, @Type)", sqlConnection);

                    command.Parameters.AddWithValue("Name", nameMCTB.Text);
                    command.Parameters.AddWithValue("Categ", CatMCCB.Text);
                    command.Parameters.AddWithValue("Type", typeMCCB.Text);

                    command.ExecuteNonQuery();


                    MaterialMessageBox.Show("Добавлено!");
                    LoadData();
                    nameMCTB.Text = "";
                    CatMCCB.SelectedIndex = -1;
                    typeMCCB.SelectedIndex = -1;
                    anotherSwitch.Checked = false;
                    AddMCPanel.Visible = false;
            }
                catch (Exception ex) { MaterialMessageBox.Show("Проверьте введённые данные", "Ошибка"); }
        }
            else if (nameMCTB.Text != "" && CatMCCB.SelectedIndex != -1 && anotherTB.Text != "" && anotherSwitch.Checked == true)
            {
                try
                {
                    SqlCommand command = new SqlCommand($"INSERT INTO MatCen (Name, Categ, Type) VALUES (@Name, @Categ, @Type)", sqlConnection);

                    command.Parameters.AddWithValue("Name", nameMCTB.Text);
                    command.Parameters.AddWithValue("Categ", CatMCCB.Text);
                    command.Parameters.AddWithValue("Type", anotherTB.Text);

                    command.ExecuteNonQuery();


                    MaterialMessageBox.Show("Добавлено!");
                    LoadData();
                    nameMCTB.Text = "";
                    CatMCCB.SelectedIndex = -1;
                    anotherTB.Text = "";
                    anotherSwitch.Checked = false;

                }
                catch (Exception ex) { MaterialMessageBox.Show("Проверьте введённые данные", "Ошибка"); }
            }
            else { MaterialMessageBox.Show("Заполните все поля", "Ошибка"); }
        }

        private void anotherSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (anotherSwitch.Checked == true)
            {
                anotherTB.Visible = true;
                typeMCCB.Visible = false;
            }
            else { anotherTB.Visible = false; typeMCCB.Visible = true; }
        }

        private void MCDVG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
            if (rowIndex != -1)
            {
                changeNameMCTB.Text = MCDVG.Rows[rowIndex].Cells[1].Value.ToString();
                changeCatMCCB.Text = MCDVG.Rows[rowIndex].Cells[2].Value.ToString();
                ChangeTypeMCTB.Text = MCDVG.Rows[rowIndex].Cells[3].Value.ToString();

            }
        }

        private void changeMCBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (changeNameMCTB.Text != "" && ChangeTypeMCTB.Text != "" && changeCatMCCB.SelectedIndex != -1)
                {

                    SqlCommand sqlCommand = new SqlCommand($"update MatCen set Name = N'{changeNameMCTB.Text}', Type = N'{ChangeTypeMCTB.Text}', Categ = N'{changeCatMCCB.Text}' WHERE Id_m = N'{MCDVG[0, MCDVG.CurrentRow.Index].Value}'", sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    LoadData();

                    changeNameMCTB.Text = "";
                    ChangeTypeMCTB.Text = "";
                    changeCatMCCB.SelectedIndex = -1;
                   ChangeMCPanel.Enabled = false;

                }
                else
                {
                    MessageBox.Show("Заполните все строки");
                }
            }
            catch (Exception ex) { MaterialMessageBox.Show(ex.Message, "Ошибка!"); }
        }

        private void searchMCTB_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < MCDVG.RowCount; i++)
            {
                MCDVG.Rows[i].Selected = false;
                for (int j = 0; j < MCDVG.ColumnCount; j++)
                    if (MCDVG.Rows[i].Cells[j].Value != null)
                        if (MCDVG.Rows[i].Cells[j].Value.ToString().Contains(materialTextBox24.Text))
                        {
                            MCDVG.Rows[i].Selected = true;
                            break;
                        }
            }
        }

        private void Добавить_Click(object sender, EventArgs e)
        {
            addChangePanel.Visible = true;
        }

        private void addChangeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand($"INSERT INTO Change (GarageNum, Id_m, Reason, Date) VALUES (@GarageNum, @Id_m, @Reason,@Date)", sqlConnection);

                command.Parameters.AddWithValue("GarageNum", BusChangeCB.SelectedValue);
                command.Parameters.AddWithValue("Id_m", MCChangeCB.SelectedValue);
                command.Parameters.AddWithValue("Reason", ReasonChangeCB.Text);
                command.Parameters.AddWithValue("Date", addChangeDateDtp.Value.Date.ToString("yyyyMMdd"));

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

       

        private void ChangeDVG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
            if (rowIndex != -1)
            {
                changeBusChangeCB.SelectedValue = (ChangeDVG.Rows[rowIndex].Cells[7].Value.ToString());
                ChangeMCChangeCB.SelectedValue = Convert.ToInt32(ChangeDVG.Rows[rowIndex].Cells[8].Value.ToString());
                ChangeReasonChangeCB.Text = ChangeDVG.Rows[rowIndex].Cells[6].Value.ToString();
                ChangeChangeDateDtp.Value = Convert.ToDateTime( ChangeDVG.Rows[rowIndex].Cells[5].Value);

            }
        }

     

        private void materialTextBox21_TextChanged(object sender, EventArgs e)
        {
            string searchText = ChangeSearchTB.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                ChangeDVG.ClearSelection();
                return;
            }

            foreach (DataGridViewRow row in ChangeDVG.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().ToLower().Contains(searchText))
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }
        }

        private void ShowAddPanelBusBtn_Click(object sender, EventArgs e)
        {
            AddMarkPanel.Visible = true;
        }

        private void ShowChangeBusPanelBtn_Click(object sender, EventArgs e)
        {
            ChangeMarkPanel.Visible = true; 
        }

        private void ShowAddBusPanelBtn_Click(object sender, EventArgs e)
        {
            AddDriverPanel.Visible = true;
        }

        private void ShowChangeDriverPanelBtn_Click(object sender, EventArgs e)
        {
            ChangeDriverPanel.Visible= true;
        }

        private void ShowAddBusPanel_Click(object sender, EventArgs e)
        {
            AddBusPanel.Visible = true;
        }

        private void ShowChangeBusBtn_Click(object sender, EventArgs e)
        {
            ChangeBusPanel.Visible= true;
        }

        private void ShowAddMCPAnelBtn_Click(object sender, EventArgs e)
        {
            AddMCPanel.Visible = true;
        }

        private void materialButton5_Click(object sender, EventArgs e)
        {
            ChangeMCPanel.Visible = true;
        }

        private void materialButton5_Click_1(object sender, EventArgs e)
        {
            AddMCPanel.Visible = false;
        }

        private void materialButton6_Click(object sender, EventArgs e)
        {
            ChangeMCPanel.Visible = false;
        }

        private void materialButton7_Click(object sender, EventArgs e)
        {
            ChangeBusPanel.Visible = false;
        }

        private void materialButton8_Click(object sender, EventArgs e)
        {
            AddBusPanel.Visible = false;
        }

        private void materialButton10_Click(object sender, EventArgs e)
        {
            AddDriverPanel.Visible = false;
        }

        private void materialButton9_Click(object sender, EventArgs e)
        {
            ChangeDriverPanel.Visible = false;
        }

        private void materialButton11_Click(object sender, EventArgs e)
        {
            AddMarkPanel.Visible = false;
        }

        private void materialButton12_Click(object sender, EventArgs e)
        {
            ChangeMarkPanel.Visible = false;
        }

        private void materialButton13_Click(object sender, EventArgs e)
        {
            addChangePanel.Visible = false;
        }

        private void materialButton14_Click(object sender, EventArgs e)
        {
            ChangeChangePanel.Visible = false;
        }

        private void materialButton4_Click(object sender, EventArgs e)
        {
            ChangeChangePanel.Visible = true;
        }

        private void ChangeChangeBtn_Click(object sender, EventArgs e)
        {
            //try
            //{
                if (changeBusChangeCB.SelectedIndex != -1 && ChangeMCChangeCB.SelectedIndex != -1 && ChangeReasonChangeCB.SelectedIndex != -1)
                {

                    SqlCommand sqlCommand = new SqlCommand($"update Change set GarageNum = N'{changeBusChangeCB.SelectedValue}', Id_m = {ChangeMCChangeCB.SelectedValue}, Reason = N'{ChangeReasonChangeCB.Text}',Date_ch = '{ChangeChangeDateDtp.Value.Date.ToString("yyyyMMdd")}' WHERE Id_ch = N'{ChangeDVG[0, ChangeDVG.CurrentRow.Index].Value}'", sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    LoadData();
                    changeBusChangeCB.SelectedIndex = -1;
                    ChangeMCChangeCB.SelectedIndex = -1;
                    ChangeReasonChangeCB.SelectedIndex = -1;
                    ChangeChangePanel.Visible = false;

                }
                else
                {
                    MessageBox.Show("Заполните все строки");
                }
            //}
            //catch (Exception ex) { MaterialMessageBox.Show(ex.Message, "Ошибка!"); }
        }

        private void materialButton2_Click(object sender, EventArgs e)
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

    }
}
