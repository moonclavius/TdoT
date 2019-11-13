namespace TdoT_v._4
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menudatei = new System.Windows.Forms.ToolStripMenuItem();
            this.dateiöffnen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.dateispeichern = new System.Windows.Forms.ToolStripMenuItem();
            this.dateiexportieren = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.dateischließen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuansicht = new System.Windows.Forms.ToolStripMenuItem();
            this.ansichtführer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ansichtprotokoll = new System.Windows.Forms.ToolStripMenuItem();
            this.ansichtstatistik = new System.Windows.Forms.ToolStripMenuItem();
            this.menueinstellungen = new System.Windows.Forms.ToolStripMenuItem();
            this.output = new System.Windows.Forms.DataGridView();
            this.edit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nfc = new System.Windows.Forms.ToolStripMenuItem();
            this.separator2 = new System.Windows.Forms.ToolStripSeparator();
            this.infos = new System.Windows.Forms.ToolStripMenuItem();
            this.anwesenheit = new System.Windows.Forms.ToolStripMenuItem();
            this.separator = new System.Windows.Forms.ToolStripSeparator();
            this.bearbeiten = new System.Windows.Forms.ToolStripMenuItem();
            this.löschen = new System.Windows.Forms.ToolStripMenuItem();
            this.open = new System.Windows.Forms.OpenFileDialog();
            this.suchen = new System.Windows.Forms.TextBox();
            this.rfidstatus = new System.Windows.Forms.PictureBox();
            this.anwesende = new System.Windows.Forms.Label();
            this.aktive = new System.Windows.Forms.Label();
            this.führungen = new System.Windows.Forms.Label();
            this.save = new System.Windows.Forms.SaveFileDialog();
            this.autosave = new System.Windows.Forms.Timer(this.components);
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.output)).BeginInit();
            this.edit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rfidstatus)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menudatei,
            this.menuansicht,
            this.menueinstellungen});
            this.menu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1181, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menu";
            // 
            // menudatei
            // 
            this.menudatei.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiöffnen,
            this.toolStripSeparator1,
            this.dateispeichern,
            this.dateiexportieren,
            this.toolStripSeparator2,
            this.dateischließen});
            this.menudatei.Name = "menudatei";
            this.menudatei.Size = new System.Drawing.Size(46, 20);
            this.menudatei.Text = "Datei";
            this.menudatei.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            // 
            // dateiöffnen
            // 
            this.dateiöffnen.Name = "dateiöffnen";
            this.dateiöffnen.Size = new System.Drawing.Size(165, 22);
            this.dateiöffnen.Text = "Öffnen";
            this.dateiöffnen.Click += new System.EventHandler(this.Dateiöffnen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(162, 6);
            // 
            // dateispeichern
            // 
            this.dateispeichern.Enabled = false;
            this.dateispeichern.Name = "dateispeichern";
            this.dateispeichern.Size = new System.Drawing.Size(165, 22);
            this.dateispeichern.Text = "Speichern";
            this.dateispeichern.Click += new System.EventHandler(this.Dateispeichern_Click);
            // 
            // dateiexportieren
            // 
            this.dateiexportieren.Enabled = false;
            this.dateiexportieren.Name = "dateiexportieren";
            this.dateiexportieren.Size = new System.Drawing.Size(165, 22);
            this.dateiexportieren.Text = "Klasse expotieren";
            this.dateiexportieren.Click += new System.EventHandler(this.Dateiexportieren_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(162, 6);
            // 
            // dateischließen
            // 
            this.dateischließen.Enabled = false;
            this.dateischließen.Name = "dateischließen";
            this.dateischließen.Size = new System.Drawing.Size(165, 22);
            this.dateischließen.Text = "Projekt schließen";
            this.dateischließen.Click += new System.EventHandler(this.Dateischließen_Click);
            // 
            // menuansicht
            // 
            this.menuansicht.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ansichtführer,
            this.toolStripSeparator3,
            this.ansichtprotokoll,
            this.ansichtstatistik});
            this.menuansicht.Name = "menuansicht";
            this.menuansicht.Size = new System.Drawing.Size(59, 20);
            this.menuansicht.Text = "Ansicht";
            // 
            // ansichtführer
            // 
            this.ansichtführer.Name = "ansichtführer";
            this.ansichtführer.Size = new System.Drawing.Size(180, 22);
            this.ansichtführer.Text = "Führer ergänzen";
            this.ansichtführer.Click += new System.EventHandler(this.Ansichtführer_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
            // 
            // ansichtprotokoll
            // 
            this.ansichtprotokoll.Name = "ansichtprotokoll";
            this.ansichtprotokoll.Size = new System.Drawing.Size(180, 22);
            this.ansichtprotokoll.Text = "Protokoll";
            this.ansichtprotokoll.Click += new System.EventHandler(this.Ansichtprotokoll_Click);
            // 
            // ansichtstatistik
            // 
            this.ansichtstatistik.Name = "ansichtstatistik";
            this.ansichtstatistik.Size = new System.Drawing.Size(180, 22);
            this.ansichtstatistik.Text = "Statistik";
            this.ansichtstatistik.Click += new System.EventHandler(this.Ansichtstatistik_Click);
            // 
            // menueinstellungen
            // 
            this.menueinstellungen.Name = "menueinstellungen";
            this.menueinstellungen.Size = new System.Drawing.Size(90, 20);
            this.menueinstellungen.Text = "Einstellungen";
            this.menueinstellungen.Click += new System.EventHandler(this.Menueinstellungen_Click);
            // 
            // output
            // 
            this.output.AllowUserToAddRows = false;
            this.output.AllowUserToDeleteRows = false;
            this.output.AllowUserToOrderColumns = true;
            this.output.AllowUserToResizeRows = false;
            this.output.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.output.BackgroundColor = System.Drawing.SystemColors.Control;
            this.output.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.output.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.output.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.output.ColumnHeadersHeight = 28;
            this.output.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.output.Location = new System.Drawing.Point(0, 24);
            this.output.MultiSelect = false;
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.RowHeadersWidth = 45;
            this.output.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.output.RowTemplate.Height = 25;
            this.output.RowTemplate.ReadOnly = true;
            this.output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.output.ShowCellErrors = false;
            this.output.ShowCellToolTips = false;
            this.output.ShowEditingIcon = false;
            this.output.ShowRowErrors = false;
            this.output.Size = new System.Drawing.Size(1181, 646);
            this.output.TabIndex = 2;
            this.output.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Output_CellClick);
            this.output.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Output_CellMouseDown);
            this.output.Sorted += new System.EventHandler(this.Output_Sorted);
            // 
            // edit
            // 
            this.edit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nfc,
            this.separator2,
            this.infos,
            this.anwesenheit,
            this.separator,
            this.bearbeiten,
            this.löschen});
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(140, 126);
            // 
            // nfc
            // 
            this.nfc.Name = "nfc";
            this.nfc.Size = new System.Drawing.Size(139, 22);
            this.nfc.Text = "Schülerkarte";
            this.nfc.Click += new System.EventHandler(this.Nfc_Click);
            // 
            // separator2
            // 
            this.separator2.Name = "separator2";
            this.separator2.Size = new System.Drawing.Size(136, 6);
            // 
            // infos
            // 
            this.infos.Name = "infos";
            this.infos.Size = new System.Drawing.Size(139, 22);
            this.infos.Text = "Infos";
            this.infos.Click += new System.EventHandler(this.Infos_Click);
            // 
            // anwesenheit
            // 
            this.anwesenheit.CheckOnClick = true;
            this.anwesenheit.Name = "anwesenheit";
            this.anwesenheit.Size = new System.Drawing.Size(139, 22);
            this.anwesenheit.Text = "Anwesend";
            this.anwesenheit.Click += new System.EventHandler(this.Anwesenheit_Click);
            // 
            // separator
            // 
            this.separator.Name = "separator";
            this.separator.Size = new System.Drawing.Size(136, 6);
            // 
            // bearbeiten
            // 
            this.bearbeiten.Name = "bearbeiten";
            this.bearbeiten.Size = new System.Drawing.Size(139, 22);
            this.bearbeiten.Text = "Bearbeiten";
            this.bearbeiten.Click += new System.EventHandler(this.Bearbeiten_Click);
            // 
            // löschen
            // 
            this.löschen.Name = "löschen";
            this.löschen.Size = new System.Drawing.Size(139, 22);
            this.löschen.Text = "Löschen";
            this.löschen.Click += new System.EventHandler(this.Löschen_Click);
            // 
            // open
            // 
            this.open.Filter = "CSV|*.csv";
            this.open.ReadOnlyChecked = true;
            this.open.Title = "TdoT - Öffnen";
            // 
            // suchen
            // 
            this.suchen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.suchen.BackColor = System.Drawing.SystemColors.HighlightText;
            this.suchen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.suchen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suchen.Location = new System.Drawing.Point(1057, 1);
            this.suchen.MaxLength = 200;
            this.suchen.Name = "suchen";
            this.suchen.Size = new System.Drawing.Size(100, 22);
            this.suchen.TabIndex = 3;
            this.suchen.Text = "Suchen...";
            this.suchen.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Suchen_MouseClick);
            this.suchen.TextChanged += new System.EventHandler(this.Suchen_TextChanged);
            this.suchen.Leave += new System.EventHandler(this.Suchen_Leave);
            // 
            // rfidstatus
            // 
            this.rfidstatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rfidstatus.BackColor = System.Drawing.Color.Red;
            this.rfidstatus.Location = new System.Drawing.Point(1157, 0);
            this.rfidstatus.Name = "rfidstatus";
            this.rfidstatus.Size = new System.Drawing.Size(24, 25);
            this.rfidstatus.TabIndex = 4;
            this.rfidstatus.TabStop = false;
            // 
            // anwesende
            // 
            this.anwesende.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.anwesende.AutoSize = true;
            this.anwesende.BackColor = System.Drawing.SystemColors.ControlLight;
            this.anwesende.Location = new System.Drawing.Point(707, 5);
            this.anwesende.Name = "anwesende";
            this.anwesende.Size = new System.Drawing.Size(75, 13);
            this.anwesende.TabIndex = 5;
            this.anwesende.Text = "Anwesende: 0";
            // 
            // aktive
            // 
            this.aktive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.aktive.AutoSize = true;
            this.aktive.BackColor = System.Drawing.SystemColors.ControlLight;
            this.aktive.Location = new System.Drawing.Point(813, 5);
            this.aktive.Name = "aktive";
            this.aktive.Size = new System.Drawing.Size(49, 13);
            this.aktive.TabIndex = 6;
            this.aktive.Text = "Aktive: 0";
            // 
            // führungen
            // 
            this.führungen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.führungen.AutoSize = true;
            this.führungen.BackColor = System.Drawing.SystemColors.ControlLight;
            this.führungen.Location = new System.Drawing.Point(891, 5);
            this.führungen.Name = "führungen";
            this.führungen.Size = new System.Drawing.Size(70, 13);
            this.führungen.TabIndex = 7;
            this.führungen.Text = "Führungen: 0";
            // 
            // save
            // 
            this.save.Filter = "CSV|*csv|PDF|*pdf";
            this.save.Title = "TdoT - Speichern";
            // 
            // autosave
            // 
            this.autosave.Enabled = true;
            this.autosave.Interval = 600000;
            this.autosave.Tag = "";
            this.autosave.Tick += new System.EventHandler(this.Autosave_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 670);
            this.Controls.Add(this.führungen);
            this.Controls.Add(this.aktive);
            this.Controls.Add(this.anwesende);
            this.Controls.Add(this.rfidstatus);
            this.Controls.Add(this.suchen);
            this.Controls.Add(this.output);
            this.Controls.Add(this.menu);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MainMenuStrip = this.menu;
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "Main";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TdoT - Uros Zivkovic";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.output)).EndInit();
            this.edit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rfidstatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem menudatei;
        private System.Windows.Forms.ToolStripMenuItem dateiöffnen;
        private System.Windows.Forms.ToolStripMenuItem dateispeichern;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem dateischließen;
        private System.Windows.Forms.ToolStripMenuItem menuansicht;
        private System.Windows.Forms.ToolStripMenuItem ansichtführer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem ansichtprotokoll;
        private System.Windows.Forms.ToolStripMenuItem ansichtstatistik;
        private System.Windows.Forms.ToolStripMenuItem menueinstellungen;
        private System.Windows.Forms.DataGridView output;
        private System.Windows.Forms.OpenFileDialog open;
        private System.Windows.Forms.TextBox suchen;
        private System.Windows.Forms.PictureBox rfidstatus;
        public System.Windows.Forms.Label anwesende;
        public System.Windows.Forms.Label aktive;
        public System.Windows.Forms.Label führungen;
        private System.Windows.Forms.SaveFileDialog save;
        private System.Windows.Forms.ContextMenuStrip edit;
        private System.Windows.Forms.ToolStripMenuItem bearbeiten;
        private System.Windows.Forms.ToolStripMenuItem löschen;
        private System.Windows.Forms.ToolStripMenuItem infos;
        private System.Windows.Forms.ToolStripSeparator separator;
        private System.Windows.Forms.ToolStripSeparator separator2;
        private System.Windows.Forms.ToolStripMenuItem anwesenheit;
        private System.Windows.Forms.ToolStripMenuItem nfc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem dateiexportieren;
        private System.Windows.Forms.Timer autosave;
    }
}

