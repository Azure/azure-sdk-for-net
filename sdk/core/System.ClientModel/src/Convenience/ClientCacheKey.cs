// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;
using System;
using System.ClientModel.Primitives;

internal sealed class ClientCacheKey : IEquatable<ClientCacheKey>
{
    public Type Type { get; }
    public string Id { get; }
    public ClientPipelineOptions? Options { get; }

    public ClientCacheKey(Type type, string id, ClientPipelineOptions? options)
    {
        Type = type;
        Id = id;
        Options = options;
    }

    public override bool Equals(object? obj)
        => Equals(obj as ClientCacheKey);

    public bool Equals(ClientCacheKey? other)
    {
        if (other is null)
            return false;

        return Type == other.Type &&
               Id == other.Id &&
               ReferenceEquals(Options, other.Options); // Reference equality
    }

    public override int GetHashCode()
    {
        int h1 = Type?.GetHashCode() ?? 0;
        int h2 = Id?.GetHashCode() ?? 0;
        int h3 = RuntimeHelpers.GetHashCode(Options); // Reference-based hash

        return CombineHashCodes(h1, h2, h3);
    }

    private static int CombineHashCodes(int h1, int h2, int h3)
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 31 + h1;
            hash = hash * 31 + h2;
            hash = hash * 31 + h3;
            return hash;
        }
    }
}
