// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Rest.ClientRuntime.Tests
{
    using Microsoft.Rest.ClientRuntime.Tests.CustomClients;
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class CustomClientWithHttpClientTests
    {
        const string MY_PRODUCT = "MyProduct";
        const string MY_VERSION = "MyVersion";
        const string DEFAULT_URI = "http://www.microsoft.com";

        /// <summary>
        /// Basic test to pass in simple HttpClient to the ServiceClient (Contoso)
        /// </summary>
        [Fact]
        public void InitializeServiceClientWithHttpClient()
        {
            HttpClient hc = new HttpClient();
            ContosoServiceClient contosoClient = new ContosoServiceClient(hc);
            HttpResponseMessage response = contosoClient.DoSyncWork();
            Assert.NotNull(response);
        }

        /// <summary>
        /// Pass in null HttpClient and get default HttpClient
        /// Verify if baseClient httpClient has the default information
        /// </summary>
        [Fact]
        public void GetBaseClassHttpClient()
        {
            string defaultProductName = "FxVersion";
            Version defaultProductVer;

            ContosoServiceClient contosoClient = new ContosoServiceClient(null);
            HttpResponseMessage response = contosoClient.DoSyncWork();
            string cont = response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.NotNull(response);

            HttpHeaderValueCollection<ProductInfoHeaderValue> userAgentValueCollection = contosoClient.HttpClient.DefaultRequestHeaders.UserAgent;
            var dP = userAgentValueCollection.Where<ProductInfoHeaderValue>((p) => p.Product.Name.Equals(defaultProductName)).FirstOrDefault<ProductInfoHeaderValue>();
            Version.TryParse(dP.Product.Version, out defaultProductVer);
            Assert.Equal(defaultProductName, dP.Product.Name);
            Assert.NotNull(defaultProductVer);
        }

        /// <summary>
        /// Creates Constoso Client with it's own handler
        /// </summary>
        [Fact]
        public void InitializeMessageHandlerPostContructor()
        {
            HttpClient hc = new HttpClient(new ContosoMessageHandler());
            ContosoServiceClient contosoClient = new ContosoServiceClient(hc);
            HttpResponseMessage response = contosoClient.DoSyncWork();
            string cont = response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.Equal("Contoso Rocks", cont);
        }

        /// <summary>
        /// This test will create contoso client with delayedHandler
        /// </summary>
        [Fact]
        public void ProvideHttpClientAfterInitialization()
        {
            ContosoServiceClient contosoClient = new ContosoServiceClient(overRideDefaultHandler: true);
            HttpResponseMessage response = contosoClient.DoSyncWork();
            string cont = response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.Equal("Delayed User Provided HttpClient after initialization", cont);
        }
        
        /// <summary>
        /// The purpose of this test is to verify if we use httpClient prior to
        /// creating service client, everything works as expected
        /// Also verifies if any properties set prior to constructing ServiceClient
        /// The provided httpClient will not change it's properties
        /// </summary>
        [Fact]
        public void UseHttpClientBeforeConstructingServiceClient()
        {
            HttpClient hc = new HttpClient(new ContosoMessageHandler());
            hc.BaseAddress = new Uri(DEFAULT_URI);
            HttpResponseMessage resMsg = SendAndReceiveResponse(hc);
            Assert.Equal(HttpStatusCode.OK, resMsg.StatusCode);
            
            ContosoServiceClient contosoClient = new ContosoServiceClient(hc);
            HttpResponseMessage response = contosoClient.DoSyncWork();
            string cont = response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.Equal("Contoso Rocks", cont);
            Assert.Equal(new Uri(DEFAULT_URI), contosoClient.HttpClient.BaseAddress);
        }

        /// <summary>
        /// THe HttpClient that is provided to ServiceClient will have it's own set of UserAgent information
        /// inside default headers. This is to verify if we merge DefaultHeader information
        /// </summary>
        [Fact]
        public void AddHeaderInformationToHttpClient()
        {
            Version defaultVersion = null;
            HttpClient hc = new HttpClient(new ContosoMessageHandler());
            hc.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(MY_PRODUCT, MY_VERSION));
            ContosoServiceClient contosoClient = new ContosoServiceClient(hc);
            HttpResponseMessage response = contosoClient.DoSyncWork();

            HttpHeaderValueCollection<ProductInfoHeaderValue> userAgentValueCollection = contosoClient.HttpClient.DefaultRequestHeaders.UserAgent;
            ProductInfoHeaderValue myProduct = userAgentValueCollection.Where<ProductInfoHeaderValue>((p) => p.Product.Name.Equals(MY_PRODUCT, StringComparison.OrdinalIgnoreCase)).First<ProductInfoHeaderValue>();
            Assert.Equal(MY_VERSION, myProduct.Product.Version);

            ProductInfoHeaderValue fxVer = userAgentValueCollection.Where<ProductInfoHeaderValue>((p) => p.Product.Name.Equals("FxVersion", StringComparison.OrdinalIgnoreCase)).First<ProductInfoHeaderValue>();
            Version.TryParse(fxVer.Product.Version, out defaultVersion);
            Assert.NotNull(defaultVersion);
        }

        /// <summary>
        /// This is to verify if a HttpClient is passed, we still add default userAgent information
        /// inside defaultheaders of the passed in HttpClient
        /// </summary>
        [Fact]
        public void AddFxVersionHeaderInformation()
        {
            Version defaultVersion = null;
            HttpClient hc = new HttpClient(new ContosoMessageHandler());
            hc.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("FxVersion", "1.0.0.0"));
            ContosoServiceClient contosoClient = new ContosoServiceClient(hc);
            HttpResponseMessage response = contosoClient.DoSyncWork();

            HttpHeaderValueCollection<ProductInfoHeaderValue> userAgentValueCollection = contosoClient.HttpClient.DefaultRequestHeaders.UserAgent;
            ProductInfoHeaderValue fxVer = userAgentValueCollection.Where<ProductInfoHeaderValue>((p) => p.Product.Name.Equals("FxVersion", StringComparison.OrdinalIgnoreCase)).First<ProductInfoHeaderValue>();
            Version.TryParse(fxVer.Product.Version, out defaultVersion);
            Assert.Equal(defaultVersion.ToString(), "1.0.0.0");
        }


        private HttpResponseMessage SendAndReceiveResponse(HttpClient httpClient)
        {
            // Construct URL
            //string url = "http://www.microsoft.com";

            // Create HTTP transport objects
            HttpRequestMessage _httpRequest = null;

            _httpRequest = new HttpRequestMessage();
            _httpRequest.Method = HttpMethod.Get;
            _httpRequest.RequestUri = new Uri(DEFAULT_URI);

            // Set Headers
            _httpRequest.Headers.Add("x-ms-version", "2013-11-01");

            return Task.Run<HttpResponseMessage>(async () => await httpClient.SendAsync(_httpRequest, new CancellationToken()).ConfigureAwait(false)).ConfigureAwait(false).GetAwaiter().GetResult();

        }

    }
}
