﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Azure.AI.OpenAI;

internal partial class TokenCredentialAuthenticationPolicy : PipelinePolicy
{
    private readonly TokenCredential _credential;
    private readonly string[] _scopes;
    private readonly TimeSpan _refreshOffset;
    private AccessToken? _currentToken;

    public TokenCredentialAuthenticationPolicy(TokenCredential credential, IEnumerable<string> scopes, TimeSpan? refreshOffset = null)
    {
        if (credential is null) throw new ArgumentNullException(nameof(credential));
        if (scopes is null) throw new ArgumentNullException(nameof(scopes));

        _credential = credential;
        _scopes = scopes.ToArray();
        _refreshOffset = refreshOffset ?? s_defaultRefreshOffset;
    }

    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        if (message?.Request is not null)
        {
            if (!IsTokenFresh())
            {
                TokenRequestContext tokenRequestContext = CreateRequestContext(message.Request);
                _currentToken = _credential.GetToken(tokenRequestContext, cancellationToken: default);
            }
            message?.Request?.Headers?.Set("Authorization", $"Bearer {_currentToken!.Value.Token}");
        }
        ProcessNext(message!, pipeline, currentIndex);
        if (message?.Response?.Status == (int)HttpStatusCode.Unauthorized)
        {
            _currentToken = null;
        }
    }

    public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        if (message?.Request is not null)
        {
            if (!IsTokenFresh())
            {
                TokenRequestContext tokenRequestContext = CreateRequestContext(message.Request);
                _currentToken
                    = await _credential.GetTokenAsync(tokenRequestContext, cancellationToken: default).ConfigureAwait(false);
            }
            message?.Request?.Headers?.Set("Authorization", $"Bearer {_currentToken!.Value.Token}");
        }
        await ProcessNextAsync(message!, pipeline, currentIndex).ConfigureAwait(false);
        if (message?.Response?.Status == (int)HttpStatusCode.Unauthorized)
        {
            _currentToken = null;
        }
    }

    private bool IsTokenFresh()
    {
        if (!_currentToken.HasValue)
            return false;
        DateTimeOffset refreshAt = _currentToken.Value.RefreshOn ?? (_currentToken.Value.ExpiresOn - _refreshOffset);
        return DateTimeOffset.UtcNow < refreshAt;
    }

    private TokenRequestContext CreateRequestContext(PipelineRequest request)
    {
        if (request.Headers.TryGetValue("x-ms-client-request-id", out string? messageClientId))
        {
            return new TokenRequestContext(_scopes, messageClientId);
        }
        return new TokenRequestContext(_scopes, null);
    }

    private static readonly TimeSpan s_defaultRefreshOffset = TimeSpan.FromMinutes(5);
}
