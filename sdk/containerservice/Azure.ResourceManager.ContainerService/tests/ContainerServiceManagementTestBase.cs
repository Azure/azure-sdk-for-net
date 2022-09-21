// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.ResourceManager.ContainerService.Tests
{
    public class ContainerServiceManagementTestBase : ManagementRecordedTestBase<ContainerServiceManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected ResourceGroupResource ResourceGroup { get; private set; }
        protected AzureLocation DefaultLocation = AzureLocation.WestUS;

        protected ContainerServiceManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected ContainerServiceManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            var sub = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup = (await sub.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("rg-"), new ResourceGroupData(DefaultLocation))).Value;
        }
    }
}
