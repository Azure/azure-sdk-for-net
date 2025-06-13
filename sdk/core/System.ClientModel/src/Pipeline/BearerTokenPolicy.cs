// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;

namespace System.ClientModel.Primitives;

/// <summary>
/// A <see cref="PipelinePolicy"/> that uses an <see cref="AuthenticationTokenProvider"/> to authenticate requests.
/// </summary>
public class BearerTokenPolicy : AuthenticationPolicy
{
    private readonly AuthenticationTokenProvider _tokenProvider;
    private readonly GetTokenOptions? _flowContext;

    /// <summary>
    /// Creates a new instance of <see cref="BearerTokenPolicy"/>.
    /// </summary>
    /// <param name="tokenProvider">The <see cref="AuthenticationTokenProvider"/>.</param>
    /// <param name="contexts">The authentication flow contexts supported by the client. This would typically be provided by generated code.</param>
    public BearerTokenPolicy(AuthenticationTokenProvider tokenProvider, IEnumerable<IReadOnlyDictionary<string, object>> contexts)
    {
        _tokenProvider = tokenProvider;
        _flowContext = GetOptionsFromContexts(contexts, tokenProvider);
    }

    /// <summary>
    /// Creates a new instance of <see cref="BearerTokenPolicy"/>.
    /// </summary>
    /// <param name="tokenProvider">The <see cref="AuthenticationTokenProvider"/>.</param>
    /// <param name="scope">The scope to be used for authentication requests made by the <paramref name="tokenProvider"/>.</param>
    public BearerTokenPolicy(AuthenticationTokenProvider tokenProvider, string scope)
    {
        _tokenProvider = tokenProvider;
        _flowContext = new GetTokenOptions(new Dictionary<string, object>()
        {
            [GetTokenOptions.ScopesPropertyName] = new ReadOnlyMemory<string>([scope])
        });
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
        AuthenticationToken? token = null;

        // The following scenarios are supported:
        // 1. If the message does not have a GetTokenOptions property.
        //    - When _flowContext is null, this shall be treated as a NoAuth scenario. The message will be processed without authentication.
        //    - When _flowContext is not null, the message will be processed with the service level flow context as-is.
        // 2. If the message has a GetTokenOptions property, it shall contain a IEnumerable<IReadOnlyDictionary<string, object>>
        //    - When _flowContext is null, the property value shall contain the flows supported by the operation.
        //      If the operation defines additional scopes, they will be embedded in the 'scopes' property of any IEnumerable<IReadOnlyDictionary<string, object>>.
        //    - When _flowContext is not null it shall be ignored and the property value shall define the flows supported by the operation.

        if (message.TryGetProperty(typeof(GetTokenOptions), out var rawContext) && rawContext is IEnumerable<IReadOnlyDictionary<string, object>> flowsContexts)
        {
            var context = GetOptionsFromContexts(flowsContexts, _tokenProvider);
            if (context is not null)
            {
                token = async ? await _tokenProvider.GetTokenAsync(context, message.CancellationToken).ConfigureAwait(false) :
                _tokenProvider.GetToken(context, message.CancellationToken);
            }
        }
        else if (_flowContext is not null && _flowContext.Properties.Count > 0)
        {
            token = async ? await _tokenProvider.GetTokenAsync(_flowContext, message.CancellationToken).ConfigureAwait(false) :
                _tokenProvider.GetToken(_flowContext, message.CancellationToken);
        }

        if (token is not null)
        {
            message.Request.Headers.Set("Authorization", $"Bearer {token.TokenValue}");
        }

        if (async)
        {
            await ProcessNextAsync(message, pipeline, currentIndex).ConfigureAwait(false);
        }
        else
        {
            ProcessNext(message, pipeline, currentIndex);
        }
    }

    internal static GetTokenOptions? GetOptionsFromContexts(IEnumerable<IReadOnlyDictionary<string, object>> contexts, AuthenticationTokenProvider tokenProvider)
    {
        foreach (var context in contexts)
        {
            var options = tokenProvider.CreateTokenOptions(context);
            if (options is not null)
            {
                return options;
            }
        }
        return null;
    }
}
