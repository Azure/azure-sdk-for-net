// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.Defender.Easm.Tests.Samples
{
    public partial class AssetResourcesSample : SamplesBase<EasmClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void AssetResourcesScenario()
        {
            #region Snippet:Sample1_AssetResources_Create_Client
            #if SNIPPET
            string endpoint = "https://<region>.easm.defender.microsoft.com/subscriptions/<Your_Subscription_Id>/resourceGroups/<Your_Resource_Group_Name>/workspaces/<Your_Workspace_Name>";
            EasmClient client = new EasmClient(new System.Uri(endpoint),
                            new DefaultAzureCredential());
            #else
            string endpoint = $"https://{TestEnvironment.Region}.easm.defender.microsoft.com/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{TestEnvironment.ResourceGroupName}/workspaces/{TestEnvironment.WorkspaceName}";
            EasmClient client = new EasmClient(new System.Uri(endpoint),
                TestEnvironment.Credential);
            #endif
            #endregion

            #region Snippet:Sample1_AssetResources_Get_Assets
            var response = client.GetAssetResources();
            int index = 0;
            foreach (AssetResource asset in response)
            {
                Console.WriteLine($"Asset Name: {asset.Name}, Kind: {asset.GetType()}");
                if (index++ > 5)
                {
                    break;
                }
            }
            #endregion
        }
    }
}
