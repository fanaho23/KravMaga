using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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
        Eleve eleveAbsent;
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
            btnAbsence.Click += BtnAbsence_Click;
            lstElevesAbsents = new List<Eleve>();

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
            //btnAbsence.Click += BtnAbsence_Click;
            int i = 6;
        }

        private void LvEleve_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //Toast.MakeText(this, e.Position.ToString(), ToastLength.Long).Show();
            nbClick += 1;
            // Eleve eleve = lstEleves[e.Position] ;

            //int idEleveAbsent = Convert.ToInt32(eleve.idEleve);

            eleveAbsent = lstEleves[e.Position];
            //Toast.MakeText(this, eleveAbsent.nomEleve, ToastLength.Long).Show();
            lstElevesAbsents.Add(eleveAbsent);
            
        }

        private void BtnAbsence_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, DateTime.Now.ToString("yyyy-MM-dd"), ToastLength.Long).Show();
            foreach (Eleve abs in lstElevesAbsents)
            {

                
                WebClient wc = new WebClient();
                Uri url = new Uri("http://" + GetString(Resource.String.ip) + "InsertAbsent.php");
                NameValueCollection parametres = new NameValueCollection();
                parametres.Add("idEleve", abs.idEleve);
                parametres.Add("date", DateTime.Now.ToString("yyyy-MM-dd"));

                wc.UploadValuesAsync(url,"POST",parametres);
                wc.UploadValuesCompleted += Wc_UploadValuesCompleted;
               // int i = 4;


            }
            
        }

        private void Wc_UploadValuesCompleted(object sender, UploadValuesCompletedEventArgs e)
        {
            //Toast.MakeText(this, "OK "+ DateTime.Now.ToString("dd-MM-yy"), ToastLength.Long).Show();
        }

    }
}