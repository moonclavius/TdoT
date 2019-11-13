namespace TdoT_v._4.Panels
{
    partial class Exportieren
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
            this.itel = new System.Windows.Forms.CheckBox();
            this.hif = new System.Windows.Forms.CheckBox();
            this.het = new System.Windows.Forms.CheckBox();
            this.bestätigen = new System.Windows.Forms.Button();
            this.klassen = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // itel
            // 
            this.itel.AutoSize = true;
            this.itel.Checked = true;
            this.itel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.itel.Location = new System.Drawing.Point(12, 11);
            this.itel.Name = "itel";
            this.itel.Size = new System.Drawing.Size(49, 17);
            this.itel.TabIndex = 1;
            this.itel.Text = "ITEL";
            this.itel.UseVisualStyleBackColor = true;
            this.itel.CheckedChanged += new System.EventHandler(this.Itel_CheckedChanged);
            // 
            // hif
            // 
            this.hif.AutoSize = true;
            this.hif.Checked = true;
            this.hif.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hif.Location = new System.Drawing.Point(67, 11);
            this.hif.Name = "hif";
            this.hif.Size = new System.Drawing.Size(35, 17);
            this.hif.TabIndex = 2;
            this.hif.Text = "IF";
            this.hif.UseVisualStyleBackColor = true;
            this.hif.CheckedChanged += new System.EventHandler(this.If_CheckedChanged);
            // 
            // het
            // 
            this.het.AutoSize = true;
            this.het.Checked = true;
            this.het.CheckState = System.Windows.Forms.CheckState.Checked;
            this.het.Location = new System.Drawing.Point(108, 11);
            this.het.Name = "het";
            this.het.Size = new System.Drawing.Size(40, 17);
            this.het.TabIndex = 3;
            this.het.Text = "ET";
            this.het.UseVisualStyleBackColor = true;
            this.het.CheckedChanged += new System.EventHandler(this.Et_CheckedChanged);
            // 
            // bestätigen
            // 
            this.bestätigen.Location = new System.Drawing.Point(157, 33);
            this.bestätigen.Name = "bestätigen";
            this.bestätigen.Size = new System.Drawing.Size(75, 23);
            this.bestätigen.TabIndex = 4;
            this.bestätigen.Text = "Bestätigen";
            this.bestätigen.UseVisualStyleBackColor = true;
            this.bestätigen.Click += new System.EventHandler(this.Bestätigen_Click);
            // 
            // klassen
            // 
            this.klassen.FormattingEnabled = true;
            this.klassen.Location = new System.Drawing.Point(12, 34);
            this.klassen.Name = "klassen";
            this.klassen.Size = new System.Drawing.Size(132, 21);
            this.klassen.Sorted = true;
            this.klassen.TabIndex = 5;
            // 
            // Exportieren
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 69);
            this.Controls.Add(this.klassen);
            this.Controls.Add(this.bestätigen);
            this.Controls.Add(this.het);
            this.Controls.Add(this.hif);
            this.Controls.Add(this.itel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Exportieren";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TdoT - Exportieren";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox itel;
        private System.Windows.Forms.CheckBox hif;
        private System.Windows.Forms.CheckBox het;
        private System.Windows.Forms.Button bestätigen;
        private System.Windows.Forms.ComboBox klassen;
    }
}