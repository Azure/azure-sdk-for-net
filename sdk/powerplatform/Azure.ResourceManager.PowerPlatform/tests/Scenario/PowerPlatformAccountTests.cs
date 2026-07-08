// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.PowerPlatform.Tests.Scenario
{
    public class PowerPlatformAccountTests : PowerPlatformManagementTestBase
    {
        public PowerPlatformAccountTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        [RecordedTest]
        [Ignore("Recording is blocked by SetUp because ArmClient.GetDefaultSubscriptionAsync emits an Azure.Core.Http.Request diagnostic scope without az.namespace before the recording session exists.")]
        public async Task GetAll_ListsPowerPlatformAccounts()
        {
            var accounts = await DefaultSubscription.GetPowerPlatformAccountsAsync().ToEnumerableAsync();
            Assert.That(accounts, Is.Not.Null);
        }
    }
}
