using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace p4lab5
{
    public partial class Form1 : Form
    {

        Random rand = new Random();
        int randomCount = 0;
        BindingList<string> drawnNumbers = new BindingList<string>();

        BindingList<Number> numbers = new BindingList<Number>();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = drawnNumbers;            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            var path = openFileDialog1.FileName;

            var content = File.ReadAllText(path);

            textBox1.Text = content;
            var filenumbers = content.Split(new[] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in filenumbers)
            {
                numbers.Add(new Number() { value = item });
                flowLayoutPanel1.Controls.Add(GenerateNumberTextBox(item));
            }

            textBox2.Visible = true;
            button2.Enabled = true;
        }

        private TextBox GenerateNumberTextBox(string number)
        {
            return new TextBox()
            {
                Text = number,
                ReadOnly = true,
                Width = 25,
            };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var randomNumber = rand.Next(50);
            textBox2.Text = randomNumber.ToString();
            randomCount++;
            if (randomCount % 10 == 0)
                drawnNumbers.Add(randomNumber.ToString());
        }
    }
}
