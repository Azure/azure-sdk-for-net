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
    internal class SampleSnippets : SamplesBase<EasmClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void CreateDiscoveryGroupSample()
        {
            #region Snippet:SampleSnippets_Create_Discovery_Group
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
            DiscoGroupData request = new DiscoGroupData();
            DiscoSource seed = new DiscoSource();
            seed.Kind = DiscoSourceKind.Host;
            seed.Name = "example.org";
            request.Seeds.Add(seed);
            client.PutDiscoGroup("example group", request);
            client.RunDiscoGroup("example group");
            #endregion
        }

        [Test]
        [SyncOnly]
        public void ViewAssetsSample()
        {
            #region Snippet:SampleSnippets_View_Assets
#if SNIPPET
            string endpoint = "https://<region>.easm.defender.microsoft.com";
            EasmClient client = new EasmClient(new System.Uri(endpoint),
                            TestEnvironment.SubscriptionId,
                            TestEnvironment.ResourceGroupName,
                            TestEnvironment.WorkspaceName,
                            TestEnvironment.Credential);
#else
            string endpoint = $"https://{TestEnvironment.Region}.easm.defender.microsoft.com";
            EasmClient client = new EasmClient(new System.Uri(endpoint),
                            TestEnvironment.SubscriptionId,
                            TestEnvironment.ResourceGroupName,
                            TestEnvironment.WorkspaceName,
                            TestEnvironment.Credential);
#endif
            Response<AssetPageResult> response = client.GetAssetResources();
            foreach (AssetResource asset in response.Value.Value)
            {
                Console.WriteLine($"{asset.Kind}: {asset.Name}");
            }
            #endregion
        }
    }
}
