// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.Identity
{
    /// <summary>
    /// Restores the <c>Accept: application/json</c> request header on the operations that return
    /// 204 No Content.
    ///
    /// The AutoRest-generated client sent this header on every operation. The TypeSpec DPG emitter
    /// omits it where the response has no content, which is a wire difference observable by any
    /// proxy, gateway or log that keys on Accept, even though the service itself is indifferent.
    ///
    /// The header is only added when absent, so a value supplied by a caller-registered pipeline
    /// policy is never overwritten. Restoring a default must not remove the ability to override it.
    /// </summary>
    internal sealed class AcceptJsonPolicy : HttpPipelineSynchronousPolicy
    {
        internal static readonly AcceptJsonPolicy Shared = new AcceptJsonPolicy();

        private AcceptJsonPolicy()
        {
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            if (!message.Request.Headers.TryGetValue("Accept", out _))
            {
                message.Request.Headers.Add("Accept", "application/json");
            }
        }
    }
}
