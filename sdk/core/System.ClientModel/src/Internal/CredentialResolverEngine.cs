// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;

namespace System.ClientModel.Primitives;

/// <summary>
/// Internal core resolution logic shared by the public
/// <c>GetCredential</c> overloads, <c>GetClientSettings&lt;T&gt;</c>
/// overloads, and the DI <c>AddClient</c> auto-resolve hook.
/// </summary>
[Experimental("SCME0002")]
internal static class CredentialResolverEngine
{
    public static AuthenticationTokenProvider? Resolve(
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

        if (resolvers is null)
        {
            return null;
        }

        // Per-resolver cache lookup: the cached provider depends on the
        // (section, resolver-that-actually-produced-it) pair, not on the whole
        // chain. So callers with overlapping chains share entries whenever the
        // same resolver instance is the one that wins for a given section.
        //
        // For each resolver in order:
        //   1. Look up cache by (sectionHash, RuntimeHelpers.GetHashCode(resolver)).
        //      If hit, return — that resolver previously produced a provider
        //      for this exact section.
        //   2. Otherwise call TryCreate. If it succeeds, store the produced
        //      provider under that key and return.
        //   3. If it doesn't match, continue to the next resolver.
        //
        // Reference-identity (RuntimeHelpers.GetHashCode) is used so distinct
        // instances of the same type don't leak providers into each other,
        // and any GetHashCode override on the resolver is bypassed.
        foreach (CredentialResolver resolver in resolvers)
        {
            if (resolver is null)
            {
                continue;
            }

            AuthenticationTokenProvider? provider = CredentialCache.GetOrTryCreate(
                workingSection,
                resolver,
                static (section, r) =>
                {
                    if (r.TryCreate(section, out AuthenticationTokenProvider? p) && p is not null)
                    {
                        return p;
                    }
                    return null;
                });

            if (provider is not null)
            {
                return provider;
            }
        }

        return null;
    }
}
