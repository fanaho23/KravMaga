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
    [Activity(Label = "MainActivity2")]
    public class MainActivity2 : Activity
    {
        List<Eleve> lstEleves;
        List<Eleve> lstElevesAbsents;
        TextView txtNom;
        TextView txtPrenom;
        ListView lvEleve;
        AdapterEleve adapter;
        Button btnAbsence;
        int nbClick =0;
        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            // Create your application here
            lvEleve = FindViewById<ListView>(Resource.Id.lvEleve);
            btnAbsence = FindViewById<Button>(Resource.Id.btnAbsence);

            WebClient wc = new WebClient();
            string instructeur = Intent.GetStringExtra("unInstructeur");
            Instructeur i = JsonConvert.DeserializeObject<Instructeur>(instructeur);
            Uri url = new Uri("http://" + GetString(Resource.String.ip) + "GetAllEleveByIdInstructeur.php?idInstructeur="+i.idInstructeur);

            wc.DownloadStringAsync(url);
            wc.DownloadStringCompleted += Wc_DownloadStringCompleted;


        }

        private void Wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            lstEleves = JsonConvert.DeserializeObject<List<Eleve>>(e.Result);
            adapter = new AdapterEleve(this, lstEleves);
            lvEleve.Adapter = adapter;
            lvEleve.ItemClick += LvEleve_ItemClick;
            btnAbsence.Click += BtnAbsence_Click;
            int i = 6;
        }

        private void LvEleve_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //Toast.MakeText(this, e.Position.ToString(), ToastLength.Long).Show();
            nbClick += 1;
            // Eleve eleve = lstEleves[e.Position] ;
           
            //int idEleveAbsent = Convert.ToInt32(eleve.idEleve);
            lstElevesAbsents = new List<Eleve> { lstEleves[e.Position] };
            btnAbsence.Click += BtnAbsence_Click;
        }

        private void BtnAbsence_Click(object sender, EventArgs e)
        {
            
            foreach (Eleve abs in lstElevesAbsents)
            {
                WebClient wc = new WebClient();
                Uri url = new Uri("http://" + GetString(Resource.String.ip) + "InsertAbsent.php?idEleve="+abs.idEleve+"&date="+DateTime.Now.ToString("dd/MM/yy"));
                wc.DownloadStringAsync(url);
                wc.DownloadStringCompleted += Wc_DownloadStringCompleted1;
                int i = 4;

            }
           // Toast.MakeText(this, DateTime.Now.ToString("dd/MM/yy"), ToastLength.Long).Show();
        }

        private void Wc_DownloadStringCompleted1(object sender, DownloadStringCompletedEventArgs e)
        {
            Toast.MakeText(this, "OK", ToastLength.Long).Show();
        }
    }
}