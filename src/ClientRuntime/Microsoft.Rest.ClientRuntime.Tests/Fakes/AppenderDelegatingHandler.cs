// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net.Http;
using System.Threading.Tasks;

namespace Microsoft.Rest.ClientRuntime.Tests.Fakes
{
    public class AppenderDelegatingHandler : DelegatingHandler
    {
        public string Value { get; set; }

        public AppenderDelegatingHandler(string value)
        {
            Value = value;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            System.Threading.CancellationToken cancellationToken)
        {
            var content = await request.Content.ReadAsStringAsync();
            content += "+" + Value;
            StringContent newContent = new StringContent(content);
            request.Content = newContent;
            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);
            return response;
        }
    }
}