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
            this.lblEmail = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAbfahrt = new System.Windows.Forms.Button();
            this.lbxNach = new System.Windows.Forms.ListBox();
            this.lbxVon = new System.Windows.Forms.ListBox();
            this.txtNach = new System.Windows.Forms.TextBox();
            this.lblNach = new System.Windows.Forms.Label();
            this.lblVon = new System.Windows.Forms.Label();
            this.btnSuchen = new System.Windows.Forms.Button();
            this.txtVon = new System.Windows.Forms.TextBox();
            this.dgvFahrplan = new System.Windows.Forms.DataGridView();
            this.rdoAbfahrt = new System.Windows.Forms.RadioButton();
            this.rdoSuche = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFahrplan)).BeginInit();
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
            this.dtpDatum.TabIndex = 0;
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
            this.dtpTime.TabIndex = 1;
            // 
            // btnEmailsenden
            // 
            this.btnEmailsenden.Location = new System.Drawing.Point(606, 132);
            this.btnEmailsenden.Name = "btnEmailsenden";
            this.btnEmailsenden.Size = new System.Drawing.Size(164, 48);
            this.btnEmailsenden.TabIndex = 2;
            this.btnEmailsenden.Text = "Email Senden";
            this.btnEmailsenden.UseVisualStyleBackColor = true;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(606, 106);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(164, 20);
            this.txtEmail.TabIndex = 3;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(603, 90);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(89, 13);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "An Email senden:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoSuche);
            this.groupBox1.Controls.Add(this.rdoAbfahrt);
            this.groupBox1.Controls.Add(this.lblEmail);
            this.groupBox1.Controls.Add(this.btnAbfahrt);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.btnEmailsenden);
            this.groupBox1.Controls.Add(this.lbxNach);
            this.groupBox1.Controls.Add(this.lbxVon);
            this.groupBox1.Controls.Add(this.txtNach);
            this.groupBox1.Controls.Add(this.lblNach);
            this.groupBox1.Controls.Add(this.lblVon);
            this.groupBox1.Controls.Add(this.btnSuchen);
            this.groupBox1.Controls.Add(this.txtVon);
            this.groupBox1.Controls.Add(this.dtpTime);
            this.groupBox1.Controls.Add(this.dtpDatum);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 191);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // btnAbfahrt
            // 
            this.btnAbfahrt.Location = new System.Drawing.Point(148, 32);
            this.btnAbfahrt.Name = "btnAbfahrt";
            this.btnAbfahrt.Size = new System.Drawing.Size(103, 21);
            this.btnAbfahrt.TabIndex = 11;
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
            this.lbxNach.TabIndex = 10;
            this.lbxNach.SelectedIndexChanged += new System.EventHandler(this.lbxNach_SelectedIndexChanged);
            // 
            // lbxVon
            // 
            this.lbxVon.FormattingEnabled = true;
            this.lbxVon.Location = new System.Drawing.Point(9, 59);
            this.lbxVon.Name = "lbxVon";
            this.lbxVon.Size = new System.Drawing.Size(133, 121);
            this.lbxVon.TabIndex = 9;
            this.lbxVon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbxVon_MouseDoubleClick);
            // 
            // txtNach
            // 
            this.txtNach.Location = new System.Drawing.Point(148, 33);
            this.txtNach.Name = "txtNach";
            this.txtNach.Size = new System.Drawing.Size(133, 20);
            this.txtNach.TabIndex = 8;
            this.txtNach.TextChanged += new System.EventHandler(this.txtNach_TextChanged);
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
            this.btnSuchen.Location = new System.Drawing.Point(287, 32);
            this.btnSuchen.Name = "btnSuchen";
            this.btnSuchen.Size = new System.Drawing.Size(75, 21);
            this.btnSuchen.TabIndex = 5;
            this.btnSuchen.Text = "Suchen";
            this.btnSuchen.UseVisualStyleBackColor = true;
            this.btnSuchen.Click += new System.EventHandler(this.btnSuchen_Click);
            // 
            // txtVon
            // 
            this.txtVon.Location = new System.Drawing.Point(9, 33);
            this.txtVon.Name = "txtVon";
            this.txtVon.Size = new System.Drawing.Size(133, 20);
            this.txtVon.TabIndex = 2;
            this.txtVon.TextChanged += new System.EventHandler(this.txtVon_TextChanged);
            // 
            // dgvFahrplan
            // 
            this.dgvFahrplan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFahrplan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFahrplan.Location = new System.Drawing.Point(12, 209);
            this.dgvFahrplan.Name = "dgvFahrplan";
            this.dgvFahrplan.Size = new System.Drawing.Size(776, 195);
            this.dgvFahrplan.TabIndex = 6;
            // 
            // rdoAbfahrt
            // 
            this.rdoAbfahrt.AutoSize = true;
            this.rdoAbfahrt.Location = new System.Drawing.Point(368, 15);
            this.rdoAbfahrt.Name = "rdoAbfahrt";
            this.rdoAbfahrt.Size = new System.Drawing.Size(84, 17);
            this.rdoAbfahrt.TabIndex = 12;
            this.rdoAbfahrt.TabStop = true;
            this.rdoAbfahrt.Text = "Abfahrtsplan";
            this.rdoAbfahrt.UseVisualStyleBackColor = true;
            this.rdoAbfahrt.CheckedChanged += new System.EventHandler(this.rdoAbfahrt_CheckedChanged);
            // 
            // rdoSuche
            // 
            this.rdoSuche.AutoSize = true;
            this.rdoSuche.Checked = true;
            this.rdoSuche.Location = new System.Drawing.Point(306, 15);
            this.rdoSuche.Name = "rdoSuche";
            this.rdoSuche.Size = new System.Drawing.Size(56, 17);
            this.rdoSuche.TabIndex = 13;
            this.rdoSuche.TabStop = true;
            this.rdoSuche.Text = "Suche";
            this.rdoSuche.UseVisualStyleBackColor = true;
            this.rdoSuche.CheckedChanged += new System.EventHandler(this.rdoSuche_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 416);
            this.Controls.Add(this.dgvFahrplan);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFahrplan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDatum;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.Button btnEmailsenden;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.GroupBox groupBox1;
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
    }
}

