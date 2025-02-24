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
/// <param name="tokenProvider"></param>
public class OAuth2BearerTokenAuthenticationPolicy(ITokenProvider tokenProvider) : PipelinePolicy
{
    private readonly ITokenProvider _tokenProvider = tokenProvider;

    /// <inheritdoc />
    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        if (message.TryGetProperty(typeof(ITokenContext), out var rawContext))
        {
            ITokenContext context = rawContext switch
            {
                IAuthorizationCodeFlowToken authCode => authCode,
                IClientCredentialsFlowToken clientSecret => clientSecret,
                IPasswordFlowToken password => password,
                IImplicitFlowToken implicitFlow => implicitFlow,
                _ => throw new NotImplementedException()
            };
            var token = _tokenProvider.GetAccessToken(context, message.CancellationToken);
            message.Request.Headers.Set("Authorization", $"Bearer {token.TokenValue}");
            return;
        }
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public override ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        throw new NotImplementedException();
    }
}
