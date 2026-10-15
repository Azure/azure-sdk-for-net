// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.MultiEndpoint
{
    internal static class MultiEndpointConfig
    {
        internal const string EnableMultiEndpointRoutingSwitchName = "Azure.Monitor.OpenTelemetry.EnableMultiEndpointRouting";

        /// <summary>
        /// Entra ID audience for "aad" routes (for example <c>https://monitor.azure.cn/</c>), set with
        /// <c>AppContext.SetData</c>. Defaults to the public cloud.
        /// </summary>
        internal const string AadAudienceName = "Azure.Monitor.OpenTelemetry.Exporter.MultiEndpointAadAudience";

        /// <remarks>
        /// The <see cref="AppContext"/> switch is read once, when this type is first touched, so it
        /// must be set before the first exporter is constructed.
        /// </remarks>
        internal static readonly bool Enabled = AppContext.TryGetSwitch(EnableMultiEndpointRoutingSwitchName, out var enabled) && enabled;

        internal static string GetAadScope()
        {
            var configured = AppContext.GetData(AadAudienceName);
            string? audience = null;

            switch (configured)
            {
                case null:
                    break;

                case string text when string.IsNullOrWhiteSpace(text):
                    break;

                case string text:
                    audience = text.Trim();
                    break;

                default:
                    AzureMonitorExporterEventSource.Log.MultiEndpointAadAudienceIgnored(AadAudienceName, configured.GetType().Name);
                    break;
            }

            return AadHelper.GetScope(audience);
        }
    }
}
