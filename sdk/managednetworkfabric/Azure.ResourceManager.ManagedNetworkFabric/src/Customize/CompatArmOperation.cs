// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    // Backward compatibility adapter for the swagger upgrade from package-2023-06-15 to package-2025-07-15.
    // The new API version changed the return types of resource action operations from generic result types
    // (e.g. StateUpdateCommonPostActionResult) to operation-specific result types. This adapter enables
    // the old method signatures to delegate to the new generated methods while converting the result back.
    internal sealed class CompatArmOperation<TSource, TTarget> : ArmOperation<TTarget>
    {
        private readonly ArmOperation<TSource> _inner;
        private readonly Func<TSource, TTarget> _converter;

        internal CompatArmOperation(ArmOperation<TSource> inner, Func<TSource, TTarget> converter)
        {
            _inner = inner ?? throw new ArgumentNullException(nameof(inner));
            _converter = converter ?? throw new ArgumentNullException(nameof(converter));
        }

        public override bool HasCompleted => _inner.HasCompleted;
        public override bool HasValue => _inner.HasValue;
        public override string Id => _inner.Id;
        public override TTarget Value => _converter(_inner.Value);
        public override Response GetRawResponse() => _inner.GetRawResponse();
        public override RehydrationToken? GetRehydrationToken() => _inner.GetRehydrationToken();
        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _inner.UpdateStatus(cancellationToken);
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _inner.UpdateStatusAsync(cancellationToken);
    }
}
