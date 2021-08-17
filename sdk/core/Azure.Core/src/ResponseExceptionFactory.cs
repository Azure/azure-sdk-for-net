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

namespace Azure.Core.Pipeline
{
    internal class ResponseExceptionFactory
    {
        private const string DefaultMessage = "Service request failed.";

        private readonly HttpMessageSanitizer _sanitizer;

        public ResponseExceptionFactory(ClientOptions options)
        {
            _sanitizer = new HttpMessageSanitizer(
                options.Diagnostics.LoggedQueryParameters.ToArray(),
                options.Diagnostics.LoggedHeaderNames.ToArray());
        }

        public async ValueTask<RequestFailedException> CreateRequestFailedExceptionAsync(Response response, string? message = null, string? errorCode = null, IDictionary<string, string>? additionalInfo = null, Exception? innerException = null)
        {
            var content = await ReadContentAsync(response, true).ConfigureAwait(false);
            ExtractFailureContent(content, ref message, ref errorCode);
            return CreateRequestFailedExceptionWithContent(response, message, content, errorCode, additionalInfo, innerException);
        }

        public RequestFailedException CreateRequestFailedException(Response response, string? message = null, string? errorCode = null, IDictionary<string, string>? additionalInfo = null, Exception? innerException = null)
        {
            string? content = ReadContentAsync(response, false).EnsureCompleted();
            ExtractFailureContent(content, ref message, ref errorCode);
            return CreateRequestFailedExceptionWithContent(response, message, content, errorCode, additionalInfo, innerException);
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

        private static void ExtractFailureContent(
            string? content,
            ref string? message,
            ref string? errorCode)
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

        private RequestFailedException CreateRequestFailedExceptionWithContent(
            Response response,
            string? message = null,
            string? content = null,
            string? errorCode = null,
            IDictionary<string, string>? additionalInfo = null,
            Exception? innerException = null)
        {
            var formatMessage = CreateRequestFailedMessageWithContent(response, message, content, errorCode, additionalInfo);
            var exception = new RequestFailedException(response.Status, formatMessage, errorCode, innerException);

            if (additionalInfo != null)
            {
                foreach (KeyValuePair<string, string> keyValuePair in additionalInfo)
                {
                    exception.Data.Add(keyValuePair.Key, keyValuePair.Value);
                }
            }

            return exception;
        }

        private string CreateRequestFailedMessageWithContent(
            Response response,
            string? message,
            string? content,
            string? errorCode,
            IDictionary<string, string>? additionalInfo)
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
                string headerValue = _sanitizer.SanitizeHeader(responseHeader.Name, responseHeader.Value);
                messageBuilder.AppendLine($"{responseHeader.Name}: {headerValue}");
            }

            return messageBuilder.ToString();
        }
    }
}
