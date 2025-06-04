// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using OpenTelemetry;
using System.Diagnostics;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.DataCollection;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics
{
    internal sealed class LiveMetricsActivityProcessor : BaseProcessor<Activity>
    {
        private readonly LiveMetricsClientManager _manager;

        internal LiveMetricsActivityProcessor(LiveMetricsClientManager manager)
        {
            _manager = manager;

            // Resource is not available at sdk initialization and must be read later.
            manager.LiveMetricsResourceFunc ??= () => ParentProvider?.GetResource().CreateAzureMonitorResource();
        }

        public override void OnEnd(Activity activity)
        {
            // Check if live metrics is enabled.
            if (!_manager.ShouldCollect())
            {
                return;
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
