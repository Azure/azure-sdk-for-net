// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Compute.Models;

namespace Azure.Provisioning.Generator.Specifications;

// NOTE: To correctly regenerate Azure.Provisioning.Compute, the mgmt library
// (Azure.ResourceManager.Compute) must first be regenerated with
// `enable-bicep-serialization: true` in its autorest.md to produce WirePath
// attributes. Then switch the PackageReference below to a ProjectReference
// pointing to the local mgmt project before running this generator.
// After generation, restore the PackageReference and revert the mgmt changes.
public class ComputeSpecification() :
    Specification("Compute", typeof(ComputeExtensions), ignorePropertiesWithoutPath: true, serviceDirectory: "compute")
{
    protected override void Customize()
    {
        // Rename single-word types to avoid AZC0012
        CustomizeResource<GalleryResource>(r => r.Name = "ComputeGallery");
        CustomizeResource<SnapshotResource>(r => r.Name = "ComputeSnapshot");

        // CloudService is being deprecated — exclude from first release
        RemoveModel<CloudServiceResource>();

        // Remove output-only properties that create writable containers in schema
        // but are not in Bicep reference (all children are readonly)
        RemoveProperty<ComputePrivateEndpointConnectionResource>("PrivateEndpointId");
        RemoveProperty<DedicatedHostGroupResource>("InstanceViewHosts");

        // Remove AdditionalProperties catch-all dictionaries — not in Bicep reference
        RemoveProperty<VirtualMachineScaleSetProperties>("AdditionalProperties");
        RemoveProperty<VirtualMachineScaleSetUpgradePolicy>("AdditionalProperties");
        RemoveProperty<VirtualMachineScaleSetVmProperties>("AdditionalProperties");
        RemoveProperty<VirtualMachineSizeProperties>("AdditionalProperties");

        // Add WirePath for GallerySource properties — mgmt SDK defines these in
        // customize partial classes without [WirePath] (backward compat wrapper)
        CustomizeProperty<GalleryImageVersionStorageProfile>("GallerySource", p => p.Path = ["source"]);
        CustomizeProperty<GalleryOSDiskImage>("GallerySource", p => p.Path = ["source"]);
        CustomizeProperty<GalleryDataDiskImage>("GallerySource", p => p.Path = ["source"]);

        CustomizeProperty<VirtualMachineScaleSetVmResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
    }
}
