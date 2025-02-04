// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.CloudMachine.Core;
using Azure.Core;
using Azure.Provisioning.Primitives;

namespace Azure.CloudMachine.AIFoundry;

/// <summary>
/// A feature that adds an AI Foundry project/connection to the CloudMachine infrastructure.
/// </summary>
public class FoundryProjectFeature : CloudMachineFeature
{
    private readonly string _foundryConnectionString;

    /// <summary>
    /// Creates a new FoundryProjectFeature.
    /// </summary>
    /// <param name="connectionString">The Foundry connection string.</param>
    public FoundryProjectFeature(string connectionString)
    {
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentException("Connection string cannot be null or empty.", nameof(connectionString));
        }

        _foundryConnectionString = connectionString;
    }

    /// <summary>
    /// Emit the connections for the Foundry.
    /// This is where you can inject the Foundry client connections into the final CloudMachine.
    /// </summary>
    /// <param name="connections">The shared ConnectionCollection for this CloudMachine.</param>
    /// <param name="cmId">The CloudMachine ID (used in naming or scoping if needed).</param>
    protected internal override void EmitConnections(ConnectionCollection connections, string cmId)
    {
        // For now, just add an entry referencing the Foundry Project’s connection string
        // so that the merged CloudMachineClient can pick it up later.
        connections.Add(new ClientConnection(
            id: "Azure.AI.Projects.AIProjectClient",
            locator: _foundryConnectionString
        ));
    }

    /// <summary>
    /// Emit the resources to be provisioned (none, initially).
    /// </summary>
    /// <param name="cm">The CloudMachineInfrastructure context.</param>
    /// <returns>A placeholder or no-op resource if you want to remain consistent with the base class’s pattern.</returns>
    protected override ProvisionableResource EmitResources(CloudMachineInfrastructure cm)
    {
        // Initially do nothing (out-of-band provisioning).
        // In the future, emit Bicep resources for the AI Foundry.
        return new NoOpResource();
    }
}
