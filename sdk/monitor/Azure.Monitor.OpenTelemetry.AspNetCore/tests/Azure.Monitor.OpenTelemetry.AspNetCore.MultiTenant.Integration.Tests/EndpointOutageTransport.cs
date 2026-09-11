// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;

#if NET
namespace Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests
{
    internal sealed class EndpointOutageTransport : HttpPipelineTransport
    {
        private readonly HttpPipelineTransport _inner;
        private readonly Uri? _unavailableEndpoint;
        private int _recovered;
        private int _failedRequests;

        internal EndpointOutageTransport(HttpPipelineTransport inner, Uri? unavailableEndpoint)
        {
            _inner = inner;
            _unavailableEndpoint = unavailableEndpoint;
        }

        internal int FailedRequests => Volatile.Read(ref _failedRequests);

        internal void Recover() => Volatile.Write(ref _recovered, 1);

        public override Request CreateRequest() => _inner.CreateRequest();

        public override void Process(HttpMessage message)
        {
            if (!TryFail(message))
            {
                _inner.Process(message);
            }
        }

        public override ValueTask ProcessAsync(HttpMessage message)
            => TryFail(message) ? default : _inner.ProcessAsync(message);

        private bool TryFail(HttpMessage message)
        {
            if (Volatile.Read(ref _recovered) != 0 || _unavailableEndpoint == null
                || !string.Equals(message.Request.Uri.ToUri().GetLeftPart(UriPartial.Authority), _unavailableEndpoint.GetLeftPart(UriPartial.Authority), StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            Interlocked.Increment(ref _failedRequests);
            message.Response = new MockResponse(503).WithHeader("Retry-After", "0");
            return true;
        }
    }
}
#endif