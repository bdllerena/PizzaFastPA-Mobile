using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFastPA.Models
{
    public class RestClient
    {
        HttpClient client = new HttpClient();
        public RestClient()
        {
        }

        /// <summary>
        /// Obtiene los datos de clientes de forma asincronica
        /// </summary>
        /// <returns>Todos los clientes de forma asincronica</returns>
        public async Task<List<Clientes>> GetRepartidoresAsync()
        {
            var response = await client.GetStringAsync("http://ec2-54-245-141-110.us-west-2.compute.amazonaws.com/pizzafast/public/index.php/clientes");
            var clientes = JsonConvert.DeserializeObject<List<Clientes>>(response);
            return clientes;
        }
        public async Task<int> AddTRepartidorAsync(Repartidor itemToAdd)
        {
            try
            {
                var data = JsonConvert.SerializeObject(itemToAdd);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("http://ec2-54-245-141-110.us-west-2.compute.amazonaws.com/pizzafast/public/index.php/pedido", content);
                var result = JsonConvert.DeserializeObject<int>(response.Content.ReadAsStringAsync().Result);
                return result;
            }
            catch (System.Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception);
                return 0;
            }

        }
        /// <summary>
        /// Agrega clientes al servicio Rest, de forma asincronica
        /// </summary>
        /// <returns>Cliente asincronica</returns>
        public async Task<int> AddClienteAsync(Clientes itemToAdd)
        {
            try
            {
                var data = JsonConvert.SerializeObject(itemToAdd);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("http://ec2-54-245-141-110.us-west-2.compute.amazonaws.com/pizzafast/public/index.php/clientes", content);
                var result = JsonConvert.DeserializeObject<int>(response.Content.ReadAsStringAsync().Result);
                return result;
            }
            catch (System.Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception);
                return 0;
            }

        }
        public async Task<int> UpdateClienteAsync(string itemIndex, Clientes itemToUpdate)
        {
            try
            {
                var data = JsonConvert.SerializeObject(itemToUpdate);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = await client.PutAsync(string.Concat("http://ec2-54-245-141-110.us-west-2.compute.amazonaws.com/pizzafast/public/index.php/clientes/", itemIndex), content);
                return JsonConvert.DeserializeObject<int>(response.Content.ReadAsStringAsync().Result);
            }
            catch (System.Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception);
                return 0;
            }
        }

        public async Task DeleteTodoItemAsync(string itemIndex)
        {
            try
            {
                await client.DeleteAsync(string.Concat("http://ec2-54-245-141-110.us-west-2.compute.amazonaws.com/pizzafast/public/index.php/clientes/", itemIndex));
            }
            catch (System.Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception);
            }
        }
    }
}
