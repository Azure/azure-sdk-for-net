// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    internal class RehydrationOperation : Operation
    {
        private readonly NextLinkOperationImplementation _nextLinkOperation;
        private readonly OperationInternal _operation;

        public RehydrationOperation(HttpPipeline pipeline, RehydrationToken? rehydrationToken, ClientOptions options = null)
        {
            AssertNotNull(pipeline, nameof(pipeline));
            AssertNotNull(rehydrationToken, nameof(rehydrationToken));
            _nextLinkOperation = (NextLinkOperationImplementation)NextLinkOperationImplementation.Create(pipeline, rehydrationToken);
            _operation = new OperationInternal(_nextLinkOperation, new ClientDiagnostics(options ?? ClientOptions.Default), null, requestMethod: _nextLinkOperation.RequestMethod);
        }

        public override string Id => _nextLinkOperation?.OperationId ?? null;

        public override RehydrationToken? GetRehydrationToken() => _nextLinkOperation?.GetRehydrationToken();

        public override bool HasCompleted => _operation.HasCompleted;

        public override Response GetRawResponse() => _operation.RawResponse;

        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operation.UpdateStatus(cancellationToken);

        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);

        private static void AssertNotNull<T>(T value, string name)
        {
            if (value is null)
            {
                throw new ArgumentNullException(name);
            }
        }
    }
}
