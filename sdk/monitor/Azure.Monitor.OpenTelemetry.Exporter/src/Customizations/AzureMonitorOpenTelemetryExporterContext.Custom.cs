// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ComponentModel;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    /// <summary>
    /// Context class which will be filled in by the System.ClientModel.SourceGeneration.
    /// For more information see 'https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/src/docs/ModelReaderWriterContext.md'
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class AzureMonitorOpenTelemetryExporterContext : ModelReaderWriterContext
    {
        private AzureMonitorOpenTelemetryExporterContext? _azureMonitorOpenTelemetryExporterContext;

        /// <summary> Gets the default instance </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AzureMonitorOpenTelemetryExporterContext Default => _azureMonitorOpenTelemetryExporterContext ??= new();
    }
}
