// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    /// <summary>
    /// A type that analyzes HTTP responses and exceptions and determines if they should be retried,
    /// and/or analyzes responses and determines if they should be treated as error responses.
    /// </summary>
    public class ResponseClassifier
    {
        internal static ResponseClassifier Shared { get; } = new();

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

        /// <summary>
        /// </summary>
        /// <param name="content"></param>
        /// <param name="responseHeaders"></param>
        /// <param name="additionalInfo"></param>
        /// <returns></returns>
        public virtual ResponseError? ExtractErrorContent(
            // TODO: is this the right parameter list for a public method?
            string? content,
            ResponseHeaders responseHeaders,
            ref IDictionary<string, string>? additionalInfo)
        {
            return ExtractAzureErrorContent(content);
        }

        //private readonly HttpMessageSanitizer _sanitizer;
        private const string DefaultMessage = "Service request failed.";

        internal static ResponseError? ExtractAzureErrorContent(string? content)
        {
            try
            {
                // Optimistic check for JSON object we expect
                if (content == null ||
                    !content.StartsWith("{", StringComparison.OrdinalIgnoreCase))
                    return null;

                return JsonSerializer.Deserialize<ErrorResponse>(content)?.Error;
            }
            catch (Exception)
            {
                // Ignore any failures - unexpected content will be
                // included verbatim in the detailed error message
            }

            return null;
        }

        //public async ValueTask<RequestFailedException> CreateRequestFailedExceptionAsync(Response response, ResponseError? error = null, IDictionary<string, string>? additionalInfo = null, Exception? innerException = null)
        //{
        //    var content = await ReadContentAsync(response, true).ConfigureAwait(false);
        //    error ??= ExtractErrorContent(content, response.Headers, ref additionalInfo);
        //    return CreateRequestFailedExceptionWithContent(response, error, content, additionalInfo, innerException);
        //}

        //public RequestFailedException CreateRequestFailedException(Response response, ResponseError? error = null, IDictionary<string, string>? additionalInfo = null, Exception? innerException = null)
        //{
        //    string? content = ReadContentAsync(response, false).EnsureCompleted();
        //    error ??= ExtractErrorContent(content, response.Headers, ref additionalInfo);
        //    return CreateRequestFailedExceptionWithContent(response, error, content, additionalInfo, innerException);
        //}

        private static RequestFailedException CreateRequestFailedExceptionWithContent(
            Response response,
            HttpMessageSanitizer sanitizer,
            ResponseError? error = null,
            string? content = null,
            IDictionary<string, string>? additionalInfo = null,
            Exception? innerException = null)
        {
            var formatMessage = CreateRequestFailedMessageWithContent(response, error, content, additionalInfo, sanitizer);
            var exception = new RequestFailedException(response.Status, formatMessage, error?.Code, innerException);

            if (additionalInfo != null)
            {
                foreach (KeyValuePair<string, string> keyValuePair in additionalInfo)
                {
                    exception.Data.Add(keyValuePair.Key, keyValuePair.Value);
                }
            }

            return exception;
        }

        //public async ValueTask<string> CreateRequestFailedMessageAsync(Response response, ResponseError? error, IDictionary<string, string>? additionalInfo, bool async)
        //{
        //    var content = await ReadContentAsync(response, async).ConfigureAwait(false);
        //    return CreateRequestFailedMessageWithContent(response, error, content, additionalInfo, _sanitizer);
        //}

        internal static string CreateRequestFailedMessageWithContent(Response response, ResponseError? error, string? content, IDictionary<string, string>? additionalInfo, HttpMessageSanitizer sanitizer)
        {
            StringBuilder messageBuilder = new StringBuilder();

            messageBuilder
                .AppendLine(error?.Message ?? DefaultMessage)
                .Append("Status: ")
                .Append(response.Status.ToString(CultureInfo.InvariantCulture));

            if (!string.IsNullOrEmpty(response.ReasonPhrase))
            {
                messageBuilder.Append(" (")
                    .Append(response.ReasonPhrase)
                    .AppendLine(")");
            }
            else
            {
                messageBuilder.AppendLine();
            }

            if (!string.IsNullOrWhiteSpace(error?.Code))
            {
                messageBuilder.Append("ErrorCode: ")
                    .Append(error?.Code)
                    .AppendLine();
            }

            if (additionalInfo != null && additionalInfo.Count > 0)
            {
                messageBuilder
                    .AppendLine()
                    .AppendLine("Additional Information:");
                foreach (KeyValuePair<string, string> info in additionalInfo)
                {
                    messageBuilder
                        .Append(info.Key)
                        .Append(": ")
                        .AppendLine(info.Value);
                }
            }

            if (content != null)
            {
                messageBuilder
                    .AppendLine()
                    .AppendLine("Content:")
                    .AppendLine(content);
            }

            messageBuilder
                .AppendLine()
                .AppendLine("Headers:");

            foreach (HttpHeader responseHeader in response.Headers)
            {
                string headerValue = sanitizer.SanitizeHeader(responseHeader.Name, responseHeader.Value);
                messageBuilder.AppendLine($"{responseHeader.Name}: {headerValue}");
            }

            return messageBuilder.ToString();
        }

        internal static async ValueTask<string?> ReadContentAsync(Response response, bool async)
        {
            string? content = null;

            if (response.ContentStream != null &&
                ContentTypeUtilities.TryGetTextEncoding(response.Headers.ContentType, out var encoding))
            {
                using (var streamReader = new StreamReader(response.ContentStream, encoding))
                {
                    content = async ? await streamReader.ReadToEndAsync().ConfigureAwait(false) : streamReader.ReadToEnd();
                }
            }

            return content;
        }

        private class ErrorResponse
        {
            [JsonPropertyName("error")]
            public ResponseError? Error { get; set; }
        }
    }
}
