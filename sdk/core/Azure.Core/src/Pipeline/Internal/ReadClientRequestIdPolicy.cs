// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;

namespace Azure.Core.Pipeline
{
    internal class ReadClientRequestIdPolicy : HttpPipelineSynchronousPolicy
    {
        private static readonly AsyncLocal<ClientRequestIdScope?> CurrentRequestIdScope = new AsyncLocal<ClientRequestIdScope?>();

        protected ReadClientRequestIdPolicy()
        {
        }

        public static ReadClientRequestIdPolicy Shared { get; } = new ReadClientRequestIdPolicy();

        public override void OnSendingRequest(HttpMessage message)
        {
            if (message.Request.Headers.TryGetValue(ClientRequestIdPolicy.ClientRequestIdHeader, out string? value))
            {
                message.Request.ClientRequestId = value;
            }
            else if (CurrentRequestIdScope.Value?.ClientRequestId != null)
            {
                message.Request.ClientRequestId = CurrentRequestIdScope.Value.ClientRequestId;
            }
        }

        internal static IDisposable StartScope(string? clientRequestId)
        {
            CurrentRequestIdScope.Value = new ClientRequestIdScope(clientRequestId, CurrentRequestIdScope.Value);

            return CurrentRequestIdScope.Value;
        }

        private class ClientRequestIdScope: IDisposable
        {
            private readonly ClientRequestIdScope? _parent;

            internal ClientRequestIdScope(string? clientRequestId, ClientRequestIdScope? parent)
            {
                ClientRequestId = clientRequestId;
                _parent = parent;
            }

            public string? ClientRequestId { get; }

            public void Dispose()
            {
                CurrentRequestIdScope.Value = _parent;
            }
        }
    }
}