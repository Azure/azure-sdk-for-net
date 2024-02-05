// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics;

/// <summary>
/// Options that allow users to configure the Live Metrics.
/// </summary>
public class LiveMetricsExporterOptions : ClientOptions
{
    /// <summary>
    /// The Connection String provides users with a single configuration setting to identify the Azure Monitor resource and endpoint.
    /// </summary>
    /// <remarks>
    /// <see href="https://docs.microsoft.com/azure/azure-monitor/app/sdk-connection-string"/>.
    /// </remarks>
    public string ConnectionString { get; set; }

    /// <summary>
    /// Enables or disables the Live Metrics feature.
    /// </summary>
    public bool EnableLiveMetrics { get; set; } = true;

    /// <summary>
    /// Get or sets the value of <see cref="TokenCredential" />.
    /// </summary>
    public TokenCredential Credential { get; set; }
}
