namespace TdoT_v._4.Panels
{
    partial class Anzahl
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
            this.besucher = new System.Windows.Forms.TextBox();
            this.bestätigen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Anzahl der Besucher:";
            // 
            // besucher
            // 
            this.besucher.Location = new System.Drawing.Point(16, 30);
            this.besucher.MaxLength = 2;
            this.besucher.Name = "besucher";
            this.besucher.Size = new System.Drawing.Size(102, 20);
            this.besucher.TabIndex = 1;
            this.besucher.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Besucher_KeyUp);
            // 
            // bestätigen
            // 
            this.bestätigen.Location = new System.Drawing.Point(124, 28);
            this.bestätigen.Name = "bestätigen";
            this.bestätigen.Size = new System.Drawing.Size(75, 23);
            this.bestätigen.TabIndex = 2;
            this.bestätigen.Text = "Bestätigen";
            this.bestätigen.UseVisualStyleBackColor = true;
            this.bestätigen.Click += new System.EventHandler(this.Bestätigen_Click);
            // 
            // Anzahl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(211, 65);
            this.Controls.Add(this.bestätigen);
            this.Controls.Add(this.besucher);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Anzahl";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TdoT - Besucher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox besucher;
        private System.Windows.Forms.Button bestätigen;
    }
}