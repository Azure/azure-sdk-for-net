// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.AI.MetricsAdvisor.Administration;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// A factory that builds Azure.AI.MetricsAdvisor and Azure.AI.MetricsAdvisor.Administration
    /// model types used for mocking.
    /// </summary>
    [CodeGenType("AIMetricsAdvisorModelFactory")]
    [CodeGenSuppress("DataFeedDimension", typeof(string), typeof(string))]
    public static partial class MetricsAdvisorModelFactory
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Models.AnomalyAlert"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="AnomalyAlert.Id"/> property.</param>
        /// <param name="timestamp">Sets the <see cref="AnomalyAlert.Timestamp"/> property.</param>
        /// <param name="createdOn">Sets the <see cref="AnomalyAlert.CreatedOn"/> property.</param>
        /// <param name="lastModified">Sets the <see cref="AnomalyAlert.LastModified"/> property.</param>
        /// <returns>A new instance of <see cref="Models.AnomalyAlert"/> for mocking purposes.</returns>
        public static AnomalyAlert AnomalyAlert(string id = null, DateTimeOffset timestamp = default, DateTimeOffset createdOn = default, DateTimeOffset lastModified = default)
        {
            return new AnomalyAlert(id, timestamp, createdOn, lastModified);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Models.AnomalyAlertConfiguration"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="AnomalyAlertConfiguration.Id"/> property.</param>
        /// <param name="name">Sets the <see cref="AnomalyAlertConfiguration.Name"/> property.</param>
        /// <param name="description">Sets the <see cref="AnomalyAlertConfiguration.Description"/> property.</param>
        /// <param name="crossMetricsOperator">Sets the <see cref="AnomalyAlertConfiguration.CrossMetricsOperator"/> property.</param>
        /// <param name="dimensionsToSplitAlert">Sets the <see cref="AnomalyAlertConfiguration.DimensionsToSplitAlert"/> property.</param>
        /// <param name="idsOfHooksToAlert">Sets the <see cref="AnomalyAlertConfiguration.IdsOfHooksToAlert"/> property.</param>
        /// <param name="metricAlertConfigurations">Sets the <see cref="AnomalyAlertConfiguration.MetricAlertConfigurations"/> property.</param>
        /// <returns>A new instance of <see cref="Models.AnomalyAlertConfiguration"/> for mocking purposes.</returns>
        public static AnomalyAlertConfiguration AnomalyAlertConfiguration(string id = null, string name = null, string description = null, MetricAlertConfigurationsOperator? crossMetricsOperator = null, IEnumerable<string> dimensionsToSplitAlert = null, IEnumerable<string> idsOfHooksToAlert = null, IEnumerable<MetricAlertConfiguration> metricAlertConfigurations = null)
        {
            dimensionsToSplitAlert ??= new List<string>();
            idsOfHooksToAlert ??= new List<string>();
            metricAlertConfigurations ??= new List<MetricAlertConfiguration>();

            return new AnomalyAlertConfiguration(id, name, description, crossMetricsOperator, dimensionsToSplitAlert?.ToList(), idsOfHooksToAlert?.ToList(), metricAlertConfigurations?.ToList());
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Models.AnomalyDetectionConfiguration"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="AnomalyDetectionConfiguration.Id"/> property.</param>
        /// <param name="name">Sets the <see cref="AnomalyDetectionConfiguration.Name"/> property.</param>
        /// <param name="description">Sets the <see cref="AnomalyDetectionConfiguration.Description"/> property.</param>
        /// <param name="metricId">Sets the <see cref="AnomalyDetectionConfiguration.MetricId"/> property.</param>
        /// <param name="wholeSeriesDetectionConditions">Sets the <see cref="AnomalyDetectionConfiguration.WholeSeriesDetectionConditions"/> property.</param>
        /// <param name="seriesGroupDetectionConditions">Sets the <see cref="AnomalyDetectionConfiguration.SeriesGroupDetectionConditions"/> property.</param>
        /// <param name="seriesDetectionConditions">Sets the <see cref="AnomalyDetectionConfiguration.SeriesDetectionConditions"/> property.</param>
        /// <returns>A new instance of <see cref="Models.AnomalyDetectionConfiguration"/> for mocking purposes.</returns>
        public static AnomalyDetectionConfiguration AnomalyDetectionConfiguration(string id = null, string name = null, string description = null, string metricId = null, MetricWholeSeriesDetectionCondition wholeSeriesDetectionConditions = null, IEnumerable<MetricSeriesGroupDetectionCondition> seriesGroupDetectionConditions = null, IEnumerable<MetricSingleSeriesDetectionCondition> seriesDetectionConditions = null)
        {
            seriesGroupDetectionConditions ??= new List<MetricSeriesGroupDetectionCondition>();
            seriesDetectionConditions ??= new List<MetricSingleSeriesDetectionCondition>();

            return new AnomalyDetectionConfiguration(id, name, description, metricId, wholeSeriesDetectionConditions, seriesGroupDetectionConditions?.ToList(), seriesDetectionConditions?.ToList());
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Models.AnomalyIncident"/> for mocking purposes.
        /// </summary>
        /// <param name="dataFeedId">Sets the <see cref="AnomalyIncident.DataFeedId"/> property.</param>
        /// <param name="metricId">Sets the <see cref="AnomalyIncident.MetricId"/> property.</param>
        /// <param name="detectionConfigurationId">Sets the <see cref="AnomalyIncident.DetectionConfigurationId"/> property.</param>
        /// <param name="id">Sets the <see cref="AnomalyIncident.Id"/> property.</param>
        /// <param name="startedOn">Sets the <see cref="AnomalyIncident.StartedOn"/> property.</param>
        /// <param name="lastDetectedOn">Sets the <see cref="AnomalyIncident.LastDetectedOn"/> property.</param>
        /// <param name="rootSeriesKey">Sets the <see cref="AnomalyIncident.RootSeriesKey"/> property.</param>
        /// <param name="severity">Sets the <see cref="AnomalyIncident.Severity"/> property.</param>
        /// <param name="status">Sets the <see cref="AnomalyIncident.Status"/> property.</param>
        /// <param name="valueOfRootNode">Sets the <see cref="AnomalyIncident.ValueOfRootNode"/> property.</param>
        /// <param name="expectedValueOfRootNode">Sets the <see cref="AnomalyIncident.ExpectedValueOfRootNode"/> property.</param>
        /// <returns>A new instance of <see cref="Models.AnomalyIncident"/> for mocking purposes.</returns>
        public static AnomalyIncident AnomalyIncident(string dataFeedId = null, string metricId = null, string detectionConfigurationId = null, string id = null, DateTimeOffset startedOn = default, DateTimeOffset lastDetectedOn = default, DimensionKey rootSeriesKey = null, AnomalySeverity severity = default, AnomalyIncidentStatus status = default, double valueOfRootNode = default, double? expectedValueOfRootNode = null)
        {
            Dictionary<string, string> dimensions = rootSeriesKey?.ToDictionary(key => key.Key, key => key.Value);
            IncidentProperty incidentProperty = new IncidentProperty(severity, status, valueOfRootNode, expectedValueOfRootNode);

            return new AnomalyIncident(dataFeedId, metricId, detectionConfigurationId, id, startedOn, lastDetectedOn, new SeriesIdentity(dimensions), incidentProperty);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Models.DataFeed"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="DataFeed.Id"/> property.</param>
        /// <param name="status">Sets the <see cref="DataFeed.Status"/> property.</param>
        /// <param name="createdOn">Sets the <see cref="DataFeed.CreatedOn"/> property.</param>
        /// <param name="creator">Sets the <see cref="DataFeed.Creator"/> property.</param>
        /// <param name="isAdministrator">Sets the <see cref="DataFeed.IsAdministrator"/> property.</param>
        /// <param name="metricIds">Sets the <see cref="DataFeed.MetricIds"/> property.</param>
        /// <param name="name">Sets the <see cref="DataFeed.Name"/> property.</param>
        /// <param name="dataSource">Sets the <see cref="DataFeed.DataSource"/> property.</param>
        /// <param name="schema">Sets the <see cref="DataFeed.Schema"/> property.</param>
        /// <param name="granularity">Sets the <see cref="DataFeed.Granularity"/> property.</param>
        /// <param name="ingestionSettings">Sets the <see cref="DataFeed.IngestionSettings"/> property.</param>
        /// <param name="description">Sets the <see cref="DataFeed.Description"/> property.</param>
        /// <param name="actionLinkTemplate">Sets the <see cref="DataFeed.ActionLinkTemplate"/> property.</param>
        /// <param name="accessMode">Sets the <see cref="DataFeed.AccessMode"/> property.</param>
        /// <param name="rollupSettings">Sets the <see cref="DataFeed.RollupSettings"/> property.</param>
        /// <param name="missingDataPointFillSettings">Sets the <see cref="DataFeed.MissingDataPointFillSettings"/> property.</param>
        /// <param name="administrators">Sets the <see cref="DataFeed.Administrators"/> property.</param>
        /// <param name="viewers">Sets the <see cref="DataFeed.Viewers"/> property.</param>
        /// <returns>A new instance of <see cref="Models.AnomalyIncident"/> for mocking purposes.</returns>
        public static DataFeed DataFeed(string id = null, DataFeedStatus? status = null, DateTimeOffset? createdOn = null, string creator = null, bool? isAdministrator = null, IReadOnlyDictionary<string, string> metricIds = null, string name = null, DataFeedSource dataSource = null, DataFeedSchema schema = null, DataFeedGranularity granularity = null, DataFeedIngestionSettings ingestionSettings = null, string description = null, string actionLinkTemplate = null, DataFeedAccessMode? accessMode = null, DataFeedRollupSettings rollupSettings = null, DataFeedMissingDataPointFillSettings missingDataPointFillSettings = null, IEnumerable<string> administrators = null, IEnumerable<string> viewers = null)
        {
            metricIds = metricIds ?? new Dictionary<string, string>();
            administrators = administrators ?? new List<string>();
            viewers = viewers ?? new List<string>();

            return new DataFeed(id, status, createdOn, creator, isAdministrator, metricIds, name, dataSource, schema, granularity, ingestionSettings, description, actionLinkTemplate, accessMode, rollupSettings, missingDataPointFillSettings, administrators.ToList(), viewers.ToList());
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Models.DataFeedIngestionProgress"/> for mocking purposes.
        /// </summary>
        /// <param name="latestSuccessTimestamp">Sets the <see cref="DataFeedIngestionProgress.LatestSuccessTimestamp"/> property.</param>
        /// <param name="latestActiveTimestamp">Sets the <see cref="DataFeedIngestionProgress.LatestActiveTimestamp"/> property.</param>
        /// <returns>A new instance of <see cref="Models.DataFeedIngestionProgress"/> for mocking purposes.</returns>
        public static DataFeedIngestionProgress DataFeedIngestionProgress(DateTimeOffset? latestSuccessTimestamp = null, DateTimeOffset? latestActiveTimestamp = null)
        {
            return new DataFeedIngestionProgress(latestSuccessTimestamp, latestActiveTimestamp);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Models.DataFeedIngestionStatus"/> for mocking purposes.
        /// </summary>
        /// <param name="timestamp">Sets the <see cref="DataFeedIngestionStatus.Timestamp"/> property.</param>
        /// <param name="status">Sets the <see cref="DataFeedIngestionStatus.Status"/> property.</param>
        /// <param name="message">Sets the <see cref="DataFeedIngestionStatus.Message"/> property.</param>
        /// <returns>A new instance of <see cref="Models.DataFeedIngestionStatus"/> for mocking purposes.</returns>
        public static DataFeedIngestionStatus DataFeedIngestionStatus(DateTimeOffset timestamp = default, IngestionStatusType status = default, string message = null)
        {
            return new DataFeedIngestionStatus(timestamp, status, message);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Models.DataFeedMetric"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="DataFeedMetric.Id"/> property.</param>
        /// <param name="name">Sets the <see cref="DataFeedMetric.Name"/> property.</param>
        /// <param name="displayName">Sets the <see cref="DataFeedMetric.DisplayName"/> property.</param>
        /// <param name="description">Sets the <see cref="DataFeedMetric.Description"/> property.</param>
        /// <returns>A new instance of <see cref="Models.DataFeedMetric"/> for mocking purposes.</returns>
        public static DataFeedMetric DataFeedMetric(string id = null, string name = null, string displayName = null, string description = null)
        {
            return new DataFeedMetric(id, name, displayName, description);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Administration.DataLakeSharedKeyCredentialEntity"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="DataSourceCredentialEntity.Id"/> property.</param>
        /// <param name="name">Sets the <see cref="DataSourceCredentialEntity.Name"/> property.</param>
        /// <param name="description">Sets the <see cref="DataSourceCredentialEntity.Description"/> property.</param>
        /// <param name="accountKey">Sets the account key. This secret is not exposed in a property.</param>
        /// <returns>A new instance of <see cref="Administration.DataLakeSharedKeyCredentialEntity"/> for mocking purposes.</returns>
        public static DataLakeSharedKeyCredentialEntity DataLakeSharedKeyCredentialEntity(string id = null, string name = null, string description = null, string accountKey = null)
        {
            DataLakeGen2SharedKeyParam parameters = new DataLakeGen2SharedKeyParam(accountKey);

            return new DataLakeSharedKeyCredentialEntity(DataSourceCredentialKind.DataLakeSharedKey, id, name, description, parameters);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Models.DataPointAnomaly"/> for mocking purposes.
        /// </summary>
        /// <param name="dataFeedId">Sets the <see cref="DataPointAnomaly.DataFeedId"/> property.</param>
        /// <param name="metricId">Sets the <see cref="DataPointAnomaly.MetricId"/> property.</param>
        /// <param name="detectionConfigurationId">Sets the <see cref="DataPointAnomaly.DetectionConfigurationId"/> property.</param>
        /// <param name="timestamp">Sets the <see cref="DataPointAnomaly.Timestamp"/> property.</param>
        /// <param name="createdOn">Sets the <see cref="DataPointAnomaly.CreatedOn"/> property.</param>
        /// <param name="lastModified">Sets the <see cref="DataPointAnomaly.LastModified"/> property.</param>
        /// <param name="seriesKey">Sets the <see cref="DataPointAnomaly.SeriesKey"/> property.</param>
        /// <param name="severity">Sets the <see cref="DataPointAnomaly.Severity"/> property.</param>
        /// <param name="status">Sets the <see cref="DataPointAnomaly.Status"/> property.</param>
        /// <param name="value">Sets the <see cref="DataPointAnomaly.Value"/> property.</param>
        /// <param name="expectedValue">Sets the <see cref="DataPointAnomaly.ExpectedValue"/> property.</param>
        /// <returns>A new instance of <see cref="Models.DataPointAnomaly"/> for mocking purposes.</returns>
        public static DataPointAnomaly DataPointAnomaly(string dataFeedId = null, string metricId = null, string detectionConfigurationId = null, DateTimeOffset timestamp = default, DateTimeOffset? createdOn = null, DateTimeOffset? lastModified = null, DimensionKey seriesKey = null, AnomalySeverity severity = default, AnomalyStatus? status = null, double value = default, double? expectedValue = null)
        {
            Dictionary<string, string> dimensions = seriesKey?.ToDictionary(key => key.Key, key => key.Value);
            AnomalyProperty anomalyProperty = new AnomalyProperty(severity, status, value, expectedValue);

            return new DataPointAnomaly(dataFeedId, metricId, detectionConfigurationId, timestamp, createdOn, lastModified, dimensions, anomalyProperty);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Administration.EmailNotificationHook"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="NotificationHook.Id"/> property.</param>
        /// <param name="name">Sets the <see cref="NotificationHook.Name"/> property.</param>
        /// <param name="description">Sets the <see cref="NotificationHook.Description"/> property.</param>
        /// <param name="externalUri">Sets the <see cref="NotificationHook.ExternalUri"/> property.</param>
        /// <param name="administrators">Sets the <see cref="NotificationHook.Administrators"/> property.</param>
        /// <param name="emailsToAlert">Sets the <see cref="EmailNotificationHook.EmailsToAlert"/> property.</param>
        /// <returns>A new instance of <see cref="Administration.EmailNotificationHook"/> for mocking purposes.</returns>
        public static EmailNotificationHook EmailNotificationHook(string id = null, string name = null, string description = null, Uri externalUri = null, IEnumerable<string> administrators = null, IEnumerable<string> emailsToAlert = null)
        {
            administrators ??= new List<string>();
            emailsToAlert ??= new List<string>();

            EmailHookParameter parameter = new EmailHookParameter(emailsToAlert.ToList());

            return new EmailNotificationHook(NotificationHookKind.Email, id, name, description, externalUri?.AbsoluteUri, administrators.ToList(), parameter);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Models.EnrichmentStatus"/> for mocking purposes.
        /// </summary>
        /// <param name="timestamp">Sets the <see cref="EnrichmentStatus.Timestamp"/> property.</param>
        /// <param name="status">Sets the <see cref="EnrichmentStatus.Status"/> property.</param>
        /// <param name="message">Sets the <see cref="EnrichmentStatus.Message"/> property.</param>
        /// <returns>A new instance of <see cref="Models.EnrichmentStatus"/> for mocking purposes.</returns>
        public static EnrichmentStatus EnrichmentStatus(DateTimeOffset timestamp = default, string status = null, string message = null)
        {
            return new EnrichmentStatus(timestamp, status, message);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Models.IncidentRootCause"/> for mocking purposes.
        /// </summary>
        /// <param name="seriesKey">Sets the <see cref="IncidentRootCause.SeriesKey"/> property.</param>
        /// <param name="paths">Sets the <see cref="IncidentRootCause.Paths"/> property.</param>
        /// <param name="contributionScore">Sets the <see cref="IncidentRootCause.ContributionScore"/> property.</param>
        /// <param name="description">Sets the <see cref="IncidentRootCause.Description"/> property.</param>
        /// <returns>A new instance of <see cref="Models.IncidentRootCause"/> for mocking purposes.</returns>
        public static IncidentRootCause IncidentRootCause(DimensionKey seriesKey = null, IEnumerable<string> paths = null, double contributionScore = default, string description = null)
        {
            paths ??= new List<string>();

            return new IncidentRootCause(seriesKey, paths, contributionScore, description);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="MetricsAdvisor.MetricAnomalyFeedback"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="MetricFeedback.Id"/> property.</param>
        /// <param name="createdOn">Sets the <see cref="MetricFeedback.CreatedOn"/> property.</param>
        /// <param name="userPrincipal">Sets the <see cref="MetricFeedback.UserPrincipal"/> property.</param>
        /// <param name="metricId">Sets the <see cref="MetricFeedback.MetricId"/> property.</param>
        /// <param name="dimensionKey">Sets the <see cref="MetricFeedback.DimensionKey"/> property.</param>
        /// <param name="startsOn">Sets the <see cref="MetricAnomalyFeedback.StartsOn"/> property.</param>
        /// <param name="endsOn">Sets the <see cref="MetricAnomalyFeedback.EndsOn"/> property.</param>
        /// <param name="anomalyValue">Sets the <see cref="MetricAnomalyFeedback.AnomalyValue"/> property.</param>
        /// <param name="detectionConfigurationId">Sets the <see cref="MetricAnomalyFeedback.DetectionConfigurationId"/> property.</param>
        /// <param name="detectionConfigurationSnapshot">Sets the <see cref="MetricAnomalyFeedback.DetectionConfigurationSnapshot"/> property.</param>
        /// <returns>A new instance of <see cref="MetricsAdvisor.MetricAnomalyFeedback"/> for mocking purposes.</returns>
        public static MetricAnomalyFeedback MetricAnomalyFeedback(string id = null, DateTimeOffset? createdOn = null, string userPrincipal = null, string metricId = null, DimensionKey dimensionKey = null, DateTimeOffset startsOn = default, DateTimeOffset endsOn = default, AnomalyValue anomalyValue = default, string detectionConfigurationId = null, AnomalyDetectionConfiguration detectionConfigurationSnapshot = null)
        {
            Dictionary<string, string> dimensions = dimensionKey?.ToDictionary(key => key.Key, key => key.Value);
            FeedbackFilter filter = new FeedbackFilter(dimensions);
            AnomalyFeedbackValue feedbackValue = new AnomalyFeedbackValue(anomalyValue);

            return new MetricAnomalyFeedback(MetricFeedbackKind.Anomaly, id, createdOn, userPrincipal, metricId, filter, startsOn, endsOn, feedbackValue, detectionConfigurationId, detectionConfigurationSnapshot);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="MetricsAdvisor.MetricChangePointFeedback"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="MetricFeedback.Id"/> property.</param>
        /// <param name="createdOn">Sets the <see cref="MetricFeedback.CreatedOn"/> property.</param>
        /// <param name="userPrincipal">Sets the <see cref="MetricFeedback.UserPrincipal"/> property.</param>
        /// <param name="metricId">Sets the <see cref="MetricFeedback.MetricId"/> property.</param>
        /// <param name="dimensionKey">Sets the <see cref="MetricFeedback.DimensionKey"/> property.</param>
        /// <param name="startsOn">Sets the <see cref="MetricChangePointFeedback.StartsOn"/> property.</param>
        /// <param name="endsOn">Sets the <see cref="MetricChangePointFeedback.EndsOn"/> property.</param>
        /// <param name="changePointValue">Sets the <see cref="MetricChangePointFeedback.ChangePointValue"/> property.</param>
        /// <returns>A new instance of <see cref="MetricsAdvisor.MetricChangePointFeedback"/> for mocking purposes.</returns>
        public static MetricChangePointFeedback MetricChangePointFeedback(string id = null, DateTimeOffset? createdOn = null, string userPrincipal = null, string metricId = null, DimensionKey dimensionKey = null, DateTimeOffset startsOn = default, DateTimeOffset endsOn = default, ChangePointValue changePointValue = default)
        {
            Dictionary<string, string> dimensions = dimensionKey?.ToDictionary(key => key.Key, key => key.Value);
            FeedbackFilter filter = new FeedbackFilter(dimensions);
            ChangePointFeedbackValue feedbackValue = new ChangePointFeedbackValue(changePointValue);

            return new MetricChangePointFeedback(MetricFeedbackKind.ChangePoint, id, createdOn, userPrincipal, metricId, filter, startsOn, endsOn, feedbackValue);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="MetricsAdvisor.MetricCommentFeedback"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="MetricFeedback.Id"/> property.</param>
        /// <param name="createdOn">Sets the <see cref="MetricFeedback.CreatedOn"/> property.</param>
        /// <param name="userPrincipal">Sets the <see cref="MetricFeedback.UserPrincipal"/> property.</param>
        /// <param name="metricId">Sets the <see cref="MetricFeedback.MetricId"/> property.</param>
        /// <param name="dimensionKey">Sets the <see cref="MetricFeedback.DimensionKey"/> property.</param>
        /// <param name="startsOn">Sets the <see cref="MetricCommentFeedback.StartsOn"/> property.</param>
        /// <param name="endsOn">Sets the <see cref="MetricCommentFeedback.EndsOn"/> property.</param>
        /// <param name="comment">Sets the <see cref="MetricCommentFeedback.Comment"/> property.</param>
        /// <returns>A new instance of <see cref="MetricsAdvisor.MetricCommentFeedback"/> for mocking purposes.</returns>
        public static MetricCommentFeedback MetricCommentFeedback(string id = null, DateTimeOffset? createdOn = null, string userPrincipal = null, string metricId = null, DimensionKey dimensionKey = null, DateTimeOffset? startsOn = null, DateTimeOffset? endsOn = null, string comment = null)
        {
            Dictionary<string, string> dimensions = dimensionKey?.ToDictionary(key => key.Key, key => key.Value);
            FeedbackFilter filter = new FeedbackFilter(dimensions);
            CommentFeedbackValue feedbackValue = new CommentFeedbackValue(comment);

            return new MetricCommentFeedback(MetricFeedbackKind.Comment, id, createdOn, userPrincipal, metricId, filter, startsOn, endsOn, feedbackValue);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Models.MetricEnrichedSeriesData"/> for mocking purposes.
        /// </summary>
        /// <param name="seriesKey">Sets the <see cref="MetricEnrichedSeriesData.SeriesKey"/> property.</param>
        /// <param name="timestamps">Sets the <see cref="MetricEnrichedSeriesData.Timestamps"/> property.</param>
        /// <param name="metricValues">Sets the <see cref="MetricEnrichedSeriesData.MetricValues"/> property.</param>
        /// <param name="isAnomaly">Sets the <see cref="MetricEnrichedSeriesData.IsAnomaly"/> property.</param>
        /// <param name="periods">Sets the <see cref="MetricEnrichedSeriesData.Periods"/> property.</param>
        /// <param name="expectedMetricValues">Sets the <see cref="MetricEnrichedSeriesData.ExpectedMetricValues"/> property.</param>
        /// <param name="lowerBoundaryValues">Sets the <see cref="MetricEnrichedSeriesData.LowerBoundaryValues"/> property.</param>
        /// <param name="upperBoundaryValues">Sets the <see cref="MetricEnrichedSeriesData.UpperBoundaryValues"/> property.</param>
        /// <returns>A new instance of <see cref="Models.MetricEnrichedSeriesData"/> for mocking purposes.</returns>
        public static MetricEnrichedSeriesData MetricEnrichedSeriesData(DimensionKey seriesKey = null, IEnumerable<DateTimeOffset> timestamps = null, IEnumerable<double> metricValues = null, IEnumerable<bool?> isAnomaly = null, IEnumerable<int?> periods = null, IEnumerable<double?> expectedMetricValues = null, IEnumerable<double?> lowerBoundaryValues = null, IEnumerable<double?> upperBoundaryValues = null)
        {
            timestamps ??= new List<DateTimeOffset>();
            metricValues ??= new List<double>();
            isAnomaly ??= new List<bool?>();
            periods ??= new List<int?>();
            expectedMetricValues ??= new List<double?>();
            lowerBoundaryValues ??= new List<double?>();
            upperBoundaryValues ??= new List<double?>();

            Dictionary<string, string> dimensions = seriesKey?.ToDictionary(key => key.Key, key => key.Value);

            return new MetricEnrichedSeriesData(new SeriesIdentity(dimensions), timestamps?.ToList(), metricValues?.ToList(), isAnomaly?.ToList(), periods?.ToList(), expectedMetricValues?.ToList(), lowerBoundaryValues?.ToList(), upperBoundaryValues?.ToList());
        }

        /// <summary>
        /// Initializes a new instance of <see cref="MetricsAdvisor.MetricPeriodFeedback"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="MetricFeedback.Id"/> property.</param>
        /// <param name="createdOn">Sets the <see cref="MetricFeedback.CreatedOn"/> property.</param>
        /// <param name="userPrincipal">Sets the <see cref="MetricFeedback.UserPrincipal"/> property.</param>
        /// <param name="metricId">Sets the <see cref="MetricFeedback.MetricId"/> property.</param>
        /// <param name="dimensionKey">Sets the <see cref="MetricFeedback.DimensionKey"/> property.</param>
        /// <param name="periodType">Sets the <see cref="MetricPeriodFeedback.PeriodType"/> property.</param>
        /// <param name="periodValue">Sets the <see cref="MetricPeriodFeedback.PeriodValue"/> property.</param>
        /// <returns>A new instance of <see cref="MetricsAdvisor.MetricPeriodFeedback"/> for mocking purposes.</returns>
        public static MetricPeriodFeedback MetricPeriodFeedback(string id = null, DateTimeOffset? createdOn = null, string userPrincipal = null, string metricId = null, DimensionKey dimensionKey = null, MetricPeriodType periodType = default, int periodValue = default)
        {
            Dictionary<string, string> dimensions = dimensionKey?.ToDictionary(key => key.Key, key => key.Value);
            FeedbackFilter filter = new FeedbackFilter(dimensions);
            PeriodFeedbackValue feedbackValue = new PeriodFeedbackValue(periodType, periodValue);

            return new MetricPeriodFeedback(MetricFeedbackKind.Period, id, createdOn, userPrincipal, metricId, filter, feedbackValue);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Models.MetricSeriesData"/> for mocking purposes.
        /// </summary>
        /// <param name="metricId">Sets the <see cref="MetricSeriesData.MetricId"/> property.</param>
        /// <param name="seriesKey">Sets the <see cref="MetricSeriesData.SeriesKey"/> property.</param>
        /// <param name="timestamps">Sets the <see cref="MetricSeriesData.Timestamps"/> property.</param>
        /// <param name="metricValues">Sets the <see cref="MetricSeriesData.MetricValues"/> property.</param>
        /// <returns>A new instance of <see cref="Models.MetricSeriesData"/> for mocking purposes.</returns>
        public static MetricSeriesData MetricSeriesData(string metricId = null, DimensionKey seriesKey = null, IEnumerable<DateTimeOffset> timestamps = null, IEnumerable<double> metricValues = null)
        {
            timestamps ??= new List<DateTimeOffset>();
            metricValues ??= new List<double>();

            Dictionary<string, string> dimensions = seriesKey?.ToDictionary(key => key.Key, key => key.Value);
            MetricSeriesDefinition definition = new MetricSeriesDefinition(metricId, dimensions);

            return new MetricSeriesData(definition, timestamps?.ToList(), metricValues?.ToList());
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Models.MetricSeriesDefinition"/> for mocking purposes.
        /// </summary>
        /// <param name="metricId">Sets the <see cref="MetricSeriesDefinition.MetricId"/> property.</param>
        /// <param name="seriesKey">Sets the <see cref="MetricSeriesDefinition.SeriesKey"/> property.</param>
        /// <returns>A new instance of <see cref="Models.MetricSeriesDefinition"/> for mocking purposes.</returns>
        public static MetricSeriesDefinition MetricSeriesDefinition(string metricId = null, DimensionKey seriesKey = null)
        {
            Dictionary<string, string> dimensions = seriesKey?.ToDictionary(key => key.Key, key => key.Value);

            return new MetricSeriesDefinition(metricId, dimensions);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Administration.ServicePrincipalCredentialEntity"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="DataSourceCredentialEntity.Id"/> property.</param>
        /// <param name="name">Sets the <see cref="DataSourceCredentialEntity.Name"/> property.</param>
        /// <param name="description">Sets the <see cref="DataSourceCredentialEntity.Description"/> property.</param>
        /// <param name="clientId">Sets the <see cref="ServicePrincipalCredentialEntity.ClientId"/> property.</param>
        /// <param name="clientSecret">Sets the client secret. This secret is not exposed in a property.</param>
        /// <param name="tenantId">Sets the <see cref="ServicePrincipalCredentialEntity.TenantId"/> property.</param>
        /// <returns>A new instance of <see cref="Administration.ServicePrincipalCredentialEntity"/> for mocking purposes.</returns>
        public static ServicePrincipalCredentialEntity ServicePrincipalCredentialEntity(string id = null, string name = null, string description = null, string clientId = null, string clientSecret = null, string tenantId = null)
        {
            ServicePrincipalParam parameters = new ServicePrincipalParam(clientId, clientSecret, tenantId);

            return new ServicePrincipalCredentialEntity(DataSourceCredentialKind.ServicePrincipal, id, name, description, parameters);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Administration.ServicePrincipalInKeyVaultCredentialEntity"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="DataSourceCredentialEntity.Id"/> property.</param>
        /// <param name="name">Sets the <see cref="DataSourceCredentialEntity.Name"/> property.</param>
        /// <param name="description">Sets the <see cref="DataSourceCredentialEntity.Description"/> property.</param>
        /// <param name="endpoint">Sets the <see cref="ServicePrincipalInKeyVaultCredentialEntity.Endpoint"/> property.</param>
        /// <param name="keyVaultClientId">Sets the <see cref="ServicePrincipalInKeyVaultCredentialEntity.KeyVaultClientId"/> property.</param>
        /// <param name="keyVaultClientSecret">Sets the Key Vault client secret. This secret is not exposed in a property.</param>
        /// <param name="secretNameForClientId">Sets the <see cref="ServicePrincipalInKeyVaultCredentialEntity.SecretNameForClientId"/> property.</param>
        /// <param name="secretNameForClientSecret">Sets the <see cref="ServicePrincipalInKeyVaultCredentialEntity.SecretNameForClientSecret"/> property.</param>
        /// <param name="tenantId">Sets the <see cref="ServicePrincipalInKeyVaultCredentialEntity.TenantId"/> property.</param>
        /// <returns>A new instance of <see cref="Administration.ServicePrincipalInKeyVaultCredentialEntity"/> for mocking purposes.</returns>
        public static ServicePrincipalInKeyVaultCredentialEntity ServicePrincipalInKeyVaultCredentialEntity(string id = null, string name = null, string description = null, Uri endpoint = null, string keyVaultClientId = null, string keyVaultClientSecret = null, string secretNameForClientId = null, string secretNameForClientSecret = null, string tenantId = null)
        {
            ServicePrincipalInKVParam parameters = new ServicePrincipalInKVParam(endpoint?.AbsoluteUri, keyVaultClientId, keyVaultClientSecret, secretNameForClientId, secretNameForClientSecret, tenantId);

            return new ServicePrincipalInKeyVaultCredentialEntity(DataSourceCredentialKind.ServicePrincipalInKeyVault, id, name, description, parameters);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Administration.SqlConnectionStringCredentialEntity"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="DataSourceCredentialEntity.Id"/> property.</param>
        /// <param name="name">Sets the <see cref="DataSourceCredentialEntity.Name"/> property.</param>
        /// <param name="description">Sets the <see cref="DataSourceCredentialEntity.Description"/> property.</param>
        /// <param name="connectionString">Sets the connection string. This secret is not exposed in a property.</param>
        /// <returns>A new instance of <see cref="Administration.SqlConnectionStringCredentialEntity"/> for mocking purposes.</returns>
        public static SqlConnectionStringCredentialEntity SqlConnectionStringCredentialEntity(string id = null, string name = null, string description = null, string connectionString = null)
        {
            AzureSQLConnectionStringParam parameters = new AzureSQLConnectionStringParam(connectionString);

            return new SqlConnectionStringCredentialEntity(DataSourceCredentialKind.SqlConnectionString, id, name, description, parameters);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Models.TopNGroupScope"/> for mocking purposes.
        /// </summary>
        /// <param name="top">Sets the <see cref="TopNGroupScope.Top"/> property.</param>
        /// <param name="period">Sets the <see cref="TopNGroupScope.Period"/> property.</param>
        /// <param name="minimumTopCount">Sets the <see cref="TopNGroupScope.MinimumTopCount"/> property.</param>
        /// <returns>A new instance of <see cref="Models.TopNGroupScope"/> for mocking purposes.</returns>
        public static TopNGroupScope TopNGroupScope(int top = default, int period = default, int minimumTopCount = default)
        {
            return new TopNGroupScope(top, period, minimumTopCount);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Administration.WebNotificationHook"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="NotificationHook.Id"/> property.</param>
        /// <param name="name">Sets the <see cref="NotificationHook.Name"/> property.</param>
        /// <param name="description">Sets the <see cref="NotificationHook.Description"/> property.</param>
        /// <param name="externalUri">Sets the <see cref="NotificationHook.ExternalUri"/> property.</param>
        /// <param name="administrators">Sets the <see cref="NotificationHook.Administrators"/> property.</param>
        /// <param name="endpoint">Sets the <see cref="WebNotificationHook.Endpoint"/> property.</param>
        /// <param name="username">Sets the <see cref="WebNotificationHook.Username"/> property.</param>
        /// <param name="password">Sets the <see cref="WebNotificationHook.Password"/> property.</param>
        /// <param name="headers">Sets the <see cref="WebNotificationHook.Headers"/> property.</param>
        /// <param name="certificateKey">Sets the <see cref="WebNotificationHook.CertificateKey"/> property.</param>
        /// <param name="certificatePassword">Sets the <see cref="WebNotificationHook.CertificatePassword"/> property.</param>
        /// <returns>A new instance of <see cref="Administration.WebNotificationHook"/> for mocking purposes.</returns>
        public static WebNotificationHook WebNotificationHook(string id = null, string name = null, string description = null, Uri externalUri = null, IEnumerable<string> administrators = null, Uri endpoint = null, string username = null, string password = null, IDictionary<string, string> headers = null, string certificateKey = null, string certificatePassword = null)
        {
            administrators ??= new List<string>();
            headers ??= new Dictionary<string, string>();

            WebhookHookParameter parameter = new WebhookHookParameter(endpoint?.AbsoluteUri, username, password, headers, certificateKey, certificatePassword);

            return new WebNotificationHook(NotificationHookKind.Webhook, id, name, description, externalUri?.AbsoluteUri, administrators.ToList(), parameter);
        }
    }
}
