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
/// secrets) cannot leak its provider into another caller's chain. Inline
/// credential sections that no resolver claims are cached under a single
/// section-only key, so the inline-ApiKey path benefits from caching too.
/// </summary>
[Experimental("SCME0002")]
internal static class CredentialCache
{
    private const string InlineKeySuffix = "::inline";

    private static readonly ConcurrentDictionary<string, CredentialSettings> s_cache = new();

    /// <summary>
    /// Look up a cached <see cref="CredentialSettings"/> for
    /// (<paramref name="mergedSection"/>, <paramref name="resolver"/>); on
    /// miss, call <see cref="CredentialResolver.TryResolve"/>. If the
    /// resolver matches and produces a non-null, non-disposable provider,
    /// build and cache a <see cref="CredentialSettings"/> for it. Returns
    /// <see langword="null"/> when the resolver does not match (the no-match
    /// case is handled by <see cref="GetOrCreateInline"/>).
    /// </summary>
    public static CredentialSettings? GetOrTryResolve(
        IConfigurationSection mergedSection,
        CredentialResolver resolver)
    {
        string sectionKey = CredentialSectionHasher.ComputeKey(mergedSection);
        if (sectionKey.Length == 0)
        {
            // ComputeKey returns the empty string only for a null section.
            // The engine guards against this before reaching the cache, but if
            // some future caller bypasses the engine and passes null we have
            // no meaningful cache key and no resolver could produce a useful
            // provider from a null section. Return null instead of invoking
            // the resolver.
            return null;
        }

        // Reference-identity hash bypasses any user GetHashCode override on
        // the resolver and gives a stable identifier for the lifetime of the
        // resolver object.
        string key = sectionKey + "::" + RuntimeHelpers.GetHashCode(resolver).ToString(Globalization.CultureInfo.InvariantCulture);

        if (s_cache.TryGetValue(key, out CredentialSettings? existing))
        {
            return existing;
        }

        if (!resolver.TryResolve(mergedSection, out AuthenticationTokenProvider? provider) || provider is null)
        {
            return null;
        }

        CredentialSettings created = new(mergedSection)
        {
            CredentialProvider = provider,
        };

        // Defensive: if the produced provider owns disposable resources, do not
        // cache the settings. A cached IDisposable provider could be disposed
        // by one consumer (e.g., a DI host shutting down) and then handed out
        // to another consumer from the cache, producing ObjectDisposedException.
        // The cost is losing token-cache sharing for disposable providers,
        // which in practice is rare (TokenCredential / AuthenticationTokenProvider
        // base contracts are not IDisposable).
        if (provider is IDisposable || provider is IAsyncDisposable)
        {
            return created;
        }

        return s_cache.GetOrAdd(key, created);
    }

    /// <summary>
    /// Returns a cached <see cref="CredentialSettings"/> for the inline
    /// credential data in <paramref name="mergedSection"/> — the no-resolver
    /// match path. The settings has <see cref="CredentialSettings.CredentialProvider"/>
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
