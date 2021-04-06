// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Data.Tables
{
    /// <summary>
    /// HttpPipelinePolicy to transform PATCH requests into POST requests with the "X-HTTP-Method":"MERGE" header set.
    /// </summary>
    internal sealed class CosmosPatchTransformPolicy : HttpPipelineSynchronousPolicy
    {
        /// <summary>
        /// Create a new <see cref="CosmosPatchTransformPolicy"/>.
        /// </summary>
        public CosmosPatchTransformPolicy()
        { }

        /// <summary>
        /// Do the transform, if necessary.
        /// </summary>
        /// <param name="message">The message with the request to transform.</param>
        public override void OnSendingRequest(HttpMessage message)
        {
            base.OnSendingRequest(message);

            if (message.Request.Method == RequestMethod.Patch)
            {
                TransformPatchToCosmosPost(message);
            }
        }

        /// <summary>
        /// Transform a PATCH request into POST request with the "X-HTTP-Method":"MERGE" header set.
        /// </summary>
        /// <param name="message"></param>
        public static void TransformPatchToCosmosPost(HttpMessage message)
        {
            message.Request.Method = RequestMethod.Post;
            message.Request.Headers.SetValue("X-HTTP-Method", "MERGE");
        }
    }
}
