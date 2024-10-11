using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace PR7
{
    public partial class Form1 : Form
    {

        private string connectionString = @"Server=(localdb)\test;Database=Cloth;Trusted_Connection=True;";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(181, 213, 202);
            buttonVhod.BackColor = Color.FromArgb(224, 169, 175);
        }

        int count = 4;
        bool avtorization = true;

        private void buttonVhod_Click(object sender, EventArgs e)
        {
            if (avtorization)
            {
                if (textBoxLogin.Text != "" && textBoxPassword.Text != "")
                {
                    if(!textBoxLogin.Text.Contains(" ") && !textBoxPassword.Text.Contains(" "))
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string checkQuery = $"SELECT COUNT(*) FROM [Пользователь$] WHERE [Логин] COLLATE SQL_Latin1_General_CP1_CS_AS = @login AND [Пароль] COLLATE SQL_Latin1_General_CP1_CS_AS = @password";

                            using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                            {
                                checkCommand.Parameters.AddWithValue("@login", textBoxLogin.Text);
                                checkCommand.Parameters.AddWithValue("@password", textBoxPassword.Text);

                                int counts = (int)checkCommand.ExecuteScalar();

                                if (counts > 0)
                                {
                                    Vhod(textBoxLogin.Text);
                                }
                                else if (count > 1)
                                {
                                    count -= 1;
                                    MessageBox.Show($"Неверный логин или пароль!\n Осталось {count} попытки!");
                                }
                                else if (count == 1)
                                {
                                    MessageBox.Show($"Попытки исчерпаны!\n Повторите позже!");
                                    Application.Exit();
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Введите логин и пароль без пробелов!");
                    }
                }
                else
                {
                    MessageBox.Show($"Введите логин и пароль!");
                }
            }
            else
            {
                if (textBoxLogin.Text != "" && textBoxPassword.Text != "" && textBoxName.Text != "")
                {
                    if (!textBoxLogin.Text.Contains(" ") && !textBoxPassword.Text.Contains(" "))
                    {
                        if (textBoxName.Text.First() != ' ' && textBoxName.Text.Last() != ' ')
                        {
                            if (textBoxLogin.Text.Length < 4) { MessageBox.Show("Минимальное количество символов в логине 4!"); return; }
                            if (textBoxPassword.Text.Length < 4) { MessageBox.Show("Минимальное количество символов в пароле 4!"); return; }
                            if (textBoxName.Text.Length < 4) { MessageBox.Show("Минимальное количество символов в наименовании 4!"); return; }
                            if (textBoxLogin.Text.Length > 16) { MessageBox.Show("Максимальное количество символов в логине 16!"); return; }
                            if (textBoxPassword.Text.Length > 16) { MessageBox.Show("Максимальное количество символов в пароле 16!"); return; }
                            if (textBoxName.Text.Length > 32) { MessageBox.Show("Максимальное количество символов в наименовании 32!"); return; }
                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                connection.Open();

                                string checkQuery = $"SELECT COUNT(*) FROM [Пользователь$] WHERE [Логин] COLLATE SQL_Latin1_General_CP1_CS_AS = @login";

                                using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                                {
                                    checkCommand.Parameters.AddWithValue("@login", textBoxLogin.Text);

                                    int counts = (int)checkCommand.ExecuteScalar();

                                    if (counts == 0)
                                    {
                                        Create(textBoxLogin.Text, textBoxPassword.Text, textBoxName.Text);
                                    }
                                    else
                                    {
                                        MessageBox.Show($"Пользователь с таким логином уже зарегистрирован!");
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show($"Пробел в наименовании не должен быть первым и последним!");
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Введите логин и пароль без пробелов!");
                    }
                }
                else
                {
                    MessageBox.Show($"Введите логин, пароль и наименование!");
                }
            }
        }

        private void Vhod(string login)
        {  
            string role = "";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string checkQuery = "SELECT [Роль] FROM [Пользователь$] WHERE [Логин] COLLATE SQL_Latin1_General_CP1_CS_AS = @login AND [Пароль] COLLATE SQL_Latin1_General_CP1_CS_AS = @password";

                using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@login", textBoxLogin.Text);
                    checkCommand.Parameters.AddWithValue("@password", textBoxPassword.Text);

                    using (SqlDataReader reader = checkCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            role = reader["Роль"].ToString();
                        }
                    }
                }

                switch(role)
                {
                    case "Заказчик":
                        Zakazchik zakazchik = new Zakazchik(login);
                        zakazchik.Show();
                        this.Visible = false;
                        break;
                    case "Менеджер":
                        Manager manager = new Manager(login);
                        manager.Show();
                        this.Visible = false;
                        break;
                    case "Кладовщик":
                        Cladovchik cladovchik = new Cladovchik(login);
                        cladovchik.Show();
                        this.Visible = false;
                        break;
                    case "Руководитель":
                        Director director = new Director(login);
                        director.Show();
                        this.Visible = false;
                        break;
                    default:
                        MessageBox.Show("Вашей роли не существует :(");
                        break;
                }
            }
        }

        private void Create(string login, string password, string name)
        {
            string role = "Заказчик";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO [Пользователь$] ([Логин], [Пароль], [Роль], [Наименование]) VALUES (@login, @password, @role, @name)";
                using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                {
                    insertCommand.Parameters.AddWithValue("@login", login);
                    insertCommand.Parameters.AddWithValue("@password", password);
                    insertCommand.Parameters.AddWithValue("@role", role);
                    insertCommand.Parameters.AddWithValue("@name", name);

                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Вы успешно зарегестрировались!");
                        Zakazchik zakazchik = new Zakazchik(login);
                        zakazchik.Show();
                        this.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при создании пользователя");
                    }
                }
            }
        }

        private void labelChange_Click(object sender, EventArgs e)
        {
            if(avtorization)
            {
                avtorization = false;
                labelBig.Text = "Регистрация";
                labelChange.Text = "Есть аккаунт? Авторизироваться";
                textBoxLogin.Text = "";
                textBoxPassword.Text = "";
                textBoxName.Text = "";            
                textBoxName.Visible = true;
                labelName.Visible = true;
                buttonVhod.Location = new Point(163, 340);
                labelChange.Location = new Point(227, 306);
            }
            else
            {
                avtorization = true;
                labelBig.Text = "Авторизация";
                labelChange.Text = "Нету аккаунта? Зарегистрироваться";
                textBoxLogin.Text = "";
                textBoxPassword.Text = "";
                textBoxName.Text = "";
                textBoxName.Visible = false;
                labelName.Visible = false;
                buttonVhod.Location = new Point(161, 283);
                labelChange.Location = new Point(221, 257);
            }
        }
    }
}
