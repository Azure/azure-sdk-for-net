// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// A data feed is the entry point of data for the Metrics Advisor service and, therefore, the first
    /// entity to be created when setting up your resource. It periodically ingests data from a
    /// <see cref="DataFeedSource"/> and monitors it in search of anomalies.
    /// </summary>
    /// <remarks>
    /// In order to create a data feed, you must set up at least the properties <see cref="Name"/>,
    /// <see cref="DataSource"/>, <see cref="Granularity"/>, <see cref="IngestionSettings"/>, and
    /// <see cref="Schema"/>, and pass this instance to the method
    /// <see cref="MetricsAdvisorAdministrationClient.CreateDataFeedAsync"/>.
    /// </remarks>
    public class DataFeed
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataFeed"/> class.
        /// </summary>
        public DataFeed()
        {
            Administrators = new ChangeTrackingList<string>();
            Viewers = new ChangeTrackingList<string>();
        }

        internal DataFeed(DataFeedDetail dataFeedDetail)
        {
            Id = dataFeedDetail.DataFeedId;
            Status = dataFeedDetail.Status;
            CreatedOn = dataFeedDetail.CreatedTime;
            Creator = dataFeedDetail.Creator;
            IsAdministrator = dataFeedDetail.IsAdmin;
            MetricIds = dataFeedDetail.Metrics.ToDictionary(metric => metric.Name, metric => metric.Id);
            Name = dataFeedDetail.DataFeedName;
            DataSource = DataFeedSource.GetDataFeedSource(dataFeedDetail);
            Schema = new DataFeedSchema(dataFeedDetail);
            Granularity = new DataFeedGranularity(dataFeedDetail);
            IngestionSettings = new DataFeedIngestionSettings(dataFeedDetail);
            Description = dataFeedDetail.DataFeedDescription;
            ActionLinkTemplate = dataFeedDetail.ActionLinkTemplate;
            AccessMode = dataFeedDetail.ViewMode;
            RollupSettings = new DataFeedRollupSettings(dataFeedDetail);
            MissingDataPointFillSettings = new DataFeedMissingDataPointFillSettings(dataFeedDetail);
            Administrators = dataFeedDetail.Admins;
            Viewers = dataFeedDetail.Viewers;
        }

        /// <summary>
        /// The unique identifier of this <see cref="DataFeed"/>.
        /// </summary>
        /// <remarks>
        /// If <c>null</c>, it means this instance has not been sent to the service to be created yet. This property
        /// will be set by the service after creation.
        /// </remarks>
        public string Id { get; internal set; }

        /// <summary>
        /// The current ingestion status of this <see cref="DataFeed"/>. Only <see cref="DataFeedStatus.Active"/>
        /// and <see cref="DataFeedStatus.Paused"/> are supported.
        /// </summary>
        /// <remarks>
        /// If <c>null</c>, it means this instance has not been sent to the service to be created yet. Once created,
        /// the status is initialized as <see cref="DataFeedStatus.Active"/>.
        /// </remarks>
        public DataFeedStatus? Status { get; }

        /// <summary>
        /// The date and time, in UTC, when this <see cref="DataFeed"/> was created.
        /// </summary>
        /// <remarks>
        /// If <c>null</c>, it means this instance has not been sent to the service to be created yet. This property
        /// will be set by the service after creation.
        /// </remarks>
        public DateTimeOffset? CreatedOn { get; }

        /// <summary>
        /// The user who created this <see cref="DataFeed"/>. If <see cref="MetricsAdvisorKeyCredential"/>
        /// authentication was used when creating the data feed, this property contains the email address of the
        /// creator. If AAD authentication was used instead, the value of this property uniquely identifies the
        /// creator's user principal, but its value depends on the type of credential used. For instance, if a
        /// <c>ClientSecretCredential</c> is used, it will contain the client ID.
        /// </summary>
        /// <remarks>
        /// If <c>null</c>, it means this instance has not been sent to the service to be created yet. This property
        /// will be set by the service after creation.
        /// </remarks>
        public string Creator { get; }

        /// <summary>
        /// Whether or not the user who queried the information about this <see cref="DataFeed"/>
        /// is one of its administrators. The complete list of administrators can be consulted in
        /// <see cref="Administrators"/>.
        /// </summary>
        /// <remarks>
        /// If <c>null</c>, it means this instance has not been sent to the service to be created yet.
        /// </remarks>
        public bool? IsAdministrator { get; }

        /// <summary>
        /// The unique identifiers of the metrics of this <see cref="DataFeed"/>. Keys are the metric
        /// names, and values are their corresponding IDs.
        /// </summary>
        /// <remarks>
        /// If empty, it means this instance has not been sent to the service to be created yet.
        /// </remarks>
        public IReadOnlyDictionary<string, string> MetricIds { get; }

        /// <summary>
        /// A custom name for this <see cref="DataFeed"/> to be displayed on the web portal. Data feed names
        /// must be unique across the same Metris Advisor resource.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The source that periodically provides data to this <see cref="DataFeed"/>.
        /// </summary>
        /// <remarks>
        /// Once the data feed is created, the kind of <see cref="DataFeedSource"/> cannot be changed anymore.
        /// You can, however, update its properties.
        /// </remarks>
        public DataFeedSource DataSource { get; set; }

        /// <summary>
        /// Specifies which values, such as metrics and dimensions, will be ingested from the <see cref="DataFeedSource"/>.
        /// </summary>
        /// <remarks>
        /// Once the data feed is created, the metrics and dimensions defined in the schema cannot be changed
        /// anymore. You can still update the property <see cref="DataFeedSchema.TimestampColumn"/>.
        /// </remarks>
        public DataFeedSchema Schema { get; set; }

        /// <summary>
        /// The frequency with which ingestion from the <see cref="DataSource"/> will happen.
        /// </summary>
        /// <remarks>
        /// Once the data feed is created, this property cannot be changed anymore.
        /// </remarks>
        public DataFeedGranularity Granularity { get; set; }

        /// <summary>
        /// Configures how a <see cref="DataFeed"/> should ingest data from its <see cref="DataSource"/>.
        /// </summary>
        public DataFeedIngestionSettings IngestionSettings { get; set; }

        /// <summary>
        /// A description of this <see cref="DataFeed"/>. Defaults to an empty string.
        /// </summary>
        /// <remarks>
        /// If set to null during an update operation, this property is set to its default value.
        /// </remarks>
        public string Description { get; set; }

        /// <summary>
        /// Defines actionable HTTP URLs, which consist of the placeholders %datafeed, %metric, %timestamp, %detect_config, and %tagset.
        /// You can use the template to redirect from an anomaly or an incident to a specific URL to drill down.
        /// See the <see href="https://aka.ms/metricsadvisor/actionlinktemplate">documentation</see> for details.
        /// Defaults to an empty string.
        /// </summary>
        /// <remarks>
        /// If set to null during an update operation, this property is set to its default value.
        /// </remarks>
        public string ActionLinkTemplate { get; set; }

        /// <summary>
        /// The access mode for this <see cref="DataFeed"/>. Only <see cref="DataFeedAccessMode.Private"/>
        /// and <see cref="DataFeedAccessMode.Public"/> are supported. Defaults to <see cref="DataFeedAccessMode.Private"/>.
        /// </summary>
        /// <remarks>
        /// If set to null during an update operation, this property is set to its default value.
        /// </remarks>
        public DataFeedAccessMode? AccessMode { get; set; }

        /// <summary>
        /// Configures the behavior of this <see cref="DataFeed"/> when handling rolled-up ingested data
        /// before detecting anomalies.
        /// </summary>
        public DataFeedRollupSettings RollupSettings { get; set; }

        /// <summary>
        /// Configures the behavior of this <see cref="DataFeed"/> when handling missing points in the
        /// data ingested from the <see cref="DataSource"/>. Defaults to settings with
        /// <see cref="DataFeedMissingDataPointFillType.SmartFilling"/> set.
        /// </summary>
        /// <remarks>
        /// If set to null during an update operation, this property is set to its default value.
        /// </remarks>
        public DataFeedMissingDataPointFillSettings MissingDataPointFillSettings { get; set; }

        /// <summary>
        /// The administrators of this <see cref="DataFeed"/>. Administrators have total control over a data feed, being allowed
        /// to update, delete, or pause them. Each element in this list represents a user with administrator access, but the value
        /// of each <c>string</c> element depends on the type of authentication to be used by this administrator when communicating
        /// with the service. If <see cref="MetricsAdvisorKeyCredential"/> authentication will be used, the <c>string</c> must be the
        /// user's email address. If AAD authentication will be used instead, the <c>string</c> must uniquely identify the user's
        /// principal. For instance, for a <c>ClientSecretCredential</c>, the <c>string</c> must be the client ID.
        /// </summary>
        /// <remarks>
        /// Upon data feed creation, the <see cref="Creator"/> is automatically assigned as an administrator by the service.
        /// </remarks>
        public IList<string> Administrators { get; }

        /// <summary>
        /// The viewers of this <see cref="DataFeed"/>. Viewers have read-only access to a data feed. Each element in this list
        /// represents a user with viewer access, but the value of each <c>string</c> element depends on the type of authentication
        /// to be used by this viewer when communicating with the service. If <see cref="MetricsAdvisorKeyCredential"/> authentication
        /// will be used, the <c>string</c> must be the user's email address. If AAD authentication will be used instead, the
        /// <c>string</c> must uniquely identify the user's principal. For instance, for a <c>ClientSecretCredential</c>, the
        /// <c>string</c> must be the client ID.
        /// </summary>
        public IList<string> Viewers { get; }

        internal DataFeedDetail GetDataFeedDetail()
        {
            DataFeedDetail detail = DataSource.InstantiateDataFeedDetail(Name, Granularity.GranularityType, Schema.MetricColumns, IngestionSettings.IngestionStartsOn);

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

            detail.DataFeedDescription = Description;
            detail.ActionLinkTemplate = ActionLinkTemplate;
            detail.ViewMode = AccessMode;

            if (RollupSettings != null)
            {
                detail.AllUpIdentification = RollupSettings.RollupIdentificationValue;
                detail.NeedRollup = RollupSettings.RollupType;
                detail.RollUpMethod = RollupSettings.AutoRollupMethod;
                foreach (string columnName in RollupSettings.AutoRollupGroupByColumnNames)
                {
                    detail.RollUpColumns.Add(columnName);
                }
            }

            if (MissingDataPointFillSettings != null)
            {
                detail.FillMissingPointType = MissingDataPointFillSettings.FillType;
                detail.FillMissingPointValue = MissingDataPointFillSettings.CustomFillValue;
            }

            foreach (var admin in Administrators)
            {
                detail.Admins.Add(admin);
            }

            foreach (var viewer in Viewers)
            {
                detail.Viewers.Add(viewer);
            }

            SetAuthenticationProperties(detail, DataSource);

            return detail;
        }

        /// <summary>
        /// Converts a data source specific <see cref="DataFeed"/> into its equivalent data source specific <see cref="DataFeedDetailPatch"/>.
        /// </summary>
        internal DataFeedDetailPatch GetPatchModel()
        {
            DataFeedDetailPatch patch = DataSource?.InstantiateDataFeedDetailPatch()
                ?? new DataFeedDetailPatch();

            patch.DataFeedName = Name;
            patch.Status = Status;

            if (Schema != null)
            {
                patch.TimestampColumn = Schema.TimestampColumn;
            }

            if (IngestionSettings != null)
            {
                patch.DataStartFrom = ClientCommon.NormalizeDateTimeOffset(IngestionSettings.IngestionStartsOn);
                patch.MaxConcurrency = IngestionSettings.DataSourceRequestConcurrency;
                patch.MinRetryIntervalInSeconds = (long?)IngestionSettings.IngestionRetryDelay?.TotalSeconds;
                patch.StartOffsetInSeconds = (long?)IngestionSettings.IngestionStartOffset?.TotalSeconds;
                patch.StopRetryAfterInSeconds = (long?)IngestionSettings.StopRetryAfter?.TotalSeconds;
            }

            patch.DataFeedDescription = Description;
            patch.ActionLinkTemplate = ActionLinkTemplate;
            patch.ViewMode = AccessMode;

            if (RollupSettings != null)
            {
                patch.AllUpIdentification = RollupSettings.RollupIdentificationValue;
                patch.NeedRollup = RollupSettings.RollupType;
                patch.RollUpMethod = RollupSettings.AutoRollupMethod;
                patch.RollUpColumns = RollupSettings.AutoRollupGroupByColumnNames;
            }

            if (MissingDataPointFillSettings != null)
            {
                patch.FillMissingPointType = MissingDataPointFillSettings.FillType;
                patch.FillMissingPointValue = MissingDataPointFillSettings.CustomFillValue;
            }

            patch.Admins = Administrators;
            patch.Viewers = Viewers;

            SetAuthenticationProperties(patch, DataSource);

            return patch;
        }

        private static void SetAuthenticationProperties(DataFeedDetail detail, DataFeedSource dataSource)
        {
            string authentication;

            switch (dataSource)
            {
                case AzureBlobDataFeedSource s:
                    authentication = s.Authentication?.ToString();
                    detail.AuthenticationType = (authentication == null) ? default(AuthenticationTypeEnum?) : new AuthenticationTypeEnum(authentication);
                    break;
                case AzureDataExplorerDataFeedSource s:
                    authentication = s.Authentication?.ToString();
                    detail.AuthenticationType = (authentication == null) ? default(AuthenticationTypeEnum?) : new AuthenticationTypeEnum(authentication);
                    detail.CredentialId = s.DataSourceCredentialId;
                    break;
                case AzureDataLakeStorageDataFeedSource s:
                    authentication = s.Authentication?.ToString();
                    detail.AuthenticationType = (authentication == null) ? default(AuthenticationTypeEnum?) : new AuthenticationTypeEnum(authentication);
                    detail.CredentialId = s.DataSourceCredentialId;
                    break;
                case SqlServerDataFeedSource s:
                    authentication = s.Authentication?.ToString();
                    detail.AuthenticationType = (authentication == null) ? default(AuthenticationTypeEnum?) : new AuthenticationTypeEnum(authentication);
                    detail.CredentialId = s.DataSourceCredentialId;
                    break;
            }
        }

        private static void SetAuthenticationProperties(DataFeedDetailPatch patch, DataFeedSource dataSource)
        {
            string authentication;

            switch (dataSource)
            {
                case AzureBlobDataFeedSource s:
                    authentication = s.Authentication?.ToString();
                    patch.AuthenticationType = (authentication == null) ? default(AuthenticationTypeEnum?) : new AuthenticationTypeEnum(authentication);
                    break;
                case AzureDataExplorerDataFeedSource s:
                    authentication = s.Authentication?.ToString();
                    patch.AuthenticationType = (authentication == null) ? default(AuthenticationTypeEnum?) : new AuthenticationTypeEnum(authentication);
                    patch.CredentialId = s.DataSourceCredentialId;
                    break;
                case AzureDataLakeStorageDataFeedSource s:
                    authentication = s.Authentication?.ToString();
                    patch.AuthenticationType = (authentication == null) ? default(AuthenticationTypeEnum?) : new AuthenticationTypeEnum(authentication);
                    patch.CredentialId = s.DataSourceCredentialId;
                    break;
                case SqlServerDataFeedSource s:
                    authentication = s.Authentication?.ToString();
                    patch.AuthenticationType = (authentication == null) ? default(AuthenticationTypeEnum?) : new AuthenticationTypeEnum(authentication);
                    patch.CredentialId = s.DataSourceCredentialId;
                    break;
            }
        }
    }
}
