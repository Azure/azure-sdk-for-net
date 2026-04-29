// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;

namespace System.ClientModel.Primitives;

/// <summary>
/// Process-wide cache of resolved <see cref="AuthenticationTokenProvider"/>
/// instances keyed by a hash of the merged credential section content combined
/// with the reference-identity hash of the resolver instance that produced
/// the provider. Two callers with identical effective config that have the
/// same resolver instance win for that section share one provider, so the
/// token-layer cache inside the provider is also shared. Distinct resolver
/// instances (even of the same type) get distinct cache entries — so a
/// custom resolver carrying instance state (e.g., per-host secrets) cannot
/// leak its provider into another caller's chain.
/// </summary>
[Experimental("SCME0002")]
internal static class CredentialCache
{
    private static readonly ConcurrentDictionary<string, AuthenticationTokenProvider> s_cache = new();

    /// <summary>
    /// Look up a cached provider for (<paramref name="mergedSection"/>, <paramref name="resolver"/>);
    /// if absent, invoke <paramref name="factory"/> and (when the result is
    /// non-null and non-disposable) cache it under that key.
    /// </summary>
    public static AuthenticationTokenProvider? GetOrTryCreate(
        IConfigurationSection mergedSection,
        CredentialResolver resolver,
        Func<IConfigurationSection, CredentialResolver, AuthenticationTokenProvider?> factory)
    {
        string sectionKey = CredentialSectionHasher.ComputeKey(mergedSection);
        if (sectionKey.Length == 0)
        {
            return factory(mergedSection, resolver);
        }

        // Reference-identity hash bypasses any user GetHashCode override on
        // the resolver and gives a stable identifier for the lifetime of the
        // resolver object.
        string key = sectionKey + "::" + RuntimeHelpers.GetHashCode(resolver).ToString(Globalization.CultureInfo.InvariantCulture);

        if (s_cache.TryGetValue(key, out AuthenticationTokenProvider? existing))
        {
            return existing;
        }

        AuthenticationTokenProvider? created = factory(mergedSection, resolver);
        if (created is null)
        {
            return null;
        }

        // Defensive: if the produced provider owns disposable resources, do not
        // cache it. A cached IDisposable provider could be disposed by one
        // consumer (e.g., a DI host shutting down) and then handed out to
        // another consumer from the cache, producing ObjectDisposedException.
        // The cost is losing token-cache sharing for disposable providers,
        // which in practice is rare (TokenCredential / AuthenticationTokenProvider
        // base contracts are not IDisposable).
        if (created is IDisposable || created is IAsyncDisposable)
        {
            return created;
        }

        return s_cache.GetOrAdd(key, created);
    }
}
