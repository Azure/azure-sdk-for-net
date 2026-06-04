// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace System.ClientModel.Primitives;

/// <summary>
/// Internal core resolution logic shared by the public
/// <c>GetCredentialSettings</c> overloads, <c>GetClientSettings&lt;T&gt;</c>
/// overloads, and the DI <c>AddClient</c> auto-resolve hook.
/// </summary>
[Experimental("SCME0002")]
internal static class CredentialResolverEngine
{
    /// <summary>
    /// Walks the supplied <see cref="CredentialResolver"/> chain (after
    /// optionally applying <paramref name="configureOverrides"/> to a
    /// writable overlay of <paramref name="credentialSection"/>) and returns
    /// a cached <see cref="CredentialSettings"/> bound to the section the
    /// chain saw, with <see cref="CredentialSettings.TokenProvider"/>
    /// populated when a resolver matches. When no resolver matches, returns
    /// the cached inline-only settings for that section. Returns
    /// <see langword="null"/> only when the section does not exist. The
    /// returned instance is shared across callers — treat it as read-only.
    /// </summary>
    public static CredentialSettings? Resolve(
        IConfigurationSection credentialSection,
        IEnumerable<CredentialResolver>? resolvers,
        Action<IConfigurationSection>? configureOverrides)
    {
        if (credentialSection is null || !credentialSection.Exists())
        {
            return null;
        }

        IConfigurationSection workingSection = credentialSection;
        if (configureOverrides is not null)
        {
            IConfigurationSection mutable = CredentialSectionOverlay.CreateOverlay(credentialSection);
            workingSection = credentialSection is ReferenceConfigurationSection refSection
                ? new ReferenceConfigurationSection(refSection.Configuration, mutable)
                : mutable;
            configureOverrides(workingSection);
        }

        // Materialize the resolver chain once at the top of every Resolve
        // call. The recursive resolveChild callback below re-enters this
        // method with the same enumerable, so a non-reentrant /
        // single-use IEnumerable (e.g., a custom iterator that throws on
        // second GetEnumerator) would blow up when the outer foreach has
        // already started walking it. Pass the materialized list through
        // the recursion so every layer sees the same snapshot.
        IReadOnlyList<CredentialResolver> resolverList = resolvers switch
        {
            null => Array.Empty<CredentialResolver>(),
            IReadOnlyList<CredentialResolver> list => list,
            _ => resolvers.ToArray()
        };

        // Build the recursive callback once per Resolve invocation. Resolvers
        // that override the chain-aware TryResolve overload (e.g., a chain-
        // owning resolver that walks Sources[]) can invoke this to resolve a
        // child IConfigurationSection through the same active resolver chain.
        // The callback re-enters this engine method with the materialized
        // resolver list and no overrides — overrides only apply to the
        // top-level section the caller passed in.
        //
        // Note: the recursive Resolve call goes through the full pipeline
        // (cache lookup, normalization, ordering), so chain entries pick up
        // caching for free and a single shared engine remains the source of
        // truth for resolution semantics.
        Func<IConfigurationSection, AuthenticationTokenProvider?> resolveChild =
            child => Resolve(child, resolverList, configureOverrides: null)?.TokenProvider;

        // Per-resolver cache lookup. The cache uses a dual-slot strategy:
        //
        //   * Shared slot — keyed by (sectionHash, resolverInstance). Populated
        //     when a resolver's TryResolve does NOT invoke resolveChild — its
        //     output is chain-independent, so one entry serves every chain
        //     composition.
        //   * Chain-specific slot — keyed by (sectionHash, resolverInstance,
        //     chainKey). Populated when a resolver DOES invoke resolveChild —
        //     its output depends on the downstream resolvers, so a different
        //     chain composition must produce a fresh resolve.
        //
        // CredentialCache.GetOrTryResolve looks up the shared slot first then
        // the chain-specific slot on miss. After invoking TryResolve it stores
        // the result in whichever slot is correct based on whether resolveChild
        // was used.
        //
        // chainKey is computed once per Resolve invocation from the materialized
        // resolverList — stable identifier for the active chain composition
        // (reference-identity hashes joined in order). All resolvers in this
        // engine call share the same chainKey since they all see the same
        // resolveChild closure capturing the same resolverList.
        //
        // Reference-identity (RuntimeHelpers.GetHashCode) is used so distinct
        // instances of the same type don't leak providers into each other,
        // and any GetHashCode override on the resolver is bypassed.
        if (resolverList.Count > 0)
        {
            string chainKey = ComputeChainKey(resolverList);
            foreach (CredentialResolver resolver in resolverList)
            {
                if (resolver is null)
                {
                    continue;
                }

                CredentialSettings? matched = CredentialCache.GetOrTryResolve(workingSection, resolver, resolveChild, chainKey);

                if (matched is not null)
                {
                    return matched;
                }
            }
        }

        // No resolver matched. Return the cached inline-only settings for
        // this section content — covers the inline ApiKey path, where the
        // credential lives directly on the section as Key/CredentialSource
        // rather than through a token provider.
        return CredentialCache.GetOrCreateInline(workingSection);
    }

    // Compose a stable chain identifier from reference-identity hashes of
    // the resolver instances in order. Two engine calls with the same
    // resolver instances in the same order produce the same chainKey; any
    // change (different instance, different order, added/removed resolver)
    // produces a different one. Resolvers' own GetHashCode overrides are
    // bypassed via RuntimeHelpers.GetHashCode.
    private static string ComputeChainKey(IReadOnlyList<CredentialResolver> resolverList)
    {
        if (resolverList.Count == 0)
        {
            return string.Empty;
        }

        StringBuilder sb = new();
        for (int i = 0; i < resolverList.Count; i++)
        {
            CredentialResolver r = resolverList[i];
            if (i > 0)
            {
                sb.Append('|');
            }
            sb.Append(r is null ? "_" : RuntimeHelpers.GetHashCode(r).ToString(Globalization.CultureInfo.InvariantCulture));
        }
        return sb.ToString();
    }
}
