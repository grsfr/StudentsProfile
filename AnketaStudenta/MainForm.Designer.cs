namespace AnketaStudenta
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            //  объявление контролов 
            this.mainLayout       = new System.Windows.Forms.TableLayoutPanel();

            // Языковая панель
            this.pnlLanguage      = new System.Windows.Forms.Panel();
            this.lblLanguage      = new System.Windows.Forms.Label();
            this.btnRU            = new System.Windows.Forms.Button();
            this.btnEN            = new System.Windows.Forms.Button();

            // Личные данные
            this.gbPersonal       = new System.Windows.Forms.GroupBox();
            this.lblFullName      = new System.Windows.Forms.Label();
            this.txtFullName      = new System.Windows.Forms.TextBox();
            this.dataText         = new System.Windows.Forms.Label();
            this.dtpBirthDate     = new System.Windows.Forms.DateTimePicker();
            this.genderPanel      = new System.Windows.Forms.FlowLayoutPanel();
            this.rbText           = new System.Windows.Forms.Label();
            this.rbMale           = new System.Windows.Forms.RadioButton();
            this.rbFemale         = new System.Windows.Forms.RadioButton();
            this.courceText       = new System.Windows.Forms.Label();

            // Таблица курсов
            this.coursesTable     = new System.Windows.Forms.TableLayoutPanel();
            this.chkCourse1       = new System.Windows.Forms.CheckBox();
            this.chkCourse2       = new System.Windows.Forms.CheckBox();
            this.chkCourse3       = new System.Windows.Forms.CheckBox();
            this.chkCourse4       = new System.Windows.Forms.CheckBox();
            this.chkCourse5       = new System.Windows.Forms.CheckBox();
            this.chkCourse6       = new System.Windows.Forms.CheckBox();
            this.chkCourse7       = new System.Windows.Forms.CheckBox();
            this.chkCourse8       = new System.Windows.Forms.CheckBox();
            this.chkCourse9       = new System.Windows.Forms.CheckBox();
            this.chkCourse10      = new System.Windows.Forms.CheckBox();
            this.lblCN1           = new System.Windows.Forms.Label();
            this.lblCN2           = new System.Windows.Forms.Label();
            this.lblCN3           = new System.Windows.Forms.Label();
            this.lblCN4           = new System.Windows.Forms.Label();
            this.lblCN5           = new System.Windows.Forms.Label();
            this.lblCN6           = new System.Windows.Forms.Label();
            this.lblCN7           = new System.Windows.Forms.Label();
            this.lblCN8           = new System.Windows.Forms.Label();
            this.lblCN9           = new System.Windows.Forms.Label();
            this.lblCN10          = new System.Windows.Forms.Label();

            this.cmbSpeciality    = new System.Windows.Forms.ComboBox();

            // Хобби
            this.gbHobbies        = new System.Windows.Forms.GroupBox();
            this.hobbiesLayout    = new System.Windows.Forms.TableLayoutPanel();
            this.chkSport         = new System.Windows.Forms.CheckBox();
            this.chkMusic         = new System.Windows.Forms.CheckBox();
            this.chkProgramming   = new System.Windows.Forms.CheckBox();
            this.chkReading       = new System.Windows.Forms.CheckBox();
            this.chkTravel        = new System.Windows.Forms.CheckBox();
            this.chkPhoto         = new System.Windows.Forms.CheckBox();

            // Панель кнопок
            this.buttonPanel      = new System.Windows.Forms.FlowLayoutPanel();
            this.btnResult        = new System.Windows.Forms.Button();
            this.btnClear         = new System.Windows.Forms.Button();
            this.btnExportPDF     = new System.Windows.Forms.Button();
            this.btnExportWord    = new System.Windows.Forms.Button();

            // Дополнительно
            this.gbExtra          = new System.Windows.Forms.GroupBox();
            this.extraLayout      = new System.Windows.Forms.TableLayoutPanel();
            this.pbStudentPhoto   = new System.Windows.Forms.PictureBox();
            this.btnLoadPhoto     = new System.Windows.Forms.Button();
            this.lblPhotoName     = new System.Windows.Forms.Label();
            this.pbQRCode         = new System.Windows.Forms.PictureBox();
            this.btnGenerateQR    = new System.Windows.Forms.Button();

            // SuspendLayout 
            this.mainLayout.SuspendLayout();
            this.pnlLanguage.SuspendLayout();
            this.gbPersonal.SuspendLayout();
            this.genderPanel.SuspendLayout();
            this.coursesTable.SuspendLayout();
            this.gbHobbies.SuspendLayout();
            this.hobbiesLayout.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.gbExtra.SuspendLayout();
            this.extraLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStudentPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbQRCode)).BeginInit();
            this.SuspendLayout();

            //  mainLayout  — корневая таблица, 5 строк
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(
                System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(this.pnlLanguage, 0, 0);
            this.mainLayout.Controls.Add(this.gbPersonal,  0, 1);
            this.mainLayout.Controls.Add(this.gbHobbies,   0, 2);
            this.mainLayout.Controls.Add(this.buttonPanel, 0, 3);
            this.mainLayout.Controls.Add(this.gbExtra,     0, 4);
            this.mainLayout.Dock     = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Name     = "mainLayout";
            this.mainLayout.RowCount = 5;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(
                System.Windows.Forms.SizeType.Absolute,  28F)); // языковая панель
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(
                System.Windows.Forms.SizeType.Absolute, 165F)); // личные данные
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(
                System.Windows.Forms.SizeType.Absolute, 90F)); // хобби
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(
                System.Windows.Forms.SizeType.Absolute,  45F)); // кнопки
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(
                System.Windows.Forms.SizeType.Percent,  60F)); // дополнительно
            this.mainLayout.TabIndex = 0;

            //  pnlLanguage  — языковая панель (RU / EN)
            this.pnlLanguage.Controls.Add(this.lblLanguage);
            this.pnlLanguage.Controls.Add(this.btnRU);
            this.pnlLanguage.Controls.Add(this.btnEN);
            this.pnlLanguage.Dock    = System.Windows.Forms.DockStyle.Fill;
            this.pnlLanguage.Name    = "pnlLanguage";
            this.pnlLanguage.Padding = new System.Windows.Forms.Padding(6, 2, 6, 0);

            this.lblLanguage.AutoSize  = true;
            this.lblLanguage.Location  = new System.Drawing.Point(8, 5);
            this.lblLanguage.Name      = "lblLanguage";
            this.lblLanguage.Text      = "Язык / Language:";
            this.lblLanguage.ForeColor = System.Drawing.Color.DimGray;

            this.btnRU.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
            this.btnRU.Location   = new System.Drawing.Point(138, 1);
            this.btnRU.Name       = "btnRU";
            this.btnRU.Size       = new System.Drawing.Size(36, 22);
            this.btnRU.TabIndex   = 0;
            this.btnRU.Text       = "RU";
            this.btnRU.BackColor  = System.Drawing.Color.SteelBlue;
            this.btnRU.ForeColor  = System.Drawing.Color.White;
            this.btnRU.Font       = new System.Drawing.Font("Segoe UI", 8F,
                System.Drawing.FontStyle.Bold);
            this.btnRU.Click     += new System.EventHandler(this.BtnRU_Click);

            this.btnEN.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
            this.btnEN.Location   = new System.Drawing.Point(180, 1);
            this.btnEN.Name       = "btnEN";
            this.btnEN.Size       = new System.Drawing.Size(36, 22);
            this.btnEN.TabIndex   = 1;
            this.btnEN.Text       = "EN";
            this.btnEN.BackColor  = System.Drawing.SystemColors.Control;
            this.btnEN.Font       = new System.Drawing.Font("Segoe UI", 8F,
                System.Drawing.FontStyle.Bold);
            this.btnEN.Click     += new System.EventHandler(this.BtnEN_Click);

            //  gbPersonal  — «Личные данные»
            this.gbPersonal.Controls.Add(this.lblFullName);
            this.gbPersonal.Controls.Add(this.txtFullName);
            this.gbPersonal.Controls.Add(this.dataText);
            this.gbPersonal.Controls.Add(this.dtpBirthDate);
            this.gbPersonal.Controls.Add(this.genderPanel);
            this.gbPersonal.Controls.Add(this.courceText);
            this.gbPersonal.Controls.Add(this.coursesTable);
            this.gbPersonal.Controls.Add(this.cmbSpeciality);
            this.gbPersonal.Dock    = System.Windows.Forms.DockStyle.Fill;
            this.gbPersonal.Margin  = new System.Windows.Forms.Padding(8, 2, 8, 2);
            this.gbPersonal.Name    = "gbPersonal";
            this.gbPersonal.TabStop = false;
            this.gbPersonal.Text    = "Личные данные";

            // ФИО
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(18, 24);
            this.lblFullName.Name     = "lblFullName";
            this.lblFullName.Text     = "ФИО:";

            // Текстовое поле ФИО
            this.txtFullName.Location = new System.Drawing.Point(118, 21);
            this.txtFullName.Name     = "txtFullName";
            this.txtFullName.Size     = new System.Drawing.Size(250, 20);
            this.txtFullName.TabIndex = 1;

            // Дата рождения
            this.dataText.AutoSize = true;
            this.dataText.Location = new System.Drawing.Point(18, 52);
            this.dataText.Name     = "dataText";
            this.dataText.Text     = "Дата рождения:";

            this.dtpBirthDate.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthDate.Location = new System.Drawing.Point(118, 49);
            this.dtpBirthDate.Name     = "dtpBirthDate";
            this.dtpBirthDate.Size     = new System.Drawing.Size(120, 20);
            this.dtpBirthDate.TabIndex = 2;

            // Пол
            this.genderPanel.Controls.Add(this.rbText);
            this.genderPanel.Controls.Add(this.rbMale);
            this.genderPanel.Controls.Add(this.rbFemale);
            this.genderPanel.Location = new System.Drawing.Point(265, 45);
            this.genderPanel.Name     = "genderPanel";
            this.genderPanel.Size     = new System.Drawing.Size(185, 28);
            this.genderPanel.TabIndex = 3;

            this.rbText.AutoSize  = true;
            this.rbText.Dock      = System.Windows.Forms.DockStyle.Left;
            this.rbText.Name      = "rbText";
            this.rbText.Text      = "Пол:";
            this.rbText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.rbMale.AutoSize = true;
            this.rbMale.Name     = "rbMale";
            this.rbMale.TabIndex = 0;
            this.rbMale.TabStop  = true;
            this.rbMale.Text     = "М";
            this.rbMale.UseVisualStyleBackColor = true;

            this.rbFemale.AutoSize = true;
            this.rbFemale.Name     = "rbFemale";
            this.rbFemale.TabIndex = 1;
            this.rbFemale.TabStop  = true;
            this.rbFemale.Text     = "Ж";
            this.rbFemale.UseVisualStyleBackColor = true;

            // Курсы
            this.courceText.AutoSize = true;
            this.courceText.Location = new System.Drawing.Point(18, 84);
            this.courceText.Name     = "courceText";
            this.courceText.Text     = "Курс:";

            this.coursesTable.ColumnCount = 10;
            this.coursesTable.RowCount    = 2;
            for (int ci = 0; ci < 10; ci++)
                this.coursesTable.ColumnStyles.Add(
                    new System.Windows.Forms.ColumnStyle(
                        System.Windows.Forms.SizeType.Absolute, 24F));
            this.coursesTable.RowStyles.Add(
                new System.Windows.Forms.RowStyle(
                    System.Windows.Forms.SizeType.Absolute, 18F));
            this.coursesTable.RowStyles.Add(
                new System.Windows.Forms.RowStyle(
                    System.Windows.Forms.SizeType.Absolute, 14F));
            this.coursesTable.Location = new System.Drawing.Point(118, 76);
            this.coursesTable.Name     = "coursesTable";
            this.coursesTable.Size     = new System.Drawing.Size(240, 34);
            this.coursesTable.TabIndex = 4;

            System.Windows.Forms.CheckBox[] cboxes = {
                chkCourse1, chkCourse2, chkCourse3, chkCourse4, chkCourse5,
                chkCourse6, chkCourse7, chkCourse8, chkCourse9, chkCourse10
            };
            System.Windows.Forms.Label[] cnums = {
                lblCN1, lblCN2, lblCN3, lblCN4, lblCN5,
                lblCN6, lblCN7, lblCN8, lblCN9, lblCN10
            };
            for (int i = 0; i < 10; i++)
            {
                cboxes[i].AutoSize  = false;
                cboxes[i].Size      = new System.Drawing.Size(16, 16);
                cboxes[i].Margin    = new System.Windows.Forms.Padding(4, 1, 4, 1);
                cboxes[i].Name      = "chkCourse" + (i + 1);
                cboxes[i].TabIndex  = i;
                cboxes[i].Tag       = (i + 1).ToString();
                cboxes[i].Text      = "";
                cboxes[i].UseVisualStyleBackColor = true;
                this.coursesTable.Controls.Add(cboxes[i], i, 0);

                cnums[i].AutoSize  = false;
                cnums[i].Size      = new System.Drawing.Size(24, 14);
                cnums[i].Margin    = new System.Windows.Forms.Padding(0);
                cnums[i].Name      = "lblCN" + (i + 1);
                cnums[i].Text      = (i + 1).ToString();
                cnums[i].TextAlign = System.Drawing.ContentAlignment.TopCenter;
                this.coursesTable.Controls.Add(cnums[i], i, 1);
            }

            this.cmbSpeciality.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpeciality.FormattingEnabled = true;
            this.cmbSpeciality.Items.AddRange(new object[] {
                "Выберите специальность",
                "Информационные системы и программирование",
                "Компьютерные системы и комплексы",
                "Сетевое и системное администрирование",
                "Обеспечение информационной безопасности",
                "Веб-разработка",
                "Мобильная разработка"
            });
            this.cmbSpeciality.Location = new System.Drawing.Point(18, 124);
            this.cmbSpeciality.Name     = "cmbSpeciality";
            this.cmbSpeciality.Size     = new System.Drawing.Size(270, 21);
            this.cmbSpeciality.TabIndex = 6;

            //  gbHobbies  — «Хобби»

            this.gbHobbies.Controls.Add(this.hobbiesLayout);
            this.gbHobbies.Dock    = System.Windows.Forms.DockStyle.Fill;
            this.gbHobbies.Margin  = new System.Windows.Forms.Padding(8, 2, 8, 2);
            this.gbHobbies.Name    = "gbHobbies";
            this.gbHobbies.TabStop = false;
            this.gbHobbies.Text    = "Хобби";

            this.hobbiesLayout.ColumnCount = 3;
            this.hobbiesLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(
                System.Windows.Forms.SizeType.Percent, 33.33F));
            this.hobbiesLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(
                System.Windows.Forms.SizeType.Percent, 33.33F));
            this.hobbiesLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(
                System.Windows.Forms.SizeType.Percent, 33.34F));
            this.hobbiesLayout.Controls.Add(this.chkSport,       0, 0);
            this.hobbiesLayout.Controls.Add(this.chkMusic,       1, 0);
            this.hobbiesLayout.Controls.Add(this.chkProgramming, 2, 0);
            this.hobbiesLayout.Controls.Add(this.chkReading,     0, 1);
            this.hobbiesLayout.Controls.Add(this.chkTravel,      1, 1);
            this.hobbiesLayout.Controls.Add(this.chkPhoto,       2, 1);
            this.hobbiesLayout.Dock     = System.Windows.Forms.DockStyle.Fill;
            this.hobbiesLayout.Name     = "hobbiesLayout";
            this.hobbiesLayout.RowCount = 2;
            this.hobbiesLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(
                System.Windows.Forms.SizeType.Percent, 50F));
            this.hobbiesLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(
                System.Windows.Forms.SizeType.Percent, 50F));

            System.Windows.Forms.CheckBox[] hboxes = {
                chkSport, chkMusic, chkProgramming, chkReading, chkTravel, chkPhoto
            };
            string[] htexts = {
                "Спорт", "Музыка", "Программирование",
                "Чтение", "Путешествия", "Фотография"
            };
            for (int i = 0; i < hboxes.Length; i++)
            {
                hboxes[i].AutoSize = true;
                hboxes[i].Dock     = System.Windows.Forms.DockStyle.None;
                hboxes[i].Margin   = new System.Windows.Forms.Padding(14, 8, 4, 4);
                hboxes[i].Name     = "chk" + htexts[i];
                hboxes[i].TabIndex = i;
                hboxes[i].Tag      = htexts[i];
                hboxes[i].Text     = htexts[i];
                hboxes[i].UseVisualStyleBackColor = true;
            }

            //  buttonPanel 

            this.buttonPanel.Controls.Add(this.btnClear);
            this.buttonPanel.Controls.Add(this.btnResult);
            this.buttonPanel.Controls.Add(this.btnExportWord);
            this.buttonPanel.Controls.Add(this.btnExportPDF);
            this.buttonPanel.Dock          = System.Windows.Forms.DockStyle.Fill;
            this.buttonPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.buttonPanel.WrapContents  = true;
            this.buttonPanel.Margin        = new System.Windows.Forms.Padding(8, 2, 8, 2);
            this.buttonPanel.Name          = "buttonPanel";
            this.buttonPanel.Padding       = new System.Windows.Forms.Padding(0, 4, 4, 0);

            this.btnClear.BackColor = System.Drawing.Color.LightGray;
            this.btnClear.Margin    = new System.Windows.Forms.Padding(6, 0, 0, 4);
            this.btnClear.Name      = "btnClear";
            this.btnClear.Size      = new System.Drawing.Size(82, 38);
            this.btnClear.TabIndex  = 1;
            this.btnClear.Text      = "Очистить";
            this.btnClear.UseVisualStyleBackColor = false;

            this.btnResult.BackColor = System.Drawing.Color.LightGreen;
            this.btnResult.Margin    = new System.Windows.Forms.Padding(6, 0, 0, 4);
            this.btnResult.Name      = "btnResult";
            this.btnResult.Size      = new System.Drawing.Size(82, 38);
            this.btnResult.TabIndex  = 0;
            this.btnResult.Text      = "Результат";
            this.btnResult.UseVisualStyleBackColor = false;

            this.btnExportWord.BackColor = System.Drawing.Color.FromArgb(197, 224, 179);
            this.btnExportWord.Margin    = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.btnExportWord.Name      = "btnExportWord";
            this.btnExportWord.Size      = new System.Drawing.Size(82, 36);
            this.btnExportWord.TabIndex  = 3;
            this.btnExportWord.Text      = "Word";
            this.btnExportWord.UseVisualStyleBackColor = false;
            this.btnExportWord.Click    += new System.EventHandler(this.BtnExportWord_Click);

            this.btnExportPDF.BackColor = System.Drawing.Color.FromArgb(255, 199, 160);
            this.btnExportPDF.Margin    = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.btnExportPDF.Name      = "btnExportPDF";
            this.btnExportPDF.Size      = new System.Drawing.Size(82, 36);
            this.btnExportPDF.TabIndex  = 2;
            this.btnExportPDF.Text      = "PDF";
            this.btnExportPDF.UseVisualStyleBackColor = false;
            this.btnExportPDF.Click    += new System.EventHandler(this.BtnExportPDF_Click);

            //  gbExtra  — «Дополнительно»
            this.gbExtra.Controls.Add(this.extraLayout);
            this.gbExtra.Dock    = System.Windows.Forms.DockStyle.Fill;
            this.gbExtra.Margin  = new System.Windows.Forms.Padding(8, 2, 8, 6);
            this.gbExtra.Name    = "gbExtra";
            this.gbExtra.Padding = new System.Windows.Forms.Padding(8);
            this.gbExtra.TabStop = false;
            this.gbExtra.Text    = "Дополнительно";

            this.extraLayout.ColumnCount = 2;
            this.extraLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(
                System.Windows.Forms.SizeType.Percent, 38F));
            this.extraLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(
                System.Windows.Forms.SizeType.Percent, 62F));
            this.extraLayout.Controls.Add(this.pbStudentPhoto, 0, 0);
            this.extraLayout.Controls.Add(this.btnLoadPhoto,   0, 1);
            this.extraLayout.Controls.Add(this.lblPhotoName,   0, 2);
            this.extraLayout.Controls.Add(this.pbQRCode,       1, 0);
            this.extraLayout.Controls.Add(this.btnGenerateQR,  1, 1);
            this.extraLayout.Dock     = System.Windows.Forms.DockStyle.Fill;
            this.extraLayout.Name     = "extraLayout";
            this.extraLayout.RowCount = 3;
            this.extraLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(
                System.Windows.Forms.SizeType.Percent, 100F));
            this.extraLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(
                System.Windows.Forms.SizeType.Absolute, 42F));
            this.extraLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(
                System.Windows.Forms.SizeType.Absolute, 18F));

            this.pbStudentPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbStudentPhoto.Dock        = System.Windows.Forms.DockStyle.Fill;
            this.pbStudentPhoto.Margin      = new System.Windows.Forms.Padding(4);
            this.pbStudentPhoto.Name        = "pbStudentPhoto";
            this.pbStudentPhoto.SizeMode    = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbStudentPhoto.TabStop     = false;

            this.btnLoadPhoto.Dock     = System.Windows.Forms.DockStyle.Fill;
            this.btnLoadPhoto.Margin   = new System.Windows.Forms.Padding(4, 4, 4, 2);
            this.btnLoadPhoto.Name     = "btnLoadPhoto";
            this.btnLoadPhoto.TabIndex = 1;
            this.btnLoadPhoto.Text     = "Загрузить фото";
            this.btnLoadPhoto.UseVisualStyleBackColor = true;
            this.btnLoadPhoto.Click   += new System.EventHandler(this.BtnLoadPhoto_Click);

            this.lblPhotoName.AutoSize  = false;
            this.lblPhotoName.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.lblPhotoName.ForeColor = System.Drawing.Color.DimGray;
            this.lblPhotoName.Margin    = new System.Windows.Forms.Padding(4, 0, 4, 2);
            this.lblPhotoName.Name      = "lblPhotoName";
            this.lblPhotoName.Text      = "";
            this.lblPhotoName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.pbQRCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbQRCode.Dock        = System.Windows.Forms.DockStyle.Fill;
            this.pbQRCode.Margin      = new System.Windows.Forms.Padding(4);
            this.pbQRCode.Name        = "pbQRCode";
            this.pbQRCode.SizeMode    = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbQRCode.TabStop     = false;

            this.btnGenerateQR.Dock     = System.Windows.Forms.DockStyle.Fill;
            this.btnGenerateQR.Margin   = new System.Windows.Forms.Padding(4, 4, 4, 2);
            this.btnGenerateQR.Name     = "btnGenerateQR";
            this.btnGenerateQR.TabIndex = 3;
            this.btnGenerateQR.Text     = "Сгенерировать QR-код";
            this.btnGenerateQR.UseVisualStyleBackColor = true;
            this.btnGenerateQR.Click   += new System.EventHandler(this.BtnGenerateQR_Click);

            //  MainForm
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode  = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize     = new System.Drawing.Size(500, 600);
            this.MinimumSize    = new System.Drawing.Size(510, 600);
            this.Controls.Add(this.mainLayout);
            this.Name = "MainForm";
            this.Text = "Анкета студента";

            // ResumeLayout 
            this.mainLayout.ResumeLayout(false);
            this.pnlLanguage.ResumeLayout(false);
            this.pnlLanguage.PerformLayout();
            this.gbPersonal.ResumeLayout(false);
            this.gbPersonal.PerformLayout();
            this.genderPanel.ResumeLayout(false);
            this.genderPanel.PerformLayout();
            this.coursesTable.ResumeLayout(false);
            this.gbHobbies.ResumeLayout(false);
            this.hobbiesLayout.ResumeLayout(false);
            this.hobbiesLayout.PerformLayout();
            this.buttonPanel.ResumeLayout(false);
            this.gbExtra.ResumeLayout(false);
            this.extraLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbStudentPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbQRCode)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        // Объявления полей 
        private System.Windows.Forms.TableLayoutPanel mainLayout;

        private System.Windows.Forms.Panel           pnlLanguage;
        private System.Windows.Forms.Label           lblLanguage;
        private System.Windows.Forms.Button          btnRU;
        private System.Windows.Forms.Button          btnEN;

        private System.Windows.Forms.GroupBox        gbPersonal;
        private System.Windows.Forms.Label           lblFullName;
        private System.Windows.Forms.TextBox         txtFullName;
        private System.Windows.Forms.Label           dataText;
        private System.Windows.Forms.DateTimePicker  dtpBirthDate;
        private System.Windows.Forms.FlowLayoutPanel genderPanel;
        private System.Windows.Forms.Label           rbText;
        private System.Windows.Forms.RadioButton     rbMale;
        private System.Windows.Forms.RadioButton     rbFemale;
        private System.Windows.Forms.Label           courceText;
        private System.Windows.Forms.TableLayoutPanel coursesTable;
        private System.Windows.Forms.CheckBox        chkCourse1, chkCourse2, chkCourse3, chkCourse4, chkCourse5;
        private System.Windows.Forms.CheckBox        chkCourse6, chkCourse7, chkCourse8, chkCourse9, chkCourse10;
        private System.Windows.Forms.Label           lblCN1, lblCN2, lblCN3, lblCN4, lblCN5;
        private System.Windows.Forms.Label           lblCN6, lblCN7, lblCN8, lblCN9, lblCN10;
        private System.Windows.Forms.ComboBox        cmbSpeciality;

        private System.Windows.Forms.GroupBox        gbHobbies;
        private System.Windows.Forms.TableLayoutPanel hobbiesLayout;
        private System.Windows.Forms.CheckBox        chkSport;
        private System.Windows.Forms.CheckBox        chkMusic;
        private System.Windows.Forms.CheckBox        chkProgramming;
        private System.Windows.Forms.CheckBox        chkReading;
        private System.Windows.Forms.CheckBox        chkTravel;
        private System.Windows.Forms.CheckBox        chkPhoto;

        private System.Windows.Forms.FlowLayoutPanel buttonPanel;
        private System.Windows.Forms.Button          btnResult;
        private System.Windows.Forms.Button          btnClear;
        private System.Windows.Forms.Button          btnExportPDF;
        private System.Windows.Forms.Button          btnExportWord;

        private System.Windows.Forms.GroupBox        gbExtra;
        private System.Windows.Forms.TableLayoutPanel extraLayout;
        private System.Windows.Forms.PictureBox      pbStudentPhoto;
        private System.Windows.Forms.Button          btnLoadPhoto;
        private System.Windows.Forms.Label           lblPhotoName;
        private System.Windows.Forms.PictureBox      pbQRCode;
        private System.Windows.Forms.Button          btnGenerateQR;
    }
}
