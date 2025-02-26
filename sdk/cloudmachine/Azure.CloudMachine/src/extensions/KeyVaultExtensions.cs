// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using Azure.Core;
using Azure.Security.KeyVault.Secrets;

namespace Azure.Projects.KeyVault;

/// <summary>
/// The key vault extensions.
/// </summary>
public static class KeyVaultExtensions
{
    /// <summary>
    /// Gets the key vault secrets client.
    /// </summary>
    /// <param name="workspace"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static SecretClient GetKeyVaultSecretsClient(this ConnectionProvider workspace)
    {
        ClientConnection connection = workspace.GetConnection(typeof(SecretClient).FullName);
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
