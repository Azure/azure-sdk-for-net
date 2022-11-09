// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.Exporter.E2E.Tests.TestFramework
{
    using System;

    using Azure.Core.TestFramework;

    public class MonitorExporterTestEnvironment : TestEnvironment
    {
        /// <summary>
        /// Connection String is used to connect to an Application Insights resource.
        /// This value comes from the ARM Template.
        /// </summary>
        public string ConnectionString => GetRecordedVariable("CONNECTION_STRING");

        public Uri LogsEndpoint => new(GetRecordedVariable("LOGS_ENDPOINT"));

        public string WorkspaceId => GetRecordedVariable("WORKSPACE_ID");
    }
}
