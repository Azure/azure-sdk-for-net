// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.ResourceManager.EventGrid.Tests
{
    public class EventGridManagementTestBase : ManagementRecordedTestBase<EventGridManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        public SubscriptionResource DefaultSubscription { get; private set; }
        public AzureLocation DefaultLocation => AzureLocation.EastUS;
        public const string  ResourceGroupNamePrefix = "EventGridRG";

        protected EventGridManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected EventGridManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroupAsync()
        {
            string rgName = Recording.GenerateAssetName(ResourceGroupNamePrefix);
            ResourceGroupData input = new ResourceGroupData(DefaultLocation);
            var lro = await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<ResourceGroupResource> CreateResourceGroupAsync(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<PartnerRegistrationResource> CreatePartnerRegistration(ResourceGroupResource resourceGroup, string registrationName)
        {
            var data = new PartnerRegistrationData(new AzureLocation("Global"));
            var registration = await resourceGroup.GetPartnerRegistrations().CreateOrUpdateAsync(WaitUntil.Completed, registrationName, data);
            return registration.Value;
        }
    }
}
