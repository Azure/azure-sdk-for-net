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
            Assert.That(assessmentProjectResource, Is.Not.Null);

            string privateEndpointConnectionName = "ccy-pe1950project1581pe.93ce5be1-e545-434b-93e5-d4a4d1a705f0";

            var collectionResponse = assessmentProjectResource.GetMigrationAssessmentPrivateEndpointConnections();

            // Get All Private Endpoint Connections
            var privateEndpointConnectionCollection = await collectionResponse.GetAllAsync().ToEnumerableAsync();
            Assert.That(privateEndpointConnectionCollection, Is.Not.Null);
            Assert.That(privateEndpointConnectionCollection, Is.Not.Empty);

            var privateEndpointConnection = privateEndpointConnectionCollection.FirstOrDefault();
            Assert.That(privateEndpointConnection, Is.Not.Null);

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
            Assert.Multiple(() =>
            {
                Assert.That(privateEndpointConnectionResponse.HasCompleted, Is.True);
                Assert.That(privateEndpointConnectionResource, Is.Not.Null);
            });

            // Get Private Endpoint Connection
            privateEndpointConnectionResource = await collectionResponse.GetAsync(privateEndpointConnectionName);
            Assert.Multiple(() =>
            {
                Assert.That(privateEndpointConnectionResource, Is.Not.Null);
                Assert.That(privateEndpointConnectionName, Is.EqualTo(privateEndpointConnectionResource.Data.Name));
            });

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
            Assert.That(assessmentProjectResource, Is.Not.Null);

            // Get All Private Link Services
            var privateLinkServiceCollection = assessmentProjectResource.GetMigrationAssessmentPrivateLinkResources();
            var privateLinkServiceResponse =
                await privateLinkServiceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(privateLinkServiceResponse, Is.Not.Null);
            Assert.That(privateLinkServiceResponse, Is.Not.Empty);

            string privateLinkResourceName = "Default";
            var privateLinkServiceResource = await privateLinkServiceCollection.GetAsync(privateLinkResourceName);
            Assert.Multiple(() =>
            {
                Assert.That(privateLinkServiceResource, Is.Not.Null);
                Assert.That(privateLinkResourceName, Is.EqualTo(privateLinkServiceResource.Value.Data.Name));
            });
        }
    }
}
