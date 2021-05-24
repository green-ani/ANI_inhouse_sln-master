namespace ani_inhse_app
{
    partial class MainFrm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.medicineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medicinePhotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeMedPhotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medPhotoGridViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertAccountNumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.medicineToolStripMenuItem,
            this.convertAccountNumToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // medicineToolStripMenuItem
            // 
            this.medicineToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.medicinePhotoToolStripMenuItem});
            this.medicineToolStripMenuItem.Name = "medicineToolStripMenuItem";
            this.medicineToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.medicineToolStripMenuItem.Text = "Medicine";
            // 
            // medicinePhotoToolStripMenuItem
            // 
            this.medicinePhotoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.takeMedPhotoToolStripMenuItem,
            this.medPhotoGridViewToolStripMenuItem});
            this.medicinePhotoToolStripMenuItem.Name = "medicinePhotoToolStripMenuItem";
            this.medicinePhotoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.medicinePhotoToolStripMenuItem.Tag = "med";
            this.medicinePhotoToolStripMenuItem.Text = "medicine photo";
            this.medicinePhotoToolStripMenuItem.Click += new System.EventHandler(this.medicinePhotoToolStripMenuItem_Click);
            // 
            // takeMedPhotoToolStripMenuItem
            // 
            this.takeMedPhotoToolStripMenuItem.Name = "takeMedPhotoToolStripMenuItem";
            this.takeMedPhotoToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.takeMedPhotoToolStripMenuItem.Tag = "med.take_photo";
            this.takeMedPhotoToolStripMenuItem.Text = "take med. photo";
            this.takeMedPhotoToolStripMenuItem.Click += new System.EventHandler(this.medicinePhotoToolStripMenuItem_Click);
            // 
            // medPhotoGridViewToolStripMenuItem
            // 
            this.medPhotoGridViewToolStripMenuItem.Name = "medPhotoGridViewToolStripMenuItem";
            this.medPhotoGridViewToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.medPhotoGridViewToolStripMenuItem.Tag = "med.photo_grid";
            this.medPhotoGridViewToolStripMenuItem.Text = "med. photo grid view";
            this.medPhotoGridViewToolStripMenuItem.Click += new System.EventHandler(this.medicinePhotoToolStripMenuItem_Click);
            // 
            // convertAccountNumToolStripMenuItem
            // 
            this.convertAccountNumToolStripMenuItem.Name = "convertAccountNumToolStripMenuItem";
            this.convertAccountNumToolStripMenuItem.Size = new System.Drawing.Size(134, 20);
            this.convertAccountNumToolStripMenuItem.Text = "Convert accountNum";
            this.convertAccountNumToolStripMenuItem.Click += new System.EventHandler(this.convertAccountNumToolStripMenuItem_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainFrm";
            this.Text = "MainFrm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem medicineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem medicinePhotoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeMedPhotoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem medPhotoGridViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertAccountNumToolStripMenuItem;
    }
}