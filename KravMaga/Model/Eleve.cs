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
    public class Eleve
    {
        [JsonProperty("idEleve")]
        public string idEleve { get; set; }
        [JsonProperty("nomEleve")]
        public string nomEleve { get; set; }
        [JsonProperty("prenomEleve")]
        public string prenomEleve { get; set; }
        [JsonProperty("idInstructeur")]
        public string  idInstructeur { get; set; }

    }
}