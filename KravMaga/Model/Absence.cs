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
    public class Absence
    {
        [JsonProperty("idEleve")]
        public string idEleve { get; set; }
        [JsonProperty("dateJ")]
        public DateTime dateJ { get; set; }
    }
}