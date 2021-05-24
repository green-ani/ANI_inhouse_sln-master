namespace ani_inhse_app
{
    partial class Frm_med_img_cropping
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
            this.pictureBox_confirm = new System.Windows.Forms.PictureBox();
            this.btn_accept = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_pill_imprint = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_confirm)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_confirm
            // 
            this.pictureBox_confirm.BackColor = System.Drawing.Color.Lavender;
            this.pictureBox_confirm.Location = new System.Drawing.Point(12, 12);
            this.pictureBox_confirm.Name = "pictureBox_confirm";
            this.pictureBox_confirm.Size = new System.Drawing.Size(300, 300);
            this.pictureBox_confirm.TabIndex = 0;
            this.pictureBox_confirm.TabStop = false;
            // 
            // btn_accept
            // 
            this.btn_accept.BackColor = System.Drawing.Color.Aquamarine;
            this.btn_accept.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btn_accept.FlatAppearance.BorderSize = 3;
            this.btn_accept.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.btn_accept.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.btn_accept.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_accept.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_accept.ForeColor = System.Drawing.Color.Black;
            this.btn_accept.Location = new System.Drawing.Point(12, 389);
            this.btn_accept.Name = "btn_accept";
            this.btn_accept.Size = new System.Drawing.Size(118, 68);
            this.btn_accept.TabIndex = 1;
            this.btn_accept.Tag = "Accept";
            this.btn_accept.Text = "Accept And Save";
            this.btn_accept.UseVisualStyleBackColor = false;
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.Pink;
            this.btn_cancel.FlatAppearance.BorderSize = 2;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.Location = new System.Drawing.Point(206, 389);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(106, 68);
            this.btn_cancel.TabIndex = 2;
            this.btn_cancel.Tag = "Drop";
            this.btn_cancel.Text = "Cancel And Drop";
            this.btn_cancel.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 329);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pill Imprint :";
            // 
            // txt_pill_imprint
            // 
            this.txt_pill_imprint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_pill_imprint.Location = new System.Drawing.Point(121, 323);
            this.txt_pill_imprint.Name = "txt_pill_imprint";
            this.txt_pill_imprint.Size = new System.Drawing.Size(191, 26);
            this.txt_pill_imprint.TabIndex = 4;
            // 
            // Frm_med_img_cropping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 473);
            this.Controls.Add(this.txt_pill_imprint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_accept);
            this.Controls.Add(this.pictureBox_confirm);
            this.Name = "Frm_med_img_cropping";
            this.ShowIcon = false;
            this.Text = "Confirmed Med. Image";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_confirm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_confirm;
        private System.Windows.Forms.Button btn_accept;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_pill_imprint;
    }
}