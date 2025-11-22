// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DurableTask.Models;
using Azure.ResourceManager.Resources;
using Microsoft.AspNetCore.Http;
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
        public async Task CreateGetListDeleteTaskHubTest()
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
                    sku: new DurableTaskSchedulerSku() { Name = DurableTaskSchedulerSkuName.Dedicated, Capacity = 1 }
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
            Assert.AreEqual("MyHub", hub.Data.Name);

            // The list endpoint should also return the newly created hub
            DurableTaskHubResource listHub = await collection.GetAllAsync().FirstOrDefaultAsync(t => t.Data.Name == "MyHub");
            Assert.NotNull(listHub);
            Assert.AreEqual(hub.Data.Name, listHub.Data.Name);

            await hub.DeleteAsync(WaitUntil.Completed);

            try
            {
                await scheduler.GetDurableTaskHubAsync("MyHub");
            }
            catch (RequestFailedException ex) when (ex.Status == StatusCodes.Status404NotFound)
            {
                // Expected exception
                Assert.Pass("TaskHub deleted successfully");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected exception: {ex}");
            }
        }
    }
}
