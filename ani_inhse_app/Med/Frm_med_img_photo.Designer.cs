namespace ani_inhse_app
{
    partial class Frm_med_img_photo
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
            this.components = new System.ComponentModel.Container();
            this.combox_med_code = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gpBox = new System.Windows.Forms.GroupBox();
            this.btn_med_preview = new System.Windows.Forms.Button();
            this.btn_med_save = new System.Windows.Forms.Button();
            this.InputChangeTimer = new System.Windows.Forms.Timer(this.components);
            this.CameraList = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_existing = new System.Windows.Forms.Button();
            this.txt_med_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel_left = new System.Windows.Forms.Panel();
            this.panel_right = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_crb = new System.Windows.Forms.TextBox();
            this.panel_main = new System.Windows.Forms.Panel();
            this.VideoPreviewPanel = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.Num_brightness = new System.Windows.Forms.NumericUpDown();
            this.chk_Brightness = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel_left.SuspendLayout();
            this.panel_right.SuspendLayout();
            this.panel_main.SuspendLayout();
            this.VideoPreviewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_brightness)).BeginInit();
            this.SuspendLayout();
            // 
            // combox_med_code
            // 
            this.combox_med_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combox_med_code.FormattingEnabled = true;
            this.combox_med_code.Location = new System.Drawing.Point(182, 18);
            this.combox_med_code.Name = "combox_med_code";
            this.combox_med_code.Size = new System.Drawing.Size(171, 28);
            this.combox_med_code.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Medicine Code :";
            // 
            // gpBox
            // 
            this.gpBox.BackColor = System.Drawing.Color.LightSteelBlue;
            this.gpBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpBox.Location = new System.Drawing.Point(3, 3);
            this.gpBox.Name = "gpBox";
            this.gpBox.Size = new System.Drawing.Size(170, 570);
            this.gpBox.TabIndex = 2;
            this.gpBox.TabStop = false;
            this.gpBox.Text = "Existing Image";
            // 
            // btn_med_preview
            // 
            this.btn_med_preview.BackColor = System.Drawing.Color.AliceBlue;
            this.btn_med_preview.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_med_preview.Location = new System.Drawing.Point(18, 135);
            this.btn_med_preview.Name = "btn_med_preview";
            this.btn_med_preview.Size = new System.Drawing.Size(140, 42);
            this.btn_med_preview.TabIndex = 5;
            this.btn_med_preview.Text = "Preview";
            this.btn_med_preview.UseVisualStyleBackColor = false;
            // 
            // btn_med_save
            // 
            this.btn_med_save.BackColor = System.Drawing.Color.AliceBlue;
            this.btn_med_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_med_save.Location = new System.Drawing.Point(18, 198);
            this.btn_med_save.Name = "btn_med_save";
            this.btn_med_save.Size = new System.Drawing.Size(140, 57);
            this.btn_med_save.TabIndex = 6;
            this.btn_med_save.Text = "Save Image";
            this.btn_med_save.UseVisualStyleBackColor = false;
            // 
            // CameraList
            // 
            this.CameraList.FormattingEnabled = true;
            this.CameraList.Location = new System.Drawing.Point(18, 35);
            this.CameraList.Name = "CameraList";
            this.CameraList.Size = new System.Drawing.Size(140, 21);
            this.CameraList.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_existing);
            this.panel1.Controls.Add(this.txt_med_name);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.combox_med_code);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1060, 100);
            this.panel1.TabIndex = 8;
            // 
            // btn_existing
            // 
            this.btn_existing.BackColor = System.Drawing.Color.AliceBlue;
            this.btn_existing.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_existing.Location = new System.Drawing.Point(689, 52);
            this.btn_existing.Name = "btn_existing";
            this.btn_existing.Size = new System.Drawing.Size(140, 42);
            this.btn_existing.TabIndex = 10;
            this.btn_existing.Text = "Show Existing";
            this.btn_existing.UseVisualStyleBackColor = false;
            // 
            // txt_med_name
            // 
            this.txt_med_name.BackColor = System.Drawing.Color.White;
            this.txt_med_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_med_name.Location = new System.Drawing.Point(182, 62);
            this.txt_med_name.Name = "txt_med_name";
            this.txt_med_name.ReadOnly = true;
            this.txt_med_name.Size = new System.Drawing.Size(458, 26);
            this.txt_med_name.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Medicine Name :";
            // 
            // panel_left
            // 
            this.panel_left.Controls.Add(this.gpBox);
            this.panel_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_left.Location = new System.Drawing.Point(0, 100);
            this.panel_left.Name = "panel_left";
            this.panel_left.Padding = new System.Windows.Forms.Padding(3);
            this.panel_left.Size = new System.Drawing.Size(176, 576);
            this.panel_left.TabIndex = 4;
            // 
            // panel_right
            // 
            this.panel_right.Controls.Add(this.chk_Brightness);
            this.panel_right.Controls.Add(this.Num_brightness);
            this.panel_right.Controls.Add(this.label3);
            this.panel_right.Controls.Add(this.txt_crb);
            this.panel_right.Controls.Add(this.CameraList);
            this.panel_right.Controls.Add(this.btn_med_save);
            this.panel_right.Controls.Add(this.btn_med_preview);
            this.panel_right.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_right.Location = new System.Drawing.Point(890, 100);
            this.panel_right.Name = "panel_right";
            this.panel_right.Size = new System.Drawing.Size(170, 576);
            this.panel_right.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Copy Right By :";
            // 
            // txt_crb
            // 
            this.txt_crb.Location = new System.Drawing.Point(18, 82);
            this.txt_crb.Name = "txt_crb";
            this.txt_crb.Size = new System.Drawing.Size(140, 20);
            this.txt_crb.TabIndex = 8;
            // 
            // panel_main
            // 
            this.panel_main.Controls.Add(this.VideoPreviewPanel);
            this.panel_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_main.Location = new System.Drawing.Point(176, 100);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(714, 576);
            this.panel_main.TabIndex = 11;
            // 
            // VideoPreviewPanel
            // 
            this.VideoPreviewPanel.BackColor = System.Drawing.Color.Lavender;
            this.VideoPreviewPanel.Controls.Add(this.pictureBox);
            this.VideoPreviewPanel.Location = new System.Drawing.Point(14, 13);
            this.VideoPreviewPanel.Name = "VideoPreviewPanel";
            this.VideoPreviewPanel.Size = new System.Drawing.Size(640, 480);
            this.VideoPreviewPanel.TabIndex = 3;
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(640, 480);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // Num_brightness
            // 
            this.Num_brightness.Location = new System.Drawing.Point(18, 284);
            this.Num_brightness.Name = "Num_brightness";
            this.Num_brightness.Size = new System.Drawing.Size(120, 20);
            this.Num_brightness.TabIndex = 10;
            // 
            // chk_Brightness
            // 
            this.chk_Brightness.AutoSize = true;
            this.chk_Brightness.Location = new System.Drawing.Point(18, 261);
            this.chk_Brightness.Name = "chk_Brightness";
            this.chk_Brightness.Size = new System.Drawing.Size(75, 17);
            this.chk_Brightness.TabIndex = 11;
            this.chk_Brightness.Text = "Brightness";
            this.chk_Brightness.UseVisualStyleBackColor = true;
            // 
            // Frm_med_img_photo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1060, 676);
            this.Controls.Add(this.panel_main);
            this.Controls.Add(this.panel_right);
            this.Controls.Add(this.panel_left);
            this.Controls.Add(this.panel1);
            this.Name = "Frm_med_img_photo";
            this.Text = "Medicine Image Form";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_left.ResumeLayout(false);
            this.panel_right.ResumeLayout(false);
            this.panel_right.PerformLayout();
            this.panel_main.ResumeLayout(false);
            this.VideoPreviewPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_brightness)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox combox_med_code;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gpBox;
        private System.Windows.Forms.Button btn_med_preview;
        private System.Windows.Forms.Button btn_med_save;
        private System.Windows.Forms.Timer InputChangeTimer;
        private System.Windows.Forms.ComboBox CameraList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_med_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel_left;
        private System.Windows.Forms.Panel panel_right;
        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.Panel VideoPreviewPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_crb;
        private System.Windows.Forms.Button btn_existing;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.CheckBox chk_Brightness;
        private System.Windows.Forms.NumericUpDown Num_brightness;
    }
}