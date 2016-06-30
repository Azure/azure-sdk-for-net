using Microsoft.Azure.Batch.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using AsyncTask = System.Threading.Tasks.Task;
using System.Net;
using Newtonsoft.Json;

namespace Microsoft.Azure.Batch.Conventions.Files.IntegrationTests.Utilities
{
    public sealed class FakeBatchServiceClient : BatchServiceClient
    {
        public FakeBatchServiceClient(Func<HttpRequestMessage, HttpResponseMessage> impl)
            : base(new FakingHandler(impl))
        {
        }

        public FakeBatchServiceClient(object responseBody)
            : this(_ => FakeResponse(responseBody))
        {
        }

        public FakeBatchServiceClient()
            : this(_ => { throw new InvalidOperationException("FakeBatchServiceClient not configured with any responses"); })
        {
        }

        public static HttpResponseMessage FakeResponse(object responseBody)
        {
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseBody)),
            };
        }

        private class FakingHandler : DelegatingHandler
        {
            private readonly Func<HttpRequestMessage, HttpResponseMessage> _impl;

            public FakingHandler(Func<HttpRequestMessage, HttpResponseMessage> impl)
            {
                _impl = impl;
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                return AsyncTask.FromResult(_impl(request));
            }
        }
    }
}
