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
    private readonly int _index;
    internal BicepListIndexer(BicepValueReference? self, int index) : base(self)
    {
        _index = index;
    }

    internal BicepListIndexer(BicepValueReference? self, int index, T literal)
        : base(self, literal)
    {
        _index = index;
    }

    internal BicepListIndexer(BicepValueReference? self, int index, BicepExpression expression)
        : base(self, expression)
    {
        _index = index;
    }

    private protected override BicepExpression CompileCore()
    {
        if (_kind == BicepValueKind.Unset)
        {
            throw new ArgumentOutOfRangeException(nameof(_index), $"Index '{_index}' is out of range on {_self?.GetReference(false)}.");
        }
        return base.CompileCore();
    }

    private protected override BicepExpression ToBicepExpressionCore()
    {
        return BicepSyntax.Index(_self!.GetReference(), new IntLiteralExpression(_index));
    }
}
