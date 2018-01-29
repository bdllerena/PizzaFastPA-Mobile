using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PizzaFastPA.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }
        async void Boton_VerClientes(object sender, EventArgs args)
        {
            var stack = Navigation.NavigationStack;
            if (stack[stack.Count - 1].GetType() != typeof(ListCliente))
                await Navigation.PushAsync(new ListCliente());


        }
        async void Boton_VerPedidos(object sender, EventArgs args)
        {
            var stack = Navigation.NavigationStack;
            if (stack[stack.Count - 1].GetType() != typeof(TodoItemPage))
                await Navigation.PushAsync(new TodoItemPage());

        }
    }
}