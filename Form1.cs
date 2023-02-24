using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Configuration.Install;

namespace ServiceInstaller
{
    public partial class Form1 : Form
    {
        ServiceController controller; 
        public Form1()
        {
            InitializeComponent();
        }

        //Вибір файла служби
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.SafeFileName;
            }
        }

        //Install Service
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 1)
            {
                MessageBox.Show("Виберіть файл з сервісом ");

            }
            else
            {
                try
                {
                    ManagedInstallerClass.InstallHelper(new string[] { openFileDialog1.FileName });
                    MessageBox.Show($"Service {openFileDialog1.SafeFileName} Install!");
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }
        }
        //UnInstall Service
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 1)
            {
                MessageBox.Show("Виберіть файл з сервісом ");

            }
            else
            {
                try
                {
                    ManagedInstallerClass.InstallHelper(new string[] { @"/u", openFileDialog1.FileName });
                    MessageBox.Show($"Service {openFileDialog1.SafeFileName} UnInstall!");
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }
        }
        //Start Service
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                controller = new ServiceController("Service1");
                //controller.ServiceName = "MTService";

                controller.Start();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
               
                controller = new ServiceController("Service1");
                //controller = new ServiceController("MTService");
                controller.Stop();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
