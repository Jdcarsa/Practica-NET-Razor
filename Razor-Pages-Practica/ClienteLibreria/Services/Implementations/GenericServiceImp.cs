


using BaseLibrary.Responses;
using ClienteLibreria.Helpers;
using ClienteLibreria.Services.Contracts;
using System.Net.Http.Json;

namespace ServerLibrary.Repositories.Implementations
{
    public class GenericServiceImp<T>(GetHttpClient getHttpClient) : IGenericServiceInterface<T>
    {
        public async Task<GeneralResponse> DeleteById(int id, string url)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var response = await httpClient.DeleteAsync($"{url}/delete/{id}");
            var result = await response.Content.ReadFromJsonAsync<GeneralResponse>();
            return result!;
        }

        public async Task<List<T>> GetAll(string url)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var results = await httpClient.GetFromJsonAsync<List<T>>($"{url}/all");
            return results!;
        }

        public async Task<T> GetById(int id, string url)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var result = await httpClient.GetFromJsonAsync<T>($"{url}/single/{id}");
            return result!;
        }

        public async Task<GeneralResponse> Insert(T item, string url)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var response = await httpClient.PostAsJsonAsync($"{url}/add", item);
            var result = await response.Content.ReadFromJsonAsync<GeneralResponse>();
            return result!;
        }

        public async Task<GeneralResponse> Update(T item, string url)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var response = await httpClient.PostAsJsonAsync($"{url}/update", item);
            var result = await response.Content.ReadFromJsonAsync<GeneralResponse>();
            return result!;
        }
    }
}
