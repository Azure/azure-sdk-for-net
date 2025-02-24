// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals;

/// <summary>
/// Enables a callback to be invoked before telemetry is sent to the backend.
/// </summary>
internal static class PostProcessTelemetryHelper
{
    /// <summary>
    /// Invokes the <paramref name="postProcess"/> callback
    /// </summary>
    internal static void InvokePostProcess(ITelemetryItem item, Action<ITelemetryItem>? postProcess)
    {
        if (postProcess == null)
        {
            return;
        }

        try
        {
            postProcess(item);

            // Clear any tags that exceed the maximum length after the callback has been invoked.
            var tags =
                from kvp in item.Tags
                where kvp.Key.Length > SchemaConstants.KVP_MaxKeyLength
                      || kvp.Value.Length > SchemaConstants.KVP_MaxValueLength
                select kvp;
            foreach (var kvp in tags.ToList())
            {
                item.Tags.Remove(kvp.Key);
            }
        }
        catch (Exception ex)
        {
            AzureMonitorExporterEventSource.Log.ErrorInvokingBeforeTelemetrySent(ex);
        }
    }
}
