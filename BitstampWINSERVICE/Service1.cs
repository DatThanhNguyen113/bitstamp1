using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Timers;
using System.Configuration;
using System.Threading;

namespace BitstampWINSERVICE
{
    public partial class Service1 : ServiceBase
    {
        private System.Timers.Timer timer1;
        string sconnect = @"Data Source=NTDPC\SQLEXPRESS;Initial Catalog=bitstampService;Integrated Security=True";
        public Service1()
        {
            InitializeComponent();
            timer1 = new System.Timers.Timer();
            timer1.Interval = 1000;
            timer1.Elapsed += new ElapsedEventHandler(this.GetDATA);
        }
        private  void GetDATA(object sender, ElapsedEventArgs e)
        {
            Thread BTCUSD = new Thread(new ThreadStart(GET_BTCUSD));
            BTCUSD.Start();
            Thread ETHUSD = new Thread(new ThreadStart(GET_ETHUSD));
            ETHUSD.Start();
            Thread ETHBTC = new Thread(new ThreadStart(Get_ETHBTC));
            ETHBTC.Start();
        }
        private List<Service_BTCUSD_DTO> List_BTCUSD()
        {
            List<Service_BTCUSD_DTO> ls = new List<Service_BTCUSD_DTO>();
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://www.bitstamp.net/api/v2/ticker");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response =  client.GetAsync(client.BaseAddress + "/btcusd").Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    Service_BTCUSD_DTO dto = JsonConvert.DeserializeObject<Service_BTCUSD_DTO>(data);
                    ls.Add(dto);
                    response.Dispose();
                }
                          
            }
            catch (Exception)
            { }
            return ls;
        }
        private void GET_BTCUSD()
        {
            List<Service_BTCUSD_DTO> ls = List_BTCUSD();
            using (SqlConnection conn = new SqlConnection(sconnect))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("proc_BTCUSD_CoinPrice", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    cmd.Parameters.AddWithValue("@lastprice", ls[0].last);                  
                    var u = cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception) { }
            }
        }
        private List<Service_ETHUSD_DTO> List_ETHUSD()
        {
            List<Service_ETHUSD_DTO> ls = new List<Service_ETHUSD_DTO>();
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://www.bitstamp.net/api/v2/ticker");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/ethusd").Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    Service_ETHUSD_DTO u = JsonConvert.DeserializeObject<Service_ETHUSD_DTO>(data);
                    ls.Add(u);
                }
            }
            catch (Exception) { }
            return ls;
        }
        private void GET_ETHUSD()
        {
            List<Service_ETHUSD_DTO> ls = List_ETHUSD();
            using (SqlConnection conn = new SqlConnection(sconnect))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("proc_ETHUSD_CoinPrice", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    cmd.Parameters.AddWithValue("@lastprice", ls[0].last);
                    var u = cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception) { }
            }
        }
        private List<Service_ETHBTC_DTO> List_ETHBTC()
        {
            List<Service_ETHBTC_DTO> ls = new List<Service_ETHBTC_DTO>();
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://www.bitstamp.net/api/v2/ticker");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response =  client.GetAsync(client.BaseAddress + "/ethbtc").Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    Service_ETHBTC_DTO dto = JsonConvert.DeserializeObject<Service_ETHBTC_DTO>(data);
                    ls.Add(dto);
                }
            }
            catch (Exception) { }
            return ls;
        }
        private void Get_ETHBTC()
        {
            List<Service_ETHBTC_DTO> ls = List_ETHBTC();
            using (SqlConnection conn = new SqlConnection(sconnect))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("proc_ETHBTC_CoinPrice", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    cmd.Parameters.AddWithValue("@lastprice", ls[0].last);
                    var u = cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception) { }
            }
        }
        protected override void OnStart(string[] args)
        {
            timer1.Start();
            timer1.Enabled = true;
        }
        public void Start()
        {
            timer1.Start();
        }

        protected override void OnStop()
        {
            timer1.Stop();
            timer1.Enabled = false;
        }
        public void Stop()
        {
            timer1.Stop();
        }
    }
}
