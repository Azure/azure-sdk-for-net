// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Compute
{
    // Suppress backward-compat overloads that reference internal @flattenProperty types.
    // These are generated incorrectly — the internal types (SharedGalleryIdentifier,
    // CommunityGalleryIdentifier, VirtualMachineScaleSetProperties, VirtualMachineScaleSetVmProperties)
    // should not appear in public method signatures. Generator bug #57525.

    [CodeGenSuppress("SharedGalleryData", typeof(string), typeof(string), typeof(SharedGalleryIdentifier), typeof(IReadOnlyDictionary<string, string>), typeof(string))]
    [CodeGenSuppress("SharedGalleryImageData", typeof(string), typeof(string), typeof(SharedGalleryIdentifier), typeof(OperatingSystemTypes?), typeof(OperatingSystemStateType?), typeof(DateTimeOffset?), typeof(GalleryImageIdentifier), typeof(RecommendedMachineConfiguration), typeof(HyperVGeneration?), typeof(IEnumerable<GalleryImageFeature>), typeof(ImagePurchasePlan), typeof(Architecture?), typeof(string), typeof(string), typeof(IDictionary<string, string>), typeof(IEnumerable<string>), typeof(string))]
    [CodeGenSuppress("SharedGalleryImageVersionData", typeof(string), typeof(string), typeof(SharedGalleryIdentifier), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(bool?), typeof(SharedGalleryImageVersionStorageProfile), typeof(IDictionary<string, string>), typeof(string))]
    [CodeGenSuppress("CommunityGalleryData", typeof(string), typeof(string), typeof(string), typeof(CommunityGalleryIdentifier), typeof(string), typeof(IDictionary<string, string>), typeof(CommunityGalleryMetadata), typeof(string))]
    [CodeGenSuppress("CommunityGalleryImageData", typeof(string), typeof(string), typeof(string), typeof(CommunityGalleryIdentifier), typeof(OperatingSystemTypes?), typeof(OperatingSystemStateType?), typeof(DateTimeOffset?), typeof(CommunityGalleryImageIdentifier), typeof(RecommendedMachineConfiguration), typeof(HyperVGeneration?), typeof(IEnumerable<GalleryImageFeature>), typeof(ImagePurchasePlan), typeof(Architecture?), typeof(string), typeof(string), typeof(string), typeof(IDictionary<string, string>), typeof(IEnumerable<string>), typeof(string))]
    [CodeGenSuppress("CommunityGalleryImageVersionData", typeof(string), typeof(string), typeof(string), typeof(CommunityGalleryIdentifier), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(bool?), typeof(SharedGalleryImageVersionStorageProfile), typeof(string), typeof(IDictionary<string, string>), typeof(string))]
    [CodeGenSuppress("VirtualMachineScaleSetVmData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(string), typeof(ComputeSku), typeof(VirtualMachineScaleSetVmProperties), typeof(ComputePlan), typeof(IEnumerable<VirtualMachineExtensionData>), typeof(IEnumerable<string>), typeof(ManagedServiceIdentity), typeof(string))]
    [CodeGenSuppress("VirtualMachineScaleSetVmData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(VirtualMachineScaleSetVmProperties), typeof(string), typeof(ComputeSku), typeof(ComputePlan), typeof(IEnumerable<VirtualMachineExtensionData>), typeof(IEnumerable<string>), typeof(ManagedServiceIdentity), typeof(string))]
    [CodeGenSuppress("VirtualMachineScaleSetData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(ComputeSku), typeof(ComputePlan), typeof(VirtualMachineScaleSetProperties), typeof(ManagedServiceIdentity), typeof(IEnumerable<string>), typeof(Resources.Models.ExtendedLocation), typeof(string), typeof(VirtualMachinePlacement))]
    [CodeGenSuppress("VirtualMachineScaleSetData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(ComputeSku), typeof(ComputePlan), typeof(VirtualMachineScaleSetProperties), typeof(ManagedServiceIdentity), typeof(IEnumerable<string>), typeof(Resources.Models.ExtendedLocation), typeof(string))]
    public static partial class ArmComputeModelFactory
    {
    }
}
