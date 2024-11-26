// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DurableTask.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.DurableTask.Tests.Scenario;

public class SchedulerTests : DurableTaskSchedulerManagementTestBase
{
    public SchedulerTests(bool isAsync) : base(isAsync)
    {
    }

    [TestCase]
    [RecordedTest]
    public async Task CreateUpdateGetPatchDeleteTest()
    {
        SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
        ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg", AzureLocation.NorthCentralUS);
        string resourceName = Recording.GenerateAssetName("resource");

        // Create Scheduler
        SchedulerData createSchedulerData = new SchedulerData
        {
            Properties = new SchedulerProperties
            {
                Sku = new SchedulerSku
                {
                    Name = "Dedicated",
                    Capacity = 1
                },
                IPAllowlist = { "12.14.16.18/20", "11.13.15.17/20", "123.124.125.126" },
            },
            Location = AzureLocation.NorthCentralUS
        };

        ArmOperation<SchedulerResource> longRunningOperation =
            await rg.GetSchedulers().CreateOrUpdateAsync(WaitUntil.Started, resourceName, createSchedulerData);

        // while provisioning is in progress the resource is in provisioning state
        SchedulerResource resource = await rg.GetSchedulerAsync(resourceName);
        Assert.NotNull(resource);
        Assert.AreEqual(ProvisioningState.Provisioning, resource.Data.Properties.ProvisioningState);

        // we keep track of the resource id to delete it later
        string resourceId = resource.Id;

        resource = await longRunningOperation.WaitForCompletionAsync();
        Assert.AreEqual(resourceName, resource.Data.Name);
        Assert.AreEqual("Dedicated", resource.Data.Properties.Sku.Name);
        Assert.AreEqual(RedundancyState.Zone, resource.Data.Properties.Sku.RedundancyState);
        Assert.Contains("12.14.16.18/20", resource.Data.Properties.IPAllowlist as IList);
        Assert.Contains("11.13.15.17/20", resource.Data.Properties.IPAllowlist as IList);
        Assert.Contains("123.124.125.126", resource.Data.Properties.IPAllowlist as IList);
        Assert.AreEqual(ProvisioningState.Succeeded, resource.Data.Properties.ProvisioningState);

        // Get Scheduler
        resource = await rg.GetSchedulerAsync(resourceName);
        Assert.NotNull(resource);
        Assert.AreEqual(resourceName, resource.Data.Name);
        Assert.AreEqual("Dedicated", resource.Data.Properties.Sku.Name);
        Assert.AreEqual(RedundancyState.Zone, resource.Data.Properties.Sku.RedundancyState);
        Assert.Contains("12.14.16.18/20", resource.Data.Properties.IPAllowlist as IList);
        Assert.Contains("11.13.15.17/20", resource.Data.Properties.IPAllowlist as IList);
        Assert.Contains("123.124.125.126", resource.Data.Properties.IPAllowlist as IList);
        Assert.AreEqual(ProvisioningState.Succeeded, resource.Data.Properties.ProvisioningState);

        SchedulerData updateSchedulerData = new SchedulerData
        {
            Properties = new SchedulerProperties
            {
                Sku = new SchedulerSku
                {
                    Name = "Dedicated",
                    Capacity = 1
                },
                IPAllowlist = { "12.14.16.18/22", "11.13.15.17/22", "123.124.125.126" },
            },
            Location = AzureLocation.NorthCentralUS
        };

        longRunningOperation = await rg.GetSchedulers().CreateOrUpdateAsync(WaitUntil.Started, resourceName, updateSchedulerData);
        // while the update is in progress the resource is in updating state
        resource = await rg.GetSchedulerAsync(resourceName);
        Assert.AreEqual(ProvisioningState.Updating, resource.Data.Properties.ProvisioningState);

        // wait for the update to complete
        resource = await longRunningOperation.WaitForCompletionAsync();
        Assert.AreEqual(resourceName, resource.Data.Name);
        Assert.AreEqual("Dedicated", resource.Data.Properties.Sku.Name);
        Assert.AreEqual(RedundancyState.Zone, resource.Data.Properties.Sku.RedundancyState);
        Assert.Contains("12.14.16.18/22", resource.Data.Properties.IPAllowlist as IList);
        Assert.Contains("11.13.15.17/22", resource.Data.Properties.IPAllowlist as IList);
        Assert.Contains("123.124.125.126", resource.Data.Properties.IPAllowlist as IList);
        Assert.AreEqual(ProvisioningState.Succeeded, resource.Data.Properties.ProvisioningState);

        // List all schedulers and verify the updated scheduler is present
        List<SchedulerResource> schedulers = await rg.GetSchedulers().GetAllAsync().ToEnumerableAsync();
        // look for the scheduler with the ARM resource ID matching our resource
        resource =  schedulers.FirstOrDefault(s => s.Data.Id == resourceId);
        Assert.NotNull(resource);
        Assert.AreEqual(resourceName, resource.Data.Name);
        Assert.AreEqual("Dedicated", resource.Data.Properties.Sku.Name);
        Assert.AreEqual(RedundancyState.Zone, resource.Data.Properties.Sku.RedundancyState);
        Assert.Contains("12.14.16.18/22", resource.Data.Properties.IPAllowlist as IList);
        Assert.Contains("11.13.15.17/22", resource.Data.Properties.IPAllowlist as IList);
        Assert.Contains("123.124.125.126", resource.Data.Properties.IPAllowlist as IList);
        Assert.AreEqual(ProvisioningState.Succeeded, resource.Data.Properties.ProvisioningState);

        // Update select Scheduler properties (Patch)

        SchedulerData patchSchedulerData = new SchedulerData
        {
            Properties = new SchedulerProperties
            {
                IPAllowlist = { "21.22.23.24/25" }
            },
        };

        longRunningOperation = await resource.UpdateAsync(waitUntil: WaitUntil.Started, patchSchedulerData);
        // while the update is in progress the resource is in updating state
        Assert.AreEqual(ProvisioningState.Updating, resource.Data.Properties.ProvisioningState);

        // wait for the update to complete
        resource = await longRunningOperation.WaitForCompletionAsync();
        Assert.AreEqual(resourceName, resource.Data.Name);
        Assert.AreEqual("Dedicated", resource.Data.Properties.Sku.Name);
        Assert.AreEqual(RedundancyState.Zone, resource.Data.Properties.Sku.RedundancyState);
        Assert.Equals(1, resource.Data.Properties.IPAllowlist.Count);
        Assert.Contains("21.22.23.24/25", resource.Data.Properties.IPAllowlist as IList);
        Assert.AreEqual(ProvisioningState.Succeeded, resource.Data.Properties.ProvisioningState);

        // Delete Scheduler
        var longRunningDeleteOperation = await resource.DeleteAsync(WaitUntil.Started);

        // while delete is in progress the resource is in deleting state
        SchedulerResource toBeDeleted = await resource.GetAsync();
        Assert.NotNull(toBeDeleted);
        Assert.Equals(ProvisioningState.Deleting, toBeDeleted.Data.Properties.ProvisioningState ?? "Unknown");

        var done = await longRunningDeleteOperation.WaitForCompletionResponseAsync();
        Assert.True(done.Status is 200 or 204);

        // verify the scheduler is deleted
        Response<SchedulerResource> notFoundResource = await rg.GetSchedulerAsync(resourceName);
        Assert.False(notFoundResource.HasValue);
        Assert.Equals(404, notFoundResource.GetRawResponse().Status);
    }
}