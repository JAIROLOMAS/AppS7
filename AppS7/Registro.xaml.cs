using AppS7.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppS7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        private SQLiteAsyncConnection con;

        public Registro()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
        }

        private void btnAgregar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var Registros = new Estudiante { Nombre = txtNombre.Text, Usuario = txtUsuario.Text, Contrasenia = txtContrasenia.Text };
                con.InsertAsync(Registros);
                DisplayAlert("Alerta", "Dato Ingresado Correctamente", "OK");

                txtNombre.Text = "";
                txtUsuario.Text = "";
                txtContrasenia.Text = "";
            }
            catch(Exception ex) {
                DisplayAlert("Alerta", ex.Message, "OK");

            }
        }
    }
}