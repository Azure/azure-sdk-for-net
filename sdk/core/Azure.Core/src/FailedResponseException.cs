// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Pipeline.Policies;

namespace Azure
{
    public class RequestFailedException : Exception
    {
        private static string _defaultMessage = "Request failed with status code {0}";

        public int Status { get; }

        public string Response { get; }

        public RequestFailedException(int status, string message, string response)
            : this(status, message, response, null)
        {}

        public RequestFailedException(int status, string message, string response, Exception innerException)
            : base(message, innerException)
        {
            Status = status;
            Response = response;
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + Response;
        }

        public static Task<RequestFailedException> CreateAsync(Response response)
        {
            return CreateAsync(response, string.Format(_defaultMessage, response.Status));
        }

        public static Task<RequestFailedException> CreateAsync(Response response, string message)
        {
            return CreateAsync(message, response, true);
        }

        public static RequestFailedException Create(Response response)
        {
            return Create(response, string.Format(_defaultMessage, response.Status));
        }

        public static RequestFailedException Create(Response response, string message)
        {
            return CreateAsync(message, response, false).EnsureCompleted();
        }

        public static async Task<RequestFailedException> CreateAsync(string message, Response response, bool async)
        {
            StringBuilder detailsBuilder = new StringBuilder();
            detailsBuilder.Append("Status: ");
            detailsBuilder.AppendLine(response.Status.ToString());
            detailsBuilder.Append("ReasonPhrase: ");
            detailsBuilder.AppendLine(response.ReasonPhrase);
            detailsBuilder.AppendLine();
            detailsBuilder.AppendLine("Headers:");
            foreach (var responseHeader in response.Headers)
            {
                detailsBuilder.AppendLine($"{responseHeader.Name}: {responseHeader.Value}");
            }

            if (response.ContentStream != null &&
                response.Headers.ContentType?.StartsWith("text/", StringComparison.OrdinalIgnoreCase) == true)
            {
                detailsBuilder.AppendLine();
                detailsBuilder.AppendLine("Content:");

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
