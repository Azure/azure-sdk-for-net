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
    /// <param name="connection"></param>
    /// <param name="scope"></param>
    /// <returns></returns>
    public static AuthenticationPolicy Create(ClientConnection connection, string scope)
    {
        return connection.CredentialKind switch
        {
            CredentialKind.TokenCredential => CreateWithTokenCredential(connection, scope),
            CredentialKind.ApiKeyString => CreateWithApiKey(connection, scope),
            _ => throw new InvalidOperationException($"Unsupported CredentialKind: {connection.CredentialKind}")
        };
    }

    private static AuthenticationPolicy CreateWithTokenCredential(ClientConnection connection, string scope)
    {
        var tokenCredential = (AuthenticationTokenProvider)connection.Credential!;
        return new BearerTokenPolicy(tokenCredential, scope);
    }

    private static AuthenticationPolicy CreateWithApiKey(ClientConnection connection, string scope)
    {
        string apiKey;
        if (connection.Credential is AuthenticationTokenProvider apiKeyProvider)
        {
            GetTokenOptions options = new GetTokenOptions(new Dictionary<string, object>
            {
                { GetTokenOptions.ScopesPropertyName, scope }
            });
            apiKey = apiKeyProvider.GetToken(options, default).TokenValue;
        }
        else
        {
            apiKey = (string)connection.Credential!;
        }
        return ApiKeyAuthenticationPolicy.CreateBearerAuthorizationPolicy(new ApiKeyCredential(apiKey));
    }
}
