// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Pipeline.Policies;

namespace Azure.Core
{
    public static class ResponseExceptionExtensionsExtensions
    {
        private const string DefaultMessage = "Request failed with status code {0}";

        public static Task<RequestFailedException> CreateRequestFailedExceptionAsync(this Response response)
        {
            return CreateRequestFailedExceptionAsync(response, string.Format(DefaultMessage, response.Status));
        }

        public static Task<RequestFailedException> CreateRequestFailedExceptionAsync(this Response response, string message)
        {
            return CreateRequestFailedExceptionAsync(message, response, true);
        }

        public static RequestFailedException CreateRequestFailedException(this Response response)
        {
            return CreateRequestFailedException(response, string.Format(DefaultMessage, response.Status));
        }

        public static RequestFailedException CreateRequestFailedException(this Response response, string message)
        {
            return CreateRequestFailedExceptionAsync(message, response, false).EnsureCompleted();
        }

        public static async Task<RequestFailedException> CreateRequestFailedExceptionAsync(string message, Response response, bool async)
        {
            StringBuilder detailsBuilder = new StringBuilder()
                .Append("Status: ")
                .AppendLine(response.Status.ToString())
                .Append("ReasonPhrase: ")
                .AppendLine(response.ReasonPhrase)
                .AppendLine()
                .AppendLine("Headers:");
            foreach (var responseHeader in response.Headers)
            {
                detailsBuilder.AppendLine($"{responseHeader.Name}: {responseHeader.Value}");
            }

            if (response.ContentStream != null &&
                response.Headers.ContentType?.StartsWith("text/", StringComparison.OrdinalIgnoreCase) == true ||
                response.Headers.ContentType?.Contains("charset=") == true)
            {
                detailsBuilder.AppendLine()
                    .AppendLine("Content:");

                using (var streamReader = new StreamReader(response.ContentStream))
                {
                    string content = async ? await streamReader.ReadToEndAsync() : streamReader.ReadToEnd();

                    detailsBuilder.AppendLine(content);
                }
            }

            return new RequestFailedException(response.Status, message, detailsBuilder.ToString());
        }
    }
}
