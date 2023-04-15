using System;
using System.Timers;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Cripto
{
    public partial class Form1 : Form
    {
        private System.Timers.Timer timer;
        public Form1()
        {
            InitializeComponent();
            timer = new System.Timers.Timer();
            timer.Elapsed += UpdateCryptoPrices;
            timer.Interval = 5000;
            timer.Enabled = true;
        }
        private void UpdateCryptoPrices(object? sender, ElapsedEventArgs e)
        {
            string binanceUrl = "https://api.binance.com/api/v3/ticker/price?symbol=BTCUSDT";
            string bybitUrl = "https://api.bybit.com/v2/public/tickers?symbol=BTCUSDT";
            string kucoinUrl = "https://api.kucoin.com/api/v1/market/orderbook/level1?symbol=BTC-USDT";
            string binancePrice = GetCryptoPricFromBinance(binanceUrl);
            string bybitPrice = GetCryptoPriceFromBybit(bybitUrl);
            string kucoinPrice = GetCryptoPriceFromKucion(kucoinUrl);

            Invoke(new Action(() =>
            {
                textBox3.Text = $"Binance: {binancePrice} USD";
                textBox4.Text = DateTime.Now.ToString();
                textBox5.Text = $"Bybit: {bybitPrice} USD";
                textBox6.Text = DateTime.Now.ToString();
                textBox7.Text = $"Kucion: {kucoinPrice} USD";
                textBox8.Text = DateTime.Now.ToString();

            }));
        }

        private string GetCryptoPricFromBinance(string url)
        {
            try
            {
                using (WebClient client1 = new WebClient())
                {
                    string json = client1.DownloadString(url);
                    dynamic? result = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                    if (result != null)
                    {
                        return result.price.ToString("#.00");
                    }
                    return "0";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при получении цены: {ex.Message}");
                return "Ошибка";
            }
        }
        private string GetCryptoPriceFromBybit(string url)
        {
            try
            {
                using (WebClient client2 = new WebClient())
                {
                    string json = client2.DownloadString(url);
                    dynamic? result = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                    if (result != null)
                    {           
                            return result.result[0].last_price.ToString("#.00");
                    }
                    
                    return "0";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при получении цены: {ex.Message}");
                return "Ошибка";
            }
        }
        private string GetCryptoPriceFromKucion(string url)
        {
            try
            {
                using (WebClient client3 = new WebClient())
                {
                    string json = client3.DownloadString(url);
                    dynamic? result = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                    if (result != null)
                    {

                        return result["data"]["price"].ToString("#.00");

                    }
                    return "0";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при получении цены: {ex.Message}");
                return "Ошибка";
            }
        }


    }
}


