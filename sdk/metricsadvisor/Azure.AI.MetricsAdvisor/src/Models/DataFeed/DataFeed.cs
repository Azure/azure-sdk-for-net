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
        /// <summary>
        /// Initializes a new instance of the <see cref="DataFeed"/> class.
        /// </summary>
        /// <param name="dataFeedName">A custom name for the <see cref="DataFeed"/>.</param>
        /// <param name="dataSource">The source from which data is consumed.</param>
        /// <param name="dataFeedGranularity">The frequency with which ingestion from the data source occurs.</param>
        /// <param name="dataFeedSchema">Defines how this <see cref="DataFeed"/> structures the data ingested from the data source in terms of metrics and dimensions.</param>
        /// <param name="dataFeedIngestionSettings">Configures how a <see cref="DataFeed"/> behaves during data ingestion from its data source.</param>
        /// <exception cref="ArgumentNullException"><paramref name="dataFeedName"/>, <paramref name="dataSource"/>, <paramref name="dataFeedGranularity"/>, <paramref name="dataFeedSchema"/>, or <paramref name="dataFeedIngestionSettings"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="dataFeedName"/> is empty.</exception>
        public DataFeed(string dataFeedName, DataFeedSource dataSource, DataFeedGranularity dataFeedGranularity, DataFeedSchema dataFeedSchema, DataFeedIngestionSettings dataFeedIngestionSettings)
        {
            Argument.AssertNotNullOrEmpty(dataFeedName, nameof(dataFeedName));
            Argument.AssertNotNull(dataSource, nameof(dataSource));
            Argument.AssertNotNull(dataFeedGranularity, nameof(dataFeedGranularity));
            Argument.AssertNotNull(dataFeedSchema, nameof(dataFeedSchema));
            Argument.AssertNotNull(dataFeedIngestionSettings, nameof(dataFeedIngestionSettings));

            Name = dataFeedName;
            DataSource = dataSource;
            SourceType = dataSource.Type;
            Granularity = dataFeedGranularity;
            Schema = dataFeedSchema;
            IngestionSettings = dataFeedIngestionSettings;
        }

        internal DataFeed(DataFeedDetail dataFeedDetail)
        {
            Id = dataFeedDetail.DataFeedId;
            Status = dataFeedDetail.Status;
            CreatedTime = dataFeedDetail.CreatedTime;
            Creator = dataFeedDetail.Creator;
            IsAdministrator = dataFeedDetail.IsAdmin;
            MetricIds = dataFeedDetail.Metrics.Select(metric => metric.MetricId).ToList();
            Name = dataFeedDetail.DataFeedName;
            DataSource = DataFeedSource.GetDataFeedSource(dataFeedDetail);
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
        /// The e-mail address of creator of this <see cref="DataFeed"/>.
        /// </summary>
        public string Creator { get; }

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
        /// The source from which data is consumed.
        /// </summary>
        public DataFeedSource DataSource { get; }

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
        public DataFeedOptions Options { get; set; }

        internal DataFeedDetail GetDataFeedDetail()
        {
            DataFeedDetail detail = DataSource.InstantiateDataFeedDetail(Name, Granularity.GranularityType, Schema.MetricColumns, IngestionSettings.IngestionStartTime);

            foreach (var column in Schema.DimensionColumns)
            {
                detail.Dimension.Add(column);
            }
            detail.TimestampColumn = Schema.TimestampColumn;

            detail.GranularityAmount = Granularity.CustomGranularityValue;

            detail.MaxConcurrency = IngestionSettings.DataSourceRequestConcurrency;
            detail.MinRetryIntervalInSeconds = (long?)IngestionSettings.IngestionRetryDelay?.TotalSeconds;
            detail.StartOffsetInSeconds = (long?)IngestionSettings.IngestionStartOffset?.TotalSeconds;
            detail.StopRetryAfterInSeconds = (long?)IngestionSettings.StopRetryAfter?.TotalSeconds;

            if (Options != null)
            {
                detail.DataFeedDescription = Options.Description;
                detail.ActionLinkTemplate = Options.ActionLinkTemplate;
                detail.ViewMode = Options.AccessMode;
                if (Options.RollupSettings != null)
                {
                    detail.AllUpIdentification = Options.RollupSettings.AlreadyRollupIdentificationValue;
                    detail.NeedRollup = Options.RollupSettings.RollupType;
                    detail.RollUpMethod = Options.RollupSettings.RollupMethod;
                    foreach (string columnName in Options.RollupSettings.AutoRollupGroupByColumnNames)
                    {
                        detail.RollUpColumns.Add(columnName);
                    }
                }
                if (Options.MissingDataPointFillSettings != null)
                {
                    detail.FillMissingPointType = Options.MissingDataPointFillSettings.FillType;
                    detail.FillMissingPointValue = Options.MissingDataPointFillSettings.CustomFillValue;
                }
                foreach (string admin in Options.Administrators)
                {
                    detail.Admins.Add(admin);
                }
                foreach (string viewer in Options.Viewers)
                {
                    detail.Admins.Add(viewer);
                }
            }

            return detail;
        }

        /// <summary>
        /// Converts a data source specific <see cref="DataFeed"/> into its equivalent data source specific <see cref="DataFeedDetailPatch"/>.
        /// </summary>
        internal DataFeedDetailPatch GetPatchModel()
        {
            DataFeedDetailPatch patch = DataSource.InstantiateDataFeedDetailPatch();

            patch.DataFeedName = Name;
            patch.Status = Status.HasValue ? new DataFeedDetailPatchStatus(Status.ToString()) : default;

            patch.TimestampColumn = Schema.TimestampColumn;

            patch.DataStartFrom = ClientCommon.NormalizeDateTimeOffset(IngestionSettings.IngestionStartTime);
            patch.MaxConcurrency = IngestionSettings.DataSourceRequestConcurrency;
            patch.MinRetryIntervalInSeconds = (long?)IngestionSettings.IngestionRetryDelay?.TotalSeconds;
            patch.StartOffsetInSeconds = (long?)IngestionSettings.IngestionStartOffset?.TotalSeconds;
            patch.StopRetryAfterInSeconds = (long?)IngestionSettings.StopRetryAfter?.TotalSeconds;

            if (Options != null)
            {
                patch.DataFeedDescription = Options.Description;
                patch.ActionLinkTemplate = Options.ActionLinkTemplate;
                patch.ViewMode = Options.AccessMode.HasValue == true ? new DataFeedDetailPatchViewMode(Options.AccessMode.ToString()) : default;
                if (Options.RollupSettings != null)
                {
                    patch.AllUpIdentification = Options.RollupSettings.AlreadyRollupIdentificationValue;
                    patch.NeedRollup = Options.RollupSettings.RollupType.HasValue ? new DataFeedDetailPatchNeedRollup(Options.RollupSettings.RollupType.ToString()) : default;
                    patch.RollUpMethod = Options.RollupSettings.RollupMethod.HasValue ? new DataFeedDetailPatchRollUpMethod(Options.RollupSettings.RollupMethod.ToString()) : default;
                    patch.RollUpColumns = Options.RollupSettings.AutoRollupGroupByColumnNames;
                }
                if (Options.MissingDataPointFillSettings != null)
                {
                    patch.FillMissingPointType = Options.MissingDataPointFillSettings.FillType.HasValue ? new DataFeedDetailPatchFillMissingPointType(Options.MissingDataPointFillSettings.FillType.ToString()) : default;
                    patch.FillMissingPointValue = Options.MissingDataPointFillSettings.CustomFillValue;
                }
                patch.Admins = Options.Administrators;
                patch.Viewers = Options.Viewers;
            }

            return patch;
        }
    }
}
