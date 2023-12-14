// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.Defender.Easm.Tests.Samples
{
    public partial class SavedFiltersSample : SamplesBase<EasmClientTestEnvironment>
    {
        #region Snippet:Sample4_SavedFilters_Monitor
        private void monitor(SavedFilter response)
        {
            // your monitor logic here
        }
        #endregion

        [Test]
        [SyncOnly]
        public void SavedFiltersScenario()
        {
            #region Snippet:Sample4_SavedFilters_Create_Client
            #if SNIPPET
            string endpoint = "https://<region>.easm.defender.microsoft.com";
            EasmClient client = new EasmClient(new System.Uri(endpoint),
                            "<Your_Subscription_Id>",
                            "<Your_Resource_Group_Name>",
                            "<Your_Workspace_Name>",
                            new DefaultAzureCredential());
            #else
            string endpoint = $"https://{TestEnvironment.Region}.easm.defender.microsoft.com";
            EasmClient client = new EasmClient(new System.Uri(endpoint),
                TestEnvironment.SubscriptionId,
                TestEnvironment.ResourceGroupName,
                TestEnvironment.WorkspaceName,
                TestEnvironment.Credential);
            #endif
            #endregion
            #region Snippet:Sample4_SavedFilters_Create_Saved_Filter
            string savedFilterName = "Sample saved filter";
            SavedFilterData savedFilterRequest = new SavedFilterData("IP Address = 1.1.1.1", "Monitored Addresses");
            client.CreateOrReplaceSavedFilter(savedFilterName, savedFilterRequest);
            #endregion
            #region Snippet:Sample4_SavedFilters_Monitor_Assets
            var savedFilterResponse = client.GetSavedFilter(savedFilterName);
            string monitorFilter = savedFilterResponse.Value.Filter;
            #if SNIPPET
            var savedFilterPageResponse = client.GetSavedFilters(monitorFilter);
            #else
            var savedFilterPageResponse = client.GetSavedFilters();
            #endif
            foreach (SavedFilter savedFilter in savedFilterPageResponse)
            {
                monitor(savedFilter);
            }
            #endregion
            #region Snippet:Sample4_SavedFilters_Update_Monitored_Assets
            AssetUpdateData assetUpdateRequest = new AssetUpdateData();
            assetUpdateRequest.State = AssetUpdateState.Confirmed;
            client.UpdateAssets(monitorFilter, assetUpdateRequest);
            #endregion
            #region Snippet:Sample4_SavedFilters_New_Saved_Filter
            SavedFilterData newSavedFilterData = new SavedFilterData("IP Address = 0.0.0.0", "Monitoring Addresses");
            client.CreateOrReplaceSavedFilter(savedFilterName, newSavedFilterData);
            #endregion
        }
    }
}
