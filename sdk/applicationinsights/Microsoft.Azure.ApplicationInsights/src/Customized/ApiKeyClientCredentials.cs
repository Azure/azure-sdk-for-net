using Microsoft.Rest;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.ApplicationInsights.Query
{
    public class ApiKeyClientCredentials : ServiceClientCredentials
    {
        private string token;

        public ApiKeyClientCredentials(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentException($"{nameof(token)} must not be null or empty");
            }

            this.token = token;
        }

        public override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("x-api-key", token);
            return Task.FromResult(true);
        }
    }
}
