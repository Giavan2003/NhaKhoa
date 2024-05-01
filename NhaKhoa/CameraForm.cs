using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace NhaKhoa
{
    public partial class CameraForm : Form
    {
        private PatientManagementForm patient;
        private VideoCaptureDevice videoSource;
        public CameraForm(PatientManagementForm patient)
        {
            InitializeComponent();
            this.patient = patient;
        }

        private void CameraForm_Load(object sender, EventArgs e)
        {
            FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count == 0)
            {
                MessageBox.Show("Không tìm thấy webcam.");
                return;
            }

            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);
            videoSource.Start();
        }
        private void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            guna2PictureBox1.Image = bitmap;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
            }
        }

        private void bt_chup_Click(object sender, EventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                // Chụp ảnh từ webcam và lưu vào biến image
                Bitmap bitmap = (Bitmap)guna2PictureBox1.Image.Clone();
                patient.SetImage(bitmap);

                // Dừng webcam và đóng Form2
                videoSource.SignalToStop();
                videoSource.NewFrame -= new NewFrameEventHandler(videoSource_NewFrame);
                this.Close();
            }
        }
    }
}
