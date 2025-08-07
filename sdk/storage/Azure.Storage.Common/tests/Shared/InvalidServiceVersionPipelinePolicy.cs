// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Storage.Tests.Shared
{
    internal class InvalidServiceVersionPipelinePolicy : HttpPipelineSynchronousPolicy
    {
        public override void OnSendingRequest(HttpMessage message)
        {
            message.Request.Headers.Remove(Constants.HeaderNames.Version);
            message.Request.Headers.Add(new HttpHeader(Constants.HeaderNames.Version, "3025-05-06"));
        }
    }
}
