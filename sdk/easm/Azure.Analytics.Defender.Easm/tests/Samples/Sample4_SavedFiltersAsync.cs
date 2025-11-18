// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.Defender.Easm.Tests.Samples
{
    public partial class SavedFiltersSample : SamplesBase<EasmClientTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async System.Threading.Tasks.Task SavedFiltersScenarioAsync()
        {
            string endpoint = $"https://{TestEnvironment.Region}.easm.defender.microsoft.com/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{TestEnvironment.ResourceGroupName}/workspaces/{TestEnvironment.WorkspaceName}";
            EasmClient client = new EasmClient(new System.Uri(endpoint),
                TestEnvironment.Credential);

            string savedFilterName = "Sample saved filter";
            SavedFilterPayload savedFilterRequest = new SavedFilterPayload("IP Address = 1.1.1.1", "Monitored Addresses");
            await client.CreateOrReplaceSavedFilterAsync(savedFilterName, savedFilterRequest);

            Response<SavedFilter> savedFilterResponse = await client.GetSavedFilterAsync(savedFilterName);
            string monitorFilter = savedFilterResponse.Value.Filter;
            var savedFilterPageResponse = client.GetSavedFiltersAsync();

            await foreach (SavedFilter savedFilter in savedFilterPageResponse)
            {
                monitor(savedFilter);
            }
            AssetUpdatePayload assetUpdateRequest = new AssetUpdatePayload();
            assetUpdateRequest.State = AssetUpdateState.Confirmed;
            await client.UpdateAssetsAsync(monitorFilter, assetUpdateRequest);
            SavedFilterPayload newSavedFilterPayload = new SavedFilterPayload("IP Address = 0.0.0.0", "Monitoring Addresses");
            await client.CreateOrReplaceSavedFilterAsync(savedFilterName, newSavedFilterPayload);
        }
    }
}
