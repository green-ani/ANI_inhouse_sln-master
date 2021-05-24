using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Reference path for the following assemblies --> C:\Program Files\Microsoft Expression\Encoder 4\SDK\
//using Microsoft.Expression.Encoder.Devices;
//using Microsoft.Expression.Encoder.Live;
using ani_inhse.Dll;
using ani_inhse.Model;
using ani_inhse;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
namespace ani_inhse_app
{
    public partial class Frm_med_img_photo : Form
    {
        #region Declaration   

        // Creates job for capture of live source
        med_img_dll img_dll = new med_img_dll();

        // Device for live source
        //private LiveDeviceSource _deviceSource;
        FilterInfoCollection USBWebcams = null;
        VideoCaptureDevice Cam = null;

        private DataTable med_code_dt = new DataTable();
        private DataTable med_existing_img_dt = new DataTable();
        string copyrightByStr = "ANI Systems";
        string copyrightStr { get { return string.Format("Copyright {0} © {1}", txt_crb.Text, DateTime.Now.Year); } }
        string med_code_id = "";
        string med_code = "";
        Frm_med_img_cropping confirmForm;
        public Bitmap opbitmap = new Bitmap(400, 400);
        int clipsize = 300;
        #endregion

        public Frm_med_img_photo()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.ImagingForm_Load);
            this.btn_med_preview.Click += new EventHandler(btnPreview_Click);
            this.btn_existing.Click += new EventHandler(btn_existing_click);
            this.btn_med_save.Click += new EventHandler(SaveImageButton_Click);
            this.FormClosed += new FormClosedEventHandler(ImagingForm_Close);

        }

        private void ImagingForm_Load(object sender, EventArgs e)
        {
            StartImaging();
            DataBaseWork();
            //SetImagePanel();
            txt_crb.Text = copyrightByStr;
        }
        private void ImagingForm_Close(object sender, EventArgs e)
        {
            if (Cam != null)
            {
                if (Cam.IsRunning)  // When Form1 closes itself, WebCam must stop, too.
                {
                    Cam.Stop();   // WebCam stops capturing images.
                }
            }
        }
        private void SetImagePanel()
        {
            VideoPreviewPanel.Width = 962;
            VideoPreviewPanel.Height = 722;

        }
        #region Camera Handling

        //*********************************************************************************
        //Load name of available USB Cameras, Camera must have a name contains string "USB"
        //*********************************************************************************
        private void StartImaging()
        {
            int numberofcameras = LoadDeviceList();
        }
        //End *************************************************





        //*********************************************************************************
        //Load name of available USB Cameras, Camera must have a name contains string "USB"
        //*********************************************************************************
        private int LoadDeviceList()
        {
            //Clear the USB Camera List
            CameraList.Items.Clear();
            USBWebcams = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach(FilterInfo video in USBWebcams)
            {
                if (video.Name.Contains("USB")) CameraList.Items.Add(video.Name);
            }
            //    //Loop through every video device working online in the system
            //    foreach (EncoderDevice ecoderdevice in EncoderDevices.FindDevices(EncoderDeviceType.Video))
            //    {
            //        //Screen for USB Cameras and load Camera List
            //        if (ecoderdevice.Name.Contains("USB")) { CameraList.Items.Add(ecoderdevice.Name); };
            //    }

            return CameraList.Items.Count;
        }
        //End *************************************************


        //*********************************************************************************
        //Handles Preview Button Click
        //*********************************************************************************
        private void btnPreview_Click(object sender, EventArgs e)

        {

            VideoCaptureDeviceForm videoSettings = new VideoCaptureDeviceForm();
            //videoSettings.ShowDialog();
            if (USBWebcams.Count > 0)  // The quantity of WebCam must be more than 0.
            {
                for(int i=0; i< USBWebcams.Count; i++)
                {
                    string camStr = USBWebcams[i].Name;
                    if(Cam != null && camStr.Contains("USB"))
                    {
                        Cam.Start();
                    }
                    else if(Cam == null && camStr.Contains("USB"))
                    {
                        Cam = new VideoCaptureDevice(USBWebcams[i].MonikerString);
                Cam.NewFrame += new NewFrameEventHandler(Cam_NewFrame);
            Cam.Start();   // WebCam starts capturing images.
                    }
                }
                

                //Cam = videoSettings.VideoDevice;
                //Cam.SignalToStop();
            } 
            else
            {
                MessageBox.Show("No video input device is connected.");
            }
            if(Cam == null)
            {
                MessageBox.Show("USB Camera device is not connected.");
            }
            //EncoderDevice video = null;
            //EncoderDevice audio = null;

            //if (CameraList.Items.Count < 1)
            //{
            //    MessageBox.Show("no device connected");
            //    return;
            //}
            ////Check the selected camera
            //GetSelectedVideoAndAudioDevices(out video, out audio);

            ////Stop _job created to have the refresh selection 
            //StopJob(_job);

            //// Starts new job for preview window
            //_job = new LiveJob();

            //// Checks for a/v devices
            //if (video != null) //{ SetVideoSource(); }

            //{
            //    // Create a new device source. We use the first audio and video devices on the system
            //    _deviceSource = _job.AddDeviceSource(video, audio);


            //    // Get the properties of the device video
            //    SourceProperties sp = _deviceSource.SourcePropertiesSnapshot();

            //    //// Sets preview window to winform panel hosted by xaml window
            //    _deviceSource.PreviewWindow = new PreviewWindow(new HandleRef(pictureBox, pictureBox.Handle));
            //    string test = VideoPreviewPanel.Location.X.ToString();

            //    // Make this source the active one
            //    _job.ActivateSource(_deviceSource);

        //}

        }
        //End btnPreview_Click************************************
        void Cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            //pictureBox.Image = (Bitmap)eventArgs.Frame.Clone();
            Image img = (Bitmap)eventArgs.Frame.Clone();
            Graphics g = Graphics.FromImage(img);

            //Set clip starting point for image in the centre
            int mid_pt_x = (pictureBox.Size.Width - clipsize) / 2 - 4;
            int mid_pt_y = (pictureBox.Size.Height - clipsize) / 2 -4;
            Rectangle rect = new Rectangle(mid_pt_x, mid_pt_y, clipsize+6, clipsize+6);
            g.DrawRectangle(new Pen(Color.Yellow, 3), rect);
            g.Dispose();
            if(chk_Brightness.Checked)
            {
                int br_val = Convert.ToInt32(Num_brightness.Value);
                AForge.Imaging.Filters.BrightnessCorrection br = new AForge.Imaging.Filters.BrightnessCorrection(br_val);
                img = br.Apply((Bitmap)img.Clone());
            }
            pictureBox.Image = img;
        }
        //*********************************************************************************
        //Stop Livejobs
        //*********************************************************************************
        /*void StopJob(LiveJob thisencoderjob)
        {
            // Has the Job already been created ?
            if (thisencoderjob != null)
            {
                // Yes
                // Is it capturing ?
                if (thisencoderjob.IsCapturing)
                    thisencoderjob.StopEncoding();

                // Remove the Device Source and destroy the job
                thisencoderjob.RemoveDeviceSource(_deviceSource);

                // Destroy the device source
                _deviceSource.PreviewWindow = null;
                _deviceSource = null;
            }
        }*/
        //End *************************************************

        //*********************************************************************************
        //Load name of available USB Cameras, Camera must have a name contains string "USB"
        //*********************************************************************************
        //private void GetSelectedVideoAndAudioDevices(out EncoderDevice video, out EncoderDevice audio)
        //{
        //    video = null;
        //    audio = null;



        //    // Get the selected video device            
        //    foreach (EncoderDevice edv in EncoderDevices.FindDevices(EncoderDeviceType.Video))
        //    {
        //        string selectitem = CameraList.Items[0].ToString();

        //        try
        //        {

        //            selectitem = CameraList.SelectedItem.ToString();
        //        }
        //        catch { }

        //        if (selectitem == null)
        //        {
        //            //
        //            MessageBox.Show("No Camera", "System Error", MessageBoxButtons.OK);
        //            return;
        //        }
        //        else
        //        {

        //            if (String.Compare(edv.Name, selectitem) == 0)
        //            {
        //                video = edv;

        //                break;
        //            }
        //        }
        //    }
        //}




        //End GetSelectedVideoAndAudioDevices**********************




        #endregion Camera Handling

        private void DataBaseWork()
        {
            med_code_dt.Clear();
            string sql = "SELECT medicine_id, medicine_code, medicine_name FROM med_photo_brief WHERE valid = 'Y'";
            med_code_dt = mysql.excuteSQLToDataTable(AppSetting.animedConn, sql);
            set_combo_med_code();
        }

        private void set_combo_med_code()
        {
            combox_med_code.DataSource = med_code_dt;
            combox_med_code.DisplayMember = "medicine_code";
            combox_med_code.ValueMember = "medicine_id";
            combox_med_code.AutoCompleteMode = AutoCompleteMode.Suggest;
            combox_med_code.AutoCompleteSource = AutoCompleteSource.ListItems;
            combox_med_code.SelectedIndexChanged += new EventHandler(combo_med_code_selectedIndex_Change);
        }

        #region event handler
        private void combo_med_code_selectedIndex_Change(object sender, System.EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            int selectedIdx = comboBox.SelectedIndex;
            if (selectedIdx >= 0)
            { txt_med_name.Text = med_code_dt.Rows[selectedIdx]["medicine_name"].ToString();
                btn_med_save.Visible = true;
            }
            else
            { txt_med_name.Text = ""; }
        }

        private void btn_existing_click (object sender, EventArgs e)
        {
            string selected_code = this.combox_med_code.SelectedValue.ToString();
            string sql = string.Format("SELECT med_photo_id, img, thum_img, valid FROM med_photo_details where medicine_id = '{0}' and  valid = 'Y'", selected_code);
            med_existing_img_dt = mysql.excuteSQLToDataTable(AppSetting.animedConn, sql);
            LoadThumbnails(med_existing_img_dt);
        }

        private void SaveImageButton_Click(object sender, EventArgs e)
        {
            Cam.SignalToStop();
            med_code_id = combox_med_code.SelectedValue.ToString();
            med_code = combox_med_code.Text.Trim();

            //Disable all input controls in the M
            SetAllFormControls(false);

            //Delegation new instance 
            confirmForm = new Frm_med_img_cropping(this);

            //Set event monitor
            confirmForm.UpdateEventHandler += UpdateEventHandler1;

            //Capture the image of the panel on the screen
            opbitmap = CapturedBitmap(pictureBox);
            confirmForm.set_crop_img( opbitmap);

            //Show form and wait for button input 
            confirmForm.Show();
        }

        //*********************************************************************************
        //Handle the input from the Image Acceptance Form
        //*********************************************************************************
        private void UpdateEventHandler1(object sender, Frm_med_img_cropping.UpdateEventArgs args)
        {

            btn_med_save.Visible = false;
            //string switchname = confirmForm.buttonname;
            confirmForm.Dispose();
            if(confirmForm.DialogResult == DialogResult.OK)
           // if (switchname.Contains("Confirm"))
            {

                //ImageConfirmed(MedCodeBox.SelectedIndex);
                string pill_str = confirmForm.pill_imprint_str;
                img_dll.insert_med_img_by_med_code(med_code_id, opbitmap, pill_str);

                ImagingFormReset();
                SetAllFormControls(true);
            }
            else
            { //DropImage(); }
                SetAllFormControls(true);
                ImagingFormReset();

            }

        }

        #endregion

        #region function
        private void LoadThumbnails(DataTable thisdatatable)
        {
            Clear_thum_img();
            if (thisdatatable.Rows.Count > 0)
            {
                System.Drawing.Point panelpoint = gpBox.Location;
                System.Drawing.Point newimagepoint = new System.Drawing.Point(5, 20);
                foreach (DataRow dr in thisdatatable.Rows)
                {
                    byte[] thumbnailbytes = dr.Field<byte[]>("thum_img");
                    string imageuid = dr["med_photo_id"].ToString();
                    byte[] iamgebytes = dr.Field<byte[]>("img");

                    MedThumbnails thisthumbnail = new MedThumbnails(thumbnailbytes, imageuid, iamgebytes);
                    thisthumbnail.Location = newimagepoint;
                    gpBox.Controls.Add(thisthumbnail);
                    newimagepoint.Y = newimagepoint.Y + 104;
                    thisthumbnail.Click += new EventHandler(ShowImageOfThumbnail);

                }
            }
        }

        private void ShowImageOfThumbnail(object sender, EventArgs e)
        {
            MedThumbnails thisthumbnail = (MedThumbnails)sender;

            Frm_med_img_view newform1 = new Frm_med_img_view();
            newform1.AddImage(thisthumbnail.MedImage);


        }

        private void ImagingFormReset()
        {
            btn_med_save.Hide();
            combox_med_code.SelectedIndex = -1;
            VideoPreviewPanel.BackgroundImage = null;
            med_code_id = "";
            med_code = "";
            Clear_thum_img();
            

        }
        void Clear_thum_img()
        {
            if (gpBox.Controls.Count > 0)
            {
                foreach (Control ctl in gpBox.Controls)
                {
                    ctl.Click -= new System.EventHandler(ShowImageOfThumbnail);
                    gpBox.Controls.Remove(ctl);
                    ctl.Dispose();
                }
            }
        }
        void SetAllFormControls(bool thisstate)
        {
            foreach (Control ctrl in this.Controls)
            {
                ctrl.Enabled = thisstate;
            }
        }
        /// <summary>
        /// 
        ///*********************************************************************************
        ///Returns a  square bitmap centered on the Control with size specified 
        ///Get the screen co-ordinate for the screen clip
        ///!! The screen size must be set to 100% for correct application.
        ///*********************************************************************************
        /// </summary>
        /// <param name="thiscontrol"></param>
        /// <returns></returns>
        ////public Bitmap CapturedBitmap(Control thiscontrol)
        ////{
        ////    //Get the position of the panel

        ////    //Point clippanelpoint = thiscontrol.PointToScreen(Point.Empty);
        ////    Point clippanelpoint = VideoPreviewPanel.PointToScreen(Point.Empty);
        ////    //Specify the clip size here
        ////    int clipsize = 300;

        ////    //Set clip starting point for image in the centre
        ////    int clipstartx = clippanelpoint.X + (thiscontrol.Width - clipsize) / 2;
        ////    int clipstarty = clippanelpoint.Y + (thiscontrol.Height - clipsize) / 2;
        ////    // int clipstartx = clippanelpoint.X + (VideoPreviewPanel.Width - clipsize) / 2;
        ////    //int clipstarty = clippanelpoint.Y + (VideoPreviewPanel.Height - clipsize) / 2;


        ////    //Create a new bitmap size of the panel
        ////    var clipbitmap = new Bitmap(clipsize, clipsize, PixelFormat.Format32bppArgb);

        ////    // Create a graphics size from the panel from the bitmap.
        ////    var gfxScreenshot = Graphics.FromImage(clipbitmap);

        ////    // Take a square screenshot from the centre of the panel
        ////    Font drawFont1 = new Font("Arial", 16, FontStyle.Bold);
        ////    Font drawFont2 = new Font("Arial", 8, FontStyle.Bold);
        ////    SolidBrush drawBrush = new SolidBrush(Color.Black);
        ////    //Bitmap bm = new Bitmap(VideoPreviewPanel.Size.Width, VideoPreviewPanel.Size.Height);
        ////    //int mid_pt_x = (VideoPreviewPanel.Size.Width - clipsize) / 2;
        ////    //int mid_pt_y = (VideoPreviewPanel.Size.Height - clipsize) / 2;
        ////    //VideoPreviewPanel.DrawToBitmap(bm, new Rectangle(0,0, VideoPreviewPanel.Size.Width, VideoPreviewPanel.Size.Height));

        ////    //var gfxScreenshot = Graphics.FromImage(clipbitmap);
        ////    //gfxScreenshot= Graphics.FromImage(bm);
        ////    gfxScreenshot.CopyFromScreen(clipstartx, clipstarty, 0, 0, thiscontrol.Bounds.Size, CopyPixelOperation.SourceCopy);

        ////    // Write the medcode on the image
        ////    // gfxScreenshot.DrawString(med_code, drawFont1, Brushes.Red, 120, 5);
        ////    //gfxScreenshot.DrawString(copyrightStr, drawFont2, Brushes.Red, 5, 280);

        ////    return clipbitmap;

        ////}

            
        public Bitmap CapturedBitmap(Control thiscontrol)
        {
            //Specify the clip size here

            //Set clip starting point for image in the centre
            int mid_pt_x = (thiscontrol.Size.Width - clipsize) / 2;
            int mid_pt_y = (thiscontrol.Size.Height - clipsize) / 2;
            Image bitmap =(Image) pictureBox.Image.Clone();
            Rectangle rect = new Rectangle(mid_pt_x, mid_pt_y, clipsize, clipsize);
            var clipbitmap = new Bitmap(clipsize, clipsize, PixelFormat.Format32bppArgb);
            Bitmap nb = new Bitmap(rect.Width, rect.Height);
            Graphics g = Graphics.FromImage(nb);
            g.DrawImage(bitmap, -rect.X, -rect.Y);
            Font drawFont1 = new Font("Arial", 16, FontStyle.Bold);
            Font drawFont2 = new Font("Arial", 8, FontStyle.Bold);
            g.DrawString(med_code, drawFont1, Brushes.Red, 120, 10);
            g.DrawString(copyrightStr, drawFont2, Brushes.Red, 5, 280);
            return nb;

        }
        #endregion

        private void Frm_med_img_photo_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            VideoCaptureDeviceForm frm = new VideoCaptureDeviceForm();
            frm.Show();

            //if (_deviceSource != null)
            //{

            //    _deviceSource.ShowConfigurationDialog(ConfigurationDialog.VideoCaptureDialog, new HandleRef(VideoPreviewPanel, VideoPreviewPanel.Handle));
            //}
        }

    }
}
