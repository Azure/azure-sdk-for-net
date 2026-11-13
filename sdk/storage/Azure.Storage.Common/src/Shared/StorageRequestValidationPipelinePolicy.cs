// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Storage
{
    /// <summary>
    /// Pipeline policy to verify x-ms-client-request-id and x-ms-client-return-request-id
    /// headers that are echoed back from a request match.
    /// </summary>
    internal class StorageRequestValidationPipelinePolicy : HttpPipelineSynchronousPolicy
    {
        /// <summary>
        /// Create a new StorageRequestValidationPipelinePolicy
        /// </summary>
        public StorageRequestValidationPipelinePolicy() { }

        /// <summary>
        /// Verify x-ms-client-request-id and x-ms-client-return-request-id headers matches as
        /// x-ms-client-return-request-id is an echo of x-mis-client-request-id.
        /// </summary>
        /// <param name="message">The message that was sent</param>
        public override void OnReceivedResponse(HttpMessage message)
        {
            if (message.HasResponse &&
                message.Request.Headers.TryGetValue(Constants.HeaderNames.ClientRequestId, out var original) &&
                message.Response.Headers.TryGetValues(Constants.HeaderNames.ClientRequestId, out var echo) &&
                !string.Equals(original, echo.First(), StringComparison.OrdinalIgnoreCase))
            {
                throw Errors.ClientRequestIdMismatch(message.Response, echo.First(), original);
            }

            if (message.Request.Headers.Contains(Constants.StructuredMessage.StructuredMessageHeader) &&
                message.Request.Headers.Contains(Constants.StructuredMessage.StructuredContentLength))
            {
                AssertStructuredMessageAcknowledgedPUT(message);
            }
            else if (message.Request.Headers.Contains(Constants.StructuredMessage.StructuredMessageHeader))
            {
                AssertStructuredMessageAcknowledgedGET(message);
            }
        }

        private static void AssertStructuredMessageAcknowledgedPUT(HttpMessage message)
        {
            if (!message.Response.IsError &&
                !message.Response.Headers.Contains(Constants.StructuredMessage.StructuredMessageHeader))
            {
                throw Errors.StructuredMessageNotAcknowledgedPUT(message.Response);
            }
        }

        private static void AssertStructuredMessageAcknowledgedGET(HttpMessage message)
        {
            if (!message.Response.IsError &&
                !(message.Response.Headers.Contains(Constants.StructuredMessage.StructuredMessageHeader) &&
                  message.Response.Headers.Contains(Constants.StructuredMessage.StructuredContentLength)))
            {
                throw Errors.StructuredMessageNotAcknowledgedGET(message.Response);
            }
        }
    }
}
