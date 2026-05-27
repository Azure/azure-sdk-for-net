// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// SA1402 is suppressed for this file: every type below is an intentionally
// identical one-line `protected X(){}` shim, bundled together to make code
// review trivial. See block comment below for full rationale.
#pragma warning disable SA1402 // File may only contain a single type

// =============================================================================
// Back-compat shims for abstract @discriminator base models.
//
// The MTG (Microsoft TypeSpec Generator) emits only a `private protected`
// parameterless constructor on abstract `@discriminator` base classes. To the
// C# compiler/IL this makes the type effectively sealed from outside the
// assembly, which trips two ApiCompat rules against the baseline v1.x
// AutoRest-generated SDK:
//
//   * CannotSealType
//   * CannotMakeMemberNonVirtual (effectively-sealed heuristic)
//
// The legacy AutoRest SDK exposed a `protected` parameterless ctor on each of
// these abstract discriminator bases, so derived subclasses authored outside
// the assembly remained binary-compatible. Restoring that `protected` ctor
// here keeps the public API surface unchanged.
//
// Every type below is a one-line shim with no behavior: just `protected X(){}`.
// They are bundled in this single file (rather than one file per class) to
// make code review trivial: pattern is identical, only the class name varies.
// =============================================================================

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery.Models
{
    public abstract partial class ApplyClusterRecoveryPointProviderSpecificContent
    {
        /// <summary> Initializes a new instance of <see cref="ApplyClusterRecoveryPointProviderSpecificContent"/> for deserialization. </summary>
        protected ApplyClusterRecoveryPointProviderSpecificContent() { }
    }
    public abstract partial class ClusterProviderSpecificRecoveryPointDetails
    {
        /// <summary> Initializes a new instance of <see cref="ClusterProviderSpecificRecoveryPointDetails"/> for deserialization. </summary>
        protected ClusterProviderSpecificRecoveryPointDetails() { }
    }
    public abstract partial class ClusterTestFailoverProviderSpecificContent
    {
        /// <summary> Initializes a new instance of <see cref="ClusterTestFailoverProviderSpecificContent"/> for deserialization. </summary>
        protected ClusterTestFailoverProviderSpecificContent() { }
    }
    public abstract partial class ClusterUnplannedFailoverProviderSpecificContent
    {
        /// <summary> Initializes a new instance of <see cref="ClusterUnplannedFailoverProviderSpecificContent"/> for deserialization. </summary>
        protected ClusterUnplannedFailoverProviderSpecificContent() { }
    }
    public abstract partial class DisableProtectionProviderSpecificContent
    {
        /// <summary> Initializes a new instance of <see cref="DisableProtectionProviderSpecificContent"/> for deserialization. </summary>
        protected DisableProtectionProviderSpecificContent() { }
    }
    public abstract partial class EnableMigrationProviderSpecificContent
    {
        /// <summary> Initializes a new instance of <see cref="EnableMigrationProviderSpecificContent"/> for deserialization. </summary>
        protected EnableMigrationProviderSpecificContent() { }
    }
    public abstract partial class EnableProtectionProviderSpecificContent
    {
        /// <summary> Initializes a new instance of <see cref="EnableProtectionProviderSpecificContent"/> for deserialization. </summary>
        protected EnableProtectionProviderSpecificContent() { }
    }
    public abstract partial class FabricSpecificCreateNetworkMappingContent
    {
        /// <summary> Initializes a new instance of <see cref="FabricSpecificCreateNetworkMappingContent"/> for deserialization. </summary>
        protected FabricSpecificCreateNetworkMappingContent() { }
    }
    public abstract partial class FabricSpecificCreationContent
    {
        /// <summary> Initializes a new instance of <see cref="FabricSpecificCreationContent"/> for deserialization. </summary>
        protected FabricSpecificCreationContent() { }
    }
    public abstract partial class FabricSpecificDetails
    {
        /// <summary> Initializes a new instance of <see cref="FabricSpecificDetails"/> for deserialization. </summary>
        protected FabricSpecificDetails() { }
    }
    public abstract partial class FabricSpecificUpdateNetworkMappingContent
    {
        /// <summary> Initializes a new instance of <see cref="FabricSpecificUpdateNetworkMappingContent"/> for deserialization. </summary>
        protected FabricSpecificUpdateNetworkMappingContent() { }
    }
    public abstract partial class MigrateProviderSpecificContent
    {
        /// <summary> Initializes a new instance of <see cref="MigrateProviderSpecificContent"/> for deserialization. </summary>
        protected MigrateProviderSpecificContent() { }
    }
    public abstract partial class MigrationProviderSpecificSettings
    {
        /// <summary> Initializes a new instance of <see cref="MigrationProviderSpecificSettings"/> for deserialization. </summary>
        protected MigrationProviderSpecificSettings() { }
    }
    public abstract partial class NetworkMappingFabricSpecificSettings
    {
        /// <summary> Initializes a new instance of <see cref="NetworkMappingFabricSpecificSettings"/> for deserialization. </summary>
        protected NetworkMappingFabricSpecificSettings() { }
    }
    public abstract partial class PlannedFailoverProviderSpecificFailoverContent
    {
        /// <summary> Initializes a new instance of <see cref="PlannedFailoverProviderSpecificFailoverContent"/> for deserialization. </summary>
        protected PlannedFailoverProviderSpecificFailoverContent() { }
    }
    public abstract partial class PolicyProviderSpecificContent
    {
        /// <summary> Initializes a new instance of <see cref="PolicyProviderSpecificContent"/> for deserialization. </summary>
        protected PolicyProviderSpecificContent() { }
    }
    public abstract partial class PolicyProviderSpecificDetails
    {
        /// <summary> Initializes a new instance of <see cref="PolicyProviderSpecificDetails"/> for deserialization. </summary>
        protected PolicyProviderSpecificDetails() { }
    }
    public abstract partial class ProtectionContainerMappingProviderSpecificDetails
    {
        /// <summary> Initializes a new instance of <see cref="ProtectionContainerMappingProviderSpecificDetails"/> for deserialization. </summary>
        protected ProtectionContainerMappingProviderSpecificDetails() { }
    }
    public abstract partial class ProtectionProfileCustomDetails
    {
        /// <summary> Initializes a new instance of <see cref="ProtectionProfileCustomDetails"/> for deserialization. </summary>
        protected ProtectionProfileCustomDetails() { }
    }
    public abstract partial class ProviderSpecificRecoveryPointDetails
    {
        /// <summary> Initializes a new instance of <see cref="ProviderSpecificRecoveryPointDetails"/> for deserialization. </summary>
        protected ProviderSpecificRecoveryPointDetails() { }
    }
    public abstract partial class RecoveryAvailabilitySetCustomDetails
    {
        /// <summary> Initializes a new instance of <see cref="RecoveryAvailabilitySetCustomDetails"/> for deserialization. </summary>
        protected RecoveryAvailabilitySetCustomDetails() { }
    }
    public abstract partial class RecoveryPlanActionDetails
    {
        /// <summary> Initializes a new instance of <see cref="RecoveryPlanActionDetails"/> for deserialization. </summary>
        protected RecoveryPlanActionDetails() { }
    }
    public abstract partial class RecoveryPlanProviderSpecificContent
    {
        /// <summary> Initializes a new instance of <see cref="RecoveryPlanProviderSpecificContent"/> for deserialization. </summary>
        protected RecoveryPlanProviderSpecificContent() { }
    }
    public abstract partial class RecoveryPlanProviderSpecificDetails
    {
        /// <summary> Initializes a new instance of <see cref="RecoveryPlanProviderSpecificDetails"/> for deserialization. </summary>
        protected RecoveryPlanProviderSpecificDetails() { }
    }
    public abstract partial class RecoveryPlanProviderSpecificFailoverContent
    {
        /// <summary> Initializes a new instance of <see cref="RecoveryPlanProviderSpecificFailoverContent"/> for deserialization. </summary>
        protected RecoveryPlanProviderSpecificFailoverContent() { }
    }
    public abstract partial class RecoveryProximityPlacementGroupCustomDetails
    {
        /// <summary> Initializes a new instance of <see cref="RecoveryProximityPlacementGroupCustomDetails"/> for deserialization. </summary>
        protected RecoveryProximityPlacementGroupCustomDetails() { }
    }
    public abstract partial class RecoveryResourceGroupCustomDetails
    {
        /// <summary> Initializes a new instance of <see cref="RecoveryResourceGroupCustomDetails"/> for deserialization. </summary>
        protected RecoveryResourceGroupCustomDetails() { }
    }
    public abstract partial class RecoveryVirtualNetworkCustomDetails
    {
        /// <summary> Initializes a new instance of <see cref="RecoveryVirtualNetworkCustomDetails"/> for deserialization. </summary>
        protected RecoveryVirtualNetworkCustomDetails() { }
    }
    public abstract partial class RemoveDisksProviderSpecificContent
    {
        /// <summary> Initializes a new instance of <see cref="RemoveDisksProviderSpecificContent"/> for deserialization. </summary>
        protected RemoveDisksProviderSpecificContent() { }
    }
    public abstract partial class ReplicationClusterProviderSpecificSettings
    {
        /// <summary> Initializes a new instance of <see cref="ReplicationClusterProviderSpecificSettings"/> for deserialization. </summary>
        protected ReplicationClusterProviderSpecificSettings() { }
    }
    public abstract partial class ReplicationProtectionIntentProviderSpecificSettings
    {
        /// <summary> Initializes a new instance of <see cref="ReplicationProtectionIntentProviderSpecificSettings"/> for deserialization. </summary>
        protected ReplicationProtectionIntentProviderSpecificSettings() { }
    }
    public abstract partial class ReplicationProviderSpecificContainerCreationContent
    {
        /// <summary> Initializes a new instance of <see cref="ReplicationProviderSpecificContainerCreationContent"/> for deserialization. </summary>
        protected ReplicationProviderSpecificContainerCreationContent() { }
    }
    public abstract partial class ReplicationProviderSpecificContainerMappingContent
    {
        /// <summary> Initializes a new instance of <see cref="ReplicationProviderSpecificContainerMappingContent"/> for deserialization. </summary>
        protected ReplicationProviderSpecificContainerMappingContent() { }
    }
    public abstract partial class ReplicationProviderSpecificSettings
    {
        /// <summary> Initializes a new instance of <see cref="ReplicationProviderSpecificSettings"/> for deserialization. </summary>
        protected ReplicationProviderSpecificSettings() { }
    }
    public abstract partial class ReplicationProviderSpecificUpdateContainerMappingContent
    {
        /// <summary> Initializes a new instance of <see cref="ReplicationProviderSpecificUpdateContainerMappingContent"/> for deserialization. </summary>
        protected ReplicationProviderSpecificUpdateContainerMappingContent() { }
    }
    public abstract partial class ResumeReplicationProviderSpecificContent
    {
        /// <summary> Initializes a new instance of <see cref="ResumeReplicationProviderSpecificContent"/> for deserialization. </summary>
        protected ResumeReplicationProviderSpecificContent() { }
    }
    public abstract partial class ResyncProviderSpecificContent
    {
        /// <summary> Initializes a new instance of <see cref="ResyncProviderSpecificContent"/> for deserialization. </summary>
        protected ResyncProviderSpecificContent() { }
    }
    public abstract partial class ReverseReplicationProviderSpecificContent
    {
        /// <summary> Initializes a new instance of <see cref="ReverseReplicationProviderSpecificContent"/> for deserialization. </summary>
        protected ReverseReplicationProviderSpecificContent() { }
    }
    public abstract partial class SharedDiskReplicationProviderSpecificSettings
    {
        /// <summary> Initializes a new instance of <see cref="SharedDiskReplicationProviderSpecificSettings"/> for deserialization. </summary>
        protected SharedDiskReplicationProviderSpecificSettings() { }
    }
    public abstract partial class SiteRecoveryAddDisksProviderSpecificContent
    {
        /// <summary> Initializes a new instance of <see cref="SiteRecoveryAddDisksProviderSpecificContent"/> for deserialization. </summary>
        protected SiteRecoveryAddDisksProviderSpecificContent() { }
    }
    public abstract partial class SiteRecoveryApplianceSpecificDetails
    {
        /// <summary> Initializes a new instance of <see cref="SiteRecoveryApplianceSpecificDetails"/> for deserialization. </summary>
        protected SiteRecoveryApplianceSpecificDetails() { }
    }
    public abstract partial class SiteRecoveryApplyRecoveryPointProviderSpecificContent
    {
        /// <summary> Initializes a new instance of <see cref="SiteRecoveryApplyRecoveryPointProviderSpecificContent"/> for deserialization. </summary>
        protected SiteRecoveryApplyRecoveryPointProviderSpecificContent() { }
    }
    public abstract partial class SiteRecoveryCreateProtectionIntentProviderDetail
    {
        /// <summary> Initializes a new instance of <see cref="SiteRecoveryCreateProtectionIntentProviderDetail"/> for deserialization. </summary>
        protected SiteRecoveryCreateProtectionIntentProviderDetail() { }
    }
    public abstract partial class SiteRecoveryEventProviderSpecificDetails
    {
        /// <summary> Initializes a new instance of <see cref="SiteRecoveryEventProviderSpecificDetails"/> for deserialization. </summary>
        protected SiteRecoveryEventProviderSpecificDetails() { }
    }
    public abstract partial class SiteRecoveryEventSpecificDetails
    {
        /// <summary> Initializes a new instance of <see cref="SiteRecoveryEventSpecificDetails"/> for deserialization. </summary>
        protected SiteRecoveryEventSpecificDetails() { }
    }
    public abstract partial class SiteRecoveryGroupTaskDetails
    {
        /// <summary> Initializes a new instance of <see cref="SiteRecoveryGroupTaskDetails"/> for deserialization. </summary>
        protected SiteRecoveryGroupTaskDetails() { }
    }
    public abstract partial class SiteRecoveryJobDetails
    {
        /// <summary> Initializes a new instance of <see cref="SiteRecoveryJobDetails"/> for deserialization. </summary>
        protected SiteRecoveryJobDetails() { }
    }
    public abstract partial class SiteRecoveryReplicationProviderSettings
    {
        /// <summary> Initializes a new instance of <see cref="SiteRecoveryReplicationProviderSettings"/> for deserialization. </summary>
        protected SiteRecoveryReplicationProviderSettings() { }
    }
    public abstract partial class SiteRecoveryTaskTypeDetails
    {
        /// <summary> Initializes a new instance of <see cref="SiteRecoveryTaskTypeDetails"/> for deserialization. </summary>
        protected SiteRecoveryTaskTypeDetails() { }
    }
    public abstract partial class StorageAccountCustomDetails
    {
        /// <summary> Initializes a new instance of <see cref="StorageAccountCustomDetails"/> for deserialization. </summary>
        protected StorageAccountCustomDetails() { }
    }
    public abstract partial class SwitchClusterProtectionProviderSpecificContent
    {
        /// <summary> Initializes a new instance of <see cref="SwitchClusterProtectionProviderSpecificContent"/> for deserialization. </summary>
        protected SwitchClusterProtectionProviderSpecificContent() { }
    }
    public abstract partial class SwitchProtectionProviderSpecificContent
    {
        /// <summary> Initializes a new instance of <see cref="SwitchProtectionProviderSpecificContent"/> for deserialization. </summary>
        protected SwitchProtectionProviderSpecificContent() { }
    }
    public abstract partial class SwitchProviderSpecificContent
    {
        /// <summary> Initializes a new instance of <see cref="SwitchProviderSpecificContent"/> for deserialization. </summary>
        protected SwitchProviderSpecificContent() { }
    }
    public abstract partial class TestFailoverProviderSpecificContent
    {
        /// <summary> Initializes a new instance of <see cref="TestFailoverProviderSpecificContent"/> for deserialization. </summary>
        protected TestFailoverProviderSpecificContent() { }
    }
    public abstract partial class TestMigrateProviderSpecificContent
    {
        /// <summary> Initializes a new instance of <see cref="TestMigrateProviderSpecificContent"/> for deserialization. </summary>
        protected TestMigrateProviderSpecificContent() { }
    }
    public abstract partial class UnplannedFailoverProviderSpecificContent
    {
        /// <summary> Initializes a new instance of <see cref="UnplannedFailoverProviderSpecificContent"/> for deserialization. </summary>
        protected UnplannedFailoverProviderSpecificContent() { }
    }
    public abstract partial class UpdateApplianceForReplicationProtectedItemProviderSpecificContent
    {
        /// <summary> Initializes a new instance of <see cref="UpdateApplianceForReplicationProtectedItemProviderSpecificContent"/> for deserialization. </summary>
        protected UpdateApplianceForReplicationProtectedItemProviderSpecificContent() { }
    }
    public abstract partial class UpdateMigrationItemProviderSpecificContent
    {
        /// <summary> Initializes a new instance of <see cref="UpdateMigrationItemProviderSpecificContent"/> for deserialization. </summary>
        protected UpdateMigrationItemProviderSpecificContent() { }
    }
    public abstract partial class UpdateReplicationProtectedItemProviderContent
    {
        /// <summary> Initializes a new instance of <see cref="UpdateReplicationProtectedItemProviderContent"/> for deserialization. </summary>
        protected UpdateReplicationProtectedItemProviderContent() { }
    }
}
