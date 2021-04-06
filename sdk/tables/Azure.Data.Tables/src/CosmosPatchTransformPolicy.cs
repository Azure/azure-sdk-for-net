// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Data.Tables
{
    /// <summary>
    /// HttpPipelinePolicy to sign requests using an Azure Storage shared key.
    /// </summary>
    internal sealed class CosmosPatchTransformPolicy : HttpPipelineSynchronousPolicy
    {
        /// <summary>
        /// Create a new <see cref="CosmosPatchTransformPolicy"/>.
        /// </summary>
        public CosmosPatchTransformPolicy()
        { }

        /// <summary>
        /// Sign the request using the shared key credentials.
        /// </summary>
        /// <param name="message">The message with the request to sign.</param>
        public override void OnSendingRequest(HttpMessage message)
        {
            base.OnSendingRequest(message);

            if (message.Request.Method == RequestMethod.Patch)
            {
                TransformPatchToCosmosPost(message);
            }
        }
        public static void TransformPatchToCosmosPost(HttpMessage message)
        {
            message.Request.Method = RequestMethod.Post;
            message.Request.Headers.SetValue("X-HTTP-Method", "MERGE");
        }
    }
}
