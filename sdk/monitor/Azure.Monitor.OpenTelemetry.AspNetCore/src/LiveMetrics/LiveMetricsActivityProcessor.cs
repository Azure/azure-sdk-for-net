// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Monitor.OpenTelemetry.AspNetCore.Internals.LiveMetrics;
using Azure.Monitor.OpenTelemetry.AspNetCore.LiveMetrics.DataCollection;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using OpenTelemetry;

namespace Azure.Monitor.OpenTelemetry.AspNetCore.LiveMetrics
{
    internal sealed class LiveMetricsActivityProcessor : BaseProcessor<Activity>
    {
        private LiveMetricsResource? _resource;
        private readonly Manager _manager;

        internal LiveMetricsResource? LiveMetricsResource => _resource ??= ParentProvider?.GetResource().CreateAzureMonitorResource();

        internal LiveMetricsActivityProcessor(Manager manager)
        {
            _manager = manager;
        }

        public override void OnEnd(Activity activity)
        {
            // Check if live metrics is enabled.
            if (!_manager.ShouldCollect())
            {
                return;
            }

            // Resource is not available at initialization and must be set later.
            if (_manager.LiveMetricsResource == null && LiveMetricsResource != null)
            {
                _manager.LiveMetricsResource = LiveMetricsResource;
            }

            if (activity.Kind == ActivityKind.Server || activity.Kind == ActivityKind.Consumer)
            {
                _manager._documentBuffer.AddRequestDocument(activity);
            }
            else
            {
                _manager._documentBuffer.AddDependencyDocument(activity);
            }

            if (activity.Events != null)
            {
                foreach (ref readonly var @event in activity.EnumerateEvents())
                {
                    if (@event.Name == SemanticConventions.AttributeExceptionEventName)
                    {
                        _manager._documentBuffer.AddExceptionDocument(@event);
                    }
                    else
                    {
                        _manager._documentBuffer.AddLogDocument(@event);
                    }
                }
            }
        }
    }
}
