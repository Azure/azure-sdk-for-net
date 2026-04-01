// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.Http.Headers;
using Azure.Core;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// A <see cref="DelegatingHandler"/> that injects a Bearer token into every outbound HTTP request.
/// The token is obtained from a <see cref="TokenCredential"/> (typically
/// <c>DefaultAzureCredential</c>) registered by <c>AddResponsesServer</c>.
/// </summary>
internal sealed class BearerTokenHandler : DelegatingHandler
{
    private static readonly string[] TokenScopes = ["https://ai.azure.com/.default"];

    private readonly TokenCredential _credential;

    /// <summary>
    /// Initializes a new instance of <see cref="BearerTokenHandler"/>.
    /// </summary>
    public BearerTokenHandler(TokenCredential credential)
    {
        _credential = credential;
    }

    /// <inheritdoc/>
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var context = new TokenRequestContext(TokenScopes);
        var token = await _credential.GetTokenAsync(context, cancellationToken);

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);
        return await base.SendAsync(request, cancellationToken);
    }
}
