// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DevTestLabs.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.ResourceManager.DevTestLabs.Tests
{
    public class DevTestLabsManagementTestBase : ManagementRecordedTestBase<DevTestLabsManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected const string ResourceGroupNamePrefix = "DevTestLabRG";
        protected AzureLocation DefaultLocation = AzureLocation.EastUS;
        protected ResourceGroupResource TestResourceGroup { get; set; }
        protected DevTestLabResource TestDevTestLab { get; set; }

        protected DevTestLabsManagementTestBase(bool isAsync, RecordedTestMode mode)
            : base(isAsync, mode)
        {
            IgnoreAuthorizationDependencyVersions();
        }

        protected DevTestLabsManagementTestBase(bool isAsync)
            : base(isAsync)
        {
            IgnoreAuthorizationDependencyVersions();
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            TestResourceGroup = await CreateResourceGroup();
            TestDevTestLab = await CreateDevTestLab(TestResourceGroup, Recording.GenerateAssetName("lab"));
        }

        [TearDown]
        public async Task TestBaseTearDown()
        {
            await DeleteAllLocks(TestResourceGroup);
        }

        protected async Task DeleteAllLocks(ResourceGroupResource resourceGroup)
        {
            var rgLocks = await resourceGroup?.GetManagementLocks().GetAllAsync().ToEnumerableAsync();
            foreach (var item in rgLocks)
            {
                await item.DeleteAsync(WaitUntil.Completed);
            }
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup()
        {
            var subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName(ResourceGroupNamePrefix);
            ResourceGroupData input = new ResourceGroupData(DefaultLocation);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<DevTestLabResource> CreateDevTestLab(ResourceGroupResource rg, string labName)
        {
            DevTestLabData data = new DevTestLabData(DefaultLocation)
            {
                PremiumDataDisks = DevTestLabPremiumDataDisk.Disabled,
                EnvironmentPermission = DevTestLabEnvironmentPermission.Contributor,
            };
            var lab = await rg.GetDevTestLabs().CreateOrUpdateAsync(WaitUntil.Completed, labName, data);
            return lab.Value;
        }
    }
}
