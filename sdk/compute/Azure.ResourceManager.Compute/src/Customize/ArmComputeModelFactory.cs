// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Compute.Models
{
    public static partial class ArmComputeModelFactory
    {
        // ---------------------------------------------------------------------
        // Hand-authored back-compat ModelFactory overloads.
        //
        // The generator emits these EBN overloads automatically when a primary
        // factory method's signature changes against the previously-shipped
        // contract. After the TypeSpec migration, several primaries had params
        // renamed/reordered/added, and the auto-generated forwarding bodies do
        // not compile. See microsoft/typespec#10595.
        //
        // Until the generator emits valid bodies (or skips emission entirely),
        // these overloads are placed here. The generator detects a user-supplied
        // member with the same signature and skips re-emitting the broken one.
        //
        // NOTE: this justification applies only to the methods in this region.
        // Methods added below for unrelated reasons should carry their own
        // explanation.
        // ---------------------------------------------------------------------

        /// <summary> Initializes a new instance of <see cref="Compute.SharedGalleryImageData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SharedGalleryImageData SharedGalleryImageData(string name, AzureLocation? location, string uniqueId, SupportedOperatingSystemType? osType, OperatingSystemStateType? osState, DateTimeOffset? endOfLifeOn, GalleryImageIdentifier identifier, RecommendedMachineConfiguration recommended, IEnumerable<string> disallowedDiskTypes, HyperVGeneration? hyperVGeneration, IEnumerable<GalleryImageFeature> features, ImagePurchasePlan purchasePlan, ArchitectureType? architecture, Uri privacyStatementUri, string eula, IReadOnlyDictionary<string, string> artifactTags)
        {
            return SharedGalleryImageData(
                name: name,
                location: location,
                uniqueId: uniqueId,
                osType: osType,
                osState: osState,
                endOfLifeOn: endOfLifeOn,
                imageIdentifier: identifier,
                recommended: recommended,
                hyperVGeneration: hyperVGeneration,
                features: features,
                purchasePlan: purchasePlan,
                architecture: architecture,
                privacyStatementUri: privacyStatementUri,
                eula: eula,
                artifactTags: artifactTags?.ToDictionary(p => p.Key, p => p.Value),
                disallowedDiskTypes: disallowedDiskTypes);
        }

        /// <summary> Initializes a new instance of <see cref="Compute.SharedGalleryImageData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SharedGalleryImageData SharedGalleryImageData(string name, AzureLocation? location, string uniqueId, SupportedOperatingSystemType? osType, OperatingSystemStateType? osState, DateTimeOffset? endOfLifeOn, GalleryImageIdentifier identifier, RecommendedMachineConfiguration recommended, IEnumerable<string> disallowedDiskTypes, HyperVGeneration? hyperVGeneration, IEnumerable<GalleryImageFeature> features, ImagePurchasePlan purchasePlan, ArchitectureType? architecture, Uri privacyStatementUri, string eula)
        {
            return SharedGalleryImageData(
                name: name,
                location: location,
                uniqueId: uniqueId,
                osType: osType,
                osState: osState,
                endOfLifeOn: endOfLifeOn,
                imageIdentifier: identifier,
                recommended: recommended,
                hyperVGeneration: hyperVGeneration,
                features: features,
                purchasePlan: purchasePlan,
                architecture: architecture,
                privacyStatementUri: privacyStatementUri,
                eula: eula,
                artifactTags: default,
                disallowedDiskTypes: disallowedDiskTypes);
        }

        /// <summary> Initializes a new instance of <see cref="Compute.RestorePointData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RestorePointData RestorePointData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IEnumerable<WritableSubResource> excludeDisks, RestorePointSourceMetadata sourceMetadata, string provisioningState, ConsistencyModeType? consistencyMode, DateTimeOffset? timeCreated, ResourceIdentifier sourceRestorePointId, RestorePointInstanceView instanceView)
        {
            return RestorePointData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                excludeDisks: excludeDisks,
                sourceMetadata: sourceMetadata,
                provisioningState: provisioningState,
                consistencyMode: consistencyMode,
                timeCreated: timeCreated,
                sourceRestorePointId: sourceRestorePointId,
                instanceView: instanceView,
                instantAccessDurationMinutes: default);
        }

        /// <summary> Initializes a new instance of <see cref="Compute.CapacityReservationGroupData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CapacityReservationGroupData CapacityReservationGroupData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, IEnumerable<string> zones, IEnumerable<SubResource> capacityReservations, IEnumerable<SubResource> virtualMachinesAssociated, CapacityReservationGroupInstanceView instanceView, IEnumerable<WritableSubResource> sharingSubscriptionIds)
        {
            return CapacityReservationGroupData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                tags: tags,
                location: location,
                zones: zones,
                capacityReservations: capacityReservations,
                virtualMachinesAssociated: virtualMachinesAssociated,
                instanceView: instanceView,
                sharingSubscriptionIds: sharingSubscriptionIds,
                reservationType: default);
        }

        /// <summary> Initializes a new instance of <see cref="Models.CapacityReservationGroupPatch"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CapacityReservationGroupPatch CapacityReservationGroupPatch(IDictionary<string, string> tags, IEnumerable<SubResource> capacityReservations, IEnumerable<SubResource> virtualMachinesAssociated, CapacityReservationGroupInstanceView instanceView, IEnumerable<WritableSubResource> sharingSubscriptionIds)
        {
            return CapacityReservationGroupPatch(
                tags: tags,
                capacityReservations: capacityReservations,
                virtualMachinesAssociated: virtualMachinesAssociated,
                instanceView: instanceView,
                sharingSubscriptionIds: sharingSubscriptionIds,
                reservationType: default);
        }

        /// <summary> Initializes a new instance of <see cref="Compute.CapacityReservationData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CapacityReservationData CapacityReservationData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ComputeSku sku, IEnumerable<string> zones, string reservationId, int? platformFaultDomainCount, IEnumerable<SubResource> virtualMachinesAssociated, DateTimeOffset? provisioningOn, string provisioningState, CapacityReservationInstanceView instanceView, DateTimeOffset? timeCreated)
        {
            return CapacityReservationData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                tags: tags,
                location: location,
                sku: sku,
                zones: zones,
                reservationId: reservationId,
                platformFaultDomainCount: platformFaultDomainCount,
                virtualMachinesAssociated: virtualMachinesAssociated,
                provisioningOn: provisioningOn,
                provisioningState: provisioningState,
                instanceView: instanceView,
                timeCreated: timeCreated,
                scheduleProfile: default);
        }

        /// <summary> Initializes a new instance of <see cref="Models.CapacityReservationPatch"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CapacityReservationPatch CapacityReservationPatch(IDictionary<string, string> tags, ComputeSku sku, string reservationId, int? platformFaultDomainCount, IEnumerable<SubResource> virtualMachinesAssociated, DateTimeOffset? provisioningOn, string provisioningState, CapacityReservationInstanceView instanceView, DateTimeOffset? timeCreated)
        {
            return CapacityReservationPatch(
                tags: tags,
                sku: sku,
                reservationId: reservationId,
                platformFaultDomainCount: platformFaultDomainCount,
                virtualMachinesAssociated: virtualMachinesAssociated,
                provisioningOn: provisioningOn,
                provisioningState: provisioningState,
                instanceView: instanceView,
                timeCreated: timeCreated,
                scheduleProfile: default);
        }

        /// <summary> Initializes a new instance of <see cref="Compute.ManagedDiskData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ManagedDiskData ManagedDiskData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ResourceIdentifier managedBy, IEnumerable<ResourceIdentifier> managedByExtended, DiskSku sku, IEnumerable<string> zones, ExtendedLocation extendedLocation, DateTimeOffset? timeCreated, SupportedOperatingSystemType? osType, HyperVGeneration? hyperVGeneration, DiskPurchasePlan purchasePlan, SupportedCapabilities supportedCapabilities, DiskCreationData creationData, int? diskSizeGB, long? diskSizeBytes, string uniqueId, EncryptionSettingsGroup encryptionSettingsGroup, string provisioningState, long? diskIopsReadWrite, long? diskMBpsReadWrite, long? diskIopsReadOnly, long? diskMBpsReadOnly, DiskState? diskState, DiskEncryption encryption, int? maxShares, IEnumerable<ShareInfoElement> shareInfo, NetworkAccessPolicy? networkAccessPolicy, ResourceIdentifier diskAccessId, DateTimeOffset? burstingEnabledOn, string tier, bool? burstingEnabled, string propertyUpdatesInProgressTargetTier, bool? supportsHibernation, DiskSecurityProfile securityProfile, float? completionPercent, DiskPublicNetworkAccess? publicNetworkAccess, DataAccessAuthMode? dataAccessAuthMode, bool? isOptimizedForFrequentAttach, DateTimeOffset? lastOwnershipUpdateOn)
        {
            return ManagedDiskData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                tags: tags,
                location: location,
                managedBy: managedBy,
                managedByExtended: managedByExtended,
                sku: sku,
                zones: zones,
                extendedLocation: extendedLocation,
                timeCreated: timeCreated,
                osType: osType,
                hyperVGeneration: hyperVGeneration,
                purchasePlan: purchasePlan,
                supportedCapabilities: supportedCapabilities,
                creationData: creationData,
                diskSizeGB: diskSizeGB,
                diskSizeBytes: diskSizeBytes,
                uniqueId: uniqueId,
                encryptionSettingsGroup: encryptionSettingsGroup,
                provisioningState: provisioningState,
                diskIopsReadWrite: diskIopsReadWrite,
                diskMBpsReadWrite: diskMBpsReadWrite,
                diskIopsReadOnly: diskIopsReadOnly,
                diskMBpsReadOnly: diskMBpsReadOnly,
                diskState: diskState,
                encryption: encryption,
                maxShares: maxShares,
                shareInfo: shareInfo,
                networkAccessPolicy: networkAccessPolicy,
                diskAccessId: diskAccessId,
                burstingEnabledOn: burstingEnabledOn,
                tier: tier,
                burstingEnabled: burstingEnabled,
                propertyUpdatesInProgressTargetTier: propertyUpdatesInProgressTargetTier,
                supportsHibernation: supportsHibernation,
                securityProfile: securityProfile,
                completionPercent: completionPercent,
                publicNetworkAccess: publicNetworkAccess,
                dataAccessAuthMode: dataAccessAuthMode,
                isOptimizedForFrequentAttach: isOptimizedForFrequentAttach,
                lastOwnershipUpdateOn: lastOwnershipUpdateOn,
                availabilityActionOnDiskDelay: default);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ManagedDiskPatch"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ManagedDiskPatch ManagedDiskPatch(IDictionary<string, string> tags, DiskSku sku, SupportedOperatingSystemType? osType, int? diskSizeGB, EncryptionSettingsGroup encryptionSettingsGroup, long? diskIopsReadWrite, long? diskMBpsReadWrite, long? diskIopsReadOnly, long? diskMBpsReadOnly, int? maxShares, DiskEncryption encryption, NetworkAccessPolicy? networkAccessPolicy, ResourceIdentifier diskAccessId, string tier, bool? burstingEnabled, DiskPurchasePlan purchasePlan, SupportedCapabilities supportedCapabilities, string propertyUpdatesInProgressTargetTier, bool? supportsHibernation, DiskPublicNetworkAccess? publicNetworkAccess, DataAccessAuthMode? dataAccessAuthMode, bool? isOptimizedForFrequentAttach)
        {
            return ManagedDiskPatch(
                tags: tags,
                sku: sku,
                osType: osType,
                diskSizeGB: diskSizeGB,
                encryptionSettingsGroup: encryptionSettingsGroup,
                diskIopsReadWrite: diskIopsReadWrite,
                diskMBpsReadWrite: diskMBpsReadWrite,
                diskIopsReadOnly: diskIopsReadOnly,
                diskMBpsReadOnly: diskMBpsReadOnly,
                maxShares: maxShares,
                encryption: encryption,
                networkAccessPolicy: networkAccessPolicy,
                diskAccessId: diskAccessId,
                tier: tier,
                burstingEnabled: burstingEnabled,
                purchasePlan: purchasePlan,
                supportedCapabilities: supportedCapabilities,
                propertyUpdatesInProgressTargetTier: propertyUpdatesInProgressTargetTier,
                supportsHibernation: supportsHibernation,
                publicNetworkAccess: publicNetworkAccess,
                dataAccessAuthMode: dataAccessAuthMode,
                isOptimizedForFrequentAttach: isOptimizedForFrequentAttach,
                availabilityActionOnDiskDelay: default);
        }

        /// <summary> Initializes a new instance of <see cref="Compute.SnapshotData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SnapshotData SnapshotData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string managedBy, SnapshotSku sku, ExtendedLocation extendedLocation, DateTimeOffset? timeCreated, SupportedOperatingSystemType? osType, HyperVGeneration? hyperVGeneration, DiskPurchasePlan purchasePlan, SupportedCapabilities supportedCapabilities, DiskCreationData creationData, int? diskSizeGB, long? diskSizeBytes, DiskState? diskState, string uniqueId, EncryptionSettingsGroup encryptionSettingsGroup, string provisioningState, bool? incremental, string incrementalSnapshotFamilyId, DiskEncryption encryption, NetworkAccessPolicy? networkAccessPolicy, ResourceIdentifier diskAccessId, DiskSecurityProfile securityProfile, bool? supportsHibernation, DiskPublicNetworkAccess? publicNetworkAccess, float? completionPercent, CopyCompletionError copyCompletionError, DataAccessAuthMode? dataAccessAuthMode)
        {
            return SnapshotData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                tags: tags,
                location: location,
                managedBy: managedBy,
                sku: sku,
                extendedLocation: extendedLocation,
                timeCreated: timeCreated,
                osType: osType,
                hyperVGeneration: hyperVGeneration,
                purchasePlan: purchasePlan,
                supportedCapabilities: supportedCapabilities,
                creationData: creationData,
                diskSizeGB: diskSizeGB,
                diskSizeBytes: diskSizeBytes,
                diskState: diskState,
                uniqueId: uniqueId,
                encryptionSettingsGroup: encryptionSettingsGroup,
                provisioningState: provisioningState,
                incremental: incremental,
                incrementalSnapshotFamilyId: incrementalSnapshotFamilyId,
                encryption: encryption,
                networkAccessPolicy: networkAccessPolicy,
                diskAccessId: diskAccessId,
                securityProfile: securityProfile,
                supportsHibernation: supportsHibernation,
                publicNetworkAccess: publicNetworkAccess,
                completionPercent: completionPercent,
                copyCompletionError: copyCompletionError,
                dataAccessAuthMode: dataAccessAuthMode,
                snapshotAccessState: default);
        }

        /// <summary> Initializes a new instance of <see cref="Compute.AvailabilitySetData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AvailabilitySetData AvailabilitySetData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ComputeSku sku, int? platformUpdateDomainCount, int? platformFaultDomainCount, IEnumerable<WritableSubResource> virtualMachines, ResourceIdentifier proximityPlacementGroupId, IEnumerable<InstanceViewStatus> statuses, ScheduledEventsPolicy scheduledEventsPolicy)
        {
            return AvailabilitySetData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                tags: tags,
                location: location,
                sku: sku,
                platformUpdateDomainCount: platformUpdateDomainCount,
                platformFaultDomainCount: platformFaultDomainCount,
                virtualMachines: virtualMachines,
                proximityPlacementGroupId: proximityPlacementGroupId,
                statuses: statuses,
                scheduledEventsPolicy: scheduledEventsPolicy,
                virtualMachineScaleSetMigrationInfo: default);
        }

        /// <summary> Initializes a new instance of <see cref="Models.AvailabilitySetPatch"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AvailabilitySetPatch AvailabilitySetPatch(IDictionary<string, string> tags, ComputeSku sku, int? platformUpdateDomainCount, int? platformFaultDomainCount, IEnumerable<WritableSubResource> virtualMachines, ResourceIdentifier proximityPlacementGroupId, IEnumerable<InstanceViewStatus> statuses, ScheduledEventsPolicy scheduledEventsPolicy)
        {
            return AvailabilitySetPatch(
                tags: tags,
                sku: sku,
                platformUpdateDomainCount: platformUpdateDomainCount,
                platformFaultDomainCount: platformFaultDomainCount,
                virtualMachines: virtualMachines,
                proximityPlacementGroupId: proximityPlacementGroupId,
                statuses: statuses,
                scheduledEventsPolicy: scheduledEventsPolicy,
                virtualMachineScaleSetMigrationInfo: default);
        }

        /// <summary> Initializes a new instance of <see cref="Compute.AvailabilitySetData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AvailabilitySetData AvailabilitySetData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ComputeSku sku, int? platformUpdateDomainCount, int? platformFaultDomainCount, IEnumerable<WritableSubResource> virtualMachines, ResourceIdentifier proximityPlacementGroupId, IEnumerable<InstanceViewStatus> statuses)
        {
            return AvailabilitySetData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                tags: tags,
                location: location,
                sku: sku,
                platformUpdateDomainCount: platformUpdateDomainCount,
                platformFaultDomainCount: platformFaultDomainCount,
                virtualMachines: virtualMachines,
                proximityPlacementGroupId: proximityPlacementGroupId,
                statuses: statuses,
                scheduledEventsPolicy: default,
                virtualMachineScaleSetMigrationInfo: default);
        }

        /// <summary> Initializes a new instance of <see cref="Models.AvailabilitySetPatch"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AvailabilitySetPatch AvailabilitySetPatch(IDictionary<string, string> tags, ComputeSku sku, int? platformUpdateDomainCount, int? platformFaultDomainCount, IEnumerable<WritableSubResource> virtualMachines, ResourceIdentifier proximityPlacementGroupId, IEnumerable<InstanceViewStatus> statuses)
        {
            return AvailabilitySetPatch(
                tags: tags,
                sku: sku,
                platformUpdateDomainCount: platformUpdateDomainCount,
                platformFaultDomainCount: platformFaultDomainCount,
                virtualMachines: virtualMachines,
                proximityPlacementGroupId: proximityPlacementGroupId,
                statuses: statuses,
                scheduledEventsPolicy: default,
                virtualMachineScaleSetMigrationInfo: default);
        }

        /// <summary> Initializes a new instance of <see cref="Compute.GalleryData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static GalleryData GalleryData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string description, string identifierUniqueName, GalleryProvisioningState? provisioningState, SharingProfile sharingProfile, bool? isSoftDeleteEnabled, SharingStatus sharingStatus)
        {
            return GalleryData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                tags: tags,
                location: location,
                identity: default,
                description: description,
                identifierUniqueName: identifierUniqueName,
                provisioningState: provisioningState,
                sharingProfile: sharingProfile,
                isSoftDeleteEnabled: isSoftDeleteEnabled,
                sharingStatus: sharingStatus);
        }

        /// <summary> Initializes a new instance of <see cref="Compute.GalleryImageData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static GalleryImageData GalleryImageData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string description, string eula, Uri privacyStatementUri, Uri releaseNoteUri, SupportedOperatingSystemType? osType, OperatingSystemStateType? osState, HyperVGeneration? hyperVGeneration, DateTimeOffset? endOfLifeOn, GalleryImageIdentifier identifier, RecommendedMachineConfiguration recommended, IEnumerable<string> disallowedDiskTypes, ImagePurchasePlan purchasePlan, GalleryProvisioningState? provisioningState, IEnumerable<GalleryImageFeature> features, ArchitectureType? architecture)
        {
            return GalleryImageData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                tags: tags,
                location: location,
                description: description,
                eula: eula,
                privacyStatementUri: privacyStatementUri,
                releaseNoteUri: releaseNoteUri,
                osType: osType,
                osState: osState,
                hyperVGeneration: hyperVGeneration,
                endOfLifeOn: endOfLifeOn,
                identifier: identifier,
                recommended: recommended,
                disallowedDiskTypes: disallowedDiskTypes,
                purchasePlan: purchasePlan,
                provisioningState: provisioningState,
                features: features,
                architecture: architecture,
                allowUpdateImage: default);
        }
    }
}
