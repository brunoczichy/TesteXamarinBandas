using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace TesteXamarinBandas.ViewModel
{
    class DetailBandViewModel
    {
        // Construtor do DetailBandViewModel
        public DetailBandViewModel(Band band)
        {
            ConsultaBanda(band);
        }

        // Método para consultar detalhes das bandas
        private void ConsultaBanda(Band band)
        {
            var id = band.Id;
            var request = HttpWebRequest.Create(string.Format(@"https://powerful-oasis-33182.herokuapp.com/bands/{0}", id));
            request.ContentType = "application/json";
            request.Method = "GET";

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                    Console.Out.WriteLine("Error fetching data. Server returned status code: {0}", response.StatusCode);
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    var content = reader.ReadToEnd();
                    if (string.IsNullOrWhiteSpace(content))
                    {
                        Console.Out.WriteLine("Response contained empty body...");
                    }
                    else
                    {
                        Console.Out.WriteLine("Response Body: \r\n {0}", content);
                    }

                    DetailBand = JsonConvert.DeserializeObject<Band>(content);

                }
            }

        }

        // Propriedade para expor os detalhes da banda
        public Band DetailBand
        {
            get;
            set;
        }

    }
}
