// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    internal partial class DataFeedDetail
    {
        public string DataFeedId { get; }

        /// <summary> dimension list. </summary>
        public IList<MetricDimension> Dimension { get; }

        /// <summary> data feed administrator. </summary>
        public IList<string> Admins { get; }

        /// <summary> data feed viewer. </summary>
        public IList<string> Viewers { get; }

        /// <summary> roll up columns. </summary>
        public IList<string> RollUpColumns { get; }

        /// <summary> Initializes a new instance of DataFeedDetail. </summary>
        /// <param name="dataFeedName"> data feed name. </param>
        /// <param name="granularityName"> granularity of the time series. </param>
        /// <param name="metrics"> measure list. </param>
        /// <param name="dataStartFrom"> ingestion start time. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="dataFeedName"/> or <paramref name="metrics"/> is null. </exception>
        public DataFeedDetail(string dataFeedName, DataFeedGranularityType granularityName, IEnumerable<DataFeedMetric> metrics, DateTimeOffset dataStartFrom)
        {
            Argument.AssertNotNullOrEmpty(dataFeedName, nameof(dataFeedName));
            Argument.AssertNotNullOrEmpty(metrics, nameof(metrics));

            DataFeedName = dataFeedName;
            GranularityName = granularityName;
            Metrics = metrics.ToList();
            Dimension = new ChangeTrackingList<MetricDimension>();
            DataStartFrom = dataStartFrom;
            RollUpColumns = new ChangeTrackingList<string>();
            Admins = new ChangeTrackingList<string>();
            Viewers = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of DataFeedDetail. </summary>
        /// <param name="dataSourceType"> data source type. </param>
        /// <param name="dataFeedId"> data feed unique id. </param>
        /// <param name="dataFeedName"> data feed name. </param>
        /// <param name="dataFeedDescription"> data feed description. </param>
        /// <param name="granularityName"> granularity of the time series. </param>
        /// <param name="granularityAmount"> if granularity is custom,it is required. </param>
        /// <param name="metrics"> measure list. </param>
        /// <param name="dimension"> dimension list. </param>
        /// <param name="timestampColumn"> user-defined timestamp column. if timestampColumn is null, start time of every time slice will be used as default value. </param>
        /// <param name="dataStartFrom"> ingestion start time. </param>
        /// <param name="startOffsetInSeconds"> the time that the beginning of data ingestion task will delay for every data slice according to this offset. </param>
        /// <param name="maxConcurrency"> the max concurrency of data ingestion queries against user data source. 0 means no limitation. </param>
        /// <param name="minRetryIntervalInSeconds"> the min retry interval for failed data ingestion tasks. </param>
        /// <param name="stopRetryAfterInSeconds"> stop retry data ingestion after the data slice first schedule time in seconds. </param>
        /// <param name="needRollup"> mark if the data feed need rollup. </param>
        /// <param name="rollUpMethod"> roll up method. </param>
        /// <param name="rollUpColumns"> roll up columns. </param>
        /// <param name="allUpIdentification"> the identification value for the row of calculated all-up value. </param>
        /// <param name="fillMissingPointType"> the type of fill missing point for anomaly detection. </param>
        /// <param name="fillMissingPointValue"> the value of fill missing point for anomaly detection. </param>
        /// <param name="viewMode"> data feed access mode, default is Private. </param>
        /// <param name="admins"> data feed administrator. </param>
        /// <param name="viewers"> data feed viewer. </param>
        /// <param name="isAdmin"> the query user is one of data feed administrator or not. </param>
        /// <param name="creator"> data feed creator. </param>
        /// <param name="status"> data feed status. </param>
        /// <param name="createdTime"> data feed created time. </param>
        /// <param name="actionLinkTemplate"> action link for alert. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="dataFeedName"/> or <paramref name="metrics"/> is null. </exception>
        internal DataFeedDetail(DataFeedSourceType dataSourceType, string dataFeedId, string dataFeedName, string dataFeedDescription, DataFeedGranularityType granularityName, int? granularityAmount, IList<DataFeedMetric> metrics, IList<MetricDimension> dimension, string timestampColumn, DateTimeOffset dataStartFrom, long? startOffsetInSeconds, int? maxConcurrency, long? minRetryIntervalInSeconds, long? stopRetryAfterInSeconds, DataFeedRollupType? needRollup, DataFeedAutoRollupMethod? rollUpMethod, IList<string> rollUpColumns, string allUpIdentification, DataFeedMissingDataPointFillType? fillMissingPointType, double? fillMissingPointValue, AccessMode? viewMode, IList<string> admins, IList<string> viewers, bool? isAdmin, string creator, DataFeedStatus? status, DateTimeOffset? createdTime, string actionLinkTemplate)
        {
            Argument.AssertNotNullOrEmpty(dataFeedName, nameof(dataFeedName));
            Argument.AssertNotNullOrEmpty(metrics, nameof(metrics));

            DataSourceType = dataSourceType;
            DataFeedId = dataFeedId;
            DataFeedName = dataFeedName;
            DataFeedDescription = dataFeedDescription;
            GranularityName = granularityName;
            GranularityAmount = granularityAmount;
            Metrics = metrics;
            Dimension = dimension ?? new ChangeTrackingList<MetricDimension>();
            TimestampColumn = timestampColumn;
            DataStartFrom = dataStartFrom;
            StartOffsetInSeconds = startOffsetInSeconds;
            MaxConcurrency = maxConcurrency;
            MinRetryIntervalInSeconds = minRetryIntervalInSeconds;
            StopRetryAfterInSeconds = stopRetryAfterInSeconds;
            NeedRollup = needRollup;
            RollUpMethod = rollUpMethod;
            RollUpColumns = rollUpColumns ?? new ChangeTrackingList<string>();
            AllUpIdentification = allUpIdentification;
            FillMissingPointType = fillMissingPointType;
            FillMissingPointValue = fillMissingPointValue;
            ViewMode = viewMode;
            Admins = admins ?? new ChangeTrackingList<string>();
            Viewers = viewers ?? new ChangeTrackingList<string>();
            IsAdmin = isAdmin;
            Creator = creator;
            Status = status;
            CreatedTime = createdTime;
            ActionLinkTemplate = actionLinkTemplate;
        }

        /// <summary> Converts a data source specific <see cref="Models.DataFeedDetail"/> into its equivalent data source specific <see cref="DataFeedDetailPatch"/>. </summary>
        /// <param name="dataFeed"></param>
        internal static DataFeedDetailPatch GetPatchModel(DataFeed dataFeed)
        {
            return dataFeed switch
            {
                DataFeed p when p.SourceType == DataFeedSourceType.AzureApplicationInsights => new AzureApplicationInsightsDataFeedPatch()
                {
                    DataFeedName = p.Name,
                    DataFeedDescription = p.Options.FeedDescription,
                    TimestampColumn = p.Schema.TimestampColumn,
                    DataStartFrom = p.IngestionSettings.IngestionStartTime,
                    StartOffsetInSeconds = (long?)dataFeed.IngestionSettings.IngestionStartOffset?.TotalSeconds,
                    MaxConcurrency = p.IngestionSettings.DataSourceRequestConcurrency,
                    MinRetryIntervalInSeconds = (long?)dataFeed.IngestionSettings.IngestionRetryDelay?.TotalSeconds,
                    StopRetryAfterInSeconds = (long?)dataFeed.IngestionSettings.StopRetryAfter?.TotalSeconds,
                    NeedRollup = p.Options.RollupSettings.RollupType.HasValue ? new DataFeedDetailPatchNeedRollup(p.Options.RollupSettings.RollupType.ToString()) : default,
                    RollUpMethod = p.Options.RollupSettings.RollupMethod.HasValue ? new DataFeedDetailPatchRollUpMethod(p.Options.RollupSettings.RollupMethod.ToString()) : default,
                    RollUpColumns = p.Options.RollupSettings.AutoRollupGroupByColumnNames ?? new ChangeTrackingList<string>(),
                    AllUpIdentification = p.Options.RollupSettings.AlreadyRollupIdentificationValue,
                    FillMissingPointType = p.Options.MissingDataPointFillSettings.FillType.HasValue ? new DataFeedDetailPatchFillMissingPointType(p.Options.MissingDataPointFillSettings.FillType.ToString()) : default,
                    FillMissingPointValue = p.Options.MissingDataPointFillSettings.CustomFillValue,
                    ViewMode = p.Options.AccessMode.HasValue ? new DataFeedDetailPatchViewMode(p.Options.AccessMode.ToString()) : default,
                    Admins = p.Options.Administrators ?? new ChangeTrackingList<string>(),
                    Viewers = p.Options.Viewers ?? new ChangeTrackingList<string>(),
                    Status = p.Status.HasValue ? new DataFeedDetailPatchStatus(p.Status.ToString()) : default,
                },
                DataFeed p when p.SourceType == DataFeedSourceType.AzureBlob => new AzureBlobDataFeedPatch()
                {
                    DataFeedName = p.Name,
                    DataFeedDescription = p.Options.FeedDescription,
                    TimestampColumn = p.Schema.TimestampColumn,
                    DataStartFrom = p.IngestionSettings.IngestionStartTime,
                    StartOffsetInSeconds = (long?)dataFeed.IngestionSettings.IngestionStartOffset?.TotalSeconds,
                    MaxConcurrency = p.IngestionSettings.DataSourceRequestConcurrency,
                    MinRetryIntervalInSeconds = (long?)dataFeed.IngestionSettings.IngestionRetryDelay?.TotalSeconds,
                    StopRetryAfterInSeconds = (long?)dataFeed.IngestionSettings.StopRetryAfter?.TotalSeconds,
                    NeedRollup = p.Options.RollupSettings.RollupType.HasValue ? new DataFeedDetailPatchNeedRollup(p.Options.RollupSettings.RollupType.ToString()) : default,
                    RollUpMethod = p.Options.RollupSettings.RollupMethod.HasValue ? new DataFeedDetailPatchRollUpMethod(p.Options.RollupSettings.RollupMethod.ToString()) : default,
                    RollUpColumns = p.Options.RollupSettings.AutoRollupGroupByColumnNames ?? new ChangeTrackingList<string>(),
                    AllUpIdentification = p.Options.RollupSettings.AlreadyRollupIdentificationValue,
                    FillMissingPointType = p.Options.MissingDataPointFillSettings.FillType.HasValue ? new DataFeedDetailPatchFillMissingPointType(p.Options.MissingDataPointFillSettings.FillType.ToString()) : default,
                    FillMissingPointValue = p.Options.MissingDataPointFillSettings.CustomFillValue,
                    ViewMode = p.Options.AccessMode.HasValue ? new DataFeedDetailPatchViewMode(p.Options.AccessMode.ToString()) : default,
                    Admins = p.Options.Administrators ?? new ChangeTrackingList<string>(),
                    Viewers = p.Options.Viewers ?? new ChangeTrackingList<string>(),
                    Status = p.Status.HasValue ? new DataFeedDetailPatchStatus(p.Status.ToString()) : default,
                },
                DataFeed p when p.SourceType == DataFeedSourceType.AzureCosmosDb => new AzureCosmosDBDataFeedPatch()
                {
                    DataFeedName = p.Name,
                    DataFeedDescription = p.Options.FeedDescription,
                    TimestampColumn = p.Schema.TimestampColumn,
                    DataStartFrom = p.IngestionSettings.IngestionStartTime,
                    StartOffsetInSeconds = (long?)dataFeed.IngestionSettings.IngestionStartOffset?.TotalSeconds,
                    MaxConcurrency = p.IngestionSettings.DataSourceRequestConcurrency,
                    MinRetryIntervalInSeconds = (long?)dataFeed.IngestionSettings.IngestionRetryDelay?.TotalSeconds,
                    StopRetryAfterInSeconds = (long?)dataFeed.IngestionSettings.StopRetryAfter?.TotalSeconds,
                    NeedRollup = p.Options.RollupSettings.RollupType.HasValue ? new DataFeedDetailPatchNeedRollup(p.Options.RollupSettings.RollupType.ToString()) : default,
                    RollUpMethod = p.Options.RollupSettings.RollupMethod.HasValue ? new DataFeedDetailPatchRollUpMethod(p.Options.RollupSettings.RollupMethod.ToString()) : default,
                    RollUpColumns = p.Options.RollupSettings.AutoRollupGroupByColumnNames ?? new ChangeTrackingList<string>(),
                    AllUpIdentification = p.Options.RollupSettings.AlreadyRollupIdentificationValue,
                    FillMissingPointType = p.Options.MissingDataPointFillSettings.FillType.HasValue ? new DataFeedDetailPatchFillMissingPointType(p.Options.MissingDataPointFillSettings.FillType.ToString()) : default,
                    FillMissingPointValue = p.Options.MissingDataPointFillSettings.CustomFillValue,
                    ViewMode = p.Options.AccessMode.HasValue ? new DataFeedDetailPatchViewMode(p.Options.AccessMode.ToString()) : default,
                    Admins = p.Options.Administrators ?? new ChangeTrackingList<string>(),
                    Viewers = p.Options.Viewers ?? new ChangeTrackingList<string>(),
                    Status = p.Status.HasValue ? new DataFeedDetailPatchStatus(p.Status.ToString()) : default,
                },
                DataFeed p when p.SourceType == DataFeedSourceType.AzureDataLakeStorageGen2 => new AzureDataLakeStorageGen2DataFeedPatch()
                {
                    DataFeedName = p.Name,
                    DataFeedDescription = p.Options.FeedDescription,
                    TimestampColumn = p.Schema.TimestampColumn,
                    DataStartFrom = p.IngestionSettings.IngestionStartTime,
                    StartOffsetInSeconds = (long?)dataFeed.IngestionSettings.IngestionStartOffset?.TotalSeconds,
                    MaxConcurrency = p.IngestionSettings.DataSourceRequestConcurrency,
                    MinRetryIntervalInSeconds = (long?)dataFeed.IngestionSettings.IngestionRetryDelay?.TotalSeconds,
                    StopRetryAfterInSeconds = (long?)dataFeed.IngestionSettings.StopRetryAfter?.TotalSeconds,
                    NeedRollup = p.Options.RollupSettings.RollupType.HasValue ? new DataFeedDetailPatchNeedRollup(p.Options.RollupSettings.RollupType.ToString()) : default,
                    RollUpMethod = p.Options.RollupSettings.RollupMethod.HasValue ? new DataFeedDetailPatchRollUpMethod(p.Options.RollupSettings.RollupMethod.ToString()) : default,
                    RollUpColumns = p.Options.RollupSettings.AutoRollupGroupByColumnNames ?? new ChangeTrackingList<string>(),
                    AllUpIdentification = p.Options.RollupSettings.AlreadyRollupIdentificationValue,
                    FillMissingPointType = p.Options.MissingDataPointFillSettings.FillType.HasValue ? new DataFeedDetailPatchFillMissingPointType(p.Options.MissingDataPointFillSettings.FillType.ToString()) : default,
                    FillMissingPointValue = p.Options.MissingDataPointFillSettings.CustomFillValue,
                    ViewMode = p.Options.AccessMode.HasValue ? new DataFeedDetailPatchViewMode(p.Options.AccessMode.ToString()) : default,
                    Admins = p.Options.Administrators ?? new ChangeTrackingList<string>(),
                    Viewers = p.Options.Viewers ?? new ChangeTrackingList<string>(),
                    Status = p.Status.HasValue ? new DataFeedDetailPatchStatus(p.Status.ToString()) : default,
                },
                DataFeed p when p.SourceType == DataFeedSourceType.AzureTable => new AzureTableDataFeedPatch()
                {
                    DataFeedName = p.Name,
                    DataFeedDescription = p.Options.FeedDescription,
                    TimestampColumn = p.Schema.TimestampColumn,
                    DataStartFrom = p.IngestionSettings.IngestionStartTime,
                    StartOffsetInSeconds = (long?)dataFeed.IngestionSettings.IngestionStartOffset?.TotalSeconds,
                    MaxConcurrency = p.IngestionSettings.DataSourceRequestConcurrency,
                    MinRetryIntervalInSeconds = (long?)dataFeed.IngestionSettings.IngestionRetryDelay?.TotalSeconds,
                    StopRetryAfterInSeconds = (long?)dataFeed.IngestionSettings.StopRetryAfter?.TotalSeconds,
                    NeedRollup = p.Options.RollupSettings.RollupType.HasValue ? new DataFeedDetailPatchNeedRollup(p.Options.RollupSettings.RollupType.ToString()) : default,
                    RollUpMethod = p.Options.RollupSettings.RollupMethod.HasValue ? new DataFeedDetailPatchRollUpMethod(p.Options.RollupSettings.RollupMethod.ToString()) : default,
                    RollUpColumns = p.Options.RollupSettings.AutoRollupGroupByColumnNames ?? new ChangeTrackingList<string>(),
                    AllUpIdentification = p.Options.RollupSettings.AlreadyRollupIdentificationValue,
                    FillMissingPointType = p.Options.MissingDataPointFillSettings.FillType.HasValue ? new DataFeedDetailPatchFillMissingPointType(p.Options.MissingDataPointFillSettings.FillType.ToString()) : default,
                    FillMissingPointValue = p.Options.MissingDataPointFillSettings.CustomFillValue,
                    ViewMode = p.Options.AccessMode.HasValue ? new DataFeedDetailPatchViewMode(p.Options.AccessMode.ToString()) : default,
                    Admins = p.Options.Administrators ?? new ChangeTrackingList<string>(),
                    Viewers = p.Options.Viewers ?? new ChangeTrackingList<string>(),
                    Status = p.Status.HasValue ? new DataFeedDetailPatchStatus(p.Status.ToString()) : default,
                },
                DataFeed p when p.SourceType == DataFeedSourceType.Elasticsearch => new ElasticsearchDataFeedPatch()
                {
                    DataFeedName = p.Name,
                    DataFeedDescription = p.Options.FeedDescription,
                    TimestampColumn = p.Schema.TimestampColumn,
                    DataStartFrom = p.IngestionSettings.IngestionStartTime,
                    StartOffsetInSeconds = (long?)dataFeed.IngestionSettings.IngestionStartOffset?.TotalSeconds,
                    MaxConcurrency = p.IngestionSettings.DataSourceRequestConcurrency,
                    MinRetryIntervalInSeconds = (long?)dataFeed.IngestionSettings.IngestionRetryDelay?.TotalSeconds,
                    StopRetryAfterInSeconds = (long?)dataFeed.IngestionSettings.StopRetryAfter?.TotalSeconds,
                    NeedRollup = p.Options.RollupSettings.RollupType.HasValue ? new DataFeedDetailPatchNeedRollup(p.Options.RollupSettings.RollupType.ToString()) : default,
                    RollUpMethod = p.Options.RollupSettings.RollupMethod.HasValue ? new DataFeedDetailPatchRollUpMethod(p.Options.RollupSettings.RollupMethod.ToString()) : default,
                    RollUpColumns = p.Options.RollupSettings.AutoRollupGroupByColumnNames ?? new ChangeTrackingList<string>(),
                    AllUpIdentification = p.Options.RollupSettings.AlreadyRollupIdentificationValue,
                    FillMissingPointType = p.Options.MissingDataPointFillSettings.FillType.HasValue ? new DataFeedDetailPatchFillMissingPointType(p.Options.MissingDataPointFillSettings.FillType.ToString()) : default,
                    FillMissingPointValue = p.Options.MissingDataPointFillSettings.CustomFillValue,
                    ViewMode = p.Options.AccessMode.HasValue ? new DataFeedDetailPatchViewMode(p.Options.AccessMode.ToString()) : default,
                    Admins = p.Options.Administrators ?? new ChangeTrackingList<string>(),
                    Viewers = p.Options.Viewers ?? new ChangeTrackingList<string>(),
                    Status = p.Status.HasValue ? new DataFeedDetailPatchStatus(p.Status.ToString()) : default,
                },
                DataFeed p when p.SourceType == DataFeedSourceType.HttpRequest => new HttpRequestDataFeedPatch()
                {
                    DataFeedName = p.Name,
                    DataFeedDescription = p.Options.FeedDescription,
                    TimestampColumn = p.Schema.TimestampColumn,
                    DataStartFrom = p.IngestionSettings.IngestionStartTime,
                    StartOffsetInSeconds = (long?)dataFeed.IngestionSettings.IngestionStartOffset?.TotalSeconds,
                    MaxConcurrency = p.IngestionSettings.DataSourceRequestConcurrency,
                    MinRetryIntervalInSeconds = (long?)dataFeed.IngestionSettings.IngestionRetryDelay?.TotalSeconds,
                    StopRetryAfterInSeconds = (long?)dataFeed.IngestionSettings.StopRetryAfter?.TotalSeconds,
                    NeedRollup = p.Options.RollupSettings.RollupType.HasValue ? new DataFeedDetailPatchNeedRollup(p.Options.RollupSettings.RollupType.ToString()) : default,
                    RollUpMethod = p.Options.RollupSettings.RollupMethod.HasValue ? new DataFeedDetailPatchRollUpMethod(p.Options.RollupSettings.RollupMethod.ToString()) : default,
                    RollUpColumns = p.Options.RollupSettings.AutoRollupGroupByColumnNames ?? new ChangeTrackingList<string>(),
                    AllUpIdentification = p.Options.RollupSettings.AlreadyRollupIdentificationValue,
                    FillMissingPointType = p.Options.MissingDataPointFillSettings.FillType.HasValue ? new DataFeedDetailPatchFillMissingPointType(p.Options.MissingDataPointFillSettings.FillType.ToString()) : default,
                    FillMissingPointValue = p.Options.MissingDataPointFillSettings.CustomFillValue,
                    ViewMode = p.Options.AccessMode.HasValue ? new DataFeedDetailPatchViewMode(p.Options.AccessMode.ToString()) : default,
                    Admins = p.Options.Administrators ?? new ChangeTrackingList<string>(),
                    Viewers = p.Options.Viewers ?? new ChangeTrackingList<string>(),
                    Status = p.Status.HasValue ? new DataFeedDetailPatchStatus(p.Status.ToString()) : default,
                },
                DataFeed p when p.SourceType == DataFeedSourceType.InfluxDb => new InfluxDBDataFeedPatch()
                {
                    DataFeedName = p.Name,
                    DataFeedDescription = p.Options.FeedDescription,
                    TimestampColumn = p.Schema.TimestampColumn,
                    DataStartFrom = p.IngestionSettings.IngestionStartTime,
                    StartOffsetInSeconds = (long?)dataFeed.IngestionSettings.IngestionStartOffset?.TotalSeconds,
                    MaxConcurrency = p.IngestionSettings.DataSourceRequestConcurrency,
                    MinRetryIntervalInSeconds = (long?)dataFeed.IngestionSettings.IngestionRetryDelay?.TotalSeconds,
                    StopRetryAfterInSeconds = (long?)dataFeed.IngestionSettings.StopRetryAfter?.TotalSeconds,
                    NeedRollup = p.Options.RollupSettings.RollupType.HasValue ? new DataFeedDetailPatchNeedRollup(p.Options.RollupSettings.RollupType.ToString()) : default,
                    RollUpMethod = p.Options.RollupSettings.RollupMethod.HasValue ? new DataFeedDetailPatchRollUpMethod(p.Options.RollupSettings.RollupMethod.ToString()) : default,
                    RollUpColumns = p.Options.RollupSettings.AutoRollupGroupByColumnNames ?? new ChangeTrackingList<string>(),
                    AllUpIdentification = p.Options.RollupSettings.AlreadyRollupIdentificationValue,
                    FillMissingPointType = p.Options.MissingDataPointFillSettings.FillType.HasValue ? new DataFeedDetailPatchFillMissingPointType(p.Options.MissingDataPointFillSettings.FillType.ToString()) : default,
                    FillMissingPointValue = p.Options.MissingDataPointFillSettings.CustomFillValue,
                    ViewMode = p.Options.AccessMode.HasValue ? new DataFeedDetailPatchViewMode(p.Options.AccessMode.ToString()) : default,
                    Admins = p.Options.Administrators ?? new ChangeTrackingList<string>(),
                    Viewers = p.Options.Viewers ?? new ChangeTrackingList<string>(),
                    Status = p.Status.HasValue ? new DataFeedDetailPatchStatus(p.Status.ToString()) : default,
                },
                DataFeed p when p.SourceType == DataFeedSourceType.AzureDataExplorer => new AzureDataExplorerDataFeedPatch()
                {
                    DataFeedName = p.Name,
                    DataFeedDescription = p.Options.FeedDescription,
                    TimestampColumn = p.Schema.TimestampColumn,
                    DataStartFrom = p.IngestionSettings.IngestionStartTime,
                    StartOffsetInSeconds = (long?)dataFeed.IngestionSettings.IngestionStartOffset?.TotalSeconds,
                    MaxConcurrency = p.IngestionSettings.DataSourceRequestConcurrency,
                    MinRetryIntervalInSeconds = (long?)dataFeed.IngestionSettings.IngestionRetryDelay?.TotalSeconds,
                    StopRetryAfterInSeconds = (long?)dataFeed.IngestionSettings.StopRetryAfter?.TotalSeconds,
                    NeedRollup = p.Options.RollupSettings.RollupType.HasValue ? new DataFeedDetailPatchNeedRollup(p.Options.RollupSettings.RollupType.ToString()) : default,
                    RollUpMethod = p.Options.RollupSettings.RollupMethod.HasValue ? new DataFeedDetailPatchRollUpMethod(p.Options.RollupSettings.RollupMethod.ToString()) : default,
                    RollUpColumns = p.Options.RollupSettings.AutoRollupGroupByColumnNames ?? new ChangeTrackingList<string>(),
                    AllUpIdentification = p.Options.RollupSettings.AlreadyRollupIdentificationValue,
                    FillMissingPointType = p.Options.MissingDataPointFillSettings.FillType.HasValue ? new DataFeedDetailPatchFillMissingPointType(p.Options.MissingDataPointFillSettings.FillType.ToString()) : default,
                    FillMissingPointValue = p.Options.MissingDataPointFillSettings.CustomFillValue,
                    ViewMode = p.Options.AccessMode.HasValue ? new DataFeedDetailPatchViewMode(p.Options.AccessMode.ToString()) : default,
                    Admins = p.Options.Administrators ?? new ChangeTrackingList<string>(),
                    Viewers = p.Options.Viewers ?? new ChangeTrackingList<string>(),
                    Status = p.Status.HasValue ? new DataFeedDetailPatchStatus(p.Status.ToString()) : default,
                },
                DataFeed p when p.SourceType == DataFeedSourceType.MySql => new MySqlDataFeedPatch()
                {
                    DataFeedName = p.Name,
                    DataFeedDescription = p.Options.FeedDescription,
                    TimestampColumn = p.Schema.TimestampColumn,
                    DataStartFrom = p.IngestionSettings.IngestionStartTime,
                    StartOffsetInSeconds = (long?)dataFeed.IngestionSettings.IngestionStartOffset?.TotalSeconds,
                    MaxConcurrency = p.IngestionSettings.DataSourceRequestConcurrency,
                    MinRetryIntervalInSeconds = (long?)dataFeed.IngestionSettings.IngestionRetryDelay?.TotalSeconds,
                    StopRetryAfterInSeconds = (long?)dataFeed.IngestionSettings.StopRetryAfter?.TotalSeconds,
                    NeedRollup = p.Options.RollupSettings.RollupType.HasValue ? new DataFeedDetailPatchNeedRollup(p.Options.RollupSettings.RollupType.ToString()) : default,
                    RollUpMethod = p.Options.RollupSettings.RollupMethod.HasValue ? new DataFeedDetailPatchRollUpMethod(p.Options.RollupSettings.RollupMethod.ToString()) : default,
                    RollUpColumns = p.Options.RollupSettings.AutoRollupGroupByColumnNames ?? new ChangeTrackingList<string>(),
                    AllUpIdentification = p.Options.RollupSettings.AlreadyRollupIdentificationValue,
                    FillMissingPointType = p.Options.MissingDataPointFillSettings.FillType.HasValue ? new DataFeedDetailPatchFillMissingPointType(p.Options.MissingDataPointFillSettings.FillType.ToString()) : default,
                    FillMissingPointValue = p.Options.MissingDataPointFillSettings.CustomFillValue,
                    ViewMode = p.Options.AccessMode.HasValue ? new DataFeedDetailPatchViewMode(p.Options.AccessMode.ToString()) : default,
                    Admins = p.Options.Administrators ?? new ChangeTrackingList<string>(),
                    Viewers = p.Options.Viewers ?? new ChangeTrackingList<string>(),
                    Status = p.Status.HasValue ? new DataFeedDetailPatchStatus(p.Status.ToString()) : default,
                },
                DataFeed p when p.SourceType == DataFeedSourceType.PostgreSql => new PostgreSqlDataFeedPatch()
                {
                    DataFeedName = p.Name,
                    DataFeedDescription = p.Options.FeedDescription,
                    TimestampColumn = p.Schema.TimestampColumn,
                    DataStartFrom = p.IngestionSettings.IngestionStartTime,
                    StartOffsetInSeconds = (long?)dataFeed.IngestionSettings.IngestionStartOffset?.TotalSeconds,
                    MaxConcurrency = p.IngestionSettings.DataSourceRequestConcurrency,
                    MinRetryIntervalInSeconds = (long?)dataFeed.IngestionSettings.IngestionRetryDelay?.TotalSeconds,
                    StopRetryAfterInSeconds = (long?)dataFeed.IngestionSettings.StopRetryAfter?.TotalSeconds,
                    NeedRollup = p.Options.RollupSettings.RollupType.HasValue ? new DataFeedDetailPatchNeedRollup(p.Options.RollupSettings.RollupType.ToString()) : default,
                    RollUpMethod = p.Options.RollupSettings.RollupMethod.HasValue ? new DataFeedDetailPatchRollUpMethod(p.Options.RollupSettings.RollupMethod.ToString()) : default,
                    RollUpColumns = p.Options.RollupSettings.AutoRollupGroupByColumnNames ?? new ChangeTrackingList<string>(),
                    AllUpIdentification = p.Options.RollupSettings.AlreadyRollupIdentificationValue,
                    FillMissingPointType = p.Options.MissingDataPointFillSettings.FillType.HasValue ? new DataFeedDetailPatchFillMissingPointType(p.Options.MissingDataPointFillSettings.FillType.ToString()) : default,
                    FillMissingPointValue = p.Options.MissingDataPointFillSettings.CustomFillValue,
                    ViewMode = p.Options.AccessMode.HasValue ? new DataFeedDetailPatchViewMode(p.Options.AccessMode.ToString()) : default,
                    Admins = p.Options.Administrators ?? new ChangeTrackingList<string>(),
                    Viewers = p.Options.Viewers ?? new ChangeTrackingList<string>(),
                    Status = p.Status.HasValue ? new DataFeedDetailPatchStatus(p.Status.ToString()) : default,
                },
                DataFeed p when p.SourceType == DataFeedSourceType.SqlServer => new SQLServerDataFeedPatch()
                {
                    DataFeedName = p.Name,
                    DataFeedDescription = p.Options.FeedDescription,
                    TimestampColumn = p.Schema.TimestampColumn,
                    DataStartFrom = p.IngestionSettings.IngestionStartTime,
                    StartOffsetInSeconds = (long?)dataFeed.IngestionSettings.IngestionStartOffset?.TotalSeconds,
                    MaxConcurrency = p.IngestionSettings.DataSourceRequestConcurrency,
                    MinRetryIntervalInSeconds = (long?)dataFeed.IngestionSettings.IngestionRetryDelay?.TotalSeconds,
                    StopRetryAfterInSeconds = (long?)dataFeed.IngestionSettings.StopRetryAfter?.TotalSeconds,
                    NeedRollup = p.Options.RollupSettings.RollupType.HasValue ? new DataFeedDetailPatchNeedRollup(p.Options.RollupSettings.RollupType.ToString()) : default,
                    RollUpMethod = p.Options.RollupSettings.RollupMethod.HasValue ? new DataFeedDetailPatchRollUpMethod(p.Options.RollupSettings.RollupMethod.ToString()) : default,
                    RollUpColumns = p.Options.RollupSettings.AutoRollupGroupByColumnNames ?? new ChangeTrackingList<string>(),
                    AllUpIdentification = p.Options.RollupSettings.AlreadyRollupIdentificationValue,
                    FillMissingPointType = p.Options.MissingDataPointFillSettings.FillType.HasValue ? new DataFeedDetailPatchFillMissingPointType(p.Options.MissingDataPointFillSettings.FillType.ToString()) : default,
                    FillMissingPointValue = p.Options.MissingDataPointFillSettings.CustomFillValue,
                    ViewMode = p.Options.AccessMode.HasValue ? new DataFeedDetailPatchViewMode(p.Options.AccessMode.ToString()) : default,
                    Admins = p.Options.Administrators ?? new ChangeTrackingList<string>(),
                    Viewers = p.Options.Viewers ?? new ChangeTrackingList<string>(),
                    Status = p.Status.HasValue ? new DataFeedDetailPatchStatus(p.Status.ToString()) : default,
                },
                DataFeed p when p.SourceType == DataFeedSourceType.MongoDb => new MongoDBDataFeedPatch()
                {
                    DataFeedName = p.Name,
                    DataFeedDescription = p.Options.FeedDescription,
                    TimestampColumn = p.Schema.TimestampColumn,
                    DataStartFrom = p.IngestionSettings.IngestionStartTime,
                    StartOffsetInSeconds = (long?)dataFeed.IngestionSettings.IngestionStartOffset?.TotalSeconds,
                    MaxConcurrency = p.IngestionSettings.DataSourceRequestConcurrency,
                    MinRetryIntervalInSeconds = (long?)dataFeed.IngestionSettings.IngestionRetryDelay?.TotalSeconds,
                    StopRetryAfterInSeconds = (long?)dataFeed.IngestionSettings.StopRetryAfter?.TotalSeconds,
                    NeedRollup = p.Options.RollupSettings.RollupType.HasValue ? new DataFeedDetailPatchNeedRollup(p.Options.RollupSettings.RollupType.ToString()) : default,
                    RollUpMethod = p.Options.RollupSettings.RollupMethod.HasValue ? new DataFeedDetailPatchRollUpMethod(p.Options.RollupSettings.RollupMethod.ToString()) : default,
                    RollUpColumns = p.Options.RollupSettings.AutoRollupGroupByColumnNames ?? new ChangeTrackingList<string>(),
                    AllUpIdentification = p.Options.RollupSettings.AlreadyRollupIdentificationValue,
                    FillMissingPointType = p.Options.MissingDataPointFillSettings.FillType.HasValue ? new DataFeedDetailPatchFillMissingPointType(p.Options.MissingDataPointFillSettings.FillType.ToString()) : default,
                    FillMissingPointValue = p.Options.MissingDataPointFillSettings.CustomFillValue,
                    ViewMode = p.Options.AccessMode.HasValue ? new DataFeedDetailPatchViewMode(p.Options.AccessMode.ToString()) : default,
                    Admins = p.Options.Administrators ?? new ChangeTrackingList<string>(),
                    Viewers = p.Options.Viewers ?? new ChangeTrackingList<string>(),
                    Status = p.Status.HasValue ? new DataFeedDetailPatchStatus(p.Status.ToString()) : default,
                },
                _ => throw new InvalidOperationException("Invalid DataFeedDetail type")
            };
        }
    }
}
