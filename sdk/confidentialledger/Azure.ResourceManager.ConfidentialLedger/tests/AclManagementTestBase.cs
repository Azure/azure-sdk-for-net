// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using System.Threading.Tasks;
using Azure.Identity;

namespace Azure.ResourceManager.ConfidentialLedger.Tests
{
    public abstract class AclManagementTestBase : ManagementRecordedTestBase<AclManagementTestEnvironment>
    {
        private ResourceGroupCollection ResourceGroups { get; set; }

        protected AclManagementTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        protected AclManagementTestBase(bool isAsync) : base(isAsync)
        {
        }

        protected async Task InitializeClients()
        {
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            SubscriptionCollection subscriptions = armClient.GetSubscriptions();
            SubscriptionResource subscription = await subscriptions.GetAsync(AclManagementTestEnvironment.TestSubscriptionId);

            ResourceGroups = subscription.GetResourceGroups();
        }

        protected ConfidentialLedgerCollection GetConfidentialLedgerCollection()
        {
            ResourceGroupResource rgr  = ResourceGroups.Get(AclManagementTestEnvironment.TestResourceGroup);
            return rgr.GetConfidentialLedgers();
        }

        protected async Task<ConfidentialLedgerResource> GetLedgerByName(string ledgerName)
        {
            ConfidentialLedgerCollection confidentialLedgerCollection = GetConfidentialLedgerCollection();
            return await confidentialLedgerCollection.GetAsync(GetResourceIdentifier(ledgerName).Name);
        }

        protected async Task CreateLedger(string ledgerName, AzureLocation location)
        {
            ConfidentialLedgerCollection ledgerCollection = GetConfidentialLedgerCollection();

            ConfidentialLedgerData ledgerData = new ConfidentialLedgerData(location);
            await ledgerCollection.CreateOrUpdateAsync(WaitUntil.Completed, ledgerName, ledgerData);
        }

        private ResourceIdentifier GetResourceIdentifier(string ledgerName)
        {
            var resourceId =
                $"/subscriptions/{AclManagementTestEnvironment.TestSubscriptionId}/resourceGroups/{AclManagementTestEnvironment.TestResourceGroup}/providers/Microsoft.ConfidentialLedger/ledgers/{ledgerName}";
            return new ResourceIdentifier(resourceId);
        }
    }
}
