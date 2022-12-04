using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace Project_laba
{
    public class Data
    {
        [JsonPropertyName("id")]
        public string Id { get; private set; }
        [JsonPropertyName("done")]
        public bool Done { get; set; }
        [JsonPropertyName("priority")]
        public string Priority { get; set; }
        [JsonPropertyName("task")]
        public string Task { get; set; }
        [JsonConstructor]
        public Data(string id, bool done, string priority, string task)
        {
            Id = id;
            Done = done;
            Priority = priority;
            Task = task;
        }
        public Data(string priority, string task)
        {
            Id = Guid.NewGuid().ToString("N");
            Done = false;
            Priority = priority;
            Task = task;
        }
    }
}
