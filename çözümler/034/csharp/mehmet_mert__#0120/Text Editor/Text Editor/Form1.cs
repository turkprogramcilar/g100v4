using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Text_Editor
{
    public partial class Form1 : Form
    {
        //Dialogs
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private FontDialog fontDialog;
        string file_name;
        string new_path;
        public Form1()
        {
            InitializeComponent();
        }
        private void NewFile()
        {
            try
            {
                this.richTextBox1.Text = string.Empty;
                this.Text = "Untitled" + DateTime.Now.ToString("MM.dd.yyyyHH.mm.ss") ;
                openFileDialog = null;
                saveFileDialog = null;
            }
            catch
            {
                
            }

        }
        private void SaveFile()
        {
            try
            {
                if (openFileDialog != null)
                {
                    File.WriteAllText(openFileDialog.FileName, this.richTextBox1.Text);
                    this.Text = openFileDialog.FileName + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"); 
                }
                else
                {
                    if (saveFileDialog == null)
                    {
                        saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = "Text File (*.txt) | *.txt";
                        saveFileDialog.ShowDialog();
                    }
                    File.WriteAllText(saveFileDialog.FileName, this.richTextBox1.Text);
                    this.Text = saveFileDialog.FileName + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                }
            }
            catch
            {

            }
        }
        private void AutoSave()
        {
            try
            {
                if (openFileDialog != null)
                {
                    File.WriteAllText(file_name, this.richTextBox1.Text);
                    this.Text = new_path; 
                }
                else
                {
                    if (saveFileDialog == null)
                    {
                        saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = "Text File (*.txt) | *.txt";
                        saveFileDialog.ShowDialog();
                    }
                    File.WriteAllText(saveFileDialog.FileName, this.richTextBox1.Text);
                    this.Text = saveFileDialog.FileName;
                }
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void OpenFile()
        {
            try
            {
                openFileDialog = new OpenFileDialog();
                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.richTextBox1.Text = File.ReadAllText(openFileDialog.FileName);
                    this.Text = openFileDialog.FileName;
                }
            }
            catch
            {
                MessageBox.Show("Dosya açarken bir hata oluştu");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFile();
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AutoSave();
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
            try
            {
                //değişken.Substring(0, authors.IndexOf(","));
                //değişken.Substring(authors.IndexOf(",") + 1);
                string time = DateTime.Now.ToString("MM.dd.yyyyHH.mm.ss") + ".txt";
                if (Path.GetFileNameWithoutExtension(openFileDialog.FileName).Length > 19) 
                {
                    string salt_isim = Path.GetFileNameWithoutExtension(openFileDialog.FileName).Substring(Path.GetFileNameWithoutExtension(openFileDialog.FileName).IndexOf("-") + 1);
                    try
                    {
                        Convert.ToInt32(salt_isim[0]);
                        Convert.ToInt32(salt_isim[1]);
                        Convert.ToInt32(salt_isim[3]);
                        Convert.ToInt32(salt_isim[4]);
                        Convert.ToInt32(salt_isim[6]);
                        Convert.ToInt32(salt_isim[7]);
                        Convert.ToInt32(salt_isim[8]);
                        Convert.ToInt32(salt_isim[9]);
                        Convert.ToInt32(salt_isim[10]);
                        Convert.ToInt32(salt_isim[11]);
                        Convert.ToInt32(salt_isim[13]);
                        Convert.ToInt32(salt_isim[14]);
                        Convert.ToInt32(salt_isim[16]);
                        Convert.ToInt32(salt_isim[17]);
                        string modlu_isim = Path.GetFileNameWithoutExtension(openFileDialog.FileName).Remove(Path.GetFileNameWithoutExtension(openFileDialog.FileName).Length-19);
                        new_path = Path.GetDirectoryName(openFileDialog.FileName) + "\\" + modlu_isim + "-"+ time ;
                        file_name = Path.GetFullPath(openFileDialog.FileName);
                        File.Move(file_name, new_path);
                        file_name = new_path;
                        //File.Delete(file_name);
                    }
                    catch
                    {
                        new_path = Path.GetDirectoryName(openFileDialog.FileName) + "\\" + Path.GetFileNameWithoutExtension(openFileDialog.FileName) + "-" + time ;
                        file_name = Path.GetFullPath(openFileDialog.FileName);
                        File.Move(file_name, new_path);
                        file_name = new_path;
                        //File.Delete(file_name);
                    }
                }
                else
                {
                    new_path = Path.GetDirectoryName(openFileDialog.FileName) + "\\" + Path.GetFileNameWithoutExtension(openFileDialog.FileName) + "-" + time;
                    file_name = Path.GetFullPath(openFileDialog.FileName);
                    File.Move(file_name, new_path);
                    file_name = new_path;
                    //File.Delete(file_name);
                }
                
            }
            catch
            {

            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveAsToolStripMenuItem.Checked == true)
            {
                saveAsToolStripMenuItem.Checked = false;
                saveToolStripMenuItem.Enabled = true;
            }
            else if (saveAsToolStripMenuItem.Checked == false)
            {
                saveAsToolStripMenuItem.Checked = true;
                saveToolStripMenuItem.Enabled = false;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.richTextBox1.Text))
                {
                    MessageBox.Show("Kaydediliyor.");
                    SaveFile();
                }
                else
                {
                    this.Close();
                }
            }
            catch
            {

            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                fontDialog = new FontDialog();
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    this.richTextBox1.Font = fontDialog.Font;
                }
            }
            catch
            {

            }
        }

        private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (saveAsToolStripMenuItem.Checked == true)
            {
                AutoSave();
            }
            
        }
    }
}
