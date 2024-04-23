// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using Azure.Monitor.OpenTelemetry.AspNetCore.Models;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using OpenTelemetry.Logs;
using ExceptionDocument = Azure.Monitor.OpenTelemetry.AspNetCore.Models.Exception;

namespace Azure.Monitor.OpenTelemetry.AspNetCore.LiveMetrics.DataCollection
{
    /// <summary>
    /// Helper class used to convert Activity to the LiveMetrics document schema.
    /// </summary>
    internal static class DocumentHelper
    {
        private const int MaxProperties = 10;

        // TODO: NEED TO HANDLE UNIQUE MAXLENGTH VALUES FOR DOCUMENT TYPES. SEE SWAGGER FOR MAXLENGTH VALUES.

        #region Document Buffer Extension Methods
        public static void AddExceptionDocument(this DoubleBuffer buffer, ActivityEvent activityEvent)
        {
            try
            {
                var exceptionDocument = ConvertToExceptionDocument(activityEvent);
                buffer.WriteDocument(exceptionDocument);
            }
            catch (System.Exception ex)
            {
                AzureMonitorAspNetCoreEventSource.Log.FailedToCreateTelemetryDocument("ExceptionDocument", ex);
            }
        }

        public static void AddExceptionDocument(this DoubleBuffer buffer, LogRecord logRecord, System.Exception exception)
        {
            try
            {
                var exceptionDocument = ConvertToExceptionDocument(logRecord, exception);
                buffer.WriteDocument(exceptionDocument);
            }
            catch (System.Exception ex)
            {
                AzureMonitorAspNetCoreEventSource.Log.FailedToCreateTelemetryDocument("ExceptionDocument", ex);
            }
        }

        public static void AddLogDocument(this DoubleBuffer buffer, ActivityEvent activityEvent)
        {
            try
            {
                var logDocument = ConvertToLogDocument(activityEvent);
                buffer.WriteDocument(logDocument);
            }
            catch (System.Exception ex)
            {
                AzureMonitorAspNetCoreEventSource.Log.FailedToCreateTelemetryDocument("LogDocument", ex);
            }
        }

        public static void AddLogDocument(this DoubleBuffer buffer, LogRecord logRecord)
        {
            try
            {
                var logDocument = ConvertToLogDocument(logRecord);
                buffer.WriteDocument(logDocument);
            }
            catch (System.Exception ex)
            {
                AzureMonitorAspNetCoreEventSource.Log.FailedToCreateTelemetryDocument("LogDocument", ex);
            }
        }

        public static void AddDependencyDocument(this DoubleBuffer buffer, Activity activity)
        {
            try
            {
                var dependencyDocument = ConvertToDependencyDocument(activity);
                buffer.WriteDocument(dependencyDocument);
            }
            catch (System.Exception ex)
            {
                AzureMonitorAspNetCoreEventSource.Log.FailedToCreateTelemetryDocument("DependencyDocument", ex);
            }
        }

        public static void AddRequestDocument(this DoubleBuffer buffer, Activity activity)
        {
            try
            {
                var requestDocument = ConvertToRequestDocument(activity);
                buffer.WriteDocument(requestDocument);
            }
            catch (System.Exception ex)
            {
                AzureMonitorAspNetCoreEventSource.Log.FailedToCreateTelemetryDocument("RequestDocument", ex);
            }
        }
        #endregion

        internal static RemoteDependency ConvertToDependencyDocument(Activity activity)
        {
            // TODO: Investigate if we can have a minimal/optimized version of ActivityTagsProcessor for LiveMetric.
            var atp = new ActivityTagsProcessor();
            atp.CategorizeTags(activity);

            RemoteDependency remoteDependencyDocumentIngress = new()
            {
                DocumentType = DocumentType.RemoteDependency,

                // The following "EXTENSION" properties are used to calculate metrics. These are not serialized.
                Extension_Duration = activity.Duration.TotalMilliseconds,
            };

            SetProperties(remoteDependencyDocumentIngress, atp);

            // HACK: Remove the V2 for now. This Enum should be removed in the future.
            if (atp.activityType.HasFlag(OperationType.V2))
            {
                atp.activityType &= ~OperationType.V2;
            }

            switch (atp.activityType)
            {
                case OperationType.Http:
                    remoteDependencyDocumentIngress.Name = activity.DisplayName;
                    remoteDependencyDocumentIngress.CommandName = AzMonList.GetTagValue(ref atp.MappedTags, SemanticConventions.AttributeUrlFull)?.ToString();
                    var httpResponseStatusCode = AzMonList.GetTagValue(ref atp.MappedTags, SemanticConventions.AttributeHttpResponseStatusCode)?.ToString();
                    remoteDependencyDocumentIngress.ResultCode = httpResponseStatusCode;
                    remoteDependencyDocumentIngress.Duration = activity.Duration < SchemaConstants.RequestData_Duration_LessThanDays
                                                ? activity.Duration.ToString("c", CultureInfo.InvariantCulture)
                                                                : SchemaConstants.Duration_MaxValue;

                    // The following "EXTENSION" properties are used to calculate metrics. These are not serialized.
                    remoteDependencyDocumentIngress.Extension_IsSuccess = IsHttpSuccess(activity, httpResponseStatusCode);
                    break;
                case OperationType.Db:
                    // Note: The Exception details are recorded in Activity.Events only if the configuration has opt-ed into this (SqlClientInstrumentationOptions.RecordException).

                    var (_, dbTarget) = atp.MappedTags.GetDbDependencyTargetAndName();

                    remoteDependencyDocumentIngress.Name = dbTarget;
                    remoteDependencyDocumentIngress.CommandName = AzMonList.GetTagValue(ref atp.MappedTags, SemanticConventions.AttributeDbStatement)?.ToString();
                    remoteDependencyDocumentIngress.Duration = activity.Duration.ToString("c", CultureInfo.InvariantCulture);

                    // TODO: remoteDependencyDocumentIngress.ResultCode = "";
                    // AI SDK reads a Number property from Connection or Command objects.
                    // As of Feb 2024, OpenTelemetry doesn't record this. This may change in the future when the semantic convention stabalizes.

                    // The following "EXTENSION" properties are used to calculate metrics. These are not serialized.
                    remoteDependencyDocumentIngress.Extension_IsSuccess = activity.Status != ActivityStatusCode.Error;
                    break;
                case OperationType.Rpc:
                    // TODO RPC
                    break;
                case OperationType.Messaging:
                    // TODO MESSAGING
                    break;
                default:
                    // Unknown or Unexpected Dependency Type
                    remoteDependencyDocumentIngress.Name = atp.activityType.ToString();
                    break;
            }

            return remoteDependencyDocumentIngress;
        }

        internal static Request ConvertToRequestDocument(Activity activity)
        {
            string httpResponseStatusCode = string.Empty;
            string urlScheme = string.Empty;
            string serverAddress = string.Empty;
            string serverPort = string.Empty;
            string urlPath = string.Empty;
            string urlQuery = string.Empty;

            foreach (ref readonly var tag in activity.EnumerateTagObjects())
            {
                if (tag.Value == null)
                {
                    // do nothing.
                    continue;
                }
                else if (tag.Key == SemanticConventions.AttributeUrlScheme)
                {
                    urlScheme = tag.Value.ToString()!;
                }
                else if (tag.Key == SemanticConventions.AttributeServerAddress)
                {
                    serverAddress = tag.Value.ToString()!;
                }
                else if (tag.Key == SemanticConventions.AttributeServerPort)
                {
                    serverPort = tag.Value.ToString()!;
                }
                else if (tag.Key == SemanticConventions.AttributeUrlPath)
                {
                    urlPath = tag.Value.ToString()!;
                }
                else if (tag.Key == SemanticConventions.AttributeUrlQuery)
                {
                    urlQuery = tag.Value.ToString()!;
                }
                else if (tag.Key == SemanticConventions.AttributeHttpResponseStatusCode)
                {
                    httpResponseStatusCode = tag.Value.ToString()!;
                }
            }

            var length = urlScheme.Length + Uri.SchemeDelimiter.Length + serverAddress.Length + serverPort.Length + urlPath.Length + urlQuery.Length;
            var url = new StringBuilder(length)
                .Append(urlScheme)
                .Append(Uri.SchemeDelimiter)
                .Append(serverAddress)
                .Append($":{serverPort}")
                .Append(urlPath)
                .Append(urlQuery)
                .ToString();

            Request requestDocumentIngress = new()
            {
                DocumentType = DocumentType.Request,
                Name = activity.DisplayName,
                //Url = TODO: I'M TRYING TO GET THE TYPE OF URL CHANGED BACK TO STRING. THIS IS A TEMPORARY FIX. (2024-03-22)
                ResponseCode = httpResponseStatusCode,
                Duration = activity.Duration < SchemaConstants.RequestData_Duration_LessThanDays
                                                ? activity.Duration.ToString("c", CultureInfo.InvariantCulture)
                                                : SchemaConstants.Duration_MaxValue,
                // The following properties are used to calculate metrics. These are not serialized.
                Extension_IsSuccess = IsHttpSuccess(activity, httpResponseStatusCode),
                Extension_Duration = activity.Duration.TotalMilliseconds,
            };

            // TODO: Investigate if we can have a minimal/optimized version of ActivityTagsProcessor for LiveMetric.
            var atp = new ActivityTagsProcessor();
            atp.CategorizeTags(activity);
            SetProperties(requestDocumentIngress, atp);

            // TODO: I'M TRYING TO GET THE TYPE OF URL CHANGED BACK TO STRING. THIS IS A TEMPORARY FIX. (2024-03-22)
            if (Uri.TryCreate(url, UriKind.Absolute, out Uri? uri))
            {
                requestDocumentIngress.Url = uri;
            }

            return requestDocumentIngress;
        }

        internal static ExceptionDocument ConvertToExceptionDocument(ActivityEvent activityEvent)
        {
            ExceptionDocument exceptionDocument = new();
            int propertiesCount = 0;

            foreach (ref readonly var tag in activityEvent.EnumerateTagObjects())
            {
                if (tag.Value == null)
                {
                    continue;
                }
                else if (tag.Key == SemanticConventions.AttributeExceptionType)
                {
                    exceptionDocument.ExceptionType = tag.Value.ToString()!;
                    continue;
                }
                else if (tag.Key == SemanticConventions.AttributeExceptionMessage)
                {
                    exceptionDocument.ExceptionMessage = tag.Value.ToString()!;
                    continue;
                }
                else if (tag.Key == SemanticConventions.AttributeExceptionStacktrace)
                {
                    // do nothing
                }
                else
                {
                    exceptionDocument.Properties.Add(new KeyValuePairString(tag.Key, tag.Value.ToString()));

                    if (++propertiesCount >= MaxProperties)
                    {
                        break;
                    }
                }
            }

            return exceptionDocument;
        }

        internal static ExceptionDocument ConvertToExceptionDocument(LogRecord logRecord, System.Exception exception)
        {
            ExceptionDocument exceptionDocument = new()
            {
                DocumentType = DocumentType.Exception,
                ExceptionType = exception.GetType().FullName,
                ExceptionMessage = exception.Message,
            };

            int propertiesCount = 0;

            foreach (KeyValuePair<string, object?> item in logRecord.Attributes ?? Enumerable.Empty<KeyValuePair<string, object?>>())
            {
                if (item.Value != null)
                {
                    if (item.Key != "{OriginalFormat}")
                    {
                        exceptionDocument.Properties.Add(new KeyValuePairString(item.Key, item.Value.ToString()));

                        if (++propertiesCount >= MaxProperties)
                        {
                            break;
                        }
                    }
                }
            }

            return exceptionDocument;
        }

        internal static Models.Trace ConvertToLogDocument(LogRecord logRecord)
        {
            var traceDocument = new Models.Trace()
            {
                DocumentType = DocumentType.Trace,
                Message = logRecord.FormattedMessage ?? logRecord.Body, // TODO: MAY NEED TO BUILD THE FORMATTED MESSAGE IF NOT AVAILABLE
            };

            int propertiesCount = 0;

            foreach (KeyValuePair<string, object?> item in logRecord.Attributes ?? Enumerable.Empty<KeyValuePair<string, object?>>())
            {
                if (item.Value != null)
                {
                    if (item.Key != "{OriginalFormat}")
                    {
                        traceDocument.Properties.Add(new KeyValuePairString(item.Key, item.Value.ToString()));

                        if (++propertiesCount >= MaxProperties)
                        {
                            break;
                        }
                    }
                }
            }

            return traceDocument;
        }

        internal static Models.Trace ConvertToLogDocument(ActivityEvent activityEvent)
        {
            var traceDocument = new Models.Trace()
            {
                DocumentType = DocumentType.Trace,
                Message = activityEvent.Name,
            };

            int propertiesCount = 0;

            foreach (ref readonly var tag in activityEvent.EnumerateTagObjects())
            {
                if (tag.Value != null)
                {
                    traceDocument.Properties.Add(new KeyValuePairString(tag.Key, tag.Value.ToString()));

                    if (++propertiesCount >= MaxProperties)
                    {
                        break;
                    }
                }
            }

            return traceDocument;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsHttpSuccess(Activity activity, string? responseCode)
        {
            if (int.TryParse(responseCode, out int statusCode))
            {
                bool isSuccessStatusCode = statusCode != 0 && statusCode < 400;
                return activity.Status != ActivityStatusCode.Error && isSuccessStatusCode;
            }
            else
            {
                return activity.Status != ActivityStatusCode.Error;
            }
        }

        private static void SetProperties(DocumentIngress documentIngress, ActivityTagsProcessor atp)
        {
            for (int i = 0; i < atp.UnMappedTags.Length && i < MaxProperties; i++)
            {
                var tag = atp.UnMappedTags[i];
                if (tag.Value != null)
                {
                    documentIngress.Properties.Add(new KeyValuePairString(tag.Key, tag.Value.ToString()));
                }
            }
        }
    }
}
