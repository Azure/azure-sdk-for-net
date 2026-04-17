## Phase 3 — Mitigate Breaking Changes (In Progress)

### Summary
- Started with ~950 unique API compat violations
- Currently at 1 remaining (0 compile errors)

### Techniques used
- **@@clientName**: 75+ type/property renames for backward compat
- **@@alternateType**: 30+ property type overrides (armResourceIdentifier, uuid, ipV4Address, azureLocation, eTag, string)
- **@@hierarchyBuilding**: Restored base types for 6 models (NetAppAccountPatch, SnapshotPolicyPatch, BackupPolicyPatch, CapacityPoolPatch, SubvolumeModel, VolumeGroup)
- **@@usage(Input|Output)**: Restored setters on 6 models (AvailabilityZoneMapping, ReplicationObject, VolumeRevert, RansomwareReport, RegionInfoResource, Snapshot)
- **Enum replacement**: NetAppProvisioningState (union → closed enum via @@alternateType)
- **Unified RelationshipStatus**: Merged VolumeBackup/Replication/RestoreRelationshipStatus into NetAppRelationshipStatus via @@alternateType
- **[CodeGenSuppress]**: Workaround for CapacityPoolPatch ModelFactory bug (microsoft/typespec#10397), BackupVaultBackupResource Data property
- **Custom code**: Backward-compat wrapper properties, deprecated operation stubs, constructors, ModelFactory overloads, IJsonModel/IEnumerable on deprecated types

### Remaining 1 API compat violation

**NetAppBackupVaultBackupResource.Data type mismatch:**
- Old API: `Data` returns `NetAppBackupData`
- New API: `Data` returns `NetAppBackupVaultBackupData`
- Root cause: The resource type name changed from `NetAppBackup` to `NetAppBackupVaultBackup`, changing the data type
- Cannot fix without CodeGenSuppress which breaks generated serialization code
- Impact: Low — callers accessing `.Data` need to use the new type

### Known issues
- microsoft/typespec#10397: @@hierarchyBuilding causes ModelFactory backward-compat overload arg-order bug (workaround: CodeGenSuppress)
- Azure/azure-sdk-for-net#58197: Same issue tracked on SDK repo

### Next Steps
- Phase 4: Self-review against mpg-migration-pr-review skill rules
- Phase 5: Push spec and SDK branches to fork, create draft PRs
