using BaseLibrary.DTOs;
using System.Net.Http.Headers;

namespace ClientLibrary.Helpers
{
    public class GetHttpClient(IHttpClientFactory httpClientFactory, LocalStorageService localStorageService)
    {
        private const string HeaderKey = "Authorization";
        public async Task<HttpClient> GetPrivateHttpClient()
        {
            var client = httpClientFactory.CreateClient("SystemApiClient");
            var stringToken = await localStorageService.GetToken();//Lấy token từ localStorageService
            if (string.IsNullOrEmpty(stringToken)) return client;

            var deserializeToken = Serializations.DeserializeJsonString<UserSession>(stringToken);
            if (deserializeToken == null) return client;

            //Token hợp lệ
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Beazer", deserializeToken.Token);
            return client;
        }
        public HttpClient GetPublicHttpClient()
        {
            var client = httpClientFactory.CreateClient("SystemApiClient");
            client.DefaultRequestHeaders.Remove(HeaderKey);
            return client;
        }
    }
    //public class GetHttpClient
    //{
    //    private readonly IHttpClientFactory httpClientFactory;
    //    private readonly LocalStorageService localStorageService;
    //    private const string HeaderKey = "Authorization";

    //    public GetHttpClient(IHttpClientFactory httpClientFactory, LocalStorageService localStorageService)
    //    {
    //        this.httpClientFactory = httpClientFactory;
    //        this.localStorageService = localStorageService;
    //    }

    //    public async Task<HttpClient> GetPrivateHttpClient()
    //    {
    //        var client = httpClientFactory.CreateClient("SystemApiClient");
    //        var stringToken = await localStorageService.GetToken();
    //        if (string.IsNullOrEmpty(stringToken)) return client;

    //        var deserializeToken = Serializations.DeserializeJsonString<UserSession>(stringToken);
    //        if (deserializeToken == null) return client;

    //        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", deserializeToken.Token);
    //        return client;
    //    }

    //    public HttpClient GetPublicHttpClient()
    //    {
    //        var client = httpClientFactory.CreateClient("SystemApiClient");
    //        client.DefaultRequestHeaders.Remove(HeaderKey);
    //        return client;
    //    }
    //}

}
