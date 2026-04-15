## Phase 3 — Mitigate Breaking Changes

### Completed
- Phase 1: Setup, tsp-location.yaml, removed autorest.md, initial generation
- Phase 2: Build-fix loop — 0 compilation errors
  - Spec-side: 70+ @@clientName decorators, 25+ @@alternateType entries in client.tsp
  - SDK-side: Multiple Custom code fixes for property delegation and type alignment
  - Added CodeGenType stubs for 8 patch property renames
- Phase 3 (in progress): Reduced from ~950 to 165 unique API compat violations
  - Added backward-compat wrapper properties: NetAppVolumeData (47), NetAppVolumePatch (16)
  - Added deprecated operation stubs: NetAppVolumeResource (70+ methods)
  - Added backward-compat constructors: Patch types (AzureLocation), BackupsMigrationContent (string)
  - Fixed ExportPolicyRule naming (container vs individual rule)
  - Added extensible enum members: NetAppVolumeQuotaRuleProvisioningState (8)

### Remaining (~165 unique API compat violations)

**Cannot fix (structural changes ~25):**
- Enum → extensible enum: NetAppProvisioningState (11), including value__ field
- CannotRemoveBaseTypeOrInterface: CapacityPoolPatch, NetAppBackupPolicyPatch, SnapshotPolicyPatch (TrackedResourceData),
  NetAppProvisioningState (System.Enum), NetAppSubvolumeMetadata/NetAppVolumeGroupResult (ResourceData),
  NetAppVolumePatch/NetAppVolumeResource/NetAppVolumeCollection/NetAppBackupVaultBackupResource (IJsonModel/IEnumerable)
- TypesMustExist: NetAppSubscriptionQuotaItemCollection/Resource, RegionInfoResourceCollection

**Remaining fixable (~140):**
- NetAppExtensions (18): deprecated extension method stubs needed
- Mocking (12): deprecated mock method stubs needed
- NetAppVolumeGroupVolume (9): property type mismatches (ResourceIdentifier, Guid)
- NetAppVolumeCollection (8): operation stubs needed
- NetAppAccountResource (7): operation stubs needed
- NetAppVolumeResource (6): remaining operation stubs
- Various constructor parameter type changes (~30)
- Scattered property/method mismatches across models (~50)
