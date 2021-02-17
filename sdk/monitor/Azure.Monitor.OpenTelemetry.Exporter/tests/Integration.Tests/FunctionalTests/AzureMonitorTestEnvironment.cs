// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.Exporter.Integration.Tests.FunctionalTests
{
    using global::Azure.Core.TestFramework;

    public class AzureMonitorTestEnvironment : TestEnvironment
    {
        public AzureMonitorTestEnvironment() : base()
        {
        }

        /// <summary>
        /// Connection String is used to connect to an Application Insights resource.
        /// This value comes from the ARM Template.
        /// </summary>
        public string ConnectionString => GetRecordedVariable(EnvironmentVariableNames.ConnectionString);

        /// <summary>
        /// Instrumentation Key are unique per Application Insights resource.
        /// IKey's are added to telemetry items and is checked in validation.
        /// This value comes from the ARM Template.
        /// </summary>
        public string InstrumentationKey => GetRecordedVariable(EnvironmentVariableNames.InstrumentationKey);

        /// <summary>
        /// Application ID is used to identify an Application Insights resource when querying telemetry from the REST API.
        /// This value comes from the ARM Template.
        /// </summary>
        public string ApplicationId => GetRecordedVariable(EnvironmentVariableNames.ApplicationId);

        internal static class EnvironmentVariableNames
        {
            public const string ConnectionString = "CONNECTION_STRING";
            public const string InstrumentationKey = "INSTRUMENTATION_KEY";
            public const string ApplicationId = "APPLICATION_ID";
        }
    }
}
