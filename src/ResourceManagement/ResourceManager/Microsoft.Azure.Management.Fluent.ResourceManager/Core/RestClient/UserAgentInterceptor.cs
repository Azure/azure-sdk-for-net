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
    public class UserAgentInterceptor : RequestInterceptorBase
    {
        private List<string> userAgents;
        public UserAgentInterceptor() : base() {
            this.userAgents = new List<string>();
        }

        public void SetUserAgent(string userAgent)
        {
            this.userAgents.Clear();
            this.AppendUserAgent(userAgent);
        }

        public void AppendUserAgent(string userAgent)
        {
            this.userAgents.Add(userAgent);
        }

        public override async Task<HttpResponseMessage> SendAsync(Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> nextSendAsync,
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (this.userAgents.Any())
            {
                if (request.Headers.UserAgent != null)
                {
                    this.userAgents.All(userAgent => {
                        request.Headers.UserAgent.TryParseAdd(userAgent);
                        return true;
                    });
                }
                else
                {
                    request.Headers.Add("User-Agent", string.Join(" ", this.userAgents));
                }
            }
            return await nextSendAsync(request, cancellationToken);
        }
    }
}
