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
            TimeSpan targetSpan = TimeSpan.FromSeconds(1);
            var metadataScheduler = new MetadataScheduler(targetSpan);
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
            TimeSpan targetSpan = TimeSpan.Zero;
            var metadataScheduler = new MetadataScheduler(targetSpan);
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
            TimeSpan targetSpan = TimeSpan.MaxValue;
            var metadataScheduler = new MetadataScheduler(targetSpan);
            metadataScheduler.HasElapsed().Should().BeTrue();
            // For initial fetch, always return true.
            metadataScheduler.HasElapsed().Should().BeTrue();
            metadataScheduler.Reset();
            metadataScheduler.HasElapsed().Should().BeFalse();
            metadataScheduler.Reset();
            metadataScheduler.HasElapsed().Should().BeFalse();
        }
    }
}
