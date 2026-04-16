## Phase 3 — Mitigate Breaking Changes (In Progress)

### Summary
- Started with ~950 unique API compat violations
- Currently at 49 remaining (0 compile errors)

### Techniques used
- **@@clientName**: 75+ type/property renames for backward compat
- **@@alternateType**: 25+ property type overrides (armResourceIdentifier, uuid, ipV4Address, azureLocation, eTag)
- **@@hierarchyBuilding**: Restored base types for 6 models (NetAppAccountPatch, SnapshotPolicyPatch, BackupPolicyPatch, CapacityPoolPatch, SubvolumeModel, VolumeGroup)
- **@@usage(Input|Output)**: Restored setters on 6 models (AvailabilityZoneMapping, ReplicationObject, VolumeRevert, RansomwareReport, RegionInfoResource, Snapshot)
- **Union replacement**: NetAppProvisioningState (enum → extensible enum)
- **[CodeGenSuppress]**: Workaround for CapacityPoolPatch ModelFactory bug (microsoft/typespec#10397)
- **Custom code**: Backward-compat wrapper properties, deprecated operation stubs, constructors, ModelFactory overloads

### Remaining 49 API compat violations

**Property type mismatch — same name, different type in partial class (18):**
- NetAppVolumeGroupVolume: CapacityPoolResourceId (ResourceIdentifier vs string), DataStoreResourceId (IReadOnlyList<ResourceIdentifier> vs IReadOnlyList<string>), BackupId/SnapshotId (string vs ResourceIdentifier), ResourceType (ResourceType? vs string)
- NetAppVolumeGroupData: Location (AzureLocation? vs string)
- BackupsMigrationContent: BackupVaultId (string vs ResourceIdentifier)
- NetAppKeyVaultStatusResult: KeyVaultPrivateEndpoints (IReadOnlyList)
- ListQuotaReportResult: QuotaReportRecords (IReadOnlyList)
- RegionInfoResourceData: AvailabilityZoneMappings (IList)
- Status types: RelationshipStatus on Backup/Replication/RestoreStatus (NetAppRelationshipStatus vs specific types), VolumeBackup/Replication/RestoreRelationshipStatus
- NetAppBackupVaultBackupResource: Data (NetAppBackupData vs NetAppBackupVaultBackupData)

**Enum member metadata mismatch (11):**
- NetAppProvisioningState: 10 members (Accepted, Canceled, Creating, etc.) + value__ field
- ApiCompat sees enum fields vs extensible enum static properties as different

**Interface removal on deprecated wrapper types (8):**
- IJsonModel<T>: NetAppVolumePatch, NetAppBackupVaultBackupResource, NetAppVolumeResource, NetAppSubscriptionQuotaItemResource
- IEnumerable<T>: NetAppVolumeCollection, NetAppSubscriptionQuotaItemCollection, RegionInfoResourceCollection

**Missing setter (8):**
- NetAppVolumeGroupVolume: BackupId, CapacityPoolResourceId, IsRestoring, SnapshotId
- NetAppVolumeGroupData: Location
- NetAppVolumeSnapshotData: Location (+ constructor)
- NetAppVolumeRevertContent: SnapshotId

**Other (4):**
- NetAppVolumeSnapshotResource: Update/UpdateAsync return type changed
- NetAppVolumeSnapshotData: missing AzureLocation constructor
- ArmNetAppModelFactory: 2 NetAppSubscriptionQuotaItem overloads (type replaced)

### Known issues
- microsoft/typespec#10397: @@hierarchyBuilding causes ModelFactory backward-compat overload arg-order bug (workaround: CodeGenSuppress)
- Azure/azure-sdk-for-net#58197: Same issue tracked on SDK repo

### Next Steps
- Phase 4: Self-review against mpg-migration-pr-review skill rules
- Phase 5: Push spec and SDK branches to fork, create draft PRs
