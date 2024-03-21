// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core;

namespace Azure.ResourceManager
{
    internal class RehydrationOperation : ArmOperation
    {
        private readonly NextLinkOperationImplementation _nextLinkOperation;
        private readonly OperationInternal _operation;

        public RehydrationOperation(ArmClient client, RehydrationToken? rehydrationToken, ClientOptions options = null)
        {
            AssertNotNull(client, nameof(client));
            AssertNotNull(rehydrationToken, nameof(rehydrationToken));
            _nextLinkOperation = (NextLinkOperationImplementation)NextLinkOperationImplementation.Create(client.Pipeline, rehydrationToken);
            var operationState = _nextLinkOperation.UpdateStateAsync(false, default).EnsureCompleted();
            _operation = operationState.HasCompleted
                ? _operation = new OperationInternal(operationState)
                : new OperationInternal(_nextLinkOperation, new ClientDiagnostics(options ?? ClientOptions.Default), operationState.RawResponse, requestMethod: _nextLinkOperation.RequestMethod);
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
