// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core
{
#pragma warning disable SA1649 // File name should match first type name
    internal class RehydrationOperation<T> : Operation<T> where T : IPersistableModel<T>
#pragma warning restore SA1649 // File name should match first type name
    {
        private readonly OperationInternal<T> _operation;
        private readonly NextLinkOperationImplementation _nextLinkOperation;

        public RehydrationOperation(HttpPipeline pipeline, RehydrationToken? rehydrationToken, ClientOptions options = null)
        {
            if (pipeline is null)
            {
                throw new ArgumentNullException(nameof(pipeline));
            }

            if (rehydrationToken is null)
            {
                throw new ArgumentNullException(nameof(rehydrationToken));
            }

            IOperationSource<T> source = new GenericOperationSource<T>();
            _nextLinkOperation = (NextLinkOperationImplementation)NextLinkOperationImplementation.Create(pipeline, rehydrationToken);
            var operation = NextLinkOperationImplementation.Create(source, _nextLinkOperation);
            var clientDiagnostics = new ClientDiagnostics(options ?? ClientOptions.Default);
            _operation = new OperationInternal<T>(operation, clientDiagnostics, null);
        }

        public override T Value => _operation.Value;

        public override bool HasValue => _operation.HasValue;

        public override string Id => _nextLinkOperation.OperationId ?? null;

        public override RehydrationToken? GetRehydrationToken() => _nextLinkOperation?.GetRehydrationToken();

        public override bool HasCompleted => _operation.HasCompleted;

        public override Response GetRawResponse() => _operation.RawResponse;

        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operation.UpdateStatus(cancellationToken);

        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);
    }
}
