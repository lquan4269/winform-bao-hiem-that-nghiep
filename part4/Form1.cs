using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace part4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            
            Form2 fm2 = new Form2();
            fm2.ShowDialog();
         
            ListViewItem item = new ListViewItem(fm2.Col_Item);
           
            
            item.SubItems.Add(fm2.Col_Type);
            item.SubItems.Add(fm2.Col_Date);
            item.SubItems.Add(fm2.Col_Cash);
            listView1.Items.Add(item);
           
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 fm2 = new Form2();
            if (listView1.CheckedItems.Count > 0)
            {
                int count = listView1.CheckedItems.Count;
                while (listView1.CheckedItems.Count > 0)
                {
                    listView1.Items.Remove(listView1.CheckedItems[0]);
                }
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Text Documents|*.txt", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (TextWriter tw = new StreamWriter(new FileStream(sfd.FileName, FileMode.Create), Encoding.UTF8))
                    {
                        foreach (ListViewItem item in listView1.Items)
                        {
                            await tw.WriteLineAsync(item.SubItems[0].Text + "\t" + item.SubItems[1].Text + "\t" + item.SubItems[2].Text + "\t" + item.SubItems[3].Text);

                        }
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string text;
            OpenFileDialog of = new OpenFileDialog();
            of.ShowDialog();
            try {
                using (var sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "data.txt"))
                {
                    text = sr.ReadLine();
                    while (text != null)
                    {
                        string[] text1 = text.Split(';');
                        Form2 fm2 = new Form2();
                        fm2.ShowDialog();
                        ListViewItem item = new ListViewItem(fm2.Col_Item);


                        item.SubItems.Add(fm2.Col_Type);
                        item.SubItems.Add(fm2.Col_Date);
                        item.SubItems.Add(fm2.Col_Cash);
                        listView1.Items.Add(item);
                        text = sr.ReadLine();
                    }
                }
            }
            catch(Exception ee)
              {
                Console.WriteLine("khong the doc file");
                Console.WriteLine(ee.Message);
            }


        }
    }
}
