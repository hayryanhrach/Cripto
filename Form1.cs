
using System.Timers;
using System.Net;

/*дизайн все сделал Я*/
namespace Cripto
{
   /*Я*/ public partial class Form1 : Form
   /*Я*/ { 
      /*Я*/  private System.Timers.Timer timer;
     /*Я*/public Form1()
    /*Я*/    {
     /*Я*/       InitializeComponent();
     /*Я*/       timer = new System.Timers.Timer();
     /*Я*/       timer.Elapsed += UpdateCryptoPrices;
      /*Я*/      timer.Interval = 5000;
        /*Я*/    timer.Enabled = true;
       /*Я*/ }
       /*Я*/ private void UpdateCryptoPrices(object? sender, ElapsedEventArgs e)
       /*Я*/ {
        /*google*/    string binanceUrl = "https://api.binance.com/api/v3/ticker/price?symbol=BTCUSDT";
       /*google*/     string bybitUrl = "https://api.bybit.com/v2/public/tickers?symbol=BTCUSDT";
        /*google*/   string kucoinUrl = "https://api.kucoin.com/api/v1/market/orderbook/level1?symbol=BTC-USDT";
          /*Я*/  string binancePrice = GetCryptoPricFromBinance(binanceUrl);
          /*Я*/  string bybitPrice = GetCryptoPriceFromBybit(bybitUrl);
         /*Я*/   string kucoinPrice = GetCryptoPriceFromKucion(kucoinUrl);

                /*chatgpt*/     Invoke(new Action(() =>
              /*chatgpt*/       {
              /*Я*/  textBox3.Text = $"Binance: {binancePrice} USD";
             /*Я*/   textBox4.Text = DateTime.Now.ToString();
             /*Я*/   textBox5.Text = $"Bybit: {bybitPrice} USD";
            /*Я*/    textBox6.Text = DateTime.Now.ToString();
             /*Я*/   textBox7.Text = $"Kucion: {kucoinPrice} USD";
             /*Я*/   textBox8.Text = DateTime.Now.ToString();

                 /*chatgpt*/    }));
      /*Я*/  }

        /*Я*/private string GetCryptoPricFromBinance(string url)
        /*Я*/{
        /*Я*/    try
        /*Я*/{
         /*Я*/       using (WebClient client1 = new WebClient())
         /*Я*/       {
        /*chatgpt*/          string json = client1.DownloadString(url);
           /*chatgpt*/         dynamic? result = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
           /*Я*/         if (result != null)
          /*Я*/          {
         /*Я*/               return result.price.ToString("#.00");
         /*Я*/           }
           /*Я*/         return "0";
        /*Я*/        }
         /*Я*/   }
         /*Я*/   catch (Exception ex)
          /*Я*/  {
          /*Я*/      Console.WriteLine($"Ошибка при получении цены: {ex.Message}");
           /*Я*/     return "Ошибка";
          /*Я*/  }
        /*Я*/ }
       /*Я*/  private string GetCryptoPriceFromBybit(string url)
        /*Я*/   {
         /*Я*/   try
          /*Я*/  {
          /*Я*/      using (WebClient client2 = new WebClient())
           /*Я*/     {
          /*chatgpt*/         string json = client2.DownloadString(url);
          /*chatgpt*/            dynamic? result = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
          /*Я*/          if (result != null)
          /*Я*/          {           
         /*Я*/                   return result.result[0].last_price.ToString("#.00");
           /*Я*/         }

         /*Я*/           return "0";
          /*Я*/      }
          /*Я*/  }
          /*Я*/  catch (Exception ex)
         /*Я*/   {
          /*Я*/      Console.WriteLine($"Ошибка при получении цены: {ex.Message}");
          /*Я*/      return "Ошибка";
          /*Я*/  }
         /*Я*/   }
        /*Я*/
        /*Я*/
         /*Я*/    private string GetCryptoPriceFromKucion(string url)
       /*Я*/ {
         /*Я*/   try
          /*Я*/  {
              /*Я*/  using (WebClient client3 = new WebClient())
              /*Я*/  {
              /*chatgpt*/    string json = client3.DownloadString(url);
            /*chatgpt*/        dynamic? result = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                    //Я
                   /*Я*/ if (result != null)
                   /*Я*/{

                 /*Я*/       return result["data"]["price"].ToString("#.00");

                  /*Я*/  }
                /*Я*/    return "0";
              /*Я*/  }
         /*Я*/   }
           /*Я*/ catch (Exception ex)
           /*Я*/ {
              /*Я*/  Console.WriteLine($"Ошибка при получении цены: {ex.Message}");
               /*Я*/ return "Ошибка";
           /*Я*/ }
        }


    }
}


