// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.PowerPlatform.Tests.Scenario
{
    [TestFixture]
    [Ignore("PowerPlatform account scenario recording is pending; requires a configured Record-mode authentication environment.")]
    public class PowerPlatformAccountTests : PowerPlatformManagementTestBase
    {
        public PowerPlatformAccountTests()
            : base(true)
        {
        }

        [Test]
        [RecordedTest]
        public async Task GetAll_ListsPowerPlatformAccounts()
        {
            ResourceGroupResource resourceGroup = await CreateResourceGroup(DefaultSubscription, "powerplatform-rg-", AzureLocation.WestUS);
            PowerPlatformAccountResource account = null;

            try
            {
                PowerPlatformAccountCollection collection = resourceGroup.GetPowerPlatformAccounts();
                string accountName = Recording.GenerateAssetName("powerplatform-account-");
                PowerPlatformAccountData data = new PowerPlatformAccountData(AzureLocation.WestUS)
                {
                    Description = "PowerPlatform account scenario test"
                };

                ArmOperation<PowerPlatformAccountResource> operation = await collection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, data);
                account = operation.Value;

                Assert.That(operation.HasCompleted, Is.True);
                Assert.That(account, Is.Not.Null);
                Assert.That(account.Data.Name, Is.EqualTo(accountName));
                Assert.That(account.Data.Location, Is.EqualTo(AzureLocation.WestUS));

                bool existsInResourceGroup = false;
                await foreach (PowerPlatformAccountResource item in collection.GetAllAsync())
                {
                    Assert.That(item, Is.Not.Null);
                    if (item.Id == account.Id)
                    {
                        existsInResourceGroup = true;
                        break;
                    }
                }

                Assert.That(existsInResourceGroup, Is.True);

                bool existsInSubscription = false;
                await foreach (PowerPlatformAccountResource item in DefaultSubscription.GetPowerPlatformAccountsAsync())
                {
                    Assert.That(item, Is.Not.Null);
                    if (item.Id == account.Id)
                    {
                        existsInSubscription = true;
                        break;
                    }
                }

                Assert.That(existsInSubscription, Is.True);
            }
            finally
            {
                try
                {
                    if (account != null)
                    {
                        await account.DeleteAsync(WaitUntil.Completed);
                    }
                }
                finally
                {
                    await resourceGroup.DeleteAsync(WaitUntil.Completed);
                }
            }
        }
    }
}
