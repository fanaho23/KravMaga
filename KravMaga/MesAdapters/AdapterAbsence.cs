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
    public class AdapterAbsence : ArrayAdapter<Absence>
    {

        Activity context;
        List<Absence> lesAbsences;

        public AdapterAbsence(Activity unContext, List<Absence> desAbsences)
            : base(unContext, Resource.Layout.ItemAbsence, desAbsences)
        {
            context = unContext;
            lesAbsences = desAbsences;
        }


        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = context.LayoutInflater.Inflate(Resource.Layout.ItemAbsence, null);
            view.FindViewById<TextView>(Resource.Id.txtDate).Text = lesAbsences[position].dateJ.ToString();
            return view;
        }


    }
}