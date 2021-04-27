
namespace YTDownloader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.link = new System.Windows.Forms.TextBox();
            this.download_button = new System.Windows.Forms.Button();
            this.linklabel = new System.Windows.Forms.Label();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // link
            // 
            this.link.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.link.Location = new System.Drawing.Point(100, 128);
            this.link.Name = "link";
            this.link.Size = new System.Drawing.Size(636, 29);
            this.link.TabIndex = 0;
            // 
            // download_button
            // 
            this.download_button.BackColor = System.Drawing.Color.Transparent;
            this.download_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.download_button.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(127)))));
            this.download_button.FlatAppearance.BorderSize = 0;
            this.download_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.download_button.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.download_button.Location = new System.Drawing.Point(100, 239);
            this.download_button.Name = "download_button";
            this.download_button.Size = new System.Drawing.Size(636, 106);
            this.download_button.TabIndex = 1;
            this.download_button.Text = "İndir";
            this.download_button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.download_button.UseVisualStyleBackColor = false;
            this.download_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // linklabel
            // 
            this.linklabel.AutoSize = true;
            this.linklabel.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.linklabel.Location = new System.Drawing.Point(100, 88);
            this.linklabel.Name = "linklabel";
            this.linklabel.Size = new System.Drawing.Size(83, 36);
            this.linklabel.TabIndex = 2;
            this.linklabel.Text = "Link:";
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(100, 356);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(636, 37);
            this.progress.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(325, 54);
            this.label1.TabIndex = 5;
            this.label1.Text = "YTDownloader";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(100, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 36);
            this.label2.TabIndex = 7;
            this.label2.Text = "Kayıt Yeri:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox1.Location = new System.Drawing.Point(100, 201);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(636, 29);
            this.textBox1.TabIndex = 6;
            // 
            // Main
            // 
            this.AcceptButton = this.download_button;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(833, 500);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.download_button);
            this.Controls.Add(this.linklabel);
            this.Controls.Add(this.link);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox link;
        private System.Windows.Forms.Button download_button;
        private System.Windows.Forms.Label linklabel;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
    }
}

