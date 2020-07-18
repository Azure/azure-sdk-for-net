// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Data.Tables
{
    /// <summary>
    /// HttpPipelinePolicy to add an Accept header to deal with service inconsistencies between Cosmos and Storage endpoints.
    /// https://github.com/Azure/azure-sdk-for-net/issues/13559
    /// </summary>
    internal sealed class TableAcceptHeaderPipelinePolicy : HttpPipelineSynchronousPolicy
    {
        /// <summary>
        /// Add Accept headers.
        /// </summary>
        /// <param name="message">The message.</param>
        public override void OnSendingRequest(HttpMessage message)
        {
            base.OnSendingRequest(message);

            // Both storage and cosmos can be inconsistent about requiring an Accept header, so add one here for all requests
            if (message.Request.Headers.TryGetValue(TableConstants.HeaderNames.Content, out var contentType))
            {
                switch (contentType)
                {
                    case TableConstants.MimeType.ApplicationXml:
                        message.Request.Headers.SetValue(TableConstants.HeaderNames.Accept, TableConstants.MimeType.ApplicationXml);
                        break;
                    default:
                        message.Request.Headers.SetValue(TableConstants.HeaderNames.Accept, TableConstants.MimeType.ApplicationJson);
                        break;
                }
            }
            else if (!message.Request.Uri.Query.Contains("comp="))
            {
                // The default Accept header should be application/json, however all requests using the comp= query string are application/xml
                // These requests don't always set a Content-Type header as a clue for the logic above.
                message.Request.Headers.SetValue(TableConstants.HeaderNames.Accept, TableConstants.MimeType.ApplicationJson);
            }
        }
    }
}
