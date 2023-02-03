using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace part4
{
    public partial class Form2 : Form
    {
      
        public Form2( )
        {
            InitializeComponent();
        }

        public string Col_Item;
        public string Col_Type;
        public string Col_Date;
        public string Col_Cash;

        private void button1_Click(object sender, EventArgs e)
        {
            Col_Date = textBox1.Text;
            if (textBox1.Text.Trim().Length == 0)
            {
                showmes("Vui long nhap thoi gian");
                return;
            }
            Col_Item = comboBox1.Text;
            if (comboBox1.Text.Trim().Length == 0)
            {
                showmes("Vui long chon muc");
                return;
            }
            Col_Type = comboBox2.Text;
            if (comboBox2.Text.Trim().Length == 0)
            {
                showmes("Vui chon khoan");
                return;
            }
            Col_Cash = textBox2.Text;
            if (textBox2.Text.Trim().Length == 0)
            {
                showmes("Vui long nhap so tien");
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();


        }
        public void showmes(string text) {
            string title = "erro";
            MessageBox.Show(text, title);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
            this.Close();
            return;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            //{
            //    e.Handled = true;
            //}
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int num;
            if (Int32.TryParse(textBox2.Text, out num))
                textBox2.Text = (num).ToString();
            else
                MessageBox.Show("Vui long nhap so");
            return;
        }
    }
}
