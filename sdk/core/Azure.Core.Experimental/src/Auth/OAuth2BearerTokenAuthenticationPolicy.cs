// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace System.ClientModel.Primitives;

/// <summary>
/// A <see cref="PipelinePolicy"/> that uses an <see cref="AuthenticationTokenProvider"/> to authenticate requests.
/// </summary>
public class OAuth2BearerTokenAuthenticationPolicy : PipelinePolicy
{
    private readonly AuthenticationTokenProvider _tokenProvider;
    private readonly GetTokenOptions _flowContext;

    /// <param name="tokenProvider"></param>
    /// <param name="contexts"></param>
    public OAuth2BearerTokenAuthenticationPolicy(AuthenticationTokenProvider tokenProvider, IEnumerable<IReadOnlyDictionary<string, object>> contexts)
    {
        _tokenProvider = tokenProvider;
        _flowContext = GetContext(contexts, tokenProvider);
    }

    /// <inheritdoc />
    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        ProcessAsync(message, pipeline, currentIndex, false).EnsureCompleted();
    }

    /// <inheritdoc />
    public override ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        return ProcessAsync(message, pipeline, currentIndex, true);
    }

    private async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex, bool async)
    {
        if (message.Request.Uri!.Scheme != Uri.UriSchemeHttps)
        {
            throw new InvalidOperationException("Bearer token authentication is not permitted for non TLS protected (https) endpoints.");
        }
        AuthenticationToken token;
        if (message.TryGetProperty(typeof(GetTokenOptions), out var rawContext) && rawContext is GetTokenOptions scopesContext)
        {
            var context = _flowContext.WithAdditionalScopes(scopesContext.Scopes);
            token = async ? await _tokenProvider.GetTokenAsync(context, message.CancellationToken).ConfigureAwait(false) :
            _tokenProvider.GetToken(context, message.CancellationToken);
        }
        else
        {
            token = _tokenProvider.GetToken(_flowContext, message.CancellationToken);
        }
        message.Request.Headers.Set("Authorization", $"Bearer {token.TokenValue}");

        if (async)
        {
            await ProcessNextAsync(message, pipeline, currentIndex).ConfigureAwait(false);
        }
        else
        {
            ProcessNext(message, pipeline, currentIndex);
        }
    }

    internal static GetTokenOptions GetContext(IEnumerable<IReadOnlyDictionary<string, object>> contexts, AuthenticationTokenProvider tokenProvider)
    {
        foreach (var context in contexts)
        {
            var createdContext = tokenProvider.CreateTokenOptions(context);
            if (createdContext is not null)
            {
                return createdContext;
            }
        }
        throw new InvalidOperationException($"The service does not support any of the auth flows implemented by the supplied token provider {tokenProvider.GetType().FullName}.");
    }
}
