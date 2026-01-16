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
        Assert.That(resource, Is.Not.Null);
        Assert.That(new[] { DurableTaskProvisioningState.Provisioning, DurableTaskProvisioningState.Accepted }, Does.Contain(resource.Data.Properties.ProvisioningState));

        // Keep track of the resource id to delete it later
        string resourceId = resource.Id;

        resource = await longRunningOperation.WaitForCompletionAsync();
        Assert.That(resource.Data.Name, Is.EqualTo(resourceName));
        Assert.That(resource.Data.Properties.Sku.Name, Is.EqualTo(DurableTaskSchedulerSkuName.Dedicated));
        Assert.That(resource.Data.Properties.Sku.RedundancyState, Is.EqualTo(DurableTaskResourceRedundancyState.None));
        Assert.That(resource.Data.Properties.IPAllowlist as IList, Does.Contain(IpRange1));
        Assert.That(resource.Data.Properties.IPAllowlist as IList, Does.Contain(IpRange2));
        Assert.That(resource.Data.Properties.IPAllowlist as IList, Does.Contain(IpRange3));
        Assert.That(resource.Data.Properties.ProvisioningState, Is.EqualTo(DurableTaskProvisioningState.Succeeded));

        // Get Scheduler
        resource = await rg.GetDurableTaskSchedulerAsync(resourceName);
        Assert.That(resource, Is.Not.Null);
        Assert.That(resource.Data.Name, Is.EqualTo(resourceName));
        Assert.That(resource.Data.Properties.Sku.Name, Is.EqualTo(DurableTaskSchedulerSkuName.Dedicated));
        Assert.That(resource.Data.Properties.Sku.RedundancyState, Is.EqualTo(DurableTaskResourceRedundancyState.None));
        Assert.That(resource.Data.Properties.IPAllowlist as IList, Does.Contain(IpRange1));
        Assert.That(resource.Data.Properties.IPAllowlist as IList, Does.Contain(IpRange2));
        Assert.That(resource.Data.Properties.IPAllowlist as IList, Does.Contain(IpRange3));
        Assert.That(resource.Data.Properties.ProvisioningState, Is.EqualTo(DurableTaskProvisioningState.Succeeded));

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
        Assert.That(resource.Data.Properties.ProvisioningState, Is.EqualTo(DurableTaskProvisioningState.Updating));

        // Wait for the update to complete
        resource = await longRunningOperation.WaitForCompletionAsync();
        Assert.That(resource.Data.Name, Is.EqualTo(resourceName));
        Assert.That(resource.Data.Properties.Sku.Name, Is.EqualTo(DurableTaskSchedulerSkuName.Dedicated));
        Assert.That(resource.Data.Properties.Sku.RedundancyState, Is.EqualTo(DurableTaskResourceRedundancyState.None));
        Assert.That(resource.Data.Properties.IPAllowlist as IList, Does.Contain(UpdatedIpRange1));
        Assert.That(resource.Data.Properties.IPAllowlist as IList, Does.Contain(UpdatedIpRange2));
        Assert.That(resource.Data.Properties.IPAllowlist as IList, Does.Contain(IpRange3));
        Assert.That(resource.Data.Tags.Count, Is.EqualTo(2));
        Assert.That(resource.Data.Tags.Keys, Does.Contain(TagKeyOrg));
        Assert.That(resource.Data.Tags.Keys, Does.Contain(TagKeyEnv));
        Assert.That(resource.Data.Tags[TagKeyOrg], Is.EqualTo(TagValueOrg));
        Assert.That(resource.Data.Tags[TagKeyEnv], Is.EqualTo(TagValueEnv));
        Assert.That(resource.Data.Properties.ProvisioningState, Is.EqualTo(DurableTaskProvisioningState.Succeeded));

        // List all schedulers and verify the updated scheduler is present
        List<DurableTaskSchedulerResource> schedulers = await rg.GetDurableTaskSchedulers().GetAllAsync().ToEnumerableAsync();
        // Look for the scheduler with the ARM resource ID matching our resource
        resource = schedulers.FirstOrDefault(s => s.Data.Id == resourceId);
        Assert.That(resource, Is.Not.Null);
        Assert.That(resource.Data.Name, Is.EqualTo(resourceName));
        Assert.That(resource.Data.Properties.Sku.Name, Is.EqualTo(DurableTaskSchedulerSkuName.Dedicated));
        Assert.That(resource.Data.Properties.Sku.RedundancyState, Is.EqualTo(DurableTaskResourceRedundancyState.None));
        Assert.That(resource.Data.Properties.IPAllowlist as IList, Does.Contain(UpdatedIpRange1));
        Assert.That(resource.Data.Properties.IPAllowlist as IList, Does.Contain(UpdatedIpRange2));
        Assert.That(resource.Data.Properties.IPAllowlist as IList, Does.Contain(IpRange3));
        Assert.That(resource.Data.Tags.Count, Is.EqualTo(2));
        Assert.That(resource.Data.Tags.Keys, Does.Contain(TagKeyOrg));
        Assert.That(resource.Data.Tags.Keys, Does.Contain(TagKeyEnv));
        Assert.That(resource.Data.Tags[TagKeyOrg], Is.EqualTo(TagValueOrg));
        Assert.That(resource.Data.Tags[TagKeyEnv], Is.EqualTo(TagValueEnv));
        Assert.That(resource.Data.Properties.ProvisioningState, Is.EqualTo(DurableTaskProvisioningState.Succeeded));

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

        Assert.That(resource.Data.Name, Is.EqualTo(resourceName));
        Assert.That(resource.Data.Properties.Sku.Name, Is.EqualTo(DurableTaskSchedulerSkuName.Dedicated));
        Assert.That(resource.Data.Properties.Sku.RedundancyState, Is.EqualTo(DurableTaskResourceRedundancyState.None));
        Assert.That(resource.Data.Properties.IPAllowlist.Count, Is.EqualTo(1));
        Assert.That(resource.Data.Properties.IPAllowlist as IList, Does.Contain(PatchIpRange));
        Assert.That(resource.Data.Tags.Count, Is.EqualTo(1));
        Assert.That(resource.Data.Tags.Keys, Does.Contain(TagKeyEnv));
        Assert.That(resource.Data.Tags[TagKeyEnv], Is.EqualTo(TagValueEnv));
        Assert.That(resource.Data.Properties.ProvisioningState, Is.EqualTo(DurableTaskProvisioningState.Succeeded));

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
