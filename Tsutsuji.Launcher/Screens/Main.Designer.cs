using System;
using System.Drawing;
using System.Globalization;

namespace Tsutsuji.Launcher.Screens
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
            this.ControlPanel = new System.Windows.Forms.Panel();
            this.LoginButton = new System.Windows.Forms.Button();
            this.RunButton = new System.Windows.Forms.Button();
            this.Username = new System.Windows.Forms.Label();
            this.NewsSection = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TwitterButton = new System.Windows.Forms.Button();
            this.YoutubeButton = new System.Windows.Forms.Button();
            this.DiscordButton = new System.Windows.Forms.Button();
            this.RecentlyRated = new System.Windows.Forms.RichTextBox();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.ControlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ControlPanel
            // 
            this.ControlPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.ControlPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ControlPanel.Controls.Add(this.SettingsButton);
            this.ControlPanel.Controls.Add(this.RecentlyRated);
            this.ControlPanel.Controls.Add(this.LoginButton);
            this.ControlPanel.Controls.Add(this.RunButton);
            this.ControlPanel.Location = new System.Drawing.Point(611, 12);
            this.ControlPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Size = new System.Drawing.Size(177, 434);
            this.ControlPanel.TabIndex = 0;
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(50, 303);
            this.LoginButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(75, 22);
            this.LoginButton.TabIndex = 2;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // RunButton
            // 
            this.RunButton.Location = new System.Drawing.Point(19, 366);
            this.RunButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(142, 44);
            this.RunButton.TabIndex = 0;
            this.RunButton.Text = "Run Hyperflux";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunHyperflux_Click);
            // 
            // Username
            // 
            this.Username.AutoSize = true;
            this.Username.Location = new System.Drawing.Point(12, 423);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(77, 13);
            this.Username.TabIndex = 0;
            this.Username.Text = "Hello, Nobody!";
            // 
            // NewsSection
            // 
            this.NewsSection.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewsSection.Location = new System.Drawing.Point(15, 30);
            this.NewsSection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NewsSection.Name = "NewsSection";
            this.NewsSection.ReadOnly = true;
            this.NewsSection.Size = new System.Drawing.Size(576, 388);
            this.NewsSection.TabIndex = 1;
            this.NewsSection.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "GDPS News and Changelogs";
            // 
            // TwitterButton
            // 
            this.TwitterButton.Location = new System.Drawing.Point(516, 423);
            this.TwitterButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TwitterButton.Name = "TwitterButton";
            this.TwitterButton.Size = new System.Drawing.Size(75, 22);
            this.TwitterButton.TabIndex = 3;
            this.TwitterButton.Text = "Twitter";
            this.TwitterButton.UseVisualStyleBackColor = true;
            // 
            // YoutubeButton
            // 
            this.YoutubeButton.Location = new System.Drawing.Point(435, 423);
            this.YoutubeButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.YoutubeButton.Name = "YoutubeButton";
            this.YoutubeButton.Size = new System.Drawing.Size(75, 22);
            this.YoutubeButton.TabIndex = 4;
            this.YoutubeButton.Text = "Youtube";
            this.YoutubeButton.UseVisualStyleBackColor = true;
            // 
            // DiscordButton
            // 
            this.DiscordButton.Location = new System.Drawing.Point(354, 423);
            this.DiscordButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DiscordButton.Name = "DiscordButton";
            this.DiscordButton.Size = new System.Drawing.Size(75, 22);
            this.DiscordButton.TabIndex = 5;
            this.DiscordButton.Text = "Discord";
            this.DiscordButton.UseVisualStyleBackColor = true;
            // 
            // RecentlyRated
            // 
            this.RecentlyRated.Location = new System.Drawing.Point(19, 28);
            this.RecentlyRated.Name = "RecentlyRated";
            this.RecentlyRated.ReadOnly = true;
            this.RecentlyRated.Size = new System.Drawing.Size(142, 268);
            this.RecentlyRated.TabIndex = 3;
            this.RecentlyRated.Text = "this gay level got rated (2*)";
            // 
            // SettingsButton
            // 
            this.SettingsButton.Location = new System.Drawing.Point(50, 333);
            this.SettingsButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(75, 22);
            this.SettingsButton.TabIndex = 4;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DiscordButton);
            this.Controls.Add(this.YoutubeButton);
            this.Controls.Add(this.TwitterButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NewsSection);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.ControlPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Main";
            this.Text = "Tsutsuji Launcher";
            this.ControlPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel ControlPanel;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Label Username;
        private System.Windows.Forms.RichTextBox RecentlyRated;
        private System.Windows.Forms.RichTextBox NewsSection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button TwitterButton;
        private System.Windows.Forms.Button YoutubeButton;
        private System.Windows.Forms.Button DiscordButton;
        private System.Windows.Forms.Button SettingsButton;
    }
}