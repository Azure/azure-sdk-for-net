// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.Monitor.Ingestion.Tests
{
    public class MonitorIngestionTestEnvironment : TestEnvironment
    {
        public string DCRImmutableId => GetRecordedVariable("INGESTION_DATA_COLLECTION_RULE_IMMUTABLE_ID");

        public string DCREndpoint => GetRecordedVariable("INGESTION_DATA_COLLECTION_ENDPOINT");

        public string Ingestion_WorkspaceId => GetRecordedVariable("WORKSPACE_ID");

        public string StreamName => GetRecordedVariable("INGESTION_STREAM_NAME");

        public string TableName => GetRecordedVariable("INGESTION_TABLE_NAME");

        public LogsIngestionAudience GetAudience()
        {
            Uri authorityHost = new(AuthorityHostUrl);

            if (authorityHost == AzureAuthorityHosts.AzurePublicCloud)
            {
                return LogsIngestionAudience.AzurePublicCloud;
            }

            if (authorityHost == AzureAuthorityHosts.AzureChina)
            {
                return LogsIngestionAudience.AzureChina;
            }

            if (authorityHost == AzureAuthorityHosts.AzureGovernment)
            {
                return LogsIngestionAudience.AzureGovernment;
            }

            throw new NotSupportedException($"Cloud for authority host {authorityHost} is not supported.");
        }
    }
}
