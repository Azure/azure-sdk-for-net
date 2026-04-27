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
            try
            {
                configureOverrides(workingSection);
            }
            catch
            {
                return null;
            }
        }

        if (resolvers is null)
        {
            return null;
        }

        return CredentialCache.GetOrAdd(workingSection, section =>
        {
            foreach (CredentialResolver resolver in resolvers)
            {
                if (resolver is null)
                {
                    continue;
                }

                AuthenticationTokenProvider? provider;
                try
                {
                    if (resolver.TryCreate(section, out provider) && provider is not null)
                    {
                        return provider;
                    }
                }
                catch
                {
                    // Never throw from Get*Credential paths.
                }
            }

            return null;
        });
    }
}
