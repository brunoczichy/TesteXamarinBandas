using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using System.Net;
using EventPlusX;
using TesteXamarinBandas.View;

namespace TesteXamarinBandas
{
    class MainPageViewModel : BaseViewModel
    {
        MainView mainView;

        // Construtor da ViewModel da MainPage
        public MainPageViewModel(MainView mainView)
        {
            this.mainView = mainView;
            CarregarArquivo();
            CarregarBandas();
            OnPropertyChanged("ListBands");
        }

        private void CarregarBandas()
        {
            foreach (var item in ListBands)
            {
                Band bandaConsulta = ConsultaBanda(item);
                item.Country = bandaConsulta.Country;
                item.CountryFlag = bandaConsulta.CountryFlag;
                item.Genre = bandaConsulta.Genre;
                item.Image = bandaConsulta.Image;
                item.Name = bandaConsulta.Name;
                item.Website = bandaConsulta.Website;
                
            }

            mainView.LoadGrid(ListBands);

        }

        // Método que carrega o arquivo para o projeto
        private void CarregarArquivo()
        {
            var assembly = typeof(MainPageViewModel).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("TesteXamarinBandas.Droid.bands.json");
            string text = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }

            Bands list = JsonConvert.DeserializeObject<Bands>(text);
            ListBands = list.BandList;

        }

        // Método para consultar detalhes das bandas
        private Band ConsultaBanda(Band band)
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

                    return JsonConvert.DeserializeObject<Band>(content);

                }
            }

        }

        // Propriedade para expor a lista para View
        public List<Band> ListBands
        {
            get;
            set;
        }

    }
}
