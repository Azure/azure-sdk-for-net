using Azure.Test.PerfStress;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace System.PerfStress
{
    public class HttpClientGetTest : PerfStressTest<UrlOptions>
    {
        private static HttpClient _httpClient;

        public HttpClientGetTest(UrlOptions options) : base(options)
        {
        }

        public override Task GlobalSetupAsync()
        {
            if (Options.Insecure)
            {
                var httpClientHandler = new HttpClientHandler();
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
                _httpClient = new HttpClient(httpClientHandler);
            }
            else
            {
                _httpClient = new HttpClient();
            }

            return Task.CompletedTask;
        }

        public override void Run(CancellationToken cancellationToken)
        {
            _httpClient.GetStringAsync(Options.Url).Wait();
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await _httpClient.GetStringAsync(Options.Url);
        }
    }
}
