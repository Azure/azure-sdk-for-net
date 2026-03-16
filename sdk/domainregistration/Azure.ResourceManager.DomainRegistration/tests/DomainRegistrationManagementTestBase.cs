// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using Azure.ResourceManager.DomainRegistration.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.DomainRegistration.Tests
{
    public class DomainRegistrationManagementTestBase : ManagementRecordedTestBase<DomainRegistrationManagementTestEnvironment>
    {
        protected AzureLocation DefaultLocation => AzureLocation.EastUS;
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }

        protected DomainRegistrationManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected DomainRegistrationManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
        }

        protected async Task<ResourceGroupResource> CreateResourceGroupAsync()
        {
            var resourceGroupName = Recording.GenerateAssetName("testRG-");
            var rgOp = await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(
                WaitUntil.Completed,
                resourceGroupName,
                new ResourceGroupData(DefaultLocation)
                {
                    Tags =
                    {
                        { "test", "env" }
                    }
                });
            return rgOp.Value;
        }
    }
}
