// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.Monitor.Ingestion.Tests
{
    public class IngestionClientTestEnvironment : TestEnvironment
    {
        public string DCRImmutableId => GetRecordedVariable("LOGS_DCR_RULE_ID");

        public string DCREndpoint => GetRecordedVariable("DATA_COLLECTION_ENDPOINT");

        public string Ingestion_WorkspaceId => GetRecordedVariable("INGESTION_WORKSPACE_ID");

        public string StreamName => GetRecordedVariable("LOGS_DCR_STREAM_NAME");

        public string TableName => GetRecordedVariable("LOGS_TABLE_NAME");

        public ClientSecretCredential ClientSecretCredential => new ClientSecretCredential(GetRecordedVariable("AZURE_TENANT_ID"), GetRecordedVariable("AZURE_CLIENT_ID"), GetRecordedVariable("AZURE_CLIENT_SECRET"));
    }
}
