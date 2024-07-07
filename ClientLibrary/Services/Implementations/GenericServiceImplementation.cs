﻿using BaseLibrary.Response;
using ClientLibrary.Helpers;
using ClientLibrary.Services.Contracts;
using System.Net.Http.Json;

namespace ClientLibrary.Services.Implementations
{
    public class GenericServiceImplementation<T>(GetHttpClient getHttpClient) : IGenericServiceInterface<T>
    {
        //Create
        public async Task<GeneralResponse> Insert(T item, string baseUrl)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var response = await httpClient.PostAsJsonAsync($"{baseUrl}/add", item);
            var result = await response.Content.ReadFromJsonAsync<GeneralResponse>();
            return result!;
        }
        //Get All
        public async Task<List<T>> GetAll(string baseUrl)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var result = await httpClient.GetFromJsonAsync<List<T>>($"{baseUrl}/all");
            return result!;
        }
        //Get Single {id}
        public async Task<T> GetById(int id, string baseUrl)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var result = await httpClient.GetFromJsonAsync<T>($"{baseUrl}/single/{id}");
            return result!;
        }
        //Update {model}
        public async Task<GeneralResponse> Update(T item, string baseUrl)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var response = await httpClient.PostAsJsonAsync($"{baseUrl}/update", item);
            var result = await response.Content.ReadFromJsonAsync<GeneralResponse>();
            return result!;
        }
        //Delete {id}
        public async Task<GeneralResponse> DeleteId(int id, string baseUrl)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var response = await httpClient.DeleteAsync($"{baseUrl}/delete/{id}");
            var result = await response.Content.ReadFromJsonAsync<GeneralResponse>();
            return result!;
        }
       
    }
}
