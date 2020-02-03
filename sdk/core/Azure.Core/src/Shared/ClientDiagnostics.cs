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

#nullable enable

namespace Azure.Core.Pipeline
{
    internal sealed class ClientDiagnostics: DiagnosticScopeFactory
    {
        private const string DefaultMessage = "Service request failed.";

        private readonly HttpMessageSanitizer _sanitizer;
        public ClientDiagnostics(ClientOptions options) : base(
            options.GetType().Namespace,
            GetResourceProviderNamespace(options.GetType().Assembly),
            options.Diagnostics.IsDistributedTracingEnabled)
        {
            _sanitizer = new HttpMessageSanitizer(
                options.Diagnostics.LoggedHeaderNames.ToArray(),
                options.Diagnostics.LoggedQueryParameters.ToArray());
        }

        public ValueTask<RequestFailedException> CreateRequestFailedExceptionAsync(Response response, string? message = null, string? errorCode = null)
        {
            return CreateRequestFailedExceptionAsync(message ?? DefaultMessage, response, errorCode, true);
        }

        public RequestFailedException CreateRequestFailedException(Response response, string? message = null, string? errorCode = null)
        {
            ValueTask<RequestFailedException> messageTask = CreateRequestFailedExceptionAsync(message ?? DefaultMessage, response, errorCode, false);
            Debug.Assert(messageTask.IsCompleted);
            return messageTask.GetAwaiter().GetResult();
        }

        public RequestFailedException CreateRequestFailedExceptionWithContent(
            Response response,
            string? message = null,
            string? content = null,
            string? errorCode = null,
            IDictionary<string, string>? additionalInfo = null,
            Exception? innerException = null)
        {
            var formatMessage = FormatMessage(response, message, content, errorCode, additionalInfo);
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

        public async ValueTask<RequestFailedException> CreateRequestFailedExceptionAsync(string message, Response response, string? errorCode, bool async)
        {
            message = await CreateRequestFailedMessageAsync(message, response, errorCode, async).ConfigureAwait(false);
            return new RequestFailedException(response.Status, message, errorCode, null);
        }

        public async ValueTask<string> CreateRequestFailedMessageAsync(string message, Response response, string? errorCode, bool async)
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

            return FormatMessage(response, message, content, errorCode);
        }

        public string FormatMessage(Response response, string? message = null, string? content = null, string? errorCode = null, IDictionary<string, string>? additionalInfo = null)
        {
            StringBuilder messageBuilder = new StringBuilder()
                .AppendLine(message ?? DefaultMessage)
                .Append("Status: ")
                .Append(response.Status.ToString(CultureInfo.InvariantCulture))
                .Append(" (")
                .Append(response.ReasonPhrase)
                .AppendLine(")");

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