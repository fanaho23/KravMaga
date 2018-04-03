using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace KravMaga.Model
{
    public class Message
    {
        [JsonProperty("idEle")]
        public string idEle { get; set; }
        [JsonProperty("nomEleve")]
        public string nomEleve { get; set; }
        [JsonProperty("prenomEleve")]
        public string prenomEleve { get; set; }
        [JsonProperty("idMessage")]
        public string idMessage { get; set; }
        [JsonProperty("sujet")]
        public string sujet { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
        
    }
}