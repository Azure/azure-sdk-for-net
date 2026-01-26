// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    /// <param name="scope">The scope of the authentication token.</param>
    public static AuthenticationPolicy Create(ClientSettings settings, string scope)
    {
        if (settings is null)
            throw new ArgumentNullException(nameof(settings));

        if (settings.Credential is null)
            throw new ArgumentNullException("settings.Credential");

        if (settings.Credential.CredentialSource is null)
            throw new ArgumentNullException("settings.Credential.CredentialSource");

        return settings.Credential.CredentialSource switch
        {
            "ApiKey" => CreateWithApiKey(settings, scope),
            _ => CreateWithTokenCredential(settings, scope)
        };
    }

    private static AuthenticationPolicy CreateWithTokenCredential(ClientSettings settings, string scope)
    {
        var tokenCredential = (AuthenticationTokenProvider)settings.CredentialObject!;
        return new BearerTokenPolicy(tokenCredential, scope);
    }

    private static AuthenticationPolicy CreateWithApiKey(ClientSettings settings, string scope)
    {
        string apiKey;
        if (settings.CredentialObject is AuthenticationTokenProvider apiKeyProvider)
        {
            GetTokenOptions options = new(new Dictionary<string, object>
            {
                { GetTokenOptions.ScopesPropertyName, new string[] { scope } }
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
