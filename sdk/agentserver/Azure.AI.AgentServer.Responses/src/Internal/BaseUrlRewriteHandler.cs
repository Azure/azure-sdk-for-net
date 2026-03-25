// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// A <see cref="DelegatingHandler"/> that rewrites the outbound request URI
/// using the <c>FOUNDRY_PROJECT_ENDPOINT</c> environment variable.
/// The storage base URL is constructed by appending <c>/storage</c> to the
/// project endpoint. If the variable is missing or empty,
/// an <see cref="InvalidOperationException"/> is thrown.
/// </summary>
internal sealed class BaseUrlRewriteHandler : DelegatingHandler
{
    internal const string ProjectEndpointEnvVar = "FOUNDRY_PROJECT_ENDPOINT";

    private readonly Uri _storageBaseUri;

    /// <summary>
    /// Initializes a new instance of <see cref="BaseUrlRewriteHandler"/>.
    /// </summary>
    public BaseUrlRewriteHandler()
    {
        var envValue = Environment.GetEnvironmentVariable(ProjectEndpointEnvVar);

        if (string.IsNullOrEmpty(envValue))
        {
            throw new InvalidOperationException(
                $"The '{ProjectEndpointEnvVar}' environment variable is required. " +
                "In hosted environments, the Azure AI Foundry platform must set this variable.");
        }

        if (!Uri.TryCreate(envValue, UriKind.Absolute, out var uri))
        {
            throw new InvalidOperationException(
                $"The '{ProjectEndpointEnvVar}' environment variable contains an invalid absolute URI.");
        }

        _storageBaseUri = new Uri(uri.GetLeftPart(UriPartial.Path).TrimEnd('/') + "/storage/");
    }

    /// <inheritdoc/>
    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var pathAndQuery = request.RequestUri!.PathAndQuery;
        request.RequestUri = new Uri(
            _storageBaseUri.GetLeftPart(UriPartial.Path).TrimEnd('/') + pathAndQuery);

        return base.SendAsync(request, cancellationToken);
    }
}
