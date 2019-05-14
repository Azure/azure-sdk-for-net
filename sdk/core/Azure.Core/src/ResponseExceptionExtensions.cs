// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.Pipeline.Policies;

namespace Azure.Core
{
    public static class ResponseExceptionExtensionsExtensions
    {
        private const string DefaultMessage = "Service request failed.";

        public static Task<RequestFailedException> CreateRequestFailedExceptionAsync(this Response response)
        {
            return CreateRequestFailedExceptionAsync(response, DefaultMessage);
        }

        public static Task<RequestFailedException> CreateRequestFailedExceptionAsync(this Response response, string message)
        {
            return CreateRequestFailedExceptionAsync(message, response, true);
        }

        public static RequestFailedException CreateRequestFailedException(this Response response)
        {
            return CreateRequestFailedException(response, DefaultMessage);
        }

        public static RequestFailedException CreateRequestFailedException(this Response response, string message)
        {
            return CreateRequestFailedExceptionAsync(message, response, false).EnsureCompleted();
        }

        public static async Task<RequestFailedException> CreateRequestFailedExceptionAsync(string message, Response response, bool async)
        {
            StringBuilder messageBuilder = new StringBuilder()
                .AppendLine(message)
                .Append("Status: ")
                .Append(response.Status.ToString())
                .Append(" (")
                .Append(response.ReasonPhrase)
                .AppendLine(")");

            if (response.ContentStream != null &&
                ContentTypeUtilities.TryGetTextEncoding(response.Headers.ContentType, out var encoding))
            {
                messageBuilder
                    .AppendLine()
                    .AppendLine("Content:");

                using (var streamReader = new StreamReader(response.ContentStream, encoding))
                {
                    string content = async ? await streamReader.ReadToEndAsync() : streamReader.ReadToEnd();

                    messageBuilder.AppendLine(content);
                }
            }


            messageBuilder
                .AppendLine()
                .AppendLine("Headers:");
            foreach (var responseHeader in response.Headers)
            {
                messageBuilder.AppendLine($"{responseHeader.Name}: {responseHeader.Value}");
            }

            return new RequestFailedException(response.Status, messageBuilder.ToString());
        }
    }
}
