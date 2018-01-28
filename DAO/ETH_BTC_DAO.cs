using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DTO;

namespace DAO
{
    public class ETH_BTC_DAO
    {
        public SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["bitstamp"].ConnectionString);
        public bool Insert_ETH_BTC(ETH_BTC_DTO dto)
        {
            string squery = string.Format("Insert into ETH_BTC([Open],Last,Hight,Low,Volume,Time) values({0},{1},{2},{3},{4},GETDATE())", dto.open, dto.last, dto.high, dto.low, dto.volume);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(squery, conn);
                var u = cmd.ExecuteNonQuery();
                cmd.Dispose();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
