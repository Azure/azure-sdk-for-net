// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Text;
using System.Threading.Tasks;

namespace Azure.ResourceManager.HardwareSecurityModules.Tests
{
    public class HardwareSecurityModulesManagementTestBase : ManagementRecordedTestBase<HardwareSecurityModulesManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }
        protected HardwareSecurityModulesManagementTestEnvironment testEnvironment => TestEnvironment;
        protected AzureLocation Location;
        protected ResourceGroupResource ResourceGroupResource { get; private set; }
        protected GenericResourceCollection GenericResourceCollection { get; private set; }

        protected HardwareSecurityModulesManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected HardwareSecurityModulesManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
        }

        protected async Task BaseSetUpForTests(bool isDedicatedHsm = false)
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await CreateCommonClient();
            }
            //TODO will initialize resource groups here as well
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync();
            Location = isDedicatedHsm ? AzureLocation.NorthCentralUS : AzureLocation.EastUS2;
            GenericResourceCollection = Client.GetGenericResources();
            ResourceGroupResource = await CreateResourceGroup(DefaultSubscription, "sdkTestsRg", Location);
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
