// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.CognitiveServices;

// TypeSpec still defines this model under the provider-level models-list response, but the
// provisioning emitter excludes operation-only model graphs. Keep the 1.2.0 type and its
// provisionable property mappings so existing consumers remain source and binary compatible.
/// <summary>
/// The BillingMeterInfo.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
[Obsolete("This type is obsolete and will be removed in a future release.")]
public partial class BillingMeterInfo : ProvisionableConstruct
{
    private BicepValue<string> _name;
    private BicepValue<string> _meterId;
    private BicepValue<string> _unit;

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    public BicepValue<string> Name
    {
        get { Initialize(); return _name; }
        set { Initialize(); _name.Assign(value); }
    }

    /// <summary>
    /// Gets or sets the meter id.
    /// </summary>
    public BicepValue<string> MeterId
    {
        get { Initialize(); return _meterId; }
        set { Initialize(); _meterId.Assign(value); }
    }

    /// <summary>
    /// Gets or sets the unit.
    /// </summary>
    public BicepValue<string> Unit
    {
        get { Initialize(); return _unit; }
        set { Initialize(); _unit.Assign(value); }
    }

    /// <summary>
    /// Creates a new BillingMeterInfo.
    /// </summary>
    public BillingMeterInfo()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of BillingMeterInfo.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _name = DefineProperty<string>("Name", ["name"]);
        _meterId = DefineProperty<string>("MeterId", ["meterId"]);
        _unit = DefineProperty<string>("Unit", ["unit"]);
    }
}
