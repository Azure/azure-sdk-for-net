// Copyright (c) Microsoft Corporation. All rights reserved.
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
        public async Task CreateAndUpdateBlobDataFeed()
        {
            var adminClient = GetMetricsAdvisorAdministrationClient();
            InitDataFeedSources();

            DataFeed createdDataFeed = await adminClient.CreateDataFeedAsync(_blobFeedName, _blobSource, _dailyGranularity, _dataFeedSchema, _dataFeedIngestionSettings, _dataFeedOptions).ConfigureAwait(false);

            Assert.That(createdDataFeed.Id, Is.Not.Null);

            createdDataFeed.Options.Description = Recording.GenerateAlphaNumericId("desc");
            await adminClient.UpdateDataFeedAsync(createdDataFeed.Id, createdDataFeed).ConfigureAwait(false);

            await adminClient.DeleteDataFeedAsync(createdDataFeed.Id);
        }

        [RecordedTest]
        public async Task CreateAndUpdateBlobDataFeedFromGet()
        {
            var adminClient = GetMetricsAdvisorAdministrationClient();
            InitDataFeedSources();

            DataFeed createdDataFeed = await adminClient.CreateDataFeedAsync(_blobFeedName, _blobSource, _dailyGranularity, _dataFeedSchema, _dataFeedIngestionSettings, _dataFeedOptions).ConfigureAwait(false);

            Assert.That(createdDataFeed.Id, Is.Not.Null);

            DataFeed getDataFeed = await adminClient.GetDataFeedAsync(createdDataFeed.Id);

            getDataFeed.Options.Description = Recording.GenerateAlphaNumericId("desc");
            getDataFeed.Options.MissingDataPointFillSettings.CustomFillValue = 42;
            getDataFeed.Options.MissingDataPointFillSettings.FillType = DataFeedMissingDataPointFillType.CustomValue;

            await adminClient.UpdateDataFeedAsync(getDataFeed.Id, getDataFeed).ConfigureAwait(false);

            await adminClient.DeleteDataFeedAsync(createdDataFeed.Id);
        }

        [RecordedTest]
        public async Task CreateAndUpdateBlobDataFeedNullOptions()
        {
            var adminClient = GetMetricsAdvisorAdministrationClient();
            InitDataFeedSources();

            DataFeed createdDataFeed = await adminClient.CreateDataFeedAsync(_blobFeedName, _blobSource, _dailyGranularity, _dataFeedSchema, _dataFeedIngestionSettings, dataFeedOptions: null).ConfigureAwait(false);

            Assert.That(createdDataFeed.Id, Is.Not.Null);

            createdDataFeed.Options.Description = Recording.GenerateAlphaNumericId("desc");
            await adminClient.UpdateDataFeedAsync(createdDataFeed.Id, createdDataFeed).ConfigureAwait(false);

            await adminClient.DeleteDataFeedAsync(createdDataFeed.Id).ConfigureAwait(false);
            ;
        }

        [RecordedTest]
        public async Task MetricAnomalyDetectionConfigurationOperations()
        {
            var adminClient = GetMetricsAdvisorAdministrationClient();

            var config = await CreateMetricAnomalyDetectionConfiguration(adminClient).ConfigureAwait(false);

            AnomalyDetectionConfiguration createdConfiguration = await adminClient.CreateMetricAnomalyDetectionConfigurationAsync(config).ConfigureAwait(false);

            Assert.That(createdConfiguration.Id, Is.Not.Null);
            Assert.That(createdConfiguration.Name, Is.EqualTo(config.Name));

            AnomalyDetectionConfiguration getConfig = await adminClient.GetMetricAnomalyDetectionConfigurationAsync(createdConfiguration.Id).ConfigureAwait(false);

            Assert.That(getConfig.Id, Is.EqualTo(createdConfiguration.Id));

            getConfig.Description = "updated";

            await adminClient.UpdateMetricAnomalyDetectionConfigurationAsync(getConfig.Id, getConfig).ConfigureAwait(false);

            // try an update with a user instantiated model.
            AnomalyDetectionConfiguration userCreatedModel = PopulateMetricAnomalyDetectionConfiguration(MetricId);
            userCreatedModel.Description = "updated again!";

            await adminClient.UpdateMetricAnomalyDetectionConfigurationAsync(getConfig.Id, userCreatedModel).ConfigureAwait(false);

            getConfig = await adminClient.GetMetricAnomalyDetectionConfigurationAsync(getConfig.Id).ConfigureAwait(false);

            Assert.That(getConfig.Description, Is.EqualTo(userCreatedModel.Description));

            await adminClient.DeleteMetricAnomalyDetectionConfigurationAsync(createdConfiguration.Id).ConfigureAwait(false);
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
            AnomalyDetectionConfiguration detectionConfig = await CreateMetricAnomalyDetectionConfiguration(adminClient).ConfigureAwait(false);

            AnomalyDetectionConfiguration createdAnomalyDetectionConfiguration = await adminClient.CreateMetricAnomalyDetectionConfigurationAsync(detectionConfig).ConfigureAwait(false);

            var alertConfigToCreate = new AnomalyAlertConfiguration(
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
                    });

            AnomalyAlertConfiguration createdAlertConfig = await adminClient.CreateAnomalyAlertConfigurationAsync(alertConfigToCreate).ConfigureAwait(false);

            Assert.That(createdAlertConfig.Id, Is.Not.Null);

            // Validate that we can Get the newly created config
            AnomalyAlertConfiguration getAlertConfig = await adminClient.GetAnomalyAlertConfigurationAsync(createdAlertConfig.Id).ConfigureAwait(false);

            List<AnomalyAlertConfiguration> getAlertConfigs = new List<AnomalyAlertConfiguration>();

            await foreach (var config in adminClient.GetAnomalyAlertConfigurationsAsync(createdAnomalyDetectionConfiguration.Id))
            {
                getAlertConfigs.Add(config);
            }

            Assert.That(getAlertConfig.Id, Is.EqualTo(createdAlertConfig.Id));
            Assert.That(getAlertConfigs.Any(c => c.Id == createdAlertConfig.Id));

            getAlertConfig.Description = "Updated";
            getAlertConfig.CrossMetricsOperator = MetricAnomalyAlertConfigurationsOperator.And;

            await adminClient.UpdateAnomalyAlertConfigurationAsync(getAlertConfig.Id, getAlertConfig).ConfigureAwait(false);

            // Validate that the update succeeded.
            getAlertConfig = await adminClient.GetAnomalyAlertConfigurationAsync(createdAlertConfig.Id).ConfigureAwait(false);

            Assert.That(getAlertConfig.Description, Is.EqualTo(getAlertConfig.Description));

            // Update again starting with our locally created model.
            alertConfigToCreate.Description = "updated again!";
            alertConfigToCreate.CrossMetricsOperator = MetricAnomalyAlertConfigurationsOperator.And;
            await adminClient.UpdateAnomalyAlertConfigurationAsync(getAlertConfig.Id, alertConfigToCreate).ConfigureAwait(false);

            // Validate that the update succeeded.
            getAlertConfig = await adminClient.GetAnomalyAlertConfigurationAsync(createdAlertConfig.Id).ConfigureAwait(false);

            Assert.That(getAlertConfig.Description, Is.EqualTo(alertConfigToCreate.Description));

            // Cleanup
            await adminClient.DeleteAnomalyAlertConfigurationAsync(createdAlertConfig.Id).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task HookOperations()
        {
            var adminClient = GetMetricsAdvisorAdministrationClient();

            NotificationHook createdEmailHook = await adminClient.CreateHookAsync(new EmailNotificationHook(Recording.GenerateAlphaNumericId("test"), new List<string> { "foo@contoso.com" }) { Description = $"{nameof(EmailNotificationHook)} description" }).ConfigureAwait(false);

            EmailNotificationHook getEmailHook = (await adminClient.GetHookAsync(createdEmailHook.Id).ConfigureAwait(false)).Value as EmailNotificationHook;

            getEmailHook.Description = "updated description";
            getEmailHook.EmailsToAlert.Add($"{Recording.GenerateAlphaNumericId("user")}@contoso.com");

            await adminClient.UpdateHookAsync(getEmailHook.Id, getEmailHook).ConfigureAwait(false);

            NotificationHook createdWebHook = await adminClient.CreateHookAsync(new WebNotificationHook(Recording.GenerateAlphaNumericId("test"), "http://contoso.com") { Description = $"{nameof(WebNotificationHook)} description" }).ConfigureAwait(false);

            createdWebHook.Description = "updated description";

            await adminClient.UpdateHookAsync(createdEmailHook.Id, createdEmailHook).ConfigureAwait(false);

            WebNotificationHook getWebHook = (await adminClient.GetHookAsync(createdWebHook.Id).ConfigureAwait(false)).Value as WebNotificationHook;

            getWebHook.Description = "updated description";
            getWebHook.CertificateKey = Recording.GenerateAlphaNumericId("key");

            List<NotificationHook> hooks = await adminClient.GetHooksAsync(new GetHooksOptions { HookNameFilter = getWebHook.Name }).ToEnumerableAsync().ConfigureAwait(false);

            Assert.That(getEmailHook.Id, Is.EqualTo(createdEmailHook.Id));
            Assert.That(getEmailHook.Name, Is.EqualTo(createdEmailHook.Name));
            Assert.That(hooks, Is.Not.Empty);
            Assert.That(hooks.Any(h => h.Name == getWebHook.Name), $"hooks should contain name {createdEmailHook.Name}, but contained names: {string.Join(",", hooks.Select(h => h.Name))}");

            await adminClient.DeleteHookAsync(createdEmailHook.Id).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task ResetDataFeedIngestionStatus()
        {
            var adminClient = GetMetricsAdvisorAdministrationClient();

            await adminClient.RefreshDataFeedIngestionAsync(DataFeedId, new DateTimeOffset(2020, 9, 1, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2020, 9, 2, 0, 0, 0, TimeSpan.Zero)).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task GetMetricAnomalyDetectionConfigurations()
        {
            var adminClient = GetMetricsAdvisorAdministrationClient();

            bool isResponseEmpty = true;

            await foreach (AnomalyDetectionConfiguration config in adminClient.GetMetricAnomalyDetectionConfigurationsAsync(MetricId))
            {
                isResponseEmpty = false;
                break;
            }

            Assert.That(isResponseEmpty, Is.False);
        }
    }
}
