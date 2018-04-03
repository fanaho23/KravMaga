using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using KravMaga.MesAdapters;
using KravMaga.Model;
using Newtonsoft.Json;

namespace KravMaga
{
    [Activity(Label = "MainActivityAbsence")]
    public class MainActivityAbsence : Activity
    {
        ListView lvAbsence;
        List<Absence> lstAbsence;
        EditText txtNom;
        Button btnAfficher;
        AdapterAbsence adapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MainAbsence);
            lvAbsence = FindViewById<ListView>(Resource.Id.lvAbsence);
            txtNom = FindViewById<EditText>(Resource.Id.txtNom);
            btnAfficher = FindViewById<Button>(Resource.Id.btnAfficher);

            btnAfficher.Click += BtnAfficher_Click;
            
        }

        private void BtnAfficher_Click(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            string instructeur = Intent.GetStringExtra("unInstructeur");
            Instructeur i = JsonConvert.DeserializeObject<Instructeur>(instructeur);
            Uri url = new Uri("http://" + GetString(Resource.String.ip) + "GetAbsencesByNomEleve.php?nomEleve="+txtNom.Text);
            wc.DownloadStringAsync(url);
            wc.DownloadStringCompleted += Wc_DownloadStringCompleted;
        }

        private void Wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            //Toast.MakeText(this,"c'est bon", ToastLength.Short).Show();
            lstAbsence = JsonConvert.DeserializeObject<List<Absence>>(e.Result);
            adapter = new AdapterAbsence(this, lstAbsence);
            lvAbsence.Adapter = adapter;
        }
    }
}