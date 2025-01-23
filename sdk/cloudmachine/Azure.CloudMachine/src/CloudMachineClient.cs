// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.Identity;
using Microsoft.Extensions.Configuration;

namespace Azure.CloudMachine;

/// <summary>
/// The cloud machine client.
/// </summary>
public partial class CloudMachineClient : ClientWorkspace
{
    /// <summary>
    /// The cloud machine ID.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string Id { get; }

    /// <summary>
    /// subclient connections.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ConnectionCollection Connections { get; } = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="CloudMachineClient"/> class for mocking purposes..
    /// </summary>
    protected CloudMachineClient() :
        this(credential: BuildCredential(default))
    {
        Id = AppConfigHelpers.ReadOrCreateCloudMachineId();
        Messaging = new MessagingServices(this);
        Storage = new StorageServices(this);
    }

#pragma warning disable AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
    /// <summary>
    /// Initializes a new instance of the <see cref="CloudMachineClient"/> class.
    /// </summary>
    /// <param name="configuration">The configuration settings.</param>
    /// <param name="credential">The token credential.</param>
    public CloudMachineClient(IConfiguration configuration, TokenCredential credential = default)
#pragma warning restore AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        : base(BuildCredential(credential))
    {
        Id = configuration["CloudMachine:ID"];
        if (Id == null)
        {
            Id = AppConfigHelpers.ReadOrCreateCloudMachineId();
        }

        IConfigurationSection connectionsSection = configuration.GetSection("CloudMachine:Connections");

        foreach (IConfigurationSection connection in connectionsSection.GetChildren())
        {
            string id = connection["Id"];
            if (id == null) continue;
            string locator = connection["Locator"];

            Connections.Add(new ClientConnection(id, locator, ClientAuthenticationMethod.EntraId));
        }

        Messaging = new MessagingServices(this);
        Storage = new StorageServices(this);
    }

#pragma warning disable AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
    /// <summary>
    /// Initializes a new instance of the <see cref="CloudMachineClient"/> class.
    /// </summary>
    /// <param name="connections"></param>
    /// <param name="credential">The token credential.</param>
    // TODO: we need to combine the configuration and the connections into a single parameter.
    public CloudMachineClient(IEnumerable<ClientConnection> connections = default, TokenCredential credential = default)
#pragma warning restore AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        : base(BuildCredential(credential))
    {
        if (connections != default)
        {
            Connections.AddRange(connections);
        }

        Id = AppConfigHelpers.ReadOrCreateCloudMachineId();
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

    /// <summary>
    /// Retrieves the connection options for a specified client type and instance ID.
    /// </summary>
    /// <param name="connectionId"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ClientConnection GetConnectionOptions(string connectionId)
    {
        return Connections[connectionId];
    }

    private static TokenCredential BuildCredential(TokenCredential credential)
    {
        if (credential == default)
        {
            // This environment variable is set by the CloudMachine App Service feature during provisioning.
            credential = Environment.GetEnvironmentVariable("CLOUDMACHINE_MANAGED_IDENTITY_CLIENT_ID") switch
            {
                string clientId when !string.IsNullOrEmpty(clientId) => new ManagedIdentityCredential(clientId),
                _ => new ChainedTokenCredential(new AzureCliCredential(), new AzureDeveloperCliCredential())
            };
        }

        return credential;
    }

    /// <summary>
    /// Reads or creates the cloud machine ID.
    /// </summary>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static string ReadOrCreateCloudMachineId() => AppConfigHelpers.ReadOrCreateCloudMachineId();

    /// <inheritdoc/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object obj) => base.Equals(obj);

    /// <inheritdoc/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode() => base.GetHashCode();

    /// <inheritdoc/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override string ToString() => Id;

    /// <summary>
    /// Retrieves all connection options.
    /// </summary>
    /// <returns></returns>
    public override IEnumerable<ClientConnection> GetAllConnectionOptions()
        => Connections;
}
