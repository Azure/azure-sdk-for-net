// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Models;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals
{
    /// <summary>
    /// Helper class used to convert Activity to the LiveMetrics document schema.
    /// </summary>
    internal static class DocumentHelper
    {
        internal static RemoteDependency ConvertToRemoteDependency(Activity activity)
        {
            string urlFull = string.Empty, httpResponseStatusCode = string.Empty;

            foreach (ref readonly var tag in activity.EnumerateTagObjects())
            {
                if (tag.Value == null)
                {
                    continue;
                }
                else if (tag.Key == SemanticConventions.AttributeUrlFull)
                {
                    urlFull = tag.Value.ToString();
                    continue;
                }
                else if (tag.Key == SemanticConventions.AttributeHttpResponseStatusCode)
                {
                    httpResponseStatusCode = tag.Value.ToString();
                    continue;
                }
            }

            RemoteDependency remoteDependencyDocumentIngress = new()
            {
                DocumentType = DocumentIngressDocumentType.RemoteDependency,
                Name = activity.DisplayName,
                CommandName = urlFull, // TODO: WHAT ABOUT DATABASES?
                ResultCode = httpResponseStatusCode,
                Duration = activity.Duration < SchemaConstants.RequestData_Duration_LessThanDays
                                                ? activity.Duration.ToString("c", CultureInfo.InvariantCulture)
                                                : SchemaConstants.Duration_MaxValue,
                // TODO: Properties = new Dictionary<string, string>(), - UX supports up to 10 custom properties

                // The following properties are used to calculate metrics. These are not serialized.
                Extension_IsSuccess = IsSuccess(activity, httpResponseStatusCode),
                Extension_Duration = activity.Duration.TotalMilliseconds,
            };

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
                    continue;
                }
                else if (tag.Key == SemanticConventions.AttributeUrlScheme)
                {
                    urlScheme = tag.Value.ToString();
                    continue;
                }
                else if (tag.Key == SemanticConventions.AttributeServerAddress)
                {
                    serverAddress = tag.Value.ToString();
                    continue;
                }
                else if (tag.Key == SemanticConventions.AttributeServerPort)
                {
                    serverPort = tag.Value.ToString();
                    continue;
                }
                else if (tag.Key == SemanticConventions.AttributeUrlPath)
                {
                    urlPath = tag.Value.ToString();
                    continue;
                }
                else if (tag.Key == SemanticConventions.AttributeUrlQuery)
                {
                    urlQuery = tag.Value.ToString();
                    continue;
                }
                else if (tag.Key == SemanticConventions.AttributeHttpResponseStatusCode)
                {
                    httpResponseStatusCode = tag.Value.ToString();
                    continue;
                }
            }

            var length = urlScheme.Length + Uri.SchemeDelimiter.Length + serverAddress.Length + serverPort.Length + urlPath.Length + urlQuery.Length;
            var urlStringBuilder = new System.Text.StringBuilder(length)
                .Append(urlScheme)
                .Append(Uri.SchemeDelimiter)
                .Append(serverAddress)
                .Append(serverPort != null ? $":{serverPort}" : string.Empty)
                .Append(urlPath)
                .Append(urlQuery);

            Request requestDocumentIngress = new()
            {
                DocumentType = DocumentIngressDocumentType.Request,
                Name = activity.DisplayName,
                Url = urlStringBuilder.ToString(),
                ResponseCode = httpResponseStatusCode,
                Duration = activity.Duration < SchemaConstants.RequestData_Duration_LessThanDays
                                                ? activity.Duration.ToString("c", CultureInfo.InvariantCulture)
                                                : SchemaConstants.Duration_MaxValue,
                // TODO: Properties = new Dictionary<string, string>(), - UX supports up to 10 custom properties

                // The following properties are used to calculate metrics. These are not serialized.
                Extension_IsSuccess = IsSuccess(activity, httpResponseStatusCode),
                Extension_Duration = activity.Duration.TotalMilliseconds,
            };

            return requestDocumentIngress;
        }

        internal static Models.Exception CreateException(string exceptionType, string exceptionMessage)
        {
            Models.Exception exceptionDocumentIngress = new()
            {
                DocumentType = DocumentIngressDocumentType.Exception,
                ExceptionType = exceptionType,
                ExceptionMessage = exceptionMessage,
                // TODO: Properties = new Dictionary<string, string>(), - UX supports up to 10 custom properties
            };

            return exceptionDocumentIngress;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsSuccess(Activity activity, string responseCode)
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
