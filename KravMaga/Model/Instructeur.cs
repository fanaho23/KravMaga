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
    public class Instructeur
    {
        [JsonProperty("idInstructeur")]
        public string idInstructeur { get; set; }
        [JsonProperty("nomInstructeur")]
        public string nomInstructeur { get; set; }
        [JsonProperty("prenomInstructeur")]
        public string prenomInstructeur { get; set; }
        [JsonProperty("mdp")]
        public string  mdpInstructeur { get; set; }
        [JsonProperty("login")]
        public string loginInstructeur { get; set; }
    }
}