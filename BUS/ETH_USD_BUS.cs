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
    public class ETH_USD_BUS
    {
        public static List<ETH_USD_DTO> List_ETH_USD()
        {
            List<ETH_USD_DTO> ls = new List<ETH_USD_DTO>();
            try
            {
               
                ETH_USD_DTO t = new ETH_USD_DTO();
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://www.bitstamp.net/api/v2/ticker");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/ethusd").Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    ETH_USD_DTO u = JsonConvert.DeserializeObject<ETH_USD_DTO>(data);
                    ls.Add(u);
                }
               
            }
            catch
            {
                Error_Message eror = new Error_Message();
                eror.BTC_USD_DisConnectError = "Connect has been stopped !";
            }
            return ls;
        }

        public bool Insert_ETH_USD(ETH_USD_DTO dto)
        {
            ETH_USD_DAO dao = new ETH_USD_DAO();
            return dao.Insert_ETH_USD(dto);
        }
    }
}
