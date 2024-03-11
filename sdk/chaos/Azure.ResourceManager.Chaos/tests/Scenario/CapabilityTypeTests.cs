// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Linq;
using Azure.ResourceManager.Chaos.Tests.TestDependencies;

namespace Azure.ResourceManager.Chaos.Tests
{
    public class CapabilityTypeTests : ChaosManagementTestBase
    {
        public CapabilityTypeTests(bool isAsync)
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
        public async Task List()
        {
            var targetTypeResponse = await this.TargetTypeCollection.GetAsync(TestConstants.VmssTargetName).ConfigureAwait(false);
            var capabilityTypeCollection = targetTypeResponse.Value.GetChaosCapabilityTypes();
            var list = await capabilityTypeCollection.GetAllAsync().ToListAsync().ConfigureAwait(false);
            Assert.IsTrue(list.Any());
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var targetTypeResponse = await this.TargetTypeCollection.GetAsync(TestConstants.VmssTargetName).ConfigureAwait(false);
            var capabilityTypeCollection = targetTypeResponse.Value.GetChaosCapabilityTypes();
            var capabilityResponse = await capabilityTypeCollection.GetAsync(TestConstants.VmssShutdownCapabilityName).ConfigureAwait(false);
            Assert.AreEqual(TestConstants.VmssShutdownCapabilityName, capabilityResponse.Value.Data.Name);
            Assert.AreEqual(200, targetTypeResponse.GetRawResponse().Status);
        }
    }
}
