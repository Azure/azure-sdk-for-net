// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

using Azure.Provisioning;
using Azure.Provisioning.Primitives;
using System;

namespace Azure.Provisioning.CognitiveServices;

/// <summary>
/// The multiregion settings Cognitive Services account.
/// </summary>
public partial class CognitiveServicesMultiRegionSettings : ProvisionableConstruct
{
    /// <summary>
    /// Multiregion routing methods.
    /// </summary>
    public BicepValue<CognitiveServicesRoutingMethod> RoutingMethod { get => _routingMethod; set => _routingMethod.Assign(value); }
    private readonly BicepValue<CognitiveServicesRoutingMethod> _routingMethod;

    /// <summary>
    /// Gets the regions.
    /// </summary>
    public BicepList<CognitiveServicesRegionSetting> Regions { get => _regions; set => _regions.Assign(value); }
    private readonly BicepList<CognitiveServicesRegionSetting> _regions;

    /// <summary>
    /// Creates a new CognitiveServicesMultiRegionSettings.
    /// </summary>
    public CognitiveServicesMultiRegionSettings()
    {
        _routingMethod = BicepValue<CognitiveServicesRoutingMethod>.DefineProperty(this, "RoutingMethod", ["routingMethod"]);
        _regions = BicepList<CognitiveServicesRegionSetting>.DefineProperty(this, "Regions", ["regions"]);
    }
}
