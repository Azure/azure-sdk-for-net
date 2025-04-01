// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;

namespace Azure.Projects;

/// <summary>
/// The project client.
/// </summary>
public partial class OfxProjectClient : ProjectClient
{
    /// <summary>
    /// Oppinionated API client
    /// </summary>
    public OfxProjectClient() {
        Messaging = new MessagingServices(this);
        Storage = new StorageServices(this);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ProjectClient"/> with the specified connection provider.
    /// </summary>
    /// <param name="projectId"></param>
    /// <param name="connections"></param>
    public OfxProjectClient(string projectId, ConnectionProvider connections):
        base(projectId, connections)
    {
        Messaging = new MessagingServices(this);
        Storage = new StorageServices(this);
    }

    /// <summary>
    /// Gets the messaging services.
    /// </summary>
    public MessagingServices Messaging { get; }

    /// <summary>
    /// Gets the storage services.
    /// </summary>
    public StorageServices Storage { get; }
}
