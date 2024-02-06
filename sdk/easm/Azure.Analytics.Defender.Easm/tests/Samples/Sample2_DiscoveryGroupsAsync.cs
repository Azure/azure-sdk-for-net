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
            string endpoint = $"https://{TestEnvironment.Region}.easm.defender.microsoft.com";
            EasmClient client = new EasmClient(new System.Uri(endpoint),
                TestEnvironment.SubscriptionId,
                TestEnvironment.ResourceGroupName,
                TestEnvironment.WorkspaceName,
                TestEnvironment.Credential);
            string discoveryGroupName = "Sample Disco";
            string discoveryGroupDescription = "This is a sample discovery group generated from C#";
            string[] hosts = TestEnvironment.Hosts.Split(',');
            string[] domains = TestEnvironment.Domains.Split(',');
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

            request.Description = discoveryGroupDescription;

            await client.CreateOrReplaceDiscoGroupAsync(discoveryGroupName, request);

            await client.RunDiscoGroupAsync(discoveryGroupName);

            var discoGroups = client.GetDiscoGroupsAsync();
            await foreach (var discoGroup in discoGroups)
            {
                Console.WriteLine(discoGroup.Name);
                var discoRuns = client.GetRunsAsync(discoGroup.Name);
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