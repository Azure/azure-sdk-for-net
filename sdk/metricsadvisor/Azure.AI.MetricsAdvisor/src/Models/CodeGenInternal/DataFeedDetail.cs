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
        public IList<DataFeedDimension> Dimension { get; }

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
            Dimension = new ChangeTrackingList<DataFeedDimension>();
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
        internal DataFeedDetail(DataFeedSourceType dataSourceType, string dataFeedId, string dataFeedName, string dataFeedDescription, DataFeedGranularityType granularityName, int? granularityAmount, IList<DataFeedMetric> metrics, IList<DataFeedDimension> dimension, string timestampColumn, DateTimeOffset dataStartFrom, long? startOffsetInSeconds, int? maxConcurrency, long? minRetryIntervalInSeconds, long? stopRetryAfterInSeconds, DataFeedRollupType? needRollup, DataFeedAutoRollupMethod? rollUpMethod, IList<string> rollUpColumns, string allUpIdentification, DataFeedMissingDataPointFillType? fillMissingPointType, double? fillMissingPointValue, DataFeedAccessMode? viewMode, IList<string> admins, IList<string> viewers, bool? isAdmin, string creator, DataFeedStatus? status, DateTimeOffset? createdTime, string actionLinkTemplate)
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
            Dimension = dimension ?? new ChangeTrackingList<DataFeedDimension>();
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
    }
}
