// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    /// <summary>
    /// This type has two responsibilities:
    ///  1) Analyzes HTTP responses and exceptions and determine if they should be retried, or classified as an error
    ///  2) Create the exception message in a service-specific way, with two customization options:
    ///     A) Services may pass client options to customize how the error message is sanitized
    ///     B) Services may inherit from ResponseClassifier and override ExtractFailureContent to customize how error
    ///        information is extracted from the Response body.
    /// </summary>
    public class ResponseClassifier
    {
        private const string DefaultMessage = "Service request failed.";

        private readonly HttpMessageSanitizer _sanitizer;

        /// <summary>
        /// Initializes a new instance of <see cref="ResponseClassifier"/>.
        /// </summary>
        public ResponseClassifier() : this(new DefaultClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ResponseClassifier"/>.
        /// </summary>
        /// <param name="options"></param>
        public ResponseClassifier(ClientOptions options)
        {
            _sanitizer = new HttpMessageSanitizer(
                options.Diagnostics.LoggedQueryParameters.ToArray(),
                options.Diagnostics.LoggedHeaderNames.ToArray());
        }

        #region Classification methods
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

        private bool _computedExceptionDetails; // false
        private string? _exceptionMessage;
        private string? _errorCode;

        internal string GetExceptionMessage(Response response)
        {
            if (!_computedExceptionDetails)
            {
                ComputeExceptionDetails(response);
            }

            return _exceptionMessage!;
        }

        internal string GetErrorCode(Response response)
        {
            if (!_computedExceptionDetails)
            {
                ComputeExceptionDetails(response);
            }

            return _errorCode!;
        }

        private void ComputeExceptionDetails(Response response)
        {
            string? message = null;
            string? errorCode = null;
            //IDictionary<string, string>? additionalInfo = new

            string? content = ReadContentAsync(response, false).EnsureCompleted();
            ExtractFailureContent(content, response.Headers, ref message, ref errorCode);//, ref additionalInfo);
            _exceptionMessage = CreateRequestFailedMessageWithContent(response, message, content, errorCode);//, additionalInfo);
            _errorCode = errorCode;
            _computedExceptionDetails = true;
        }

        /// <summary>
        /// Specifies if the response contained in the <paramref name="message"/> is not successful.
        /// </summary>
        public virtual bool IsErrorResponse(HttpMessage message)
        {
            var statusKind = message.Response.Status / 100;
            return statusKind == 4 || statusKind == 5;
        }
        #endregion

        #region Exception creation methods -- from ClientDiagnostics, we'll add these back in a later iteration

        // TODO: there's a lot of work to do from a Core/service library dependencies perspective
        // to move these methods from ClientDiagnostics to ResponseClassifier -- currently tracking that
        // with this issue: https://github.com/azure/azure-sdk-for-net/issues/24031

        // NOTE: where these take Response along with other parameters, why do we need the other parameters?
        // Would it be possible to instead do new RequestFailedException(response) here?

        //public async ValueTask<RequestFailedException> CreateRequestFailedExceptionAsync(Response response, string? message = null, string? errorCode = null, IDictionary<string, string>? additionalInfo = null, Exception? innerException = null)
        //{
        //    var content = await ReadContentAsync(response, true).ConfigureAwait(false);
        //    ExtractFailureContent(content, response.Headers, ref message, ref errorCode, ref additionalInfo);
        //    return CreateRequestFailedExceptionWithContent(response, message, content, errorCode, additionalInfo, innerException);
        //}

        //public RequestFailedException CreateRequestFailedException(Response response, string? message = null, string? errorCode = null, IDictionary<string, string>? additionalInfo = null, Exception? innerException = null)
        //{
        //    string? content = ReadContentAsync(response, false).EnsureCompleted();
        //    ExtractFailureContent(content, response.Headers, ref message, ref errorCode, ref additionalInfo);
        //    return CreateRequestFailedExceptionWithContent(response, message, content, errorCode, additionalInfo, innerException);
        //}

        //public RequestFailedException CreateRequestFailedExceptionWithContent(
        //    Response response,
        //    string? message = null,
        //    string? content = null,
        //    string? errorCode = null,
        //    IDictionary<string, string>? additionalInfo = null,
        //    Exception? innerException = null)
        //{
        //    var formatMessage = CreateRequestFailedMessageWithContent(response, message, content, errorCode, additionalInfo);
        //    var exception = new RequestFailedException(response.Status, formatMessage, errorCode, innerException);

        //    if (additionalInfo != null)
        //    {
        //        foreach (KeyValuePair<string, string> keyValuePair in additionalInfo)
        //        {
        //            exception.Data.Add(keyValuePair.Key, keyValuePair.Value);
        //        }
        //    }

        //    return exception;
        //}

        //public async ValueTask<string> CreateRequestFailedMessageAsync(Response response, string? message, string? errorCode, IDictionary<string, string>? additionalInfo, bool async)
        //{
        //    var content = await ReadContentAsync(response, async).ConfigureAwait(false);
        //    return CreateRequestFailedMessageWithContent(response, message, content, errorCode, additionalInfo);
        //}
        #endregion

        #region Exception details extraction & message creation methods
        /// <summary>
        /// </summary>
        /// <param name="response"></param>
        /// <param name="message"></param>
        /// <param name="content"></param>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        internal string CreateRequestFailedMessageWithContent(Response response, string? message, string? content, string? errorCode)//, IDictionary<string, string>? additionalInfo)
        {
            StringBuilder messageBuilder = new StringBuilder()
                .AppendLine(message ?? DefaultMessage)
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

            // Note: we can ignore additionalInfo for now (for the purposes of the discussion of this design)
            // because it's only passed in by exception creation methods called by the service libraries,
            // and isn't useful when we are creating the exception from the response directly.

            //if (additionalInfo != null && additionalInfo.Count > 0)
            //{
            //    messageBuilder
            //        .AppendLine()
            //        .AppendLine("Additional Information:");
            //    foreach (KeyValuePair<string, string> info in additionalInfo)
            //    {
            //        messageBuilder
            //            .Append(info.Key)
            //            .Append(": ")
            //            .AppendLine(info.Value);
            //    }
            //}

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

            return messageBuilder.ToString();
        }

        /// <summary>
        /// Partial method that can optionally be defined to extract the error
        /// message, code, and details in a service specific manner.
        /// </summary>
        /// <param name="content">The error content.</param>
        /// <param name="responseHeaders">The response headers.</param>
        /// <param name="message">The error message.</param>
        /// <param name="errorCode">The error code.</param>
        ///// <param name="additionalInfo">Additional error details.</param>
        protected virtual void ExtractFailureContent(
            string? content,
            ResponseHeaders responseHeaders,
            ref string? message,
            ref string? errorCode)//,
            //ref IDictionary<string, string>? additionalInfo) // We'll add this back in when we
                                  // add the full set of CreateException methods
                                  // from ClientDiagnostics
        {
            try
            {
                // Optimistic check for JSON object we expect
                if (content == null ||
                    !content.StartsWith("{", StringComparison.OrdinalIgnoreCase))
                    return;

                string? parsedMessage = null;
                using JsonDocument document = JsonDocument.Parse(content);
                if (document.RootElement.TryGetProperty("error", out var errorProperty))
                {
                    if (errorProperty.TryGetProperty("code", out var codeProperty))
                    {
                        errorCode = codeProperty.GetString();
                    }
                    if (errorProperty.TryGetProperty("message", out var messageProperty))
                    {
                        parsedMessage = messageProperty.GetString();
                    }
                }

                // Make sure we parsed a message so we don't overwrite the value with null
                if (parsedMessage != null)
                {
                    message = parsedMessage;
                }
            }
            catch (Exception)
            {
                // Ignore any failures - unexpected content will be
                // included verbatim in the detailed error message
            }
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
        #endregion
    }
}
