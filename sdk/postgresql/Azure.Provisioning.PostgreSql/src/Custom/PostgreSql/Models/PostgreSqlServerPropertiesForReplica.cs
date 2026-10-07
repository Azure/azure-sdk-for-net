// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.PostgreSql;

/// <summary>
/// The properties to create a new replica.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is obsoleted and will be removed in a future version. Please use PostgreSqlFlexibleServer with CreateMode and SourceServerResourceId for replica scenarios instead.")]
public partial class PostgreSqlServerPropertiesForReplica : PostgreSqlServerPropertiesForCreate
{
    /// <summary>
    /// The master server id to create replica from.
    /// </summary>
    public BicepValue<ResourceIdentifier> SourceServerId
    {
        get { Initialize(); return _sourceServerId!; }
    }
    private BicepValue<ResourceIdentifier> _sourceServerId;

    /// <summary>
    /// Creates a new PostgreSqlServerPropertiesForReplica.
    /// </summary>
    public PostgreSqlServerPropertiesForReplica() : base()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of
    /// PostgreSqlServerPropertiesForReplica.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        DefineProperty<string>("createMode", ["createMode"], defaultValue: "Replica");
        _sourceServerId = DefineProperty<ResourceIdentifier>("SourceServerId", ["sourceServerId"], isOutput: true);
    }
}
