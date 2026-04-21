## Phase 3 — Mitigate Breaking Changes (Complete)

### Summary
- Started with ~950 unique API compat violations
- **All ApiCompat violations resolved** (0 remaining, 0 compile errors)

### Techniques used
- **@@clientName**: 75+ type/property renames for backward compat
- **@@alternateType**: 30+ property type overrides (armResourceIdentifier, uuid, ipV4Address, azureLocation, eTag, string)
- **@@hierarchyBuilding**: Restored base types for 6 models (NetAppAccountPatch, SnapshotPolicyPatch, BackupPolicyPatch, CapacityPoolPatch, SubvolumeModel, VolumeGroup)
- **@@usage(Input|Output)**: Restored setters on 6 models (AvailabilityZoneMapping, ReplicationObject, VolumeRevert, RansomwareReport, RegionInfoResource, Snapshot)
- **Enum replacement**: NetAppProvisioningState (union → closed enum via @@alternateType)
- **Unified RelationshipStatus**: Merged VolumeBackup/Replication/RestoreRelationshipStatus into NetAppRelationshipStatus via @@alternateType
- **[CodeGenSuppress]**: Workaround for CapacityPoolPatch ModelFactory bug (microsoft/typespec#10397), BackupVaultBackupResource Data property
- **Custom code**: Backward-compat wrapper properties, deprecated operation stubs, constructors, ModelFactory overloads, IJsonModel/IEnumerable on deprecated types

### Resolution of last violation

**NetAppBackupVaultBackupResource.Data type mismatch (resolved):**
- Resolved by renaming `NetAppBackupVaultBackupData` → `NetAppBackupData` via `[CodeGenType("NetAppBackupData")]` on the generated model. `NetAppBackupVaultBackupResource.Data` now returns `NetAppBackupData`, matching the v1.15.0 baseline.

### Additional Phase 3 work after merge from main
- Added compatibility property shims after rebasing onto main: `Enabled` (BackupPolicy/SnapshotPolicy data + patch), `PolicyEnforced` (NetAppVolumeBackupConfiguration), `SnapshotDirectoryVisible` (VolumeData), `LdapOverTLS`/`AesEncryption`/`LdapSigning` (NetAppAccountActiveDirectory), `IsLdapOverTlsEnabled` (LdapConfiguration), `UnixReadOnly`/`UnixReadWrite`/`Cifs`/`Nfsv3`/`Nfsv41`/`Kerberos5*ReadOnly`/`*ReadWrite` (NetAppVolumeExportPolicyRule), `Nfsv3`/`Nfsv4` (ElasticProtocolType), `ProximityPlacementGroup` (VolumeGroupVolumeProperties).
- Added compatibility wrapper types: `ExportPolicyRule`, `VolumeBackupProperties`, `VolumeGroupVolumeProperties`.
- Updated internal tests (NetAppTestBase, SnapshotPolicyTests, etc.) to use the canonical new property names.

### Known issues
- microsoft/typespec#10397: @@hierarchyBuilding causes ModelFactory backward-compat overload arg-order bug (workaround: CodeGenSuppress)
- Azure/azure-sdk-for-net#58197: Same issue tracked on SDK repo

### Next Steps
- Phase 4: Self-review against mpg-migration-pr-review skill rules
- Phase 5: Run pre-commit checks (Update-Snippets, Export-API), push branches, create draft PRs
