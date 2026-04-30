// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.TrafficManager.Models;

namespace Azure.ResourceManager.TrafficManager
{
    /// <summary>
    /// Wraps a generic ArmOperation to provide backward-compatible non-generic ArmOperation return type.
    /// </summary>
    internal class TrafficManagerNonGenericArmOperation : ArmOperation
    {
        private readonly TrafficManagerArmOperation<TrafficManagerDeleteOperationResult> _inner;

        internal TrafficManagerNonGenericArmOperation(TrafficManagerArmOperation<TrafficManagerDeleteOperationResult> inner)
        {
            _inner = inner;
        }

        public override string Id => _inner.Id;

        public override bool HasCompleted => _inner.HasCompleted;

        public override Response GetRawResponse() => _inner.GetRawResponse();

        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _inner.UpdateStatus(cancellationToken);

        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _inner.UpdateStatusAsync(cancellationToken);

        public override RehydrationToken? GetRehydrationToken() => _inner.GetRehydrationToken();
    }
}
