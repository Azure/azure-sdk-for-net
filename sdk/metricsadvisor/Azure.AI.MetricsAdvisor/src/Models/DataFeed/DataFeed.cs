// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Periodically ingests data from a data source in order to build time series
    /// to be monitored for anomaly detection.
    /// </summary>
    public class DataFeed
    {
        internal DataFeed(DataFeedDetail dataFeedDetail)
        {
            Id = dataFeedDetail.DataFeedId;
            Status = dataFeedDetail.Status;
            CreatedTime = dataFeedDetail.CreatedTime;
            IsAdministrator = dataFeedDetail.IsAdmin;
            MetricIds = dataFeedDetail.Metrics.Select(metric => metric.MetricId).ToList();
            Name = dataFeedDetail.DataFeedName;
            SourceType = dataFeedDetail.DataSourceType;
            Schema = new DataFeedSchema(dataFeedDetail);
            Granularity = new DataFeedGranularity(dataFeedDetail);
            IngestionSettings = new DataFeedIngestionSettings(dataFeedDetail);
            Options = new DataFeedOptions(dataFeedDetail);
        }

        /// <summary>
        /// The unique identifier of this <see cref="DataFeed"/>. Set by the service.
        /// </summary>
        public string Id { get; internal set; }

        /// <summary>
        /// The current ingestion status of this <see cref="DataFeed"/>.
        /// </summary>
        public DataFeedStatus? Status { get; }

        /// <summary>
        /// Date and time, in UTC, when this <see cref="DataFeed"/> was created.
        /// </summary>
        public DateTimeOffset? CreatedTime { get; }

        /// <summary>
        /// Whether or not the user who queried the information about this <see cref="DataFeed"/>
        /// is one of its administrators.
        /// </summary>
        public bool? IsAdministrator { get; }

        /// <summary>
        /// The unique identifiers of the metrics defined in this feed's <see cref="DataFeedSchema"/>.
        /// Set by the service.
        /// </summary>
        public IReadOnlyList<string> MetricIds { get; }

        /// <summary>
        /// A custom name for this <see cref="DataFeed"/> to be displayed on the web portal.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The type of data source that ingests this <see cref="DataFeed"/> with data.
        /// </summary>
        public DataFeedSourceType SourceType { get; }

        /// <summary>
        /// Defines how this <see cref="DataFeed"/> structures the data ingested from the data source
        /// in terms of metrics and dimensions.
        /// </summary>
        public DataFeedSchema Schema { get; }

        /// <summary>
        /// The frequency with which ingestion from the data source will happen.
        /// </summary>
        public DataFeedGranularity Granularity { get; }

        /// <summary>
        /// Configures how a <see cref="DataFeed"/> behaves during data ingestion from its data source.
        /// </summary>
        public DataFeedIngestionSettings IngestionSettings { get; }

        /// <summary>
        /// A set of options configuring the behavior of this <see cref="DataFeed"/>. Options include administrators,
        /// roll-up settings, access mode, and others.
        /// </summary>
        public DataFeedOptions Options { get; }

        /// <summary> Converts a data source specific <see cref="DataFeed"/> into its equivalent data source specific <see cref="DataFeedDetailPatch"/>. </summary>
        internal DataFeedDetailPatch GetPatchModel()
        {
            return this switch
            {
                DataFeed p when p.SourceType == DataFeedSourceType.AzureApplicationInsights => new AzureApplicationInsightsDataFeedPatch()
                {
                    DataFeedName = p.Name,
                    DataFeedDescription = p.Options?.FeedDescription,
                    TimestampColumn = p.Schema.TimestampColumn,
                    DataStartFrom = p.IngestionSettings.IngestionStartTime,
                    StartOffsetInSeconds = (long?)IngestionSettings.IngestionStartOffset?.TotalSeconds,
                    MaxConcurrency = p.IngestionSettings.DataSourceRequestConcurrency,
                    MinRetryIntervalInSeconds = (long?)IngestionSettings.IngestionRetryDelay?.TotalSeconds,
                    StopRetryAfterInSeconds = (long?)IngestionSettings.StopRetryAfter?.TotalSeconds,
                    NeedRollup = p.Options?.RollupSettings?.RollupType.HasValue == true ? new DataFeedDetailPatchNeedRollup(p.Options.RollupSettings.RollupType.ToString()) : default,
                    RollUpMethod = p.Options?.RollupSettings?.RollupMethod.HasValue == true ? new DataFeedDetailPatchRollUpMethod(p.Options.RollupSettings.RollupMethod.ToString()) : default,
                    RollUpColumns = p.Options?.RollupSettings?.AutoRollupGroupByColumnNames ?? new ChangeTrackingList<string>(),
                    AllUpIdentification = p.Options?.RollupSettings?.AlreadyRollupIdentificationValue,
                    FillMissingPointType = p.Options?.MissingDataPointFillSettings?.FillType.HasValue == true ? new DataFeedDetailPatchFillMissingPointType(p.Options.MissingDataPointFillSettings.FillType.ToString()) : default,
                    FillMissingPointValue = p.Options?.MissingDataPointFillSettings?.CustomFillValue,
                    ViewMode = p.Options?.AccessMode.HasValue == true ? new DataFeedDetailPatchViewMode(p.Options.AccessMode.ToString()) : default,
                    Admins = p.Options?.Administrators,
                    Viewers = p.Options?.Viewers,
                    Status = p.Status.HasValue ? new DataFeedDetailPatchStatus(p.Status.ToString()) : default,
                },
                DataFeed p when p.SourceType == DataFeedSourceType.AzureBlob => new AzureBlobDataFeedPatch()
                {
                    DataFeedName = p.Name,
                    DataFeedDescription = p.Options?.FeedDescription,
                    TimestampColumn = p.Schema.TimestampColumn,
                    DataStartFrom = p.IngestionSettings.IngestionStartTime,
                    StartOffsetInSeconds = (long?)IngestionSettings.IngestionStartOffset?.TotalSeconds,
                    MaxConcurrency = p.IngestionSettings.DataSourceRequestConcurrency,
                    MinRetryIntervalInSeconds = (long?)IngestionSettings.IngestionRetryDelay?.TotalSeconds,
                    StopRetryAfterInSeconds = (long?)IngestionSettings.StopRetryAfter?.TotalSeconds,
                    NeedRollup = p.Options?.RollupSettings?.RollupType.HasValue == true ? new DataFeedDetailPatchNeedRollup(p.Options.RollupSettings.RollupType.ToString()) : default,
                    RollUpMethod = p.Options?.RollupSettings?.RollupMethod.HasValue == true ? new DataFeedDetailPatchRollUpMethod(p.Options.RollupSettings.RollupMethod.ToString()) : default,
                    RollUpColumns = p.Options?.RollupSettings?.AutoRollupGroupByColumnNames ?? new ChangeTrackingList<string>(),
                    AllUpIdentification = p.Options?.RollupSettings?.AlreadyRollupIdentificationValue,
                    FillMissingPointType = p.Options?.MissingDataPointFillSettings?.FillType.HasValue == true  ? new DataFeedDetailPatchFillMissingPointType(p.Options.MissingDataPointFillSettings.FillType.ToString()) : default,
                    FillMissingPointValue = p.Options?.MissingDataPointFillSettings?.CustomFillValue,
                    ViewMode = p.Options?.AccessMode.HasValue == true ? new DataFeedDetailPatchViewMode(p.Options.AccessMode.ToString()) : default,
                    Admins = p.Options?.Administrators,
                    Viewers = p.Options?.Viewers,
                    Status = p.Status.HasValue ? new DataFeedDetailPatchStatus(p.Status.ToString()) : default,
                },
                DataFeed p when p.SourceType == DataFeedSourceType.AzureCosmosDb => new AzureCosmosDBDataFeedPatch()
                {
                    DataFeedName = p.Name,
                    DataFeedDescription = p.Options?.FeedDescription,
                    TimestampColumn = p.Schema.TimestampColumn,
                    DataStartFrom = p.IngestionSettings.IngestionStartTime,
                    StartOffsetInSeconds = (long?)IngestionSettings.IngestionStartOffset?.TotalSeconds,
                    MaxConcurrency = p.IngestionSettings.DataSourceRequestConcurrency,
                    MinRetryIntervalInSeconds = (long?)IngestionSettings.IngestionRetryDelay?.TotalSeconds,
                    StopRetryAfterInSeconds = (long?)IngestionSettings.StopRetryAfter?.TotalSeconds,
                    NeedRollup = p.Options?.RollupSettings?.RollupType.HasValue == true ? new DataFeedDetailPatchNeedRollup(p.Options.RollupSettings.RollupType.ToString()) : default,
                    RollUpMethod = p.Options?.RollupSettings?.RollupMethod.HasValue == true ? new DataFeedDetailPatchRollUpMethod(p.Options.RollupSettings.RollupMethod.ToString()) : default,
                    RollUpColumns = p.Options?.RollupSettings?.AutoRollupGroupByColumnNames ?? new ChangeTrackingList<string>(),
                    AllUpIdentification = p.Options?.RollupSettings?.AlreadyRollupIdentificationValue,
                    FillMissingPointType = p.Options?.MissingDataPointFillSettings?.FillType.HasValue == true  ? new DataFeedDetailPatchFillMissingPointType(p.Options.MissingDataPointFillSettings.FillType.ToString()) : default,
                    FillMissingPointValue = p.Options?.MissingDataPointFillSettings?.CustomFillValue,
                    ViewMode = p.Options?.AccessMode.HasValue == true ? new DataFeedDetailPatchViewMode(p.Options.AccessMode.ToString()) : default,
                    Admins = p.Options?.Administrators,
                    Viewers = p.Options?.Viewers,
                    Status = p.Status.HasValue ? new DataFeedDetailPatchStatus(p.Status.ToString()) : default,
                },
                DataFeed p when p.SourceType == DataFeedSourceType.AzureDataLakeStorageGen2 => new AzureDataLakeStorageGen2DataFeedPatch()
                {
                    DataFeedName = p.Name,
                    DataFeedDescription = p.Options?.FeedDescription,
                    TimestampColumn = p.Schema.TimestampColumn,
                    DataStartFrom = p.IngestionSettings.IngestionStartTime,
                    StartOffsetInSeconds = (long?)IngestionSettings.IngestionStartOffset?.TotalSeconds,
                    MaxConcurrency = p.IngestionSettings.DataSourceRequestConcurrency,
                    MinRetryIntervalInSeconds = (long?)IngestionSettings.IngestionRetryDelay?.TotalSeconds,
                    StopRetryAfterInSeconds = (long?)IngestionSettings.StopRetryAfter?.TotalSeconds,
                    NeedRollup = p.Options?.RollupSettings?.RollupType.HasValue == true ? new DataFeedDetailPatchNeedRollup(p.Options.RollupSettings.RollupType.ToString()) : default,
                    RollUpMethod = p.Options?.RollupSettings?.RollupMethod.HasValue == true ? new DataFeedDetailPatchRollUpMethod(p.Options.RollupSettings.RollupMethod.ToString()) : default,
                    RollUpColumns = p.Options?.RollupSettings?.AutoRollupGroupByColumnNames ?? new ChangeTrackingList<string>(),
                    AllUpIdentification = p.Options?.RollupSettings?.AlreadyRollupIdentificationValue,
                    FillMissingPointType = p.Options?.MissingDataPointFillSettings?.FillType.HasValue == true  ? new DataFeedDetailPatchFillMissingPointType(p.Options.MissingDataPointFillSettings.FillType.ToString()) : default,
                    FillMissingPointValue = p.Options?.MissingDataPointFillSettings?.CustomFillValue,
                    ViewMode = p.Options?.AccessMode.HasValue == true ? new DataFeedDetailPatchViewMode(p.Options.AccessMode.ToString()) : default,
                    Admins = p.Options?.Administrators,
                    Viewers = p.Options?.Viewers,
                    Status = p.Status.HasValue ? new DataFeedDetailPatchStatus(p.Status.ToString()) : default,
                },
                DataFeed p when p.SourceType == DataFeedSourceType.AzureTable => new AzureTableDataFeedPatch()
                {
                    DataFeedName = p.Name,
                    DataFeedDescription = p.Options?.FeedDescription,
                    TimestampColumn = p.Schema.TimestampColumn,
                    DataStartFrom = p.IngestionSettings.IngestionStartTime,
                    StartOffsetInSeconds = (long?)IngestionSettings.IngestionStartOffset?.TotalSeconds,
                    MaxConcurrency = p.IngestionSettings.DataSourceRequestConcurrency,
                    MinRetryIntervalInSeconds = (long?)IngestionSettings.IngestionRetryDelay?.TotalSeconds,
                    StopRetryAfterInSeconds = (long?)IngestionSettings.StopRetryAfter?.TotalSeconds,
                    NeedRollup = p.Options?.RollupSettings?.RollupType.HasValue == true ? new DataFeedDetailPatchNeedRollup(p.Options.RollupSettings.RollupType.ToString()) : default,
                    RollUpMethod = p.Options?.RollupSettings?.RollupMethod.HasValue == true ? new DataFeedDetailPatchRollUpMethod(p.Options.RollupSettings.RollupMethod.ToString()) : default,
                    RollUpColumns = p.Options?.RollupSettings?.AutoRollupGroupByColumnNames ?? new ChangeTrackingList<string>(),
                    AllUpIdentification = p.Options?.RollupSettings?.AlreadyRollupIdentificationValue,
                    FillMissingPointType = p.Options?.MissingDataPointFillSettings?.FillType.HasValue == true  ? new DataFeedDetailPatchFillMissingPointType(p.Options.MissingDataPointFillSettings.FillType.ToString()) : default,
                    FillMissingPointValue = p.Options?.MissingDataPointFillSettings?.CustomFillValue,
                    ViewMode = p.Options?.AccessMode.HasValue == true ? new DataFeedDetailPatchViewMode(p.Options.AccessMode.ToString()) : default,
                    Admins = p.Options?.Administrators,
                    Viewers = p.Options?.Viewers,
                    Status = p.Status.HasValue ? new DataFeedDetailPatchStatus(p.Status.ToString()) : default,
                },
                DataFeed p when p.SourceType == DataFeedSourceType.Elasticsearch => new ElasticsearchDataFeedPatch()
                {
                    DataFeedName = p.Name,
                    DataFeedDescription = p.Options?.FeedDescription,
                    TimestampColumn = p.Schema.TimestampColumn,
                    DataStartFrom = p.IngestionSettings.IngestionStartTime,
                    StartOffsetInSeconds = (long?)IngestionSettings.IngestionStartOffset?.TotalSeconds,
                    MaxConcurrency = p.IngestionSettings.DataSourceRequestConcurrency,
                    MinRetryIntervalInSeconds = (long?)IngestionSettings.IngestionRetryDelay?.TotalSeconds,
                    StopRetryAfterInSeconds = (long?)IngestionSettings.StopRetryAfter?.TotalSeconds,
                    NeedRollup = p.Options?.RollupSettings?.RollupType.HasValue == true ? new DataFeedDetailPatchNeedRollup(p.Options.RollupSettings.RollupType.ToString()) : default,
                    RollUpMethod = p.Options?.RollupSettings?.RollupMethod.HasValue == true ? new DataFeedDetailPatchRollUpMethod(p.Options.RollupSettings.RollupMethod.ToString()) : default,
                    RollUpColumns = p.Options?.RollupSettings?.AutoRollupGroupByColumnNames ?? new ChangeTrackingList<string>(),
                    AllUpIdentification = p.Options?.RollupSettings?.AlreadyRollupIdentificationValue,
                    FillMissingPointType = p.Options?.MissingDataPointFillSettings?.FillType.HasValue == true  ? new DataFeedDetailPatchFillMissingPointType(p.Options.MissingDataPointFillSettings.FillType.ToString()) : default,
                    FillMissingPointValue = p.Options?.MissingDataPointFillSettings?.CustomFillValue,
                    ViewMode = p.Options?.AccessMode.HasValue == true ? new DataFeedDetailPatchViewMode(p.Options.AccessMode.ToString()) : default,
                    Admins = p.Options?.Administrators,
                    Viewers = p.Options?.Viewers,
                    Status = p.Status.HasValue ? new DataFeedDetailPatchStatus(p.Status.ToString()) : default,
                },
                DataFeed p when p.SourceType == DataFeedSourceType.HttpRequest => new HttpRequestDataFeedPatch()
                {
                    DataFeedName = p.Name,
                    DataFeedDescription = p.Options?.FeedDescription,
                    TimestampColumn = p.Schema.TimestampColumn,
                    DataStartFrom = p.IngestionSettings.IngestionStartTime,
                    StartOffsetInSeconds = (long?)IngestionSettings.IngestionStartOffset?.TotalSeconds,
                    MaxConcurrency = p.IngestionSettings.DataSourceRequestConcurrency,
                    MinRetryIntervalInSeconds = (long?)IngestionSettings.IngestionRetryDelay?.TotalSeconds,
                    StopRetryAfterInSeconds = (long?)IngestionSettings.StopRetryAfter?.TotalSeconds,
                    NeedRollup = p.Options?.RollupSettings?.RollupType.HasValue == true ? new DataFeedDetailPatchNeedRollup(p.Options.RollupSettings.RollupType.ToString()) : default,
                    RollUpMethod = p.Options?.RollupSettings?.RollupMethod.HasValue == true ? new DataFeedDetailPatchRollUpMethod(p.Options.RollupSettings.RollupMethod.ToString()) : default,
                    RollUpColumns = p.Options?.RollupSettings?.AutoRollupGroupByColumnNames ?? new ChangeTrackingList<string>(),
                    AllUpIdentification = p.Options?.RollupSettings?.AlreadyRollupIdentificationValue,
                    FillMissingPointType = p.Options?.MissingDataPointFillSettings?.FillType.HasValue == true  ? new DataFeedDetailPatchFillMissingPointType(p.Options.MissingDataPointFillSettings.FillType.ToString()) : default,
                    FillMissingPointValue = p.Options?.MissingDataPointFillSettings?.CustomFillValue,
                    ViewMode = p.Options?.AccessMode.HasValue == true ? new DataFeedDetailPatchViewMode(p.Options.AccessMode.ToString()) : default,
                    Admins = p.Options?.Administrators,
                    Viewers = p.Options?.Viewers,
                    Status = p.Status.HasValue ? new DataFeedDetailPatchStatus(p.Status.ToString()) : default,
                },
                DataFeed p when p.SourceType == DataFeedSourceType.InfluxDb => new InfluxDBDataFeedPatch()
                {
                    DataFeedName = p.Name,
                    DataFeedDescription = p.Options?.FeedDescription,
                    TimestampColumn = p.Schema.TimestampColumn,
                    DataStartFrom = p.IngestionSettings.IngestionStartTime,
                    StartOffsetInSeconds = (long?)IngestionSettings.IngestionStartOffset?.TotalSeconds,
                    MaxConcurrency = p.IngestionSettings.DataSourceRequestConcurrency,
                    MinRetryIntervalInSeconds = (long?)IngestionSettings.IngestionRetryDelay?.TotalSeconds,
                    StopRetryAfterInSeconds = (long?)IngestionSettings.StopRetryAfter?.TotalSeconds,
                    NeedRollup = p.Options?.RollupSettings?.RollupType.HasValue == true ? new DataFeedDetailPatchNeedRollup(p.Options.RollupSettings.RollupType.ToString()) : default,
                    RollUpMethod = p.Options?.RollupSettings?.RollupMethod.HasValue == true ? new DataFeedDetailPatchRollUpMethod(p.Options.RollupSettings.RollupMethod.ToString()) : default,
                    RollUpColumns = p.Options?.RollupSettings?.AutoRollupGroupByColumnNames ?? new ChangeTrackingList<string>(),
                    AllUpIdentification = p.Options?.RollupSettings?.AlreadyRollupIdentificationValue,
                    FillMissingPointType = p.Options?.MissingDataPointFillSettings?.FillType.HasValue == true  ? new DataFeedDetailPatchFillMissingPointType(p.Options.MissingDataPointFillSettings.FillType.ToString()) : default,
                    FillMissingPointValue = p.Options?.MissingDataPointFillSettings?.CustomFillValue,
                    ViewMode = p.Options?.AccessMode.HasValue == true ? new DataFeedDetailPatchViewMode(p.Options.AccessMode.ToString()) : default,
                    Admins = p.Options?.Administrators,
                    Viewers = p.Options?.Viewers,
                    Status = p.Status.HasValue ? new DataFeedDetailPatchStatus(p.Status.ToString()) : default,
                },
                DataFeed p when p.SourceType == DataFeedSourceType.AzureDataExplorer => new AzureDataExplorerDataFeedPatch()
                {
                    DataFeedName = p.Name,
                    DataFeedDescription = p.Options?.FeedDescription,
                    TimestampColumn = p.Schema.TimestampColumn,
                    DataStartFrom = p.IngestionSettings.IngestionStartTime,
                    StartOffsetInSeconds = (long?)IngestionSettings.IngestionStartOffset?.TotalSeconds,
                    MaxConcurrency = p.IngestionSettings.DataSourceRequestConcurrency,
                    MinRetryIntervalInSeconds = (long?)IngestionSettings.IngestionRetryDelay?.TotalSeconds,
                    StopRetryAfterInSeconds = (long?)IngestionSettings.StopRetryAfter?.TotalSeconds,
                    NeedRollup = p.Options?.RollupSettings?.RollupType.HasValue == true ? new DataFeedDetailPatchNeedRollup(p.Options.RollupSettings.RollupType.ToString()) : default,
                    RollUpMethod = p.Options?.RollupSettings?.RollupMethod.HasValue == true ? new DataFeedDetailPatchRollUpMethod(p.Options.RollupSettings.RollupMethod.ToString()) : default,
                    RollUpColumns = p.Options?.RollupSettings?.AutoRollupGroupByColumnNames ?? new ChangeTrackingList<string>(),
                    AllUpIdentification = p.Options?.RollupSettings?.AlreadyRollupIdentificationValue,
                    FillMissingPointType = p.Options?.MissingDataPointFillSettings?.FillType.HasValue == true  ? new DataFeedDetailPatchFillMissingPointType(p.Options.MissingDataPointFillSettings.FillType.ToString()) : default,
                    FillMissingPointValue = p.Options?.MissingDataPointFillSettings?.CustomFillValue,
                    ViewMode = p.Options?.AccessMode.HasValue == true ? new DataFeedDetailPatchViewMode(p.Options.AccessMode.ToString()) : default,
                    Admins = p.Options?.Administrators,
                    Viewers = p.Options?.Viewers,
                    Status = p.Status.HasValue ? new DataFeedDetailPatchStatus(p.Status.ToString()) : default,
                },
                DataFeed p when p.SourceType == DataFeedSourceType.MySql => new MySqlDataFeedPatch()
                {
                    DataFeedName = p.Name,
                    DataFeedDescription = p.Options?.FeedDescription,
                    TimestampColumn = p.Schema.TimestampColumn,
                    DataStartFrom = p.IngestionSettings.IngestionStartTime,
                    StartOffsetInSeconds = (long?)IngestionSettings.IngestionStartOffset?.TotalSeconds,
                    MaxConcurrency = p.IngestionSettings.DataSourceRequestConcurrency,
                    MinRetryIntervalInSeconds = (long?)IngestionSettings.IngestionRetryDelay?.TotalSeconds,
                    StopRetryAfterInSeconds = (long?)IngestionSettings.StopRetryAfter?.TotalSeconds,
                    NeedRollup = p.Options?.RollupSettings?.RollupType.HasValue == true ? new DataFeedDetailPatchNeedRollup(p.Options.RollupSettings.RollupType.ToString()) : default,
                    RollUpMethod = p.Options?.RollupSettings?.RollupMethod.HasValue == true ? new DataFeedDetailPatchRollUpMethod(p.Options.RollupSettings.RollupMethod.ToString()) : default,
                    RollUpColumns = p.Options?.RollupSettings?.AutoRollupGroupByColumnNames ?? new ChangeTrackingList<string>(),
                    AllUpIdentification = p.Options?.RollupSettings?.AlreadyRollupIdentificationValue,
                    FillMissingPointType = p.Options?.MissingDataPointFillSettings?.FillType.HasValue == true  ? new DataFeedDetailPatchFillMissingPointType(p.Options.MissingDataPointFillSettings.FillType.ToString()) : default,
                    FillMissingPointValue = p.Options?.MissingDataPointFillSettings?.CustomFillValue,
                    ViewMode = p.Options?.AccessMode.HasValue == true ? new DataFeedDetailPatchViewMode(p.Options.AccessMode.ToString()) : default,
                    Admins = p.Options?.Administrators,
                    Viewers = p.Options?.Viewers,
                    Status = p.Status.HasValue ? new DataFeedDetailPatchStatus(p.Status.ToString()) : default,
                },
                DataFeed p when p.SourceType == DataFeedSourceType.PostgreSql => new PostgreSqlDataFeedPatch()
                {
                    DataFeedName = p.Name,
                    DataFeedDescription = p.Options?.FeedDescription,
                    TimestampColumn = p.Schema.TimestampColumn,
                    DataStartFrom = p.IngestionSettings.IngestionStartTime,
                    StartOffsetInSeconds = (long?)IngestionSettings.IngestionStartOffset?.TotalSeconds,
                    MaxConcurrency = p.IngestionSettings.DataSourceRequestConcurrency,
                    MinRetryIntervalInSeconds = (long?)IngestionSettings.IngestionRetryDelay?.TotalSeconds,
                    StopRetryAfterInSeconds = (long?)IngestionSettings.StopRetryAfter?.TotalSeconds,
                    NeedRollup = p.Options?.RollupSettings?.RollupType.HasValue == true ? new DataFeedDetailPatchNeedRollup(p.Options.RollupSettings.RollupType.ToString()) : default,
                    RollUpMethod = p.Options?.RollupSettings?.RollupMethod.HasValue == true ? new DataFeedDetailPatchRollUpMethod(p.Options.RollupSettings.RollupMethod.ToString()) : default,
                    RollUpColumns = p.Options?.RollupSettings?.AutoRollupGroupByColumnNames ?? new ChangeTrackingList<string>(),
                    AllUpIdentification = p.Options?.RollupSettings?.AlreadyRollupIdentificationValue,
                    FillMissingPointType = p.Options?.MissingDataPointFillSettings?.FillType.HasValue == true  ? new DataFeedDetailPatchFillMissingPointType(p.Options.MissingDataPointFillSettings.FillType.ToString()) : default,
                    FillMissingPointValue = p.Options?.MissingDataPointFillSettings?.CustomFillValue,
                    ViewMode = p.Options?.AccessMode.HasValue == true ? new DataFeedDetailPatchViewMode(p.Options.AccessMode.ToString()) : default,
                    Admins = p.Options?.Administrators,
                    Viewers = p.Options?.Viewers,
                    Status = p.Status.HasValue ? new DataFeedDetailPatchStatus(p.Status.ToString()) : default,
                },
                DataFeed p when p.SourceType == DataFeedSourceType.SqlServer => new SQLServerDataFeedPatch()
                {
                    DataFeedName = p.Name,
                    DataFeedDescription = p.Options?.FeedDescription,
                    TimestampColumn = p.Schema.TimestampColumn,
                    DataStartFrom = p.IngestionSettings.IngestionStartTime,
                    StartOffsetInSeconds = (long?)IngestionSettings.IngestionStartOffset?.TotalSeconds,
                    MaxConcurrency = p.IngestionSettings.DataSourceRequestConcurrency,
                    MinRetryIntervalInSeconds = (long?)IngestionSettings.IngestionRetryDelay?.TotalSeconds,
                    StopRetryAfterInSeconds = (long?)IngestionSettings.StopRetryAfter?.TotalSeconds,
                    NeedRollup = p.Options?.RollupSettings?.RollupType.HasValue == true ? new DataFeedDetailPatchNeedRollup(p.Options.RollupSettings.RollupType.ToString()) : default,
                    RollUpMethod = p.Options?.RollupSettings?.RollupMethod.HasValue == true ? new DataFeedDetailPatchRollUpMethod(p.Options.RollupSettings.RollupMethod.ToString()) : default,
                    RollUpColumns = p.Options?.RollupSettings?.AutoRollupGroupByColumnNames ?? new ChangeTrackingList<string>(),
                    AllUpIdentification = p.Options?.RollupSettings?.AlreadyRollupIdentificationValue,
                    FillMissingPointType = p.Options?.MissingDataPointFillSettings?.FillType.HasValue == true  ? new DataFeedDetailPatchFillMissingPointType(p.Options.MissingDataPointFillSettings.FillType.ToString()) : default,
                    FillMissingPointValue = p.Options?.MissingDataPointFillSettings?.CustomFillValue,
                    ViewMode = p.Options?.AccessMode.HasValue == true ? new DataFeedDetailPatchViewMode(p.Options.AccessMode.ToString()) : default,
                    Admins = p.Options?.Administrators,
                    Viewers = p.Options?.Viewers,
                    Status = p.Status.HasValue ? new DataFeedDetailPatchStatus(p.Status.ToString()) : default,
                },
                DataFeed p when p.SourceType == DataFeedSourceType.MongoDb => new MongoDBDataFeedPatch()
                {
                    DataFeedName = p.Name,
                    DataFeedDescription = p.Options?.FeedDescription,
                    TimestampColumn = p.Schema.TimestampColumn,
                    DataStartFrom = p.IngestionSettings.IngestionStartTime,
                    StartOffsetInSeconds = (long?)IngestionSettings.IngestionStartOffset?.TotalSeconds,
                    MaxConcurrency = p.IngestionSettings.DataSourceRequestConcurrency,
                    MinRetryIntervalInSeconds = (long?)IngestionSettings.IngestionRetryDelay?.TotalSeconds,
                    StopRetryAfterInSeconds = (long?)IngestionSettings.StopRetryAfter?.TotalSeconds,
                    NeedRollup = p.Options?.RollupSettings?.RollupType.HasValue == true ? new DataFeedDetailPatchNeedRollup(p.Options.RollupSettings.RollupType.ToString()) : default,
                    RollUpMethod = p.Options?.RollupSettings?.RollupMethod.HasValue == true ? new DataFeedDetailPatchRollUpMethod(p.Options.RollupSettings.RollupMethod.ToString()) : default,
                    RollUpColumns = p.Options?.RollupSettings?.AutoRollupGroupByColumnNames ?? new ChangeTrackingList<string>(),
                    AllUpIdentification = p.Options?.RollupSettings?.AlreadyRollupIdentificationValue,
                    FillMissingPointType = p.Options?.MissingDataPointFillSettings?.FillType.HasValue == true  ? new DataFeedDetailPatchFillMissingPointType(p.Options.MissingDataPointFillSettings.FillType.ToString()) : default,
                    FillMissingPointValue = p.Options?.MissingDataPointFillSettings?.CustomFillValue,
                    ViewMode = p.Options?.AccessMode.HasValue == true ? new DataFeedDetailPatchViewMode(p.Options.AccessMode.ToString()) : default,
                    Admins = p.Options?.Administrators,
                    Viewers = p.Options?.Viewers,
                    Status = p.Status.HasValue ? new DataFeedDetailPatchStatus(p.Status.ToString()) : default,
                },
                _ => throw new InvalidOperationException("Invalid DataFeedDetail type")
            };
        }
    }
}
