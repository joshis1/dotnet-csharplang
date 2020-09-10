using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventHandler_Delegates_Tutorial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button b2 = new Button();
            b2.Text = "Click Me";
            b2.Size = new Size(100, 50);
            b2.Location = new Point(100, 100);
            this.Controls.Add(b2);

            b2.Click += delegate (object s, EventArgs e1)
            {
                MessageBox.Show("Hello World");
            };

            b2.Click += (s, e1) =>
            {
                MessageBox.Show("Hello Lambda");
            };

        }
    }
}
