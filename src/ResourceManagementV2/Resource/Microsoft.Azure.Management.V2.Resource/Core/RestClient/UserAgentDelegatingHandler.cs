using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core
{
    public class UserAgentDelegatingHandler : DelegatingHandlerBase
    {
        private string userAgent;
        public UserAgentDelegatingHandler() : base() { }

        public UserAgentDelegatingHandler(HttpMessageHandler innerHandler) : base(innerHandler)
        { }

        public void setUserAgent(string userAgent)
        {
            this.userAgent = userAgent;
        }

        public void appendUserAgent(string userAgent)
        {
            this.userAgent = " " + userAgent;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("User-Agent", this.userAgent);
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
