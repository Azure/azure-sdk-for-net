// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using Azure.Core;
using Azure.Data.AppConfiguration;
using Azure.Storage.Blobs;

namespace Azure.Projects;

/// <summary>
/// Extension methods for <see cref="ProjectClient"/>.
/// </summary>
public static class AppConfigurationExtensions
{
    /// <summary>
    /// Creates a <see cref="BlobContainerClient"/> for the project.
    /// </summary>
    /// <param name="provider"></param>
    /// <returns></returns>
    public static ConfigurationClient GetConfigurationClient(this ConnectionProvider provider)
    {
        ConfigurationClientKey configurationClientKey = new();
        ConfigurationClient client = provider.Subclients.GetClient(configurationClientKey, () =>
            CreateClient(provider));
        return client;
    }

    private static ConfigurationClient CreateClient(ConnectionProvider provider)
    {
        ClientConnection connection = provider.GetConnection(typeof(ConfigurationClient).FullName);
        if (connection.TryGetLocatorAsUri(out Uri uri))
        {
            return new ConfigurationClient(uri, (TokenCredential)connection.Credential);
        }
        throw new InvalidOperationException("ConfigurationClient connection not found");
    }

    private record ConfigurationClientKey();
}
