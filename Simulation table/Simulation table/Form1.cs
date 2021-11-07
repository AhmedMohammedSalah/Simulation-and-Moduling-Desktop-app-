using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulation_table
{
    public partial class Form1 : Form
    {
        public double[] cus_arrive_prop = new double[8];
        public double[] cus_arrive_comulative = new double[8];
        public int[] customer_from = new int[8];
        public int[] customer_to = new int[8];


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public void button1_Click(object sender, EventArgs e)
        {
            
            cus_arrive_prop[0] = Convert.ToDouble(textBox1.Text);
            cus_arrive_prop[1] = Convert.ToDouble(textBox2.Text);
            cus_arrive_prop[2] = Convert.ToDouble(textBox3.Text);
            cus_arrive_prop[3] = Convert.ToDouble(textBox4.Text);
            cus_arrive_prop[4] = Convert.ToDouble(textBox5.Text);
            cus_arrive_prop[5] = Convert.ToDouble(textBox6.Text);
            cus_arrive_prop[6] = Convert.ToDouble(textBox7.Text);
            cus_arrive_prop[7] = Convert.ToDouble(textBox8.Text);
            cus_arrive_comulative[0] = 0;
            cus_arrive_comulative[1] = cus_arrive_prop[0];
            cus_arrive_comulative[2] = cus_arrive_prop[0] + cus_arrive_prop[1];
            cus_arrive_comulative[3] = cus_arrive_prop[0] + cus_arrive_prop[1] + cus_arrive_prop[2];
            cus_arrive_comulative[4] = cus_arrive_prop[0] + cus_arrive_prop[1] + cus_arrive_prop[2] + cus_arrive_prop[3];
            cus_arrive_comulative[5] = cus_arrive_prop[0] + cus_arrive_prop[1] + cus_arrive_prop[2] + cus_arrive_prop[3] + cus_arrive_prop[4];
            cus_arrive_comulative[6] = cus_arrive_prop[0] + cus_arrive_prop[1] + cus_arrive_prop[2] + cus_arrive_prop[3] + cus_arrive_prop[4] + cus_arrive_prop[5];
            cus_arrive_comulative[7] = cus_arrive_prop[0] + cus_arrive_prop[1] + cus_arrive_prop[2] + cus_arrive_prop[3] + cus_arrive_prop[4] + cus_arrive_prop[5] + cus_arrive_prop[6];
            
            customer_to[7] = 1000;
            customer_from[0] = Convert.ToInt32(1000 * cus_arrive_comulative[0]);
            customer_from[1] = Convert.ToInt32(1000 * cus_arrive_comulative[1]);
            customer_from[2] = Convert.ToInt32(1000 * cus_arrive_comulative[2]);
            customer_from[3] = Convert.ToInt32(1000 * cus_arrive_comulative[3]);
            customer_from[4] = Convert.ToInt32(1000 * cus_arrive_comulative[4]);
            customer_from[5] = Convert.ToInt32(1000 * cus_arrive_comulative[5]);
            customer_from[6] = Convert.ToInt32(1000 * cus_arrive_comulative[6]);
            customer_from[7] = Convert.ToInt32(1000 * cus_arrive_comulative[7]);
            customer_to[0] = customer_from[1] - 1;
            customer_to[1] = customer_from[2] - 1;
            customer_to[2] = customer_from[3] - 1;
            customer_to[3] = customer_from[4] - 1;
            customer_to[4] = customer_from[5] - 1;
            customer_to[5] = customer_from[6] - 1;
            customer_to[6] = customer_from[7] - 1;



            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
       
        }
    }





