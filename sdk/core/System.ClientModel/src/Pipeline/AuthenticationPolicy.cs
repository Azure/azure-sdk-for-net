// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

/// <summary>
/// A <see cref="PipelinePolicy"/> for authentication.
/// </summary>
public abstract class AuthenticationPolicy : PipelinePolicy
{
    /// <summary>
    /// .
    /// </summary>
    /// <param name="settings"></param>
    /// <param name="scope"></param>
    /// <returns></returns>
    public static AuthenticationPolicy Create(ClientSettings settings, string scope)
    {
        if (settings.Credential?.CredentialSource is null)
            throw new ArgumentNullException(nameof(settings.Credential), "CredentialSource cannot be null.");

        return settings.Credential?.CredentialSource switch
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
            GetTokenOptions options = new GetTokenOptions(new Dictionary<string, object>
            {
                { GetTokenOptions.ScopesPropertyName, new string[] { scope } }
            });
            apiKey = apiKeyProvider.GetToken(options, default).TokenValue;
        }
        else
        {
            apiKey = (string)settings.CredentialObject!;
        }
        return ApiKeyAuthenticationPolicy.CreateBearerAuthorizationPolicy(new ApiKeyCredential(apiKey));
    }
}
