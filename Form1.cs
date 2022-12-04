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
    public partial class Form1 : Form
    {
        public static Form1 instance;
        public Form1()
        {
            InitializeComponent();
            instance = this;
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
            }
            
        }
        public List<Data> data { get; set; } = new List<Data>();
        public List<Data> dataSaveToFile { get; set; } = new List<Data>();
        private void Form1_Load(object sender, EventArgs e)
        {
            Helper.FetchFromFile();
            Helper.LoadTimer();
        }

        private void AddTask_Click(object sender, EventArgs e)
        {
            Form2 addForm = new Form2();
            addForm.ShowDialog();
        }

        private void LoadData_Click(object sender, EventArgs e)
        {
            Helper.FetchFromFile();
        }

        private void SaveData_Click(object sender, EventArgs e)
        {
            Helper.SaveToFile();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                if (MessageBox.Show("Ви впевнені, що хочете видалити запис?",
                    "Message", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Data d = (Data)dataBindingSource.Current;
                    List<Data> filtered = data.FindAll(el => el.Id != d.Id);
                    data = filtered;
                    List<Data> filtered2 = dataSaveToFile.FindAll(el => el.Id != d.Id);
                    dataSaveToFile = filtered2;
                    dataSaveToFile = filtered2;
                    dataBindingSource.DataSource = dataSaveToFile;
                }
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
            {
                Data cData = (Data)dataBindingSource.Current;
                Form3 updateForm = new Form3(cData);
                updateForm.ShowDialog();
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> list = new List<string>(); // list of Priority
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if(checkedListBox1.GetItemChecked(i))
                {
                    list.Add(checkedListBox1.GetItemText(checkedListBox1.Items[i]));
                }
            }
                
            List<Data> filtered = data.FindAll(el => list.Contains(el.Priority)); // LinQ filter
            dataSaveToFile = filtered;
            dataBindingSource.DataSource = dataSaveToFile;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string value = textBox1.Text;
            List<Data> filtered = (from el in data
                                where el.Task.ToLower().Contains(value.ToLower()) || el.Priority.ToLower().Contains(value.ToLower())
                                select el).ToList();
            dataSaveToFile = filtered;
            dataBindingSource.DataSource = dataSaveToFile;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();
            aboutForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Helper.StartTimer();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Helper.StopTimer();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Helper.ClearTimer();
        }
    }
}
