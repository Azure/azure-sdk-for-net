// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    /// <summary>
    /// A type that analyzes HTTP responses and exceptions and determines if they should be retried.
    /// </summary>
    public class ResponseClassifier
    {
        /// <summary>
        /// Specifies if the request contained in the <paramref name="message"/> should be retried.
        /// </summary>
        public virtual bool IsRetriableResponse(HttpMessage message)
        {
            switch (message.Response.Status)
            {
                case 408: // Request Timeout
                case 429: // Too Many Requests
                case 500: // Internal Server Error
                case 502: // Bad Gateway
                case 503: // Service Unavailable
                case 504: // Gateway Timeout
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Specifies if the operation that caused the exception should be retried.
        /// </summary>
        public virtual bool IsRetriableException(Exception exception)
        {
            return (exception is IOException) ||
                   (exception is RequestFailedException requestFailed && requestFailed.Status == 0);
        }

        /// <summary>
        /// Specifies if the operation that caused the exception should be retried taking the <see cref="HttpMessage"/> into consideration.
        /// </summary>
        public virtual bool IsRetriable(HttpMessage message, Exception exception)
        {
            return IsRetriableException(exception) ||
                   // Retry non-user initiated cancellations
                   (exception is OperationCanceledException && !message.CancellationToken.IsCancellationRequested);
        }

        /// <summary>
        /// Specifies if the response contained in the <paramref name="message"/> is not successful.
        /// </summary>
        public virtual bool IsErrorResponse(HttpMessage message)
        {
            var statusKind = message.Response.Status / 100;
            return statusKind == 4 || statusKind == 5;
        }

        //private const string DefaultMessage = "Service request failed.";

        //internal static string CreateRequestFailedMessageWithContent(Response response, string? message, string? content, string? errorCode, IDictionary<string, string>? additionalInfo, HttpMessageSanitizer sanitizer)
        //{
        //    StringBuilder messageBuilder = new StringBuilder();

        //    messageBuilder
        //        .AppendLine(message ?? DefaultMessage)
        //        .Append("Status: ")
        //        .Append(response.Status.ToString(CultureInfo.InvariantCulture));

        //    if (!string.IsNullOrEmpty(response.ReasonPhrase))
        //    {
        //        messageBuilder.Append(" (")
        //            .Append(response.ReasonPhrase)
        //            .AppendLine(")");
        //    }
        //    else
        //    {
        //        messageBuilder.AppendLine();
        //    }

        //    if (!string.IsNullOrWhiteSpace(errorCode))
        //    {
        //        messageBuilder.Append("ErrorCode: ")
        //            .Append(errorCode)
        //            .AppendLine();
        //    }

        //    if (additionalInfo != null && additionalInfo.Count > 0)
        //    {
        //        messageBuilder
        //            .AppendLine()
        //            .AppendLine("Additional Information:");
        //        foreach (KeyValuePair<string, string> info in additionalInfo)
        //        {
        //            messageBuilder
        //                .Append(info.Key)
        //                .Append(": ")
        //                .AppendLine(info.Value);
        //        }
        //    }

        //    if (content != null)
        //    {
        //        messageBuilder
        //            .AppendLine()
        //            .AppendLine("Content:")
        //            .AppendLine(content);
        //    }

        //    messageBuilder
        //        .AppendLine()
        //        .AppendLine("Headers:");

        //    foreach (HttpHeader responseHeader in response.Headers)
        //    {
        //        string headerValue = sanitizer.SanitizeHeader(responseHeader.Name, responseHeader.Value);
        //        messageBuilder.AppendLine($"{responseHeader.Name}: {headerValue}");
        //    }

        //    return messageBuilder.ToString();
        //}

        //internal static async ValueTask<string?> ReadContentAsync(Response response, bool async)
        //{
        //    string? content = null;

        //    if (response.ContentStream != null &&
        //        ContentTypeUtilities.TryGetTextEncoding(response.Headers.ContentType, out var encoding))
        //    {
        //        using (var streamReader = new StreamReader(response.ContentStream, encoding))
        //        {
        //            content = async ? await streamReader.ReadToEndAsync().ConfigureAwait(false) : streamReader.ReadToEnd();
        //        }
        //    }

        //    return content;
        //}
    }
}
