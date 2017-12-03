using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteXamarinBandas
{
    class Bands
    {

        [JsonProperty("bands")]
        public List<Band> BandList
        {
            get;
            set;

        }
    }
}
