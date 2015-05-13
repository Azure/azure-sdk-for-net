using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AzureRedisCache.Tests
{
    public class DummyResponseDelegatingHandler : DelegatingHandler
    {
        private HttpResponseMessage _response;

        public DummyResponseDelegatingHandler(HttpResponseMessage response)
        {
            _response = response;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            return _response;
        }
    }
}
