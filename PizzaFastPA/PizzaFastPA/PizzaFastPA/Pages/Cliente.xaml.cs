using PizzaFastPA.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PizzaFastPA.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cliente : ContentPage
    {
       // List<Clientes> items;
        RestClient dataService;
        public Cliente()
        {
            InitializeComponent();
            dataService = new RestClient();
            var todoItem = (TodoItem)BindingContext;
        }
        async void OnSaveClicked(object sender, EventArgs e)
        {
            var todoItem = (TodoItem)BindingContext;
            await App.Database.SaveItemAsync(todoItem);
            Clientes newItem = new Clientes
            {
                // nickname = txtNick.Text,
                //cedula = Cedula.Text,
                nombre = Nombre.Text,
                apellido = Apellido.Text,
                cedula = Cedula.Text,
                fechaNac = FechaNac.Text

            };
            await dataService.AddClienteAsync(newItem);
            Clientes updateItem = new Clientes
            {
                // nickname = txtNick.Text,
                //cedula = Cedula.Text,
                nombre = Nombre.Text,
                apellido = Apellido.Text,
                fechaNac = FechaNac.Text

            };
            await dataService.UpdateClienteAsync(Cedula.Text, updateItem);
            await Navigation.PopAsync();

            //CrossLocalNotifications.Current.Show("EspePocket - Tareas", "Recuerda terminar: " + Titulo.Text + "!", todoItem.ID, DateTime.Now.AddMinutes(value));
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var todoItem = (TodoItem)BindingContext;
            await App.Database.DeleteItemAsync(todoItem);
            try
            {
                //  var mi = ((MenuItem)sender);
                //  Clientes itemToDelete = (Clientes)mi.CommandParameter;
                // Clientes itemToDelete = Cedula.Text;
                // int itemIndex = items.IndexOf(itemToDelete);
                // await dataService.DeleteTodoItemAsync(itemIndex);
                await dataService.DeleteTodoItemAsync(Cedula.Text);
            }
            catch (System.Exception exception)
            {
                await DisplayAlert("Mensaje", exception.ToString(), "OK");
                System.Diagnostics.Debug.WriteLine(exception);
            }
            /*var mi = ((MenuItem)sender);
            Clientes itemToDelete = (Clientes)mi.CommandParameter;
            int itemIndex = items.IndexOf(itemToDelete);
            await dataService.DeleteTodoItemAsync(itemIndex);*/
            await Navigation.PopAsync();
            // CrossLocalNotifications.Current.Cancel(todoItem.ID);
        }
    }
}