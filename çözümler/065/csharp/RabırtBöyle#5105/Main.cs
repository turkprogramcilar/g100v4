using System;
using System.Windows.Forms;
using System.IO;
using VideoLibrary;
using MediaToolkit;

namespace YTDownloader
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        public string appLocation = Application.StartupPath;

        private async void button1_Click(object sender, EventArgs e)
        {
            if(link.Text == "")
            {
                MessageBox.Show("Link giriniz!!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                progress.Value = 0;
                download_button.Enabled = false;


                var fileLoc = textBox1.Text;
                var yt = YouTube.Default;
                var video = await yt.GetVideoAsync(link.Text);

                progress.Value = 30;

                File.WriteAllBytes(fileLoc + video.FullName, await video.GetBytesAsync());

                progress.Value = 60;

                var mp4 = new MediaToolkit.Model.MediaFile { Filename = fileLoc + video.FullName };
                var mp3 = new MediaToolkit.Model.MediaFile { Filename = fileLoc + video.FullName + ".mp3" };

                using (var enging = new Engine())
                {
                    enging.GetMetadata(mp4);
                    enging.Convert(mp4, mp3);
                }

                progress.Value = 90;
                File.Delete(fileLoc + video.FullName);

                progress.Value = 100;

                MessageBox.Show($"{video.FullName}.mp3, {fileLoc} konumuna indirildi", "İşlem Başarılı", MessageBoxButtons.OK,MessageBoxIcon.Information);

                download_button.Enabled = true;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            textBox1.Text = @appLocation + @"\Downloads\";

            if (Directory.Exists(@appLocation+@"\Downloads\")){}
            else
            {
                Directory.CreateDirectory(@appLocation+@"\Downloads\");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

    }
}
