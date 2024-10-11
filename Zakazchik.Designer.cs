namespace PR7
{
    partial class Zakazchik
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.оформлениеЗаказаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокЗаказовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выйтиИзАккаунтаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelWarning = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBoxImageTovar = new System.Windows.Forms.PictureBox();
            this.labelShirina = new System.Windows.Forms.Label();
            this.labelDlina = new System.Windows.Forms.Label();
            this.labelArticle = new System.Windows.Forms.Label();
            this.progressBarLoading = new System.Windows.Forms.ProgressBar();
            this.buttonBuy = new System.Windows.Forms.Button();
            this.numericColichestvo = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImageTovar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericColichestvo)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оформлениеЗаказаToolStripMenuItem,
            this.списокЗаказовToolStripMenuItem,
            this.выйтиИзАккаунтаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // оформлениеЗаказаToolStripMenuItem
            // 
            this.оформлениеЗаказаToolStripMenuItem.Name = "оформлениеЗаказаToolStripMenuItem";
            this.оформлениеЗаказаToolStripMenuItem.Size = new System.Drawing.Size(130, 20);
            this.оформлениеЗаказаToolStripMenuItem.Text = "Оформление заказа";
            this.оформлениеЗаказаToolStripMenuItem.Click += new System.EventHandler(this.оформлениеЗаказаToolStripMenuItem_Click);
            // 
            // списокЗаказовToolStripMenuItem
            // 
            this.списокЗаказовToolStripMenuItem.Name = "списокЗаказовToolStripMenuItem";
            this.списокЗаказовToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.списокЗаказовToolStripMenuItem.Text = "Список заказов";
            this.списокЗаказовToolStripMenuItem.Click += new System.EventHandler(this.списокЗаказовToolStripMenuItem_Click);
            // 
            // выйтиИзАккаунтаToolStripMenuItem
            // 
            this.выйтиИзАккаунтаToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.выйтиИзАккаунтаToolStripMenuItem.Name = "выйтиИзАккаунтаToolStripMenuItem";
            this.выйтиИзАккаунтаToolStripMenuItem.Size = new System.Drawing.Size(120, 20);
            this.выйтиИзАккаунтаToolStripMenuItem.Text = "Выйти из аккаунта";
            this.выйтиИзАккаунтаToolStripMenuItem.Click += new System.EventHandler(this.выйтиИзАккаунтаToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridView1.Location = new System.Drawing.Point(12, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(776, 403);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.Visible = false;
            // 
            // labelWarning
            // 
            this.labelWarning.AutoSize = true;
            this.labelWarning.BackColor = System.Drawing.Color.Transparent;
            this.labelWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWarning.Location = new System.Drawing.Point(265, 223);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(270, 20);
            this.labelWarning.TabIndex = 2;
            this.labelWarning.Text = "Вы еще ничего не заказывали!";
            this.labelWarning.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(7, 35);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(447, 403);
            this.flowLayoutPanel1.TabIndex = 6;
            this.flowLayoutPanel1.Visible = false;
            // 
            // pictureBoxImageTovar
            // 
            this.pictureBoxImageTovar.Location = new System.Drawing.Point(524, 43);
            this.pictureBoxImageTovar.Name = "pictureBoxImageTovar";
            this.pictureBoxImageTovar.Size = new System.Drawing.Size(200, 200);
            this.pictureBoxImageTovar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxImageTovar.TabIndex = 7;
            this.pictureBoxImageTovar.TabStop = false;
            this.pictureBoxImageTovar.Visible = false;
            // 
            // labelShirina
            // 
            this.labelShirina.AutoSize = true;
            this.labelShirina.BackColor = System.Drawing.Color.Transparent;
            this.labelShirina.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelShirina.Location = new System.Drawing.Point(487, 285);
            this.labelShirina.Name = "labelShirina";
            this.labelShirina.Size = new System.Drawing.Size(69, 18);
            this.labelShirina.TabIndex = 8;
            this.labelShirina.Text = "Ширина: ";
            this.labelShirina.Visible = false;
            // 
            // labelDlina
            // 
            this.labelDlina.AutoSize = true;
            this.labelDlina.BackColor = System.Drawing.Color.Transparent;
            this.labelDlina.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDlina.Location = new System.Drawing.Point(656, 285);
            this.labelDlina.Name = "labelDlina";
            this.labelDlina.Size = new System.Drawing.Size(57, 18);
            this.labelDlina.TabIndex = 9;
            this.labelDlina.Text = "Длина:";
            this.labelDlina.Visible = false;
            // 
            // labelArticle
            // 
            this.labelArticle.BackColor = System.Drawing.Color.Transparent;
            this.labelArticle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelArticle.Location = new System.Drawing.Point(524, 246);
            this.labelArticle.Name = "labelArticle";
            this.labelArticle.Size = new System.Drawing.Size(200, 18);
            this.labelArticle.TabIndex = 10;
            this.labelArticle.Text = "Артикул: ";
            this.labelArticle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelArticle.Visible = false;
            // 
            // progressBarLoading
            // 
            this.progressBarLoading.Location = new System.Drawing.Point(183, 224);
            this.progressBarLoading.Name = "progressBarLoading";
            this.progressBarLoading.Size = new System.Drawing.Size(463, 23);
            this.progressBarLoading.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarLoading.TabIndex = 11;
            this.progressBarLoading.Visible = false;
            // 
            // buttonBuy
            // 
            this.buttonBuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBuy.Location = new System.Drawing.Point(579, 348);
            this.buttonBuy.Name = "buttonBuy";
            this.buttonBuy.Size = new System.Drawing.Size(100, 30);
            this.buttonBuy.TabIndex = 12;
            this.buttonBuy.Text = "ЗАКАЗАТЬ";
            this.buttonBuy.UseVisualStyleBackColor = true;
            this.buttonBuy.Visible = false;
            this.buttonBuy.Click += new System.EventHandler(this.buttonBuy_Click);
            // 
            // numericColichestvo
            // 
            this.numericColichestvo.Location = new System.Drawing.Point(579, 316);
            this.numericColichestvo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericColichestvo.Name = "numericColichestvo";
            this.numericColichestvo.ReadOnly = true;
            this.numericColichestvo.Size = new System.Drawing.Size(100, 20);
            this.numericColichestvo.TabIndex = 13;
            this.numericColichestvo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericColichestvo.Visible = false;
            // 
            // Zakazchik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.numericColichestvo);
            this.Controls.Add(this.buttonBuy);
            this.Controls.Add(this.progressBarLoading);
            this.Controls.Add(this.labelArticle);
            this.Controls.Add(this.labelDlina);
            this.Controls.Add(this.labelShirina);
            this.Controls.Add(this.pictureBoxImageTovar);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.labelWarning);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Zakazchik";
            this.ShowIcon = false;
            this.Text = "Заказчик";
            this.Load += new System.EventHandler(this.Zakazchik_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImageTovar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericColichestvo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem выйтиИзАккаунтаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оформлениеЗаказаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокЗаказовToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelWarning;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBoxImageTovar;
        private System.Windows.Forms.Label labelShirina;
        private System.Windows.Forms.Label labelDlina;
        private System.Windows.Forms.Label labelArticle;
        private System.Windows.Forms.ProgressBar progressBarLoading;
        private System.Windows.Forms.Button buttonBuy;
        private System.Windows.Forms.NumericUpDown numericColichestvo;
    }
}