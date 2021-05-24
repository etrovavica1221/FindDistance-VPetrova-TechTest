using Newtonsoft.Json;

namespace  postcodesDistance
{
    public partial class httpResponseModel
    {
        [JsonProperty("destination_addresses")]
        public string[] DestinationAddresses { get; set; }

        [JsonProperty("origin_addresses")]
        public string[] OriginAddresses { get; set; }

        [JsonProperty("rows")]
        public Row[] Rows { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public partial class Row
    {
        [JsonProperty("elements")]
        public Element[] Elements { get; set; }
    }

    public partial class Element
    {
        [JsonProperty("distance")]
        public Distance Distance { get; set; }

        [JsonProperty("duration")]
        public Distance Duration { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public partial class Distance
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }
    }
}
