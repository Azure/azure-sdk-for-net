// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
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
            var message = await CreateRequestFailedMessageAsync(error.Message, response, error.Code.ToString(), error.Target, async).ConfigureAwait(false);
            var innerException = CreateInnerException(error.InnerError, error.Details);

            return new RequestFailedException(response.Status, message, error.Code.ToString(), innerException);
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

        private static string CreateTextAnalyticsExceptionMessage(string errorCode, string message, string target)
        {
            StringBuilder messageBuilder = new StringBuilder()
                .AppendLine(message)
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

            return messageBuilder.ToString();
        }

        /// <summary>
        /// Called for the innerException and details that are direct children of the top-level error.
        /// </summary>
        /// <param name="innerError"></param>
        /// <param name="details"></param>
        /// <returns></returns>
        private static Exception CreateInnerException(TextAnalyticsInnerError innerError, IEnumerable<TextAnalyticsError> details)
        {
            var detailCount = details.Count();
            if (detailCount > 0)
            {
                var innerExceptions = new Exception[detailCount + 1];
                innerExceptions[0] = CreateInnerException(innerError);

                int i = 1;
                foreach (TextAnalyticsError error in details)
                {
                    innerExceptions[i++] = CreateInnerException(error);
                }

                return new AggregateException(innerExceptions);
            }

            return CreateInnerException(innerError);
        }

        private static Exception CreateInnerException(TextAnalyticsError error)
        {
            var message = CreateTextAnalyticsExceptionMessage(error.Code.ToString(), error.Message, error.Target);
            if (error.InnerError != default)
            {
                return new InvalidOperationException(message, CreateInnerException(error.InnerError));
            }

            return new InvalidOperationException(message);
        }

        private static Exception CreateInnerException(TextAnalyticsInnerError error)
        {
            var message = CreateTextAnalyticsExceptionMessage(error.Code.ToString(), error.Message, error.Target);
            if (error.InnerError != default)
            {
                return new InvalidOperationException(message, CreateInnerException(error.InnerError));
            }

            return new InvalidOperationException(message);
        }
    }
}
