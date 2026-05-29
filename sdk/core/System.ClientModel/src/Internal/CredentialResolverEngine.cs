// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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

        // Per-resolver cache lookup: the cached settings depend on the
        // (section, resolver-that-actually-produced-it) pair, not on the whole
        // chain. So callers with overlapping chains share entries whenever the
        // same resolver instance is the one that wins for a given section.
        //
        // For each resolver in order:
        //   1. Look up cache by (sectionHash, RuntimeHelpers.GetHashCode(resolver)).
        //      If hit, return — that resolver previously produced settings for
        //      this exact section.
        //   2. Otherwise call TryResolve. If it succeeds, store the produced
        //      settings under that key and return.
        //   3. If it doesn't match, continue to the next resolver.
        //
        // Reference-identity (RuntimeHelpers.GetHashCode) is used so distinct
        // instances of the same type don't leak providers into each other,
        // and any GetHashCode override on the resolver is bypassed.
        if (resolvers is not null)
        {
            foreach (CredentialResolver resolver in resolvers)
            {
                if (resolver is null)
                {
                    continue;
                }

                CredentialSettings? matched = CredentialCache.GetOrTryResolve(workingSection, resolver);

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
}
