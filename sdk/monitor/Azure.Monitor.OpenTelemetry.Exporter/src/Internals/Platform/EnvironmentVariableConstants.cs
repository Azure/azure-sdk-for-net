﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        /// INTERNAL ONLY.
        /// Used by Statsbeat to get the App Service Website Name.
        /// Used by LiveMetrics to detect if an application is running in Azure App Service.
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

        /// <summary>
        /// By default, OpenTelemetry.Instrumenation.AspNetCore v1.8.1 will redact query strings values from URLs.
        /// This environment variable can be set to true to disable this behavior.
        /// </summary>
        /// <remarks>
        /// <see href="https://github.com/open-telemetry/opentelemetry-dotnet/blob/main/src/OpenTelemetry.Instrumentation.AspNetCore/CHANGELOG.md#181"/>.
        /// </remarks>
        public const string ASPNETCORE_DISABLE_URL_QUERY_REDACTION = "OTEL_DOTNET_EXPERIMENTAL_ASPNETCORE_DISABLE_URL_QUERY_REDACTION";

        /// <summary>
        /// By default, OpenTelemetry.Instrumenation.Http v1.8.1 will redact query string values from URLs.
        /// This environment variable can be set to true to disable this behavior.
        /// </summary>
        /// <remarks>
        /// <see href="https://github.com/open-telemetry/opentelemetry-dotnet/blob/main/src/OpenTelemetry.Instrumentation.Http/CHANGELOG.md#181"/>.
        /// </remarks>
        public const string HTTPCLIENT_DISABLE_URL_QUERY_REDACTION = "OTEL_DOTNET_EXPERIMENTAL_HTTPCLIENT_DISABLE_URL_QUERY_REDACTION";
    }
}
