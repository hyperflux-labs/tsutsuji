namespace Tsutsuji.Updater.Screens
{
    partial class Updater
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
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.SizeText = new System.Windows.Forms.Label();
            this.FileName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(12, 48);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(464, 23);
            this.ProgressBar.Step = 1;
            this.ProgressBar.TabIndex = 0;
            // 
            // SizeText
            // 
            this.SizeText.AutoSize = true;
            this.SizeText.Location = new System.Drawing.Point(13, 74);
            this.SizeText.Name = "SizeText";
            this.SizeText.Size = new System.Drawing.Size(0, 13);
            this.SizeText.TabIndex = 1;
            // 
            // FileName
            // 
            this.FileName.AutoSize = true;
            this.FileName.Location = new System.Drawing.Point(13, 19);
            this.FileName.Name = "FileName";
            this.FileName.Size = new System.Drawing.Size(177, 13);
            this.FileName.TabIndex = 2;
            this.FileName.Text = "Checking if Hyperflux is up to date...";
            // 
            // Updater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 99);
            this.Controls.Add(this.FileName);
            this.Controls.Add(this.SizeText);
            this.Controls.Add(this.ProgressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Updater";
            this.Text = "Hyperflux Updater";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Label SizeText;
        private System.Windows.Forms.Label FileName;
    }
}