// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.CognitiveServices;

// TypeSpec still defines ModelSku below the operation-only AccountModel model graph, which the
// provisioning emitter excludes. Keep the 1.2.0 type and its provisionable property mappings
// because CognitiveServicesAccountModel exposed it in the shipped public API.
/// <summary>
/// Describes an available Cognitive Services Model SKU.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
[Obsolete("This type is obsolete and will be removed in a future release.")]
public partial class CognitiveServicesModelSku : ProvisionableConstruct
{
    private BicepValue<string> _name;
    private BicepValue<string> _usageName;
    private BicepValue<DateTimeOffset> _deprecationOn;
    private CognitiveServicesCapacityConfig _capacity;
    private BicepList<ServiceAccountCallRateLimit> _rateLimits;
    private BicepList<BillingMeterInfo> _cost;

    /// <summary>
    /// The name of the model SKU.
    /// </summary>
    public BicepValue<string> Name
    {
        get { Initialize(); return _name; }
        set { Initialize(); _name.Assign(value); }
    }

    /// <summary>
    /// The usage name of the model SKU.
    /// </summary>
    public BicepValue<string> UsageName
    {
        get { Initialize(); return _usageName; }
        set { Initialize(); _usageName.Assign(value); }
    }

    /// <summary>
    /// The datetime of deprecation of the model SKU.
    /// </summary>
    public BicepValue<DateTimeOffset> DeprecationOn
    {
        get { Initialize(); return _deprecationOn; }
        set { Initialize(); _deprecationOn.Assign(value); }
    }

    /// <summary>
    /// The capacity configuration.
    /// </summary>
    public CognitiveServicesCapacityConfig Capacity
    {
        get { Initialize(); return _capacity; }
        set { Initialize(); AssignOrReplace(ref _capacity, value); }
    }

    /// <summary>
    /// The list of rateLimit.
    /// </summary>
    public BicepList<ServiceAccountCallRateLimit> RateLimits
    {
        get { Initialize(); return _rateLimits; }
    }

    /// <summary>
    /// The list of billing meter info.
    /// </summary>
    public BicepList<BillingMeterInfo> Cost
    {
        get { Initialize(); return _cost; }
        set { Initialize(); _cost.Assign(value); }
    }

    /// <summary>
    /// Creates a new CognitiveServicesModelSku.
    /// </summary>
    public CognitiveServicesModelSku()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of CognitiveServicesModelSku.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _name = DefineProperty<string>("Name", ["name"]);
        _usageName = DefineProperty<string>("UsageName", ["usageName"]);
        _deprecationOn = DefineProperty<DateTimeOffset>("DeprecationOn", ["deprecationDate"]);
        _capacity = DefineModelProperty<CognitiveServicesCapacityConfig>("Capacity", ["capacity"]);
        _rateLimits = DefineListProperty<ServiceAccountCallRateLimit>("RateLimits", ["rateLimits"], isOutput: true);
        _cost = DefineListProperty<BillingMeterInfo>("Cost", ["cost"]);
    }
}
