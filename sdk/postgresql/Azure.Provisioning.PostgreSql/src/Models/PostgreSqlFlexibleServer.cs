// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.PostgreSql;

/// <summary>
/// PostgreSqlFlexibleServer.
/// </summary>
[CodeGenSuppress("GetResourceNameRequirements")]
public partial class PostgreSqlFlexibleServer : ProvisionableResource
{
    /// <summary>
    /// Maximum number of replicas that a primary server can have.
    /// </summary>
    [CodeGenMember("ReplicaCapacity")]
    public BicepValue<int> ReplicaCapacity
    {
        get
        {
            if (Properties is null)
            {
                Properties = new ServerProperties();
            }
            return Properties.ReplicaCapacity;
        }
        set
        {
            if (Properties is null)
            {
                Properties = new ServerProperties();
            }
            Properties.ReplicaCapacity = value;
        }
    }

    /// <summary>
    /// Max storage allowed for a server.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BicepValue<int> StorageSizeInGB
    {
        get { Initialize(); return Storage.StorageSizeInGB; }
        set { Initialize(); Storage.StorageSizeInGB = value; }
    }

    /// <summary>
    /// Get the requirements for naming this resource.
    /// </summary>
    /// <returns>Naming requirements.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ResourceNameRequirements GetResourceNameRequirements() =>
        new(3, 63, ResourceNameCharacters.LowercaseLetters | ResourceNameCharacters.Numbers | ResourceNameCharacters.Hyphen);
}
