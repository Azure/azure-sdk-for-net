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
            Assert.AreEqual(digitalTwinsInstanceName, digitalTwinsResource.Data.Name);
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssigned, digitalTwinsResource.Data.Identity.ManagedServiceIdentityType);

            // delete one
            await digitalTwinsResource.DeleteAsync(WaitUntil.Completed);

            //// Create an egress endpoint
            //string endpointName = Recording.GenerateAssetName("sdkTestEndpoint");
            //Uri eventHubNamespaceUri = new Uri("sb://myeventhubnamespace.servicebus.windows.net");
            //string eventHubName = "MyEventHub";

            //ArmOperation<DigitalTwinsEndpointResource> createEndpointResponse = await digitalTwinsResource.GetDigitalTwinsEndpointResources().CreateOrUpdateAsync(
            //    WaitUntil.Completed,
            //    endpointName,
            //    new DigitalTwinsEndpointResourceData(
            //        new DigitalTwinsEventHubProperties
            //        {
            //            AuthenticationType = DigitalTwinsAuthenticationType.IdentityBased,
            //            EndpointUri = eventHubNamespaceUri,
            //            EntityPath = eventHubName,
            //        }));

            //DigitalTwinsEndpointResource endpointResource = createEndpointResponse.Value;

            //// Ensure endpoint configuration was stored correctly
            //Assert.AreEqual(endpointName, endpointResource.Data.Name);
            //Assert.AreEqual(DigitalTwinsAuthenticationType.IdentityBased, endpointResource.Data.Properties.AuthenticationType);
            //Assert.IsAssignableFrom<DigitalTwinsEventHubProperties>(endpointResource.Data.Properties);
            //DigitalTwinsEventHubProperties eventHubEndpointProperties = (DigitalTwinsEventHubProperties)endpointResource.Data.Properties;
            //Assert.AreEqual(eventHubNamespaceUri, eventHubEndpointProperties.EndpointUri);
            //Assert.AreEqual(eventHubName, eventHubEndpointProperties.EntityPath);
        }
    }
}
