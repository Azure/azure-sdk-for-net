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
                Assert.That(feedResult.Administrators, Is.EquivalentTo(feed.Administrators));
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

            DataFeed dataFeed = new DataFeed(_blobFeedName, _blobSource, _dailyGranularity, _dataFeedSchema, _dataFeedIngestionSettings)
            {
                Description = _dataFeedDescription
            };

            string dataFeedId = await adminClient.CreateDataFeedAsync(dataFeed).ConfigureAwait(false);

            Assert.That(dataFeedId, Is.Not.Null);

            dataFeed.Description = Recording.GenerateAlphaNumericId("desc");
            await adminClient.UpdateDataFeedAsync(dataFeedId, dataFeed).ConfigureAwait(false);

            await adminClient.DeleteDataFeedAsync(dataFeedId);
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
        public async Task CreateAndUpdateBlobDataFeedNullOptions()
        {
            var adminClient = GetMetricsAdvisorAdministrationClient();
            InitDataFeedSources();

            DataFeed dataFeed = new DataFeed(_blobFeedName, _blobSource, _dailyGranularity, _dataFeedSchema, _dataFeedIngestionSettings);

            string dataFeedId = await adminClient.CreateDataFeedAsync(dataFeed).ConfigureAwait(false);

            Assert.That(dataFeedId, Is.Not.Null);

            dataFeed.Description = Recording.GenerateAlphaNumericId("desc");

            await adminClient.UpdateDataFeedAsync(dataFeedId, dataFeed).ConfigureAwait(false);

            await adminClient.DeleteDataFeedAsync(dataFeedId).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task MetricAnomalyDetectionConfigurationOperations()
        {
            var adminClient = GetMetricsAdvisorAdministrationClient();
            string createdConfigurationId = await CreateDetectionConfiguration(adminClient).ConfigureAwait(false);

            Assert.That(createdConfigurationId, Is.Not.Null);

            AnomalyDetectionConfiguration getConfig = await adminClient.GetDetectionConfigurationAsync(createdConfigurationId).ConfigureAwait(false);

            Assert.That(getConfig.Id, Is.EqualTo(createdConfigurationId));

            getConfig.Description = "updated";

            await adminClient.UpdateDetectionConfigurationAsync(getConfig.Id, getConfig).ConfigureAwait(false);

            // try an update with a user instantiated model.
            AnomalyDetectionConfiguration userCreatedModel = PopulateMetricAnomalyDetectionConfiguration(MetricId);
            userCreatedModel.Description = "updated again!";

            await adminClient.UpdateDetectionConfigurationAsync(getConfig.Id, userCreatedModel).ConfigureAwait(false);

            getConfig = await adminClient.GetDetectionConfigurationAsync(getConfig.Id).ConfigureAwait(false);

            Assert.That(getConfig.Description, Is.EqualTo(userCreatedModel.Description));

            await adminClient.DeleteDetectionConfigurationAsync(createdConfigurationId).ConfigureAwait(false);
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
            string createdAnomalyDetectionConfigurationId = await CreateDetectionConfiguration(adminClient).ConfigureAwait(false);

            var alertConfigToCreate = new AnomalyAlertConfiguration(
                    Recording.GenerateAlphaNumericId("test"),
                    new List<string>(),
                    new List<MetricAnomalyAlertConfiguration>
                    {
                        new MetricAnomalyAlertConfiguration(
                            createdAnomalyDetectionConfigurationId,
                            new MetricAnomalyAlertScope(
                                MetricAnomalyAlertScopeType.TopN,
                                new DimensionKey(new List<KeyValuePair<string, string>>
                                {
                                    new KeyValuePair<string, string>("test", "test2")
                                }),
                                new TopNGroupScope(8, 4, 2)))
                    });

            string createdAlertConfigId = await adminClient.CreateAlertConfigurationAsync(alertConfigToCreate).ConfigureAwait(false);

            Assert.That(createdAlertConfigId, Is.Not.Null);

            // Validate that we can Get the newly created config
            AnomalyAlertConfiguration getAlertConfig = await adminClient.GetAlertConfigurationAsync(createdAlertConfigId).ConfigureAwait(false);

            List<AnomalyAlertConfiguration> getAlertConfigs = new List<AnomalyAlertConfiguration>();

            await foreach (var config in adminClient.GetAlertConfigurationsAsync(createdAnomalyDetectionConfigurationId))
            {
                getAlertConfigs.Add(config);
            }

            Assert.That(getAlertConfig.Id, Is.EqualTo(createdAlertConfigId));
            Assert.That(getAlertConfigs.Any(c => c.Id == createdAlertConfigId));

            getAlertConfig.Description = "Updated";
            getAlertConfig.CrossMetricsOperator = MetricAnomalyAlertConfigurationsOperator.And;

            await adminClient.UpdateAlertConfigurationAsync(getAlertConfig.Id, getAlertConfig).ConfigureAwait(false);

            // Validate that the update succeeded.
            getAlertConfig = await adminClient.GetAlertConfigurationAsync(createdAlertConfigId).ConfigureAwait(false);

            Assert.That(getAlertConfig.Description, Is.EqualTo(getAlertConfig.Description));

            // Update again starting with our locally created model.
            alertConfigToCreate.Description = "updated again!";
            alertConfigToCreate.CrossMetricsOperator = MetricAnomalyAlertConfigurationsOperator.And;
            await adminClient.UpdateAlertConfigurationAsync(getAlertConfig.Id, alertConfigToCreate).ConfigureAwait(false);

            // Validate that the update succeeded.
            getAlertConfig = await adminClient.GetAlertConfigurationAsync(createdAlertConfigId).ConfigureAwait(false);

            Assert.That(getAlertConfig.Description, Is.EqualTo(alertConfigToCreate.Description));

            // Cleanup
            await adminClient.DeleteAlertConfigurationAsync(createdAlertConfigId).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task HookOperations()
        {
            var adminClient = GetMetricsAdvisorAdministrationClient();
            var emailHook = new EmailNotificationHook(Recording.GenerateAlphaNumericId("test"), new List<string> { "foo@contoso.com" }) { Description = $"{nameof(EmailNotificationHook)} description" };

            string createdEmailHookId = await adminClient.CreateHookAsync(emailHook).ConfigureAwait(false);

            EmailNotificationHook getEmailHook = (await adminClient.GetHookAsync(createdEmailHookId).ConfigureAwait(false)).Value as EmailNotificationHook;

            getEmailHook.Description = "updated description";
            getEmailHook.EmailsToAlert.Add($"{Recording.GenerateAlphaNumericId("user")}@contoso.com");

            await adminClient.UpdateHookAsync(getEmailHook.Id, getEmailHook).ConfigureAwait(false);

            var webHook = new WebNotificationHook(Recording.GenerateAlphaNumericId("test"), "http://contoso.com") { Description = $"{nameof(WebNotificationHook)} description" };

            string createdWebHookId = await adminClient.CreateHookAsync(webHook).ConfigureAwait(false);

            webHook.Description = "updated description";

            await adminClient.UpdateHookAsync(createdEmailHookId, emailHook).ConfigureAwait(false);

            WebNotificationHook getWebHook = (await adminClient.GetHookAsync(createdWebHookId).ConfigureAwait(false)).Value as WebNotificationHook;

            getWebHook.Description = "updated description";
            getWebHook.CertificateKey = Recording.GenerateAlphaNumericId("key");

            List<NotificationHook> hooks = await adminClient.GetHooksAsync(new GetHooksOptions { HookNameFilter = getWebHook.Name }).ToEnumerableAsync().ConfigureAwait(false);

            Assert.That(getEmailHook.Id, Is.EqualTo(createdEmailHookId));
            Assert.That(getEmailHook.Name, Is.EqualTo(emailHook.Name));
            Assert.That(hooks, Is.Not.Empty);
            Assert.That(hooks.Any(h => h.Name == getWebHook.Name), $"hooks should contain name {emailHook.Name}, but contained names: {string.Join(",", hooks.Select(h => h.Name))}");

            await adminClient.DeleteHookAsync(createdEmailHookId).ConfigureAwait(false);
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

            await foreach (AnomalyDetectionConfiguration config in adminClient.GetDetectionConfigurationsAsync(MetricId))
            {
                isResponseEmpty = false;
                break;
            }

            Assert.That(isResponseEmpty, Is.False);
        }
    }
}
