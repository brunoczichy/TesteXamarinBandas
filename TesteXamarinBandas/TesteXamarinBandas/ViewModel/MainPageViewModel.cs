using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;

namespace TesteXamarinBandas
{
    class MainPageViewModel
    {
        // Construtor da ViewModel da MainPage
        public MainPageViewModel()
        {
            CarregarArquivo();
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

        // Propriedade para expor a lista para View
        public List<Band> ListBands
        {
            get;
            set;
        }

    }
}
