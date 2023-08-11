// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Analytics.Defender.Easm.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.Defender.Easm.Tests.Samples
{
    public partial class SavedFiltersSample : SamplesBase<EasmClientTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task SavedFiltersScenarioAsync()
        {
            string endpoint = $"https://{TestEnvironment.Region}.easm.defender.microsoft.com";
            EasmClient client = new EasmClient(new System.Uri(endpoint),
                            TestEnvironment.SubscriptionId,
                            TestEnvironment.ResourceGroupName,
                            TestEnvironment.WorkspaceName,
                            TestEnvironment.Credential);

            string savedFilterName = "Sample saved filter";
            SavedFilterData savedFilterRequest = new SavedFilterData("IP Address = 1.1.1.1", "Monitored Addresses");

            await client.PutSavedFilterAsync(savedFilterName, savedFilterRequest);

            Response<SavedFilter> savedFilterResponse = await client.GetSavedFilterAsync(savedFilterName);
            string monitorFilter = savedFilterResponse.Value.Filter;

            // Response<SavedFilterPageResponse> savedFilterPageResponse = client.SavedFiltersList(monitorFilter);
            Response<SavedFilterPageResult> savedFilterPageResponse = await client.GetSavedFiltersAsync();

            foreach (SavedFilter savedFilter in savedFilterPageResponse.Value.Value)
            {
                monitor(savedFilter);
            }

            AssetUpdateData assetUpdateRequest = new AssetUpdateData();
            assetUpdateRequest.State = AssetUpdateState.Confirmed;
            await client.UpdateAssetsAsync(monitorFilter, assetUpdateRequest);

            SavedFilterData newSavedFilterData = new SavedFilterData("IP Address = 0.0.0.0", "Monitoring Addresses");
            await client.PutSavedFilterAsync(savedFilterName, newSavedFilterData);
        }
    }
}
