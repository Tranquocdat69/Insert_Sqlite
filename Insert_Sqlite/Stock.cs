using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Insert_Sqlite
{
    class Stock
    {
        [JsonProperty("c")]
        [DataMember(Name = "c")]
        public string Code { get; set; }
        [JsonProperty("p")]
        [DataMember(Name = "p")]
        public double Price { get; set; }
        [JsonProperty("q")]
        [DataMember(Name = "q")]
        public int Quantity { get; set; }
    }
}
