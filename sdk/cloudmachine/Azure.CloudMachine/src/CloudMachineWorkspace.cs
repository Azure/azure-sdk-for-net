// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;
using Azure.Core;
using Azure.Identity;
using Azure.Messaging.EventGrid.SystemEvents;
using Microsoft.Extensions.Configuration;

namespace Azure.CloudMachine;

/// <summary>
/// The cloud machine workspace.
/// </summary>
public class CloudMachineWorkspace : ClientWorkspace
{
    /// <summary>
    /// subclient connections.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ConnectionCollection Connections { get; } = [];

    /// <summary>
    /// The cloud machine ID.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string Id { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CloudMachineWorkspace"/> class.
    /// </summary>
    /// <param name="credential"></param>
    /// <param name="configuration"></param>
    /// <param name="connections"></param>
    /// <exception cref="Exception"></exception>
    [SuppressMessage("Usage", "AZC0007:DO provide a minimal constructor that takes only the parameters required to connect to the service.", Justification = "<Pending>")]
    public CloudMachineWorkspace(TokenCredential credential = default, IConfiguration configuration = default, IEnumerable<ClientConnection> connections = default)
        : base(BuildCredentail(credential))
    {
        if (connections != default)
        {
            Connections.AddRange(connections);
        }

        Id = configuration switch
        {
            null => AppConfigHelpers.ReadOrCreateCmid(),
            _ => configuration["CloudMachine:ID"] ?? throw new Exception("CloudMachine:ID configuration value missing")
        };
    }

    private static TokenCredential BuildCredentail(TokenCredential credential)
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

    /// <summary>
    /// Reads or creates the cloud machine ID.
    /// </summary>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static string ReadOrCreateCmid() => AppConfigHelpers.ReadOrCreateCmid();

    /// <inheritdoc/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object obj) => base.Equals(obj);

    /// <inheritdoc/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode() => base.GetHashCode();

    /// <inheritdoc/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override string ToString() => Id;
}
