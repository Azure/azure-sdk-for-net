// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.ResourceManager.Chaos.Tests.TestDependencies;
using System.Linq;

namespace Azure.ResourceManager.Chaos.Tests
{
    public class TargetTests : ChaosManagementTestBase
    {
        public TargetTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Playback)
        {
        }

        // Typical constructor setup requires an init method instead to not break Record functionality
        [SetUp]
        public async Task ClearChallengeCacheForRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await Initialize().ConfigureAwait(false);
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var targetCollection = this.ResourceGroupResource.GetChaosTargets(
                TestConstants.ComputeNamespace,
                TestConstants.VmssResourceName,
                this.VmssName);
            var createUpdateTargetResponse = await targetCollection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                TestConstants.VmssTargetName,
                new ChaosTargetData(new Dictionary<string, BinaryData>()));
            Assert.AreEqual(200, createUpdateTargetResponse.GetRawResponse().Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var targetResponse = await this.ResourceGroupResource.GetChaosTargetAsync(
                TestConstants.ComputeNamespace,
                TestConstants.VmssResourceName,
                this.VmssName,
                TestConstants.VmssTargetName).ConfigureAwait(false);
            Assert.AreEqual(TestConstants.VmssTargetName, targetResponse.Value.Data.Name);
            Assert.AreEqual(200, targetResponse.GetRawResponse().Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            var targetCollection = this.ResourceGroupResource.GetChaosTargets(
                TestConstants.ComputeNamespace,
                TestConstants.VmssResourceName,
                this.VmssName);
            var targetList = await targetCollection.GetAllAsync().ToListAsync().ConfigureAwait(false);
            Assert.IsTrue(targetList.Any());
        }
    }
}
