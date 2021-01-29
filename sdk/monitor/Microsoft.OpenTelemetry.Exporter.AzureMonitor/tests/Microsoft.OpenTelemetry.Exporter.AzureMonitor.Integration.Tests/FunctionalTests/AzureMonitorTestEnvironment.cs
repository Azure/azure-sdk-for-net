// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor.Integration.Tests.FunctionalTests
{
    using Azure.Core.TestFramework;

    public class AzureMonitorTestEnvironment : TestEnvironment
    {
        public AzureMonitorTestEnvironment() : base()
        {
        }

        public string ConnectionString => GetRecordedVariable(EnvironmentVariableNames.ConnectionString);

        public string InstrumentationKey => GetRecordedVariable(EnvironmentVariableNames.InstrumentationKey);

        internal static class EnvironmentVariableNames
        {
            public const string ConnectionString = "CONNECTION_STRING";
            public const string InstrumentationKey = "INSTRUMENTATION_KEY";
        }
    }
}
