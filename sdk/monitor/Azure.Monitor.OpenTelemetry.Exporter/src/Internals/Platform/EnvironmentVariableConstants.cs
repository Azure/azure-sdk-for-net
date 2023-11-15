// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform
{
    internal static class EnvironmentVariableConstants
    {
        /// <summary>
        /// Available for users to set their Connection String.
        /// </summary>
        /// <remarks>
        /// <see href="https://learn.microsoft.com/azure/azure-monitor/app/opentelemetry-configuration?#connection-string"/>.
        /// </remarks>
        public const string APPLICATIONINSIGHTS_CONNECTION_STRING = "APPLICATIONINSIGHTS_CONNECTION_STRING";

        /// <summary>
        /// Available for users to opt-out of Statsbeat.
        /// </summary>
        /// <remarks>
        /// <see href="https://learn.microsoft.com/azure/azure-monitor/app/statsbeat"/>.
        /// </remarks>
        public const string APPLICATIONINSIGHTS_STATSBEAT_DISABLED = "APPLICATIONINSIGHTS_STATSBEAT_DISABLED";

        /// <summary>
        /// INTERNAL ONLY. Used by Statsbeat to identify if the Exporter is running within Azure Functions.
        /// </summary>
        public const string FUNCTIONS_WORKER_RUNTIME = "FUNCTIONS_WORKER_RUNTIME";

        /// <summary>
        /// INTERNAL ONLY. Used by PersistentStorage to identify a Windows temp directory to save telemetry.
        /// </summary>
        public const string LOCALAPPDATA = "LOCALAPPDATA";

        /// <summary>
        /// INTERNAL ONLY. Used by PersistentStorage to identify a Windows temp directory to save telemetry.
        /// </summary>
        public const string TEMP = "TEMP";

        /// <summary>
        /// INTERNAL ONLY. Used by PersistentStorage to identify a Linux temp directory to save telemetry.
        /// </summary>
        public const string TMPDIR = "TMPDIR";

        /// <summary>
        /// INTERNAL ONLY. Used by Statsbeat to get the App Service Host Name.
        /// </summary>
        public const string WEBSITE_HOME_STAMPNAME = "WEBSITE_HOME_STAMPNAME";

        /// <summary>
        /// INTERNAL ONLY. Used by Statsbeat to identify Azure Functions.
        /// </summary>
        public const string WEBSITE_HOSTNAME = "WEBSITE_HOSTNAME";

        /// <summary>
        /// INTERNAL ONLY. Used by Statsbeat to get the App Service Website Name.
        /// </summary>
        public const string WEBSITE_SITE_NAME = "WEBSITE_SITE_NAME";

        /// <summary>
        /// INTERNAL ONLY. Used by Statsbeat to get the AKS ARM Namespace ID for AKS auto-instrumentation.
        /// </summary>
        public const string AKS_ARM_NAMESPACE_ID = "AKS_ARM_NAMESPACE_ID";

        /// <summary>
        /// When set to true, exporter will emit resources as metric telemetry.
        /// </summary>
        public const string EXPORT_RESOURCE_METRIC = "OTEL_DOTNET_AZURE_MONITOR_ENABLE_RESOURCE_METRICS";
    }
}
