// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

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
        public string StorageAccountName => GetRecordedVariable("STORAGE_ACCOUNT_NAME");
        public string StorageAccountId => GetRecordedVariable("STORAGE_ID");

        protected override async ValueTask<bool> IsEnvironmentReadyAsync()
        {
            var client = new LogsQueryClient(Credential);
            DateTimeOffset RetentionWindowStart = DateTimeOffset.Now;
            var result = await client.QueryResourceAsync(new ResourceIdentifier(StorageAccountId), "search *", new QueryTimeRange(RetentionWindowStart, TimeSpan.FromDays(15))).ConfigureAwait(false);

            // make sure StorageAccount set-up is complete before beginning testing
            if (result.Value.Table.Rows.Count == 0 || result.Value.Table.Columns.Count == 0)
                return false;

            return true;
        }
    }
}
