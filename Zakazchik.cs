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
using System.Xml.Linq;

namespace PR7
{
    public partial class Zakazchik : Form
    {
        private BindingSource bindingSource2 = new BindingSource();
        private string connectionString = @"Server=(localdb)\test;Database=Cloth;Trusted_Connection=True;";
        string loginUser = "";
        private BackgroundWorker backgroundWorker;
        string articleTovar = "";
        public Zakazchik(string loginUser)
        {
            InitializeComponent();
            this.loginUser = loginUser;

            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
        }

        private DataTable GetDataFromDatabase(string tableName, string check)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"SELECT * FROM [{tableName}] {check}";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dataTable);
            }
            return dataTable;
        }

        private void LoadDatabase(string tableName, string check)
        {
            DataTable dataTable = GetDataFromDatabase(tableName, check);
            dataTable.TableName = tableName;
            if (dataTable.Rows.Count == 0)
            {
                dataGridView1.Visible = false;
                labelWarning.Visible = true;
            }
            else
            {
                bindingSource2.DataSource = dataTable;
                dataGridView1.DataSource = bindingSource2;
                dataGridView1.Visible = true;
            }
        }

        private DataTable GetDataFromDatabase2(string tableName, string check)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"SELECT Заказ.*, [Заказанные изделия$].[Артикул изделия], [Заказанные изделия$].Количество " +
                               $"FROM [{tableName}] Заказ " +
                               $"INNER JOIN [Заказанные изделия$] [Заказанные изделия$] " +
                               $"ON Заказ.[Номер] = [Заказанные изделия$].[Номер заказа] " +
                               $"{check}";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dataTable);
            }
            return dataTable;
        }

        private void LoadDatabase2(string tableName, string check)
        {
            DataTable dataTable = GetDataFromDatabase2(tableName, check);
            dataTable.TableName = tableName;
            if (dataTable.Rows.Count == 0)
            {
                dataGridView1.Visible = false;
                labelWarning.Visible = true;
            }
            else
            {
                bindingSource2.DataSource = dataTable;
                dataGridView1.DataSource = bindingSource2;
                dataGridView1.Visible = true;
            }
        }


        private void Zakazchik_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(181, 213, 202);
            dataGridView1.BackgroundColor = Color.FromArgb(181, 213, 202);
        }

        private void выйтиИзАккаунтаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void списокЗаказовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            pictureBoxImageTovar.Visible = false;
            flowLayoutPanel1.Visible = false;
            labelDlina.Visible = false;
            labelShirina.Visible = false;
            labelArticle.Visible = false;
            numericColichestvo.Visible = false;
            buttonBuy.Visible = false;
            flowLayoutPanel1.Controls.Clear();
            LoadDatabase2("Заказ$", $"WHERE [Заказчик] COLLATE SQL_Latin1_General_CP1_CS_AS = '{loginUser}'");
        }

        private void оформлениеЗаказаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            labelWarning.Visible = false;
            flowLayoutPanel1.Visible = false;
            progressBarLoading.Visible = true;

            this.Enabled = false;

            flowLayoutPanel1.Controls.Clear();

            if (!backgroundWorker.IsBusy)
            {
                backgroundWorker.RunWorkerAsync();
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            DataTable dataTable = GetDataFromDatabase("Изделие$", "");
            int yOffset = 0;
            int totalItems = dataTable.Rows.Count;

            for (int i = 0; i < totalItems; i++)
            {
                string article = dataTable.Rows[i]["Артикул"].ToString();

                try
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Size = new System.Drawing.Size(100, 100);
                    pictureBox.Location = new System.Drawing.Point(10, yOffset);
                    pictureBox.Tag = article;
                    pictureBox.Image = Image.FromFile($"C://Users//name//Downloads//Хохулин А, Хохулин В//ПР7/images//Изделия//{article}.JPG");
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.Click += PictureBox_Click;

                    this.Invoke(new Action(() =>
                    {
                        flowLayoutPanel1.Controls.Add(pictureBox);
                    }));

                    yOffset += 210;
                }
                catch (Exception)
                {
                    Button button = new Button();
                    button.Text = $"Артикул {article}";
                    button.Size = new System.Drawing.Size(100, 100);
                    button.Location = new System.Drawing.Point(10, yOffset);
                    button.Tag = article;
                    button.Click += Button_Click;

                    this.Invoke(new Action(() =>
                    {
                        flowLayoutPanel1.Controls.Add(button);
                    }));

                    yOffset += 35;
                }

                int progress = (int)((i + 1) / (float)totalItems * 100);
                backgroundWorker.ReportProgress(progress);
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarLoading.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBarLoading.Visible = false;
            flowLayoutPanel1.Visible = true;
            this.Enabled = true;
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox clickedPictureBox = sender as PictureBox;

            if (clickedPictureBox != null)
            {
                string article = clickedPictureBox.Tag.ToString();
                articleTovar = article;
                //MessageBox.Show($"Артикул: {article}");
                LoadInformationTovar(article);
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                string article = clickedButton.Tag.ToString();
                articleTovar = article;
                //MessageBox.Show($"Артикул: {article}");
                LoadInformationTovar(article);
            }
        }

        private void LoadInformationTovar(string article)
        {
            flowLayoutPanel1.Focus();
            labelDlina.Visible = true;
            labelShirina.Visible = true;
            labelArticle.Visible = true;
            numericColichestvo.Visible = true;
            buttonBuy.Visible = true;
            pictureBoxImageTovar.Visible = true;
            numericColichestvo.Value = 1;
            try
            {
                pictureBoxImageTovar.Image = Image.FromFile($"C://Users//name//Downloads//Хохулин А, Хохулин В//ПР7/images//Изделия//{article}.JPG");
            }
            catch (Exception ex)
            {
                pictureBoxImageTovar.Image = Image.FromFile($"C://Users//name//Downloads//Хохулин А, Хохулин В//ПР7/images//nophoto.png");
            }


            string shirina = "";
            string dlina = "";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string checkQuery = "SELECT [Ширина], [Длина] FROM [Изделие$] WHERE [Артикул] COLLATE SQL_Latin1_General_CP1_CS_AS = @article";

                using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@article", article);

                    using (SqlDataReader reader = checkCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            shirina = reader["Ширина"].ToString();
                            dlina = reader["Длина"].ToString();
                        }
                    }
                }
                labelArticle.Text = $"Артикул: {article}";
                labelDlina.Text = $"Длина: {dlina}см";
                labelShirina.Text = $"Ширина: {shirina}см";
            }
        }

        private void buttonBuy_Click(object sender, EventArgs e)
        {
            string max = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string checkQuery = "SELECT MAX([Номер]) FROM [Заказ$];";

                using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                {
                    using (SqlDataReader reader = checkCommand.ExecuteReader())
                    {
                        if (reader.Read() && !reader.IsDBNull(0))
                        {
                            max = reader.GetValue(0).ToString();
                        }
                    }
                }
            }
            CreateZakaz(Convert.ToInt32(max));
        }
        public void CreateZakaz(int number)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO [Заказ$] ([Номер], [Дата], [Этап выполнения], [Заказчик], [Менеджер], [Стоимость]) VALUES (@number, @date, @atap, @zakazchik, null, null)";
                using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                {
                    insertCommand.Parameters.AddWithValue("@number", number+1);
                    insertCommand.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    insertCommand.Parameters.AddWithValue("@atap", "Новый");
                    insertCommand.Parameters.AddWithValue("@zakazchik", loginUser);

                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        CreateZakazIzdel(number+1, articleTovar);
                    }
                    else
                    {
                        MessageBox.Show("ERROR");
                    }
                }
            }
        }
        public void CreateZakazIzdel(int number, string article)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO [Заказанные изделия$] ([Номер заказа], [Артикул изделия], [Количество]) VALUES (@number, @article, @count)";
                using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                {
                    insertCommand.Parameters.AddWithValue("@number", number);
                    insertCommand.Parameters.AddWithValue("@article", articleTovar);
                    insertCommand.Parameters.AddWithValue("@count", Convert.ToInt32(numericColichestvo.Value));

                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Вы успешно заказали изделие! Вы можете посмотреть состояние своего заказа в разделе 'Список заказов'!");
                    }
                    else
                    {
                        MessageBox.Show("Zakaz not success");
                    }
                }
            }
        }
    }
}
