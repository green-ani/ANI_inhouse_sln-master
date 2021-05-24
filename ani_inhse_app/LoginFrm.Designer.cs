namespace ani_inhse_app
{
    partial class LoginFrm
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
            this.label2 = new System.Windows.Forms.Label();
            this.txt_login_name = new System.Windows.Forms.TextBox();
            this.txt_login_pw = new System.Windows.Forms.TextBox();
            this.btn_submit = new System.Windows.Forms.Button();
            this.btn_clr = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label1.Location = new System.Drawing.Point(189, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login Name :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label2.Location = new System.Drawing.Point(159, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Login password :";
            // 
            // txt_login_name
            // 
            this.txt_login_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_login_name.Location = new System.Drawing.Point(318, 129);
            this.txt_login_name.Name = "txt_login_name";
            this.txt_login_name.Size = new System.Drawing.Size(203, 29);
            this.txt_login_name.TabIndex = 2;
            // 
            // txt_login_pw
            // 
            this.txt_login_pw.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_login_pw.Location = new System.Drawing.Point(318, 174);
            this.txt_login_pw.Name = "txt_login_pw";
            this.txt_login_pw.PasswordChar = '*';
            this.txt_login_pw.Size = new System.Drawing.Size(203, 29);
            this.txt_login_pw.TabIndex = 3;
            this.txt_login_pw.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_login_pw_KeyDown);
            // 
            // btn_submit
            // 
            this.btn_submit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_submit.Location = new System.Drawing.Point(318, 243);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(78, 36);
            this.btn_submit.TabIndex = 4;
            this.btn_submit.Text = "OK";
            this.btn_submit.UseVisualStyleBackColor = true;
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // btn_clr
            // 
            this.btn_clr.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clr.Location = new System.Drawing.Point(443, 243);
            this.btn_clr.Name = "btn_clr";
            this.btn_clr.Size = new System.Drawing.Size(78, 36);
            this.btn_clr.TabIndex = 5;
            this.btn_clr.Text = "Clear";
            this.btn_clr.UseVisualStyleBackColor = true;
            this.btn_clr.Click += new System.EventHandler(this.btn_clr_Click);
            // 
            // LoginFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_clr);
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.txt_login_pw);
            this.Controls.Add(this.txt_login_name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "LoginFrm";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_login_name;
        private System.Windows.Forms.TextBox txt_login_pw;
        private System.Windows.Forms.Button btn_submit;
        private System.Windows.Forms.Button btn_clr;
    }
}

