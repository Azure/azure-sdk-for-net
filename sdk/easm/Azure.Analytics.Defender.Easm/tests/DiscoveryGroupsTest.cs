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
            Assert.IsNotNull(results);
            await foreach (DiscoveryGroup result in results)
            {
                Assert.IsNotNull(result.Name);
                Assert.IsNotNull(result.DisplayName);
                Assert.IsNotNull(result.Description);
                Assert.IsNotNull(result.Seeds);
                Assert.IsNotNull(result.Seeds[0].Kind);
                Assert.IsNotNull(result.Seeds[0].Name);
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
            Assert.IsNull(result.Value.Error);
        }
        [RecordedTest]
        public async System.Threading.Tasks.Task DiscoveryGroupsGetTest()
        {
            var result = await client.GetDiscoveryGroupAsync(knownGroupName);
            DiscoveryGroup discoGroup = result.Value;
            Assert.AreEqual(knownGroupName, discoGroup.Name);
            Assert.AreEqual(knownGroupName, discoGroup.DisplayName);
            Assert.IsNotNull(discoGroup.Description);
            Assert.IsNotNull(discoGroup.Seeds);
            Assert.IsNotNull(discoGroup.Seeds[0].Kind);
            Assert.IsNotNull(discoGroup.Seeds[0].Name);
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
            Assert.IsTrue(doSeedsMatch(seed, discoGroup.Seeds[0]));
        }
        [RecordedTest]
        public async System.Threading.Tasks.Task DiscoGroupsRunTest()
        {
            Response response = await client.RunDiscoveryGroupAsync(knownGroupName).ConfigureAwait(false);
            Assert.AreEqual(204, response.Status);
        }
        [RecordedTest]
        public async System.Threading.Tasks.Task DiscoRunListTest()
        {
            var response = client.GetDiscoveryGroupRunsAsync(knownGroupName).ConfigureAwait(false);
            await foreach (var run in response)
            {
                Assert.IsNotNull(run.State);
                Assert.IsNotNull(run.TotalAssetsFoundCount);
            }
        }
        private bool? doSeedsMatch(DiscoverySource seed, DiscoverySource discoSource)
        {
            return seed.Kind == discoSource.Kind && seed.Name == discoSource.Name;
        }
    }
}
