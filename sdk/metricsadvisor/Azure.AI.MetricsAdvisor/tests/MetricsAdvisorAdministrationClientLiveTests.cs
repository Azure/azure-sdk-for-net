// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class MetricsAdvisorAdministrationClientLiveTests : MetricsAdvisorLiveTestBase
    {
        public MetricsAdvisorAdministrationClientLiveTests(bool isAsync) : base(isAsync, RecordedTestMode.Playback /* To record tests, add this argument, RecordedTestMode.Record */)
        { }

        [RecordedTest]
        public async Task GetDataFeeds()
        {
            var adminClient = GetMetricsAdvisorAdministrationClient();

            List<DataFeed> feeds = await adminClient.GetDataFeedsAsync(new GetDataFeedsOptions { TopCount = 2 }).ToEnumerableAsync().ConfigureAwait(false);

            Assert.That(feeds, Is.Not.Empty);
        }

        [RecordedTest]
        public async Task CreateAndUpdateBlobDataFeedFromGet()
        {
            var adminClient = GetMetricsAdvisorAdministrationClient();
            InitDataFeedSources();

            DataFeed dataFeed = new DataFeed(_blobFeedName, _blobSource, _dailyGranularity, _dataFeedSchema, _dataFeedIngestionSettings)
            {
                Description = _dataFeedDescription
            };

            string dataFeedId = await adminClient.CreateDataFeedAsync(dataFeed).ConfigureAwait(false);

            Assert.That(dataFeedId, Is.Not.Null);

            DataFeed getDataFeed = await adminClient.GetDataFeedAsync(dataFeedId);

            getDataFeed.Description = Recording.GenerateAlphaNumericId("desc");
            getDataFeed.MissingDataPointFillSettings.CustomFillValue = 42;
            getDataFeed.MissingDataPointFillSettings.FillType = DataFeedMissingDataPointFillType.CustomValue;

            await adminClient.UpdateDataFeedAsync(getDataFeed.Id, getDataFeed).ConfigureAwait(false);

            await adminClient.DeleteDataFeedAsync(dataFeedId);
        }

        [RecordedTest]
        public async Task GetDataFeedIngestionStatuses()
        {
            var adminClient = GetMetricsAdvisorAdministrationClient();

            List<DataFeed> feeds = await adminClient.GetDataFeedsAsync().ToEnumerableAsync().ConfigureAwait(false);

            int pages = 0;
            foreach (DataFeed feed in feeds)
            {
                await foreach (var status in adminClient.GetDataFeedIngestionStatusesAsync(feed.Id, new GetDataFeedIngestionStatusesOptions(Recording.UtcNow.AddYears(-5), Recording.UtcNow) { TopCount = 1 }))
                {
                    pages++;
                    Assert.That(status, Is.Not.Null);
                    Assert.That(status.Message, Is.Not.Null);

                    //Only perform a single iteration.
                    if (pages > 2)
                        break;
                }
            }
        }

        [RecordedTest]
        public async Task GetDataFeedIngestionProgress()
        {
            var adminClient = GetMetricsAdvisorAdministrationClient();

            DataFeedIngestionProgress progress = await adminClient.GetDataFeedIngestionProgressAsync(DataFeedId).ConfigureAwait(false);

            Assert.That(progress, Is.Not.Null);
        }

        [RecordedTest]
        public async Task ResetDataFeedIngestionStatus()
        {
            var adminClient = GetMetricsAdvisorAdministrationClient();

            await adminClient.RefreshDataFeedIngestionAsync(DataFeedId, new DateTimeOffset(2020, 9, 1, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2020, 9, 2, 0, 0, 0, TimeSpan.Zero)).ConfigureAwait(false);
        }
    }
}
