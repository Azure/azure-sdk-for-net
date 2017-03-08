using Microsoft.Rest.ClientRuntime.Tests.SvcClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Rest.ClientRuntime.Tests
{
    public class SvcClientWithHttpClientTests
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
            ContosoServiceClient contosoClient = new FabricamServiceClient(new HttpClientHandler(), handlers);
            HttpResponseMessage response = contosoClient.DoSyncWork();
            string cont = response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.Equal("Delayed User Provided HttpClient after initialization", cont);
        }
    }
}
