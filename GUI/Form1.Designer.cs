namespace GUI
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtpDatum = new System.Windows.Forms.DateTimePicker();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.btnEmailsenden = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.grpFahrplan = new System.Windows.Forms.GroupBox();
            this.rdoSuche = new System.Windows.Forms.RadioButton();
            this.rdoAbfahrt = new System.Windows.Forms.RadioButton();
            this.btnAbfahrt = new System.Windows.Forms.Button();
            this.lbxNach = new System.Windows.Forms.ListBox();
            this.lbxVon = new System.Windows.Forms.ListBox();
            this.txtNach = new System.Windows.Forms.TextBox();
            this.lblNach = new System.Windows.Forms.Label();
            this.lblVon = new System.Windows.Forms.Label();
            this.btnSuchen = new System.Windows.Forms.Button();
            this.txtVon = new System.Windows.Forms.TextBox();
            this.dgvFahrplan = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpGmap = new System.Windows.Forms.GroupBox();
            this.btnNear = new System.Windows.Forms.Button();
            this.lbxStation = new System.Windows.Forms.ListBox();
            this.btnclose = new System.Windows.Forms.Button();
            this.txtStation = new System.Windows.Forms.TextBox();
            this.btnGmaps = new System.Windows.Forms.Button();
            this.wbGmaps = new System.Windows.Forms.WebBrowser();
            this.grpFahrplan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFahrplan)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grpGmap.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpDatum
            // 
            this.dtpDatum.CustomFormat = "dd.MM.yyyy";
            this.dtpDatum.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDatum.Location = new System.Drawing.Point(287, 59);
            this.dtpDatum.MinDate = new System.DateTime(2018, 12, 12, 0, 0, 0, 0);
            this.dtpDatum.Name = "dtpDatum";
            this.dtpDatum.Size = new System.Drawing.Size(103, 20);
            this.dtpDatum.TabIndex = 5;
            this.dtpDatum.Value = new System.DateTime(2018, 12, 19, 11, 32, 55, 0);
            // 
            // dtpTime
            // 
            this.dtpTime.CustomFormat = "HH:mm";
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTime.Location = new System.Drawing.Point(287, 85);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.ShowUpDown = true;
            this.dtpTime.Size = new System.Drawing.Size(53, 20);
            this.dtpTime.TabIndex = 6;
            // 
            // btnEmailsenden
            // 
            this.btnEmailsenden.ForeColor = System.Drawing.Color.Black;
            this.btnEmailsenden.Location = new System.Drawing.Point(6, 150);
            this.btnEmailsenden.Name = "btnEmailsenden";
            this.btnEmailsenden.Size = new System.Drawing.Size(163, 30);
            this.btnEmailsenden.TabIndex = 15;
            this.btnEmailsenden.Text = "Email Senden";
            this.btnEmailsenden.UseVisualStyleBackColor = true;
            this.btnEmailsenden.Click += new System.EventHandler(this.btnEmailsenden_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(6, 124);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(163, 20);
            this.txtEmail.TabIndex = 14;
            // 
            // grpFahrplan
            // 
            this.grpFahrplan.Controls.Add(this.rdoSuche);
            this.grpFahrplan.Controls.Add(this.rdoAbfahrt);
            this.grpFahrplan.Controls.Add(this.btnAbfahrt);
            this.grpFahrplan.Controls.Add(this.lbxNach);
            this.grpFahrplan.Controls.Add(this.lbxVon);
            this.grpFahrplan.Controls.Add(this.txtNach);
            this.grpFahrplan.Controls.Add(this.lblNach);
            this.grpFahrplan.Controls.Add(this.lblVon);
            this.grpFahrplan.Controls.Add(this.btnSuchen);
            this.grpFahrplan.Controls.Add(this.txtVon);
            this.grpFahrplan.Controls.Add(this.dtpTime);
            this.grpFahrplan.Controls.Add(this.dtpDatum);
            this.grpFahrplan.ForeColor = System.Drawing.Color.White;
            this.grpFahrplan.Location = new System.Drawing.Point(12, 12);
            this.grpFahrplan.Name = "grpFahrplan";
            this.grpFahrplan.Size = new System.Drawing.Size(430, 191);
            this.grpFahrplan.TabIndex = 5;
            this.grpFahrplan.TabStop = false;
            this.grpFahrplan.Text = "Fahrplan";
            // 
            // rdoSuche
            // 
            this.rdoSuche.AutoSize = true;
            this.rdoSuche.Checked = true;
            this.rdoSuche.Location = new System.Drawing.Point(278, 15);
            this.rdoSuche.Name = "rdoSuche";
            this.rdoSuche.Size = new System.Drawing.Size(56, 17);
            this.rdoSuche.TabIndex = 9;
            this.rdoSuche.TabStop = true;
            this.rdoSuche.Text = "Suche";
            this.rdoSuche.UseVisualStyleBackColor = true;
            this.rdoSuche.CheckedChanged += new System.EventHandler(this.rdoSuche_CheckedChanged);
            // 
            // rdoAbfahrt
            // 
            this.rdoAbfahrt.AutoSize = true;
            this.rdoAbfahrt.Location = new System.Drawing.Point(340, 15);
            this.rdoAbfahrt.Name = "rdoAbfahrt";
            this.rdoAbfahrt.Size = new System.Drawing.Size(84, 17);
            this.rdoAbfahrt.TabIndex = 10;
            this.rdoAbfahrt.Text = "Abfahrtsplan";
            this.rdoAbfahrt.UseVisualStyleBackColor = true;
            this.rdoAbfahrt.CheckedChanged += new System.EventHandler(this.rdoAbfahrt_CheckedChanged);
            // 
            // btnAbfahrt
            // 
            this.btnAbfahrt.ForeColor = System.Drawing.Color.Black;
            this.btnAbfahrt.Location = new System.Drawing.Point(148, 32);
            this.btnAbfahrt.Name = "btnAbfahrt";
            this.btnAbfahrt.Size = new System.Drawing.Size(103, 21);
            this.btnAbfahrt.TabIndex = 8;
            this.btnAbfahrt.Text = "Abfahrts tabelle";
            this.btnAbfahrt.UseVisualStyleBackColor = true;
            this.btnAbfahrt.Visible = false;
            this.btnAbfahrt.Click += new System.EventHandler(this.btnAbfahrt_Click);
            // 
            // lbxNach
            // 
            this.lbxNach.FormattingEnabled = true;
            this.lbxNach.Location = new System.Drawing.Point(148, 59);
            this.lbxNach.Name = "lbxNach";
            this.lbxNach.Size = new System.Drawing.Size(133, 121);
            this.lbxNach.TabIndex = 4;
            this.lbxNach.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbxNach_KeyDown);
            this.lbxNach.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbxNach_MouseDoubleClick);
            // 
            // lbxVon
            // 
            this.lbxVon.FormattingEnabled = true;
            this.lbxVon.Location = new System.Drawing.Point(9, 59);
            this.lbxVon.Name = "lbxVon";
            this.lbxVon.Size = new System.Drawing.Size(133, 121);
            this.lbxVon.TabIndex = 2;
            this.lbxVon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbxVon_KeyDown);
            this.lbxVon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbxVon_MouseDoubleClick);
            // 
            // txtNach
            // 
            this.txtNach.Location = new System.Drawing.Point(148, 33);
            this.txtNach.Name = "txtNach";
            this.txtNach.Size = new System.Drawing.Size(133, 20);
            this.txtNach.TabIndex = 3;
            this.txtNach.Click += new System.EventHandler(this.txtNach_Click);
            this.txtNach.TextChanged += new System.EventHandler(this.txtNach_TextChanged);
            this.txtNach.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNach_KeyDown);
            // 
            // lblNach
            // 
            this.lblNach.AutoSize = true;
            this.lblNach.Location = new System.Drawing.Point(145, 17);
            this.lblNach.Name = "lblNach";
            this.lblNach.Size = new System.Drawing.Size(33, 13);
            this.lblNach.TabIndex = 7;
            this.lblNach.Text = "Nach";
            // 
            // lblVon
            // 
            this.lblVon.AutoSize = true;
            this.lblVon.Location = new System.Drawing.Point(9, 17);
            this.lblVon.Name = "lblVon";
            this.lblVon.Size = new System.Drawing.Size(26, 13);
            this.lblVon.TabIndex = 6;
            this.lblVon.Text = "Von";
            // 
            // btnSuchen
            // 
            this.btnSuchen.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSuchen.ForeColor = System.Drawing.Color.Black;
            this.btnSuchen.Location = new System.Drawing.Point(287, 32);
            this.btnSuchen.Name = "btnSuchen";
            this.btnSuchen.Size = new System.Drawing.Size(75, 21);
            this.btnSuchen.TabIndex = 7;
            this.btnSuchen.Text = "Suchen";
            this.btnSuchen.UseVisualStyleBackColor = false;
            this.btnSuchen.Click += new System.EventHandler(this.btnSuchen_Click);
            // 
            // txtVon
            // 
            this.txtVon.Location = new System.Drawing.Point(9, 33);
            this.txtVon.Name = "txtVon";
            this.txtVon.Size = new System.Drawing.Size(133, 20);
            this.txtVon.TabIndex = 1;
            this.txtVon.Click += new System.EventHandler(this.txtVon_Click);
            this.txtVon.TextChanged += new System.EventHandler(this.txtVon_TextChanged);
            this.txtVon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVon_KeyDown);
            // 
            // dgvFahrplan
            // 
            this.dgvFahrplan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFahrplan.BackgroundColor = System.Drawing.Color.Black;
            this.dgvFahrplan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFahrplan.Location = new System.Drawing.Point(12, 209);
            this.dgvFahrplan.Name = "dgvFahrplan";
            this.dgvFahrplan.Size = new System.Drawing.Size(875, 343);
            this.dgvFahrplan.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.btnEmailsenden);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(712, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(175, 191);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fahr plan an Email senden";
            // 
            // grpGmap
            // 
            this.grpGmap.Controls.Add(this.btnNear);
            this.grpGmap.Controls.Add(this.lbxStation);
            this.grpGmap.Controls.Add(this.btnclose);
            this.grpGmap.Controls.Add(this.txtStation);
            this.grpGmap.Controls.Add(this.btnGmaps);
            this.grpGmap.ForeColor = System.Drawing.Color.White;
            this.grpGmap.Location = new System.Drawing.Point(448, 12);
            this.grpGmap.Name = "grpGmap";
            this.grpGmap.Size = new System.Drawing.Size(258, 191);
            this.grpGmap.TabIndex = 8;
            this.grpGmap.TabStop = false;
            this.grpGmap.Text = "Google Maps";
            // 
            // btnNear
            // 
            this.btnNear.ForeColor = System.Drawing.Color.Black;
            this.btnNear.Location = new System.Drawing.Point(151, 150);
            this.btnNear.Name = "btnNear";
            this.btnNear.Size = new System.Drawing.Size(101, 30);
            this.btnNear.TabIndex = 15;
            this.btnNear.Text = "Nächste Station";
            this.btnNear.UseVisualStyleBackColor = true;
            this.btnNear.Click += new System.EventHandler(this.btnNear_Click);
            // 
            // lbxStation
            // 
            this.lbxStation.FormattingEnabled = true;
            this.lbxStation.Location = new System.Drawing.Point(6, 59);
            this.lbxStation.Name = "lbxStation";
            this.lbxStation.Size = new System.Drawing.Size(246, 82);
            this.lbxStation.TabIndex = 14;
            this.lbxStation.Visible = false;
            this.lbxStation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbxStation_KeyDown);
            this.lbxStation.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbxStation_MouseDoubleClick);
            // 
            // btnclose
            // 
            this.btnclose.ForeColor = System.Drawing.Color.Black;
            this.btnclose.Location = new System.Drawing.Point(6, 150);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(30, 30);
            this.btnclose.TabIndex = 13;
            this.btnclose.Text = "X";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Visible = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // txtStation
            // 
            this.txtStation.Location = new System.Drawing.Point(6, 33);
            this.txtStation.Name = "txtStation";
            this.txtStation.Size = new System.Drawing.Size(246, 20);
            this.txtStation.TabIndex = 11;
            this.txtStation.Click += new System.EventHandler(this.txtStation_Click);
            this.txtStation.TextChanged += new System.EventHandler(this.txtStation_TextChanged);
            this.txtStation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStation_KeyDown);
            // 
            // btnGmaps
            // 
            this.btnGmaps.ForeColor = System.Drawing.Color.Black;
            this.btnGmaps.Location = new System.Drawing.Point(42, 150);
            this.btnGmaps.Name = "btnGmaps";
            this.btnGmaps.Size = new System.Drawing.Size(103, 30);
            this.btnGmaps.TabIndex = 12;
            this.btnGmaps.Text = "Google Maps";
            this.btnGmaps.UseVisualStyleBackColor = true;
            this.btnGmaps.Click += new System.EventHandler(this.btnGmaps_Click);
            // 
            // wbGmaps
            // 
            this.wbGmaps.Location = new System.Drawing.Point(12, 209);
            this.wbGmaps.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbGmaps.Name = "wbGmaps";
            this.wbGmaps.Size = new System.Drawing.Size(875, 343);
            this.wbGmaps.TabIndex = 9;
            this.wbGmaps.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(899, 564);
            this.Controls.Add(this.wbGmaps);
            this.Controls.Add(this.dgvFahrplan);
            this.Controls.Add(this.grpGmap);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpFahrplan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "SBB Fahrplan";
            this.grpFahrplan.ResumeLayout(false);
            this.grpFahrplan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFahrplan)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpGmap.ResumeLayout(false);
            this.grpGmap.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDatum;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.Button btnEmailsenden;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.GroupBox grpFahrplan;
        private System.Windows.Forms.DataGridView dgvFahrplan;
        private System.Windows.Forms.TextBox txtNach;
        private System.Windows.Forms.Label lblNach;
        private System.Windows.Forms.Label lblVon;
        private System.Windows.Forms.Button btnSuchen;
        private System.Windows.Forms.TextBox txtVon;
        private System.Windows.Forms.ListBox lbxNach;
        private System.Windows.Forms.ListBox lbxVon;
        private System.Windows.Forms.Button btnAbfahrt;
        private System.Windows.Forms.RadioButton rdoSuche;
        private System.Windows.Forms.RadioButton rdoAbfahrt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grpGmap;
        private System.Windows.Forms.TextBox txtStation;
        private System.Windows.Forms.Button btnGmaps;
        private System.Windows.Forms.WebBrowser wbGmaps;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.ListBox lbxStation;
        private System.Windows.Forms.Button btnNear;
    }
}

