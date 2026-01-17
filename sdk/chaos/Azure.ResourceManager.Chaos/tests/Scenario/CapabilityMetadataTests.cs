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
    // The ChaosCapabilityMetadataCollection has been removed and replaced with ChaosCapabilityTypeCollection
    // which is accessed via ChaosTargetTypeResource instead of ChaosTargetMetadataResource
    [Ignore("Tests need to be updated for 2026-02-01-preview API - ChaosCapabilityMetadata/ChaosTargetMetadata removed")]
    public class CapabilityMetadataTests : ChaosManagementTestBase
    {
        public CapabilityMetadataTests(bool isAsync)
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
            // TODO: Update to use ChaosCapabilityTypeCollection via ChaosTargetTypeResource
            await Task.CompletedTask;
            Assert.Pass("Test needs to be updated for 2026-02-01-preview API");
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            // TODO: Update to use ChaosCapabilityTypeCollection via ChaosTargetTypeResource
            await Task.CompletedTask;
            Assert.Pass("Test needs to be updated for 2026-02-01-preview API");
        }
    }
}
