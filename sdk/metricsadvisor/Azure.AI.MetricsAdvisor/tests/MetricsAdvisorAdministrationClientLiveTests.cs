﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task GetDataFeed()
        {
            var adminClient = GetMetricsAdvisorAdministrationClient();

            List<DataFeed> feeds = await adminClient.GetDataFeedsAsync().ToEnumerableAsync().ConfigureAwait(false);

            Assert.That(feeds, Is.Not.Empty);

            foreach (DataFeed feed in feeds)
            {
                DataFeed feedResult = await adminClient.GetDataFeedAsync(feed.Id);

                Assert.That(feedResult.CreatedTime, Is.EqualTo(feed.CreatedTime));
                Assert.That(feedResult.Granularity.GranularityType, Is.EqualTo(feed.Granularity.GranularityType));
                Assert.That(feedResult.Granularity.CustomGranularityValue, Is.EqualTo(feed.Granularity.CustomGranularityValue));
                Assert.That(feedResult.Id, Is.EqualTo(feed.Id));
                Assert.That(feedResult.IngestionSettings.DataSourceRequestConcurrency, Is.EqualTo(feed.IngestionSettings.DataSourceRequestConcurrency));
                Assert.That(feedResult.IsAdministrator, Is.EqualTo(feed.IsAdministrator));
                Assert.That(feedResult.MetricIds, Is.EqualTo(feed.MetricIds));
                Assert.That(feedResult.Name, Is.EqualTo(feed.Name));
                Assert.That(feedResult.Options.Administrators, Is.EquivalentTo(feed.Options.Administrators));
                Assert.That(feedResult.Schema.DimensionColumns.Count, Is.EqualTo(feed.Schema.DimensionColumns.Count));
                Assert.That(feedResult.SourceType, Is.EqualTo(feed.SourceType));
                Assert.That(feedResult.Status, Is.EqualTo(feed.Status));
            }
        }

        [RecordedTest]
        public async Task CreateBlobDataFeed()
        {
            var adminClient = GetMetricsAdvisorAdministrationClient();
            InitDataFeedSources();

            DataFeed createdDataFeed = await adminClient.CreateDataFeedAsync(_blobFeedName, _blobSource, _dailyGranularity, _dataFeedSchema, _dataFeedIngestionSettings, _dataFeedOptions).ConfigureAwait(false);

            Assert.That(createdDataFeed.Id, Is.Not.Null);

            await adminClient.DeleteDataFeedAsync(createdDataFeed.Id);
        }

        [RecordedTest]
        public async Task CreateMetricAnomalyDetectionConfiguration()
        {
            var adminClient = GetMetricsAdvisorAdministrationClient();

            var config = await CreateMetricAnomalyDetectionConfiguration(adminClient);

            MetricAnomalyDetectionConfiguration createdConfiguration = await adminClient.CreateMetricAnomalyDetectionConfigurationAsync(config).ConfigureAwait(false);

            Assert.That(createdConfiguration.Id, Is.Not.Null);
            Assert.That(createdConfiguration.Name, Is.EqualTo(config.Name));

            MetricAnomalyDetectionConfiguration getConfig = await adminClient.GetMetricAnomalyDetectionConfigurationAsync(createdConfiguration.Id).ConfigureAwait(false);

            Assert.That(getConfig.Id, Is.EqualTo(createdConfiguration.Id));

            await adminClient.DeleteMetricAnomalyDetectionConfigurationAsync(createdConfiguration.Id);
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
        public async Task AnomalyAlertConfigurationOperations()
        {
            var adminClient = GetMetricsAdvisorAdministrationClient();

            // Create a Detection Configuration
            DataFeed feed = await GetFirstDataFeed(adminClient);
            MetricAnomalyDetectionConfiguration detectionConfig = await CreateMetricAnomalyDetectionConfiguration(adminClient).ConfigureAwait(false);

            MetricAnomalyDetectionConfiguration createdAnomalyDetectionConfiguration = await adminClient.CreateMetricAnomalyDetectionConfigurationAsync(detectionConfig).ConfigureAwait(false);

            AnomalyAlertConfiguration createdAlertConfig = await adminClient.CreateAnomalyAlertConfigurationAsync(
                new AnomalyAlertConfiguration(
                    Recording.GenerateAlphaNumericId("test"),
                    new List<string>(),
                    new List<MetricAnomalyAlertConfiguration>
                    {
                        new MetricAnomalyAlertConfiguration(
                            createdAnomalyDetectionConfiguration.Id,
                            new MetricAnomalyAlertScope(
                                MetricAnomalyAlertScopeType.TopN,
                                new DimensionKey(new List<KeyValuePair<string, string>>
                                {
                                    new KeyValuePair<string, string>("test", "test2")
                                }),
                                new TopNGroupScope(8, 4, 2)))
                    })
            ).ConfigureAwait(false);

            Assert.That(createdAlertConfig.Id, Is.Not.Null);

            // Validate that we can Get the newly created config
            AnomalyAlertConfiguration getAlertConfig = await adminClient.GetAnomalyAlertConfigurationAsync(createdAlertConfig.Id).ConfigureAwait(false);
            Response<IReadOnlyList<AnomalyAlertConfiguration>> getAlertConfigs = await adminClient.GetAnomalyAlertConfigurationsAsync(createdAnomalyDetectionConfiguration.Id).ConfigureAwait(false);

            Assert.That(getAlertConfig.Id, Is.EqualTo(createdAlertConfig.Id));
            Assert.That(getAlertConfigs.Value.Any(c => c.Id == createdAlertConfig.Id));

            // Cleanup
            await adminClient.DeleteAnomalyAlertConfigurationAsync(createdAlertConfig.Id).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task HookOperations()
        {
            var adminClient = GetMetricsAdvisorAdministrationClient();

            AlertingHook createdHook = await adminClient.CreateHookAsync(new EmailHook(Recording.GenerateAlphaNumericId("test"), new List<string> { "foo@contoso.com" })).ConfigureAwait(false);
            AlertingHook getHook = await adminClient.GetHookAsync(createdHook.Id).ConfigureAwait(false);
            List<AlertingHook> hooks = await adminClient.GetHooksAsync(new GetHooksOptions { HookName = getHook.Name }).ToEnumerableAsync().ConfigureAwait(false);

            Assert.That(getHook.Id, Is.EqualTo(createdHook.Id));
            Assert.That(getHook.Name, Is.EqualTo(createdHook.Name));
            Assert.That(hooks, Is.Not.Empty);
            Assert.That(hooks.First().Name, Is.EqualTo(createdHook.Name));

            await adminClient.DeleteHookAsync(createdHook.Id).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task ResetDataFeedIngestionStatus()
        {
            var adminClient = GetMetricsAdvisorAdministrationClient();

            await adminClient.ResetDataFeedIngestionStatusAsync(DataFeedId, new DateTimeOffset(2020, 9, 1, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2020, 9, 2, 0, 0, 0, TimeSpan.Zero)).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task GetMetricAnomalyDetectionConfigurations()
        {
            var adminClient = GetMetricsAdvisorAdministrationClient();

            Response<IReadOnlyList<MetricAnomalyDetectionConfiguration>> configs = await adminClient.GetMetricAnomalyDetectionConfigurationsAsync(MetricId).ConfigureAwait(false);

            Assert.That(configs.Value, Is.Not.Empty);
        }
    }
}
