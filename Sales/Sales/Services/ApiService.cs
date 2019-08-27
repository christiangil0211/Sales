namespace Sales.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Sales.Common.Models;
    using Newtonsoft.Json;
    using Plugin.Connectivity;
    using Sales.Helpers;
    using System.Text;

    public class ApiService
    {
        public async Task<Response> CheckConnection()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = Lenguages.TumOnInternet,
                };
            }

            var isReachable = await CrossConnectivity.Current.IsRemoteReachable(
                "google.co");

            if (!isReachable)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = Lenguages.NoInternet,
                };
            }

            return new Response
            {
                IsSuccess = true,
            };
        }
        public async Task<Response> GetList<T>(string urlBase, string prefix, string controller)
        { 
            try
            {
                //Se crea una objeto cliente para generar la comunicacion
                var client = new HttpClient();
                // Se carga y se le pasa la direccion de consulta
                client.BaseAddress = new Uri(urlBase);
                //Vamos a concatenar el prefijo  y la URl en una variable
                var url = $"{prefix}{controller}";
                //se envia la peticion y esperamos
                var response = await client.GetAsync(url);
                //recibe la respuesta y se lee lo que retorna
                var answer = await response.Content.ReadAsStringAsync();
                //Validamos la respuesta que nos llega
                //si es nula o vacia 
                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = answer,
                    };
                }
                //Si no fue nula o trajo la respuesta
                //se crea objeto para deserializar la respuesta (convertir lista a un objeto )
                var list = JsonConvert.DeserializeObject<List<T>>(answer);

                return new Response
                {
                    IsSuccess =true,
                    Result = list,
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    //Se envia respuesta falsa y mensaje todo de la clase response cunado fallo
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }           
        }
        public async Task<Response> Post<T>(string urlBase, string prefix, string controller, T model)
        {
            try
            {
                var request = JsonConvert.SerializeObject(model);
                var content = new StringContent(request, Encoding.UTF8, "application/json");
                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);
                var url = $"{prefix}{controller}";
                var response = await client.PostAsync(url, content);
                var answer = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = answer,
                    };
                }
                var obj = JsonConvert.DeserializeObject<T>(answer);
                return new Response
                {
                    IsSuccess = true,
                    Result = obj,
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }
    }
}
