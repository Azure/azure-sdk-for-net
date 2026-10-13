// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.PostgreSql;

/// <summary>
/// The PostgreSqlServerPrivateLinkServiceConnectionStateProperty.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is obsoleted and will be removed in a future version. Please use PostgreSqlFlexibleServersPrivateLinkServiceConnectionState instead.")]
public partial class PostgreSqlServerPrivateLinkServiceConnectionStateProperty : ProvisionableConstruct
{
    /// <summary>
    /// The private link service connection status.
    /// </summary>
    public BicepValue<PostgreSqlPrivateLinkServiceConnectionStateStatus> Status
    {
        get { Initialize(); return _status!; }
    }
    private BicepValue<PostgreSqlPrivateLinkServiceConnectionStateStatus> _status;

    /// <summary>
    /// The private link service connection description.
    /// </summary>
    public BicepValue<string> Description
    {
        get { Initialize(); return _description!; }
    }
    private BicepValue<string> _description;

    /// <summary>
    /// The actions required for private link service connection.
    /// </summary>
    public BicepValue<PostgreSqlPrivateLinkServiceConnectionStateRequiredAction> ActionsRequired
    {
        get { Initialize(); return _actionsRequired!; }
    }
    private BicepValue<PostgreSqlPrivateLinkServiceConnectionStateRequiredAction> _actionsRequired;

    /// <summary>
    /// Creates a new PostgreSqlServerPrivateLinkServiceConnectionStateProperty.
    /// </summary>
    public PostgreSqlServerPrivateLinkServiceConnectionStateProperty()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of
    /// PostgreSqlServerPrivateLinkServiceConnectionStateProperty.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _status = DefineProperty<PostgreSqlPrivateLinkServiceConnectionStateStatus>("Status", ["status"], isOutput: true);
        _description = DefineProperty<string>("Description", ["description"], isOutput: true);
        _actionsRequired = DefineProperty<PostgreSqlPrivateLinkServiceConnectionStateRequiredAction>("ActionsRequired", ["actionsRequired"], isOutput: true);
    }
}
