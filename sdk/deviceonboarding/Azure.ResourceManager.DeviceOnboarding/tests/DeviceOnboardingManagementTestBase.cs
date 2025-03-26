// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.ResourceManager.DeviceOnboarding.Tests
{
    public class DeviceOnboardingManagementTestBase : ManagementRecordedTestBase<DeviceOnboardingManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }

        protected DeviceOnboardingManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
            BodyKeySanitizers.Add(new BodyKeySanitizer("..containerUri") { Value = @"https://sanitized.blob.core.windows.net/mycontainer" });
        }

        protected DeviceOnboardingManagementTestBase(bool isAsync)
            : base(isAsync)
        {
            BodyKeySanitizers.Add(new BodyKeySanitizer("..containerUri") { Value = @"https://sanitized.blob.core.windows.net/mycontainer" });
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
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
