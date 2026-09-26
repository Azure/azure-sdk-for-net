// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Network;

/// <summary> The legacy data model for an ExpressRoute link. </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
[Obsolete("This type is deprecated and it will be removed in a future version. Please use ExpressRouteLink instead.")]
public partial class ExpressRouteLinkData : ProvisionableConstruct
{
    private BicepValue<ETag> _eTag;
    private BicepValue<string> _routerName;
    private BicepValue<string> _interfaceName;
    private BicepValue<string> _patchPanelId;
    private BicepValue<string> _rackId;
    private BicepValue<string> _coloLocation;
    private BicepValue<ExpressRouteLinkConnectorType> _connectorType;
    private BicepValue<ExpressRouteLinkAdminState> _adminState;
    private BicepValue<NetworkProvisioningState> _provisioningState;
    private ExpressRouteLinkMacSecConfig _macSecConfig;
    private BicepValue<ResourceIdentifier> _id;
    private BicepValue<string> _name;
    private BicepValue<ResourceType> _resourceType;

    /// <summary> A unique read-only string that changes whenever the resource is updated. </summary>
    public BicepValue<ETag> ETag { get { Initialize(); return _eTag; } }

    /// <summary> Name of Azure router associated with physical port. </summary>
    public BicepValue<string> RouterName { get { Initialize(); return _routerName; } }

    /// <summary> Name of Azure router interface. </summary>
    public BicepValue<string> InterfaceName { get { Initialize(); return _interfaceName; } }

    /// <summary> Mapping between physical port to patch panel port. </summary>
    public BicepValue<string> PatchPanelId { get { Initialize(); return _patchPanelId; } }

    /// <summary> Mapping of physical patch panel to rack. </summary>
    public BicepValue<string> RackId { get { Initialize(); return _rackId; } }

    /// <summary> Cololocation for ExpressRoute Hybrid Direct. </summary>
    public BicepValue<string> ColoLocation { get { Initialize(); return _coloLocation; } }

    /// <summary> Physical fiber port type. </summary>
    public BicepValue<ExpressRouteLinkConnectorType> ConnectorType { get { Initialize(); return _connectorType; } }

    /// <summary> Administrative state of the physical port. </summary>
    public BicepValue<ExpressRouteLinkAdminState> AdminState
    {
        get { Initialize(); return _adminState; }
        set { Initialize(); _adminState.Assign(value); }
    }

    /// <summary> The provisioning state of the ExpressRoute link resource. </summary>
    public BicepValue<NetworkProvisioningState> ProvisioningState { get { Initialize(); return _provisioningState; } }

    /// <summary> MacSec configuration. </summary>
    public ExpressRouteLinkMacSecConfig MacSecConfig
    {
        get { Initialize(); return _macSecConfig; }
        set { Initialize(); AssignOrReplace(ref _macSecConfig, value); }
    }

    /// <summary> Resource ID. </summary>
    public BicepValue<ResourceIdentifier> Id
    {
        get { Initialize(); return _id; }
        set { Initialize(); _id.Assign(value); }
    }

    /// <summary> Resource name. </summary>
    public BicepValue<string> Name
    {
        get { Initialize(); return _name; }
        set { Initialize(); _name.Assign(value); }
    }

    /// <summary> Resource type. </summary>
    public BicepValue<ResourceType> ResourceType { get { Initialize(); return _resourceType; } }

    /// <summary> Creates a new ExpressRouteLinkData. </summary>
    public ExpressRouteLinkData()
    {
    }

    /// <inheritdoc/>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _eTag = DefineProperty<ETag>(nameof(ETag), new string[] { "etag" }, isOutput: true);
        _routerName = DefineProperty<string>(nameof(RouterName), new string[] { "properties", "routerName" }, isOutput: true);
        _interfaceName = DefineProperty<string>(nameof(InterfaceName), new string[] { "properties", "interfaceName" }, isOutput: true);
        _patchPanelId = DefineProperty<string>(nameof(PatchPanelId), new string[] { "properties", "patchPanelId" }, isOutput: true);
        _rackId = DefineProperty<string>(nameof(RackId), new string[] { "properties", "rackId" }, isOutput: true);
        _coloLocation = DefineProperty<string>(nameof(ColoLocation), new string[] { "properties", "coloLocation" }, isOutput: true);
        _connectorType = DefineProperty<ExpressRouteLinkConnectorType>(nameof(ConnectorType), new string[] { "properties", "connectorType" }, isOutput: true);
        _adminState = DefineProperty<ExpressRouteLinkAdminState>(nameof(AdminState), new string[] { "properties", "adminState" });
        _provisioningState = DefineProperty<NetworkProvisioningState>(nameof(ProvisioningState), new string[] { "properties", "provisioningState" }, isOutput: true);
        _macSecConfig = DefineModelProperty<ExpressRouteLinkMacSecConfig>(nameof(MacSecConfig), new string[] { "properties", "macSecConfig" });
        _id = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" });
        _name = DefineProperty<string>(nameof(Name), new string[] { "name" });
        _resourceType = DefineProperty<ResourceType>(nameof(ResourceType), new string[] { "type" }, isOutput: true);
    }
}
