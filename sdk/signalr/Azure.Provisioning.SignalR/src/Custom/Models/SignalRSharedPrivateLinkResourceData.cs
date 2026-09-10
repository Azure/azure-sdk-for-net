// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;

namespace Azure.Provisioning.SignalR;

// The TypeSpec generator now emits SignalRSharedPrivateLink as a child resource.
// Preserve the previously shipped data model for source and binary compatibility.
/// <summary> The data model for a SignalR shared private link resource. </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
[Obsolete("This class is deprecated and it will be removed in a future version. Please use SignalRSharedPrivateLink instead.")]
public partial class SignalRSharedPrivateLinkResourceData : ProvisionableConstruct
{
    private BicepValue<string> _groupId;
    private BicepValue<ResourceIdentifier> _privateLinkResourceId;
    private BicepValue<SignalRProvisioningState> _provisioningState;
    private BicepValue<string> _requestMessage;
    private BicepValue<SignalRSharedPrivateLinkResourceStatus> _status;
    private BicepValue<ResourceIdentifier> _id;
    private BicepValue<string> _name;
    private SystemData _systemData;

    /// <summary> Gets or sets the provider group identifier. </summary>
    public BicepValue<string> GroupId { get { Initialize(); return _groupId; } set { Initialize(); _groupId.Assign(value); } }

    /// <summary> Gets or sets the private link resource identifier. </summary>
    public BicepValue<ResourceIdentifier> PrivateLinkResourceId { get { Initialize(); return _privateLinkResourceId; } set { Initialize(); _privateLinkResourceId.Assign(value); } }

    /// <summary> Gets the resource provisioning state. </summary>
    public BicepValue<SignalRProvisioningState> ProvisioningState { get { Initialize(); return _provisioningState; } }

    /// <summary> Gets or sets the approval request message. </summary>
    public BicepValue<string> RequestMessage { get { Initialize(); return _requestMessage; } set { Initialize(); _requestMessage.Assign(value); } }

    /// <summary> Gets the shared private link resource status. </summary>
    public BicepValue<SignalRSharedPrivateLinkResourceStatus> Status { get { Initialize(); return _status; } }

    /// <summary> Gets the resource identifier. </summary>
    public BicepValue<ResourceIdentifier> Id { get { Initialize(); return _id; } }

    /// <summary> Gets the resource name. </summary>
    public BicepValue<string> Name { get { Initialize(); return _name; } }

    /// <summary> Gets resource system metadata. </summary>
    public SystemData SystemData { get { Initialize(); return _systemData; } }

    /// <summary> Creates a new instance of <see cref="SignalRSharedPrivateLinkResourceData"/>. </summary>
    public SignalRSharedPrivateLinkResourceData()
    {
    }

    /// <inheritdoc/>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _groupId = DefineProperty<string>(nameof(GroupId), new string[] { "properties", "groupId" });
        _privateLinkResourceId = DefineProperty<ResourceIdentifier>(nameof(PrivateLinkResourceId), new string[] { "properties", "privateLinkResourceId" });
        _provisioningState = DefineProperty<SignalRProvisioningState>(nameof(ProvisioningState), new string[] { "properties", "provisioningState" }, isOutput: true);
        _requestMessage = DefineProperty<string>(nameof(RequestMessage), new string[] { "properties", "requestMessage" });
        _status = DefineProperty<SignalRSharedPrivateLinkResourceStatus>(nameof(Status), new string[] { "properties", "status" }, isOutput: true);
        _id = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" }, isOutput: true);
        _name = DefineProperty<string>(nameof(Name), new string[] { "name" }, isOutput: true);
        _systemData = DefineModelProperty<SystemData>(nameof(SystemData), new string[] { "systemData" }, isOutput: true);
    }
}
