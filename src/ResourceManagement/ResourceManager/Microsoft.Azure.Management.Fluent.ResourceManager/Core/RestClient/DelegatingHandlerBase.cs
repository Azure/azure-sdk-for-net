// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Fluent.Resource.Core
{
    public abstract class RequestInterceptorBase : IRequestInterceptor
    {
        protected RequestInterceptorBase() { }

        abstract public Task<HttpResponseMessage> SendAsync(Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> nextSendAsync,
            HttpRequestMessage request,
            CancellationToken cancellationToken);

        protected string getHeader(HttpHeaders headers, string name)
        {
            IEnumerable<string> values;
            var found = headers.TryGetValues(name, out values);
            if (found)
            {
                return values.FirstOrDefault();
            }

            return null;
        }
        protected bool isHeaderExists(HttpHeaders headers, string name)
        {
            return headers.Any(h => h.Key.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
