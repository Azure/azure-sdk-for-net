using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Batch.Unit.Tests
{
    public class FakeHttpClientHandler : DelegatingHandler
    {
        private readonly Func<HttpRequestMessage, HttpResponseMessage> _message;

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_message(request));
        }

        public FakeHttpClientHandler(Func<HttpRequestMessage, HttpResponseMessage> message)
        {
            _message = message;
        }
    }
}