// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.CognitiveServices;

// TypeSpec still defines ModelDeprecationInfo below the operation-only AccountModel model graph,
// which the provisioning emitter excludes. Keep the 1.2.0 type and its provisionable property
// mappings because CognitiveServicesAccountModel exposed it in the shipped public API.
/// <summary>
/// Cognitive Services account ModelDeprecationInfo.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
[Obsolete("This type is obsolete and will be removed in a future release.")]
public partial class ServiceAccountModelDeprecationInfo : ProvisionableConstruct
{
    private BicepValue<DateTimeOffset> _fineTuneOn;
    private BicepValue<DateTimeOffset> _inferenceOn;

    /// <summary>
    /// The datetime of deprecation of the fineTune Model.
    /// </summary>
    public BicepValue<DateTimeOffset> FineTuneOn
    {
        get { Initialize(); return _fineTuneOn; }
        set { Initialize(); _fineTuneOn.Assign(value); }
    }

    /// <summary>
    /// The datetime of deprecation of the inference Model.
    /// </summary>
    public BicepValue<DateTimeOffset> InferenceOn
    {
        get { Initialize(); return _inferenceOn; }
        set { Initialize(); _inferenceOn.Assign(value); }
    }

    /// <summary>
    /// Creates a new ServiceAccountModelDeprecationInfo.
    /// </summary>
    public ServiceAccountModelDeprecationInfo()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of
    /// ServiceAccountModelDeprecationInfo.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _fineTuneOn = DefineProperty<DateTimeOffset>("FineTuneOn", ["fineTune"]);
        _inferenceOn = DefineProperty<DateTimeOffset>("InferenceOn", ["inference"]);
    }
}
