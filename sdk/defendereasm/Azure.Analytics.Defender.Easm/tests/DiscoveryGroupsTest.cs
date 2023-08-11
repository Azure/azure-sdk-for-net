// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Analytics.Defender.Easm.Models;
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
            newGroupName = "New disco group Name CS";
            newGroupDescription = "This is a description";
            seedKind = "domain";
            seedName = "example.org";
        }

        [RecordedTest]
        public async Task DiscoveryGroupsListTest()
        {
            Response<DiscoGroupPageResult> response = await client.GetDiscoGroupsAsync();
            DiscoGroup discoGroupResponse = response.Value.Value[0];
            Assert.IsNotNull(discoGroupResponse.Name);
            Assert.IsNotNull(discoGroupResponse.DisplayName);
            Assert.IsNotNull(discoGroupResponse.Description);
            Assert.IsNotNull(discoGroupResponse.Tier);
            Assert.IsNotNull(discoGroupResponse.Id);
        }

        [RecordedTest]
        public async Task DiscoveryGroupsValidateTest()
        {
            DiscoSource seed = new DiscoSource();
            seed.Kind = seedKind;
            seed.Name = seedName;

            //AzureDataExplorerDataConnectionProperties azureProperties = new AzureDataExplorerDataConnectionProperties();
            //azureProperties.Region = "eastus";
            //azureProperties.ClusterName = "testCluster";
            //azureProperties.DatabaseName = "testDb";
            //AzureDataExplorerDataConnectionData discoGroupRequest = new AzureDataExplorerDataConnectionData(azureProperties);

            DiscoGroupData discoGroupRequest = new DiscoGroupData();
            discoGroupRequest.Name = newGroupName;
            discoGroupRequest.Description = newGroupDescription;
            discoGroupRequest.Seeds.Add(seed);
            discoGroupRequest.FrequencyMilliseconds = 604800000;
            discoGroupRequest.Tier = "advanced";
            Response<ValidateResult> response = await client.ValidateDiscoGroupAsync(discoGroupRequest);
            Assert.IsNull(response.Value.Error);
        }

        [RecordedTest]
        public async Task DiscoveryGroupsGetTest()
        {
            Response<DiscoGroup> response = await client.GetDiscoGroupAsync(knownGroupName);
            DiscoGroup discoGroupResponse = response.Value;
            Assert.AreEqual(knownGroupName, discoGroupResponse.Id);
            Assert.AreEqual(knownGroupName, discoGroupResponse.Name);
            Assert.AreEqual(knownGroupName, discoGroupResponse.DisplayName);
            Assert.IsNotNull(discoGroupResponse.Description);
            Assert.IsNotNull(discoGroupResponse.Tier);
        }

        [RecordedTest]
        public async Task DiscoveryGroupsPutTest()
        {
            DiscoSource seed = new DiscoSource();
            seed.Kind = seedKind;
            seed.Name = seedName;

            DiscoGroupData discoGroupRequest = new DiscoGroupData();
            discoGroupRequest.Name = newGroupName;
            discoGroupRequest.Description = newGroupDescription;
            discoGroupRequest.Seeds.Add(seed);
            discoGroupRequest.FrequencyMilliseconds = 604800000;
            discoGroupRequest.Tier = "advanced";
            Response<DiscoGroup> response = await client.PutDiscoGroupAsync(newGroupName, discoGroupRequest);
            DiscoGroup discoGroupResponse = response.Value;
            Assert.IsTrue(doSeedsMatch(seed, discoGroupResponse.Seeds[0]));
        }

        [RecordedTest]
        public async Task DiscoveryGroupsRunTest()
        {
            Response response = await client.RunDiscoGroupAsync(knownGroupName);
            Assert.AreEqual(204, response.Status);
        }

        [RecordedTest]
        public async Task DiscoveryGroupsListRunsTest()
        {
            Response<DiscoRunPageResult> response = await client.GetRunsAsync(knownGroupName);
            DiscoRunResult discoRunResponse = response.Value.Value[0];
            Assert.IsNotNull(discoRunResponse.State);
            Assert.IsNotNull(discoRunResponse.Tier);
        }

        private bool? doSeedsMatch(DiscoSource seed, DiscoSource discoSource)
        {
            return seed.Kind == discoSource.Kind && seed.Name == discoSource.Name;
        }
    }
}
