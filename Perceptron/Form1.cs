using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perceptron
{
    public partial class Form1 : Form
    {
        double w1;
        double w2;
        double bias;
        double learningrate = .5;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private int getOutput(int x1, int x2)
        {
            if (x1 == 1 && x2 == 1)
            {
                return 1;
            }
            else if (x1 == 1 && x2 == -1)
            {
                return 1;
            }
            else if (x1 == -1 && x2 == 1)
            {
                return 1;
            }

            return -1;
        }

        private double Train()
        {
            int epoch = Convert.ToInt32(textBox1.Text);
            int x1 = Convert.ToInt32(textBox2.Text);
            int x2 = Convert.ToInt32(textBox3.Text);
            int output = getOutput(x1, x2);
            double y = 0;

            for (int i = 0; i < epoch; i++)
            {
                if (y <= 0)
                    y = 0;
                if (y > 1)
                    y = 1;

                y = ((x1 * w1) + (x2 * w2)) + bias;

                w1 = (w1 + learningrate * (output - y));
                w2 = (w2 + learningrate * (output - y));
                bias = (bias + learningrate * (output - y));
            }
            return y;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = (Train().ToString());
        }
    }
}
