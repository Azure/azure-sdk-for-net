// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
#if NETFRAMEWORK
    /// <summary>
    /// The <see cref="HttpWebRequest"/> based <see cref="HttpPipelineTransport"/> implementation.
    /// </summary>
    internal partial class HttpWebRequestTransport : HttpPipelineTransport
    {
        private class AzureCoreHttpWebRequestTransport : PipelineTransport
        {
            private readonly HttpWebRequestTransport _transport;

            public AzureCoreHttpWebRequestTransport(HttpWebRequestTransport transport)
            {
                _transport = transport;
            }

            protected override PipelineMessage CreateMessageCore()
            {
                Request request = _transport.CreateRequest();
                return new HttpMessage(request, ResponseClassifier.Shared);
            }

            protected override void ProcessCore(PipelineMessage message)
            {
                HttpMessage httpMessage = AssertHttpMessage(message);
                _transport.ProcessSyncOrAsync(httpMessage, async: false).EnsureCompleted();
            }

            protected override async ValueTask ProcessCoreAsync(PipelineMessage message)
            {
                HttpMessage httpMessage = AssertHttpMessage(message);
                await _transport.ProcessSyncOrAsync(httpMessage, async: true).ConfigureAwait(false);
            }

            private static HttpMessage AssertHttpMessage(PipelineMessage message)
            {
                if (message is not HttpMessage httpMessage)
                {
                    throw new InvalidOperationException($"Invalid type for PipelineMessage: '{message?.GetType()}'.");
                }

                return httpMessage;
            }
        }
    }
#endif
}
