// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;

namespace CR.Azure.FullDesktop.Tests.Fakes
{
    public class FakeServiceClientWithCredentials : ServiceClient<FakeServiceClientWithCredentials>
    {
        private Uri _baseUri;
        private ServiceClientCredentials _credentials;

        /// <summary>
        /// Initializes a new instance of the FakeServiceClientWithCredentials class.
        /// </summary>
        private FakeServiceClientWithCredentials()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the FakeServiceClientWithCredentials class.
        /// </summary>
        public FakeServiceClientWithCredentials(ServiceClientCredentials credentials, Uri baseUri)
            : base()
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
        public FakeServiceClientWithCredentials( ServiceClientCredentials credentials, Uri baseUri, HttpClientHandler rootHandler, params DelegatingHandler[] handlers)
            : base(rootHandler, handlers)
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
        public FakeServiceClientWithCredentials(ServiceClientCredentials credentials, Uri baseUri, params DelegatingHandler[] handlers)
            : base(handlers)
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
        public FakeServiceClientWithCredentials(ServiceClientCredentials credentials, params DelegatingHandler[] handlers)
            : base(handlers)
        {
            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }
            this._credentials = credentials;
            this._baseUri = new Uri("https://TBD");

            this.Credentials.InitializeServiceClient(this);
        }

                /// <summary>
        /// Initializes a new instance of the FakeServiceClientWithCredentials class.
        /// </summary>
        public FakeServiceClientWithCredentials(ServiceClientCredentials credentials, HttpClientHandler rootHandler, params DelegatingHandler[] handlers)
            : base(rootHandler, handlers)
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

        public ServiceClientCredentials Credentials
        {
            get { return _credentials; }
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
    }
}
