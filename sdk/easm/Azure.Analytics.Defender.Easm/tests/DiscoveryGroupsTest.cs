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
        [Test]
        public async System.Threading.Tasks.Task DiscoveryGroupsListTest()
        {
            var results = client.GetDiscoGroupsAsync();
            Assert.IsNotNull(results);
            await foreach (DiscoGroup result in results)
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
        [Test]
        public async System.Threading.Tasks.Task ValidateDiscoveryGroupTest()
        {
            DiscoSource seed = new DiscoSource();
            seed.Kind = seedKind;
            seed.Name = seedName;
            DiscoGroupData request = new DiscoGroupData();
            request.Seeds.Add(seed);
            request.Name = newGroupName;
            request.Description = newGroupDescription;
            request.FrequencyMilliseconds = 604800000L;
            request.Tier = "advanced";
            ValidateResult result = await client.ValidateDiscoGroupAsync(request).ConfigureAwait(false);
            Assert.IsNull(result.Error);
        }
        [Test]
        public async System.Threading.Tasks.Task DiscoveryGroupsGetTest()
        {
            var result = await client.GetDiscoGroupAsync(knownGroupName);
            DiscoGroup discoGroup = result.Value;
            Assert.AreEqual(knownGroupName, discoGroup.Name);
            Assert.AreEqual(knownGroupName, discoGroup.DisplayName);
            Assert.IsNotNull(discoGroup.Description);
            Assert.IsNotNull(discoGroup.Seeds);
            Assert.IsNotNull(discoGroup.Seeds[0].Kind);
            Assert.IsNotNull(discoGroup.Seeds[0].Name);
        }
        [Test]
        public async System.Threading.Tasks.Task DiscoveryGroupsCreateOrReplaceTest()
        {
            DiscoSource seed = new DiscoSource();
            seed.Kind = seedKind;
            seed.Name = seedName;
            DiscoGroupData request = new DiscoGroupData();
            request.Seeds.Add(seed);
            request.Name = newGroupName;
            request.Description = newGroupDescription;
            request.FrequencyMilliseconds = 604800000L;
            request.Tier = "advanced";
            var response = await client.CreateOrReplaceDiscoGroupAsync(newGroupName, request).ConfigureAwait(false);
            DiscoGroup discoGroup = response.Value;
            Assert.IsTrue(doSeedsMatch(seed, discoGroup.Seeds[0]));
        }
        [Test]
        public async System.Threading.Tasks.Task DiscoGroupsRunTest()
        {
            Response response = await client.RunDiscoGroupAsync(knownGroupName).ConfigureAwait(false);
            Assert.AreEqual(204, response.Status);
        }

        [Test]
        public async System.Threading.Tasks.Task DisocRunListTest()
        {
            var response = client.GetRunsAsync(knownGroupName).ConfigureAwait(false);
            await foreach (var run in response)
            {
                Assert.IsNotNull(run.State);
                Assert.IsNotNull(run.TotalAssetsFoundCount);
            }
        }
        private bool? doSeedsMatch(DiscoSource seed, DiscoSource discoSource)
        {
            return seed.Kind == discoSource.Kind && seed.Name == discoSource.Name;
        }
    }
}
