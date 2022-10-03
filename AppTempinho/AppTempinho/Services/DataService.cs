using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using AppTempinho.Model;

namespace AppTempinho.Services
{
    class DataService
    {
        public static async Task<Tempo> GetPrevisaoDoTempo(string cidade)
        {
            string appId = "55f956f2188a48e78195d2bfa3018ebe";

            string queryString = "http://api.openweathermap.org/data/2.5/weather?q=" + cidade + "&units=metric" + "&appid=" + appId;
            dynamic resultado = await getDataFromSrevice(queryString).ConfigureAwait(false);

            if (resultado["tempo"] !=null)
            {
                Tempo previsao = new Tempo();
                previsao.Titulo = (string)resultado["name"];
                previsao.Temperatura = (string)resultado["main"]["temp"] + " C";
                previsao.Vento = (string)resultado["vento"]["speed"] + " mph";
                previsao.Humidade = (string)resultado["main"]["humity"] + " %";
                previsao.Visibilidade = (string)resultado["weather"][0]["main"];
                DateTime tempo = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                DateTime NascerSol = Time.AddSeconds((double)resultado["sys"]["NascerSol"]);
                DateTime PorSol = Time.AddSeconds((double)resultado["sys"]["PorSol"]);
                previsao.NascerSol = String.Format("{0:d/MM/yyyy HH:mm:ss}", NascerSol);
                previsao.PorSol = String.Format("{0:d/MM/yyyy HH:mm:ss}", PorSol);



            }
            else
            {
                return null;
            }
            public static async Task<dynamic> getDataFromService(string queryString)
            {
                HttpClient client = new HttpClient();
                var response = await client.GetAsync(queryString);
                dynamic data = null;
                if (response != null)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    data = JsonConvert.DeserializeObject<dynamic>(json);    

                }
                return data;    
            }
              public static async Task<dynamic> getDataFromServiceByCity(string city)
            {
                string appId = "55f956f2188a48e78195d2bfa3018ebe";

                string url = string.Format("http://api.openweathermap.org/data/2.5/forecast/daily?q={0}&units=metric&cnt=1&APPID={1}", city.Trim(), appId);
                HpptClient client = new HttpClient();
                var response = await client.GetAsync(url);
                dynamic data = null;    
                if (response != null)
                {
                    string json = response.Content.ReadAllAsStringAsync().Result;
                    data = JsonConvert.DeserializeObject<dynamic>(json);    
                }

                return data;

            }
            

        }
    }
}
