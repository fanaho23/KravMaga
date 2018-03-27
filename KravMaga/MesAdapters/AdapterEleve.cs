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

namespace KravMaga.MesAdapters
{
    public class AdapterEleve : ArrayAdapter<Eleve>
    {
        Activity context;
        List<Eleve> lesEleves;
        public AdapterEleve(Activity unContext, List<Eleve> desEleves)
            : base(unContext, Resource.Layout.ItemEleve, desEleves)
        {
            context = unContext;
            lesEleves = desEleves;
        }



        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            var view = context.LayoutInflater.Inflate(Resource.Layout.ItemEleve, null);
            view.FindViewById<TextView>(Resource.Id.txtNom).Text = lesEleves[position].nomEleve.ToString();
            view.FindViewById<TextView>(Resource.Id.txtPrenom).Text = lesEleves[position].prenomEleve.ToString();
            
            return view;
        }
    }
}