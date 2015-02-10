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
    public class FakeServiceClientWithCredentials : ServiceClient<FakeServiceClientWithCredentials>
    {
        private Uri _baseUri;
        private SubscriptionCloudCredentials _credentials;

        /// <summary>
        /// Initializes a new instance of the FakeServiceClientWithCredentials class.
        /// </summary>
        private FakeServiceClientWithCredentials()
            : base()
        {
            HttpClient.Timeout = TimeSpan.FromSeconds(300);
        }

        /// <summary>
        /// Initializes a new instance of the FakeServiceClientWithCredentials class.
        /// </summary>
        public FakeServiceClientWithCredentials(SubscriptionCloudCredentials credentials, Uri baseUri)
            : this()
        {
            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }
            if (baseUri == null)
            {
                throw new ArgumentNullException("baseUri");
            }
            this._credentials = credentials;
            this._baseUri = baseUri;

            this.Credentials.InitializeServiceClient(this);
        }

        /// <summary>
        /// Initializes a new instance of the FakeServiceClientWithCredentials class.
        /// </summary>
        public FakeServiceClientWithCredentials(SubscriptionCloudCredentials credentials)
            : this()
        {
            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }
            this._credentials = credentials;
            this._baseUri = new Uri("https://TBD");

            this.Credentials.InitializeServiceClient(this);
        }

        public Uri BaseUri
        {
            get { return _baseUri; }
        }

        public SubscriptionCloudCredentials Credentials
        {
            get { return _credentials; }
        }

        protected override void Clone(ServiceClient<FakeServiceClientWithCredentials> client)
        {
            base.Clone(client);
            FakeServiceClientWithCredentials management = client as FakeServiceClientWithCredentials;
            if (management != null)
            {
                management._credentials = Credentials;
                management._baseUri = BaseUri;
                management.Credentials.InitializeServiceClient(management);
            }
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

            await this.Credentials.ProcessHttpRequestAsync(httpRequest, new CancellationToken());
                
            // Set Headers
            httpRequest.Headers.Add("x-ms-version", "2013-11-01");
                
            // Set Credentials
            var cancellationToken = new CancellationToken();
            cancellationToken.ThrowIfCancellationRequested();
            return await HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
        }

        public override FakeServiceClientWithCredentials WithHandler(DelegatingHandler handler)
        {
            return (FakeServiceClientWithCredentials)WithHandler(new FakeServiceClientWithCredentials(), handler);
        }
    }
}
