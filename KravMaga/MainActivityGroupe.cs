using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
    [Activity(Label = "MainActivityGroupe")]
    public class MainActivityGroupe : Activity
    {
        List<Model.Message> lstMessages;
        ListView lvMessage;
        EditText txtMessage;
        Button btnEnvoyer;
        TextView txtAuteur;
        TextView txtDescription;
        AdapterMessage adapter;
        Eleve eleve;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MainMessageGroupe);
            lvMessage = FindViewById<ListView>(Resource.Id.lvMessageGroupe);
            txtMessage = FindViewById<EditText>(Resource.Id.txtMessage);
            btnEnvoyer = FindViewById<Button>(Resource.Id.btnEnvoyer);
            txtAuteur = FindViewById<TextView>(Resource.Id.txtAuteur);
            txtDescription = FindViewById<TextView>(Resource.Id.txtDescription);
            btnEnvoyer.Click += BtnEnvoyer_Click;
            WebClient wc = new WebClient();

            string unEleve = Intent.GetStringExtra("unEleve");
            eleve = JsonConvert.DeserializeObject<Eleve>(unEleve);
            Uri url = new Uri("http://" + GetString(Resource.String.ip) + "GetAllMessage.php");

            wc.DownloadStringAsync(url);
            wc.DownloadStringCompleted += Wc_DownloadStringCompleted;


        }

        private void Wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            lstMessages = JsonConvert.DeserializeObject<List<Model.Message>>(e.Result);

            adapter = new AdapterMessage(this, lstMessages);

            lvMessage.Adapter = adapter;

            /*adapter = new AdapterEleve(this, lstEleves);
            lvEleve.Adapter = adapter;
            lvEleve.ItemClick += LvEleve_ItemClick;
            btnAbsence.Click += BtnAbsence_Click;*/
            int i = 6;
        }

        private void BtnEnvoyer_Click(object sender, EventArgs e)
        {
            //Toast.MakeText(this, "coucou", ToastLength.Long).Show();
            WebClient wc = new WebClient();
            Uri url = new Uri("http://" + GetString(Resource.String.ip) + "InsertMessageGroupe.php");
            NameValueCollection parametres = new NameValueCollection();
            parametres.Add("idEle", eleve.idEleve);
            parametres.Add("description", txtMessage.Text.ToString());

            wc.UploadValuesAsync(url, "POST", parametres);
            wc.UploadValuesCompleted += Wc_UploadValuesCompleted;
        }

        private void Wc_UploadValuesCompleted(object sender, UploadValuesCompletedEventArgs e)
        {
            Toast.MakeText(this,"Message envoyé", ToastLength.Long).Show();
            WebClient wc = new WebClient();
            Uri url = new Uri("http://" + GetString(Resource.String.ip) + "GetAllMessage.php");
            txtMessage.Text = "";
            wc.DownloadStringAsync(url);
            wc.DownloadStringCompleted += Wc_DownloadStringCompleted;
        }
    }
}