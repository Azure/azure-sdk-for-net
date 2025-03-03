// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace System.ClientModel.Auth;

/// <summary>
/// A <see cref="PipelinePolicy"/> that uses an <see cref="ITokenProvider"/>
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="OAuth2BearerTokenAuthenticationPolicy"/> class.
/// </remarks>
public class OAuth2BearerTokenAuthenticationPolicy : PipelinePolicy
{
    private readonly ITokenProvider _tokenProvider;
    private readonly IScopedFlowContext _flowContext;

    /// <param name="tokenProvider"></param>
    /// <param name="contexts"></param>
    public OAuth2BearerTokenAuthenticationPolicy(ITokenProvider tokenProvider, IEnumerable<IReadOnlyDictionary<string, object>> contexts)
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
        Token token;
        if (message.TryGetProperty(typeof(IScopedFlowContext), out var rawContext) && rawContext is IScopedFlowContext scopesContext)
        {
            var context = _flowContext.CloneWithAdditionalScopes(scopesContext.Scopes);
            token = async ? await _tokenProvider.GetAccessTokenAsync(context, message.CancellationToken).ConfigureAwait(false) :
            _tokenProvider.GetAccessToken(context, message.CancellationToken);
        }
        else
        {
            token = _tokenProvider.GetAccessToken(_flowContext, message.CancellationToken);
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

    internal static IScopedFlowContext GetContext(IEnumerable<IReadOnlyDictionary<string, object>> contexts, ITokenProvider tokenProvider)
    {
        var type = tokenProvider.GetType();
        // This assumes that a credential provider will only implement one flow type.
        var credentialFlowType = type switch
        {
            var t when typeof(TokenProvider<IClientCredentialsFlowContext>).IsAssignableFrom(t) => typeof(IClientCredentialsFlowContext),
            var t when typeof(TokenProvider<IAuthorizationCodeFlowContext>).IsAssignableFrom(t) => typeof(IAuthorizationCodeFlowContext),
            var t when typeof(TokenProvider<IPasswordFlowContext>).IsAssignableFrom(t) => typeof(IPasswordFlowContext),
            var t when typeof(TokenProvider<IImplicitFlowContext>).IsAssignableFrom(t) => typeof(IImplicitFlowContext),
            _ => throw new InvalidOperationException("Supplied credential does not implement any supported auth flow.")
        };
        foreach (var context in contexts)
        {
            var createdContext = tokenProvider.CreateContext(context);
            if (createdContext != null && credentialFlowType.IsInstanceOfType(createdContext))
            {
                return (IScopedFlowContext)createdContext;
            }
        }
        throw new InvalidOperationException($"The service does not support the flow implemented by the supplied token provider {type.FullName}.");
    }
}
