// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Projects;

/// <summary>
/// The project client.
/// </summary>
public partial class CloudMachineClient
{
    /// <summary>
    /// Oppinionated API client
    /// </summary>
    public CloudMachineClient(ProjectClient project) {
        Messaging = new MessagingServices(project);
        Storage = new StorageServices(project);
    }

    /// <summary>
    /// For mocking purposes only.
    /// </summary>
    protected CloudMachineClient() { }

    /// <summary>
    /// Gets the messaging services.
    /// </summary>
    public MessagingServices Messaging { get; }

    /// <summary>
    /// Gets the storage services.
    /// </summary>
    public StorageServices Storage { get; }
}

/// <summary>
/// Extension methods for the project client.
/// </summary>
public static class CloudMachineExtensions
{
    /// <summary>
    /// Gets the OFX client for the project.
    /// </summary>
    /// <param name="project"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static CloudMachineClient GetCloudMachineClient(this ProjectClient project)
    {
        throw new NotImplementedException();
    }
}
