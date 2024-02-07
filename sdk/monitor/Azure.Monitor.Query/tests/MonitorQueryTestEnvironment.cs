// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.Monitor.Query.Tests
{
    public class MonitorQueryTestEnvironment : TestEnvironment
    {
        public string WorkspaceId => GetRecordedVariable("WORKSPACE_ID");
        public string SecondaryWorkspaceId => GetRecordedVariable("SECONDARY_WORKSPACE_ID");
        public string WorkspaceKey => GetRecordedVariable("WORKSPACE_KEY", options => options.IsSecret(SanitizedValue.Base64));
        public string SecondaryWorkspaceKey => GetRecordedVariable("SECONDARY_WORKSPACE_KEY", options => options.IsSecret(SanitizedValue.Base64));
        public string MetricsResource => GetRecordedVariable("METRICS_RESOURCE_ID");
        public string MetricsNamespace => GetRecordedVariable("METRICS_RESOURCE_NAMESPACE");
        public string MonitorIngestionEndpoint => GetOptionalVariable("METRICS_INGEST_SUFFIX") ?? "ods.opinsights.azure.com";
        public string MetricsIngestionEndpoint => GetOptionalVariable("METRICS_INGEST_SUFFIX") ?? "monitoring.azure.com";
        public Uri LogsEndpoint => new(GetRecordedVariable("LOGS_ENDPOINT"));
        public Uri MetricsEndpoint => new(ResourceManagerUrl);
        public string ResourceId => GetRecordedVariable("RESOURCE_ID");
        public string WorkspacePrimaryResourceId => GetRecordedVariable("WORKSPACE_PRIMARY_RESOURCE_ID");
        public string WorkspaceSecondaryResourceId => GetRecordedVariable("WORKSPACE_SECONDARY_RESOURCE_ID");
        public string DataplaneEndpoint => GetRecordedOptionalVariable("DATAPLANE_ENDPOINT");
        public string ConnectionString => GetRecordedOptionalVariable("CONNECTION_STRING");
        public string StorageAccountId => GetRecordedOptionalVariable("STORAGE_ID");
        public string StorageAccountConnectionString => GetRecordedOptionalVariable("STORAGE_CONNECTION_STRING");
        public string MetricsLocation => GetRecordedVariable("METRICS_LOCATION");
        public string GetLogsAudience()
        {
            Uri authorityHost = new(AuthorityHostUrl);

            if (authorityHost == AzureAuthorityHosts.AzurePublicCloud)
            {
                return LogsQueryAudience.AzurePublicCloud.ToString();
            }

            else if (authorityHost == AzureAuthorityHosts.AzureChina)
            {
                return LogsQueryAudience.AzureChina.ToString();
            }

            else if (authorityHost == AzureAuthorityHosts.AzureGovernment)
            {
                return LogsQueryAudience.AzureGovernment.ToString();
            }

            throw new NotSupportedException($"Cloud for authority host {authorityHost} is not supported.");
        }

        public string GetMetricsAudience()
        {
            Uri authorityHost = new(AuthorityHostUrl);

            if (authorityHost == AzureAuthorityHosts.AzurePublicCloud)
            {
                return MetricsQueryAudience.AzurePublicCloud.ToString();
            }

            else if (authorityHost == AzureAuthorityHosts.AzureChina)
            {
                return MetricsQueryAudience.AzureChina.ToString();
            }

            else if (authorityHost == AzureAuthorityHosts.AzureGovernment)
            {
                return MetricsQueryAudience.AzureGovernment.ToString();
            }

            throw new NotSupportedException($"Cloud for authority host {authorityHost} is not supported.");
        }
    }
}
