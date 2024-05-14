// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Models;
using OpenTelemetry;

using ExceptionDocument = Azure.Monitor.OpenTelemetry.LiveMetrics.Models.Exception;

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

            string? statusCodeAttributeValue = null;

            foreach (ref readonly var tag in activity.EnumerateTagObjects())
            {
                if (tag.Key == SemanticConventions.AttributeHttpResponseStatusCode)
                {
                    statusCodeAttributeValue = tag.Value?.ToString();
                    break;
                }
            }

            if (activity.Kind == ActivityKind.Server || activity.Kind == ActivityKind.Consumer)
            {
                AddRequestDocument(activity, statusCodeAttributeValue);
            }
            else
            {
                AddRemoteDependencyDocument(activity, statusCodeAttributeValue);
            }

            if (activity.Events != null)
            {
                foreach (ref readonly var @event in activity.EnumerateEvents())
                {
                    string? exceptionType = null;
                    string? exceptionMessage = null;

                    foreach (ref readonly var tag in @event.EnumerateTagObjects())
                    {
                        // TODO: see if these can be cached
                        if (tag.Key == SemanticConventions.AttributeExceptionType)
                        {
                            exceptionType = tag.Value?.ToString();
                            continue;
                        }
                        if (tag.Key == SemanticConventions.AttributeExceptionMessage)
                        {
                            exceptionMessage = tag.Value?.ToString();
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
                    }
                    catch (System.Exception)
                    {
                    }
                }

                _disposed = true;
            }

            base.Dispose(disposing);
        }

        private void AddExceptionDocument(string? exceptionType, string? exceptionMessage)
        {
            ExceptionDocument exceptionDocumentIngress = new()
            {
                ExceptionType = exceptionType,
                ExceptionMessage = exceptionMessage,
                DocumentType = DocumentIngressDocumentType.Exception,
                // TODO: DocumentStreamIds = new List<string>(),
                // TODO: Properties = new Dictionary<string, string>(), - Validate with UX team if this is needed.
            };

            _manager._documentBuffer.WriteDocument(exceptionDocumentIngress);
        }

        private void AddRemoteDependencyDocument(Activity activity, string? statusCodeAttributeValue)
        {
            RemoteDependency remoteDependencyDocumentIngress = new()
            {
                Name = activity.DisplayName,
                // TODO: Implementation needs to be copied from Exporter.
                // TODO: Value of dependencyTelemetry.Data
                CommandName = "",
                // TODO: Value of dependencyTelemetry.ResultCode
                ResultCode = "",
                Duration = activity.Duration < SchemaConstants.RequestData_Duration_LessThanDays
                                                ? activity.Duration.ToString("c", CultureInfo.InvariantCulture)
                                                : SchemaConstants.Duration_MaxValue,
                DocumentType = DocumentIngressDocumentType.RemoteDependency,
                // TODO: DocumentStreamIds = new List<string>(),
                // TODO: Properties = new Dictionary<string, string>(), - Validate with UX team if this is needed.

                Extension_IsSuccess = IsSuccess(activity, statusCodeAttributeValue),
                Extension_Duration = activity.Duration.TotalMilliseconds,
            };

            _manager._documentBuffer.WriteDocument(remoteDependencyDocumentIngress);
        }

        private void AddRequestDocument(Activity activity, string? statusCodeAttributeValue)
        {
            Request requestDocumentIngress = new()
            {
                Name = activity.DisplayName,
                // TODO: Implementation needs to be copied from Exporter.
                // Value of requestTelemetry.ResultCode
                Url = "",
                ResponseCode = statusCodeAttributeValue,
                Duration = activity.Duration < SchemaConstants.RequestData_Duration_LessThanDays
                                                ? activity.Duration.ToString("c", CultureInfo.InvariantCulture)
                                                : SchemaConstants.Duration_MaxValue,
                DocumentType = DocumentIngressDocumentType.Request,
                // TODO: DocumentStreamIds = new List<string>(),
                // TODO: Properties = new Dictionary<string, string>(), - Validate with UX team if this is needed.

                Extension_IsSuccess = IsSuccess(activity, statusCodeAttributeValue),
                Extension_Duration = activity.Duration.TotalMilliseconds,
            };

            _manager._documentBuffer.WriteDocument(requestDocumentIngress);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsSuccess(Activity activity, string? responseCode)
        {
            if (responseCode != null && int.TryParse(responseCode, out int statusCode))
            {
                bool isSuccessStatusCode = statusCode != 0 && statusCode < 400;
                return activity.Status != ActivityStatusCode.Error && isSuccessStatusCode;
            }
            else
            {
                return activity.Status != ActivityStatusCode.Error;
            }
        }
    }
}
