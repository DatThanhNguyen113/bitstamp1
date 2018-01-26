using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using DTO;
using DAO;

namespace BUS
{
    public class BTC_USD_BUS
    {
        public async  static  Task<List<BTC_USD_DTO>> List_BTC_USD()
        {
            List<BTC_USD_DTO> ls = new List<BTC_USD_DTO>();
            try
            {
                BTC_USD_DTO t = new BTC_USD_DTO();
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://www.bitstamp.net/api/v2/ticker");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress + "/btcusd");
                if (response.IsSuccessStatusCode)
                {
                    var data =  response.Content.ReadAsStringAsync().Result;
                    BTC_USD_DTO u = JsonConvert.DeserializeObject<BTC_USD_DTO>(data);
                    ls.Add(u);
                    response.Dispose();
                }
                client.Dispose();
            }
            catch(Exception)
            { }
            return ls;
        }
        public bool Insert_BTC_USD(BTC_USD_DTO dto)
        {
            BTC_USD_DAO dao = new BTC_USD_DAO();
            return dao.Insert_BTC_BUS(dto);
        }
    }
}
