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
        public DataFeed()
        {
            AdministratorsEmails = new ChangeTrackingList<string>();
            ViewersEmails = new ChangeTrackingList<string>();
        }

        internal DataFeed(DataFeedDetail dataFeedDetail)
        {
            Id = dataFeedDetail.DataFeedId;
            Status = dataFeedDetail.Status;
            CreatedTime = dataFeedDetail.CreatedTime;
            CreatorEmail = dataFeedDetail.Creator;
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
            AdministratorsEmails = dataFeedDetail.Admins;
            ViewersEmails = dataFeedDetail.Viewers;
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
        public string CreatorEmail { get; }

        /// <summary>
        /// Whether or not the user who queried the information about this <see cref="DataFeed"/>
        /// is one of its administrators.
        /// </summary>
        public bool? IsAdministrator { get; }

        /// <summary>
        /// The unique identifiers of the metrics defined in this feed's <see cref="DataFeedSchema"/>.
        /// Set by the service.
        /// </summary>
        public IReadOnlyDictionary<string, string> MetricIds { get; }

        /// <summary>
        /// A custom name for this <see cref="DataFeed"/> to be displayed on the web portal.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The source from which data is consumed.
        /// </summary>
        public DataFeedSource DataSource { get; set; }

        /// <summary>
        /// The type of data source that ingests this <see cref="DataFeed"/> with data.
        /// </summary>
        public DataFeedSourceType? SourceType => DataSource?.Type;

        /// <summary>
        /// Defines how this <see cref="DataFeed"/> structures the data ingested from the data source
        /// in terms of metrics and dimensions.
        /// </summary>
        public DataFeedSchema Schema { get; set; }

        /// <summary>
        /// The frequency with which ingestion from the data source will happen.
        /// </summary>
        public DataFeedGranularity Granularity { get; set; }

        /// <summary>
        /// Configures how a <see cref="DataFeed"/> behaves during data ingestion from its data source.
        /// </summary>
        public DataFeedIngestionSettings IngestionSettings { get; set; }

        /// <summary>
        /// A description of this <see cref="DataFeed"/>.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Defines actionable HTTP URLs, which consist of the placeholders %datafeed, %metric, %timestamp, %detect_config, and %tagset.
        /// You can use the template to redirect from an anomaly or an incident to a specific URL to drill down.
        /// See the <see href="https://docs.microsoft.com/azure/cognitive-services/metrics-advisor/how-tos/manage-data-feeds#action-link-template">documentation</see> for details.
        /// </summary>
        public string ActionLinkTemplate { get; set; }

        /// <summary>
        /// The access mode for this <see cref="DataFeed"/>.
        /// </summary>
        public DataFeedAccessMode? AccessMode { get; set; }

        /// <summary>
        /// Configures the behavior of this <see cref="DataFeed"/> for rolling-up the ingested data
        /// before detecting anomalies.
        /// </summary>
        public DataFeedRollupSettings RollupSettings { get; set; }

        /// <summary>
        /// Configures the behavior of this <see cref="DataFeed"/> when dealing with missing points
        /// in the data ingested from the data source.
        /// </summary>
        public DataFeedMissingDataPointFillSettings MissingDataPointFillSettings { get; set; }

        /// <summary>
        /// The emails of this data feed's administrators. Administrators have total control over a
        /// data feed, being allowed to update, delete or pause them. They also have access to the
        /// credentials used to authenticate to the data source.
        /// </summary>
        public IList<string> AdministratorsEmails { get; }

        /// <summary>
        /// The emails of this data feed's viewers. Viewers have read-only access to a data feed, and
        /// do not have access to the credentials used to authenticate to the data source.
        /// </summary>
        public IList<string> ViewersEmails { get; }

        internal DataFeedDetail GetDataFeedDetail()
        {
            DataFeedDetail detail = DataSource.InstantiateDataFeedDetail(Name, Granularity.GranularityType, Schema.MetricColumns, IngestionSettings.IngestionStartTime.Value);

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
                detail.AllUpIdentification = RollupSettings.AlreadyRollupIdentificationValue;
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

            foreach (var admin in AdministratorsEmails)
            {
                detail.Admins.Add(admin);
            }

            foreach (var viewer in ViewersEmails)
            {
                detail.Viewers.Add(viewer);
            }

            detail.AuthenticationType = GetAuthenticationType(DataSource);
            detail.CredentialId = GetCredentialId(DataSource);

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
                patch.DataStartFrom = IngestionSettings.IngestionStartTime.HasValue ? ClientCommon.NormalizeDateTimeOffset(IngestionSettings.IngestionStartTime.Value) : null;
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
                patch.AllUpIdentification = RollupSettings.AlreadyRollupIdentificationValue;
                patch.NeedRollup = RollupSettings.RollupType;
                patch.RollUpMethod = RollupSettings.AutoRollupMethod;
                patch.RollUpColumns = RollupSettings.AutoRollupGroupByColumnNames;
            }

            if (MissingDataPointFillSettings != null)
            {
                patch.FillMissingPointType = MissingDataPointFillSettings.FillType;
                patch.FillMissingPointValue = MissingDataPointFillSettings.CustomFillValue;
            }

            patch.Admins = AdministratorsEmails;
            patch.Viewers = ViewersEmails;

            patch.AuthenticationType = GetAuthenticationType(DataSource);
            patch.CredentialId = GetCredentialId(DataSource);

            return patch;
        }

        private static string GetCredentialId(DataFeedSource datasource)
        {
            if (datasource is AzureDataExplorerDataFeedSource adeSource)
            {
                return adeSource.DatasourceCredentialId;
            }
            else if (datasource is AzureDataLakeStorageGen2DataFeedSource adlsSource)
            {
                return adlsSource.DatasourceCredentialId;
            }
            else if (datasource is SqlServerDataFeedSource ssSource)
            {
                return ssSource.DatasourceCredentialId;
            }

            return null;
        }

        private static AuthenticationTypeEnum GetAuthenticationType(DataFeedSource datasource)
        {
            if (datasource is AzureBlobDataFeedSource abSource)
            {
                return abSource.Authentication switch
                {
                    AzureBlobDataFeedSource.AuthenticationType.Basic => AuthenticationTypeEnum.Basic,
                    AzureBlobDataFeedSource.AuthenticationType.ManagedIdentity => AuthenticationTypeEnum.ManagedIdentity,
                    _ => throw new InvalidOperationException($"Invalid authentication type: {abSource.Authentication}")
                };
            }
            else if (datasource is AzureDataExplorerDataFeedSource adeSource)
            {
                return adeSource.Authentication switch
                {
                    AzureDataExplorerDataFeedSource.AuthenticationType.Basic => AuthenticationTypeEnum.Basic,
                    AzureDataExplorerDataFeedSource.AuthenticationType.ManagedIdentity => AuthenticationTypeEnum.ManagedIdentity,
                    AzureDataExplorerDataFeedSource.AuthenticationType.ServicePrincipal => AuthenticationTypeEnum.ServicePrincipal,
                    AzureDataExplorerDataFeedSource.AuthenticationType.ServicePrincipalInKeyVault => AuthenticationTypeEnum.ServicePrincipalInKV,
                    _ => throw new InvalidOperationException($"Invalid authentication type: {adeSource.Authentication}")
                };
            }
            else if (datasource is AzureDataLakeStorageGen2DataFeedSource adlsSource)
            {
                return adlsSource.Authentication switch
                {
                    AzureDataLakeStorageGen2DataFeedSource.AuthenticationType.Basic => AuthenticationTypeEnum.Basic,
                    AzureDataLakeStorageGen2DataFeedSource.AuthenticationType.SharedKeyCredential => AuthenticationTypeEnum.DataLakeGen2SharedKey,
                    AzureDataLakeStorageGen2DataFeedSource.AuthenticationType.ServicePrincipal => AuthenticationTypeEnum.ServicePrincipal,
                    AzureDataLakeStorageGen2DataFeedSource.AuthenticationType.ServicePrincipalInKeyVault => AuthenticationTypeEnum.ServicePrincipalInKV,
                    _ => throw new InvalidOperationException($"Invalid authentication type: {adlsSource.Authentication}")
                };
            }
            else if (datasource is SqlServerDataFeedSource ssSource)
            {
                return ssSource.Authentication switch
                {
                    SqlServerDataFeedSource.AuthenticationType.Basic => AuthenticationTypeEnum.Basic,
                    SqlServerDataFeedSource.AuthenticationType.ManagedIdentity => AuthenticationTypeEnum.ManagedIdentity,
                    SqlServerDataFeedSource.AuthenticationType.SqlConnectionString => AuthenticationTypeEnum.AzureSQLConnectionString,
                    SqlServerDataFeedSource.AuthenticationType.ServicePrincipal => AuthenticationTypeEnum.ServicePrincipal,
                    SqlServerDataFeedSource.AuthenticationType.ServicePrincipalInKeyVault => AuthenticationTypeEnum.ServicePrincipalInKV,
                    _ => throw new InvalidOperationException($"Invalid authentication type: {ssSource.Authentication}")
                };
            }

            return AuthenticationTypeEnum.Basic;
        }
    }
}
