// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals;
using OpenTelemetry;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics
{
    internal sealed class LiveMetricsExtractionProcessor : BaseProcessor<Activity>
    {
        private bool _disposed;
        private LiveMetricsResource? _resource;
        private readonly Manager _manager;

        internal LiveMetricsResource? LiveMetricsResource => _resource ??= ParentProvider?.GetResource().CreateAzureMonitorResource();

        internal LiveMetricsExtractionProcessor(Manager manager)
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
                AddRequestDocument(activity);
            }
            else
            {
                AddRemoteDependencyDocument(activity);
            }

            if (activity.Events != null)
            {
                foreach (ref readonly var @event in activity.EnumerateEvents())
                {
                    string exceptionType = string.Empty;
                    string exceptionMessage = string.Empty;

                    foreach (ref readonly var tag in @event.EnumerateTagObjects())
                    {
                        // TODO: see if these can be cached
                        if (tag.Value == null)
                        {
                            continue;
                        }
                        else if (tag.Key == SemanticConventions.AttributeExceptionType)
                        {
                            exceptionType = tag.Value.ToString();
                            continue;
                        }
                        else if (tag.Key == SemanticConventions.AttributeExceptionMessage)
                        {
                            exceptionMessage = tag.Value.ToString();
                            continue;
                        }
                    }

                    AddExceptionDocument(exceptionType, exceptionMessage);
                }
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
                    catch (System.Exception)
                    {
                    }
                }

                _disposed = true;
            }

            base.Dispose(disposing);
        }

        private void AddExceptionDocument(string exceptionType, string exceptionMessage)
        {
            var exceptionDocumentIngress = DocumentHelper.CreateException(exceptionType, exceptionMessage);
            _manager._documentBuffer.WriteDocument(exceptionDocumentIngress);
        }

        private void AddRemoteDependencyDocument(Activity activity)
        {
            var remoteDependencyDocumentIngress = DocumentHelper.ConvertToRemoteDependency(activity);
            _manager._documentBuffer.WriteDocument(remoteDependencyDocumentIngress);
        }

        private void AddRequestDocument(Activity activity)
        {
            var requestDocumentIngress = DocumentHelper.ConvertToRequest(activity);
            _manager._documentBuffer.WriteDocument(requestDocumentIngress);
        }
    }
}
