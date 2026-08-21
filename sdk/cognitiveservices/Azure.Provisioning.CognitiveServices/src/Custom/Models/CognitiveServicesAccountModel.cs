// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;

namespace Azure.Provisioning.CognitiveServices;

// TypeSpec still defines AccountModel as part of ModelsOperationGroup.list, but the provisioning
// emitter excludes models that are reachable only from provider actions rather than ARM resource
// properties. Keep the 1.2.0 type and Bicep mappings for API compatibility.
/// <summary>
/// Cognitive Services account Model.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
[Obsolete("This type is obsolete and will be removed in a future release.")]
public partial class CognitiveServicesAccountModel : CognitiveServicesAccountDeploymentModel
{
    private CognitiveServicesAccountDeploymentModel _baseModel;
    private BicepValue<bool> _isDefaultVersion;
    private BicepList<CognitiveServicesModelSku> _skus;
    private BicepValue<int> _maxCapacity;
    private BicepDictionary<string> _capabilities;
    private BicepDictionary<string> _finetuneCapabilities;
    private ServiceAccountModelDeprecationInfo _deprecation;
    private BicepValue<ModelLifecycleStatus> _lifecycleStatus;
    private SystemData _systemData;

    /// <summary>
    /// Properties of Cognitive Services account deployment model.
    /// </summary>
    public CognitiveServicesAccountDeploymentModel BaseModel
    {
        get { Initialize(); return _baseModel; }
        set { Initialize(); AssignOrReplace(ref _baseModel, value); }
    }

    /// <summary>
    /// If the model is default version.
    /// </summary>
    public BicepValue<bool> IsDefaultVersion
    {
        get { Initialize(); return _isDefaultVersion; }
        set { Initialize(); _isDefaultVersion.Assign(value); }
    }

    /// <summary>
    /// The list of Model Sku.
    /// </summary>
    public BicepList<CognitiveServicesModelSku> Skus
    {
        get { Initialize(); return _skus; }
        set { Initialize(); _skus.Assign(value); }
    }

    /// <summary>
    /// The max capacity.
    /// </summary>
    public BicepValue<int> MaxCapacity
    {
        get { Initialize(); return _maxCapacity; }
        set { Initialize(); _maxCapacity.Assign(value); }
    }

    /// <summary>
    /// The capabilities.
    /// </summary>
    public BicepDictionary<string> Capabilities
    {
        get { Initialize(); return _capabilities; }
        set { Initialize(); _capabilities.Assign(value); }
    }

    /// <summary>
    /// The capabilities for finetune models.
    /// </summary>
    public BicepDictionary<string> FinetuneCapabilities
    {
        get { Initialize(); return _finetuneCapabilities; }
        set { Initialize(); _finetuneCapabilities.Assign(value); }
    }

    /// <summary>
    /// Cognitive Services account ModelDeprecationInfo.
    /// </summary>
    public ServiceAccountModelDeprecationInfo Deprecation
    {
        get { Initialize(); return _deprecation; }
        set { Initialize(); AssignOrReplace(ref _deprecation, value); }
    }

    /// <summary>
    /// Model lifecycle status.
    /// </summary>
    public BicepValue<ModelLifecycleStatus> LifecycleStatus
    {
        get { Initialize(); return _lifecycleStatus; }
        set { Initialize(); _lifecycleStatus.Assign(value); }
    }

    /// <summary>
    /// Metadata pertaining to creation and last modification of the resource.
    /// </summary>
    public SystemData SystemData
    {
        get { Initialize(); return _systemData; }
    }

    /// <summary>
    /// Creates a new CognitiveServicesAccountModel.
    /// </summary>
    public CognitiveServicesAccountModel()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of
    /// CognitiveServicesAccountModel.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _baseModel = DefineModelProperty<CognitiveServicesAccountDeploymentModel>("BaseModel", ["baseModel"]);
        _isDefaultVersion = DefineProperty<bool>("IsDefaultVersion", ["isDefaultVersion"]);
        _skus = DefineListProperty<CognitiveServicesModelSku>("Skus", ["skus"]);
        _maxCapacity = DefineProperty<int>("MaxCapacity", ["maxCapacity"]);
        _capabilities = DefineDictionaryProperty<string>("Capabilities", ["capabilities"]);
        _finetuneCapabilities = DefineDictionaryProperty<string>("FinetuneCapabilities", ["finetuneCapabilities"]);
        _deprecation = DefineModelProperty<ServiceAccountModelDeprecationInfo>("Deprecation", ["deprecation"]);
        _lifecycleStatus = DefineProperty<ModelLifecycleStatus>("LifecycleStatus", ["lifecycleStatus"]);
        _systemData = DefineModelProperty<SystemData>("SystemData", ["systemData"], isOutput: true);
    }
}
