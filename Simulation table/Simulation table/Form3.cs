using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Excel = Microsoft.Office.Interop.Excel;


namespace Simulation_table
{
    public partial class Form3 : Form
    {


        public Form3()
        {
            InitializeComponent();

        }

        private void label46_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //opject from form1 +form2 
            var f1 = Application.OpenForms["Form1"] as Form1;
            var f2 = Application.OpenForms["Form2"] as Form2;
            //Random Variable 
            Random random = new Random();
            //fill Random inter label 
            int[] cus_random = new int[8];
            int[] cus_inter = new int[8];
            cus_random[0] = Convert.ToInt32(ra1.Text = Convert.ToString(random.Next(1000)));
            cus_random[1] = Convert.ToInt32(ra2.Text = Convert.ToString(random.Next(1000)));
            cus_random[2] = Convert.ToInt32(ra3.Text = Convert.ToString(random.Next(1000)));
            cus_random[3] = Convert.ToInt32(ra4.Text = Convert.ToString(random.Next(1000)));
            cus_random[4] = Convert.ToInt32(ra5.Text = Convert.ToString(random.Next(1000)));
            cus_random[5] = Convert.ToInt32(ra6.Text = Convert.ToString(random.Next(1000)));
            cus_random[6] = Convert.ToInt32(ra7.Text = Convert.ToString(random.Next(1000)));
            cus_random[7] = Convert.ToInt32(ra8.Text = Convert.ToString(random.Next(1000)));

            //fill inter time label 
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (cus_random[i] >= f1.customer_from[j] && cus_random[i] < f1.customer_to[j])
                    {
                        cus_inter[i] = j+1 ;
                    }

                }
            }
            it1.Text = Convert.ToString(cus_inter[0]);
            it2.Text = Convert.ToString(cus_inter[1]);
            it3.Text = Convert.ToString(cus_inter[2]);
            it4.Text = Convert.ToString(cus_inter[3]);
            it5.Text = Convert.ToString(cus_inter[4]);
            it6.Text = Convert.ToString(cus_inter[5]);
            it7.Text = Convert.ToString(cus_inter[6]);
            it8.Text = Convert.ToString(cus_inter[7]);

            // ----Arival time ---------------
            int[] cus_arrive = new int[8];
            cus_arrive[0] = 0;
            for (int i = 1; i < 8; i++)
            {
                cus_arrive[i] = cus_arrive[i-1] + cus_inter[i];
            }

            at1.Text = Convert.ToString(cus_arrive[0]);
            at2.Text = Convert.ToString(cus_arrive[1]);
            at3.Text = Convert.ToString(cus_arrive[2]);
            at4.Text = Convert.ToString(cus_arrive[3]);
            at5.Text = Convert.ToString(cus_arrive[4]);
            at6.Text = Convert.ToString(cus_arrive[5]);
            at7.Text = Convert.ToString(cus_arrive[6]);
            at8.Text = Convert.ToString(cus_arrive[7]);





            //---------------------------------------------------------------------------
            //fill Random Service label 
            int[] service_random = new int[8];
            int[] service_time = new int[8];
            service_random[0] = Convert.ToInt32(rs1.Text = Convert.ToString(random.Next(1000)));
            service_random[1] = Convert.ToInt32(rs2.Text = Convert.ToString(random.Next(1000)));
            service_random[2] = Convert.ToInt32(rs3.Text = Convert.ToString(random.Next(1000)));
            service_random[3] = Convert.ToInt32(rs4.Text = Convert.ToString(random.Next(1000)));
            service_random[4] = Convert.ToInt32(rs5.Text = Convert.ToString(random.Next(1000)));
            service_random[5] = Convert.ToInt32(rs6.Text = Convert.ToString(random.Next(1000)));
            service_random[6] = Convert.ToInt32(rs7.Text = Convert.ToString(random.Next(1000)));
            service_random[7] = Convert.ToInt32(rs8.Text = Convert.ToString(random.Next(1000)));

            //fill Service time label 
            for (int i = 0; i <8; i++)
            {
                for (int j = 0; j <8; j++)
                {
                    if ((service_random[i] >= f2.service_from[j] )&& (cus_random[i] < f2.service_to[j]))
                    {
                        service_time[i] = f2.service_time[j];
                    }

                }
            }
            st1.Text = Convert.ToString(service_time[0]);
            st2.Text = Convert.ToString(service_time[1]);
            st3.Text = Convert.ToString(service_time[2]);
            st4.Text = Convert.ToString(service_time[3]);
            st5.Text = Convert.ToString(service_time[4]);
            st6.Text = Convert.ToString(service_time[5]);
            st7.Text = Convert.ToString(service_time[6]);
            st8.Text = Convert.ToString(service_time[7]);
            //--------services end && Begin ------------se &&sb

            int[] service_end = new int[8];
            service_end[0] = service_time[0];
            int[] service_begun = new int[8];
            service_begun[0] = 0;
            //--------service end ------------se

            for (int i = 1; i < 8; i++)
            {
                service_begun[i] = Math.Max(service_end[i - 1], cus_arrive[i]);
                service_end[i] = service_time[i] + service_begun[i];
            }
            se1.Text = Convert.ToString(service_end[0]);
            se2.Text = Convert.ToString(service_end[1]);
            se3.Text = Convert.ToString(service_end[2]);
            se4.Text = Convert.ToString(service_end[3]);
            se5.Text = Convert.ToString(service_end[4]);
            se6.Text = Convert.ToString(service_end[5]);
            se7.Text = Convert.ToString(service_end[6]);
            se8.Text = Convert.ToString(service_time[7]);
            //--------service Begin ------------sb
            sb1.Text = Convert.ToString(service_begun[0]);
            sb2.Text = Convert.ToString(service_begun[1]);
            sb3.Text = Convert.ToString(service_begun[2]);
            sb4.Text = Convert.ToString(service_begun[3]);
            sb5.Text = Convert.ToString(service_begun[4]);
            sb6.Text = Convert.ToString(service_begun[5]);
            sb7.Text = Convert.ToString(service_begun[6]);
            sb8.Text = Convert.ToString(service_begun[7]);

            //--------Waiting time  ------------wt

            int[] wait = new int[8];
            wait[0] = 0;
            for (int i = 0; i < 8; i++)
            {
                if (service_begun[i] > cus_arrive[i])
                {
                    wait[i] = service_begun[i] - cus_arrive[i];
                }
                else
                    wait[i] = 0;
            }

            wt1.Text = Convert.ToString(wait[0]);
            wt2.Text = Convert.ToString(wait[1]);
            wt3.Text = Convert.ToString(wait[2]);
            wt4.Text = Convert.ToString(wait[3]);
            wt5.Text = Convert.ToString(wait[4]);
            wt6.Text = Convert.ToString(wait[5]);
            wt7.Text = Convert.ToString(wait[6]);
            wt8.Text = Convert.ToString(wait[7]);
            //-------server idle   ------------si 

            int[] server_idle = new int[8];
            server_idle[0] = 0;
            for (int i = 1; i < 8; i++)
            {
                if (cus_arrive[i] > service_end[i-1])//arrive , service end
                {
                    server_idle[i] = cus_arrive[i] - service_end[i - 1];
                }
                else
                    server_idle[i] = 0;
            }

            si1.Text = Convert.ToString(server_idle[0]);
            si2.Text = Convert.ToString(server_idle[1]);
            si3.Text = Convert.ToString(server_idle[2]);
            si4.Text = Convert.ToString(server_idle[3]);
            si5.Text = Convert.ToString(server_idle[4]);
            si6.Text = Convert.ToString(server_idle[5]);
            si7.Text = Convert.ToString(server_idle[6]);
            si8.Text = Convert.ToString(server_idle[7]);
            

        }
        private void button1_Click(object sender, EventArgs e)
        {
            // -----------------Add Data To Excell Sheat -----------------------
            Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            // to check if there an excell app 
            if (xlApp == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
                return;
            }
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            // fill Data in excell by excell cells 
            // fill head 
            xlWorkSheet.Cells[1, 1] = h1.Text;
            xlWorkSheet.Cells[1, 2] = h2.Text;
            xlWorkSheet.Cells[1, 3] = h3.Text;
            xlWorkSheet.Cells[1, 4] = h4.Text;
            xlWorkSheet.Cells[1, 5] = h5.Text;
            xlWorkSheet.Cells[1, 6] = h6.Text;
            xlWorkSheet.Cells[1, 7] = h7.Text;
            xlWorkSheet.Cells[1, 8] = h8.Text;
            xlWorkSheet.Cells[1, 9] = h9.Text;
            xlWorkSheet.Cells[1, 10] = h10.Text;
            //fill h1 elements 
            xlWorkSheet.Cells[2, 1] = "1";
            xlWorkSheet.Cells[3, 1] = "2";
            xlWorkSheet.Cells[4, 1] = "3";
            xlWorkSheet.Cells[5, 1] = "4";
            xlWorkSheet.Cells[6, 1] = "5";
            xlWorkSheet.Cells[7, 1] = "6";
            xlWorkSheet.Cells[8, 1] = "7";
            xlWorkSheet.Cells[9, 1] = "8";
            //fill h2 elements 
            xlWorkSheet.Cells[2, 2] = ra1.Text;
            xlWorkSheet.Cells[3, 2] = ra2.Text;
            xlWorkSheet.Cells[4, 2] = ra3.Text;
            xlWorkSheet.Cells[5, 2] = ra4.Text;
            xlWorkSheet.Cells[6, 2] = ra5.Text;
            xlWorkSheet.Cells[7, 2] = ra6.Text;
            xlWorkSheet.Cells[8, 2] = ra7.Text;
            xlWorkSheet.Cells[9, 2] = ra8.Text;
            //fill h3 elements 
            xlWorkSheet.Cells[2, 3] = it1.Text;
            xlWorkSheet.Cells[3, 3] = it2.Text;
            xlWorkSheet.Cells[4, 3] = it3.Text;
            xlWorkSheet.Cells[5, 3] = it4.Text;
            xlWorkSheet.Cells[6, 3] = it5.Text;
            xlWorkSheet.Cells[7, 3] = it6.Text;
            xlWorkSheet.Cells[8, 3] = it7.Text;
            xlWorkSheet.Cells[9, 3] = it8.Text; 
            //fill h4 elements 
            xlWorkSheet.Cells[2, 4] = at1.Text;
            xlWorkSheet.Cells[3, 4] = at2.Text;
            xlWorkSheet.Cells[4, 4] = at3.Text;
            xlWorkSheet.Cells[5, 4] = at4.Text;
            xlWorkSheet.Cells[6, 4] = at5.Text;
            xlWorkSheet.Cells[7, 4] = at6.Text;
            xlWorkSheet.Cells[8, 4] = at7.Text;
            xlWorkSheet.Cells[9, 4] = at8.Text;
            //fill h5 elements 
            xlWorkSheet.Cells[2, 5] = rs1.Text;
            xlWorkSheet.Cells[3, 5] = rs2.Text;
            xlWorkSheet.Cells[4, 5] = rs3.Text;
            xlWorkSheet.Cells[5, 5] = rs4.Text;
            xlWorkSheet.Cells[6, 5] = rs5.Text;
            xlWorkSheet.Cells[7, 5] = rs6.Text;
            xlWorkSheet.Cells[8, 5] = rs7.Text;
            xlWorkSheet.Cells[9, 5] = rs8.Text;
            //fill h6 elements 
            xlWorkSheet.Cells[2, 6] = st1.Text;
            xlWorkSheet.Cells[3, 6] = st2.Text;
            xlWorkSheet.Cells[4, 6] = st3.Text;
            xlWorkSheet.Cells[5, 6] = st4.Text;
            xlWorkSheet.Cells[6, 6] = st5.Text;
            xlWorkSheet.Cells[7, 6] = st6.Text;
            xlWorkSheet.Cells[8, 6] = st7.Text;
            xlWorkSheet.Cells[9, 6] = st8.Text;
            //fill h7 elements 
            xlWorkSheet.Cells[2, 7] = sb1.Text;
            xlWorkSheet.Cells[3, 7] = sb2.Text;
            xlWorkSheet.Cells[4, 7] = sb3.Text;
            xlWorkSheet.Cells[5, 7] = sb4.Text;
            xlWorkSheet.Cells[6, 7] = sb5.Text;
            xlWorkSheet.Cells[7, 7] = sb6.Text;
            xlWorkSheet.Cells[8, 7] = sb7.Text;
            xlWorkSheet.Cells[9, 7] = sb8.Text;
            //fill h8 elements 
            xlWorkSheet.Cells[2, 8] = se1.Text;
            xlWorkSheet.Cells[3, 8] = se2.Text;
            xlWorkSheet.Cells[4, 8] = se3.Text;
            xlWorkSheet.Cells[5, 8] = se4.Text;
            xlWorkSheet.Cells[6, 8] = se5.Text;
            xlWorkSheet.Cells[7, 8] = se6.Text;
            xlWorkSheet.Cells[8, 8] = se7.Text;
            xlWorkSheet.Cells[9, 8] = se8.Text;
            //fill h9 elements 
            xlWorkSheet.Cells[2, 9] = wt1.Text;
            xlWorkSheet.Cells[3, 9] = wt2.Text;
            xlWorkSheet.Cells[4, 9] = wt3.Text;
            xlWorkSheet.Cells[5, 9] = wt4.Text;
            xlWorkSheet.Cells[6, 9] = wt5.Text;
            xlWorkSheet.Cells[7, 9] = wt6.Text;
            xlWorkSheet.Cells[8, 9] = wt7.Text;
            xlWorkSheet.Cells[9, 9] = wt8.Text;
            //fill h10 elements 
            xlWorkSheet.Cells[2, 10] = si1.Text;
            xlWorkSheet.Cells[3, 10] = si2.Text;
            xlWorkSheet.Cells[4, 10] = si3.Text;
            xlWorkSheet.Cells[5, 10] = si4.Text;
            xlWorkSheet.Cells[6, 10] = si5.Text;
            xlWorkSheet.Cells[7, 10] = si6.Text;
            xlWorkSheet.Cells[8, 10] = si7.Text;
            xlWorkSheet.Cells[9, 10] = si8.Text;





            xlWorkBook.SaveAs("C:\\Users\\Ahmed Mohamed Salah\\Desktop\\"+textBox1.Text+ ".xls",
                Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue,
                misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue
                , misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);

            MessageBox.Show("Excel file created , you can find the file C:\\Users\\Ahmed Mohamed Salah\\Desktop\\" + textBox1.Text + ".xls");




        }
        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label73_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
