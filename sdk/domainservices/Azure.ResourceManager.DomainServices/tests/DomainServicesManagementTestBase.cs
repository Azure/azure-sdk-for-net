// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.DomainServices.Tests
{
    public class DomainServicesManagementTestBase : ManagementRecordedTestBase<DomainServicesManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        public SubscriptionResource DefaultSubscription { get; private set; }
        public AzureLocation DefaultLocation => AzureLocation.WestUS2;
        public const string ResourceGroupNamePrefix = "domainservicesRG";

        protected DomainServicesManagementTestBase(bool isAsync, RecordedTestMode mode)
            : base(isAsync, mode)
        {
        }

        protected DomainServicesManagementTestBase(bool isAsync)
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
    }
}
