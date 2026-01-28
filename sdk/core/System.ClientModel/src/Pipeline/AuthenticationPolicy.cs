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

        string? scope = settings.Credential.AdditionalProperties?["Scope"];

        return settings.Credential.CredentialSource switch
        {
            "ApiKey" => CreateWithApiKey(settings, scope),
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

        if (settings.CredentialProvider is null)
        {
            throw new InvalidOperationException("No AuthenticationTokenProvider was provided.");
        }

        return new BearerTokenPolicy(settings.CredentialProvider, scope);
    }

    [Experimental("SCME0002")]
    private static AuthenticationPolicy CreateWithApiKey(ClientSettings settings, string? scope)
    {
        string apiKey;

        if (settings.CredentialProvider is AuthenticationTokenProvider apiKeyProvider)
        {
            if (scope is not null)
            {
                throw new InvalidOperationException("Scope is not applicable for API key authentication.");
            }

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
