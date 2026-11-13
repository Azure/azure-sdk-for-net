// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.DeviceRegistry.Tests
{
    public class DeviceRegistryManagementTestBase : ManagementRecordedTestBase<DeviceRegistryManagementTestEnvironment>
    {
        // Runs once before any DeviceRegistry test class is instantiated.
        // The static constructor executes before ManagementRecordedTestBase reads env vars,
        // so setting them here affects ALL test classes that inherit from this base.
        static DeviceRegistryManagementTestBase()
        {
            // ── Test Mode ──
            // Uncomment ONE of the lines below to force a specific test mode for ALL tests
            // without needing to set env vars (useful in Visual Studio Test Explorer).
            // NOTE: Visual Studio requires restart after changing env vars externally.
            //Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Record");
            //Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Live");
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");

            // ── Tenant ID ──
            //Environment.SetEnvironmentVariable("AZURE_TENANT_ID", "8bc1aaa9-4b2f-4162-976b-7d86459f0e7f");
            Environment.SetEnvironmentVariable("AZURE_TENANT_ID", "72f988bf-86f1-41af-91ab-2d7cd011db47");

            // ── Subscription ID ──
            //Environment.SetEnvironmentVariable("AZURE_SUBSCRIPTION_ID", "8c64812d-6e59-4e65-96b3-14a7cdb1a4e4");
            Environment.SetEnvironmentVariable("AZURE_SUBSCRIPTION_ID", "53cd450b-b108-4e6e-b048-f63c1dcc8c8f");

            // ── Log effective values ──
            var testMode = Environment.GetEnvironmentVariable("AZURE_TEST_MODE") ?? "(not set → defaults to Playback)";
            var tenantId = Environment.GetEnvironmentVariable("AZURE_TENANT_ID") ?? "(not set)";
            var subscriptionId = Environment.GetEnvironmentVariable("AZURE_SUBSCRIPTION_ID") ?? "(not set)";
            Console.WriteLine($"\n  AZURE_TEST_MODE       = {testMode}");
            Console.WriteLine($"  AZURE_TENANT_ID       = {tenantId}");
            Console.WriteLine($"  AZURE_SUBSCRIPTION_ID = {subscriptionId}\n");
        }

        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }

        protected DeviceRegistryManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected DeviceRegistryManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }
    }
}
