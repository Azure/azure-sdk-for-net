// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;

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
    private readonly IScopedFlowToken _flowContext;

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
        Token token;
        if (message.TryGetProperty(typeof(IScopedFlowToken), out var rawContext) && rawContext is IScopedFlowToken scopesContext)
        {
            var context = _flowContext.CloneWithAdditionalScopes(scopesContext.Scopes);
            token = _tokenProvider.GetAccessToken(context, message.CancellationToken);
        }
        else
        {
            token = _tokenProvider.GetAccessToken(_flowContext, message.CancellationToken);
        }
        message.Request.Headers.Set("Authorization", $"Bearer {token.TokenValue}");

        ProcessNext(message, pipeline, currentIndex);
        return;
    }

    /// <inheritdoc />
    public override ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        return ProcessNextAsync(message, pipeline, currentIndex);
    }

    internal static IScopedFlowToken GetContext(IEnumerable<IReadOnlyDictionary<string, object>> contexts, ITokenProvider tokenProvider)
    {
        var type = tokenProvider.GetType();
        // This assumes that a credential provider will only implement one flow type.
        var credentialFlowType = type switch
        {
            var t when typeof(TokenProvider<IClientCredentialsFlowToken>).IsAssignableFrom(t) => typeof(IClientCredentialsFlowToken),
            var t when typeof(TokenProvider<IAuthorizationCodeFlowToken>).IsAssignableFrom(t) => typeof(IAuthorizationCodeFlowToken),
            var t when typeof(TokenProvider<IPasswordFlowToken>).IsAssignableFrom(t) => typeof(IPasswordFlowToken),
            var t when typeof(TokenProvider<IImplicitFlowToken>).IsAssignableFrom(t) => typeof(IImplicitFlowToken),
            _ => throw new InvalidOperationException("Supplied credential does not implement any supported auth flow.")
        };
        foreach (var context in contexts)
        {
            var createdContext = tokenProvider.CreateContext(context);
            if (createdContext != null && credentialFlowType.IsInstanceOfType(createdContext))
            {
                return (IScopedFlowToken)createdContext;
            }
        }
        throw new InvalidOperationException($"The service does not support the flow implemented by the supplied token provider {type.FullName}.");
    }
}
