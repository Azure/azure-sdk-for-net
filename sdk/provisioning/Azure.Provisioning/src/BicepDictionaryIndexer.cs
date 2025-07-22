// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
    internal BicepDictionaryIndexer(BicepValueReference? self, string key) : base(self)
    {
        Key = key;
    }

    internal BicepDictionaryIndexer(BicepValueReference? self, string key, T literal)
        : base(self, literal)
    {
        Key = key;
    }

    internal BicepDictionaryIndexer(BicepValueReference? self, string key, BicepExpression expression)
        : base(self, expression)
    {
        Key = key;
    }

    internal string Key { get; }

    public override BicepExpression Compile()
    {
        if (_kind == BicepValueKind.Unset)
        {
            throw new KeyNotFoundException($"Key '{Key}' is out of range on {_self?.GetReference(false)}.");
        }
        return base.Compile();
    }
}
