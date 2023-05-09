namespace DairyManagementSoftware
{
    partial class login
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
            this.login_txt = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.text_inp = new System.Windows.Forms.TextBox();
            this.login_btn = new System.Windows.Forms.Button();
            this.Cancel_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // login_txt
            // 
            this.login_txt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.login_txt.Font = new System.Drawing.Font("Times New Roman", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_txt.Location = new System.Drawing.Point(0, 0);
            this.login_txt.Name = "login_txt";
            this.login_txt.Padding = new System.Windows.Forms.Padding(0, 90, 0, 0);
            this.login_txt.Size = new System.Drawing.Size(1010, 607);
            this.login_txt.TabIndex = 0;
            this.login_txt.Text = "LOGIN";
            this.login_txt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(208, 262);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter Password:";
            // 
            // text_inp
            // 
            this.text_inp.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_inp.Location = new System.Drawing.Point(567, 259);
            this.text_inp.Name = "text_inp";
            this.text_inp.Size = new System.Drawing.Size(234, 41);
            this.text_inp.TabIndex = 2;
            // 
            // login_btn
            // 
            this.login_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_btn.Location = new System.Drawing.Point(317, 395);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(168, 50);
            this.login_btn.TabIndex = 3;
            this.login_btn.Text = "Login";
            this.login_btn.UseVisualStyleBackColor = true;
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
            // 
            // Cancel_btn
            // 
            this.Cancel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancel_btn.Location = new System.Drawing.Point(557, 395);
            this.Cancel_btn.Name = "Cancel_btn";
            this.Cancel_btn.Size = new System.Drawing.Size(168, 50);
            this.Cancel_btn.TabIndex = 4;
            this.Cancel_btn.Text = "Cancel";
            this.Cancel_btn.UseVisualStyleBackColor = true;
            this.Cancel_btn.Click += new System.EventHandler(this.Cancel_btn_Click);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 607);
            this.Controls.Add(this.Cancel_btn);
            this.Controls.Add(this.login_btn);
            this.Controls.Add(this.text_inp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.login_txt);
            this.Name = "login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label login_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox text_inp;
        private System.Windows.Forms.Button login_btn;
        private System.Windows.Forms.Button Cancel_btn;
    }
}

