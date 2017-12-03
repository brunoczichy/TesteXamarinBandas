using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteXamarinBandas
{
    public class Band
    {
        [JsonProperty("id")]
        public String Id
        {
            get;
            set;
        }

        [JsonProperty("name")]
        public String Name
        {
            get;
            set;
        }
        public string FullName => string.Format("Nome: {0}", Name);

        [JsonProperty("genre")]
        public String Genre
        {
            get;
            set;
        }
        public string FullGenre => string.Format("Gênero: {0}", Genre);

        [JsonProperty("image")]
        public String Image
        {
            get;
            set;
        }

        [JsonProperty("country")]
        public String Country
        {
            get;
            set;
        }
        public string FullCountry => string.Format("País: {0}", Country);

        [JsonProperty("country_flag")]
        public String CountryFlag
        {
            get;
            set;
        }

        [JsonProperty("website")]
        public String Website
        {
            get;
            set;
        }
        public string FullWebsite => string.Format("Site: {0}", Website);
    }
}
