// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Monitor.OpenTelemetry.AspNetCore.Internals.LiveMetrics;
using Azure.Monitor.OpenTelemetry.AspNetCore.LiveMetrics.DataCollection;
using OpenTelemetry;
using OpenTelemetry.Logs;

namespace Azure.Monitor.OpenTelemetry.AspNetCore.LiveMetrics
{
    internal class LiveMetricsLogProcessor : BaseProcessor<LogRecord>
    {
        private bool _disposed;
        private readonly Manager _manager;

        public LiveMetricsLogProcessor(Manager manager)
        {
            _manager = manager;

            // Resource is not available at sdk initialization and must be read later.
            manager.LiveMetricsResourceFunc ??= () => ParentProvider?.GetResource().CreateAzureMonitorResource();
        }

        public override void OnEnd(LogRecord data)
        {
            // Check if live metrics is enabled.
            if (!_manager.ShouldCollect())
            {
                return;
            }

            if (data.Exception is null)
            {
                _manager._documentBuffer.AddLogDocument(data);
            }
            else
            {
                _manager._documentBuffer.AddExceptionDocument(data);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    try
                    {
                        _manager.Dispose();
                    }
                    catch (Exception)
                    {
                    }
                }

                _disposed = true;
            }

            base.Dispose(disposing);
        }
    }
}
