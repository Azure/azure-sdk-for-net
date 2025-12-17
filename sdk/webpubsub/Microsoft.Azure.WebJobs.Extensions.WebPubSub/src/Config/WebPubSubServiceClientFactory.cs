// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using Azure;
using Azure.Messaging.WebPubSub;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub;

internal class WebPubSubServiceClientFactory(
    IConfiguration configuration,
    AzureComponentFactory azureComponentFactory,
    IOptions<WebPubSubServiceAccessOptions> options) : IWebPubSubServiceClientFactory
{
    private readonly WebPubSubServiceAccessOptions _options = options.Value;

    /// <summary>
    /// Creates a WebPubSubServiceClient with fallback connection and hub resolution.
    /// Priority for connection:
    ///   1. attributeConnection (can be connection string or config section name)
    ///   2. options (identity-based connection prioritized over connection string)
    /// Priority for hub: attributeHub > options.Hub.
    /// </summary>
    /// <param name="attributeConnection">Connection from the attribute (can be connection string or config section name).</param>
    /// <param name="attributeHub">Hub from the attribute (highest priority).</param>
    /// <returns>A configured WebPubSubServiceClient instance.</returns>
    public WebPubSubServiceClient Create(string attributeConnection, string attributeHub)
    {
        // Resolve hub with priority: attribute > options
        var hub = attributeHub ?? _options.Hub;

        // Already validated
        Debug.Assert(hub is not null);

        WebPubSubServiceAccess? access;
        // Determine the connection source and create client accordingly
        if (!string.IsNullOrEmpty(attributeConnection))
        {
            if (WebPubSubServiceAccessUtil.CreateFromIConfiguration(configuration.GetSection(attributeConnection), azureComponentFactory, out var fromConfig))
            {
                access = fromConfig;
            }
            else
            {
                // This should not happen because we have validated the attribute.
                throw new InvalidOperationException(
                    $"Valid Web PubSub connection is missing.");
            }
        }
        else if (_options.WebPubSubAccess != null)
        {
            access = _options.WebPubSubAccess;
        }
        else
        {
            // This should not happen because we have validated the attribute.
            throw new InvalidOperationException(
                $"Valid Web PubSub connection is missing.");
        }
        return CreateClient(access, hub);
    }

    private static WebPubSubServiceClient CreateClient(WebPubSubServiceAccess access, string hub)
    {
        if (access.Credential is KeyCredential keyCredential)
        {
            return new WebPubSubServiceClient(access.ServiceEndpoint, hub, new AzureKeyCredential(keyCredential.AccessKey));
        }
        if (access.Credential is IdentityCredential identityCredential)
        {
            return new WebPubSubServiceClient(access.ServiceEndpoint, hub, identityCredential.TokenCredential);
        }
        throw new InvalidOperationException($"Unsupported credential type {access.Credential.GetType().Name} for WebPubSubServiceClient.");
    }
}
