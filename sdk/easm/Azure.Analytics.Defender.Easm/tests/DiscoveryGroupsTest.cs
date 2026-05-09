// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Analytics.Defender.Easm;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.Defender.Easm.Tests
{
    internal class DiscoveryGroupsTest : EasmClientTest
    {
        private string knownGroupName;
        private string newGroupName;
        private string newGroupDescription;
        private string seedKind;
        private string seedName;

        public DiscoveryGroupsTest(bool isAsync) : base(isAsync)
        {
            knownGroupName = "University of Kansas";
            newGroupName = "New disco group Name";
            newGroupDescription = "This is a description";
            seedKind = "domain";
            seedName = "example.org";
        }
        [RecordedTest]
        public async System.Threading.Tasks.Task DiscoveryGroupsListTest()
        {
            var results = client.GetDiscoveryGroupsAsync();
            Assert.That(results, Is.Not.Null);
            await foreach (DiscoveryGroup result in results)
            {
                Assert.That(result.Name, Is.Not.Null);
                Assert.That(result.DisplayName, Is.Not.Null);
                Assert.That(result.Description, Is.Not.Null);
                Assert.That(result.Seeds, Is.Not.Null);
                Assert.That(result.Seeds[0].Kind, Is.Not.Null);
                Assert.That(result.Seeds[0].Name, Is.Not.Null);
                break;
            }
        }
        [RecordedTest]
        public async System.Threading.Tasks.Task ValidateDiscoveryGroupTest()
        {
            DiscoverySource seed = new DiscoverySource();
            seed.Kind = seedKind;
            seed.Name = seedName;
            DiscoveryGroupPayload request = new DiscoveryGroupPayload();
            request.Seeds.Add(seed);
            request.Name = newGroupName;
            request.Description = newGroupDescription;
            request.FrequencyMilliseconds = 604800000L;
            request.Tier = "advanced";
            var result = await client.ValidateDiscoveryGroupAsync(request).ConfigureAwait(false);
            Assert.That(result.Value.Error, Is.Null);
        }
        [RecordedTest]
        public async System.Threading.Tasks.Task DiscoveryGroupsGetTest()
        {
            var result = await client.GetDiscoveryGroupAsync(knownGroupName);
            DiscoveryGroup discoGroup = result.Value;
            Assert.That(discoGroup.Name, Is.EqualTo(knownGroupName));
            Assert.That(discoGroup.DisplayName, Is.EqualTo(knownGroupName));
            Assert.That(discoGroup.Description, Is.Not.Null);
            Assert.That(discoGroup.Seeds, Is.Not.Null);
            Assert.That(discoGroup.Seeds[0].Kind, Is.Not.Null);
            Assert.That(discoGroup.Seeds[0].Name, Is.Not.Null);
        }
        [RecordedTest]
        public async System.Threading.Tasks.Task DiscoveryGroupsCreateOrReplaceTest()
        {
            DiscoverySource seed = new DiscoverySource();
            seed.Kind = seedKind;
            seed.Name = seedName;
            DiscoveryGroupPayload request = new DiscoveryGroupPayload();
            request.Seeds.Add(seed);
            request.Name = newGroupName;
            request.Description = newGroupDescription;
            request.FrequencyMilliseconds = 604800000L;
            request.Tier = "advanced";
            var response = await client.CreateOrReplaceDiscoveryGroupAsync(newGroupName, request).ConfigureAwait(false);
            DiscoveryGroup discoGroup = response.Value;
            Assert.That(doSeedsMatch(seed, discoGroup.Seeds[0]), Is.True);
        }
        [RecordedTest]
        public async System.Threading.Tasks.Task DiscoGroupsRunTest()
        {
            Response response = await client.RunDiscoveryGroupAsync(knownGroupName).ConfigureAwait(false);
            Assert.That(response.Status, Is.EqualTo(204));
        }
        [RecordedTest]
        public async System.Threading.Tasks.Task DiscoRunListTest()
        {
            var response = client.GetDiscoveryGroupRunsAsync(knownGroupName).ConfigureAwait(false);
            await foreach (var run in response)
            {
                Assert.That(run.State, Is.Not.Null);
                Assert.That(run.TotalAssetsFoundCount, Is.Not.Null);
            }
        }
        private bool? doSeedsMatch(DiscoverySource seed, DiscoverySource discoSource)
        {
            return seed.Kind == discoSource.Kind && seed.Name == discoSource.Name;
        }
    }
}
