// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

namespace System.ClientModel.Primitives;

/// <summary>
/// A <see cref="PipelinePolicy"/> for authentication.
/// </summary>
public abstract class AuthenticationPolicy : PipelinePolicy
{
    /// <summary>
    /// Creates an <see cref="AuthenticationPolicy"/> based on the provided <see cref="ClientSettings"/> and scope.
    /// </summary>
    /// <param name="settings">The <see cref="ClientSettings"/> to use.</param>
    [Experimental("SCME0002")]
    public static AuthenticationPolicy Create(ClientSettings settings)
    {
        if (settings is null)
        {
            throw new ArgumentNullException(nameof(settings));
        }

        if (settings.Credential is null)
        {
            throw new ArgumentNullException("settings.Credential");
        }

        if (settings.Credential.CredentialSource is null)
        {
            throw new ArgumentNullException("settings.Credential.CredentialSource");
        }

        // Read Scope from either the root of the credential section (forward-looking
        // shape) or the legacy AdditionalProperties subsection (current shape written
        // by Azure.Core's AddDefaultScope). Reading both lets writers migrate to the
        // flat shape without breaking SCM consumers.
        string? scope = settings.Credential["Scope"]
            ?? settings.Credential.AdditionalProperties?["Scope"];

        return settings.Credential.CredentialSource switch
        {
            "apikeycredential" => CreateWithApiKey(settings, scope),
            _ => CreateWithTokenCredential(settings, scope)
        };
    }

    [Experimental("SCME0002")]
    private static AuthenticationPolicy CreateWithTokenCredential(ClientSettings settings, string? scope)
    {
        if (scope is null)
        {
            throw new InvalidOperationException(
                $"Scope must be provided in configuration for '{settings.Credential!.CredentialSource}' authentication.");
        }

        AuthenticationTokenProvider? provider = settings.Credential?.TokenProvider;
        if (provider is null)
        {
            throw new InvalidOperationException("No AuthenticationTokenProvider was provided.");
        }

        return new BearerTokenPolicy(provider, scope);
    }

    [Experimental("SCME0002")]
    private static AuthenticationPolicy CreateWithApiKey(ClientSettings settings, string? scope)
    {
        string apiKey;

        AuthenticationTokenProvider? provider = settings.Credential?.TokenProvider;
        if (provider is AuthenticationTokenProvider apiKeyProvider)
        {
            // Scope is meaningless for API-key auth; silently ignore any value
            // present on the credential section so that callers who set
            // TokenProvider for an ApiKey configuration (for example, via
            // a custom CredentialResolver that fetches a refreshable key) are
            // not rejected just because Scope happens to also be set.
            GetTokenOptions options = new(new Dictionary<string, object>
            {
                // TokenCredential requires at least one scope, so we provide a dummy value
                // that will be ignored by the API key provider.
                { GetTokenOptions.ScopesPropertyName, new string[] { "<null>" } }
            });
            apiKey = apiKeyProvider.GetToken(options, default).TokenValue;
        }
        else if (settings.Credential is not null && settings.Credential.Key is not null)
        {
            apiKey = settings.Credential.Key;
        }
        else
        {
            throw new InvalidOperationException("API key is not provided in the ClientSettings.");
        }

        return ApiKeyAuthenticationPolicy.CreateBearerAuthorizationPolicy(new ApiKeyCredential(apiKey));
    }
}
