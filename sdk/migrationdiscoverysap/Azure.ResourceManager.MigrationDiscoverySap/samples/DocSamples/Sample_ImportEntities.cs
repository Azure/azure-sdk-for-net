// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Identity;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using System.Text.Json;

namespace Azure.ResourceManager.MigrationDiscoverySap.Samples
{
    public class Sample_ImportEntities
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async void GetIntermediateStatusOfImportEntitiesMethodion()
        {
            #region Snippet:Readme_GetIntermediateStatusOfImportEntitiesMethod
            ArmClient client = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
            ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();

            string resourceGroupName = "myRgName";
            ResourceGroupResource rg = await resourceGroups.GetAsync(resourceGroupName);
            // Create Resource group, create a discovery site.
            // Get Discovery site resource with the created name.
            string discoverySiteName = "siteName";
            SapDiscoverySiteResource sapDiscoverySiteResource = await rg.GetSapDiscoverySiteAsync(discoverySiteName);
            // Post import entities operation.
            ArmOperation<OperationStatusResult> importEntitiesOp = await sapDiscoverySiteResource.ImportEntitiesAsync(WaitUntil.Completed);
            // Get operation status.
            Response<GenericResource> operationStatus = await client.GetGenericResources().GetAsync(ResourceIdentifier.Parse(importEntitiesOp.Value.Id));
            JsonDocument doc = JsonDocument.Parse(operationStatus?.GetRawResponse()?.Content?.ToString());
            JsonElement root = doc.RootElement;
            JsonElement p = root.GetProperty("properties");
            string status = p.GetProperty("status").GetString();
            #endregion Snippet:Readme_GetIntermediateStatusOfImportEntitiesMethod
        }
    }
}
