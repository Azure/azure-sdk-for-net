// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;

#pragma warning disable CS0618 // compatibility types intentionally reference each other

namespace Azure.Provisioning.ContainerRegistry;

/// <summary>
/// The properties of a task step.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is deprecated and will be removed in a future version. Use Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryFileTaskStep from the Azure.Provisioning.ContainerRegistry.Tasks package instead.")]
public partial class ContainerRegistryFileTaskStep : ContainerRegistryTaskStepProperties
{
    /// <summary>
    /// The task template/definition file path relative to the source context.
    /// </summary>
    public BicepValue<string> TaskFilePath
    {
        get { Initialize(); return _taskFilePath!; }
        set { Initialize(); _taskFilePath!.Assign(value); }
    }
    private BicepValue<string>? _taskFilePath;

    /// <summary>
    /// The task values/parameters file path relative to the source context.
    /// </summary>
    public BicepValue<string> ValuesFilePath
    {
        get { Initialize(); return _valuesFilePath!; }
        set { Initialize(); _valuesFilePath!.Assign(value); }
    }
    private BicepValue<string>? _valuesFilePath;

    /// <summary>
    /// The collection of overridable values that can be passed when running a
    /// task.
    /// </summary>
    public BicepList<ContainerRegistryTaskOverridableValue> Values
    {
        get { Initialize(); return _values!; }
        set { Initialize(); _values!.Assign(value); }
    }
    private BicepList<ContainerRegistryTaskOverridableValue>? _values;

    /// <summary>
    /// Creates a new ContainerRegistryFileTaskStep.
    /// </summary>
    public ContainerRegistryFileTaskStep() : base()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of
    /// ContainerRegistryFileTaskStep.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        DefineProperty<string>("type", ["type"], defaultValue: "FileTask");
        _taskFilePath = DefineProperty<string>("TaskFilePath", ["taskFilePath"]);
        _valuesFilePath = DefineProperty<string>("ValuesFilePath", ["valuesFilePath"]);
        _values = DefineListProperty<ContainerRegistryTaskOverridableValue>("Values", ["values"]);
    }
}

#pragma warning restore CS0618
