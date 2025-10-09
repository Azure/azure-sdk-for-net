// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DurableTask.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.DurableTask.Tests.Scenario
{
    public class TaskHubTests : DurableTaskSchedulerManagementTestBase
    {
        public TaskHubTests(bool isAsync) : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateDeleteTaskHubTest()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg", AzureLocation.NorthCentralUS);
            await TestContext.Error.WriteLineAsync(
                $"subscription: {subscription.Data.SubscriptionId}, resource group {rg.Data.Name}");
            string resourceName = Recording.GenerateAssetName("resource");

            // Create Scheduler
            DurableTaskSchedulerData createSchedulerData = new(AzureLocation.NorthCentralUS)
            {
                Properties = new DurableTaskSchedulerProperties(
                    ipAllowlist: ["0.0.0.0/0"], // all IPs allowed to access the endpoint
                    sku: new DurableTaskSchedulerSku() { Name = SchedulerSkuName.Dedicated, Capacity = 1 }
                )
            };
            ArmOperation<DurableTaskSchedulerResource> longRunningOperation =
                await rg.GetDurableTaskSchedulers().CreateOrUpdateAsync(WaitUntil.Completed, resourceName, createSchedulerData);
            DurableTaskSchedulerResource scheduler = longRunningOperation.Value;
            DurableTaskHubCollection collection = scheduler.GetDurableTaskHubs();

            await collection.CreateOrUpdateAsync(WaitUntil.Completed, "MyHub", new DurableTaskHubData());

            DurableTaskHubResource hub = await scheduler.GetDurableTaskHubAsync("MyHub");
            Assert.True(hub.HasData);
            Assert.True(hub.Data.Properties.DashboardUri.Host.ToLower().Contains("durabletask.io"));
            Assert.Equals("MyHub", hub.Data.Name);

            await hub.DeleteAsync(WaitUntil.Completed);

            await hub.GetAsync().ContinueWith(t =>
            {
                if (t.IsFaulted)
                {
                    var ex = t.Exception.Flatten().InnerExceptions[0] as RequestFailedException;
                    Assert.AreEqual(404, ex.Status);
                }
                else
                {
                    Assert.Fail("The task hub was not deleted.");
                }
            });
        }
    }
}
