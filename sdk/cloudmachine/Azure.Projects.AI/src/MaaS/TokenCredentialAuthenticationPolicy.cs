// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline;

internal partial class TokenCredentialAuthenticationPolicy : PipelinePolicy
{
    private readonly TokenCredential _credential;
    private readonly string[] _scopes;
    private readonly TimeSpan _refreshOffset;
    private AccessToken? _currentToken;

    public TokenCredentialAuthenticationPolicy(TokenCredential credential, IEnumerable<string> scopes, TimeSpan? refreshOffset = null)
    {
        if (credential == null) throw new ArgumentNullException(nameof(credential));
        if (scopes == null) throw new ArgumentNullException(nameof(scopes));

        _credential = credential;
        _scopes = scopes.ToArray();
        _refreshOffset = refreshOffset ?? s_defaultRefreshOffset;
    }

    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        if (message.Request is not null)
        {
            if (!IsTokenFresh())
            {
                TokenRequestContext tokenRequestContext = CreateRequestContext(message.Request);
                _currentToken = _credential.GetToken(tokenRequestContext, cancellationToken: default);
            }

            if (_currentToken==null)
            {
                throw new InvalidOperationException("TokenCredential returned null token.");
            }
            message.Request?.Headers?.Set("Authorization", $"Bearer {_currentToken.Value.Token}");
        }

        ProcessNext(message, pipeline, currentIndex);
        if (message?.Response?.Status == (int)HttpStatusCode.Unauthorized)
        {
            _currentToken = null;
        }
    }

    public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        if (message.Request is not null)
        {
            if (!IsTokenFresh())
            {
                TokenRequestContext tokenRequestContext = CreateRequestContext(message.Request);
                _currentToken
                    = await _credential.GetTokenAsync(tokenRequestContext, cancellationToken: default).ConfigureAwait(false);
            }

            if (_currentToken == null)
            {
                throw new InvalidOperationException("TokenCredential returned null token.");
            }
            message.Request?.Headers?.Set("Authorization", $"Bearer {_currentToken.Value.Token}");
        }
        await ProcessNextAsync(message, pipeline, currentIndex).ConfigureAwait(false);

        if (message.Response?.Status == (int)HttpStatusCode.Unauthorized)
        {
            _currentToken = null;
        }
    }

    private bool IsTokenFresh()
    {
        if (!_currentToken.HasValue) return false;
        DateTimeOffset refreshAt = _currentToken.Value.RefreshOn ?? (_currentToken.Value.ExpiresOn - _refreshOffset);
        return DateTimeOffset.UtcNow < refreshAt;
    }

    private TokenRequestContext CreateRequestContext(PipelineRequest request)
    {
        string? clientRequestId = request.Headers.TryGetValue("x-ms-client-request-id", out string? messageClientId) == true
            ? messageClientId
            : null;
        return new TokenRequestContext(_scopes, clientRequestId);
    }

    private static readonly TimeSpan s_defaultRefreshOffset = TimeSpan.FromMinutes(5);
}
