// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning;

/// <summary>
/// Represents a value or an expression accessed from an indexer property of <see cref="BicepList{T}"/>.
/// </summary>
/// <typeparam name="T">type of the value.</typeparam>
internal class BicepListIndexer<T> : BicepValue<T>
{
    internal BicepListIndexer(BicepValueReference? self, int index) : base(self)
    {
        Index = index;
    }

    internal BicepListIndexer(BicepValueReference? self, int index, T literal)
        : base(self, literal)
    {
        Index = index;
    }

    internal BicepListIndexer(BicepValueReference? self, int index, BicepExpression expression)
        : base(self, expression)
    {
        Index = index;
    }

    internal int Index { get; }

    private protected override BicepExpression CompileCore()
    {
        if (_kind == BicepValueKind.Unset)
        {
            throw new ArgumentOutOfRangeException(nameof(Index), $"Index '{Index}' is out of range on {_self?.GetReference(false)}.");
        }
        return base.CompileCore();
    }
}
