// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.IotCentral.Models;
using NUnit.Framework;
using Azure.Core;

namespace Azure.ResourceManager.IotCentral.Tests
{
    public class IotCentralManagementTestBase : ManagementRecordedTestBase<IotCentralManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        protected IotCentralManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected IotCentralManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public new Task OneTimeSetUp() => base.OneTimeSetUp();

        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            await base.StopSessionRecordingAsync();
            base.OneTimeCleanupResourceGroups();
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }

        public string GetRandomTestName() { return Recording.GenerateAssetName("test-"); }

        protected async Task<ResourceGroupResource> CreateResourceGroupAsync(SubscriptionResource subscription, string rgNamePrefix)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            var input = new ResourceGroupData(AzureLocation.WestUS);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }
    }
}
