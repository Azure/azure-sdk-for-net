// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal static class EnvironmentVariableConstants
    {
        /// <summary>
        /// Used to set the Connection String.
        /// </summary>
        /// <remarks>
        /// <see href="https://learn.microsoft.com/azure/azure-monitor/app/opentelemetry-configuration?#connection-string"/>.
        /// </remarks>
        public const string APPLICATIONINSIGHTS_CONNECTION_STRING = "APPLICATIONINSIGHTS_CONNECTION_STRING";

        /// <summary>
        /// Used to turn off Statsbeat.
        /// </summary>
        /// <remarks>
        /// <see href="https://learn.microsoft.com/azure/azure-monitor/app/statsbeat"/>.
        /// </remarks>
        public const string APPLICATIONINSIGHTS_STATSBEAT_DISABLED = "APPLICATIONINSIGHTS_STATSBEAT_DISABLED";

        /// <summary>
        /// Used by Statsbeat to identify if the Exporter is running within Azure Functions.
        /// </summary>
        public const string FUNCTIONS_WORKER_RUNTIME = "FUNCTIONS_WORKER_RUNTIME";

        /// <summary>
        /// Used by PersistentStorage to identify a Windows temp directory to save telemetry.
        /// </summary>
        public const string LOCALAPPDATA = "LOCALAPPDATA";

        /// <summary>
        /// Used by PersistentStorage to identify a Windows temp directory to save telemetry.
        /// </summary>
        public const string TEMP = "TEMP";

        /// <summary>
        /// Used by PersistentStorage to identify a Linux temp directory to save telemetry.
        /// </summary>
        public const string TMPDIR = "TMPDIR";

        /// <summary>
        /// Used by Statsbeat to get the App Service Host Name.
        /// </summary>
        public const string WEBSITE_HOME_STAMPNAME = "WEBSITE_HOME_STAMPNAME";

        /// <summary>
        /// Used by Statsbeat to identify Azure Functions.
        /// </summary>
        public const string WEBSITE_HOSTNAME = "WEBSITE_HOSTNAME";

        /// <summary>
        /// Used by Statsbeat to get the App Service Website Name.
        /// </summary>
        public const string WEBSITE_SITE_NAME = "WEBSITE_SITE_NAME";
    }
}
