// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    /// <summary>
    /// A type that analyzes HTTP responses and exceptions and determines if they should be retried.
    /// </summary>
    public class ResponseClassifier
    {
        private const string DefaultFailureMessage = "Service request failed.";

        private readonly HttpMessageSanitizer _sanitizer;

        /// <summary>
        /// Initializes a new instance of <see cref="ResponseClassifier"/>.
        /// </summary>
        public ResponseClassifier() : this(new DefaultClientOptions())
        {
        }

        /// <summary>
        /// </summary>

        /// <summary>
        /// Initializes a new instance of <see cref="ResponseClassifier"/>.
        /// </summary>
        public ResponseClassifier(ClientOptions options)
        {
            _sanitizer = new HttpMessageSanitizer(
                options?.Diagnostics.LoggedQueryParameters.ToArray() ?? Array.Empty<string>(),
                options?.Diagnostics.LoggedHeaderNames.ToArray() ?? Array.Empty<string>());
        }

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
        /// Creates an instance of <see cref="RequestFailedException"/> for the provided failed <see cref="Response"/>.
        /// </summary>
        /// <param name="response"></param>
        /// <param name="error"></param>
        /// <param name="innerException"></param>
        /// <returns></returns>
        public virtual async ValueTask<RequestFailedException> CreateRequestFailedExceptionAsync(
            Response response,
            AzureError? error = null,
            Exception? innerException = null)
        {
            var content = await ReadContentAsync(response, true).ConfigureAwait(false);
            return CreateRequestFailedExceptionWithContent(response, content, error, innerException);
        }

        /// <summary>
        /// Creates an instance of <see cref="RequestFailedException"/> for the provided failed <see cref="Response"/>.
        /// </summary>
        /// <param name="response"></param>
        /// <param name="error"></param>
        /// <param name="innerException"></param>
        /// <returns></returns>
        public virtual RequestFailedException CreateRequestFailedException(
            Response response,
            AzureError? error = null,
            Exception? innerException = null)
        {
            string? content = ReadContentAsync(response, false).EnsureCompleted();
            return CreateRequestFailedExceptionWithContent(response, content, error, innerException);
        }

        /// <summary>
        /// Partial method that can optionally be defined to extract the error
        /// message, code, and details in a service specific manner.
        /// </summary>
        /// <param name="response">The response headers.</param>
        /// <param name="textContent">The extracted text content</param>
        protected virtual AzureError? ExtractFailureContent(Response response, string? textContent)
        {
            try
            {
                // Optimistic check for JSON object we expect
                if (textContent == null ||
                    !textContent.StartsWith("{", StringComparison.OrdinalIgnoreCase))
                    return null;

                var extractFailureContent = new AzureError();

                using JsonDocument document = JsonDocument.Parse(textContent);
                if (document.RootElement.TryGetProperty("error", out var errorProperty))
                {
                    if (errorProperty.TryGetProperty("code", out var codeProperty))
                    {
                        extractFailureContent.ErrorCode = codeProperty.GetString();
                    }
                    if (errorProperty.TryGetProperty("message", out var messageProperty))
                    {
                        extractFailureContent.Message = messageProperty.GetString();
                    }
                }

                return extractFailureContent;
            }
            catch (Exception)
            {
                // Ignore any failures - unexpected content will be
                // included verbatim in the detailed error message
            }

            return null;
        }

        private RequestFailedException CreateRequestFailedExceptionWithContent(
            Response response,
            string? content,
            AzureError? details,
            Exception? innerException)
        {
            var errorInformation = ExtractFailureContent(response, content);

            var message = details?.Message ?? errorInformation?.Message ?? DefaultFailureMessage;
            var errorCode = details?.ErrorCode ?? errorInformation?.ErrorCode;

            IDictionary<object, object?>? data = null;
            if (errorInformation?.Data != null)
            {
                if (details?.Data == null)
                {
                    data = errorInformation.Data;
                }
                else
                {
                    data = new Dictionary<object, object?>(details.Data);
                    foreach (var pair in errorInformation.Data)
                    {
                        data[pair.Key] = pair.Value;
                    }
                }
            }

            StringBuilder messageBuilder = new StringBuilder()
                .AppendLine(message)
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

            if (!string.IsNullOrWhiteSpace(errorCode))
            {
                messageBuilder.Append("ErrorCode: ")
                    .Append(errorCode)
                    .AppendLine();
            }

            if (data != null && data.Count > 0)
            {
                messageBuilder
                    .AppendLine()
                    .AppendLine("Additional Information:");
                foreach (KeyValuePair<object, object?> info in data)
                {
                    messageBuilder
                        .Append(info.Key)
                        .Append(": ")
                        .Append(info.Value)
                        .AppendLine();
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
                string headerValue = _sanitizer.SanitizeHeader(responseHeader.Name, responseHeader.Value);
                messageBuilder.AppendLine($"{responseHeader.Name}: {headerValue}");
            }

            var exception = new RequestFailedException(response.Status, messageBuilder.ToString(), errorCode, innerException);

            if (data != null)
            {
                foreach (KeyValuePair<object, object?> keyValuePair in data)
                {
                    exception.Data.Add(keyValuePair.Key, keyValuePair.Value);
                }
            }

            return exception;
        }

        private static async ValueTask<string?> ReadContentAsync(Response response, bool async)
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
    }
}
