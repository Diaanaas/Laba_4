using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace Project_laba
{
    class Helper
    {
        const string path = @"../../ToDoData.json";
        static System.Timers.Timer t;
        static int h, m=25, s;
        public static async void FetchFromFile()
        {
            var option = new JsonSerializerOptions
            {
                WriteIndented = true,
                IncludeFields = true
            };
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                Form1.instance.data = await JsonSerializer.DeserializeAsync<List<Data>>(fs);
                Form1.instance.dataSaveToFile = Form1.instance.data;
                var show = JsonSerializer.Serialize(Form1.instance.data, option);
            }
            Form1.instance.dataBindingSource.DataSource = Form1.instance.dataSaveToFile;
        }
        public static async void SaveToFile()
        {
            var option = new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
            };
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    await JsonSerializer.SerializeAsync(fs, Form1.instance.dataSaveToFile, option);
                }
                MessageBox.Show("Дані успішно збережні у файл", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Error", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public static void LoadTimer()
        {
            t = new System.Timers.Timer(1000);
            t.Elapsed += (sender, eventArgs) =>
            {
                if (h == 0 && m == 0 && s == 0)
                {
                    t.Stop();
                    return;
                }
                if (s == 00)
                {
                    s = 59;
                    m -= 1;
                }
                else
                {
                    s -= 1;
                }
                
                
                Form1.instance.textBox2.Text = TimerResult();
            };

        }
        static public void StartTimer()
        {
            t.Start();
        }
        static public void StopTimer()
        {
            t.Stop();
        }
        static public void ClearTimer()
        {
            h = 0; m = 25; s = 0;
            Form1.instance.textBox2.Text = TimerResult();
        }
        static private string TimerResult()
        {
            return string.Format("{0}:{1}:{2}",
                        h.ToString().PadLeft(2, '0'),
                        m.ToString().PadLeft(2, '0'),
                        s.ToString().PadLeft(2, '0'));
        }

    }
}
