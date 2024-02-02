// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Models;
using ExceptionDocument = Azure.Monitor.OpenTelemetry.LiveMetrics.Models.Exception;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals
{
    internal static class DocumentHelper
    {
        internal static RemoteDependency ConvertToRemoteDependency(Activity activity)
        {
            string? statusCodeAttributeValue = null;

            foreach (ref readonly var tag in activity.EnumerateTagObjects())
            {
                if (tag.Key == SemanticConventions.AttributeHttpResponseStatusCode)
                {
                    statusCodeAttributeValue = tag.Value?.ToString();
                    break;
                }
            }

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

            return remoteDependencyDocumentIngress;
        }

        internal static Request ConvertToRequest(Activity activity)
        {
            string? statusCodeAttributeValue = null;

            foreach (ref readonly var tag in activity.EnumerateTagObjects())
            {
                if (tag.Key == SemanticConventions.AttributeHttpResponseStatusCode)
                {
                    statusCodeAttributeValue = tag.Value?.ToString();
                    break;
                }
            }

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

            return requestDocumentIngress;
        }

        internal static Models.Exception CreateException(string exceptionType, string exceptionMessage)
        {
            ExceptionDocument exceptionDocumentIngress = new()
            {
                ExceptionType = exceptionType,
                ExceptionMessage = exceptionMessage,
                DocumentType = DocumentIngressDocumentType.Exception,
                // TODO: DocumentStreamIds = new List<string>(),
                // TODO: Properties = new Dictionary<string, string>(), - Validate with UX team if this is needed.
            };

            return exceptionDocumentIngress;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsSuccess(Activity activity, string? responseCode)
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
