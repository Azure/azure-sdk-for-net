// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// Extensions for experimenting with Response API.
    /// </summary>
    public static class ResponseExtensions
    {
        /// <summary>
        /// This will be a property on the non-experimental Azure.Core.Response.
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public static bool IsError(this Response response)
        {
            var classifiedResponse = response as ClassifiedResponse;

            if (classifiedResponse == null)
            {
                throw new InvalidOperationException("IsError was not set on the response. " +
                    "Please ensure the pipeline includes ResponsePropertiesPolicy.");
            }

            return classifiedResponse.IsError;
        }

        /// <summary>
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public static RequestFailedException CreateRequestFailedException(this Response response)
        {
            var classifiedResponse = response as ClassifiedResponse;

            if (classifiedResponse == null)
            {
                throw new InvalidOperationException("ResponseClassifier was not set on the response. " +
                    "Please ensure the pipeline includes ResponsePropertiesPolicy.");
            }

            string message = null;
            string errorCode = null;

            string content = ClientDiagnostics.ReadContentAsync(response, false).EnsureCompleted();
            ClientDiagnostics.ExtractAzureErrorContent(content, ref message, ref errorCode);
            string exceptionMessage = ClientDiagnostics.CreateRequestFailedMessageWithContent(
                response,
                message,
                content,
                errorCode,
                null,
                classifiedResponse.ResponseClassifier.MessageSanitizer);

            return new RequestFailedException(
                response.Status,
                exceptionMessage,
                errorCode,
                null);
        }
    }
}
