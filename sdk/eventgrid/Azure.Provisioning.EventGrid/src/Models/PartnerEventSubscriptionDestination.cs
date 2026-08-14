// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.EventGrid;

/// <summary>
/// The PartnerEventSubscriptionDestination.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)] // Removed from Preview
public partial class PartnerEventSubscriptionDestination : EventSubscriptionDestination
{
    /// <summary>
    /// The Azure Resource Id that represents the endpoint of a Partner
    /// Destination of an event subscription.
    /// </summary>
    public BicepValue<string> ResourceId
    {
        get { Initialize(); return _resourceId!; }
        set { Initialize(); _resourceId!.Assign(value); }
    }
    private BicepValue<string>? _resourceId;

    /// <summary>
    /// Creates a new PartnerEventSubscriptionDestination.
    /// </summary>
    public PartnerEventSubscriptionDestination() : base()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of
    /// PartnerEventSubscriptionDestination.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        DefineProperty<string>("endpointType", ["endpointType"], defaultValue: "PartnerDestination");
        _resourceId = DefineProperty<string>("ResourceId", ["properties", "resourceId"]);
    }
}
