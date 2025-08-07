// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.TestFramework;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Azure.Analytics.Defender.Easm.Tests.Samples
{
    public partial class ManagingExternalIdsSample : SamplesBase<EasmClientTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async System.Threading.Tasks.Task ManagingExternalIdsScenarioAsync()
        {
            string endpoint = $"https://{TestEnvironment.Region}.easm.defender.microsoft.com/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{TestEnvironment.ResourceGroupName}/workspaces/{TestEnvironment.WorkspaceName}";
            EasmClient client = new EasmClient(new System.Uri(endpoint),
                TestEnvironment.Credential);

            string mappingJson = TestEnvironment.Mapping;
            List<Dictionary<string, string>> mapping = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(mappingJson);

            List<String> updateIds = new List<String>();
            List<String> externalIds = new List<String>();
            mapping.ForEach(async asset =>
            {
                externalIds.Add(asset["external_id"]);
                AssetUpdatePayload assetUpdateRequest = new AssetUpdatePayload();
                assetUpdateRequest.ExternalId = asset["external_id"];
                string filter = $"kind = {asset["kind"]} AND name = {asset["name"]}";
                var taskResponse = await client.UpdateAssetsAsync(filter, assetUpdateRequest);
                updateIds.Add(taskResponse.Value.Id);
            });
            updateIds.ForEach(async id =>
            {
                var taskResponse = await client.GetTaskAsync(id);
                Console.WriteLine($"{taskResponse.Value.Id}: {taskResponse.Value.State}");
            });
            string assetFilter = $"External ID in (\"{string.Join("\", \"", externalIds)}\")";

            var assetPageResponse = client.GetAssetResourcesAsync(assetFilter);
            await foreach (AssetResource assetResponse in assetPageResponse)
            {
                Console.WriteLine($"{assetResponse.ExternalId}, {assetResponse.Name}");
            }
        }
    }
}
