namespace TdoT_v._4.Panels
{
    partial class Edit
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
            this.label1 = new System.Windows.Forms.Label();
            this.nachname = new System.Windows.Forms.TextBox();
            this.vorname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.klasse = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ändern = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.notiz = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nachname";
            // 
            // nachname
            // 
            this.nachname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nachname.Location = new System.Drawing.Point(16, 30);
            this.nachname.MaxLength = 50;
            this.nachname.Name = "nachname";
            this.nachname.Size = new System.Drawing.Size(100, 20);
            this.nachname.TabIndex = 1;
            // 
            // vorname
            // 
            this.vorname.Location = new System.Drawing.Point(138, 30);
            this.vorname.MaxLength = 50;
            this.vorname.Name = "vorname";
            this.vorname.Size = new System.Drawing.Size(100, 20);
            this.vorname.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(135, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Vorname";
            // 
            // klasse
            // 
            this.klasse.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.klasse.Location = new System.Drawing.Point(259, 30);
            this.klasse.MaxLength = 6;
            this.klasse.Name = "klasse";
            this.klasse.Size = new System.Drawing.Size(100, 20);
            this.klasse.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(256, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Klasse";
            // 
            // ändern
            // 
            this.ändern.Location = new System.Drawing.Point(259, 78);
            this.ändern.Name = "ändern";
            this.ändern.Size = new System.Drawing.Size(75, 23);
            this.ändern.TabIndex = 5;
            this.ändern.Text = "Ändern";
            this.ändern.UseVisualStyleBackColor = true;
            this.ändern.Click += new System.EventHandler(this.Ändern_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Notiz";
            // 
            // notiz
            // 
            this.notiz.Location = new System.Drawing.Point(16, 81);
            this.notiz.MaxLength = 23;
            this.notiz.Name = "notiz";
            this.notiz.Size = new System.Drawing.Size(222, 20);
            this.notiz.TabIndex = 6;
            // 
            // Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 118);
            this.Controls.Add(this.notiz);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ändern);
            this.Controls.Add(this.klasse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.vorname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nachname);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Edit";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TdoT - Bearbeiten";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nachname;
        private System.Windows.Forms.TextBox vorname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox klasse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ändern;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox notiz;
    }
}