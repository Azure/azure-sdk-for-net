// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using Azure.AI.Models;
using Azure.Core;

namespace Azure.AI.OpenAI;

/// <summary>
/// The Azure OpenAI extensions.
/// </summary>
public static partial class AIServicesExtensions
{
    /// <summary>
    /// Gets the OpenAI embedding client.
    /// </summary>
    /// <param name="provider"></param>
    /// <param name="deploymentName"></param>
    /// <returns></returns>
    public static ModelsClient GetModelsClient(this ConnectionProvider provider, string? deploymentName = null)
    {
        ModelsClient client = provider.Subclients.GetClient(() => CreateModelsClient(provider), null!);
        return client;
    }

    private static ModelsClient CreateModelsClient(this ConnectionProvider provider)
    {
        ClientConnection connection = provider.GetConnection(typeof(ModelsClient).FullName!);

        if (!connection.TryGetLocatorAsUri(out Uri? uri) || uri is null)
        {
            throw new InvalidOperationException("Invalid URI.");
        }

        return connection.Authentication == ClientAuthenticationMethod.Credential
            ? new ModelsClient(uri, (connection.Credential as TokenCredential)!)
            : new ModelsClient(uri, new ApiKeyCredential(connection.ApiKeyCredential!));
    }
}
