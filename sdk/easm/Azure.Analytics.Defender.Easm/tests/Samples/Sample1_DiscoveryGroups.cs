// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
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
            string endpoint = "https://<region>.easm.defender.microsoft.com/subscriptions/<Your_Subscription_Id>/resourceGroups/<Your_Resource_Group_Name>/workspaces/<Your_Workspace_Name>";
            EasmClient client = new EasmClient(new System.Uri(endpoint),
                            new DefaultAzureCredential());
            #else
            string endpoint = $"https://{TestEnvironment.Region}.easm.defender.microsoft.com/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{TestEnvironment.ResourceGroupName}/workspaces/{TestEnvironment.WorkspaceName}";
            EasmClient client = new EasmClient(new System.Uri(endpoint),
                TestEnvironment.Credential);
            #endif
            #endregion

            #region Snippet:Sample2_DiscoveryGroups_Create_Discovery_Group
            string discoveryGroupName = "Sample Disco From C#";
            string discoveryGroupDescription = "This is a sample discovery group generated from C#";
            #if SNIPPET
            string[] hosts = new string[2];
            hosts[0] = "<host1>.com";
            hosts[1] = "<host2>.com";
            string[] domains = new string[2];
            domains[0] = "<domain1>.com";
            domains[1] = "<domain2>.com";
            #else
            string[] hosts = TestEnvironment.Hosts.Split(',');
            string[] domains = TestEnvironment.Domains.Split(',');
            #endif
            DiscoveryGroupPayload request = new DiscoveryGroupPayload();
            foreach (var host in hosts)
            {
                DiscoverySource seed = new DiscoverySource();
                seed.Kind = DiscoverySourceKind.Host;
                seed.Name = host;
                request.Seeds.Add(seed);
            }
            foreach (var domain in domains)
            {
                DiscoverySource seed = new DiscoverySource();
                seed.Kind = DiscoverySourceKind.Domain;
                seed.Name = domain;
                request.Seeds.Add(seed);
            }

            request.Description = discoveryGroupDescription;
            client.CreateOrReplaceDiscoveryGroup(discoveryGroupName, request);
            #endregion

            #region Snippet:Sample2_DiscoveryGroups_Run
            client.RunDiscoveryGroup(discoveryGroupName);
            Pageable<DiscoveryGroup> response = client.GetDiscoveryGroups();
            foreach (DiscoveryGroup discoGroup in response)
            {
                Console.WriteLine(discoGroup.Name);
                Pageable<DiscoveryRunResult> discoRunPageResponse = client.GetDiscoveryGroupRuns(discoGroup.Name);
                int index = 0;
                foreach (DiscoveryRunResult discoRun in discoRunPageResponse)
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
