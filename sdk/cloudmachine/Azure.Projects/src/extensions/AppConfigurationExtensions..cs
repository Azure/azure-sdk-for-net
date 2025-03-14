﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
    /// <param name="project"></param>
    /// <returns></returns>
    public static  ConfigurationClient GetConfigurationClient(this ProjectClient project)
    {
        ConfigurationClient client = project.Subclients.GetClient(() =>
            CreateClient(project), default);
        return client;
    }

    private static ConfigurationClient CreateClient(ProjectClient project)
    {
        ClientConnection connection = project.GetConnection(typeof(ConfigurationClient).FullName);
        if (connection.TryGetLocatorAsUri(out Uri uri))
        {
            return new ConfigurationClient(uri, (TokenCredential)connection.Credential);
        }
        throw new InvalidOperationException("ConfigurationClient connection not found");
    }
}
