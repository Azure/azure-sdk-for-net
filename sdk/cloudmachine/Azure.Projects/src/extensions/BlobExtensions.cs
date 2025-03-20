// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Identity;
using System;
using Azure.Storage.Blobs;
using System.ClientModel.Primitives;
using Azure.Core;
using Azure.AI.OpenAI;
using OpenAI.Chat;

namespace Azure.Projects;

/// <summary>
/// Extension methods for <see cref="ProjectClient"/>.
/// </summary>
public static class BlobExtensions
{
    /// <summary>
    /// Creates a <see cref="BlobContainerClient"/> for the project.
    /// </summary>
    /// <param name="project"></param>
    /// <param name="containerName"></param>
    /// <returns></returns>
    public static  BlobContainerClient GetBlobContainerClient(this ProjectClient project, string containerName = "default")
    {
        string id = $"{typeof(BlobContainerClient).FullName}@{containerName}";
        BlobContainerClient client = project.Subclients.GetClient(() =>
            CreateClient(project, containerName), id);
        return client;
    }

    private static BlobContainerClient CreateClient(ProjectClient project, string containerName)
    {
        string id = $"{typeof(BlobContainerClient).FullName}@{containerName}";
        ClientConnection connection = project.GetConnection(id);
        if (connection.TryGetLocatorAsUri(out Uri uri))
        {
            return new BlobContainerClient(uri, (TokenCredential)connection.Credential);
        }
        throw new InvalidOperationException($"Invalid connection locator for container: {containerName}");
    }
}
