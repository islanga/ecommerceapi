namespace ecommerceclient.Helper
{
    public class EcommerceAPI
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7047/");

            return client;
        }
    }
}
