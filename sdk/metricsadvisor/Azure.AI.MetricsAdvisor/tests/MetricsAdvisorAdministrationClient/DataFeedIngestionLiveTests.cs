// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class DataFeedIngestionLiveTests : MetricsAdvisorLiveTestBase
    {
        public DataFeedIngestionLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task GetDataFeedIngestionProgress(bool useTokenCredential)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient(useTokenCredential);

            DataFeedIngestionProgress progress = await adminClient.GetDataFeedIngestionProgressAsync(DataFeedId);

            Assert.That(progress, Is.Not.Null);
            Assert.That(progress.LatestActiveTimestamp, Is.Not.Null);
            Assert.That(progress.LatestActiveTimestamp, Is.Not.EqualTo(default(DateTimeOffset)));
            Assert.That(progress.LatestSuccessTimestamp, Is.Not.Null);
            Assert.That(progress.LatestSuccessTimestamp, Is.Not.EqualTo(default(DateTimeOffset)));
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task RefreshDataIngestion(bool useTokenCredential)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient(useTokenCredential);

            var startTime = DateTimeOffset.Parse("2022-03-01T00:00:00Z");
            var endTime = DateTimeOffset.Parse("2022-03-03T00:00:00Z");

            Response response = await adminClient.RefreshDataFeedIngestionAsync(DataFeedId, startTime, endTime);

            Assert.That(response.Status, Is.EqualTo(204));
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task GetDataFeedIngestionStatuses(bool useTokenCredential)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient(useTokenCredential);

            var options = new GetDataFeedIngestionStatusesOptions(SamplingStartTime, SamplingEndTime);

            var statusCount = 0;

            await foreach (DataFeedIngestionStatus status in adminClient.GetDataFeedIngestionStatusesAsync(DataFeedId, options))
            {
                Assert.That(status, Is.Not.Null);
                Assert.That(status.Timestamp, Is.InRange(SamplingStartTime, SamplingEndTime));
                Assert.That(status.Status, Is.Not.EqualTo(default(IngestionStatusType)));
                Assert.That(status.Message, Is.Not.Null);

                if (++statusCount >= MaximumSamplesCount)
                {
                    break;
                }
            }

            Assert.That(statusCount, Is.GreaterThan(0));
        }
    }
}
