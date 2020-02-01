// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    internal sealed class ClientDiagnostics: DiagnosticsScopeFactory
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

        public async ValueTask<RequestFailedException> CreateRequestFailedExceptionAsync(string message, Response response, string? errorCode, bool async)
        {
            message = await CreateRequestFailedMessageAsync(message, response, errorCode, async).ConfigureAwait(false);
            return new RequestFailedException(response.Status, message, errorCode, null);
        }

        public async ValueTask<string> CreateRequestFailedMessageAsync(string message, Response response, string? errorCode, bool async)
        {
            StringBuilder messageBuilder = new StringBuilder()
                .AppendLine(message)
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

            if (response.ContentStream != null &&
                ContentTypeUtilities.TryGetTextEncoding(response.Headers.ContentType, out var encoding))
            {
                messageBuilder
                    .AppendLine()
                    .AppendLine("Content:");

                using (var streamReader = new StreamReader(response.ContentStream, encoding))
                {
                    string content = async ? await streamReader.ReadToEndAsync().ConfigureAwait(false) : streamReader.ReadToEnd();

                    messageBuilder.AppendLine(content);
                }
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