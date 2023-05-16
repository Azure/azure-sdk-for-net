// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.ResourceManager.ConfidentialLedger.Tests
{
    public abstract class MccfManagementTestBase : ManagementRecordedTestBase<MccfManagementTestEnvironment>
    {
        protected SubscriptionResource Subscription;
        protected string mccfName;

        private readonly string _testResourceGroupPrefix = "sdk-test-rg-";
        private static readonly AzureLocation s_defaultTestLocation = AzureLocation.WestEurope;
        private string _resourceGroupName;
        private readonly string _testFixtureName;
        private ResourceGroupResource _resourceGroup;

        protected MccfManagementTestBase(bool isAsync, RecordedTestMode mode, string testFixtureName) : base(isAsync, mode)
        {
            _testFixtureName = testFixtureName;
        }

        protected MccfManagementTestBase(bool isAsync, string testFixtureName) : base(isAsync)
        {
            _testFixtureName = testFixtureName;
        }

        [OneTimeSetUp]
        public async Task InitializeTestResources()
        {
            SubscriptionResource subscription = await GlobalClient.GetDefaultSubscriptionAsync();
            ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();
            _resourceGroupName = _testResourceGroupPrefix + _testFixtureName;
            await resourceGroups.CreateOrUpdateAsync(WaitUntil.Completed,
                _resourceGroupName, new ResourceGroupData(s_defaultTestLocation));

            await StopSessionRecordingAsync();
        }

        [SetUp]
        public void Setup()
        {
            ArmClient armClient = GetArmClient();
            Subscription = armClient.GetSubscriptionResource(
                new ResourceIdentifier($"/subscriptions/{TestEnvironment.SubscriptionId}"));
            ResourceGroupCollection resourceGroups = Subscription.GetResourceGroups();
            _resourceGroup =  resourceGroups.GetAsync(_resourceGroupName).Result;
            mccfName = TestEnvironment.TestMccfNamePrefix + _testFixtureName;
        }

        /// <summary>
        /// Method fetches the ledger detail provided the ledger name
        /// It looks for the ledger in the resource group configured for the test fixture from where this method was invoked
        /// </summary>
        /// <param name="mccfName"></param>
        /// <returns></returns>
        protected async Task<ManagedCCFResource> GetMccfByName(string mccfName)
        {
            var resourceId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{_resourceGroupName}/providers/Microsoft.ConfidentialLedger/ManagedCCFs/{mccfName}";
            return await _resourceGroup.GetManagedCCFs().GetAsync(new ResourceIdentifier(resourceId).Name);
        }

        /// <summary>
        /// Method takes the ledger name and starts a long running job for creating the confidential ledger
        /// By default it create the ledger in West Europe location
        /// </summary>
        /// <param name="mccfName"></param>
        protected async Task CreateMccf(string mccfName)
        {
            ManagedCCFData mccfData = new(s_defaultTestLocation);
            await _resourceGroup.GetManagedCCFs().CreateOrUpdateAsync(WaitUntil.Completed, mccfName, mccfData);
        }

        /// <summary>
        /// Method takes the ledger name and try to update the the ledger with the given ledger data
        /// </summary>
        /// <param name="mccfName"></param>
        /// <param name="mccfData"></param>
        protected async Task UpdateMccf(string mccfName, ManagedCCFData mccfData)
        {
            await _resourceGroup.GetManagedCCFs().CreateOrUpdateAsync(WaitUntil.Completed, mccfData.Name, mccfData);
        }
    }
}
