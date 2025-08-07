// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

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

        public RehydrationOperation(NextLinkOperationImplementation nextLinkOperation, OperationState operationState, ClientOptions? options = null)
        {
            _nextLinkOperation = nextLinkOperation;
            _operation = operationState.HasCompleted
                ? new OperationInternal(operationState)
                : new OperationInternal(nextLinkOperation, new ClientDiagnostics(options ?? ClientOptions.Default), operationState.RawResponse);
        }

        public override string Id => _nextLinkOperation.OperationId;

        public override RehydrationToken? GetRehydrationToken() => _nextLinkOperation?.GetRehydrationToken();

        public override bool HasCompleted => _operation.HasCompleted;

        public override Response GetRawResponse() => _operation.RawResponse;

        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operation.UpdateStatus(cancellationToken);

        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);
    }
}
