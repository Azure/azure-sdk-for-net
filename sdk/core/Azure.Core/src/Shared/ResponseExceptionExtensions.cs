// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    internal static class ResponseExceptionExtensions
    {
        private const string DefaultMessage = "Service request failed.";

        public static ValueTask<RequestFailedException> CreateRequestFailedExceptionAsync(this Response response, string message = null, string errorCode = null)
        {
            return CreateRequestFailedExceptionAsync(message ?? DefaultMessage, response, errorCode, true);
        }

        public static RequestFailedException CreateRequestFailedException(this Response response, string message = null, string errorCode = null)
        {
            ValueTask<RequestFailedException> messageTask = CreateRequestFailedExceptionAsync(message, response, errorCode, false);
            Debug.Assert(messageTask.IsCompleted);
            return messageTask.GetAwaiter().GetResult();
        }

        public static async ValueTask<RequestFailedException> CreateRequestFailedExceptionAsync(string message, Response response, string errorCode, bool async)
        {
            message = await CreateRequestFailedMessageAsync(message, response, errorCode, async).ConfigureAwait(false);
            return new RequestFailedException(response.Status, message, errorCode, null);
        }

        public static async ValueTask<string> CreateRequestFailedMessageAsync(string message, Response response, string errorCode, bool async)
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
                messageBuilder.AppendLine($"{responseHeader.Name}: {responseHeader.Value}");
            }

            return messageBuilder.ToString();
        }
    }
}
