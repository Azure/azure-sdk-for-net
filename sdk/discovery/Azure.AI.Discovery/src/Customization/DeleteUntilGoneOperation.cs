// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.AI.Discovery
{
    // Delete poller that ignores the broken operation-status monitor and instead
    // polls the KnowledgeBase resource, treating a 404 (resource gone) as success.
    internal class DeleteUntilGoneOperation : Operation
    {
        private readonly KnowledgeBases _client;
        private readonly string _name;
        private readonly RequestContext _context;
        private Response _rawResponse;
        private bool _completed;

        public DeleteUntilGoneOperation(KnowledgeBases client, string name, Response initialResponse, RequestContext context)
        {
            _client = client;
            _name = name;
            _context = context;
            _rawResponse = initialResponse;
        }

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
            if (_rawResponse.Status == 404)
            {
                _completed = true;
            }
            return _rawResponse;
        }

        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            if (_completed)
            {
                return _rawResponse;
            }
            _rawResponse = await _client.GetForPollingAsync(_name, _context, cancellationToken).ConfigureAwait(false);
            if (_rawResponse.Status == 404)
            {
                _completed = true;
            }
            return _rawResponse;
        }
    }
}
