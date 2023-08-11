// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Analytics.Defender.Easm.Models;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Analytics.Defender.Easm.Tests.Samples
{
    public partial class DiscoveryGroupsSample: SamplesBase<EasmClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void DiscoveryGroupsScenario()
        {
            #region Snippet:Sample2_DiscoveryGroups_Create_Client
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

#region Snippet:Sample2_DiscoveryGroups_Create_Discovery_Group
            string discoveryGroupName = "Sample Disco From C#";
            string discoveryGroupDescription = "This is a sample discovery group generated from C#";

#if SNIPPET
            string[] hosts = ["<host1>.<org>.com", "<host2>.<org>.com"];
            string[] domains = ["<domain1>.com", "<domain2>.com"];
#else
            string[] hosts = TestEnvironment.Hosts.Split(',');
            string[] domains = TestEnvironment.Domains.Split(',');
#endif

            DiscoGroupData request = new DiscoGroupData();
            foreach (string host in hosts)
            {
                DiscoSource seed = new DiscoSource();
                seed.Kind = DiscoSourceKind.Host;
                seed.Name = host;
                request.Seeds.Add(seed);
            }
            foreach (string domain in domains)
            {
                DiscoSource seed = new DiscoSource();
                seed.Kind = DiscoSourceKind.Domain;
                seed.Name = domain;
                request.Seeds.Add(seed);
            }

            request.Name = discoveryGroupName;
            request.Description = discoveryGroupDescription;

            client.PutDiscoGroup(discoveryGroupName, request);
            #endregion

            #region Snippet:Sample2_DiscoveryGroups_Run
            client.RunDiscoGroup(discoveryGroupName);

            Response<DiscoGroupPageResult> response = client.GetDiscoGroups();
            foreach (DiscoGroup discoGroup in response.Value.Value){
                Console.WriteLine(discoGroup.Name);
                Response<DiscoRunPageResult> discoRunPageResponse = client.GetRuns(discoGroup.Name);
                int index = 0;
                foreach (DiscoRunResult discoRun in discoRunPageResponse.Value.Value){
                    Console.WriteLine($" - started: {discoRun.StartedDate}, finished: {discoRun.CompletedDate}, assets found: {discoRun.TotalAssetsFoundCount}");
                    if (++index == 5){
                        break;
                    }
                }
            }
            #endregion
        }
    }
}
