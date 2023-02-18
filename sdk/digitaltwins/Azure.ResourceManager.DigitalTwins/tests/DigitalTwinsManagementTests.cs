// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.ResourceManager.Models;

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
        public async Task CreateDigitalTwinWithIdentity()
        {
            var location = AzureLocation.WestCentralUS;
            var subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "digitaltwinsrg", location).ConfigureAwait(false);
            string digitaltwinsName = Recording.GenerateAssetName("digitalTwinsResource");

            var digitalTwinsData = new DigitalTwinsDescriptionData(location);
            digitalTwinsData.Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned);

            var digitalTwinsResource = await rg.GetDigitalTwinsDescriptions().CreateOrUpdateAsync(WaitUntil.Completed, digitaltwinsName, digitalTwinsData).ConfigureAwait(false);
            Assert.AreEqual(digitaltwinsName, digitalTwinsResource.Value.Data.Name);
        }
    }
}
