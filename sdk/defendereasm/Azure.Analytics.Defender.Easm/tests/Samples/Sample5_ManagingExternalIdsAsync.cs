// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Analytics.Defender.Easm.Models;
using Azure.Core.TestFramework;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Azure.Analytics.Defender.Easm.Tests.Samples
{
    public partial class ManagingExternalIdsSample : SamplesBase<EasmClientTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task ManagingExternalIdsScenarioAsync()
        {
            string endpoint = $"https://{TestEnvironment.Region}.easm.defender.microsoft.com";
            EasmClient client = new EasmClient(new System.Uri(endpoint),
                            TestEnvironment.SubscriptionId,
                            TestEnvironment.ResourceGroupName,
                            TestEnvironment.WorkspaceName,
                            TestEnvironment.Credential);

            string mappingJson = TestEnvironment.Mapping;
            List<Dictionary<string, string>> mapping = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(mappingJson);

            List<String> updateIds = new List<String>();
            List<String> externalIds = new List<String>();
            mapping.ForEach(async asset =>
            {
                externalIds.Add(asset["external_id"]);
                AssetUpdateData assetUpdateRequest = new AssetUpdateData();
                assetUpdateRequest.ExternalId = asset["external_id"];
                string filter = $"kind = {asset["kind"]} AND name = {asset["name"]}";
                Response<TaskResource> taskResponse = await client.UpdateAssetsAsync(filter, assetUpdateRequest);
                updateIds.Add(taskResponse.Value.Id);
            });

            updateIds.ForEach(async id =>
            {
                Response<TaskResource> taskResponse = await client.GetTaskAsync(id);
                Console.WriteLine($"{taskResponse.Value.Id}: {taskResponse.Value.State}");
            });

            string assetFilter = $"External ID in (\"{string.Join("\", \"", externalIds)}\")";

            Response<AssetPageResult> assetPageResponse = await client.GetAssetResourcesAsync(assetFilter);
            foreach (AssetResource assetResponse in assetPageResponse.Value.Value)
            {
                Console.WriteLine($"{assetResponse.ExternalId}, {assetResponse.Name}");
            }
        }
    }
}
