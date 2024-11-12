using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.Util;
using System.IO;


namespace AiSystemLaba
{
    public partial class Form1 : Form
    {
        CascadeClassifier faceCascade = new CascadeClassifier(@"C:\Emgu\emgucv-windows-x86 2.4.0.1717\bin\haarcascade_frontalface_default.xml");

        CascadeClassifier eyeCascade = new CascadeClassifier(@"C:\Emgu\emgucv-windows-x86 2.4.0.1717\bin\haarcascade_eye.xml");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog ok = new OpenFileDialog();

            Image img = null;

            string name = "";

            if (ok.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                img = Image.FromFile(ok.FileName);
                name = ok.FileName;
                pictureBox1.Image = img;
            }

            function(name);
        }
        public void function(string puth)
        {
            Image<Bgr, byte> image = new Image<Bgr, byte>(puth);
            Image<Gray, Byte> grayImage = image.Convert<Gray, Byte>();
            var faces = faceCascade.DetectMultiScale(grayImage, 1.1, 3,new Size(20, 20),new Size(500, 500));
            foreach (var face in faces)
            {

                image.Draw(face, new Bgr(255, 255, 255), 10);


                var eyes = eyeCascade.DetectMultiScale(grayImage, 1.1, 3, new Size(20, 20), new Size(500, 500));

                foreach (var eye in eyes)

                {
                    image.Draw(eye, new Bgr(0, 0, 255), 3);
                }

                imageBox1.Image = image;
            }
        }
    }
}

