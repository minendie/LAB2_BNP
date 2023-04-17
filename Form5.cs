using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB2
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        [Serializable]
        public class Student
        {
            public string ID { get; set; } = "";
            public string Name { get; set; } = "";
            public string Phone { get; set; } = "";
            public float MScore { get; set; } = 0;
            public float LScore { get; set; } = 0;
            public float Average { get; set; } = 0;



        }
        public List<Student> stdnt = new List<Student>();
        public List<Student> des_stdnt = new List<Student>();

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool flag = true;

            foreach (TextBox textBox in Controls.OfType<TextBox>())
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    MessageBox.Show("Please fill in full information of student before adding to the list!!!");
                    flag = false;
                    break;
                }
                else if (textBox.Name == "textBox1")
                {
                    bool digit = false;
                    foreach (char c in textBox.Text)
                    {
                        if (char.IsDigit(c))
                        {
                            digit = true;
                            break;
                        }
                    }
                    if (digit)
                    {
                        MessageBox.Show("Please enter characters not any numbers for Name");
                        flag = false;
                        break;
                    }


                }

                else if (textBox.Name == "textBox3" && !int.TryParse(textBox.Text, out int num1))
                {
                    MessageBox.Show("Please enter right phone number!");
                    flag = false;
                    break;

                }
                else if (textBox.Name == "textBox4" && (!float.TryParse(textBox.Text, out float num2) || textBox.Text.Contains(",") || num2 > 10 || num2 < 0) || textBox.Name == "textBox5" && (!float.TryParse(textBox.Text, out float num3) || textBox.Text.Contains(",") || num3 > 10 || num3 < 0))
                {
                    MessageBox.Show("Please enter valid values for scores!\n");
                    flag = false;
                    break;
                }

            }
            if (flag)
            {
                Student student = new Student();

                student.Name = textBox1.Text;
                richTextBox1.Text += textBox1.Text + "\n";
                student.ID = textBox2.Text;
                richTextBox1.Text += textBox2.Text + "\n";
                student.Phone = textBox3.Text;
                richTextBox1.Text += textBox3.Text + "\n";
                student.MScore = float.Parse(textBox4.Text);
                richTextBox1.Text += textBox4.Text + "\n";
                student.LScore = float.Parse(textBox5.Text);
                richTextBox1.Text += textBox5.Text + "\n" + "\n";
                stdnt.Add(student);
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                textBox4.Text = string.Empty;
                textBox5.Text = string.Empty;

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();
            FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, stdnt);
            fs.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = File.OpenRead(openFileDialog.FileName))
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    des_stdnt = binaryFormatter.Deserialize(fs) as List<Student>;
                }
                MessageBox.Show("Read successfully!");
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                {
                    for (int i = 0; i < des_stdnt.Count(); i++)
                    {
                        des_stdnt[i].Average = (des_stdnt[i].MScore + des_stdnt[i].LScore) / 2;
                        sw.WriteLine(des_stdnt[i].Name);
                        sw.WriteLine(des_stdnt[i].ID);
                        sw.WriteLine(des_stdnt[i].Phone);
                        sw.WriteLine(des_stdnt[i].MScore);
                        sw.WriteLine(des_stdnt[i].LScore);
                        sw.WriteLine(des_stdnt[i].Average);
                    }
                }
            }
        }
    }
}
