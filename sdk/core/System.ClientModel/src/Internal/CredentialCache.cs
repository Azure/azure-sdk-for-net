// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;

namespace System.ClientModel.Primitives;

/// <summary>
/// Process-wide cache of resolved <see cref="CredentialSettings"/> instances
/// keyed by a hash of the merged credential section content. Resolver-matched
/// entries are additionally keyed by the reference-identity hash of the
/// resolver instance that produced the provider, so two callers with
/// identical effective config that share a resolver instance also share one
/// settings instance (and the token-layer cache inside the provider).
/// Distinct resolver instances (even of the same type) get distinct cache
/// entries — a custom resolver carrying instance state (e.g., per-host
/// secrets) cannot leak its provider into another caller's chain.
/// Chain-owning resolvers — identified by invoking
/// <c>resolveChild</c> during <c>TryResolve</c> — are NOT cached; each
/// resolution builds a fresh wrapper that composes cached leaf providers via
/// <c>resolveChild</c>, so the token-layer cache lives on the leaves where
/// it belongs and a chain wrapper cannot leak its captured chain across
/// callers. Inline credential sections that no resolver claims are cached
/// under a single section-only key, so the inline-ApiKey path benefits from
/// caching too.
/// </summary>
[Experimental("SCME0002")]
internal static class CredentialCache
{
    private const string InlineKeySuffix = "::inline";

    private static readonly ConcurrentDictionary<string, CredentialSettings> s_cache = new();

    /// <summary>
    /// Look up a cached <see cref="CredentialSettings"/> for
    /// (<paramref name="mergedSection"/>, <paramref name="resolver"/>); on
    /// miss, call <see cref="CredentialResolver.TryResolve(IConfigurationSection, Func{IConfigurationSection, AuthenticationTokenProvider?}, out AuthenticationTokenProvider?)"/>.
    /// If the resolver matches and produces a non-null, non-disposable provider,
    /// build a <see cref="CredentialSettings"/> for it. Cache the result only
    /// if the resolver did NOT invoke <paramref name="resolveChild"/> (i.e.,
    /// is not a chain owner); otherwise return the freshly built settings
    /// without caching so each resolution gets a wrapper bound to its own
    /// active chain. Returns <see langword="null"/> when the resolver does
    /// not match (the no-match case is handled by
    /// <see cref="GetOrCreateInline"/>).
    /// </summary>
    /// <param name="mergedSection">The credential section to resolve (already
    /// merged with any overrides).</param>
    /// <param name="resolver">The resolver to invoke on cache miss.</param>
    /// <param name="resolveChild">A callback that recursively resolves child
    /// sections through the active engine. Passed (wrapped with a usage
    /// tracker) to the chain-aware
    /// <see cref="CredentialResolver.TryResolve(IConfigurationSection, Func{IConfigurationSection, AuthenticationTokenProvider?}, out AuthenticationTokenProvider?)"/>
    /// overload so chain-owning resolvers can recurse without re-implementing
    /// engine logic. Invoking it during <c>TryResolve</c> opts the resolver
    /// out of caching. Required — callers without a chain pass a no-op
    /// (<c><![CDATA[static _ => null]]></c>) to honor the resolver's non-null
    /// contract.</param>
    public static CredentialSettings? GetOrTryResolve(
        IConfigurationSection mergedSection,
        CredentialResolver resolver,
        Func<IConfigurationSection, AuthenticationTokenProvider?> resolveChild)
    {
        string sectionKey = CredentialSectionHasher.ComputeKey(mergedSection);
        if (sectionKey.Length == 0)
        {
            return null;
        }

        // RuntimeHelpers.GetHashCode bypasses user GetHashCode overrides.
        string cacheKey = sectionKey + "::" + RuntimeHelpers.GetHashCode(resolver).ToString(Globalization.CultureInfo.InvariantCulture);

        if (s_cache.TryGetValue(cacheKey, out CredentialSettings? existing))
        {
            return existing;
        }

        // Chain owners — resolvers that invoke resolveChild during TryResolve —
        // are not cached because their output depends on the active chain.
        bool isChainOwner = false;
        Func<IConfigurationSection, AuthenticationTokenProvider?> trackedResolveChild = section =>
        {
            isChainOwner = true;
            return resolveChild(section);
        };

        if (!resolver.TryResolve(mergedSection, trackedResolveChild, out AuthenticationTokenProvider? provider) || provider is null)
        {
            return null;
        }

        CredentialSettings created = new(mergedSection)
        {
            TokenProvider = provider,
        };

        // Disposable providers aren't cached: a consumer disposing one would
        // poison later cache hits with ObjectDisposedException.
        if (provider is IDisposable || provider is IAsyncDisposable)
        {
            return created;
        }

        if (isChainOwner)
        {
            return created;
        }

        return s_cache.GetOrAdd(cacheKey, created);
    }

    /// <summary>
    /// Returns a cached <see cref="CredentialSettings"/> for the inline
    /// credential data in <paramref name="mergedSection"/> — the no-resolver
    /// match path. The settings has <see cref="CredentialSettings.TokenProvider"/>
    /// set to <see langword="null"/> and exposes the section's bound
    /// metadata (<c>Key</c>, <c>CredentialSource</c>, <c>AdditionalProperties</c>,
    /// indexer). Repeated calls for the same section content return the same
    /// instance.
    /// </summary>
    public static CredentialSettings GetOrCreateInline(IConfigurationSection mergedSection)
    {
        string sectionKey = CredentialSectionHasher.ComputeKey(mergedSection);
        if (sectionKey.Length == 0)
        {
            // No meaningful cache key — fall back to a one-shot instance.
            return new CredentialSettings(mergedSection);
        }

        return s_cache.GetOrAdd(sectionKey + InlineKeySuffix, _ => new CredentialSettings(mergedSection));
    }
}
