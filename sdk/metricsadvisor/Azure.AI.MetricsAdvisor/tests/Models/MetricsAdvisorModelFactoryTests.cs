// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.AI.MetricsAdvisor.Models;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="MetricsAdvisorModelFactory"/> class.
    /// </summary>
    public class MetricsAdvisorModelFactoryTests
    {
        private readonly DimensionKey SampleDimensionKey = new DimensionKey(new Dictionary<string, string>()
        {
            { "key1", "value1" },
            { "key2", "value2" }
        });

        [Test]
        public void AnomalyAlert()
        {
            var id = "id";
            var timestamp = DateTimeOffset.Parse("2021-01-01T00:00:00Z");
            var createdOn = DateTimeOffset.Parse("2021-02-02T00:00:00Z");
            var lastModified = DateTimeOffset.Parse("2021-03-03T00:00:00Z");

            var anomalyAlert = MetricsAdvisorModelFactory.AnomalyAlert(id, timestamp, createdOn, lastModified);

            Assert.That(anomalyAlert.Id, Is.EqualTo(id));
            Assert.That(anomalyAlert.Timestamp, Is.EqualTo(timestamp));
            Assert.That(anomalyAlert.CreatedOn, Is.EqualTo(createdOn));
            Assert.That(anomalyAlert.LastModified, Is.EqualTo(lastModified));
        }

        [Test]
        public void AnomalyAlertConfiguration()
        {
            var id = "id";
            var name = "name";
            var description = "description";
            var crossMetricsOperator = MetricAlertConfigurationsOperator.Xor;
            var dimensionsToSplitAlert = new List<string>() { "dimension1", "dimension2" };
            var idsOfHooksToAlert = new List<string>() { "hookId1", "hookId2" };
            var metricAlertConfigurations = new List<MetricAlertConfiguration>()
            {
                new MetricAlertConfiguration("detectionConfigId1", MetricAnomalyAlertScope.CreateScopeForWholeSeries()),
                new MetricAlertConfiguration("detectionConfigId2", MetricAnomalyAlertScope.CreateScopeForWholeSeries())
            };

            var anomalyAlertConfiguration = MetricsAdvisorModelFactory.AnomalyAlertConfiguration(id, name, description, crossMetricsOperator,
                dimensionsToSplitAlert, idsOfHooksToAlert, metricAlertConfigurations);

            Assert.That(anomalyAlertConfiguration.Id, Is.EqualTo(id));
            Assert.That(anomalyAlertConfiguration.Name, Is.EqualTo(name));
            Assert.That(anomalyAlertConfiguration.Description, Is.EqualTo(description));
            Assert.That(anomalyAlertConfiguration.CrossMetricsOperator, Is.EqualTo(crossMetricsOperator));
            Assert.That(anomalyAlertConfiguration.DimensionsToSplitAlert, Is.EqualTo(dimensionsToSplitAlert));
            Assert.That(anomalyAlertConfiguration.IdsOfHooksToAlert, Is.EqualTo(idsOfHooksToAlert));
            Assert.That(anomalyAlertConfiguration.MetricAlertConfigurations, Is.EqualTo(metricAlertConfigurations));
        }

        [Test]
        public void AnomalyDetectionConfiguration()
        {
            var id = "id";
            var name = "name";
            var description = "description";
            var metricId = "metricId";
            var wholeSeriesDetectionConditions = new MetricWholeSeriesDetectionCondition();
            var seriesGroupDetectionConditions = new List<MetricSeriesGroupDetectionCondition>()
            {
                new MetricSeriesGroupDetectionCondition(SampleDimensionKey),
                new MetricSeriesGroupDetectionCondition(SampleDimensionKey)
            };
            var seriesDetectionConditions = new List<MetricSingleSeriesDetectionCondition>()
            {
                new MetricSingleSeriesDetectionCondition(SampleDimensionKey),
                new MetricSingleSeriesDetectionCondition(SampleDimensionKey)
            };

            var anomalyDetectionConfiguration = MetricsAdvisorModelFactory.AnomalyDetectionConfiguration(id, name, description, metricId,
                wholeSeriesDetectionConditions, seriesGroupDetectionConditions, seriesDetectionConditions);

            Assert.That(anomalyDetectionConfiguration.Id, Is.EqualTo(id));
            Assert.That(anomalyDetectionConfiguration.Name, Is.EqualTo(name));
            Assert.That(anomalyDetectionConfiguration.Description, Is.EqualTo(description));
            Assert.That(anomalyDetectionConfiguration.MetricId, Is.EqualTo(metricId));
            Assert.That(anomalyDetectionConfiguration.WholeSeriesDetectionConditions, Is.EqualTo(wholeSeriesDetectionConditions));
            Assert.That(anomalyDetectionConfiguration.SeriesGroupDetectionConditions, Is.EqualTo(seriesGroupDetectionConditions));
            Assert.That(anomalyDetectionConfiguration.SeriesDetectionConditions, Is.EqualTo(seriesDetectionConditions));
        }

        [Test]
        public void AnomalyIncident()
        {
            var dataFeedId = "dataFeedId";
            var metricId = "metricId";
            var detectionConfigurationId = "detectionConfigurationId";
            var id = "id";
            var startedOn = DateTimeOffset.Parse("2021-01-01T00:00:00Z");
            var lastDetectedOn = DateTimeOffset.Parse("2021-02-02T00:00:00Z");
            var rootSeriesKey = SampleDimensionKey;
            var severity = AnomalySeverity.High;
            var status = AnomalyIncidentStatus.Resolved;
            var valueOfRootNode = 10.0;
            var expectedValueOfRootNode = 20.0;

            var anomalyIncident = MetricsAdvisorModelFactory.AnomalyIncident(dataFeedId, metricId, detectionConfigurationId,
                id, startedOn, lastDetectedOn, rootSeriesKey, severity, status, valueOfRootNode, expectedValueOfRootNode);

            Assert.That(anomalyIncident.DataFeedId, Is.EqualTo(dataFeedId));
            Assert.That(anomalyIncident.MetricId, Is.EqualTo(metricId));
            Assert.That(anomalyIncident.DetectionConfigurationId, Is.EqualTo(detectionConfigurationId));
            Assert.That(anomalyIncident.Id, Is.EqualTo(id));
            Assert.That(anomalyIncident.StartedOn, Is.EqualTo(startedOn));
            Assert.That(anomalyIncident.LastDetectedOn, Is.EqualTo(lastDetectedOn));
            Assert.That(anomalyIncident.RootSeriesKey, Is.EqualTo(rootSeriesKey));
            Assert.That(anomalyIncident.Severity, Is.EqualTo(severity));
            Assert.That(anomalyIncident.Status, Is.EqualTo(status));
            Assert.That(anomalyIncident.ValueOfRootNode, Is.EqualTo(valueOfRootNode));
            Assert.That(anomalyIncident.ExpectedValueOfRootNode, Is.EqualTo(expectedValueOfRootNode));
        }

        [Test]
        public void DataFeed()
        {
            var id = "id";
            var status = DataFeedStatus.Paused;
            var createdOn = DateTimeOffset.Parse("2021-01-01T00:00:00Z");
            var creator = "creator";
            var isAdministrator = true;
            var metricIds = new Dictionary<string, string>()
            {
                { "key1", "value1" },
                { "key2", "value2" }
            };
            var name = "name";
            var dataSource = new SqlServerDataFeedSource("query");
            var schema = new DataFeedSchema();
            var granularity = new DataFeedGranularity(DataFeedGranularityType.Daily);
            var ingestionSettings = new DataFeedIngestionSettings(DateTimeOffset.UtcNow);
            var description = "description";
            var actionLinkTemplate = "actionLinkTemplate";
            var accessMode = DataFeedAccessMode.Public;
            var rollupSettings = new DataFeedRollupSettings();
            var missingDataPointFillSettings = new DataFeedMissingDataPointFillSettings(DataFeedMissingDataPointFillType.PreviousValue);
            var administrators = new List<string>() { "admin1", "admin2" };
            var viewers = new List<string>() { "viewer1", "viewer2" };

            var dataFeed = MetricsAdvisorModelFactory.DataFeed(id, status, createdOn, creator, isAdministrator, metricIds, name, dataSource,
                schema, granularity, ingestionSettings, description, actionLinkTemplate, accessMode, rollupSettings, missingDataPointFillSettings,
                administrators, viewers);

            Assert.That(dataFeed.Id, Is.EqualTo(id));
            Assert.That(dataFeed.Status, Is.EqualTo(status));
            Assert.That(dataFeed.CreatedOn, Is.EqualTo(createdOn));
            Assert.That(dataFeed.Creator, Is.EqualTo(creator));
            Assert.That(dataFeed.IsAdministrator, Is.EqualTo(isAdministrator));
            Assert.That(dataFeed.MetricIds, Is.EqualTo(metricIds));
            Assert.That(dataFeed.Name, Is.EqualTo(name));
            Assert.That(dataFeed.DataSource, Is.EqualTo(dataSource));
            Assert.That(dataFeed.Schema, Is.EqualTo(schema));
            Assert.That(dataFeed.Granularity, Is.EqualTo(granularity));
            Assert.That(dataFeed.IngestionSettings, Is.EqualTo(ingestionSettings));
            Assert.That(dataFeed.Description, Is.EqualTo(description));
            Assert.That(dataFeed.ActionLinkTemplate, Is.EqualTo(actionLinkTemplate));
            Assert.That(dataFeed.AccessMode, Is.EqualTo(accessMode));
            Assert.That(dataFeed.RollupSettings, Is.EqualTo(rollupSettings));
            Assert.That(dataFeed.MissingDataPointFillSettings, Is.EqualTo(missingDataPointFillSettings));
            Assert.That(dataFeed.Administrators, Is.EqualTo(administrators));
            Assert.That(dataFeed.Viewers, Is.EqualTo(viewers));
        }

        [Test]
        public void DataFeedIngestionProgress()
        {
            var latestSuccessTimestamp = DateTimeOffset.Parse("2021-01-01T00:00:00Z");
            var latestActiveTimestamp = DateTimeOffset.Parse("2021-02-02T00:00:00Z");

            var dataFeedIngestionProgress = MetricsAdvisorModelFactory.DataFeedIngestionProgress(latestSuccessTimestamp, latestActiveTimestamp);

            Assert.That(dataFeedIngestionProgress.LatestSuccessTimestamp, Is.EqualTo(latestSuccessTimestamp));
            Assert.That(dataFeedIngestionProgress.LatestActiveTimestamp, Is.EqualTo(latestActiveTimestamp));
        }

        [Test]
        public void DataFeedIngestionStatus()
        {
            var timestamp = DateTimeOffset.Parse("2021-01-01T00:00:00Z");
            var status = IngestionStatusType.Paused;
            var message = "message";

            var dataFeedIngestionStatus = MetricsAdvisorModelFactory.DataFeedIngestionStatus(timestamp, status, message);

            Assert.That(dataFeedIngestionStatus.Timestamp, Is.EqualTo(timestamp));
            Assert.That(dataFeedIngestionStatus.Status, Is.EqualTo(status));
            Assert.That(dataFeedIngestionStatus.Message, Is.EqualTo(message));
        }

        [Test]
        public void DataFeedMetric()
        {
            var id = "id";
            var name = "name";
            var displayName = "displayName";
            var description = "description";

            var dataFeedMetric = MetricsAdvisorModelFactory.DataFeedMetric(id, name, displayName, description);

            Assert.That(dataFeedMetric.Id, Is.EqualTo(id));
            Assert.That(dataFeedMetric.Name, Is.EqualTo(name));
            Assert.That(dataFeedMetric.DisplayName, Is.EqualTo(displayName));
            Assert.That(dataFeedMetric.Description, Is.EqualTo(description));
        }

        [Test]
        public void DataLakeSharedKeyCredentialEntity()
        {
            var id = "id";
            var name = "name";
            var description = "displayName";
            var accountKey = "accountKey";

            var credentialEntity = MetricsAdvisorModelFactory.DataLakeSharedKeyCredentialEntity(id, name, description, accountKey);

            Assert.That(credentialEntity.Id, Is.EqualTo(id));
            Assert.That(credentialEntity.Name, Is.EqualTo(name));
            Assert.That(credentialEntity.Description, Is.EqualTo(description));
            Assert.That(credentialEntity.AccountKey, Is.EqualTo(accountKey)); // Validation of internal property
        }

        [Test]
        public void DataPointAnomaly()
        {
            var dataFeedId = "dataFeedId";
            var metricId = "metricId";
            var detectionConfigurationId = "detectionConfigurationId";
            var timestamp = DateTimeOffset.Parse("2021-01-01T00:00:00Z");
            var createdOn = DateTimeOffset.Parse("2021-02-02T00:00:00Z");
            var lastModified = DateTimeOffset.Parse("2021-03-03T00:00:00Z");
            var seriesKey = SampleDimensionKey;
            var severity = AnomalySeverity.High;
            var status = AnomalyStatus.Resolved;
            var value = 10.0;
            var expectedValue = 20.0;

            var dataPointAnomaly = MetricsAdvisorModelFactory.DataPointAnomaly(dataFeedId, metricId, detectionConfigurationId,
                timestamp, createdOn, lastModified, seriesKey, severity, status, value, expectedValue);

            Assert.That(dataPointAnomaly.DataFeedId, Is.EqualTo(dataFeedId));
            Assert.That(dataPointAnomaly.MetricId, Is.EqualTo(metricId));
            Assert.That(dataPointAnomaly.DetectionConfigurationId, Is.EqualTo(detectionConfigurationId));
            Assert.That(dataPointAnomaly.Timestamp, Is.EqualTo(timestamp));
            Assert.That(dataPointAnomaly.CreatedOn, Is.EqualTo(createdOn));
            Assert.That(dataPointAnomaly.LastModified, Is.EqualTo(lastModified));
            Assert.That(dataPointAnomaly.SeriesKey, Is.EqualTo(seriesKey));
            Assert.That(dataPointAnomaly.Severity, Is.EqualTo(severity));
            Assert.That(dataPointAnomaly.Status, Is.EqualTo(status));
            Assert.That(dataPointAnomaly.Value, Is.EqualTo(value));
            Assert.That(dataPointAnomaly.ExpectedValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void EmailNotificationHook()
        {
            var id = "id";
            var name = "name";
            var description = "description";
            var externalUri = new Uri("https://fake.endpoint.com/");
            var administrators = new List<string>() { "admin1", "admin2" };
            var emailsToAlert = new List<string>() { "fake1@email.com", "fake2@email.com" };

            var hook = MetricsAdvisorModelFactory.EmailNotificationHook(id, name, description, externalUri, administrators, emailsToAlert);

            Assert.That(hook.Id, Is.EqualTo(id));
            Assert.That(hook.Name, Is.EqualTo(name));
            Assert.That(hook.Description, Is.EqualTo(description));
            Assert.That(hook.ExternalUri, Is.EqualTo(externalUri));
            Assert.That(hook.Administrators, Is.EqualTo(administrators));
            Assert.That(hook.EmailsToAlert, Is.EqualTo(emailsToAlert));
        }

        [Test]
        public void EnrichmentStatus()
        {
            var timestamp = DateTimeOffset.Parse("2021-01-01T00:00:00Z");
            var status = "status";
            var message = "message";

            var enrichmentStatus = MetricsAdvisorModelFactory.EnrichmentStatus(timestamp, status, message);

            Assert.That(enrichmentStatus.Timestamp, Is.EqualTo(timestamp));
            Assert.That(enrichmentStatus.Status, Is.EqualTo(status));
            Assert.That(enrichmentStatus.Message, Is.EqualTo(message));
        }

        [Test]
        public void IncidentRootCause()
        {
            var seriesKey = SampleDimensionKey;
            var paths = new List<string>() { "dimension1", "dimension2" };
            var contributionScore = 0.5;
            var description = "description";

            var incidentRootCause = MetricsAdvisorModelFactory.IncidentRootCause(seriesKey, paths, contributionScore, description);

            Assert.That(incidentRootCause.SeriesKey, Is.EqualTo(seriesKey));
            Assert.That(incidentRootCause.Paths, Is.EqualTo(paths));
            Assert.That(incidentRootCause.ContributionScore, Is.EqualTo(contributionScore));
            Assert.That(incidentRootCause.Description, Is.EqualTo(description));
        }

        [Test]
        public void MetricAnomalyFeedback()
        {
            var id = "id";
            var createdOn = DateTimeOffset.Parse("2021-01-01T00:00:00Z");
            var userPrincipal = "userPrincipal";
            var metricId = "metricId";
            var dimensionKey = SampleDimensionKey;
            var startsOn = DateTimeOffset.Parse("2021-02-02T00:00:00Z");
            var endsOn = DateTimeOffset.Parse("2021-03-03T00:00:00Z");
            var anomalyValue = AnomalyValue.AutoDetect;
            var detectionConfigurationId = "id3";
            var detectionConfigurationSnapshot = MetricsAdvisorModelFactory.AnomalyDetectionConfiguration();

            var feedback = MetricsAdvisorModelFactory.MetricAnomalyFeedback(id, createdOn, userPrincipal, metricId, dimensionKey, startsOn,
                endsOn, anomalyValue, detectionConfigurationId, detectionConfigurationSnapshot);

            Assert.That(feedback.Id, Is.EqualTo(id));
            Assert.That(feedback.CreatedOn, Is.EqualTo(createdOn));
            Assert.That(feedback.UserPrincipal, Is.EqualTo(userPrincipal));
            Assert.That(feedback.MetricId, Is.EqualTo(metricId));
            Assert.That(feedback.DimensionKey, Is.EqualTo(dimensionKey));
            Assert.That(feedback.StartsOn, Is.EqualTo(startsOn));
            Assert.That(feedback.EndsOn, Is.EqualTo(endsOn));
            Assert.That(feedback.AnomalyValue, Is.EqualTo(anomalyValue));
            Assert.That(feedback.DetectionConfigurationId, Is.EqualTo(detectionConfigurationId));
            Assert.That(feedback.DetectionConfigurationSnapshot, Is.EqualTo(detectionConfigurationSnapshot));
        }

        [Test]
        public void MetricChangePointFeedback()
        {
            var id = "id";
            var createdOn = DateTimeOffset.Parse("2021-01-01T00:00:00Z");
            var userPrincipal = "userPrincipal";
            var metricId = "metricId";
            var dimensionKey = SampleDimensionKey;
            var startsOn = DateTimeOffset.Parse("2021-02-02T00:00:00Z");
            var endsOn = DateTimeOffset.Parse("2021-03-03T00:00:00Z");
            var changePointValue = ChangePointValue.AutoDetect;

            var feedback = MetricsAdvisorModelFactory.MetricChangePointFeedback(id, createdOn, userPrincipal, metricId, dimensionKey, startsOn,
                endsOn, changePointValue);

            Assert.That(feedback.Id, Is.EqualTo(id));
            Assert.That(feedback.CreatedOn, Is.EqualTo(createdOn));
            Assert.That(feedback.UserPrincipal, Is.EqualTo(userPrincipal));
            Assert.That(feedback.MetricId, Is.EqualTo(metricId));
            Assert.That(feedback.DimensionKey, Is.EqualTo(dimensionKey));
            Assert.That(feedback.StartsOn, Is.EqualTo(startsOn));
            Assert.That(feedback.EndsOn, Is.EqualTo(endsOn));
            Assert.That(feedback.ChangePointValue, Is.EqualTo(changePointValue));
        }

        [Test]
        public void MetricCommentFeedback()
        {
            var id = "id";
            var createdOn = DateTimeOffset.Parse("2021-01-01T00:00:00Z");
            var userPrincipal = "userPrincipal";
            var metricId = "metricId";
            var dimensionKey = SampleDimensionKey;
            var startsOn = DateTimeOffset.Parse("2021-02-02T00:00:00Z");
            var endsOn = DateTimeOffset.Parse("2021-03-03T00:00:00Z");
            var comment = "comment";

            var feedback = MetricsAdvisorModelFactory.MetricCommentFeedback(id, createdOn, userPrincipal, metricId, dimensionKey, startsOn,
                endsOn, comment);

            Assert.That(feedback.Id, Is.EqualTo(id));
            Assert.That(feedback.CreatedOn, Is.EqualTo(createdOn));
            Assert.That(feedback.UserPrincipal, Is.EqualTo(userPrincipal));
            Assert.That(feedback.MetricId, Is.EqualTo(metricId));
            Assert.That(feedback.DimensionKey, Is.EqualTo(dimensionKey));
            Assert.That(feedback.StartsOn, Is.EqualTo(startsOn));
            Assert.That(feedback.EndsOn, Is.EqualTo(endsOn));
            Assert.That(feedback.Comment, Is.EqualTo(comment));
        }

        [Test]
        public void MetricEnrichedSeriesData()
        {
            var seriesKey = SampleDimensionKey;
            var timestamps = new List<DateTimeOffset>()
            {
                DateTimeOffset.Parse("2021-01-01T00:00:00Z"),
                DateTimeOffset.Parse("2021-02-02T00:00:00Z")
            };
            var metricValues = new List<double>() { 10.0, 20.0 };
            var isAnomaly = new List<bool?>() { true, false };
            var periods = new List<int?>() { 1, 2 };
            var expectedMetricValues = new List<double?>() { 30.0, 40.0 };
            var lowerBoundaryValues = new List<double?>() { 50.0, 60.0 };
            var upperBoundaryValues = new List<double?>() { 70.0, 80.0 };

            var metricEnrichedSeriesData = MetricsAdvisorModelFactory.MetricEnrichedSeriesData(seriesKey, timestamps, metricValues,
                isAnomaly, periods, expectedMetricValues, lowerBoundaryValues, upperBoundaryValues);

            Assert.That(metricEnrichedSeriesData.SeriesKey, Is.EqualTo(seriesKey));
            Assert.That(metricEnrichedSeriesData.Timestamps, Is.EqualTo(timestamps));
            Assert.That(metricEnrichedSeriesData.MetricValues, Is.EqualTo(metricValues));
            Assert.That(metricEnrichedSeriesData.IsAnomaly, Is.EqualTo(isAnomaly));
            Assert.That(metricEnrichedSeriesData.Periods, Is.EqualTo(periods));
            Assert.That(metricEnrichedSeriesData.ExpectedMetricValues, Is.EqualTo(expectedMetricValues));
            Assert.That(metricEnrichedSeriesData.LowerBoundaryValues, Is.EqualTo(lowerBoundaryValues));
            Assert.That(metricEnrichedSeriesData.UpperBoundaryValues, Is.EqualTo(upperBoundaryValues));
        }

        [Test]
        public void MetricPeriodFeedback()
        {
            var id = "id";
            var createdOn = DateTimeOffset.Parse("2021-01-01T00:00:00Z");
            var userPrincipal = "userPrincipal";
            var metricId = "metricId";
            var dimensionKey = SampleDimensionKey;
            var periodType = MetricPeriodType.AutoDetect;
            var periodValue = 10;

            var feedback = MetricsAdvisorModelFactory.MetricPeriodFeedback(id, createdOn, userPrincipal, metricId, dimensionKey, periodType,
                periodValue);

            Assert.That(feedback.Id, Is.EqualTo(id));
            Assert.That(feedback.CreatedOn, Is.EqualTo(createdOn));
            Assert.That(feedback.UserPrincipal, Is.EqualTo(userPrincipal));
            Assert.That(feedback.MetricId, Is.EqualTo(metricId));
            Assert.That(feedback.DimensionKey, Is.EqualTo(dimensionKey));
            Assert.That(feedback.PeriodType, Is.EqualTo(periodType));
            Assert.That(feedback.PeriodValue, Is.EqualTo(periodValue));
        }

        [Test]
        public void MetricSeriesData()
        {
            var metricId = "id";
            var seriesKey = SampleDimensionKey;
            var timestamps = new List<DateTimeOffset>()
            {
                DateTimeOffset.Parse("2021-01-01T00:00:00Z"),
                DateTimeOffset.Parse("2021-02-02T00:00:00Z")
            };
            var metricValues = new List<double>() { 10.0, 20.0 };

            var metricSeriesData = MetricsAdvisorModelFactory.MetricSeriesData(metricId, seriesKey, timestamps, metricValues);

            Assert.That(metricSeriesData.MetricId, Is.EqualTo(metricId));
            Assert.That(metricSeriesData.SeriesKey, Is.EqualTo(seriesKey));
            Assert.That(metricSeriesData.Timestamps, Is.EqualTo(timestamps));
            Assert.That(metricSeriesData.MetricValues, Is.EqualTo(metricValues));
        }

        [Test]
        public void MetricSeriesDefinition()
        {
            var metricId = "id";
            var seriesKey = SampleDimensionKey;

            var metricSeriesDefinition = MetricsAdvisorModelFactory.MetricSeriesDefinition(metricId, seriesKey);

            Assert.That(metricSeriesDefinition.MetricId, Is.EqualTo(metricId));
            Assert.That(metricSeriesDefinition.SeriesKey, Is.EqualTo(seriesKey));
        }

        [Test]
        public void ServicePrincipalCredentialEntity()
        {
            var id = "id";
            var name = "name";
            var description = "displayName";
            var clientId = "clientId";
            var clientSecret = "clientSecret";
            var tenantId = "tenantId";

            var credentialEntity = MetricsAdvisorModelFactory.ServicePrincipalCredentialEntity(id, name, description, clientId, clientSecret, tenantId);

            Assert.That(credentialEntity.Id, Is.EqualTo(id));
            Assert.That(credentialEntity.Name, Is.EqualTo(name));
            Assert.That(credentialEntity.Description, Is.EqualTo(description));
            Assert.That(credentialEntity.ClientId, Is.EqualTo(clientId));
            Assert.That(credentialEntity.ClientSecret, Is.EqualTo(clientSecret)); // Validation of internal property
            Assert.That(credentialEntity.TenantId, Is.EqualTo(tenantId));
        }

        [Test]
        public void ServicePrincipalInKeyVaultCredentialEntity()
        {
            var id = "id";
            var name = "name";
            var description = "displayName";
            var endpoint = new Uri("https://fake.endpoint.com/");
            var keyVaultClientId = "keyVaultClientId";
            var keyVaultClientSecret = "keyVaultClientSecret";
            var secretNameForClientId = "secretNameForClientId";
            var secretNameForClientSecret = "secretNameForClientSecret";
            var tenantId = "tenantId";

            var credentialEntity = MetricsAdvisorModelFactory.ServicePrincipalInKeyVaultCredentialEntity(id, name, description, endpoint, keyVaultClientId, keyVaultClientSecret, secretNameForClientId, secretNameForClientSecret, tenantId);

            Assert.That(credentialEntity.Id, Is.EqualTo(id));
            Assert.That(credentialEntity.Name, Is.EqualTo(name));
            Assert.That(credentialEntity.Description, Is.EqualTo(description));
            Assert.That(credentialEntity.Endpoint, Is.EqualTo(endpoint));
            Assert.That(credentialEntity.KeyVaultClientId, Is.EqualTo(keyVaultClientId));
            Assert.That(credentialEntity.KeyVaultClientSecret, Is.EqualTo(keyVaultClientSecret)); // Validation of internal property
            Assert.That(credentialEntity.SecretNameForClientId, Is.EqualTo(secretNameForClientId));
            Assert.That(credentialEntity.SecretNameForClientSecret, Is.EqualTo(secretNameForClientSecret));
            Assert.That(credentialEntity.TenantId, Is.EqualTo(tenantId));
        }

        [Test]
        public void SqlConnectionStringCredentialEntity()
        {
            var id = "id";
            var name = "name";
            var description = "displayName";
            var connectionString = "connectionString";

            var credentialEntity = MetricsAdvisorModelFactory.SqlConnectionStringCredentialEntity(id, name, description, connectionString);

            Assert.That(credentialEntity.Id, Is.EqualTo(id));
            Assert.That(credentialEntity.Name, Is.EqualTo(name));
            Assert.That(credentialEntity.Description, Is.EqualTo(description));
            Assert.That(credentialEntity.ConnectionString, Is.EqualTo(connectionString)); // Validation of internal property
        }

        [Test]
        public void TopNGroupScope()
        {
            var top = 10;
            var period = 20;
            var minimumTopCount = 30;

            var topNGroupScope = MetricsAdvisorModelFactory.TopNGroupScope(top, period, minimumTopCount);

            Assert.That(topNGroupScope.Top, Is.EqualTo(top));
            Assert.That(topNGroupScope.Period, Is.EqualTo(period));
            Assert.That(topNGroupScope.MinimumTopCount, Is.EqualTo(minimumTopCount));
        }

        [Test]
        public void WebNotificationHook()
        {
            var id = "id";
            var name = "name";
            var description = "description";
            var externalUri = new Uri("https://fake.endpoint1.com/");
            var administrators = new List<string>() { "admin1", "admin2" };
            var endpoint = new Uri("https://fake.endpoint2.com/");
            var username = "username";
            var password = "password";
            var headers = new Dictionary<string, string>()
            {
                { "key1", "value1" },
                { "key2", "value2" }
            };
            var certificateKey = "certificateKey";
            var certificatePassword = "certificatePassword";

            var hook = MetricsAdvisorModelFactory.WebNotificationHook(id, name, description, externalUri, administrators, endpoint,
                username, password, headers, certificateKey, certificatePassword);

            Assert.That(hook.Id, Is.EqualTo(id));
            Assert.That(hook.Name, Is.EqualTo(name));
            Assert.That(hook.Description, Is.EqualTo(description));
            Assert.That(hook.ExternalUri, Is.EqualTo(externalUri));
            Assert.That(hook.Administrators, Is.EqualTo(administrators));
            Assert.That(hook.Endpoint, Is.EqualTo(endpoint));
            Assert.That(hook.Username, Is.EqualTo(username));
            Assert.That(hook.Password, Is.EqualTo(password));
            Assert.That(hook.Headers, Is.EqualTo(headers));
            Assert.That(hook.CertificateKey, Is.EqualTo(certificateKey));
            Assert.That(hook.CertificatePassword, Is.EqualTo(certificatePassword));
        }
    }
}
