using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB2
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter a path");
            }
            else
            {
                string folderpath = textBox1.Text;
                DirectoryInfo di = new DirectoryInfo(folderpath);
                if (di.Exists)
                {

                    FileInfo[] fiArr = di.GetFiles();
                    foreach (FileInfo fileInfo in fiArr)
                    {
                        ListViewItem item = new ListViewItem(fileInfo.Name);
                        //item.Text = ;
                        item.SubItems.Add(fileInfo.Length.ToString());
                        item.SubItems.Add(fileInfo.Extension);
                        item.SubItems.Add(fileInfo.CreationTime.ToString());
                        listView1.Items.Add(item);
                    }
                    if (listView1.Items.Count == 0)
                    {
                        MessageBox.Show("There is no file in the folder.");
                    }

                }
                else
                {
                    MessageBox.Show("Folder path not exists, please enter a correct path!");
                }


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            listView1.Items.Clear();
        }
    }
}
