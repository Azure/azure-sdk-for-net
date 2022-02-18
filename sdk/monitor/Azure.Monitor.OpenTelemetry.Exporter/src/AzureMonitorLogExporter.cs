// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;

using Azure.Core.Pipeline;

using OpenTelemetry;
using OpenTelemetry.Logs;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    internal class AzureMonitorLogExporter : BaseExporter<LogRecord>
    {
        private readonly ITransmitter _transmitter;
        private readonly AzureMonitorExporterOptions _options;
        private readonly string _instrumentationKey;
        private readonly ResourceParser _resourceParser;

        public AzureMonitorLogExporter(AzureMonitorExporterOptions options) : this(options, new AzureMonitorTransmitter(options))
        {
        }

        internal AzureMonitorLogExporter(AzureMonitorExporterOptions options, ITransmitter transmitter)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            ConnectionString.ConnectionStringParser.GetValues(_options.ConnectionString, out _instrumentationKey, out _);
            _transmitter = transmitter;
            _resourceParser = new ResourceParser();
        }

        /// <inheritdoc/>
        public override ExportResult Export(in Batch<LogRecord> batch)
        {
            // Prevent Azure Monitor's HTTP operations from being instrumented.
            using var scope = SuppressInstrumentationScope.Begin();

            try
            {
                var resource = ParentProvider.GetResource();
                _resourceParser.UpdateRoleNameAndInstance(resource);
                var telemetryItems = LogsHelper.OtelToAzureMonitorLogs(batch, _resourceParser.RoleName, _resourceParser.RoleInstance, _instrumentationKey);

                // TODO: Handle return value, it can be converted as metrics.
                // TODO: Validate CancellationToken and async pattern here.
                _transmitter.TrackAsync(telemetryItems, false, CancellationToken.None).EnsureCompleted();
                return ExportResult.Success;
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.Write($"FailedToExport{EventLevelSuffix.Error}", ex.LogAsyncException());
                return ExportResult.Failure;
            }
        }
    }
}
