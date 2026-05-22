// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Compute.Models
{
    public static partial class ArmComputeModelFactory
    {
        // ---------------------------------------------------------------------
        // Hand-authored back-compat overloads needed because the previously-
        // shipped contract used IReadOnlyDictionary<string, string> for the
        // artifactTags parameter, but the TypeSpec primary now uses
        // IDictionary<string, string>. Two distinct problems arise:
        //
        // 1) The IReadOnlyDictionary back-compat overloads themselves.
        //    The forwarding body must convert IReadOnlyDictionary into an
        //    IDictionary, but Dictionary<,> implements BOTH interfaces, so
        //    the result of ToDictionary(...) is ambiguous between the primary
        //    and the back-compat overload. We add an explicit
        //    (IDictionary<string, string>) cast to disambiguate.
        //
        // 2) The pre-existing shorter shims (without artifactTags) that were
        //    valid in the previously-shipped contract. Their generated body
        //    forwards using `artifactTags: default`, which becomes ambiguous
        //    once the IReadOnlyDictionary back-compat overload above coexists
        //    with the IDictionary primary. We relocate them here so the cast
        //    `(IDictionary<string, string>)null` can disambiguate the call.
        //
        // Plus VirtualMachineScaleSetVmData below: the primary reorders
        // parameters but reuses the same names, so a generated named-arg
        // forward is ambiguous against the back-compat overload. We use a
        // positional call instead.
        // ---------------------------------------------------------------------

        /// <summary> Initializes a new instance of <see cref="Compute.SharedGalleryImageVersionData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SharedGalleryImageVersionData SharedGalleryImageVersionData(string name, AzureLocation? location, string uniqueId, DateTimeOffset? publishedOn, DateTimeOffset? endOfLifeOn, bool? isExcludedFromLatest, SharedGalleryImageVersionStorageProfile storageProfile, IReadOnlyDictionary<string, string> artifactTags)
        {
            return SharedGalleryImageVersionData(
                name: name,
                location: location,
                uniqueId: uniqueId,
                publishedOn: publishedOn,
                endOfLifeOn: endOfLifeOn,
                isExcludedFromLatest: isExcludedFromLatest,
                storageProfile: storageProfile,
                artifactTags: (IDictionary<string, string>)artifactTags?.ToDictionary(p => p.Key, p => p.Value));
        }

        /// <summary> Initializes a new instance of <see cref="Compute.CommunityGalleryData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CommunityGalleryData CommunityGalleryData(string name, AzureLocation? location, ResourceType? resourceType, string uniqueId, string disclaimer, IReadOnlyDictionary<string, string> artifactTags, CommunityGalleryMetadata communityMetadata)
        {
            return CommunityGalleryData(
                name: name,
                location: location,
                resourceType: resourceType,
                uniqueId: uniqueId,
                disclaimer: disclaimer,
                artifactTags: (IDictionary<string, string>)artifactTags?.ToDictionary(p => p.Key, p => p.Value),
                communityMetadata: communityMetadata);
        }

        /// <summary> Initializes a new instance of <see cref="Compute.CommunityGalleryImageVersionData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CommunityGalleryImageVersionData CommunityGalleryImageVersionData(string name, AzureLocation? location, ResourceType? resourceType, string uniqueId, DateTimeOffset? publishedOn, DateTimeOffset? endOfLifeOn, bool? isExcludedFromLatest, SharedGalleryImageVersionStorageProfile storageProfile, string disclaimer, IReadOnlyDictionary<string, string> artifactTags)
        {
            return CommunityGalleryImageVersionData(
                name: name,
                location: location,
                resourceType: resourceType,
                uniqueId: uniqueId,
                publishedOn: publishedOn,
                endOfLifeOn: endOfLifeOn,
                isExcludedFromLatest: isExcludedFromLatest,
                storageProfile: storageProfile,
                disclaimer: disclaimer,
                artifactTags: (IDictionary<string, string>)artifactTags?.ToDictionary(p => p.Key, p => p.Value));
        }

        /// <summary> Initializes a new instance of <see cref="Compute.VirtualMachineScaleSetVmData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VirtualMachineScaleSetVmData VirtualMachineScaleSetVmData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, VirtualMachineScaleSetVmProperties properties, string instanceId, ComputeSku sku, ComputePlan plan, IEnumerable<VirtualMachineExtensionData> resources, IEnumerable<string> zones, ManagedServiceIdentity identity, string etag)
        {
            // Positional call — see region note above (named-arg ambiguous).
            return VirtualMachineScaleSetVmData(id, name, resourceType, systemData, tags, location, instanceId, sku, properties, plan, resources, zones, identity, etag);
        }

        // Older shim (no artifactTags param). Generated body forwards with
        // `artifactTags: default`, ambiguous against the IReadOnlyDictionary
        // back-compat overload above. Cast to (IDictionary<string, string>)null.
        /// <summary> Initializes a new instance of <see cref="Compute.SharedGalleryImageVersionData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SharedGalleryImageVersionData SharedGalleryImageVersionData(string name, AzureLocation? location, string uniqueId, DateTimeOffset? publishedOn, DateTimeOffset? endOfLifeOn, bool? isExcludedFromLatest, SharedGalleryImageVersionStorageProfile storageProfile)
        {
            return SharedGalleryImageVersionData(
                name: name,
                location: location,
                uniqueId: uniqueId,
                publishedOn: publishedOn,
                endOfLifeOn: endOfLifeOn,
                isExcludedFromLatest: isExcludedFromLatest,
                storageProfile: storageProfile,
                artifactTags: (IDictionary<string, string>)null);
        }

        // Older shim (no artifactTags param). See note above.
        /// <summary> Initializes a new instance of <see cref="Compute.CommunityGalleryData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CommunityGalleryData CommunityGalleryData(string name, AzureLocation? location, ResourceType? resourceType, string uniqueId)
        {
            return CommunityGalleryData(
                name: name,
                location: location,
                resourceType: resourceType,
                uniqueId: uniqueId,
                disclaimer: default,
                artifactTags: (IDictionary<string, string>)null,
                communityMetadata: default);
        }

        // Older shim (no artifactTags param). See note above.
        /// <summary> Initializes a new instance of <see cref="Compute.CommunityGalleryImageVersionData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CommunityGalleryImageVersionData CommunityGalleryImageVersionData(string name, AzureLocation? location, ResourceType? resourceType, string uniqueId, DateTimeOffset? publishedOn, DateTimeOffset? endOfLifeOn, bool? isExcludedFromLatest, SharedGalleryImageVersionStorageProfile storageProfile)
        {
            return CommunityGalleryImageVersionData(
                name: name,
                location: location,
                resourceType: resourceType,
                uniqueId: uniqueId,
                publishedOn: publishedOn,
                endOfLifeOn: endOfLifeOn,
                isExcludedFromLatest: isExcludedFromLatest,
                storageProfile: storageProfile,
                disclaimer: default,
                artifactTags: (IDictionary<string, string>)null);
        }

        // Hand-authored back-compat overload. The generator-emitted forwarding
        // body uses all-named arguments and `artifactTags: default`, which is
        // ambiguous between the IDictionary<string,string> primary and the
        // IReadOnlyDictionary<string,string> back-compat overload. We supply
        // an explicit cast to disambiguate; the generator detects this matching
        // signature and skips re-emitting the broken version.
        /// <summary> Initializes a new instance of <see cref="Compute.CommunityGalleryImageData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CommunityGalleryImageData CommunityGalleryImageData(string name, AzureLocation? location, ResourceType? resourceType, string uniqueId, SupportedOperatingSystemType? osType, OperatingSystemStateType? osState, DateTimeOffset? endOfLifeOn, CommunityGalleryImageIdentifier imageIdentifier, RecommendedMachineConfiguration recommended, IEnumerable<string> disallowedDiskTypes, HyperVGeneration? hyperVGeneration, IEnumerable<GalleryImageFeature> features, ImagePurchasePlan purchasePlan, ArchitectureType? architecture, Uri privacyStatementUri, string eula)
        {
            return CommunityGalleryImageData(
                name: name,
                location: location,
                resourceType: resourceType,
                uniqueId: uniqueId,
                osType: osType,
                osState: osState,
                endOfLifeOn: endOfLifeOn,
                imageIdentifier: imageIdentifier,
                recommended: recommended,
                hyperVGeneration: hyperVGeneration,
                features: features,
                purchasePlan: purchasePlan,
                architecture: architecture,
                privacyStatementUri: privacyStatementUri,
                eula: eula,
                disclaimer: default,
                artifactTags: (IDictionary<string, string>)null,
                disallowedDiskTypes: disallowedDiskTypes);
        }
    }
}
