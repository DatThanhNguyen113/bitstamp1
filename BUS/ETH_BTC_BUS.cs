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
    public class ETH_BTC_BUS
    {
        public async static Task<List<ETH_BTC_DTO>> List_ETH_BTC()
        {
            List<ETH_BTC_DTO> ls = new List<ETH_BTC_DTO>();
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://www.bitstamp.net/api/v2/ticker");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress + "/ethbtc");
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    ETH_BTC_DTO u = JsonConvert.DeserializeObject<ETH_BTC_DTO>(data);
                    ls.Add(u);
                }
            }
            catch (Exception) { }
            return ls;
        }
        public bool Insert_ETH_BTC(ETH_BTC_DTO dto)
        {
            ETH_BTC_DAO dao = new ETH_BTC_DAO();
            return dao.Insert_ETH_BTC(dto);
        }
    }
}
