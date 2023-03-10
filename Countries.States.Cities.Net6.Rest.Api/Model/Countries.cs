using Newtonsoft.Json;

namespace Countries.States.Cities.Net6.Rest.Api.Model
{
    public class Countries
    {
        public int id { get; set; }
        public string name { get; set; }
        public string iso3 { get; set; }
        public string iso2 { get; set; }
        public string numeric_code { get; set; }
        public string phone_code { get; set; }
        public string capital { get; set; }
        public string currency { get; set; }
        public string currency_name { get; set; }
        public string currency_symbol { get; set; }
        public string tld { get; set; }
        public string native { get; set; }
        public string region { get; set; }
        public string subregion { get; set; }
        public List<Timezone> timezones { get; set; }
        public Translations translations { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string emoji { get; set; }
        public string emojiU { get; set; }
    }

    public class Timezone
    {
        public string zoneName { get; set; }
        public int gmtOffset { get; set; }
        public string gmtOffsetName { get; set; }
        public string abbreviation { get; set; }
        public string tzName { get; set; }
    }

    public class Translations
    {
        public string kr { get; set; }

        [JsonProperty("pt-BR")]
        public string ptBR { get; set; }

        public string pt { get; set; }
        public string nl { get; set; }
        public string hr { get; set; }
        public string fa { get; set; }
        public string de { get; set; }
        public string es { get; set; }
        public string fr { get; set; }
        public string ja { get; set; }
        public string it { get; set; }
        public string cn { get; set; }
        public string tr { get; set; }
    }
}