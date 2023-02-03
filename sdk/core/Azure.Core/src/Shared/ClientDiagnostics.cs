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
using System.Text.Json.Serialization;
using System.Threading.Tasks;

#nullable enable

namespace Azure.Core.Pipeline
{
    internal class ClientDiagnostics : DiagnosticScopeFactory
    {
        private const string DefaultMessage = "Service request failed.";

        private readonly HttpMessageSanitizer _sanitizer;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientDiagnostics"/> class.
        /// </summary>
        /// <param name="options">The customer provided client options object.</param>
        /// <param name="suppressNestedClientActivities">Flag controlling if <see cref="System.Diagnostics.Activity"/>
        ///  created by this <see cref="ClientDiagnostics"/> for client method calls should be suppressed when called
        ///  by other Azure SDK client methods.  It's recommended to set it to true for new clients; use default (null)
        ///  for backward compatibility reasons, or set it to false to explicitly disable suppression for specific cases.
        ///  The default value could change in the future, the flag should be only set to false if suppression for the client
        ///  should never be enabled.</param>
        public ClientDiagnostics(ClientOptions options, bool? suppressNestedClientActivities = null)
                    : this(options.GetType().Namespace!,
                    GetResourceProviderNamespace(options.GetType().Assembly),
                    options.Diagnostics,
                    suppressNestedClientActivities)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientDiagnostics"/> class.
        /// </summary>
        /// <param name="optionsNamespace">Namespace of the client class, such as Azure.Storage or Azure.AppConfiguration.</param>
        /// <param name="providerNamespace">Azure Resource Provider namespace of the Azure service SDK is primarily used for.</param>
        /// <param name="diagnosticsOptions">The customer provided client diagnostics options.</param>
        /// <param name="suppressNestedClientActivities">Flag controlling if <see cref="System.Diagnostics.Activity"/>
        ///  created by this <see cref="ClientDiagnostics"/> for client method calls should be suppressed when called
        ///  by other Azure SDK client methods.  It's recommended to set it to true for new clients, use default (null) for old clients
        ///  for backward compatibility reasons, or set it to false to explicitly disable suppression for specific cases.
        ///  The default value could change in the future, the flag should be only set to false if suppression for the client
        ///  should never be enabled.</param>
        public ClientDiagnostics(string optionsNamespace, string? providerNamespace, DiagnosticsOptions diagnosticsOptions, bool? suppressNestedClientActivities = null)
            : base(optionsNamespace, providerNamespace, diagnosticsOptions.IsDistributedTracingEnabled, suppressNestedClientActivities.GetValueOrDefault(false))
        {
            _sanitizer = CreateMessageSanitizer(diagnosticsOptions);
        }

        internal static HttpMessageSanitizer CreateMessageSanitizer(DiagnosticsOptions diagnostics)
        {
            return new HttpMessageSanitizer(
                diagnostics.LoggedQueryParameters.ToArray(),
                diagnostics.LoggedHeaderNames.ToArray());
        }

        internal static ResponseError? ExtractAzureErrorContent(string? content)
        {
            try
            {
                // Optimistic check for JSON object we expect
                if (content == null ||
                    !content.StartsWith("{", StringComparison.OrdinalIgnoreCase)) return null;

                return JsonSerializer.Deserialize<ErrorResponse>(content)?.Error;
            }
            catch (Exception)
            {
                // Ignore any failures - unexpected content will be
                // included verbatim in the detailed error message
            }

            return null;
        }

        public async ValueTask<RequestFailedException> CreateRequestFailedExceptionAsync(Response response, ResponseError? error = null, IDictionary<string, string>? additionalInfo = null, Exception? innerException = null)
        {
            if (GetType() == typeof(ClientDiagnostics) && error is null && additionalInfo is null)
            {
                return new RequestFailedException(response, innerException);
            }

            var content = await ReadContentAsync(response, true).ConfigureAwait(false);
            return CreateRequestFailedExceptionWithContent(response, error, content, additionalInfo, innerException);
        }

        public RequestFailedException CreateRequestFailedException(Response response, ResponseError? error = null, IDictionary<string, string>? additionalInfo = null, Exception? innerException = null)
        {
            if (GetType() == typeof(ClientDiagnostics) && error is null && additionalInfo is null)
            {
                return new RequestFailedException(response, innerException);
            }

            string? content = ReadContentAsync(response, false).EnsureCompleted();
            return CreateRequestFailedExceptionWithContent(response, error, content, additionalInfo, innerException);
        }

        private RequestFailedException CreateRequestFailedExceptionWithContent(
            Response response,
            ResponseError? error = null,
            string? content = null,
            IDictionary<string, string>? additionalInfo = null,
            Exception? innerException = null)
        {
            error ??= ExtractAzureErrorContent(content);
            var formatMessage = CreateRequestFailedMessageWithContent(response, error, content, additionalInfo, _sanitizer);
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

        public async ValueTask<string> CreateRequestFailedMessageAsync(Response response, ResponseError? error, IDictionary<string, string>? additionalInfo, bool async)
        {
            var content = await ReadContentAsync(response, async).ConfigureAwait(false);
            return CreateRequestFailedMessageWithContent(response, error, content, additionalInfo, _sanitizer);
        }

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
                string header = $"{responseHeader.Name}: {headerValue}";
                messageBuilder.AppendLine(header);
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

        private class ErrorResponse
        {
            [JsonPropertyName("error")]
            public ResponseError? Error { get; set; }
        }
    }
}
