// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.DigitalTwins.Models;

namespace Azure.ResourceManager.DigitalTwins.Tests
{
    public class DigitalTwinsManagementTests : DigitalTwinsManagementTestBase
    {
        public DigitalTwinsManagementTests(bool isAsync)
            : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateDigitalTwinWithSystemAssignedIdentityAndEndpoint()
        {
            // Create ADT instance
            string digitalTwinsInstanceName = Recording.GenerateAssetName("sdkTestAdt");
            ArmOperation<DigitalTwinsDescriptionResource> createAdtInstanceResponse = await ResourceGroup.GetDigitalTwinsDescriptions().CreateOrUpdateAsync(
                WaitUntil.Completed,
                digitalTwinsInstanceName,
                new DigitalTwinsDescriptionData(Location)
                {
                    Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned),
                }).ConfigureAwait(false);

            DigitalTwinsDescriptionResource digitalTwinsResource = createAdtInstanceResponse.Value;

            // Ensure names of instance are equal
            Assert.That(digitalTwinsResource.Data.Name, Is.EqualTo(digitalTwinsInstanceName));
            Assert.That(digitalTwinsResource.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.SystemAssigned));

            // Create an egress endpoint
            string endpointName = Recording.GenerateAssetName("sdkTestEndpoint");
            Uri eventHubNamespaceUri = new Uri("sb://myeventhubnamespace.servicebus.windows.net");
            string eventHubName = "MyEventHub";

            ArmOperation<DigitalTwinsEndpointResource> createEndpointResponse = await digitalTwinsResource.GetDigitalTwinsEndpointResources().CreateOrUpdateAsync(
                WaitUntil.Completed,
                endpointName,
                new DigitalTwinsEndpointResourceData(
                    new DigitalTwinsEventHubProperties
                    {
                        AuthenticationType = DigitalTwinsAuthenticationType.IdentityBased,
                        EndpointUri = eventHubNamespaceUri,
                        EntityPath = eventHubName,
                    }));

            DigitalTwinsEndpointResource endpointResource = createEndpointResponse.Value;

            // Ensure endpoint configuration was stored correctly
            Assert.That(endpointResource.Data.Name, Is.EqualTo(endpointName));
            Assert.That(endpointResource.Data.Properties.AuthenticationType, Is.EqualTo(DigitalTwinsAuthenticationType.IdentityBased));
            Assert.IsAssignableFrom<DigitalTwinsEventHubProperties>(endpointResource.Data.Properties);
            DigitalTwinsEventHubProperties eventHubEndpointProperties = (DigitalTwinsEventHubProperties)endpointResource.Data.Properties;
            Assert.That(eventHubEndpointProperties.EndpointUri, Is.EqualTo(eventHubNamespaceUri));
            Assert.That(eventHubEndpointProperties.EntityPath, Is.EqualTo(eventHubName));
        }
    }
}
