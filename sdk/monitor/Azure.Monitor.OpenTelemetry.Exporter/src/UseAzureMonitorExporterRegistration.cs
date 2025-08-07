// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.Exporter;

// Note: This class is added to the IServiceCollection when UseAzureMonitorExporter is
// called. Its purpose is to detect registrations so that subsequent calls and
// calls to signal-specific UseAzureMonitorExporter can throw.
internal sealed class UseAzureMonitorExporterRegistration
{
    public static readonly UseAzureMonitorExporterRegistration Instance = new();

    private UseAzureMonitorExporterRegistration()
    {
        // Note: Some dependency injection containers (ex: Unity, Grace) will
        // automatically create services if they have a public constructor even
        // if the service was never registered into the IServiceCollection. The
        // behavior of UseAzureMonitorExporterRegistration requires that it should only
        // exist if registered. This private constructor is intended to prevent
        // automatic instantiation.
    }
}
