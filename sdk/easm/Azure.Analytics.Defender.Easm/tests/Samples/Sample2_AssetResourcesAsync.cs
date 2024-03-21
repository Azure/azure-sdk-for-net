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
        [AsyncOnly]
        public async System.Threading.Tasks.Task AssetResourcesScenarioAsync()
        {
            string endpoint = $"https://{TestEnvironment.Region}.easm.defender.microsoft.com/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{TestEnvironment.ResourceGroupName}/workspaces/{TestEnvironment.WorkspaceName}";
            EasmClient client = new EasmClient(new System.Uri(endpoint),
                TestEnvironment.Credential);

            var response = client.GetAssetResourcesAsync();
            int index = 0;
            await foreach (AssetResource asset in response)
            {
                Console.WriteLine($"{asset.Name} : {asset.GetType()}");
                if (index++ > 5)
                {
                    break;
                }
            }
        }
    }
}
