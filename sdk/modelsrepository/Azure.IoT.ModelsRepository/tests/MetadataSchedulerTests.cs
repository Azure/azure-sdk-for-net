// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using FluentAssertions;
using NUnit.Framework;

namespace Azure.IoT.ModelsRepository.Tests
{
    public class MetadataSchedulerTests : ModelsRepositoryTestBase
    {
        [Test]
        public void SchedulerEnabledMetadata()
        {
            // In this case the scheduler should support only an initial metadata fetch.
            var metadataOptions = new ModelsRepositoryClientMetadataOptions();
            var metadataScheduler = new MetadataScheduler(metadataOptions);
            metadataScheduler.ShouldFetchMetadata().Should().BeTrue();
            // For initial fetch, always return true.
            metadataScheduler.ShouldFetchMetadata().Should().BeTrue();
            metadataScheduler.MarkAsFetched();
            metadataScheduler.ShouldFetchMetadata().Should().BeFalse();
            metadataScheduler.ShouldFetchMetadata().Should().BeFalse();
        }

        [Test]
        public void SchedulerDisabledMetadata()
        {
            // In this case the scheduler should support no metadata fetching.
            var metadataOptions = new ModelsRepositoryClientMetadataOptions
            {
                IsMetadataProcessingEnabled = false
            };
            var metadataScheduler = new MetadataScheduler(metadataOptions);
            metadataScheduler.ShouldFetchMetadata().Should().BeFalse();
            metadataScheduler.ShouldFetchMetadata().Should().BeFalse();
            metadataScheduler.MarkAsFetched();
            metadataScheduler.ShouldFetchMetadata().Should().BeFalse();
            metadataScheduler.ShouldFetchMetadata().Should().BeFalse();
        }
    }
}
