// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;

namespace System.ClientModel.Primitives;

/// <summary>
/// Process-wide cache of resolved <see cref="AuthenticationTokenProvider"/>
/// instances keyed by a hash of the merged credential section content. Two
/// callers with identical effective config share one provider so token-layer
/// caches inside the provider are also shared.
/// </summary>
[Experimental("SCME0002")]
internal static class CredentialCache
{
    private static readonly ConcurrentDictionary<string, AuthenticationTokenProvider> s_cache = new();

    public static AuthenticationTokenProvider? GetOrAdd(
        IConfigurationSection mergedSection,
        Func<IConfigurationSection, AuthenticationTokenProvider?> factory)
    {
        string key = CredentialSectionHasher.ComputeKey(mergedSection);
        if (key.Length == 0)
        {
            return factory(mergedSection);
        }

        if (s_cache.TryGetValue(key, out AuthenticationTokenProvider? existing))
        {
            return existing;
        }

        AuthenticationTokenProvider? created = factory(mergedSection);
        if (created is null)
        {
            return null;
        }

        return s_cache.GetOrAdd(key, created);
    }
}
