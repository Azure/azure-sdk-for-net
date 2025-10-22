// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.ResourceManager.NetworkCloud.Tests
{
    public class NetworkCloudManagementTestBase : ManagementRecordedTestBase<NetworkCloudManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected ResourceGroupResource ResourceGroupResource { get; private set; }
        protected SubscriptionResource SubscriptionResource { get; private set; }

        protected NetworkCloudManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
            BodyKeySanitizers.Add(new BodyKeySanitizer("properties.vmImageRepositoryCredentials.password") { Value = "fake-password123" });
            BodyKeySanitizers.Add(new BodyKeySanitizer("..containerUrl") { Value = "https://sanitized.blob.core.windows.net/container" });
            BodyKeySanitizers.Add(new BodyKeySanitizer("..vaultUri") { Value = "https://sanitized.vault.azure.net" });

            SanitizersToRemove.Add("AZSDK3402");
        }

        protected NetworkCloudManagementTestBase(bool isAsync)
            : base(isAsync)
        {
            BodyKeySanitizers.Add(new BodyKeySanitizer("properties.vmImageRepositoryCredentials.password") { Value = "fake-password123" });
            BodyKeySanitizers.Add(new BodyKeySanitizer("..containerUrl") { Value = "https://sanitized.blob.core.windows.net/container" });
            BodyKeySanitizers.Add(new BodyKeySanitizer("..vaultUri") { Value = "https://sanitized.vault.azure.net" });

            SanitizersToRemove.Add("AZSDK3402");
        }

        [SetUp]
        public async Task SetUp()
        {
            Client = GetArmClient();

            var subscriptionId = SubscriptionResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId);
            SubscriptionResource = Client.GetSubscriptionResource(subscriptionId);
            ResourceGroupResource = await CreateResourceGroup(SubscriptionResource, "networkcloud-sdk", TestEnvironment.Location);

            TestContext.Out.WriteLine("using resource group: " + ResourceGroupResource.Id);
            TestContext.Out.WriteLine("using subscription: " + SubscriptionResource.Id);
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }
    }
}
