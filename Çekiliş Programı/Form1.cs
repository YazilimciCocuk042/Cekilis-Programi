using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Çekiliş_Programı
{
    public partial class Form1 : Form
    {
        public bool kontrol = false;

        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("Lütfen bir katılımcı ismi girin!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                listBox1.Items.Add(textBox1.Text);
                label3.Text = $"Toplamda {listBox1.Items.Count} katılımcı var!";
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                textBox1.Text = "";
            }
        }

        public void buttonControl()
        {
            for (; ; )
            {    
                if (listBox1.Items.Count > 1)
                {
                    button2.Enabled = true;
                }
                else
                {
                    button2.Enabled = false;
                }  
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;

            Thread thread = new Thread(() => buttonControl());
            thread.IsBackground = true;
            thread.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(guna2ComboBox1.SelectedIndex == 0)
            {
                MessageBox.Show("Lütfen kazanan sayısı seçin!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int kac = 1;
                while (kac <= int.Parse(guna2ComboBox1.SelectedItem.ToString()))
                {
                    Random rnd = new Random();

                    int hedef = rnd.Next(10, 30);

                    for (int sayi_ = 0; sayi_ <= hedef; sayi_++)
                    {
                        int sayi1 = rnd.Next(listBox1.Items.Count);
                        Thread.Sleep(150);
                        listBox1.SelectedIndex = sayi1;
                        sayi_++;
                    }
                    int sayi = rnd.Next(listBox1.Items.Count);
                    listBox1.SelectedIndex = sayi;

                    listBox2.Items.Add($"{kac}. kazanan {listBox1.SelectedItem} olarak seçildi!");
                    listBox2.SelectedIndex = listBox2.Items.Count - 1;

                    label1.Text = $"Toplamda {listBox2.Items.Count} kazanan var!";
                    kac++;
                }
            }  
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(listBox2.Items.Count > 0)
            {
                listBox2.Items.Clear();
                label1.Text = "Toplamda 0 kazanan var!";
            }
            else
            {
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                listBox1.Items.Clear();
                label3.Text = "Toplamda 0 katılımcı var!";
            }
            else
            {
                return;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/yazilimci.cocuk0/");
        }
    }
}
