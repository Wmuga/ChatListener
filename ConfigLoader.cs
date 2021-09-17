using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatListener
{
    public static class ConfigLoader
    {

        public static Config Load(string path)
        {
            return JsonSerializer.Deserialize<Config>( new StreamReader(path).ReadToEnd());
        }
        public class Config
        {
            [JsonPropertyName("channels")]
            public string[] Channels { get; set; }
            [JsonPropertyName("not-log")]
            public string[] NotLog{ get; set; }
            [JsonPropertyName("log-path")] 
            public string LogPath{ get; set; }
            [JsonPropertyName("ping-sound")]
            public string PingSound { get; set; }
        }
    }
}