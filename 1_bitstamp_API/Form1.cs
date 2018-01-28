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
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms.DataVisualization.Charting;

namespace _1_bitstamp_API
{
    public partial class Form1 : Form
    {
        DateTime dt = DateTime.Now;
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
        public DataTable GetData()
        {
            
            DataTable DT = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["bitstamp"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("PriceBTC_USD", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@BeginDate","1/20/2018");
                    cmd.Parameters.AddWithValue("@EndDate",dt);
                    SqlDataReader reader = cmd.ExecuteReader();
                    DT.Load(reader);
                }
            }
            return DT;
        }
        public DataTable GetDataETH_USD()
        {

            DataTable DT = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["bitstamp"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("PriceETH_USD", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@BeginDate", "1/20/2018");
                    cmd.Parameters.AddWithValue("@EndDate", dt);
                    SqlDataReader reader = cmd.ExecuteReader();
                    DT.Load(reader);
                }
            }
            return DT;
        }
        public DataTable GetDataETH_BTC()
        {

            DataTable DT = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["bitstamp"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("PriceETH_BTC", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@BeginDate", "1/20/2018");
                    cmd.Parameters.AddWithValue("@EndDate", dt);
                    SqlDataReader reader = cmd.ExecuteReader();
                    DT.Load(reader);
                }
            }
            return DT;
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
        private void Chart_Drawing()
        {
            chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
            chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;
            chart2.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
            chart2.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;
            chart3.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
            chart3.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;
            chart1.Series["Price"].Points.Clear();
            chart1.Series["Price"].XValueMember = "Day";
            chart1.Series["Price"].YValueMembers = "Hight, Low, Open, Close";
            chart1.DataManipulator.IsStartFromFirst = true;
            chart1.Series["Price"].Color = System.Drawing.Color.Green;
            chart1.Series["Price"].CustomProperties = "PriceDownColor=Green, PriceUpColor=Red";
            chart1.Series["Price"]["ShowClosePriceClosePrice"] = "Both";
            chart1.Series["Price"].XValueType = ChartValueType.Date;
            chart1.DataSource = GetData();
            chart2.Series["Price"].Points.Clear();
            chart2.Series["Price"].XValueMember = "Day";
            chart2.Series["Price"].YValueMembers = "Hight, Low, Open, Close";
            chart2.DataManipulator.IsStartFromFirst = true;
            chart2.Series["Price"].Color = System.Drawing.Color.Green;
            chart2.Series["Price"].CustomProperties = "PriceDownColor=Green, PriceUpColor=Red";
            chart2.Series["Price"]["ShowClosePriceClosePrice"] = "Both";
            chart2.Series["Price"].XValueType = ChartValueType.Date;
            chart2.DataSource = GetDataETH_USD();
            chart3.Series["Price"].Points.Clear();
            chart3.Series["Price"].XValueMember = "Day";
            chart3.Series["Price"].YValueMembers = "Hight, Low, Open, Close";
            chart3.DataManipulator.IsStartFromFirst = true;
            chart3.Series["Price"].Color = System.Drawing.Color.Green;
            chart3.Series["Price"].CustomProperties = "PriceDownColor=Green, PriceUpColor=Red";
            chart3.Series["Price"]["ShowClosePriceClosePrice"] = "Both";
            chart3.Series["Price"].XValueType = ChartValueType.Date;
            chart3.DataSource = GetDataETH_BTC();
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

            Chart_Drawing();
            timer1.Interval = 1000;
        }
    }
}
