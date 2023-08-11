// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Analytics.Defender.Easm.Models;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.Defender.Easm.Tests.Samples
{
    public partial class EasmSamples: SamplesBase<EasmClientTestEnvironment>
    {
        /* please refer to https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/tests/Samples/Sample1.HelloWorldAsync.cs to write samples. */
        [Test]
        [AsyncOnly]
        public async Task ScenarioAsync()
        {
            string endpoint = $"https://{TestEnvironment.Region}.easm.defender.microsoft.com";
            EasmClient client = new EasmClient(new System.Uri(endpoint),
                            TestEnvironment.SubscriptionId,
                            TestEnvironment.ResourceGroupName,
                            TestEnvironment.WorkspaceName,
                            TestEnvironment.Credential);

            Response<AssetPageResult> response = await client.GetAssetResourcesAsync();
            foreach (AssetResource asset in response.Value.Value)
            {
                Console.WriteLine($"{asset.Kind}: {asset.Name}");
            }
        }
    }
}
