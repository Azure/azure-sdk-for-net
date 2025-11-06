// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DurableTask.Models;
using Azure.ResourceManager.Resources;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace Azure.ResourceManager.DurableTask.Tests.Scenario;

public class SchedulerTests : DurableTaskSchedulerManagementTestBase
{
    // IP address allowlist test constants
    private const string IpRange1 = "12.14.16.18/20";
    private const string IpRange2 = "11.13.15.17/20";
    private const string IpRange3 = "123.124.125.126";
    private const string UpdatedIpRange1 = "12.14.16.18/22";
    private const string UpdatedIpRange2 = "11.13.15.17/22";
    private const string PatchIpRange = "21.22.23.24/25";

    // Tags key value test constants
    private const string TagKeyOrg = "org";
    private const string TagValueOrg = "Contoso";
    private const string TagKeyEnv = "env";
    private const string TagValueEnv = "test";

    public SchedulerTests(bool isAsync) : base(isAsync)
    {
    }

    [TestCase]
    [RecordedTest]
    public async Task CreateUpdateGetPatchDeleteTest()
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
                ipAllowlist: [IpRange1, IpRange2, IpRange3],
                sku: new DurableTaskSchedulerSku() { Name = DurableTaskSchedulerSkuName.Dedicated, Capacity = 1 }
            )
        };

        ArmOperation<DurableTaskSchedulerResource> longRunningOperation =
            await rg.GetDurableTaskSchedulers().CreateOrUpdateAsync(WaitUntil.Started, resourceName, createSchedulerData);

        // While provisioning is in progress the resource is in first in accepted, then provisioning state
        DurableTaskSchedulerResource resource = await rg.GetDurableTaskSchedulerAsync(resourceName);
        Assert.NotNull(resource);
        Assert.Contains(resource.Data.Properties.ProvisioningState, new[] { DurableTaskProvisioningState.Provisioning, DurableTaskProvisioningState.Accepted });

        // Keep track of the resource id to delete it later
        string resourceId = resource.Id;

        resource = await longRunningOperation.WaitForCompletionAsync();
        Assert.AreEqual(resourceName, resource.Data.Name);
        Assert.AreEqual(DurableTaskSchedulerSkuName.Dedicated, resource.Data.Properties.Sku.Name);
        Assert.AreEqual(DurableTaskResourceRedundancyState.None, resource.Data.Properties.Sku.RedundancyState);
        Assert.Contains(IpRange1, resource.Data.Properties.IPAllowlist as IList);
        Assert.Contains(IpRange2, resource.Data.Properties.IPAllowlist as IList);
        Assert.Contains(IpRange3, resource.Data.Properties.IPAllowlist as IList);
        Assert.AreEqual(DurableTaskProvisioningState.Succeeded, resource.Data.Properties.ProvisioningState);

        // Get Scheduler
        resource = await rg.GetDurableTaskSchedulerAsync(resourceName);
        Assert.NotNull(resource);
        Assert.AreEqual(resourceName, resource.Data.Name);
        Assert.AreEqual(DurableTaskSchedulerSkuName.Dedicated, resource.Data.Properties.Sku.Name);
        Assert.AreEqual(DurableTaskResourceRedundancyState.None, resource.Data.Properties.Sku.RedundancyState);
        Assert.Contains(IpRange1, resource.Data.Properties.IPAllowlist as IList);
        Assert.Contains(IpRange2, resource.Data.Properties.IPAllowlist as IList);
        Assert.Contains(IpRange3, resource.Data.Properties.IPAllowlist as IList);
        Assert.AreEqual(DurableTaskProvisioningState.Succeeded, resource.Data.Properties.ProvisioningState);

        DurableTaskSchedulerData updateSchedulerData = new(AzureLocation.NorthCentralUS)
        {
            Properties = new DurableTaskSchedulerProperties(
                ipAllowlist: [UpdatedIpRange1, UpdatedIpRange2, IpRange3],
                sku: new DurableTaskSchedulerSku() { Name = DurableTaskSchedulerSkuName.Dedicated, Capacity = 1 }
            ),
            Tags = { { TagKeyOrg, TagValueOrg }, { TagKeyEnv, TagValueEnv } }
        };

        longRunningOperation =
            await rg.GetDurableTaskSchedulers().CreateOrUpdateAsync(WaitUntil.Started, resourceName, updateSchedulerData);
        // While the update is in progress the resource is in updating state
        resource = await rg.GetDurableTaskSchedulerAsync(resourceName);
        Assert.AreEqual(DurableTaskProvisioningState.Updating, resource.Data.Properties.ProvisioningState);

        // Wait for the update to complete
        resource = await longRunningOperation.WaitForCompletionAsync();
        Assert.AreEqual(resourceName, resource.Data.Name);
        Assert.AreEqual(DurableTaskSchedulerSkuName.Dedicated, resource.Data.Properties.Sku.Name);
        Assert.AreEqual(DurableTaskResourceRedundancyState.None, resource.Data.Properties.Sku.RedundancyState);
        Assert.Contains(UpdatedIpRange1, resource.Data.Properties.IPAllowlist as IList);
        Assert.Contains(UpdatedIpRange2, resource.Data.Properties.IPAllowlist as IList);
        Assert.Contains(IpRange3, resource.Data.Properties.IPAllowlist as IList);
        Assert.AreEqual(2, resource.Data.Tags.Count);
        Assert.That(resource.Data.Tags.Keys, Does.Contain(TagKeyOrg));
        Assert.That(resource.Data.Tags.Keys, Does.Contain(TagKeyEnv));
        Assert.AreEqual(TagValueOrg, resource.Data.Tags[TagKeyOrg]);
        Assert.AreEqual(TagValueEnv, resource.Data.Tags[TagKeyEnv]);
        Assert.AreEqual(DurableTaskProvisioningState.Succeeded, resource.Data.Properties.ProvisioningState);

        // List all schedulers and verify the updated scheduler is present
        List<DurableTaskSchedulerResource> schedulers = await rg.GetDurableTaskSchedulers().GetAllAsync().ToEnumerableAsync();
        // Look for the scheduler with the ARM resource ID matching our resource
        resource = schedulers.FirstOrDefault(s => s.Data.Id == resourceId);
        Assert.NotNull(resource);
        Assert.AreEqual(resourceName, resource.Data.Name);
        Assert.AreEqual(DurableTaskSchedulerSkuName.Dedicated, resource.Data.Properties.Sku.Name);
        Assert.AreEqual(DurableTaskResourceRedundancyState.None, resource.Data.Properties.Sku.RedundancyState);
        Assert.Contains(UpdatedIpRange1, resource.Data.Properties.IPAllowlist as IList);
        Assert.Contains(UpdatedIpRange2, resource.Data.Properties.IPAllowlist as IList);
        Assert.Contains(IpRange3, resource.Data.Properties.IPAllowlist as IList);
        Assert.AreEqual(2, resource.Data.Tags.Count);
        Assert.That(resource.Data.Tags.Keys, Does.Contain(TagKeyOrg));
        Assert.That(resource.Data.Tags.Keys, Does.Contain(TagKeyEnv));
        Assert.AreEqual(TagValueOrg, resource.Data.Tags[TagKeyOrg]);
        Assert.AreEqual(TagValueEnv, resource.Data.Tags[TagKeyEnv]);
        Assert.AreEqual(DurableTaskProvisioningState.Succeeded, resource.Data.Properties.ProvisioningState);

        // Update select Scheduler properties (Patch)
        DurableTaskSchedulerPatch patchSchedulerData = new()
        {
            Properties = new DurableTaskSchedulerPatchProperties
            {
                IPAllowlist = { PatchIpRange },
                Sku = new DurableTaskSchedulerSkuUpdate
                {
                    Capacity = 1
                }
            },
            Tags = { { TagKeyEnv, TagValueEnv } }
        };

        // While the update is in progress the resource is in updating state, but we will wait for completion now
        longRunningOperation = await resource.UpdateAsync(waitUntil: WaitUntil.Completed, patchSchedulerData);
        resource = longRunningOperation.Value;

        Assert.AreEqual(resourceName, resource.Data.Name);
        Assert.AreEqual(DurableTaskSchedulerSkuName.Dedicated, resource.Data.Properties.Sku.Name);
        Assert.AreEqual(DurableTaskResourceRedundancyState.None, resource.Data.Properties.Sku.RedundancyState);
        Assert.AreEqual(1, resource.Data.Properties.IPAllowlist.Count);
        Assert.Contains(PatchIpRange, resource.Data.Properties.IPAllowlist as IList);
        Assert.AreEqual(1, resource.Data.Tags.Count);
        Assert.That(resource.Data.Tags.Keys, Does.Contain(TagKeyEnv));
        Assert.AreEqual(TagValueEnv, resource.Data.Tags[TagKeyEnv]);
        Assert.AreEqual(DurableTaskProvisioningState.Succeeded, resource.Data.Properties.ProvisioningState);

        // Delete Scheduler
        await resource.DeleteAsync(WaitUntil.Completed);

        // Verify the scheduler is deleted
        try
        {
            await rg.GetDurableTaskSchedulerAsync(resourceName);
        }
        catch (RequestFailedException ex) when (ex.Status == StatusCodes.Status404NotFound)
        {
            // Expected exception
            Assert.Pass("Scheduler deleted successfully");
        }
        catch (Exception ex)
        {
            Assert.Fail($"Unexpected exception: {ex}");
        }
    }
}
