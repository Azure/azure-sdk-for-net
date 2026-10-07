// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.AI.Discovery
{
    // Create/update poller that terminates on provisioningState (not status) and
    // treats a synchronous completion (200, no Operation-Location) as success.
    internal class ProvisioningStateOperation : Operation<BinaryData>
    {
        private readonly KnowledgeBases _client;
        private readonly string _name;
        private readonly RequestContext _context;
        private Response _rawResponse;
        private BinaryData _value;
        private bool _completed;
        private bool _hasValue;

        public ProvisioningStateOperation(KnowledgeBases client, string name, Response initialResponse, RequestContext context)
        {
            _client = client;
            _name = name;
            _context = context;
            _rawResponse = initialResponse;

            bool hasOperationLocation =
                initialResponse.Headers.TryGetValue("Operation-Location", out _) ||
                initialResponse.Headers.TryGetValue("operation-location", out _);
            if (!hasOperationLocation)
            {
                // Synchronous completion: no long-running operation to poll.
                _completed = true;
                _value = initialResponse.Content;
                _hasValue = _value != null;
            }
            else
            {
                Evaluate(initialResponse, throwOnFailure: false);
            }
        }

        public override BinaryData Value =>
            _hasValue ? _value : throw new InvalidOperationException("The operation has not completed successfully.");

        public override bool HasValue => _hasValue;

        public override string Id => _name;

        public override bool HasCompleted => _completed;

        public override Response GetRawResponse() => _rawResponse;

        public override Response UpdateStatus(CancellationToken cancellationToken = default)
        {
            if (_completed)
            {
                return _rawResponse;
            }
            _rawResponse = _client.GetForPolling(_name, _context, cancellationToken);
            Evaluate(_rawResponse, throwOnFailure: true);
            return _rawResponse;
        }

        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            if (_completed)
            {
                return _rawResponse;
            }
            _rawResponse = await _client.GetForPollingAsync(_name, _context, cancellationToken).ConfigureAwait(false);
            Evaluate(_rawResponse, throwOnFailure: true);
            return _rawResponse;
        }

        private void Evaluate(Response response, bool throwOnFailure)
        {
            string state = KnowledgeBases.ReadProvisioningState(response);
            if (state == null)
            {
                return;
            }
            if (state.Equals("Succeeded", StringComparison.OrdinalIgnoreCase))
            {
                _completed = true;
                _value = response.Content;
                _hasValue = _value != null;
            }
            else if (state.Equals("Failed", StringComparison.OrdinalIgnoreCase) ||
                     state.Equals("Canceled", StringComparison.OrdinalIgnoreCase))
            {
                _completed = true;
                if (throwOnFailure)
                {
                    throw new RequestFailedException(response);
                }
            }
        }
    }
}
