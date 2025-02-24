// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Monitor.OpenTelemetry.Exporter.Models;

namespace Azure.Monitor.OpenTelemetry.Exporter;

/// <summary> A telemetry item that will be sent to Application Insights. </summary>
public interface ITelemetryItem
{
    /// <summary> Type name of telemetry data item. </summary>
    string Name { get; }
    /// <summary> Key/value collection of context properties.</summary>
    IDictionary<string, string> Tags { get; }
}
