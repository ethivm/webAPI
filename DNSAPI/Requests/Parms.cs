using Newtonsoft.Json;

namespace DNSAPI.Requests
{
    public class Parms
    {
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
    }
}