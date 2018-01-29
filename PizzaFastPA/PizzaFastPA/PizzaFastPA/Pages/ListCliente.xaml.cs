using PizzaFastPA.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PizzaFastPA.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListCliente : ContentPage
    {
        RestClient dataService;
        List<Clientes> items;
        public ListCliente()
        {
            InitializeComponent();
            dataService = new RestClient();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ((App)App.Current).ResumeAtTodoId = -1;
            items = await dataService.GetRepartidoresAsync();
            listView.ItemsSource = await App.Database.GetItemsAsync();
        }
        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Cliente
            {
                BindingContext = new TodoItem()
            });
        }
        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((App)App.Current).ResumeAtTodoId = (e.SelectedItem as TodoItem).ID;
            Debug.WriteLine("setting ResumeAtTodoId = " + (e.SelectedItem as TodoItem).ID);

            await Navigation.PushAsync(new Cliente
            {
                BindingContext = e.SelectedItem as TodoItem
            });
        }
    }
}