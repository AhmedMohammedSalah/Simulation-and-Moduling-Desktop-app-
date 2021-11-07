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
    public partial class Form2 : Form
    {
        public double[] service_time_prop = new double[8];
        public double[] service_cumlative = new double[8];
        public int[] service_time = new int [8];
        public int[] service_from = new int[8];
        public int[] service_to = new int[8];
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            service_time[0] = Convert.ToInt32(st1.Text);
            service_time[1] = Convert.ToInt32(st2.Text);
            service_time[2] = Convert.ToInt32(st3.Text);
            service_time[3] = Convert.ToInt32(st4.Text);
            service_time[4] = Convert.ToInt32(st5.Text);
            service_time[5] = Convert.ToInt32(st6.Text);
            service_time[6] = Convert.ToInt32(st7.Text);
            service_time[7] = Convert.ToInt32(st8.Text);

            service_time_prop[0] = Convert.ToDouble(textBox1.Text);
            service_time_prop[1] = Convert.ToDouble(textBox2.Text);
            service_time_prop[2] = Convert.ToDouble(textBox3.Text);
            service_time_prop[3] = Convert.ToDouble(textBox4.Text);
            service_time_prop[4] = Convert.ToDouble(textBox5.Text);
            service_time_prop[5] = Convert.ToDouble(textBox6.Text);
            service_time_prop[6] = Convert.ToDouble(textBox7.Text);
            service_time_prop[7] = Convert.ToDouble(textBox8.Text);
            service_cumlative[0] = 0;
            service_cumlative[1] = service_time_prop[0];
            service_cumlative[2] = service_time_prop[0] + service_time_prop[1];
            service_cumlative[3] = service_time_prop[0] + service_time_prop[1] + service_time_prop[2];
            service_cumlative[4] = service_time_prop[0] + service_time_prop[1] + service_time_prop[2] + service_time_prop[3];
            service_cumlative[5] = service_time_prop[0] + service_time_prop[1] + service_time_prop[2] + service_time_prop[3] + service_time_prop[4];
            service_cumlative[6] = service_time_prop[0] + service_time_prop[1] + service_time_prop[2] + service_time_prop[3] + service_time_prop[4] + service_time_prop[5];
            service_cumlative[7] = service_time_prop[0] + service_time_prop[1] + service_time_prop[2] + service_time_prop[3] + service_time_prop[4] + service_time_prop[5] + service_time_prop[6];
            
            
            service_to[7] = 1000;
            service_from[0] = Convert.ToInt32(1000 * service_cumlative[0]);
            service_from[1] = Convert.ToInt32(1000 * service_cumlative[1]);
            service_from[2] = Convert.ToInt32(1000 * service_cumlative[2]);
            service_from[3] = Convert.ToInt32(1000 * service_cumlative[3]);
            service_from[4] = Convert.ToInt32(1000 * service_cumlative[4]);
            service_from[5] = Convert.ToInt32(1000 * service_cumlative[5]);
            service_from[6] = Convert.ToInt32(1000 * service_cumlative[6]);
            service_from[7] = Convert.ToInt32(1000 * service_cumlative[7]);
            service_to[0] = service_from[1] - 1;
            service_to[1] = service_from[2] - 1;
            service_to[2] = service_from[3] - 1;
            service_to[3] = service_from[4] - 1;
            service_to[4] = service_from[5] - 1;
            service_to[5] = service_from[6] - 1;
            service_to[6] = service_from[7] - 1;
            Form3 f3 = new Form3();
            f3.Show();

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
