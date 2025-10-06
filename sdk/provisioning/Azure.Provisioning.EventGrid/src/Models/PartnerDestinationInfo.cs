// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ComponentModel;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.EventGrid;

/// <summary>
/// Properties of the corresponding partner destination of a Channel.
/// Please note
/// Azure.ResourceManager.EventGrid.Models.PartnerDestinationInfo is the base
/// class. According to the scenario, a derived class of the base class might
/// need to be assigned here, or this property needs to be casted to one of
/// the possible derived classes.             The available derived classes
/// include
/// Azure.ResourceManager.EventGrid.Models.WebhookPartnerDestinationInfo.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)] // Removed from Preview
public partial class PartnerDestinationInfo : ProvisionableConstruct
{
    /// <summary>
    /// Azure subscription ID of the subscriber. The partner destination
    /// associated with the channel will be             created under this
    /// Azure subscription.
    /// </summary>
    public BicepValue<string> AzureSubscriptionId
    {
        get { Initialize(); return _azureSubscriptionId!; }
        set { Initialize(); _azureSubscriptionId!.Assign(value); }
    }
    private BicepValue<string>? _azureSubscriptionId;

    /// <summary>
    /// Azure Resource Group of the subscriber. The partner destination
    /// associated with the channel will be             created under this
    /// resource group.
    /// </summary>
    public BicepValue<string> ResourceGroupName
    {
        get { Initialize(); return _resourceGroupName!; }
        set { Initialize(); _resourceGroupName!.Assign(value); }
    }
    private BicepValue<string>? _resourceGroupName;

    /// <summary>
    /// Name of the partner destination associated with the channel.
    /// </summary>
    public BicepValue<string> Name
    {
        get { Initialize(); return _name!; }
        set { Initialize(); _name!.Assign(value); }
    }
    private BicepValue<string>? _name;

    /// <summary>
    /// Additional context of the partner destination endpoint.
    /// </summary>
    public BicepValue<string> EndpointServiceContext
    {
        get { Initialize(); return _endpointServiceContext!; }
        set { Initialize(); _endpointServiceContext!.Assign(value); }
    }
    private BicepValue<string>? _endpointServiceContext;

    /// <summary>
    /// Change history of the resource move.
    /// </summary>
    public BicepList<ResourceMoveChangeHistory> ResourceMoveChangeHistory
    {
        get { Initialize(); return _resourceMoveChangeHistory!; }
        set { Initialize(); _resourceMoveChangeHistory!.Assign(value); }
    }
    private BicepList<ResourceMoveChangeHistory>? _resourceMoveChangeHistory;

    /// <summary>
    /// Creates a new PartnerDestinationInfo.
    /// </summary>
    public PartnerDestinationInfo()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of PartnerDestinationInfo.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _azureSubscriptionId = DefineProperty<string>("AzureSubscriptionId", ["azureSubscriptionId"]);
        _resourceGroupName = DefineProperty<string>("ResourceGroupName", ["resourceGroupName"]);
        _name = DefineProperty<string>("Name", ["name"]);
        _endpointServiceContext = DefineProperty<string>("EndpointServiceContext", ["endpointServiceContext"]);
        _resourceMoveChangeHistory = DefineListProperty<ResourceMoveChangeHistory>("ResourceMoveChangeHistory", ["resourceMoveChangeHistory"]);
    }
}
