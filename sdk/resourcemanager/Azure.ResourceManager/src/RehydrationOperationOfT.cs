// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager
{
#pragma warning disable SA1649 // File name should match first type name
    internal class RehydrationOperation<T> : ArmOperation<T> where T : notnull
#pragma warning restore SA1649 // File name should match first type name
    {
        private readonly OperationInternal<T> _operation;
        private readonly NextLinkOperationImplementation _nextLinkOperation;

        public RehydrationOperation(NextLinkOperationImplementation nextLinkOperation, OperationState<T> operationState, IOperation<T> operation, ClientOptions? options = null)
        {
            _nextLinkOperation = nextLinkOperation;
            _operation = operationState.HasCompleted
                    ? new OperationInternal<T>(operationState)
                    : new OperationInternal<T>(operation, new ClientDiagnostics(options ?? ClientOptions.Default), operationState.RawResponse);
        }

        public override T Value => _operation.Value;

        public override bool HasValue => _operation.HasValue;

        public override string Id => _nextLinkOperation.OperationId;

        public override bool HasCompleted => _operation.HasCompleted;

        public override Response GetRawResponse() => _operation.RawResponse;

        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operation.UpdateStatus(cancellationToken);

        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);
    }
}
