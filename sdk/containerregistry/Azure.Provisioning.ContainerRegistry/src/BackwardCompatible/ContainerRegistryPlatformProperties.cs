// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.Provisioning.Primitives;

#pragma warning disable CS0618 // compatibility types intentionally reference each other

namespace Azure.Provisioning.ContainerRegistry;

/// <summary>
/// The platform properties against which the run has to happen.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is deprecated and will be removed in a future version. Use Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskPlatformProperties from the Azure.Provisioning.ContainerRegistry.Tasks package instead.")]
public partial class ContainerRegistryPlatformProperties : ProvisionableConstruct
{
    /// <summary>
    /// The operating system type required for the run.
    /// </summary>
    public BicepValue<ContainerRegistryOS> OS
    {
        get { Initialize(); return _oS!; }
        set { Initialize(); _oS!.Assign(value); }
    }
    private BicepValue<ContainerRegistryOS>? _oS;

    /// <summary>
    /// The OS architecture.
    /// </summary>
    public BicepValue<ContainerRegistryOSArchitecture> Architecture
    {
        get { Initialize(); return _architecture!; }
        set { Initialize(); _architecture!.Assign(value); }
    }
    private BicepValue<ContainerRegistryOSArchitecture>? _architecture;

    /// <summary>
    /// Variant of the CPU.
    /// </summary>
    public BicepValue<ContainerRegistryCpuVariant> Variant
    {
        get { Initialize(); return _variant!; }
        set { Initialize(); _variant!.Assign(value); }
    }
    private BicepValue<ContainerRegistryCpuVariant>? _variant;

    /// <summary>
    /// Creates a new ContainerRegistryPlatformProperties.
    /// </summary>
    public ContainerRegistryPlatformProperties()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of
    /// ContainerRegistryPlatformProperties.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _oS = DefineProperty<ContainerRegistryOS>("OS", ["os"]);
        _architecture = DefineProperty<ContainerRegistryOSArchitecture>("Architecture", ["architecture"]);
        _variant = DefineProperty<ContainerRegistryCpuVariant>("Variant", ["variant"]);
    }
}

#pragma warning restore CS0618
