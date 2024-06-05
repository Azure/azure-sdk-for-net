// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI;

internal partial class AzureTokenAuthenticationPolicy : PipelinePolicy
{
    private readonly TokenCredential _credential;
    private AccessToken? _currentToken;

    public AzureTokenAuthenticationPolicy(TokenCredential credential)
    {
        _credential = credential;
    }

    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        if (message?.Request is not null)
        {
            if (!_currentToken.HasValue || _currentToken.Value.ExpiresOn < DateTimeOffset.UtcNow + TimeSpan.FromSeconds(30))
            {
                TokenRequestContext tokenRequestContext = CreateRequestContext(message.Request);
                _currentToken = _credential.GetToken(tokenRequestContext, cancellationToken: default);
            }
            message?.Request?.Headers?.Add("Authorization", $"Bearer {_currentToken.Value.Token}");
        }
        ProcessNext(message, pipeline, currentIndex);
    }

    public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        if (message?.Request is not null)
        {
            if (!_currentToken.HasValue || _currentToken.Value.ExpiresOn < DateTimeOffset.UtcNow + TimeSpan.FromSeconds(30))
            {
                TokenRequestContext tokenRequestContext = CreateRequestContext(message.Request);
                _currentToken
                    = await _credential.GetTokenAsync(tokenRequestContext, cancellationToken: default).ConfigureAwait(false);
            }
            message?.Request?.Headers?.Add("Authorization", $"Bearer {_currentToken.Value.Token}");
        }
        await ProcessNextAsync(message, pipeline, currentIndex).ConfigureAwait(false);
    }

    private static TokenRequestContext CreateRequestContext(PipelineRequest request)
    {
        string clientRequestId = request.Headers.TryGetValue("x-ms-client-request-id", out string messageClientId) == true
            ? messageClientId
            : null;
        return new TokenRequestContext(DefaultAuthorizationScopes, clientRequestId);
    }

    private static readonly string[] DefaultAuthorizationScopes = ["https://cognitiveservices.azure.com/.default"];
}