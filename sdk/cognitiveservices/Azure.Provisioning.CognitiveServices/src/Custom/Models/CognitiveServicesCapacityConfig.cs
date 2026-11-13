// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.CognitiveServices;

// TypeSpec still defines CapacityConfig below the operation-only AccountModel model graph, which
// the provisioning emitter excludes. Keep the 1.2.0 type and its provisionable property mappings
// because CognitiveServicesModelSku exposed it in the shipped public API.
/// <summary>
/// The capacity configuration.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
[Obsolete("This type is obsolete and will be removed in a future release.")]
public partial class CognitiveServicesCapacityConfig : ProvisionableConstruct
{
    private BicepValue<int> _minimum;
    private BicepValue<int> _maximum;
    private BicepValue<int> _step;
    private BicepValue<int> _default;
    private BicepList<int> _allowedValues;

    /// <summary>
    /// The minimum capacity.
    /// </summary>
    public BicepValue<int> Minimum
    {
        get { Initialize(); return _minimum; }
        set { Initialize(); _minimum.Assign(value); }
    }

    /// <summary>
    /// The maximum capacity.
    /// </summary>
    public BicepValue<int> Maximum
    {
        get { Initialize(); return _maximum; }
        set { Initialize(); _maximum.Assign(value); }
    }

    /// <summary>
    /// The minimal incremental between allowed values for capacity.
    /// </summary>
    public BicepValue<int> Step
    {
        get { Initialize(); return _step; }
        set { Initialize(); _step.Assign(value); }
    }

    /// <summary>
    /// The default capacity.
    /// </summary>
    public BicepValue<int> Default
    {
        get { Initialize(); return _default; }
        set { Initialize(); _default.Assign(value); }
    }

    /// <summary>
    /// The array of allowed values for capacity.
    /// </summary>
    public BicepList<int> AllowedValues
    {
        get { Initialize(); return _allowedValues; }
        set { Initialize(); _allowedValues.Assign(value); }
    }

    /// <summary>
    /// Creates a new CognitiveServicesCapacityConfig.
    /// </summary>
    public CognitiveServicesCapacityConfig()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of
    /// CognitiveServicesCapacityConfig.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _minimum = DefineProperty<int>("Minimum", ["minimum"]);
        _maximum = DefineProperty<int>("Maximum", ["maximum"]);
        _step = DefineProperty<int>("Step", ["step"]);
        _default = DefineProperty<int>("Default", ["default"]);
        _allowedValues = DefineListProperty<int>("AllowedValues", ["allowedValues"]);
    }
}
