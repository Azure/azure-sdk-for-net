// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Rest.ClientRuntime.Tests
{
    using Microsoft.Rest.ClientRuntime.Tests.CustomClients;
    using System.Net.Http;
    using Xunit;

    public class CustomClientWithHttpClientTests
    {
        [Fact]
        public void InitializeServiceClientWithHttpClient()
        {
            HttpClient hc = new HttpClient();
            ContosoServiceClient contosoClient = new ContosoServiceClient(hc);
            HttpResponseMessage response = contosoClient.DoSyncWork();
            Assert.NotNull(response);
        }

        [Fact]
        public void GetInitializedHttpClient()
        {
            ContosoServiceClient contosoClient = new ContosoServiceClient(null);
            HttpResponseMessage response = contosoClient.DoSyncWork();
            string cont = response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.NotNull(response);
        }

        [Fact]
        public void InitializeMessageHandlerPostContructor()
        {
            HttpClient hc = new HttpClient(new ContosoMessageHandler());
            ContosoServiceClient contosoClient = new ContosoServiceClient(hc);
            HttpResponseMessage response = contosoClient.DoSyncWork("Hello");
            string cont = response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.Equal("Contoso Rocks", cont);
        }

        [Fact]
        public void ProvideHttpClientAfterInitialization()
        {
            DelegatingHandler[] handlers = new ContosoMessageHandler[] { new ContosoMessageHandler() };
            ContosoServiceClient contosoClient = new ContosoServiceClient();
            HttpResponseMessage response = contosoClient.DoSyncWork();
            string cont = response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.Equal("Delayed User Provided HttpClient after initialization", cont);
        }
    }
}
