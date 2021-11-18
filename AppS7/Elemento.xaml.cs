using AppS7.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppS7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Elemento : ContentPage
    {
        public int IdSeleccionado;
        private SQLiteAsyncConnection _conn;
        IEnumerable<Estudiante> ResultadoDelete;
        IEnumerable<Estudiante> ResultadoUpdate;

        public Elemento(int id)
        {
            _conn = DependencyService.Get<DataBase>().GetConnection();
            IdSeleccionado = id;
            InitializeComponent();

        }

        public static IEnumerable<Estudiante> Delete(SQLiteConnection db, int id)
        {
            return db.Query<Estudiante>("DELETE FROM estudiante where id=? ", id);
        }

        public static IEnumerable<Estudiante> Update(SQLiteConnection db, string nombre, string usuario, string contrasenia, int id)
        {
            return db.Query<Estudiante>("UPDATE Estudiante SET Nombre=?, Usuario=?", "Contrasenia=?, where Id=?", usuario, contrasenia, id);
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var documentPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(documentPath);
                ResultadoUpdate = Update(db, Nombre.Text, Usuario.Text, Contrasenia.Text, IdSeleccionado);
                
                DisplayAlert("Alerta", "Se Actualizo Correctamente", "ok");
                
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", "Error"+ ex.Message, "ok");

            }
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var documentPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(documentPath);
                ResultadoDelete = Delete(db, IdSeleccionado);

                DisplayAlert("Alerta", "Se Elimino Correctamente", "ok");

            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", "Error" + ex.Message, "ok");

            }

        }
    }
}