using Android.App;
using Android.Widget;
using Android.OS;
using System.Net;
using System;
using System.Collections.Generic;
using KravMaga.Model;
using Newtonsoft.Json;
using KravMaga.MesAdapters;
using Android.Content;

namespace KravMaga
{
    [Activity(Label = "KravMaga", MainLauncher = true)]
    public class MainActivity : Activity
    {
        
        AdapterEleve adapter;
        EditText txtLogin;
        EditText txtMdp;
        Button btnValider;
        List<Instructeur> lstInstructeur;
        List<Eleve> lstEleve;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Authentification);
            

            txtLogin = FindViewById<EditText>(Resource.Id.txtLogin);
            txtMdp = FindViewById<EditText>(Resource.Id.txtLogin);
            btnValider = FindViewById<Button>(Resource.Id.btnValider);
            /*WebClient wc = new WebClient();
            Uri url = new Uri("http://"+GetString(Resource.String.ip)+"GetAllEleve.php");

            wc.DownloadStringAsync(url);
            wc.DownloadStringCompleted += Wc_DownloadStringCompleted;*/
            btnValider.Click += BtnValider_Click;

        }

        private void BtnValider_Click(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();

            WebClient wc2 = new WebClient();

            Uri url = new Uri("http://" + GetString(Resource.String.ip) + "GetAllInstructeur.php");

            Uri url2 = new Uri("http://" + GetString(Resource.String.ip) + "GetAllEleve.php");

            wc.DownloadStringAsync(url);
            wc.DownloadStringCompleted += Wc_DownloadStringCompleted;

            wc2.DownloadStringAsync(url2);
            wc2.DownloadStringCompleted += Wc2_DownloadStringCompleted;
        }

        private void Wc2_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            lstEleve = JsonConvert.DeserializeObject<List<Eleve>>(e.Result);

            foreach ( Eleve eleve in lstEleve)
            {
                if (txtLogin.Text == eleve.login && txtMdp.Text == eleve.mdp && txtLogin.Text != "" && txtMdp.Text != "")
                {
                   // Intent intent = new Intent(this, typeof());
                }
            }
        }

        private void Wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            /*lstEleves = JsonConvert.DeserializeObject<List<Eleve>>(e.Result);

            adapter = new AdapterEleve(this, lstEleves);

            lvEleve.Adapter = adapter;
            int i = 0;*/
            lstInstructeur = JsonConvert.DeserializeObject<List<Instructeur>>(e.Result);
            foreach (Instructeur i in lstInstructeur)
            {
                if (txtLogin.Text == i.loginInstructeur && txtMdp.Text == i.mdpInstructeur && txtLogin.Text != "" && txtMdp.Text !="" )
                {

                    //Intent intent = new Intent(this, typeof(MainActivity2));
                    Intent intentMenu = new Intent(this, typeof(MainActivityMenuInstructeur));
                    //Intent intentMenu = new Intent(this, typeof(MainActivityMenuInstructeur));
                    string instructeur = i.idInstructeur;
                    intentMenu.PutExtra("unInstructeur", JsonConvert.SerializeObject(i));
                   // intentMenu.PutExtra("Test", JsonConvert.SerializeObject(i));
                    //intentMenu.PutExtra("LeInstructeur", JsonConvert.SerializeObject(i));
                    Toast.MakeText(this , "Ok", ToastLength.Long).Show();
                    StartActivity(intentMenu);

                }
            }
        }
    }
}

