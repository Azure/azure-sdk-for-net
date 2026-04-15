## Phase 3 — Mitigate Breaking Changes

### Completed
- Phase 1: Setup, tsp-location.yaml, removed autorest.md, initial generation
- Phase 2: Build-fix loop — 0 compilation errors
  - Spec-side: 25+ @@clientName decorators, 16 @@alternateType entries, 1 @@access entry in client.tsp
  - SDK-side: Fixed NetAppAccountPatch, NetAppAccountData, NetAppKeyVaultProperties, ArmNetAppModelFactory custom code
  - Added CodeGenType stubs for 8 patch property renames

### Remaining (~445 unique API compat violations)

**TypesMustExist (3 types):**
- `NetAppSubscriptionQuotaItemCollection` / `NetAppSubscriptionQuotaItemResource` — old ARM resource pattern replaced by `NetAppResourceQuotaLimitCollection` / `NetAppResourceQuotaLimitResource`
- `RegionInfoResourceCollection` — no longer generated as collection (singleton resource)

**CannotRemoveBaseTypeOrInterface (11 types):**
- Patch types lost `TrackedResourceData` base: `CapacityPoolPatch`, `NetAppBackupPolicyPatch`, `SnapshotPolicyPatch`
- `NetAppProvisioningState` changed from enum to extensible enum
- Models lost `ResourceData` base: `NetAppSubvolumeMetadata`, `NetAppVolumeGroupResult`
- Missing `IJsonModel<>` interfaces: `NetAppVolumeBackupConfiguration`, `NetAppVolumePatch`
- Volume resource types changed: `NetAppBackupVaultBackupResource`, `NetAppVolumeResource`, `NetAppVolumeCollection`

**MembersMustExist (~430 members):**
- Operation signature changes on `NetAppVolumeResource` (methods now on `VolumeResource`)
- `NetAppVolumeBackupConfiguration` properties (BackupPolicyId, BackupVaultId as ResourceIdentifier)
- ModelFactory backward-compat overloads (~14)
- Various constructor and property signature changes
