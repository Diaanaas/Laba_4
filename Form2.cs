using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_laba
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.Text == "" || richTextBox1.Text == "") throw new Exception("введіть усі поля");   
                Data data = new Data(listBox1.Text, richTextBox1.Text);
                //Form1.instance.data.Add(data);
                Form1.instance.dataSaveToFile.Add(data);
                Form1.instance.data.Append(data);
                Form1.instance.dataBindingSource.ResetBindings(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталась помилка, {ex.Message}", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Close();
        }
    }
}
