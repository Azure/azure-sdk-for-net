// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.TextAnalytics
{
    internal static class TextAnalyticsExceptionExtensions
    {
        public static ValueTask<RequestFailedException> CreateRequestFailedExceptionAsync(this Response response, TextAnalyticsError error)
        {
            return CreateRequestFailedExceptionAsync(response, error, true);
        }

        public static RequestFailedException CreateRequestFailedException(this Response response, TextAnalyticsError error)
        {
            ValueTask<RequestFailedException> messageTask = CreateRequestFailedExceptionAsync(response, error, false);
            return messageTask.GetAwaiter().GetResult();
        }

        public static async ValueTask<RequestFailedException> CreateRequestFailedExceptionAsync(this Response response, TextAnalyticsError error, bool async)
        {
            var message = await CreateRequestFailedMessageAsync(error.Message, response, error.ErrorCode, error.Target, async).ConfigureAwait(false);
            return new RequestFailedException(response.Status, message, error.ErrorCode, null);
        }

        private static async ValueTask<string> CreateRequestFailedMessageAsync(string message, Response response, string errorCode, string target, bool async)
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

            if (!string.IsNullOrWhiteSpace(target))
            {
                messageBuilder.Append("Target: ")
                    .Append(target)
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
