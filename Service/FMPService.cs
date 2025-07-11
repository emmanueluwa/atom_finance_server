using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using atom_finance_server.Dtos.Stock;
using atom_finance_server.Interfaces;
using atom_finance_server.Mappers;
using atom_finance_server.Models;
using Newtonsoft.Json;

namespace atom_finance_server.Service
{
    public class FMPService : IFMPService
    {
        private HttpClient _httpClient;
        private IConfiguration _config;

        public FMPService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<Stock> FindStockBySymbolAsync(string symbol)
        {
            try
            {

                var result = await _httpClient.GetAsync($"https://financialmodelingprep.com/stable/profile?symbol={symbol}&apikey={_config["FMPKey"]}");
                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    var tasks = JsonConvert.DeserializeObject<FMPStock[]>(content);

                    var stock = tasks[0];
                    if (stock != null)
                    {
                        return stock.FromFMPStockToStock();
                    }
                    return null;
                }
                return null;
            }
            catch (Exception e)
            {
                // TODO: add logging system
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
