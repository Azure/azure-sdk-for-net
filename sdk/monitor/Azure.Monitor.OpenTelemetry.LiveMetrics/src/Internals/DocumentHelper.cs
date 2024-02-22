// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Models;
using ExceptionDocument = Azure.Monitor.OpenTelemetry.LiveMetrics.Models.Exception;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals
{
    /// <summary>
    /// Helper class used to convert Activity to the LiveMetrics document schema.
    /// </summary>
    internal static class DocumentHelper
    {
        // TODO: NEED TO HANDLE UNIQUE MAXLENGTH VALUES FOR DOCUMENT TYPES. SEE SWAGGER FOR MAXLENGTH VALUES.

        internal static RemoteDependency ConvertToRemoteDependency(Activity activity)
        {
            // TODO: Investigate if we can have a minimal/optimized version of ActivityTagsProcessor for LiveMetric.
            var atp = new ActivityTagsProcessor();
            atp.CategorizeTags(activity);

            RemoteDependency remoteDependencyDocumentIngress = new()
            {
                DocumentType = DocumentIngressDocumentType.RemoteDependency,

                // TODO: Properties = new Dictionary<string, string>(), - UX supports up to 10 custom properties

                // The following "EXTENSION" properties are used to calculate metrics. These are not serialized.
                Extension_Duration = activity.Duration.TotalMilliseconds,
            };

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

        internal static Request ConvertToRequest(Activity activity)
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
                    urlScheme = tag.Value.ToString();
                }
                else if (tag.Key == SemanticConventions.AttributeServerAddress)
                {
                    serverAddress = tag.Value.ToString();
                }
                else if (tag.Key == SemanticConventions.AttributeServerPort)
                {
                    serverPort = tag.Value.ToString();
                }
                else if (tag.Key == SemanticConventions.AttributeUrlPath)
                {
                    urlPath = tag.Value.ToString();
                }
                else if (tag.Key == SemanticConventions.AttributeUrlQuery)
                {
                    urlQuery = tag.Value.ToString();
                }
                else if (tag.Key == SemanticConventions.AttributeHttpResponseStatusCode)
                {
                    httpResponseStatusCode = tag.Value.ToString();
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
                DocumentType = DocumentIngressDocumentType.Request,
                Name = activity.DisplayName,
                Url = url,
                ResponseCode = httpResponseStatusCode,
                Duration = activity.Duration < SchemaConstants.RequestData_Duration_LessThanDays
                                                ? activity.Duration.ToString("c", CultureInfo.InvariantCulture)
                                                : SchemaConstants.Duration_MaxValue,
                // TODO: Properties = new Dictionary<string, string>(), - UX supports up to 10 custom properties

                // The following properties are used to calculate metrics. These are not serialized.
                Extension_IsSuccess = IsHttpSuccess(activity, httpResponseStatusCode),
                Extension_Duration = activity.Duration.TotalMilliseconds,
            };

            return requestDocumentIngress;
        }

        internal static ExceptionDocument CreateException(string exceptionType, string exceptionMessage)
        {
            ExceptionDocument exceptionDocumentIngress = new()
            {
                DocumentType = DocumentIngressDocumentType.Exception,
                ExceptionType = exceptionType,
                ExceptionMessage = exceptionMessage,
                // TODO: Properties = new Dictionary<string, string>(), - UX supports up to 10 custom properties
            };

            return exceptionDocumentIngress;
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
    }
}
