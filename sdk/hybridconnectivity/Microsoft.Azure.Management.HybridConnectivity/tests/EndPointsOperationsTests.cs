using Microsoft.Azure.Management.HybridConnectivity.Tests.Helpers;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using Microsoft.Azure.Management.HybridConnectivity;
using Microsoft.Azure.Management.HybridConnectivity.Models;
using Microsoft.Rest.Azure;
using System.Linq;

namespace Microsoft.Azure.Management.HybridConnectivity.Tests
{
    public class EndPointsOperationsTests : TestBase
    {
        const string resourceURI = "/subscriptions/1c70e365-4937-4ff9-8524-262064a268d8/resourceGroups/DotnetSDKTest/providers/Microsoft.HybridCompute/machines/LAPTOP-HDUMCR3M";

        [Fact]
        public void EndPoints_CreateOrUpdateEndpoint()
        {
            using (MockContext context = MockContext.Start(GetType().FullName))
            {
                HybridConnectivityManagementClient client = this.GetHybridConnectivityManagementClient(context);
                EndpointResource endpointResource = new EndpointResource
                {
                    EndpointResourceType = "default"
                };
                EndpointResource response = client.Endpoints.CreateOrUpdate(resourceURI, "default", endpointResource);
                this.AssertEndpointResource(response);
            }
        }

        [Fact]
        public void EndPoints_ListCredentials()
        {
            using (MockContext context = MockContext.Start(GetType().FullName))
            {
                HybridConnectivityManagementClient client = this.GetHybridConnectivityManagementClient(context);
                EndpointResource endpointResource = new EndpointResource
                {
                    EndpointResourceType = "default"
                };
                EndpointResource response = client.Endpoints.CreateOrUpdate(resourceURI, "default", endpointResource);
                this.AssertEndpointResource(response);
                EndpointAccessResource endpointAccessResource = client.Endpoints.ListCredentials(resourceURI, "default");
                Assert.NotNull(endpointAccessResource);
                Assert.False(string.IsNullOrEmpty(endpointAccessResource.AccessKey));
                Assert.NotNull(endpointAccessResource.ExpiresOn);
                Assert.False(string.IsNullOrEmpty(endpointAccessResource.HybridConnectionName));
                Assert.False(string.IsNullOrEmpty(endpointAccessResource.NamespaceName));
                Assert.False(string.IsNullOrEmpty(endpointAccessResource.NamespaceNameSuffix));
            }
        }

        [Fact]
        public void EndPoints_GetEndpoint()
        {
            using (MockContext context = MockContext.Start(GetType().FullName))
            {
                HybridConnectivityManagementClient client = this.GetHybridConnectivityManagementClient(context);
                EndpointResource response = client.Endpoints.Get(resourceURI, "default");
                this.AssertEndpointResource(response);
            }
        }

        [Fact]
        public void EndPoints_ListEndpoints()
        {
            using (MockContext context = MockContext.Start(GetType().FullName))
            {
                HybridConnectivityManagementClient client = this.GetHybridConnectivityManagementClient(context);
                IPage<EndpointResource> response = client.Endpoints.List(resourceURI);
                this.AssertEndpointResource(response.First());
            }
        }

        [Fact]
        public void EndPoints_UpdateEndpoint()
        {
            using (MockContext context = MockContext.Start(GetType().FullName))
            {
                EndpointResource endpointResource = new EndpointResource
                {
                    EndpointResourceType = "default"
                };
                HybridConnectivityManagementClient client = this.GetHybridConnectivityManagementClient(context);
                Assert.Throws<ErrorResponseException>(() => client.Endpoints.Update(resourceURI, "default", endpointResource));
            }
        }

        [Fact]
        public void EndPoints_DeleteEndpoint()
        {
            using (MockContext context = MockContext.Start(GetType().FullName))
            {
                HybridConnectivityManagementClient client = this.GetHybridConnectivityManagementClient(context);
                EndpointResource endpointResource = new EndpointResource
                {
                    EndpointResourceType = "default"
                };
                EndpointResource createResponse = client.Endpoints.CreateOrUpdate(resourceURI, "default", endpointResource);
                Assert.NotNull(createResponse.Id);

                client.Endpoints.Delete(resourceURI, "default");

                Assert.Throws<ErrorResponseException>(() => client.Endpoints.Get(resourceURI, "default"));
            }
        }

        private void AssertEndpointResource(EndpointResource response)
        {
            Assert.Equal(resourceURI + "/providers/Microsoft.HybridConnectivity/endpoints/default", response.Id);
            Assert.Equal("default", response.Name);
            Assert.Equal("microsoft.hybridconnectivity/endpoints", response.Type);
            Assert.Equal("Succeeded", response.ProvisioningState);
        }
    }
}