using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using DTO;
using BUS;
using System.Threading;

namespace _1_bitstamp_API
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
          
        }
        private async void Loadding_BTC_USD()
        {
            List<BTC_USD_DTO> ls_BTC_USD = await BTC_USD_BUS.List_BTC_USD();

            dataGridView1.Invoke(new Action(() => dataGridView1.DataSource = ls_BTC_USD));
        }
        private void Insert_BTC_USD()
        {
            try
            {
                BTC_USD_DTO dto = new BTC_USD_DTO();
                dto.open = double.Parse(dataGridView1.Rows[0].Cells[8].Value.ToString());
                dto.last = double.Parse(dataGridView1.Rows[0].Cells[1].Value.ToString());
                dto.high = double.Parse(dataGridView1.Rows[0].Cells[0].Value.ToString());
                dto.low = double.Parse(dataGridView1.Rows[0].Cells[5].Value.ToString());
                dto.volume = double.Parse(dataGridView1.Rows[0].Cells[4].Value.ToString());
                BTC_USD_BUS bus = new BTC_USD_BUS();
                bus.Insert_BTC_USD(dto);
            }
            catch(Exception)
            {
                //timer1.Stop();
                //MessageBox.Show("BTC/USD API connect has been stopped");
                return;
            }
            finally
            {
                timer1.Start();
            }
            
        }
        private async void Loadding_ETH_USD()
        {
            List<ETH_USD_DTO> ls_ETH_USD =  await ETH_USD_BUS.List_ETH_USD();

            dataGridView2.Invoke(new Action(() => dataGridView2.DataSource = ls_ETH_USD));
        }
        private void Insert_ETH_USD()
        {
            try
            {
                ETH_USD_DTO dto = new ETH_USD_DTO();
                dto.open = double.Parse(dataGridView2.Rows[0].Cells[8].Value.ToString());
                dto.last = double.Parse(dataGridView2.Rows[0].Cells[1].Value.ToString());
                dto.high = double.Parse(dataGridView2.Rows[0].Cells[0].Value.ToString());
                dto.low = double.Parse(dataGridView2.Rows[0].Cells[5].Value.ToString());
                dto.volume = double.Parse(dataGridView2.Rows[0].Cells[4].Value.ToString());
                ETH_USD_BUS bus = new ETH_USD_BUS();
                bus.Insert_ETH_USD(dto);
            }
            catch(Exception)
            {
                //timer1.Stop();
                //MessageBox.Show(" ETH/USD API Connecting has been stopped!");
                return;
            }
            finally
            {
                timer1.Start();
            }
        }
        private async void Loadding_ETH_BTC()
        {

            List<ETH_BTC_DTO> ls_ETH_BTC =  await ETH_BTC_BUS.List_ETH_BTC();
            
            dataGridView3.Invoke(new Action(() => dataGridView3.DataSource = ls_ETH_BTC));
        }
        private void Insert_ETH_BTC()
        {
            try
            {
                ETH_BTC_DTO dto = new ETH_BTC_DTO();
                dto.open = double.Parse(dataGridView3.Rows[0].Cells[8].Value.ToString());
                dto.last = double.Parse(dataGridView3.Rows[0].Cells[1].Value.ToString());
                dto.high = double.Parse(dataGridView3.Rows[0].Cells[0].Value.ToString());
                dto.low = double.Parse(dataGridView3.Rows[0].Cells[5].Value.ToString());
                dto.volume = double.Parse(dataGridView3.Rows[0].Cells[4].Value.ToString());
                ETH_BTC_BUS bus = new ETH_BTC_BUS();
                bus.Insert_ETH_BTC(dto);
            }
            catch(Exception)
            {
                //timer1.Stop();
                //MessageBox.Show(" ETH/BTC API Connecting has been stopped!");
                return;
            }
            finally
            {
                timer1.Start();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Thread A = new Thread(new ThreadStart(Loadding_BTC_USD));           
            Insert_BTC_USD();
            A.Start();

            Thread B = new Thread(new ThreadStart(Loadding_ETH_USD));
            Insert_ETH_USD();
            B.Start();

            Thread C = new Thread(new ThreadStart(Loadding_ETH_BTC));
            Insert_ETH_BTC();
            C.Start();

            timer1.Interval = 1000;
        }

        private void Chart()
        {
            //Dictionary<int, double> value = new Dictionary<int, double>();
            //List<ETH_BTC_DTO> ls_ETH_BTC = ETH_BTC_BUS.List_ETH_BTC();
            //chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
            //chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;
            //chart1.DataSource = value;
            //chart1.Series["Series1"].XValueMember = "USD";
            //chart1.Series["Series1"].YValueMembers = "value";
            ////chart1.Series["Series1"].Points.AddY("20");
            ////chart1.Series["Series1"].Points.AddY("20");
            ////chart1.Series["Series1"].Points.AddY("30");

            //chart1.Series["Series1"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            
            //chart1.Refresh();
            //value.Clear();
            //value.Add(1,12);
            //chart1.DataBind();
        }
    }
}
