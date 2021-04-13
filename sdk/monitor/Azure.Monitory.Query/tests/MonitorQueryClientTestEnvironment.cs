// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.Template.Tests
{
    public class MonitorQueryClientTestEnvironment : TestEnvironment
    {
        public string WorkspaceId => GetRecordedVariable("WORKSPACE_ID");
        public string WorkspaceKey => GetRecordedVariable("WORKSPACE_KEY", options => options.IsSecret(SanitizedValue.Base64));
        public string MetricsResource => GetRecordedVariable("METRICS_RESOURCE_ID");
        public string MetricsNamespace => GetRecordedVariable("METRICS_RESOURCE_NAMESPACE");
        public string MonitorIngestionEndpoint => GetOptionalVariable("METRICS_INGEST_SUFFIX") ?? "ods.opinsights.azure.com";
    }
}
