// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Analytics.Defender.Easm.Tests.Samples
{
    public partial class DiscoveryGroupsSample : SamplesBase<EasmClientTestEnvironment>
    {
        [Test]
        public async System.Threading.Tasks.Task DiscoveryGroupsScenarioAsync()
        {
            string endpoint = $"https://{TestEnvironment.Region}.easm.defender.microsoft.com/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{TestEnvironment.ResourceGroupName}/workspaces/{TestEnvironment.WorkspaceName}";
            EasmClient client = new EasmClient(new System.Uri(endpoint),
                TestEnvironment.Credential);
            string discoveryGroupName = "Sample Disco";
            string discoveryGroupDescription = "This is a sample discovery group generated from C#";
            string[] hosts = TestEnvironment.Hosts.Split(',');
            string[] domains = TestEnvironment.Domains.Split(',');
            DiscoveryGroupPayload request = new DiscoveryGroupPayload();
            foreach (string host in hosts)
            {
                DiscoverySource seed = new DiscoverySource();
                seed.Kind = DiscoverySourceKind.Host;
                seed.Name = host;
                request.Seeds.Add(seed);
            }
            foreach (string domain in domains)
            {
                DiscoverySource seed = new DiscoverySource();
                seed.Kind = DiscoverySourceKind.Domain;
                seed.Name = domain;
                request.Seeds.Add(seed);
            }

            request.Description = discoveryGroupDescription;

            await client.CreateOrReplaceDiscoveryGroupAsync(discoveryGroupName, request);

            await client.RunDiscoveryGroupAsync(discoveryGroupName);

            var discoGroups = client.GetDiscoveryGroupsAsync();
            await foreach (var discoGroup in discoGroups)
            {
                Console.WriteLine(discoGroup.Name);
                var discoRuns = client.GetDiscoveryGroupRunsAsync(discoGroup.Name);
                int index = 0;
                await foreach (var discoRun in discoRuns)
                {
                    Console.WriteLine($" - started: {discoRun.StartedDate}, finished: {discoRun.CompletedDate}, assets found: {discoRun.TotalAssetsFoundCount}");
                    if (++index == 5)
                    {
                        break;
                    }
                }
            }
        }
    }
}
