// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;

namespace CR.Azure.NetCore.Tests.Fakes
{
    public class FakeServiceClient : ServiceClient<FakeServiceClient>
    {
        private FakeServiceClient() : base()
        {
            // Prevent base constructor from executing
        }

        public FakeServiceClient(HttpClientHandler httpMessageHandler)
            : base(httpMessageHandler)
        {
        }

        public async Task<HttpResponseMessage> DoStuff()
        {
            // Construct URL
            string url = "http://www.microsoft.com";
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            
            httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Get;
            httpRequest.RequestUri = new Uri(url);
                
            // Set Headers
            httpRequest.Headers.Add("x-ms-version", "2013-11-01");
                
            // Set Credentials
            var cancellationToken = new CancellationToken();
            cancellationToken.ThrowIfCancellationRequested();
            return await this.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
        }

    }
}
