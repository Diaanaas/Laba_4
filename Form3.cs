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
    public partial class Form3 : Form
    {
        private Data cData { get; set; } = null;
        public Form3(Data data)
        {
            InitializeComponent();
            cData = data;
            initValues();
        }
        private void initValues()
        {
            listBox1.Text = cData.Priority;
            richTextBox1.Text = cData.Task;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //update
            Data d = Form1.instance.data.Find(el => el.Id == cData.Id);
            d.Priority = listBox1.Text;
            d.Task = richTextBox1.Text;
            Form1.instance.dataBindingSource.ResetBindings(false);
            Close();
        }
    }
}
