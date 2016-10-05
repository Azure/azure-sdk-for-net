// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Fluent.Resource.Core
{
    public class UserAgentDelegatingHandler : DelegatingHandlerBase
    {
        private List<string> userAgents;
        public UserAgentDelegatingHandler() : base()
        {
            this.userAgents = new List<string>();
        }

        public UserAgentDelegatingHandler(HttpMessageHandler innerHandler) : base(innerHandler)
        { }

        public void SetUserAgent(string userAgent)
        {
            this.userAgents.Clear();
            this.AppendUserAgent(userAgent);
        }

        public void AppendUserAgent(string userAgent)
        {
            this.userAgents.Add(userAgent);
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (this.userAgents.Any())
            {
                if (request.Headers.UserAgent != null)
                {
                    foreach(var userAgent in this.userAgents)
                    {
                        request.Headers.UserAgent.TryParseAdd(userAgent);
                    }
                }
                else
                {
                    request.Headers.Add("User-Agent", string.Join(" ", this.userAgents));
                }
            }
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
