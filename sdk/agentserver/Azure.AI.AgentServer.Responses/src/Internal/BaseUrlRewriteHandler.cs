// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// A <see cref="DelegatingHandler"/> that rewrites the outbound request URI
/// using the <c>FOUNDRY_AGENT_STORAGE_CALLBACK_URL</c> environment variable.
/// This variable is set by the Azure AI Foundry hosting platform and contains
/// the storage endpoint URL. If the variable is missing or empty,
/// an <see cref="InvalidOperationException"/> is thrown.
/// </summary>
internal sealed class BaseUrlRewriteHandler : DelegatingHandler
{
    internal const string CallbackUrlEnvVar = "FOUNDRY_AGENT_STORAGE_CALLBACK_URL";

    private readonly Uri _callbackUri;

    /// <summary>
    /// Initializes a new instance of <see cref="BaseUrlRewriteHandler"/>.
    /// </summary>
    public BaseUrlRewriteHandler()
    {
        var envValue = Environment.GetEnvironmentVariable(CallbackUrlEnvVar);

        if (string.IsNullOrEmpty(envValue))
        {
            throw new InvalidOperationException(
                $"The '{CallbackUrlEnvVar}' environment variable is required. " +
                "In hosted environments, the Azure AI Foundry platform must set this variable.");
        }

        if (!Uri.TryCreate(envValue, UriKind.Absolute, out var uri))
        {
            throw new InvalidOperationException(
                $"The '{CallbackUrlEnvVar}' environment variable contains an invalid absolute URI.");
        }

        _callbackUri = uri;
    }

    /// <inheritdoc/>
    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var pathAndQuery = request.RequestUri!.PathAndQuery;
        request.RequestUri = new Uri(
            _callbackUri.GetLeftPart(UriPartial.Path).TrimEnd('/') + pathAndQuery);

        return base.SendAsync(request, cancellationToken);
    }
}
