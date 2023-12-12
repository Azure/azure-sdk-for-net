// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.Defender.Easm.Tests.Samples
{
    public partial class DiscoveryGroupsSample : SamplesBase<EasmClientTestEnvironment>
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
            foreach (var host in hosts)
            {
                DiscoSource seed = new DiscoSource();
                seed.Kind = DiscoSourceKind.Host;
                seed.Name = host;
                request.Seeds.Add(seed);
            }
            foreach (var domain in domains)
            {
                DiscoSource seed = new DiscoSource();
                seed.Kind = DiscoSourceKind.Domain;
                seed.Name = domain;
                request.Seeds.Add(seed);
            }

            request.Name = discoveryGroupName;
            request.Description = discoveryGroupDescription;
            client.CreateOrReplaceDiscoGroup(discoveryGroupName, request);
            #endregion

            #region Snippet:Sample2_DiscoveryGroups_Run
            client.RunDiscoGroup(discoveryGroupName);
            Pageable<DiscoGroup> response = client.GetDiscoGroups();
            foreach (DiscoGroup discoGroup in response)
            {
                Console.WriteLine(discoGroup.Name);
                Pageable<DiscoRunResult> discoRunPageResponse = client.GetRuns(discoGroup.Name);
                int index = 0;
                foreach (DiscoRunResult discoRun in discoRunPageResponse)
                {
                    Console.WriteLine($" - started: {discoRun.StartedDate}, finished: {discoRun.CompletedDate}, assets found: {discoRun.TotalAssetsFoundCount}, status: {discoRun.State}");
                    if (++index == 5){
                        break;
                    }
                }
            }
            #endregion
        }
    }
}
