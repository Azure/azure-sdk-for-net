// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.EventGrid;

/// <summary>
/// The change history of the resource move.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)] // Removed from Preview
public partial class ResourceMoveChangeHistory : ProvisionableConstruct
{
    /// <summary>
    /// Azure subscription ID of the resource.
    /// </summary>
    public BicepValue<string> AzureSubscriptionId
    {
        get { Initialize(); return _azureSubscriptionId!; }
        set { Initialize(); _azureSubscriptionId!.Assign(value); }
    }
    private BicepValue<string>? _azureSubscriptionId;

    /// <summary>
    /// Azure Resource Group of the resource.
    /// </summary>
    public BicepValue<string> ResourceGroupName
    {
        get { Initialize(); return _resourceGroupName!; }
        set { Initialize(); _resourceGroupName!.Assign(value); }
    }
    private BicepValue<string>? _resourceGroupName;

    /// <summary>
    /// UTC timestamp of when the resource was changed.
    /// </summary>
    public BicepValue<DateTimeOffset> ChangedTimeUtc
    {
        get { Initialize(); return _changedTimeUtc!; }
        set { Initialize(); _changedTimeUtc!.Assign(value); }
    }
    private BicepValue<DateTimeOffset>? _changedTimeUtc;

    /// <summary>
    /// Creates a new ResourceMoveChangeHistory.
    /// </summary>
    public ResourceMoveChangeHistory()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of ResourceMoveChangeHistory.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _azureSubscriptionId = DefineProperty<string>("AzureSubscriptionId", ["azureSubscriptionId"]);
        _resourceGroupName = DefineProperty<string>("ResourceGroupName", ["resourceGroupName"]);
        _changedTimeUtc = DefineProperty<DateTimeOffset>("ChangedTimeUtc", ["changedTimeUtc"]);
    }
}
