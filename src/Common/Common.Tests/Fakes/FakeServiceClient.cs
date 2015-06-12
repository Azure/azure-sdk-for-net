//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Hyak.Common;

namespace Microsoft.Azure.Common.Test.Fakes
{
    public class FakeServiceClient : ServiceClient<FakeServiceClient>
    {
        public FakeServiceClient()
        {
            // Prevent base constructor from executing
        }

        public FakeServiceClient(HttpMessageHandler httpMessageHandler)
            : this()
        {
            InitializeHttpClient(httpMessageHandler);
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

        /// <summary>
        /// Get an instance of the FakeServiceClient class that uses the handler while initiating web requests.
        /// </summary>
        /// <param name="handler">the handler</param>
        public override FakeServiceClient WithHandler(DelegatingHandler handler)
        {
            return WithHandler(new FakeServiceClient(), handler);
        }
    }
}
