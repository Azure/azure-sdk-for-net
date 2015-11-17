// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;

namespace HttpRecorder.Tests
{
    public class FakeHttpClient : ServiceClient<FakeHttpClient>
    {
        public FakeHttpClient(params DelegatingHandler[] handlers)
            : base(handlers)
        {
        }

        public FakeHttpClient()
        {
        }

        public async Task<HttpResponseMessage> DoStuffA()
        {
            // Construct URL
            string url = "http://www.microsoft.com/path/to/resourceA";

            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;

            httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Get;
            httpRequest.RequestUri = new Uri(url);

            // Set Headers
            httpRequest.Headers.Add("x-ms-version", "2013-11-01");
            httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "abcdefg");

            // Set Credentials
            var cancellationToken = new CancellationToken();
            cancellationToken.ThrowIfCancellationRequested();
            return await HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
        }

        public async Task<HttpResponseMessage> DoStuffB()
        {
            // Construct URL
            string url = "http://www.microsoft.com/path/to/resourceB";

            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;

            httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Get;
            httpRequest.RequestUri = new Uri(url);

            // Set Headers
            httpRequest.Headers.Add("x-ms-version", "2013-11-01");
            httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "xyz123");

            // Set Credentials
            var cancellationToken = new CancellationToken();
            cancellationToken.ThrowIfCancellationRequested();
            return await HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
        }

        public async Task<HttpResponseMessage> DoStuffC(string body, string versionHeader, string versionUrl)
        {
            // Construct URL
            string url = "http://www.microsoft.com/path/to/resourceB?api-version=" + versionUrl;

            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;

            httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Post;
            httpRequest.RequestUri = new Uri(url);
            httpRequest.Content = new StringContent(body);

            // Set Headers
            httpRequest.Headers.Add("x-ms-version", versionHeader);
            httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "xyz123");

            // Set Credentials
            var cancellationToken = new CancellationToken();
            cancellationToken.ThrowIfCancellationRequested();
            return await HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
        }

        public async Task<HttpResponseMessage> DoStuffD(string contentType)
        {
            // Construct URL
            string url = "http://www.microsoft.com/path/to/resourceB";

            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;

            httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Post;
            httpRequest.RequestUri = new Uri(url);
            httpRequest.Content = new StringContent("test", Encoding.UTF8, contentType);

            // Set Headers
            httpRequest.Headers.Add("x-ms-version", "2013-11-01");
            httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "xyz123");

            // Set Credentials
            var cancellationToken = new CancellationToken();
            cancellationToken.ThrowIfCancellationRequested();
            return await HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
        }

        public async Task<HttpResponseMessage> DoStuffX(string assetName)
        {
            // Construct URL
            string url = "http://www.microsoft.com/path/to/resource/" + assetName;

            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;

            httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Get;
            httpRequest.RequestUri = new Uri(url);

            // Set Headers
            httpRequest.Headers.Add("x-ms-version", "2013-11-01");
            httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "xyz123");

            // Set Credentials
            var cancellationToken = new CancellationToken();
            cancellationToken.ThrowIfCancellationRequested();
            return await HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
        }
    }
}
