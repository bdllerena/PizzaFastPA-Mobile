using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaFastPA.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PizzaFastPA.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoItemPage : ContentPage
    {
        double value = 0;
       // int valueOption = 0;

        //List<Repartidor> items;
        RestClient dataService;
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ((App)App.Current).ResumeAtTodoId = -1;
            picker.ItemsSource = await App.Database.GetItemsAsync();
        }
        public TodoItemPage()
        {
            InitializeComponent();
            dataService = new RestClient();
            var todoItem = (TodoItem)BindingContext;
            Dictionary<string, int> option = new Dictionary<string, int>
            {
                 { "Especialidades", 1 }, { "Personalizada", 2 }
            };
            foreach (string options in option.Keys)
            {
                poison.Items.Add(options);
            }

            picker.SelectedIndexChanged += (sender, args) =>
            {
                if (picker.SelectedIndex != -1)
                {
                    string number = picker.Items[picker.SelectedIndex];
                    CedulaInvi.Text = number;
                }
                else
                {
                    string number = picker.Items[picker.SelectedIndex];
                    CedulaInvi.Text = number;
                }
            };

            poison.SelectedIndexChanged += (sender, args) =>
            {
                if (poison.SelectedIndex != -1)
                {
                    string number = poison.Items[poison.SelectedIndex];
                    value = option[number];
                    switch (value)
                    {
                        case 1:
                            Ingrediente1.IsVisible = true;
                            Ingrediente2.IsVisible = true;
                            Ingrediente3.IsVisible = true;
                            Cantidad1.IsVisible = true;
                            Ingrediente1.IsEnabled = true;
                            Ingrediente2.IsEnabled = true;
                            Ingrediente3.IsEnabled = true;
                            Cantidad1.IsEnabled = true;
                            /* Pizza1.IsEnabled = true;
                             Pizza1.IsVisible = true;
                             Pizza2.IsEnabled = true;
                             Pizza2.IsVisible = true;
                             Pizza3.IsEnabled = true;
                             Pizza3.IsVisible = true;
                             Cantidad1.IsEnabled = true;
                             Cantidad1.IsVisible = true;
                             Cantidad2.IsEnabled = true;
                             Cantidad2.IsVisible = true;
                             Cantidad3.IsEnabled = true;
                             Cantidad3.IsVisible = true;*/
                            break;
                        case 2:
                            break;
                    }
                }
                else
                {
                    string number = poison.Items[poison.SelectedIndex];
                    value = option[number];
                    switch (value)
                    {
                        case 1:
                            Ingrediente1.IsVisible = true;
                            Ingrediente2.IsVisible = true;
                            Ingrediente3.IsVisible = true;
                            Cantidad1.IsVisible = true;
                            Ingrediente1.IsEnabled = true;
                            Ingrediente2.IsEnabled = true;
                            Ingrediente3.IsEnabled = true;
                            Cantidad1.IsEnabled = true;
                            /* Pizza1.IsEnabled = true;
                             Pizza1.IsVisible = true;
                             Pizza2.IsEnabled = true;
                             Pizza2.IsVisible = true;
                             Pizza3.IsEnabled = true;
                             Pizza3.IsVisible = true;
                             Cantidad1.IsEnabled = true;
                             Cantidad1.IsVisible = true;
                             Cantidad2.IsEnabled = true;
                             Cantidad2.IsVisible = true;
                             Cantidad3.IsEnabled = true;
                             Cantidad3.IsVisible = true;*/
                            break;
                        case 2:
                            break;
                    }
                }
            };
            /*  Dictionary<string, double> tiempo = new Dictionary<string, double>
              {
                   { "1 minuto", 1 },
                  { "5 minutos", 5 }, { "15 minutos", 15 },
                  { "25 minutos", 25 }, { "45 minutos", 45 },
                  { "1 hora", 60 }, { "2 horas", 120 },
                  { "3 horas", 180}, { "12 horas", 720},
                  { "24 horas", 1440 }, { "2 días", 2880},
                  { "1 semana", 10080}
              };

              foreach (string times in tiempo.Keys)
              {
                  poison.Items.Add(times);
              }
              poison.SelectedIndexChanged += (sender, args) =>
              {
                  if (poison.SelectedIndex != -1)
                  {
                      string number = poison.Items[poison.SelectedIndex];
                      value = tiempo[number];

                  }
                  else
                  {
                      string number = poison.Items[poison.SelectedIndex];
                      value = tiempo[number];
                  }
              };*/
            //   Esverdad();
        }
        /* public void Esverdad()
         {
             var todoItem = (TodoItem)BindingContext;
             if (dones.IsToggled == true)
             {
                 CrossLocalNotifications.Current.Cancel(todoItem.ID);
             }
         }*/
        /*
        async void OnSaveClicked(object sender, EventArgs e)
        {
            var todoItem = (TodoItem)BindingContext;
            await App.Database.SaveItemAsync(todoItem);
            await Navigation.PopAsync();

            //CrossLocalNotifications.Current.Show("EspePocket - Tareas", "Recuerda terminar: " + Titulo.Text + "!", todoItem.ID, DateTime.Now.AddMinutes(value));
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var todoItem = (TodoItem)BindingContext;
            await App.Database.DeleteItemAsync(todoItem);
            await Navigation.PopAsync();
           // CrossLocalNotifications.Current.Cancel(todoItem.ID);
        }*/

        /* public void OnCancelClicked(object sender, EventArgs e)
         {
             DisplayAlert("Alerta", "El recordatorio fue cancelado si desea crear uno nuevo vuelva a guardar la nota", "OK");
             var todoItem = (TodoItem)BindingContext;
             //await Navigation.PopAsync();
            // CrossLocalNotifications.Current.Cancel(todoItem.ID);
         }

         void OnSpeakClicked(object sender, EventArgs e)
         {
             var todoItem = (TodoItem)BindingContext;
             //DependencyService.Get<ITextToSpeech>().Speak(todoItem.Name + " " + todoItem.Notes);
         }*/
        /*}
        async void RefreshData()
        {
            items = await dataService.GetRepartidoresAsync();
            //repartidores.ItemsSource = items.OrderBy(item => item.nickname).ToList();
        }*/
        async void AddButton_Clicked(object sender, System.EventArgs e)
        {

            Repartidor newItem = new Repartidor
            {
                // nickname = txtNick.Text,
                //cedula = Cedula.Text,
                cedula = CedulaInvi.Text,
                ingrediente1 = Ingrediente1.Text,
                ingrediente2 = Ingrediente2.Text,
                ingrediente3 = Ingrediente3.Text,
                cantidad1 = Cantidad1.Text
            };
            await dataService.AddTRepartidorAsync(newItem);
            await DisplayAlert("Mensaje", "Su pedido se realizo con éxito", "OK");
            var stack = Navigation.NavigationStack;
            if (stack[stack.Count - 1].GetType() != typeof(MainPage))
                await Navigation.PushAsync(new MainPage());
            //RefreshData();
        }
    }
}
/*
 *       /*RestClient dataService;
        List<Repartidor> items;*/
/*
public RestServices()
{
InitializeComponent();
/*dataService = new RestClient();
RefreshData();
var minutes = TimeSpan.FromMinutes(1);
Device.StartTimer(minutes, () => {
RefreshData();
return true;
});}*/


/*   async void RefreshData()
   {
       items = await dataService.GetRepartidoresAsync();
       repartidores.ItemsSource = items.OrderBy(item => item.nombre.ToList();
   }*/
/*
async void AddButton_Clicked(object sender, System.EventArgs e)
{
 Repartidor newItem = new Repartidor
 {
     // nickname = txtNick.Text,
     cedula = txtCed.Text
 };
 await dataService.AddTRepartidorAsync(newItem);
 //RefreshData();
}*/
