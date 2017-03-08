// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Rest.ClientRuntime.Tests.CustomClients
{
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public class FabricamServiceClient : ContosoServiceClient
    {
        private HttpClient _httpClient;

        /// <summary>
        /// Constructor for FabricamServiceClient
        /// </summary>
        /// <param name="httpClient">HttpClient object</param>
        public FabricamServiceClient(HttpClient httpClient) : base(httpClient)
        { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="rootHandler">HttpClientHandler</param>
        /// <param name="handlers">DelegatingHandler </param>
        public FabricamServiceClient(HttpClientHandler rootHandler, DelegatingHandler[] handlers)
            : base(rootHandler, handlers)
        { }

        /// <summary>
        /// The idea is to have customized client override Get in the child class inheriting ServiceClient
        /// and provide an instance of HttpClient.
        /// This is yet another way for anyone to use their own HttpClient and override default existing client
        /// without using the overloaded ServiceClient(HttpClient) constructor
        /// </summary>
        public override HttpClient HttpClient
        {
            get
            {
                if (_httpClient == null)
                {
                    _httpClient = new HttpClient(new DelayedHandler("Delayed User Provided HttpClient after initialization"));
                }

                return _httpClient;
            }
        }
        
        protected override void Dispose(bool disposing)
        {
            if(_httpClient != null)
            {
                _httpClient.Dispose();
            }

            base.Dispose(disposing);
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