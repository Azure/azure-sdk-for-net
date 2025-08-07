// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;

namespace Azure.Storage.Test.Shared
{
    internal class CaptureMessageContentsPolicy : HttpPipelineSynchronousPolicy
    {
        private readonly HashSet<CaptureMessageScope> _scopes = new();

        public List<HttpMessage> Messages { get; } = new();

        public IDisposable CaptureScope() => new CaptureMessageScope(this);

        public override void OnReceivedResponse(HttpMessage message)
        {
            if (_scopes.Count == 0)
            {
                return;
            }

            MockRequest requestCopy = new()
            {
                Uri = message.Request.Uri,
                Method = message.Request.Method,
                ClientRequestId = message.Request.ClientRequestId,
            };
            foreach (HttpHeader header in message.Request.Headers)
            {
                requestCopy.Headers.Add(header);
            }

            MockResponse responseCopy = new(message.Response.Status, message.Response.ReasonPhrase)
            {
                ClientRequestId = message.Response.ClientRequestId,
            };
            foreach (HttpHeader header in message.Response.Headers)
            {
                responseCopy.AddHeader(header);
            }

            Messages.Add(new HttpMessage(requestCopy, null)
            {
                Response = responseCopy,
            });
        }

        private class CaptureMessageScope : IDisposable
        {
            private readonly CaptureMessageContentsPolicy _policy;

            public CaptureMessageScope(CaptureMessageContentsPolicy policy)
            {
                _policy = policy;
                _policy._scopes.Add(this);
            }

            public void Dispose()
            {
                _policy._scopes.Remove(this);
            }
        }
    }
}
