// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using Azure.Core;
using Azure.Data.AppConfiguration;

namespace Azure.Projects.AppConfiguration;

/// <summary>
/// AppConfiguration extensions.
/// </summary>
public static class AppConfigurationExtensions
{
    /// <summary>
    /// Gets the ConfigurationClient.
    /// </summary>
    /// <param name="workspace"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static ConfigurationClient GetConfigurationClient(this ConnectionProvider workspace)
    {
        ClientConnection connection = workspace.GetConnection(typeof(ConfigurationClient).FullName);
        if (connection.Authentication == ClientAuthenticationMethod.Credential)
        {
            if (!connection.TryGetLocatorAsUri(out Uri uri))
            {
                throw new InvalidOperationException("The connection is not a valid URI.");
            }
            return new(uri, (TokenCredential)connection.Credential);
        }
        throw new Exception("API key not supported");
    }
}
