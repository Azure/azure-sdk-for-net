// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Rest.ClientRuntime.Tests.Fakes
{
    public class FakeServiceClient : ServiceClient<FakeServiceClient>
    {
        private ServiceClientCredentials _clientCredentials;
        private HttpRequestMessage _httpRequest;

        public FakeServiceClient()
        {
            // Prevent base constructor from executing
        }

        public FakeServiceClient(HttpClientHandler httpMessageHandler, params DelegatingHandler[] handlers)
            : base(httpMessageHandler, handlers)
        {
        }

        public FakeServiceClient(
                        HttpClientHandler httpMessageHandler, 
                        ServiceClientCredentials credentials, 
                        params DelegatingHandler[] handlers)
                            : this(httpMessageHandler, handlers)
        {
            _clientCredentials = credentials;
        }


        private async Task<HttpResponseMessage> DoStuff(string content = null)
        {
            // Construct URL
            string url = "http://tempuri.norg";

            // Create HTTP transport objects
            _httpRequest = null;

            _httpRequest = new HttpRequestMessage();
            _httpRequest.Method = HttpMethod.Get;
            _httpRequest.RequestUri = new Uri(url);

            // Set content
            if (content != null)
            {
                _httpRequest.Content = new StringContent(content);
            }

            // Set Headers
            _httpRequest.Headers.Add("x-ms-version", "2013-11-01");

            // Set Credentials
            var cancellationToken = new CancellationToken();
            if (_clientCredentials != null)
            {
                await _clientCredentials.ProcessHttpRequestAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            }
            cancellationToken.ThrowIfCancellationRequested();
            return await this.HttpClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
        }

        private async Task<HttpOperationResponse> DoStuffAndThrow(string content = null)
        {
            // Construct URL
            string url = "http://tempuri.norg";

            // Create HTTP transport objects
            _httpRequest = null;

            _httpRequest = new HttpRequestMessage();
            _httpRequest.Method = HttpMethod.Get;
            _httpRequest.RequestUri = new Uri(url);

            // Set content
            if (content != null)
            {
                _httpRequest.Content = new StringContent(content);
            }

            // Set Headers
            _httpRequest.Headers.Add("x-ms-version", "2013-11-01");

            // Set Credentials
            var cancellationToken = new CancellationToken();
            if (_clientCredentials != null)
            {
                await _clientCredentials.ProcessHttpRequestAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            }
            cancellationToken.ThrowIfCancellationRequested();
            var httpResponse = await this.HttpClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            throw new HttpOperationException
            {
                Request = new HttpRequestMessageWrapper(_httpRequest, content),
                Response = new HttpResponseMessageWrapper(httpResponse, httpResponse.Content.AsString())
            };
        }

        public HttpResponseMessage DoStuffSync(string content = null)
        {
            return Task.Factory.StartNew(() =>
            {
                return DoStuff(content);
            }).Unwrap().GetAwaiter().GetResult();
        }

        public HttpOperationResponse DoStuffAndThrowSync(string content = null)
        {
            return Task.Factory.StartNew(() =>
            {
                return DoStuffAndThrow(content);
            }).Unwrap().GetAwaiter().GetResult();
        }

        protected override void Dispose(bool disposing)
        {
            _httpRequest.Dispose();
            base.Dispose(disposing);
        }
    }
}
