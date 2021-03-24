// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Pipeline
{
    internal class ReadClientRequestIdPolicy : RequestScopePolicy
    {
        private ReadClientRequestIdPolicy()
        {
        }

        public static ReadClientRequestIdPolicy Shared { get; } = new ReadClientRequestIdPolicy();

        internal static IDisposable StartScope(string? clientRequestId)
        {
            return Shared.StartScope(message =>
            {
                if (message.Request.Headers.TryGetValue(ClientRequestIdPolicy.ClientRequestIdHeader, out string? value))
                {
                    message.Request.ClientRequestId = value;
                }
                else if (clientRequestId != null)
                {
                    message.Request.ClientRequestId = clientRequestId;
                }
            });
        }
    }
}
