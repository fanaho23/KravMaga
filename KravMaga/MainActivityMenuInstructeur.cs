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
using KravMaga.Model;
using Newtonsoft.Json;

namespace KravMaga
{
    [Activity(Label = "MainActivityMenuInstructeur")]
    public class MainActivityMenuInstructeur : Activity
    {
        Button btnListe;
        Button btnAbsent;
        Instructeur i;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MenuInstructeur);
            btnListe = FindViewById<Button>(Resource.Id.btnListe);
            btnAbsent = FindViewById<Button>(Resource.Id.btnAbsent);
            btnListe.Click += BtnListe_Click;
            btnAbsent.Click += BtnAbsent_Click;
            // Create your application here
        }

        private void BtnAbsent_Click(object sender, EventArgs e)
        {
            string instructeur = Intent.GetStringExtra("unInstructeur");
            Instructeur i = JsonConvert.DeserializeObject<Instructeur>(instructeur);
            Intent intent = new Intent(this, typeof(MainActivityAbsence));
            intent.PutExtra("unInstructeur", JsonConvert.SerializeObject(i));
            StartActivity(intent);
            //Toast.MakeText(this, "Btn ok", ToastLength.Short).Show();
        }

        private void BtnListe_Click(object sender, EventArgs e)
        {
            string instructeur = Intent.GetStringExtra("unInstructeur");
            Instructeur i = JsonConvert.DeserializeObject<Instructeur>(instructeur);
            Intent intent = new Intent(this, typeof(MainActivity2));
            intent.PutExtra("unInstructeur", JsonConvert.SerializeObject(i));
            StartActivity(intent);
        }
    }
}