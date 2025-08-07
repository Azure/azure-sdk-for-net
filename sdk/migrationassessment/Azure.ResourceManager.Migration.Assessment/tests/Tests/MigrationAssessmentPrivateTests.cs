// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Migration.Assessment.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Moq;
using NUnit.Framework;

namespace Azure.ResourceManager.Migration.Assessment.Tests
{
    public class MigrationAssessmentPrivateTests : MigrationAssessmentManagementTestBase
    {
        public MigrationAssessmentPrivateTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        [Ignore("Defer for beta release; should address before stable release.")]
        public async Task TestPrivateEndpointConnectionOperations()
        {
            AzureLocation targetRegion = AzureLocation.EastUS;
            string targetSubscriptionId = DefaultSubscription.Data.SubscriptionId;
            ResourceGroupResource rg = await DefaultSubscription.GetResourceGroups().GetAsync("sakanwar");

            // Get Assessment Project
            var response = await rg.GetMigrationAssessmentProjectAsync("ccy-pe1950project");
            var assessmentProjectResource = response.Value;
            Assert.IsNotNull(assessmentProjectResource);

            string privateEndpointConnectionName = "ccy-pe1950project1581pe.93ce5be1-e545-434b-93e5-d4a4d1a705f0";

            var collectionResponse = assessmentProjectResource.GetMigrationAssessmentPrivateEndpointConnections();

            // Get All Private Endpoint Connections
            var privateEndpointConnectionCollection = await collectionResponse.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(privateEndpointConnectionCollection);
            Assert.GreaterOrEqual(privateEndpointConnectionCollection.Count, 1);

            var privateEndpointConnection = privateEndpointConnectionCollection.FirstOrDefault();
            Assert.IsNotNull(privateEndpointConnection);

            // Create Private Endpoint Connection
            var privateEndpointConnectionData =
                new MigrationAssessmentPrivateEndpointConnectionData()
                {
                    ConnectionState = new MigrationAssessmentPrivateLinkServiceConnectionState()
                    {
                        Status = MigrationAssessmentPrivateEndpointServiceConnectionStatus.Approved,
                        Description = "",
                        ActionsRequired = "",
                    },
                    PrivateEndpoint = new SubResource(),
                };

            var privateEndpointConnectionResponse =
                await collectionResponse.CreateOrUpdateAsync(WaitUntil.Completed, privateEndpointConnectionName, privateEndpointConnectionData);
            var privateEndpointConnectionResource = privateEndpointConnectionResponse.Value;
            Assert.IsTrue(privateEndpointConnectionResponse.HasCompleted);
            Assert.IsNotNull(privateEndpointConnectionResource);

            // Get Private Endpoint Connection
            privateEndpointConnectionResource = await collectionResponse.GetAsync(privateEndpointConnectionName);
            Assert.IsNotNull(privateEndpointConnectionResource);
            Assert.AreEqual(privateEndpointConnectionResource.Data.Name, privateEndpointConnectionName);

            // Delete Private Endpoint Connection
            await privateEndpointConnectionResource.DeleteAsync(WaitUntil.Completed);
        }

        [RecordedTest]
        [Ignore("Defer for beta release; should address before stable release.")]
        public async Task TestPrivateLinkServiceOperations()
        {
            AzureLocation targetRegion = AzureLocation.CentralUS;
            string targetSubscriptionId = DefaultSubscription.Data.SubscriptionId;
            ResourceGroupResource rg = await DefaultSubscription.GetResourceGroups().GetAsync("sdktest");

            // Get Assessment Project
            var response = await rg.GetMigrationAssessmentProjectAsync("privateendpoint-test4be2project");
            var assessmentProjectResource = response.Value;
            Assert.IsNotNull(assessmentProjectResource);

            // Get All Private Link Services
            var privateLinkServiceCollection = assessmentProjectResource.GetMigrationAssessmentPrivateLinkResources();
            var privateLinkServiceResponse =
                await privateLinkServiceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(privateLinkServiceResponse);
            Assert.GreaterOrEqual(privateLinkServiceResponse.Count, 1);

            string privateLinkResourceName = "Default";
            var privateLinkServiceResource = await privateLinkServiceCollection.GetAsync(privateLinkResourceName);
            Assert.IsNotNull(privateLinkServiceResource);
            Assert.AreEqual(privateLinkServiceResource.Value.Data.Name, privateLinkResourceName);
        }
    }
}
