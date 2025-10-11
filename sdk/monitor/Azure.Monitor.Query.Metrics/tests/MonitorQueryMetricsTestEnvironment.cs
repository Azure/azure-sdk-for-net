// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.Monitor.Query.Metrics.Tests
{
    public class MonitorQueryMetricsTestEnvironment : TestEnvironment
    {
        public string WorkspaceId => GetRecordedVariable("WORKSPACE_ID");
        public string SecondaryWorkspaceId => GetRecordedVariable("SECONDARY_WORKSPACE_ID");
        public string WorkspaceKey => GetRecordedVariable("WORKSPACE_KEY", options => options.IsSecret(SanitizedValue.Base64));
        public string SecondaryWorkspaceKey => GetRecordedVariable("SECONDARY_WORKSPACE_KEY", options => options.IsSecret(SanitizedValue.Base64));
        public string MetricsResource => GetRecordedVariable("METRICS_RESOURCE_ID");
        public string MetricsNamespace => GetRecordedVariable("METRICS_RESOURCE_NAMESPACE");
        public string MonitorIngestionEndpoint => GetOptionalVariable("METRICS_INGEST_SUFFIX") ?? "ods.opinsights.azure.com";
        public Uri LogsEndpoint => new(GetRecordedVariable("LOGS_ENDPOINT"));
        public string ResourceId => GetRecordedVariable("RESOURCE_ID");
        public string WorkspacePrimaryResourceId => GetRecordedVariable("WORKSPACE_PRIMARY_RESOURCE_ID");
        public string WorkspaceSecondaryResourceId => GetRecordedVariable("WORKSPACE_SECONDARY_RESOURCE_ID");
        public string DataplaneEndpoint => GetRecordedOptionalVariable("DATAPLANE_ENDPOINT");
        public string ConnectionString => GetRecordedOptionalVariable("CONNECTION_STRING");
        public string StorageAccountId => GetRecordedOptionalVariable("STORAGE_ID");
        public string StorageAccountConnectionString => GetRecordedOptionalVariable("STORAGE_CONNECTION_STRING");
        public string GetMetricsAudience()
        {
            Uri authorityHost = new(AuthorityHostUrl);

            if (authorityHost == AzureAuthorityHosts.AzurePublicCloud)
            {
                return MetricsClientAudience.AzurePublicCloud.ToString();
            }

            else if (authorityHost == AzureAuthorityHosts.AzureChina)
            {
                return MetricsClientAudience.AzureChina.ToString();
            }

            else if (authorityHost == AzureAuthorityHosts.AzureGovernment)
            {
                return MetricsClientAudience.AzureGovernment.ToString();
            }

            throw new NotSupportedException($"Cloud for authority host {authorityHost} is not supported.");
        }

        public string GetMetricsClientAudience()
        {
            Uri authorityHost = new(AuthorityHostUrl);

            if (authorityHost == AzureAuthorityHosts.AzurePublicCloud)
            {
                return MetricsClientAudience.AzurePublicCloud.ToString();
            }

            if (authorityHost == AzureAuthorityHosts.AzureChina)
            {
                return MetricsClientAudience.AzureChina.ToString();
            }

            if (authorityHost == AzureAuthorityHosts.AzureGovernment)
            {
                return MetricsClientAudience.AzureGovernment.ToString();
            }

            throw new NotSupportedException($"Cloud for authority host {authorityHost} is not supported.");
        }

        public string ConstructMetricsClientUri()
        {
            string uri = "https://" + Location + ".metrics.monitor.azure.";
            var audience = GetMetricsClientAudience();

            // Depending on which cloud, append the correct regional suffix
            if (audience == MetricsClientAudience.AzureChina.ToString())
            {
                uri += "cn";
            }
            else if (audience == MetricsClientAudience.AzureGovernment.ToString())
            {
                uri += "us";
            }
            else
            {
                uri += "com";
            }

            return uri;
        }
    }
}
