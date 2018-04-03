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
    [Activity(Label = "MainActivityMenuEleve")]
    public class MainActivityMenuEleve : Activity
    {
        Eleve eleve;
        Button btnGroupe;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MenuEleve);

            btnGroupe = FindViewById<Button>(Resource.Id.btnGroupe);

            btnGroupe.Click += BtnGroupe_Click;
            //Toast.MakeText(this, "2", ToastLength.Long).Show();
        }

        private void BtnGroupe_Click(object sender, EventArgs e)
        {
            string unEleve = Intent.GetStringExtra("unEleve");
            eleve = JsonConvert.DeserializeObject<Eleve>(unEleve);

            Intent intent = new Intent(this, typeof(MainActivityGroupe));
            intent.PutExtra("unEleve", JsonConvert.SerializeObject(eleve));
            StartActivity(intent);
            //Toast.MakeText(this, "page de +", ToastLength.Long).Show();
        }
    }
}