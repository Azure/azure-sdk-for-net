using System.Linq;
using System.Collections;
using System.Collections.Generic;
using CustomProviders.Tests.Helpers;
using Microsoft.CustomProviders;
using Microsoft.CustomProviders.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace CustomProviders.Tests
{
    public class CustomResourceProviderTests : TestBase
    {
        private const string ResourceGroupName = "swaggertestrg";
        private const string ResourceProviderName = "swaggertestactionname";
        private const string Location = "EastUS";
        private const string ActionRouteName = "rpActionRouteNameTest";
        private const string URLEndpoint = "http://www.msn.com/fakeendpoint";

        [Fact]
        public void CustomProvider_CRUD()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                using (var testFixture = new CustomProvidersTestBase(context))
                {
                    var rpRouteDef = new CustomRPActionRouteDefinition(ActionRouteName, URLEndpoint);
                    var rpManifest = new CustomRPManifest();
                    rpManifest.Location = Location;
                    rpManifest.Actions = new List<CustomRPActionRouteDefinition>();
                    rpManifest.Actions.Add(rpRouteDef);
                    
                    //1. Create an custom provider with Action
                    var createOperationResponse = testFixture.customprovidersClient.CustomResourceProvider.CreateOrUpdate(ResourceGroupName, ResourceProviderName, rpManifest);
                    Assert.NotNull(createOperationResponse);
                    Assert.Equal(ProvisioningState.Succeeded, createOperationResponse.ProvisioningState);
                    Assert.True(createOperationResponse.Actions.Count() == 1);

                    //2. Get custom provider
                    var getOperationResponse = testFixture.customprovidersClient.CustomResourceProvider.Get(ResourceGroupName, ResourceProviderName);
                    Assert.NotNull(getOperationResponse);
                    Assert.Equal(ProvisioningState.Succeeded, getOperationResponse.ProvisioningState);
                    Assert.True(getOperationResponse.Actions.Count() == 1);

                    //3. List custom provider by subscription
                    var subListOperationResponse = testFixture.customprovidersClient.CustomResourceProvider.ListBySubscription();
                    Assert.NotNull(subListOperationResponse);
                    Assert.True(subListOperationResponse.Count() == 1);

                    //4. List custom provider by resource group
                    var rgListOperationResponse = testFixture.customprovidersClient.CustomResourceProvider.ListByResourceGroup(ResourceGroupName);
                    Assert.NotNull(rgListOperationResponse);
                    Assert.True(rgListOperationResponse.Count() == 1);

                    //5. Delele custom provider
                    testFixture.customprovidersClient.CustomResourceProvider.Delete(ResourceGroupName, ResourceProviderName);

                    //6. Verify delete
                    rgListOperationResponse = testFixture.customprovidersClient.CustomResourceProvider.ListByResourceGroup(ResourceGroupName);
                    Assert.NotNull(rgListOperationResponse);
                    Assert.True(rgListOperationResponse.Count() == 0);
                }
            }
        }
    }
}


