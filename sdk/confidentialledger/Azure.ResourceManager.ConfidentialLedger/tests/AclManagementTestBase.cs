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
    public abstract class AclManagementTestBase : ManagementRecordedTestBase<AclManagementTestEnvironment>
    {
        private ConfidentialLedgerCollection LedgerCollection { get; set; }

        private static readonly AzureLocation s_defaultTestLocation = AzureLocation.WestEurope;

        protected SubscriptionResource Subscription;

        protected AclManagementTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        protected AclManagementTestBase(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task InitializeTestResources()
        {
            Subscription = await GlobalClient.GetDefaultSubscriptionAsync();
            ResourceGroupCollection resourceGroups = Subscription.GetResourceGroups();
            ResourceGroupResource resourceGroup = (await resourceGroups.CreateOrUpdateAsync(WaitUntil.Completed,
                TestEnvironment.TestResourceGroup, new ResourceGroupData(s_defaultTestLocation))).Value;

            LedgerCollection =  resourceGroup.GetConfidentialLedgers();

            await StopSessionRecordingAsync();
        }

        [OneTimeTearDown]
        public void CleanTestResource()
        {
            CleanupResourceGroups();
        }

        protected async Task<ConfidentialLedgerResource> GetLedgerByName(string ledgerName)
        {
            var resourceId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{TestEnvironment.TestResourceGroup}/providers/Microsoft.ConfidentialLedger/ledgers/{ledgerName}";
            return await LedgerCollection.GetAsync(new ResourceIdentifier(resourceId).Name);
        }

        protected async Task CreateLedger(string ledgerName)
        {
            ConfidentialLedgerData ledgerData = new(s_defaultTestLocation);
            await LedgerCollection.CreateOrUpdateAsync(WaitUntil.Completed, ledgerName, ledgerData);
        }
    }
}
