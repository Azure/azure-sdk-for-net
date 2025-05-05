// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using Azure.Core;

namespace Azure.AI.Models;

/// <summary>
/// The Azure OpenAI extensions.
/// </summary>
public static partial class AIModelsExtensions
{
    /// <summary>
    /// Gets the OpenAI embedding client.
    /// </summary>
    /// <param name="provider"></param>
    /// <param name="deploymentName"></param>
    /// <returns></returns>
    public static ModelsClient GetModelsClient(this ClientConnectionProvider provider, string? deploymentName = null)
    {
        ModelsClientKey modelsClientKey = new(deploymentName);
        ModelsClient client = provider.Subclients.GetClient(modelsClientKey, () => CreateModelsClient(provider));
        return client;
    }

    private static ModelsClient CreateModelsClient(this ClientConnectionProvider provider)
    {
        ClientConnection connection = provider.GetConnection(typeof(ModelsClient).FullName!);

        if (!connection.TryGetLocatorAsUri(out Uri? uri) || uri is null)
        {
            throw new InvalidOperationException("Invalid URI.");
        }

        return connection.CredentialKind == CredentialKind.TokenCredential
            ? new ModelsClient(uri, (connection.Credential as TokenCredential)!)
            : new ModelsClient(uri, new ApiKeyCredential((string)connection.Credential!));
    }

    private record ModelsClientKey(string? DeploymentName);
}
