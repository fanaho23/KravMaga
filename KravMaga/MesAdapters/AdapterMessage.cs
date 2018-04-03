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
/*
namespace KravMaga.MesAdapters
{
    public class AdapterMessage : ArrayAdapter<Message>
    {

        Activity context;
        List<Model.Message> lesMessages;
        public AdapterMessage(Activity unContext, List<Model.Message> desMessages)
            : base(unContext, Resource.Layout.ItemMessageGroupe, desMessages)
        {
            context = unContext;
            lesMessages = desMessages;
        }
       
    */
namespace KravMaga.MesAdapters
{
    public class AdapterMessage : ArrayAdapter<Model.Message>
    {

        Activity context;
        List<Model.Message> lesMessages;

        public AdapterMessage(Activity unContext, List<Model.Message> desMessages)
            : base(unContext, Resource.Layout.ItemMessageGroupe, desMessages)
        {
            context = unContext;
            lesMessages = desMessages;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = context.LayoutInflater.Inflate(Resource.Layout.ItemMessageGroupe, null);
            //view.FindViewById<TextView>(Resource.Id.txtAuteur).Text = lesMessages[position].idEleve.toString();
            view.FindViewById<TextView>(Resource.Id.txtAuteur).Text = lesMessages[position].prenomEleve.ToString()+" "+lesMessages[position].nomEleve.ToString();
            view.FindViewById<TextView>(Resource.Id.txtDescription).Text = lesMessages[position].description.ToString();


            return view;
        }

        

    }

   
}