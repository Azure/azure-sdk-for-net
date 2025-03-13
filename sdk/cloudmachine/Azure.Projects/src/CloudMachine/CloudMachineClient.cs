// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Projects;

/// <summary>
/// The project client.
/// </summary>
public partial class CloudMachineClient : ProjectClient
{
    /// <summary>
    /// Oppinionated API client
    /// </summary>
    public CloudMachineClient() {
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
