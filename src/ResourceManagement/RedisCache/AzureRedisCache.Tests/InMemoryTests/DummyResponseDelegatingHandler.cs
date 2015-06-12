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

#pragma warning disable 1998
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            return _response;
        }
#pragma warning restore 1998
    }
}
