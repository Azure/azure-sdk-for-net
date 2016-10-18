// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Microsoft.Rest.ClientRuntime.Tests.Fakes
{
    public class MirrorDelegatingHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            System.Threading.CancellationToken cancellationToken)
        {
            HttpStatusCode responseCode = HttpStatusCode.OK;
            IEnumerable<string> headerValues = null;
            if (request.Headers.TryGetValues("response-code", out headerValues))
            {
                Enum.TryParse(headerValues.First(), out responseCode);
            }

            var requestContent = await request.Content.ReadAsStringAsync();
            var response = new HttpResponseMessage(responseCode);
            response.Content = new StringContent(requestContent);
            return response;
        }
    }
}