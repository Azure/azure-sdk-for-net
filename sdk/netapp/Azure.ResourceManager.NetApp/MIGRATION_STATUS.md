## Phase 3 — Mitigate Breaking Changes

### Completed
- Phase 1: Setup, tsp-location.yaml, removed autorest.md, initial generation
- Phase 2: Build-fix loop — 0 compilation errors
  - Spec-side: 70+ @@clientName decorators, 25+ @@alternateType entries in client.tsp
  - SDK-side: Multiple Custom code fixes for property delegation and type alignment
- Phase 3 (in progress): Reduced from ~950 to 175 unique API compat violations
  - Backward-compat wrapper properties: NetAppVolumeData (47), NetAppVolumePatch (16)
  - Deprecated operation stubs: NetAppVolumeResource (80+), NetAppVolumeCollection (10)
  - Backward-compat constructors: Patch types, BackupsMigrationContent
  - Fixed ExportPolicyRule naming, added extensible enum members
  - Created stub types: NetAppSubscriptionQuotaItemResource/Collection, RegionInfoResourceCollection
  - Fixed RegenSdkLocal.ps1 to accept service folder path

### Remaining (~175 unique API compat violations)

**Cannot fix (structural ~25):**
- Enum → extensible enum: NetAppProvisioningState (11)
- CannotRemoveBaseTypeOrInterface: Patch types (TrackedResourceData), enum (System.Enum),
  models (ResourceData), Volume types (IJsonModel/IEnumerable)

**Remaining fixable (~150):**
- NetAppExtensions (18): deprecated extension method stubs
- Mocking (12): deprecated mock method stubs
- NetAppVolumeGroupVolume (9): property type mismatches
- NetAppAccountResource (7): operation stubs
- NetAppVolumeResource (6): remaining operation stubs
- Constructor parameter type changes (~30)
- Scattered property/method mismatches (~50)
- New stub type members (~20)
