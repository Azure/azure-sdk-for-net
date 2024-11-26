﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;
using Microsoft.Extensions.Configuration;

namespace Azure.CloudMachine;

/// <summary>
/// The cloud machine client.
/// </summary>
public partial class CloudMachineClient : CloudMachineWorkspace
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CloudMachineClient"/> class for mocking purposes..
    /// </summary>
    protected CloudMachineClient()
    {
        Messaging = new MessagingServices(this);
        Storage = new StorageServices(this);
    }
#pragma warning disable AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
    /// <summary>
    /// Initializes a new instance of the <see cref="CloudMachineClient"/> class.
    /// </summary>
    /// <param name="credential">The token credential.</param>
    /// <param name="configuration">The configuration settings.</param>
    /// <param name="connections"></param>
    public CloudMachineClient(TokenCredential credential = default, IConfiguration configuration = default, IEnumerable<ClientConnection> connections = default)
#pragma warning restore AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        : base(credential, configuration, connections)
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
