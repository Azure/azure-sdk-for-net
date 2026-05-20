// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Providers;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Azure.Generator.Management.Visitors;

internal class CollectionResultNameVisitor : ScmLibraryVisitor
{
    // Keep generated CollectionResults file names below the repo path-length budget
    // even under long sdk\<service>\<package> prefixes.
    internal const int MaxCollectionResultNameLength = 80;
    private const int HashLength = 12;

    private static readonly string[] _collectionResultSuffixes =
    [
        "AsyncCollectionResultOfT",
        "CollectionResultOfT",
        "AsyncCollectionResult",
        "CollectionResult"
    ];

    protected override TypeProvider? VisitType(TypeProvider type)
    {
        if (type.CustomCodeView is null &&
            type.Name.Length > MaxCollectionResultNameLength &&
            TryGetCollectionResultSuffix(type.Name, out var suffix))
        {
            type.Update(name: BuildShortenedName(type.Name, suffix));
        }

        return type;
    }

    private static bool TryGetCollectionResultSuffix(string name, out string suffix)
    {
        foreach (var candidate in _collectionResultSuffixes)
        {
            if (name.EndsWith(candidate, StringComparison.Ordinal))
            {
                suffix = candidate;
                return true;
            }
        }

        suffix = string.Empty;
        return false;
    }

    private static string BuildShortenedName(string originalName, string suffix)
    {
        var hash = GetStableHash(originalName);
        var maxPrefixLength = MaxCollectionResultNameLength - suffix.Length - hash.Length;
        var prefixLength = Math.Min(originalName.Length - suffix.Length, maxPrefixLength);
        return $"{originalName[..prefixLength]}{hash}{suffix}";
    }

    private static string GetStableHash(string value)
    {
        var hash = SHA256.HashData(Encoding.UTF8.GetBytes(value));
        return Convert.ToHexString(hash, 0, HashLength / 2);
    }
}
