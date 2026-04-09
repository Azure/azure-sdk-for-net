// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Compute.Models
{
    // Suppress backward-compat overloads that reference internal @flattenProperty types.
    // Generator bug #57525.

    [CodeGenSuppress("SharedGallery", typeof(string), typeof(string), typeof(SharedGalleryIdentifier), typeof(IReadOnlyDictionary<string, string>), typeof(string))]
    [CodeGenSuppress("SharedGalleryImage", typeof(string), typeof(string), typeof(SharedGalleryIdentifier), typeof(OperatingSystemTypes?), typeof(OperatingSystemStateType?), typeof(DateTimeOffset?), typeof(GalleryImageIdentifier), typeof(RecommendedMachineConfiguration), typeof(HyperVGeneration?), typeof(IEnumerable<GalleryImageFeature>), typeof(ImagePurchasePlan), typeof(Architecture?), typeof(string), typeof(string), typeof(IDictionary<string, string>), typeof(IEnumerable<string>), typeof(string))]
    [CodeGenSuppress("SharedGalleryImageVersion", typeof(string), typeof(string), typeof(SharedGalleryIdentifier), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(bool?), typeof(SharedGalleryImageVersionStorageProfile), typeof(IDictionary<string, string>), typeof(string))]
    [CodeGenSuppress("CommunityGallery", typeof(string), typeof(string), typeof(string), typeof(CommunityGalleryIdentifier), typeof(string), typeof(IDictionary<string, string>), typeof(CommunityGalleryMetadata), typeof(string))]
    [CodeGenSuppress("CommunityGalleryImage", typeof(string), typeof(string), typeof(string), typeof(CommunityGalleryIdentifier), typeof(OperatingSystemTypes?), typeof(OperatingSystemStateType?), typeof(DateTimeOffset?), typeof(CommunityGalleryImageIdentifier), typeof(RecommendedMachineConfiguration), typeof(HyperVGeneration?), typeof(IEnumerable<GalleryImageFeature>), typeof(ImagePurchasePlan), typeof(Architecture?), typeof(string), typeof(string), typeof(string), typeof(IDictionary<string, string>), typeof(IEnumerable<string>), typeof(string))]
    [CodeGenSuppress("CommunityGalleryImageVersion", typeof(string), typeof(string), typeof(string), typeof(CommunityGalleryIdentifier), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(bool?), typeof(SharedGalleryImageVersionStorageProfile), typeof(string), typeof(IDictionary<string, string>), typeof(string))]
    // NOTE: Cannot suppress VirtualMachineScaleSetData and VirtualMachineScaleSetVmData overloads
    // because they use Resources.Models.ExtendedLocation which conflicts with Compute.Models.ExtendedLocation
    // in typeof() resolution. These 4 CS0051 errors remain until generator bug #57525 is fixed.
    public static partial class ArmComputeModelFactory
    {
    }
}
