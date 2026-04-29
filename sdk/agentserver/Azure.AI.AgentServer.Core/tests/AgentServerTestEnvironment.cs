// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.AI.AgentServer.Core.Tests
{
    /// <summary>
    /// Test environment for AgentServer live tests.
    /// Reads outputs from test-resources.bicep deployment.
    /// </summary>
    public class AgentServerTestEnvironment : TestEnvironment
    {
        /// <summary>
        /// Application Insights connection string for exporting traces.
        /// </summary>
        public string ApplicationInsightsConnectionString =>
            GetRecordedVariable("APPLICATIONINSIGHTS_CONNECTION_STRING");

        /// <summary>
        /// Log Analytics workspace customer ID for querying traces.
        /// </summary>
        public string WorkspaceId => GetRecordedVariable("WORKSPACE_ID");

        /// <summary>
        /// Log Analytics query endpoint.
        /// </summary>
        public Uri LogsEndpoint => new(GetRecordedVariable("LOGS_ENDPOINT"));
    }
}
