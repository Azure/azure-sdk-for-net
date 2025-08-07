// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning;

/// <summary>
/// Represents a value or an expression accessed from an indexer property of <see cref="BicepDictionary{T}"/>.
/// </summary>
/// <typeparam name="T">type of the value.</typeparam>
internal class BicepDictionaryIndexer<T> : BicepValue<T>
{
    private readonly string _key;

    internal BicepDictionaryIndexer(BicepValueReference? self, string key) : base(self)
    {
        _key = key;
    }

    internal BicepDictionaryIndexer(BicepValueReference? self, string key, T literal)
        : base(self, literal)
    {
        _key = key;
    }

    internal BicepDictionaryIndexer(BicepValueReference? self, string key, BicepExpression expression)
        : base(self, expression)
    {
        _key = key;
    }

    private protected override BicepExpression CompileCore()
    {
        if (_kind == BicepValueKind.Unset)
        {
            throw new KeyNotFoundException($"Key '{_key}' is out of range on {_self?.GetReference(false)}.");
        }
        return base.CompileCore();
    }

    private protected override BicepExpression ToBicepExpressionCore()
    {
        return BicepSyntax.Index(_self!.GetReference(), _key);
    }
}
