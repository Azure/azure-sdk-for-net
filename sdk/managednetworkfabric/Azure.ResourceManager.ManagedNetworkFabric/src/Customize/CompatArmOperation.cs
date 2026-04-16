// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    /// <summary>
    /// Wraps an <see cref="ArmOperation{TSource}"/> to present it as an <see cref="ArmOperation{TTarget}"/>
    /// by converting the result value. Used for backward-compatible method shims where the return type changed.
    /// </summary>
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
