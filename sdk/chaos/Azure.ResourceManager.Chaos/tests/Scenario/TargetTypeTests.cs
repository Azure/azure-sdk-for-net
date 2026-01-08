// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Linq;
using Azure.ResourceManager.Chaos.Tests.TestDependencies;

namespace Azure.ResourceManager.Chaos.Tests
{
    public class TargetTypeTests : ChaosManagementTestBase
    {
        public TargetTypeTests(bool isAsync)
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
            var list = await this.TargetTypeCollection.GetAllAsync().ToListAsync().ConfigureAwait(false);
            Assert.That(list.Any(), Is.True);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var targetTypeResponse = await this.TargetTypeCollection.GetAsync(TestConstants.VmssTargetName).ConfigureAwait(false);
            Assert.Multiple(() =>
            {
                Assert.That(targetTypeResponse.Value.Data.Name, Is.EqualTo(TestConstants.VmssTargetName));
                Assert.That(targetTypeResponse.GetRawResponse().Status, Is.EqualTo(200));
            });
        }
    }
}
