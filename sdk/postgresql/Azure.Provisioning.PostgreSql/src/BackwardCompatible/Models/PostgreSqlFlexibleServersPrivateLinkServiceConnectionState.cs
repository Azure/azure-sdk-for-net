// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.PostgreSql;

/// <summary>
/// A collection of information about the state of the connection between
/// service consumer and provider.
/// </summary>
public partial class PostgreSqlFlexibleServersPrivateLinkServiceConnectionState : ProvisionableConstruct
{
    private BicepValue<PostgreSqlFlexibleServersPrivateEndpointServiceConnectionStatus> _status;
    private BicepValue<string> _description;
    private BicepValue<string> _actionsRequired;

    /// <summary>
    /// Indicates whether the connection has been Approved/Rejected/Removed by
    /// the owner of the service.
    /// </summary>
    public BicepValue<PostgreSqlFlexibleServersPrivateEndpointServiceConnectionStatus> Status
    {
        get { Initialize(); return _status; }
        set { Initialize(); _status.Assign(value); }
    }

    /// <summary>
    /// The reason for approval/rejection of the connection.
    /// </summary>
    public BicepValue<string> Description
    {
        get { Initialize(); return _description; }
        set { Initialize(); _description.Assign(value); }
    }

    /// <summary>
    /// A message indicating if changes on the service provider require any
    /// updates on the consumer.
    /// </summary>
    public BicepValue<string> ActionsRequired
    {
        get { Initialize(); return _actionsRequired; }
        set { Initialize(); _actionsRequired.Assign(value); }
    }

    /// <summary>
    /// Creates a new
    /// PostgreSqlFlexibleServersPrivateLinkServiceConnectionState.
    /// </summary>
    public PostgreSqlFlexibleServersPrivateLinkServiceConnectionState()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of
    /// PostgreSqlFlexibleServersPrivateLinkServiceConnectionState.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _status = DefineProperty<PostgreSqlFlexibleServersPrivateEndpointServiceConnectionStatus>(nameof(Status), ["status"]);
        _description = DefineProperty<string>(nameof(Description), ["description"]);
        _actionsRequired = DefineProperty<string>(nameof(ActionsRequired), ["actionsRequired"]);
    }
}
