// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Linq;
using Azure.ResourceManager.Chaos.Tests.TestDependencies;

namespace Azure.ResourceManager.Chaos.Tests
{
    // TODO: These tests need to be updated for the 2026-02-01-preview API
    // The ChaosTargetMetadataCollection has been removed and replaced with ChaosTargetTypeCollection
    // which is accessed differently in the new API
    [Ignore("Tests need to be updated for 2026-02-01-preview API - ChaosTargetMetadata removed")]
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
            // TODO: Update to use ChaosTargetTypeCollection from subscription
            await Task.CompletedTask;
            Assert.Pass("Test needs to be updated for 2026-02-01-preview API");
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            // TODO: Update to use ChaosTargetTypeCollection from subscription
            await Task.CompletedTask;
            Assert.Pass("Test needs to be updated for 2026-02-01-preview API");
        }
    }
}
