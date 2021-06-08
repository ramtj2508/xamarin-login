using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;

namespace EjercicioLogin
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        string Usuario, Password;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            var btnIngresa = FindViewById<Button>(Resource.Id.btningresar);
            var txtUser = FindViewById<EditText>(Resource.Id.txtusuario);
            var txtPassword = FindViewById<EditText>(Resource.Id.txtpassword);
            var Imagen = FindViewById<ImageView>(Resource.Id.img);
            Imagen.SetImageResource(Resource.Drawable.logo2png);
            btnIngresa.Click += delegate
            {
                try
                {
                    Usuario = txtUser.Text;
                    Password = txtPassword.Text;
                 if (Usuario == "Antonio")   
                    if (Password == "123")
                    {
                        Cargar();
                    }
                    else Toast.MakeText(this, "Error en password", ToastLength.Long).Show();
                   else Toast.MakeText(this, "Error en Usuario", ToastLength.Long).Show();


                }
                catch (System.Exception ex)
                {
                    Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
                }
            };
        }
        public void Cargar()
        {
            var VistaPrincipal = new Intent(this, typeof(principal));
            VistaPrincipal.PutExtra("Usuario", Usuario);
            StartActivity(VistaPrincipal);
        }

    }
}