// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

#nullable enable

namespace Azure.Core.Pipeline
{
    internal sealed partial class ClientDiagnostics : DiagnosticScopeFactory
    {
        private const string DefaultMessage = "Service request failed.";

        private readonly HttpMessageSanitizer _sanitizer;
        public ClientDiagnostics(ClientOptions options) : base(
            options.GetType().Namespace!,
            GetResourceProviderNamespace(options.GetType().Assembly),
            options.Diagnostics.IsDistributedTracingEnabled)
        {
            _sanitizer = new HttpMessageSanitizer(
                options.Diagnostics.LoggedQueryParameters.ToArray(),
                options.Diagnostics.LoggedHeaderNames.ToArray());
        }

        /// <summary>
        /// Partial method that can optionally be defined to extract the error
        /// message, code, and details in a service specific manner.
        /// </summary>
        /// <param name="content">The error content.</param>
        /// <param name="message">The error message.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="additionalInfo">Additional error details.</param>
#pragma warning disable CA1822 // Member can be static
        partial void ExtractFailureContent(
            string? content,
            ref string? message,
            ref string? errorCode,
            ref IDictionary<string, string>? additionalInfo);
#pragma warning restore CA1822

        public async ValueTask<RequestFailedException> CreateRequestFailedExceptionAsync(Response response, string? message = null, string? errorCode = null, IDictionary<string, string>? additionalInfo = null, Exception? innerException = null)
        {
            var content = await ReadContentAsync(response, true).ConfigureAwait(false);
            ExtractFailureContent(content, ref message, ref errorCode, ref additionalInfo);
            return CreateRequestFailedExceptionWithContent(response, message, content, errorCode, additionalInfo, innerException);
        }

        public RequestFailedException CreateRequestFailedException(Response response, string? message = null, string? errorCode = null, IDictionary<string, string>? additionalInfo = null, Exception? innerException = null)
        {
            string? content = ReadContentAsync(response, false).EnsureCompleted();
            ExtractFailureContent(content, ref message, ref errorCode, ref additionalInfo);
            return CreateRequestFailedExceptionWithContent(response, message, content, errorCode, additionalInfo, innerException);
        }

        public RequestFailedException CreateRequestFailedExceptionWithContent(
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

        public async ValueTask<string> CreateRequestFailedMessageAsync(Response response, string? message, string? errorCode, IDictionary<string, string>? additionalInfo, bool async)
        {
            var content = await ReadContentAsync(response, async).ConfigureAwait(false);
            return CreateRequestFailedMessageWithContent(response, message, content, errorCode, additionalInfo);
        }

        public string CreateRequestFailedMessageWithContent(Response response, string? message, string? content, string? errorCode, IDictionary<string, string>? additionalInfo)
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

        internal static string? GetResourceProviderNamespace(Assembly assembly)
        {
            foreach (var customAttribute in assembly.GetCustomAttributes(true))
            {
                // Weak bind internal shared type
                var attributeType = customAttribute.GetType();
                if (attributeType.Name == "AzureResourceProviderNamespaceAttribute")
                {
                    return attributeType.GetProperty("ResourceProviderNamespace")?.GetValue(customAttribute) as string;
                }
            }

            return null;
        }
    }
}
