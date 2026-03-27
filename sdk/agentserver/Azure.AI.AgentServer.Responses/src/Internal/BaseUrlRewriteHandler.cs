// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// A <see cref="DelegatingHandler"/> that rewrites the outbound request URI
/// using <see cref="FoundryEnvironment.ProjectEndpoint"/>.
/// The storage base URL is constructed by appending <c>/storage</c> to the
/// project endpoint.
/// </summary>
internal sealed class BaseUrlRewriteHandler : DelegatingHandler
{
    private readonly Uri _storageBaseUri;

    /// <summary>
    /// Initializes a new instance of <see cref="BaseUrlRewriteHandler"/>.
    /// </summary>
    public BaseUrlRewriteHandler()
    {
        var endpoint = FoundryEnvironment.ProjectEndpoint;

        if (string.IsNullOrWhiteSpace(endpoint))
        {
            throw new InvalidOperationException(
                "FoundryEnvironment.ProjectEndpoint is required. " +
                "In hosted environments, the Azure AI Foundry platform must set the FOUNDRY_PROJECT_ENDPOINT variable.");
        }

        if (!Uri.TryCreate(endpoint, UriKind.Absolute, out var uri))
        {
            throw new InvalidOperationException(
                "FoundryEnvironment.ProjectEndpoint contains an invalid absolute URI.");
        }

        if (!string.Equals(uri.Scheme, Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException(
                "FoundryEnvironment.ProjectEndpoint must use the HTTPS scheme.");
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
