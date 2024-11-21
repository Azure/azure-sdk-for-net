// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Tracing;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Fabric.Tests
{
    public class FabricManagementTestBase : ManagementRecordedTestBase<FabricManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource Subscription { get; private set; }
        protected ResourceGroupResource ResourceGroup { get; private set; }

        protected AzureLocation DefaultLocation => AzureLocation.WestUS;
        protected ResourceType ResourceType => "Microsoft.Fabric/capacities";

        protected FabricManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected FabricManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            Subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup = (await Subscription.GetResourceGroupAsync(TestEnvironment.ResourceGroup)).Value;
        }
    }
}
