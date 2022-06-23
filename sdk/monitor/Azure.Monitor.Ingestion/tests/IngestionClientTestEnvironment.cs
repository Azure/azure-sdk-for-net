// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.Monitor.Ingestion.Tests
{
    public class IngestionClientTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("Ingestion_ENDPOINT");

        public string DCRImmutableId => GetRecordedVariable("DCRImmutableId");

        public string DCREndpoint => GetRecordedVariable("DCREndpoint");

        public string Ingestion_WorkspaceId => GetRecordedVariable("Ingestion_WorkspaceId");

        public string StreamName => GetRecordedVariable("StreamName");

        public string TableName => GetRecordedVariable("TableName");

        public ClientSecretCredential ClientSecretCredential => new ClientSecretCredential(TenantId, ClientId, ClientSecret);
    }
}
