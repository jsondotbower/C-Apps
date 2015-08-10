namespace DateChanger
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnChangeDate = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnPreviousDay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 160);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // BtnChangeDate
            // 
            this.BtnChangeDate.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnChangeDate.Location = new System.Drawing.Point(12, 178);
            this.BtnChangeDate.Name = "BtnChangeDate";
            this.BtnChangeDate.Size = new System.Drawing.Size(300, 47);
            this.BtnChangeDate.TabIndex = 0;
            this.BtnChangeDate.TabStop = false;
            this.BtnChangeDate.Text = "Go to the next day";
            this.BtnChangeDate.UseVisualStyleBackColor = true;
            this.BtnChangeDate.Click += new System.EventHandler(this.BtnChangeDate_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExit.Location = new System.Drawing.Point(12, 284);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(300, 31);
            this.BtnExit.TabIndex = 0;
            this.BtnExit.TabStop = false;
            this.BtnExit.Text = "Turn off the Delorean";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnPreviousDay
            // 
            this.BtnPreviousDay.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPreviousDay.Location = new System.Drawing.Point(12, 231);
            this.BtnPreviousDay.Name = "BtnPreviousDay";
            this.BtnPreviousDay.Size = new System.Drawing.Size(300, 47);
            this.BtnPreviousDay.TabIndex = 0;
            this.BtnPreviousDay.TabStop = false;
            this.BtnPreviousDay.Text = "Go back a day";
            this.BtnPreviousDay.UseVisualStyleBackColor = true;
            this.BtnPreviousDay.Click += new System.EventHandler(this.BtnPreviousDay_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 326);
            this.Controls.Add(this.BtnPreviousDay);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.BtnChangeDate);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Delorean";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BtnChangeDate;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button BtnPreviousDay;
    }
}

