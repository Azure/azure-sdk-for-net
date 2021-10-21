// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using FluentAssertions;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Azure.IoT.ModelsRepository.Tests
{
    public class MetadataSchedulerTests : ModelsRepositoryTestBase
    {
        [Test]
        public async Task SchedulerBasicUsage()
        {
            var metadataOptions = new ModelsRepositoryClientMetadataOptions(TimeSpan.FromSeconds(1));
            var metadataScheduler = new MetadataScheduler(metadataOptions);
            metadataScheduler.HasElapsed().Should().BeTrue();
            // For initial fetch, always return true.
            metadataScheduler.HasElapsed().Should().BeTrue();
            metadataScheduler.Reset();
            metadataScheduler.HasElapsed().Should().BeFalse();
            await Task.Delay(2000);
            metadataScheduler.HasElapsed().Should().BeTrue();
        }

        [Test]
        public void SchedulerContinuousElapse()
        {
            var metadataOptions = new ModelsRepositoryClientMetadataOptions(TimeSpan.Zero);
            var metadataScheduler = new MetadataScheduler(metadataOptions);
            metadataScheduler.HasElapsed().Should().BeTrue();
            // For initial fetch, always return true.
            metadataScheduler.HasElapsed().Should().BeTrue();
            metadataScheduler.Reset();
            metadataScheduler.HasElapsed().Should().BeTrue();
            metadataScheduler.Reset();
            metadataScheduler.HasElapsed().Should().BeTrue();
        }

        [Test]
        public void SchedulerSingleElapse()
        {
            // Default Expiration is single elapse
            var metadataOptions = new ModelsRepositoryClientMetadataOptions();
            var metadataScheduler = new MetadataScheduler(metadataOptions);
            metadataScheduler.HasElapsed().Should().BeTrue();
            // For initial fetch, always return true.
            metadataScheduler.HasElapsed().Should().BeTrue();
            metadataScheduler.Reset();
            metadataScheduler.HasElapsed().Should().BeFalse();
            metadataScheduler.Reset();
            metadataScheduler.HasElapsed().Should().BeFalse();
        }

        [Test]
        public void SchedulerNeverElapse()
        {
            var metadataOptions = new ModelsRepositoryClientMetadataOptions
            {
                Enabled = false
            };
            var metadataScheduler = new MetadataScheduler(metadataOptions);
            metadataScheduler.HasElapsed().Should().BeFalse();
            metadataScheduler.HasElapsed().Should().BeFalse();
            metadataScheduler.Reset();
            metadataScheduler.HasElapsed().Should().BeFalse();
            metadataScheduler.Reset();
            metadataScheduler.HasElapsed().Should().BeFalse();
        }
    }
}
