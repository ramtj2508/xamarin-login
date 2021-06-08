using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Data;

namespace EjercicioLogin
{
    [Activity(Label = "principal")]
    public class principal : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.vistaprincipal);
            var lblDestino = FindViewById<EditText>(Resource.Id.lblusuario);
            var btnGuardar = FindViewById<Button>(Resource.Id.btnguardar);
            var btnBuscar = FindViewById<Button>(Resource.Id.btnbuscar);
            var txtNom = FindViewById<EditText>(Resource.Id.txtnombre);
            var txtDom = FindViewById<EditText>(Resource.Id.txtdomicilio);
            var txtCorreo = FindViewById<EditText>(Resource.Id.txtcorreo);
            var txtEdad = FindViewById<EditText>(Resource.Id.txtedad);
            var txtSaldo = FindViewById<EditText>(Resource.Id.txtsaldo);
            var txtFolio = FindViewById<EditText>(Resource.Id.txtfolio);
            string Usuario;
            Usuario = Intent.GetStringExtra("Usuario");
            lblDestino.Text = Usuario;

            btnGuardar.Click += delegate
            {

                try
                {

                    var WS = new ServicioWeb.ServicioWeb();

                    if
                   (WS.Guardar(txtNom.Text, txtDom.Text,
                       txtCorreo.Text, int.Parse(txtEdad.Text),
                       double.Parse(txtSaldo.Text))) Toast.MakeText
                        (this, "Guardado Correctamente en SQL",
                            ToastLength.Long).Show();
                    else
                        Toast.MakeText(this, "No Guardado",
                        ToastLength.Long).Show();

                }
                catch (System.Exception ex)
                {

                    Toast.MakeText(this, ex.Message, ToastLength.Long).Show();

                }
            };

            btnBuscar.Click += delegate

            {
                var Conjunto = new DataSet();
                DataRow Renglon;
                try
                {
                    var WS = new ServicioWeb.ServicioWeb();
                    Conjunto = WS.Busqueda(int.Parse(txtFolio.Text));
                    Renglon = Conjunto.Tables["Datos"].Rows[0];
                    txtCorreo.Text = Renglon["Correo"].ToString();
                    txtDom.Text = Renglon["Domicilio"].ToString();
                    txtEdad.Text = Renglon["Edad"].ToString();
                    txtNom.Text = Renglon["Nombre"].ToString();
                    txtSaldo.Text = Renglon["Saldo"].ToString();

                }
                catch (System.Exception ex)
                {

                    Toast.MakeText(this, ex.Message, ToastLength.Long).Show();

                }
            };
        }


            /*   btnGuardar.Click += delegate
               {
                   var DC = new Datos();
                   try
                   {
                       DC.Nombre = txtNom.Text;
                       DC.Domicilio = txtDom.Text;
                       DC.Correo = txtCorreo.Text;
                       DC.Edad = txtEdad.Text;
                       DC.Saldo = txtSaldo.Text;
                       var serializador = new XmlSerializer(typeof (Datos));
                       var Escritura = new StreamWriter(Path.Combine(System.Environment.GetFolderPath
                           (System.Environment.SpecialFolder.Personal), txtFolio.Text + ".xml"));
                       serializador.Serialize(Escritura, DC);
                       Escritura.Close();
                       txtFolio.Text = "";
                       txtCorreo.Text = "";
                       txtDom.Text = "";
                       txtEdad.Text = "";
                       txtNom.Text = "";
                       txtSaldo.Text = "";
                       Toast.MakeText(this, "Archivo guardado correctamente", ToastLength.Long).Show();
                   }
                   catch (System.Exception ex)
                   {
                       Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
                   }
               };
            
            btnBuscar.Click += delegate
            {
                var DC = new Datos();
                try
                {

                    var serializador = new XmlSerializer(typeof(Datos));
                    var Lectura = new StreamReader(Path.Combine(System.Environment.GetFolderPath
                        (System.Environment.SpecialFolder.Personal), txtFolio.Text + ".xml"));
                    var datos = (Datos)serializador.Deserialize(Lectura);
                    Lectura.Close();
                    txtCorreo.Text = datos.Correo;
                    txtDom.Text = datos.Domicilio;
                    txtEdad.Text = datos.Edad.ToString();
                    txtNom.Text = datos.Nombre;
                    txtSaldo.Text = datos.Saldo.ToString();
                    }
                catch (System.Exception ex)
                {
                    Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
                }
            };
        }
            */
        public class Datos
        {
            public string Nombre, Domicilio, Edad, Correo, Saldo;
        }
    }
}