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

#nullable enable

namespace Azure.Core.Pipeline
{
    internal class ClientDiagnostics : DiagnosticScopeFactory
    {
        private readonly ResponseExceptionFactory _exceptionFactory;

        public ClientDiagnostics(ClientOptions options) : base(
            options.GetType().Namespace!,
            GetResourceProviderNamespace(options.GetType().Assembly),
            options.Diagnostics.IsDistributedTracingEnabled)
        {
            _exceptionFactory = new ResponseExceptionFactory(options);
        }

        /// <summary>
        /// Partial method that can optionally be defined to extract the error
        /// message, code, and details in a service specific manner.
        /// </summary>
        /// <param name="content">The error content.</param>
        /// <param name="responseHeaders">The response headers.</param>
        /// <param name="message">The error message.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="additionalInfo">Additional error details.</param>
        protected virtual void ExtractFailureContent(
            string? content,
            ResponseHeaders responseHeaders,
            ref string? message,
            ref string? errorCode,
            ref IDictionary<string, string>? additionalInfo)
        {
            try
            {
                // Optimistic check for JSON object we expect
                if (content == null ||
                    !content.StartsWith("{", StringComparison.OrdinalIgnoreCase)) return;

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

        public async ValueTask<RequestFailedException> CreateRequestFailedExceptionAsync(Response response, string? message = null, string? errorCode = null, IDictionary<string, string>? additionalInfo = null, Exception? innerException = null)
        {
            return await _exceptionFactory.CreateRequestFailedExceptionAsync(response, message, errorCode, additionalInfo, innerException).ConfigureAwait(false);
        }

        public RequestFailedException CreateRequestFailedException(Response response, string? message = null, string? errorCode = null, IDictionary<string, string>? additionalInfo = null, Exception? innerException = null)
        {
            return _exceptionFactory.CreateRequestFailedException(response, message, errorCode, additionalInfo, innerException);
        }

        public RequestFailedException CreateRequestFailedMessageAsync(
            Response response,
            string? message = null,
            string? content = null,
            string? errorCode = null,
            IDictionary<string, string>? additionalInfo = null,
            Exception? innerException = null)
        {
            return _exceptionFactory.CreateRequestFailedMessageAsync(response, message, content, errorCode, additionalInfo, innerException);
        }

        public async ValueTask<string> CreateRequestFailedMessageAsync(Response response, string? message, string? errorCode, IDictionary<string, string>? additionalInfo, bool async)
        {
            return _exceptionFactory.CreateRequestFailedMessageAsync(response, message, errorCode, additionalInfo, async);
        }

        private string CreateRequestFailedMessageWithContent(Response response, string? message, string? content, string? errorCode, IDictionary<string, string>? additionalInfo)
        {
            return _exceptionFactory.CreateRequestFailedMessageWithContent(response, message, content, errorCode, additionalInfo);
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
