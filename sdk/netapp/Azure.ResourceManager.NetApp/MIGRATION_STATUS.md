## Phase 3 — Mitigate Breaking Changes

### Completed
- Phase 1: Setup, tsp-location.yaml, removed autorest.md, initial generation
- Phase 2: Build-fix loop — 0 compilation errors
  - Spec-side: 70+ @@clientName decorators, 25+ @@alternateType entries in client.tsp
  - SDK-side: Multiple Custom code fixes for property delegation and type alignment
- Phase 3 (in progress): Reduced from ~950 to 79 unique API compat violations
  - Backward-compat wrapper properties: NetAppVolumeData (47), NetAppVolumePatch (16)
  - Deprecated operation stubs: NetAppVolumeResource (80+), NetAppVolumeCollection (10),
    NetAppAccountResource, SnapshotPolicyResource, extension/mocking methods
  - Backward-compat constructors: Patch types, BackupsMigrationContent, various content types
  - Fixed ExportPolicyRule naming, added extensible enum members
  - Created stub types: NetAppSubscriptionQuotaItemResource/Collection, RegionInfoResourceCollection
  - Fixed RegenSdkLocal.ps1 to accept service folder path

### Remaining (~79 unique API compat violations)

**Cannot fix (structural ~25):**
- Enum → extensible enum: NetAppProvisioningState (12 incl. value__ and base type)
- CannotRemoveBaseTypeOrInterface (~13): Patch types lost TrackedResourceData,
  models lost ResourceData, Volume types lost IJsonModel/IEnumerable interfaces

**Remaining fixable (~54):**
- NetAppVolumeGroupVolume (8): property type mismatches (ResourceIdentifier vs string, Guid vs string)
- Constructor parameter type changes (~15): various content/data types
- NetAppAccountResource (4): remaining operation stubs
- NetAppVolumeResource (3): remaining operation stubs
- Scattered individual property/method mismatches (~24)
