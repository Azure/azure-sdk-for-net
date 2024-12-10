// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Security.KeyVault.Secrets;

namespace Azure.CloudMachine.KeyVault;

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
    public static SecretClient GetKeyVaultSecretsClient(this ClientWorkspace workspace)
    {
        ClientConnection connection = workspace.GetConnectionOptions(typeof(SecretClient).FullName);
        if (connection.Authentication == ClientAuthenticationMethod.EntraId)
        {
            return new(connection.ToUri(), workspace.Credential);
        }
        throw new Exception("API key not supported");
    }
}
