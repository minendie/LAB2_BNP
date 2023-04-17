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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            FileStream fs = new FileStream(ofd.FileName, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            string content = sr.ReadToEnd();
            richTextBox1.Text = content;
            textBox1.Text = ofd.SafeFileName.ToString();
            textBox2.Text = fs.Name.ToString();
            //count the char, note Lenght count the bytes in file not real characters, each newline represent 2 bytes ('\r\n') 
            textBox5.Text = content.Length.ToString();
            //count lines
            content = content.Replace("\r\n", "\r");
            textBox3.Text = richTextBox1.Lines.Count().ToString();
            content = content.Replace('\r', ' ');
            //count words
            string[] source = content.Split(new char[] { '.', '?', '!', '.', ':', ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            textBox4.Text = source.Count().ToString();
        }
    }
}
