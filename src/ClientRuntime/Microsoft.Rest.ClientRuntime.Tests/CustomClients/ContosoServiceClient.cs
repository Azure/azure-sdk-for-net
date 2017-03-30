// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Rest.ClientRuntime.Tests.CustomClients
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Customized client that emulates how partners will use Customized code to extend
    /// generated client.
    /// </summary>
    public class ContosoServiceClient : ServiceClient<ContosoServiceClient>
    {
        /// <summary>
        /// Initializes with default contosomessage handler
        /// </summary>
        public ContosoServiceClient():base()
        {
            HttpClient = new HttpClient(new ContosoMessageHandler());
        }

        /// <summary>
        /// Overrides default handler (ContosoMessageHandler) with DelayedHandler if specified
        /// </summary>
        /// <param name="overRideDefaultHandler"></param>
        public ContosoServiceClient(bool overRideDefaultHandler)
        {
            if(overRideDefaultHandler)
            {
                HttpClient = new HttpClient(new DelayedHandler("Delayed User Provided HttpClient after initialization"));
            }
            else
            {
                HttpClient = new HttpClient(new ContosoMessageHandler());
            }
        }

        /// <summary>
        /// Constructor that accepts HttpClient
        /// </summary>
        /// <param name="httpClient"></param>
        public ContosoServiceClient(HttpClient httpClient) : base (httpClient)
        {

        }

        public ContosoServiceClient(HttpClientHandler rootHandler, DelegatingHandler[] handlers) 
            : base(rootHandler, handlers)
        { }

        /// <summary>
        /// Some task emulating getting response back
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public HttpResponseMessage DoSyncWork(string content = null)
        {
            return Task.Factory.StartNew(() =>
            {
                return DoStuff(content);
            }).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Creates request and sends
        /// </summary>
        /// <param name="content">string value</param>
        /// <returns></returns>
        private async Task<HttpResponseMessage> DoStuff(string content = null)
        {
            // Construct URL
            string url = "http://www.microsoft.com";

            // Create HTTP transport objects
            HttpRequestMessage _httpRequest = null;

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
            
            return await this.HttpClient.SendAsync(_httpRequest, new CancellationToken()).ConfigureAwait(false);
        }
    }
    
    /// <summary>
    /// Custom message handler
    /// </summary>
    public class ContosoMessageHandler : DelegatingHandler
    {
        public ContosoMessageHandler() : base()
        {
            InnerHandler = new HttpClientHandler();
        }

        /// <summary>
        /// Returns Contoso Rocks response
        /// </summary>
        /// <param name="request">HttpRequestMessage object</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns></returns>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            StringContent contosoContent = new StringContent("Contoso Rocks");
            HttpResponseMessage response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            response.Content = contosoContent;
            return await Task.Run(() => response);
        }
    }

    /// <summary>
    /// Yet another delegating handler for tests    
    /// </summary>
    public class DelayedHandler : DelegatingHandler
    {
        string _handlerData;
        private DelayedHandler() : base()
        {
            InnerHandler = new HttpClientHandler();
        }

        public DelayedHandler(string handlerData)
            : this()
        {
            _handlerData = handlerData;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            StringContent contosoContent = new StringContent(_handlerData);
            HttpResponseMessage response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            response.Content = contosoContent;
            return await Task.Run(() => response);
        }
    }
}
