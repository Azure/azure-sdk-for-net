// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;

namespace System.ClientModel.Primitives;

/// <summary>
/// Built-in <see cref="CredentialResolver"/> that recognizes credential
/// sections describing an inline API key (<c>CredentialSource: ApiKey</c>
/// or its normalized alias <c>ApiKeyCredential</c>) and produces an
/// <see cref="ApiKeyTokenProvider"/> from <c>section["Key"]</c>.
/// <para>
/// This resolver is appended to every resolver chain by
/// <see cref="CredentialResolverEngine"/> after caller-supplied resolvers,
/// so customer resolvers may intercept and override the default ApiKey
/// behavior (e.g., a vault-backed lookup that reads the key from a remote
/// store).
/// </para>
/// </summary>
[Experimental("SCME0002")]
internal sealed class ApiKeyCredentialResolver : CredentialResolver
{
    public static ApiKeyCredentialResolver Instance { get; } = new ApiKeyCredentialResolver();

    private ApiKeyCredentialResolver()
    {
    }

    public override bool TryResolve(
        IConfigurationSection credentialSection,
        [NotNullWhen(true)] out AuthenticationTokenProvider? provider)
    {
        provider = null;

        if (credentialSection is null)
        {
            return false;
        }

        // Reuse CredentialSettings so the source-string normalization
        // ("ApiKey" -> "apikeycredential") stays in one place.
        CredentialSettings settings = new(credentialSection);

        if (settings.CredentialSource != "apikeycredential")
        {
            return false;
        }

        if (string.IsNullOrEmpty(settings.Key))
        {
            return false;
        }

        provider = new ApiKeyTokenProvider(settings.Key!);
        return true;
    }
}
