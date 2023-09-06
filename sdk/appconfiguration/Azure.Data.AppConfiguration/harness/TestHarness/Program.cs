using System.Net;
using Azure.Data.AppConfiguration;
using Azure.Core.Pipeline;
using System.Text;

class TestHttpMessageHandler : HttpMessageHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent("{ \"key\": \"abc\", \"value\" :\"def\" }", Encoding.UTF8, "application/json")
        });
    }
}

internal class Program
{
    static async Task Main(string[] args)
    {
        // Use any well formed connection string
        string connectionString = "<str>";

        var client = new ConfigurationClient(
            connectionString,
            new ConfigurationClientOptions
            {
                Transport = new HttpClientTransport(new TestHttpMessageHandler())
            });

        var result = await client.GetConfigurationSettingAsync("abc");

        var result2 = await client.SetConfigurationSettingAsync("abc", "def");
    }
}
