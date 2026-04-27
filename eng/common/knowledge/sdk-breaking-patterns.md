# SDK Breaking Change Patterns

This document catalogs known TypeSpec changes that cause SDK breaking changes, organized by detection source, per-language impact, and recommended `client.tsp` mitigations. It is used by `azsdk_typespec_generate_authoring_plan` to warn developers about SDK impact during TypeSpec authoring.

## How to Use This Document

When generating an authoring plan for TypeSpec changes, check if the planned changes match any pattern below. If so, include an **SDK IMPACT** warning in the plan with the recommended mitigation. The developer can then apply the `client.tsp` fix in the same session, before merge.

## Pattern Catalog

### 1. Enum Changed to Extensible Union

**Detection:** TypeSpec diff shows `enum` keyword replaced by `union` or extensible enum pattern.

**Per-Language Impact:**
- **Java:** ❌ Breaking — enum ordinal values change, deserialization breaks
- **.NET:** ⚠️ May break — strong typing affected, but extensible enums are handled
- **Python:** ✅ Usually safe — duck typing, string comparison
- **Go:** ❌ Breaking — type assertion fails on new union type

**Mitigation:**
```typespec
// In client.tsp — Define a new enum with all original enum values, then use @@alternateType to map to the new enum type for affacted languages.
enum FooStatusEnum
{
 // ... all values from original FooStatus Enum
}
@@alternateType(MyService.FooStatus, FooStatusEnum, "java");
@@alternateType(MyService.FooStatus, FooStatusEnum, "go");
```

---

### 2. Enum Split Into Multiple Enums

**Detection:** SDK changelog shows enum type lost members that moved to a new enum type (e.g., `ProvisioningState` split into `ProvisioningState` + `StorageTaskAssignmentProvisioningState`).

**Per-Language Impact:**
- **Java:** ❌ Breaking — return type change + missing enum members
- **.NET:** ❌ Breaking — type mismatch in client code
- **Python:** ⚠️ May break — type hint changes
- **Go:** ❌ Breaking — type assertion and switch cases fail

**Mitigation:**

This is a complex multi-step case. The mitigation combines `@@alternateType` and `@@clientName` with a critical "make room" step:

```typespec
// In client.tsp
// Step 1: CRITICAL — Rename the ORIGINAL enum out of the way first
// Without this, you get "duplicate-client-name" errors
@@clientName(MyService.ProvisioningState, "StorageProvisioningState", "java");

// Step 2: Create merged enum with ALL values from both enums
enum ProvisioningStateEnum {
  Creating,
  ResolvingDNS,
  Succeeded,
  // ... all values from original ProvisioningState
  Canceled,
  Failed,
  // ... plus values from StorageTaskAssignmentProvisioningState
}

// Step 3: Give the merged enum the original name
@@clientName(MyService.ProvisioningStateEnum, "ProvisioningState", "java");

// Step 4: Point properties at the merged enum
@@alternateType(
  MyService.StorageAccountProperties.provisioningState,
  MyService.ProvisioningStateEnum,
  "java"
);
@@alternateType(
  MyService.StorageTaskAssignmentProperties.provisioningState,
  MyService.ProvisioningStateEnum,
  "java"
);
```

**Key learning from Storage dogfood:** Step 1 (the "make room" step) is critical. Without renaming the original enum first, creating a new enum with `@@clientName` to the same name causes `duplicate-client-name` errors. This multi-step interaction is the most common failure point.

---

### 3. Enum Value Name Changed (Numeric Names)

**Detection:** SDK changelog shows enum member renamed — typically numbers converted to words (Swagger) being replaced by original numeric names (TypeSpec).

**Per-Language Changelog Pattern:**
- **Python:** `Enum 'Minute' deleted or renamed its member 'ZERO'` / `Enum 'Minute' added member 'ENUM_0'`
- **Go:** `'ZERO' from enum 'Minute' has been removed` / `New value 'ENUM_0' added to enum type 'Minute'`
- **Java/.NET:** Similar rename patterns in changelog

**Per-Language Impact:**
- **All languages:** ❌ Breaking — existing code references old enum member names

**Mitigation:**
```typespec
// In client.tsp — restore original member names per language
@@clientName(MyService.Minute.`0`, "ZERO", "python");
@@clientName(MyService.Minute.`30`, "THIRTY", "python");
@@clientName(MyService.Minute.`0`, "ZERO", "go");
@@clientName(MyService.Minute.`30`, "THIRTY", "go");
```

---

### 4. Model Renamed

**Detection:** TypeSpec diff or changelog shows model name changed between versions.

**Per-Language Changelog Pattern:**
- **Python:** `Deleted or renamed model 'ResourceInfo'` / `Added model 'RedisResource'`
- **Go:** `Struct 'A' has been removed` / `New struct 'B'`
- **Java/.NET:** Model removal + addition in changelog

**Per-Language Impact:**
- **All languages:** ❌ Breaking — client code references the old name

**Note (Python):** Check legacy `readme.python.md` for Swagger rename directives that need to be preserved:
```md
directive:
  - rename-model:
      from: 'RedisResource'
      to: 'ResourceInfo'
```

**Mitigation:**
```typespec
// In client.tsp — preserve the old name for all languages
@@clientName(MyService.NewModelName, "OldModelName");

// Or scope to specific languages if only some need backward compat
@@clientName(MyService.NewModelName, "OldModelName", "java");
@@clientName(MyService.NewModelName, "OldModelName", "python");
```

---

### 5. Model Removed

**Detection:** TypeSpec diff shows model definition deleted, or changelog shows model no longer available.

**Per-Language Impact:**
- **All languages:** ❌ Breaking — any code referencing the model fails to compile
- **Go:** Cannot be resolved through client customizations if model is truly deleted

**Mitigation:**
```typespec
// In main.tsp — version gate with @removed instead of deleting
@removed(Versions.v2026_07_01)
model DeprecatedModel {
  // ...
}
```

If the model was intentionally removed and replacement exists, use `@@clientName` to alias:
```typespec
@@clientName(MyService.ReplacementModel, "OldModelName");
```

---

### 6. Property Type Changed

**Detection:** TypeSpec diff shows property type changed (e.g., `int32` → `duration`, `string` → custom model).

**Per-Language Changelog Pattern:**
- **Go:** `Type of 'Test.Prop' has been changed from '*string' to '*int32'`
- **Python:** Property type change visible in changelog
- **Java/.NET:** Getter return type changes

**Per-Language Impact:**
- **Java:** ❌ Breaking — deserialization and getter return type change
- **.NET:** ❌ Breaking — analyzer AZC0030 flags type mismatches; use `@@alternateType` with `Azure.ResourceManager.CommonTypes.ArmResourceIdentifier` for ID properties
- **Python:** ⚠️ May break — mypy type check fails
- **Go:** ❌ Breaking — cannot be resolved through client customizations

**Mitigation:**
```typespec
// In client.tsp — use @@alternateType to keep old type for affected languages
@@alternateType(MyService.MyModel.timeout, int32, "java");

// For .NET — use CommonTypes for ARM resource IDs
@@alternateType(MyService.MyModel.resourceId, Azure.ResourceManager.CommonTypes.ArmResourceIdentifier, "csharp");
```

**Note (Go):** Property type changes cannot be resolved through `client.tsp` customizations in Go. The spec change itself must be reconsidered if Go backward compatibility is required.

---

### 7. Property Renamed

**Detection:** TypeSpec diff shows property name changed, or changelog shows renamed getter/setter.

**Per-Language Changelog Pattern:**
- **Go:** `Field 'A' of struct 'Test' has been removed` / `New field 'B' in struct 'Test'`
- **Python:** Paired removal/addition of model properties
- **Java/.NET:** Getter/setter name changes

**Per-Language Impact:**
- **All languages:** ❌ Breaking — getter/setter name changes, customization code drifts
- **Java/Python:** Additional risk — customization files (`*Customization.java`, `*_patch.py`) may reference old name

**Mitigation:**
```typespec
// In client.tsp — preserve old property name
@@clientName(MyService.MyModel.newPropertyName, "oldPropertyName");

// Scope per language if needed
@@clientName(MyService.MyModel.newPropertyName, "oldPropertyName", "go");
@@clientName(MyService.MyModel.newPropertyName, "oldPropertyName", "python");
```

---

### 8. Property or Model Made Read-Only (Setters Removed)

**Detection:** SDK changelog shows setter methods (`withXyz`) removed from models, or constructors changed to private.

**Per-Language Impact:**
- **Java:** ❌ Breaking — immutable models, no setters
- **.NET:** ✅ Safe — partial classes can add setters via `[CodeGenType]`
- **Python:** ✅ Safe — `_patch.py` can override
- **Go:** ❌ Breaking — exported fields become unexported

**Mitigation:**
```typespec
// In client.tsp — restore input usage for affected languages
@@usage(MyService.MyModel, Usage.input, "java");
@@usage(MyService.MyModel, Usage.input, "go");
```

---

### 9. Operation Renamed

**Detection:** TypeSpec diff shows operation name changed, or changelog shows method renamed.

**Per-Language Changelog Pattern:**
- **Python:** `Removed operation StorageTaskAssignmentOperations.list` / `Added operation StorageTaskAssignmentOperations.storage_task_assignment_list`
- **Go:** `Function 'A' has been removed` / `New function '*xxx.B(xxx) *xxx'`
- **Java/.NET:** Method name changes in changelog

**Per-Language Impact:**
- **All languages:** ❌ Breaking — method names change in generated clients

**Mitigation:**
```typespec
// In client.tsp — restore the original operation name
@@clientName(MyService.StorageTaskAssignment.storageTaskAssignmentList, "list", "python");
@@clientName(MyService.MyInterface.newOpName, "oldOpName", "go");
```

---

### 10. Operation Signature Changed (Parameters Added/Removed/Reordered)

**Detection:** TypeSpec diff shows operation parameters added/removed/retyped, or changelog shows parameter changes.

**Per-Language Changelog Pattern:**
- **Python:** `Method 'IotDpsResourceOperations.get' re-ordered its parameters from ['self', 'provisioning_service_name', 'resource_group_name'] to ['self', 'resource_group_name', 'provisioning_service_name']`
- **Go:** `Function '*xxx.Test' parameter(s) have been changed from '(string)' to '(string, int32)'`
- **Java/.NET:** Method signature changes

**Per-Language Impact:**
- **All languages:** ❌ Breaking — method signatures change in generated clients
- **Go:** Required parameter additions, optional-to-required changes, and parameter deletions cannot be resolved through client customizations

**Mitigation (Python — parameter reorder):**
```typespec
// In client.tsp — use @@override to control parameter order
op MyCustomOp(
  @path provider: "Microsoft.ThisWillBeReplaced",
  @path provisioningServiceName: string,
  ...Azure.ResourceManager.CommonTypes.ResourceGroupNameParameter,
): ProvisioningServiceDescription;

@@override(ProvisioningServiceDescriptions.get, MyCustomOp, "python");
```

**Mitigation (general — rename/hide):**
```typespec
@@clientName(MyService.MyInterface.newOpName, "oldOpName");
@@access(MyService.MyInterface.internalOp, Access.internal, "python");
```

---

### 11. Operation Removed or Hidden

**Detection:** TypeSpec diff shows operation deleted or `@removed` decorator added.

**Per-Language Impact:**
- **All languages:** ❌ Breaking — method no longer exists in client
- **Go:** Cannot be resolved through client customizations

**Mitigation:**
```typespec
// In main.tsp — use version gating instead of deletion
@removed(Versions.v2026_07_01)
op oldOperation(): void;
```

---

### 12. Combine multiple model properties into one

**Detection:** TypeSpec diff shows that one or more properties in a model are combined into a new model, and a new property of that model is added.

**Per-Language Impact:**
- **All languages:** ❌ Breaking — missing properties and new property added in a model

**Mitigation:** This can be resolved by applying `@flattenProperty` to the new combined property in `client.tsp`.

---

### 13. Interface Renamed (DataPlane only)

**Detection:** TypeSpec diff shows interface name changed.

**Per-Language Impact:**
- **All languages:** ❌ Breaking — client name changed

**Mitigation:**
```typespec
// In client.tsp — restore the original operation name
@@clientName(MyService.newInterfaceName, "oldInterfaceName");
```

---

### 14. List/Page Wrapper Models Removed

**Detection:** SDK changelog shows list wrapper models removed (e.g., `ListQueueResource`, `StorageAccountListResult`, `FileShareItems`).

**Per-Language Changelog Pattern:**
- **Python:** `Deleted or renamed model 'ElasticSanList'`, `Deleted or renamed model 'SnapshotList'`
- **Go:** Paged response type changes
- **Java/.NET:** Pagination model types changed

**Per-Language Impact:**
- **Java:** ❌ Breaking — pagination model types changed
- **.NET:** ⚠️ May break — use `@@markAsPageable` to preserve `Pageable<T>` return type
- **Python:** ✅ Accept — Python does not expose pageable models for list APIs (low impact)
- **Go:** ❌ Breaking — response type assertion fails; paging operation changes cannot be resolved through client customizations

**Mitigation (.NET — markAsPageable):**
```typespec
// In client.tsp — make non-pageable list operation return Pageable<T>
// Requires: using Azure.ClientGenerator.Core.Legacy;
#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "migration"
@@markAsPageable(MyService.MyInterface.listOperation, "csharp");
```

**Note:** Do NOT use `@@markAsPageable` if the operation is already marked with `@list` — the `@list` decorator already makes it pageable.

**Mitigation (Java — clientName):**
```typespec
@@clientName(MyService.NewPagedResponse, "OldListResult", "java");
```

---

### 15. Client Name Changed

**Detection:** SDK changelog shows client class renamed.

**Per-Language Changelog Pattern:**
- **Python:** `Deleted or renamed client 'IotDpsClient'`
- **Java/.NET:** Client class name changes

**Per-Language Impact:**
- **All languages:** ❌ Breaking — client instantiation code breaks

**Root Cause:** TypeSpec generates client names from the `namespace` rather than the `@service` `title` annotation.

**Mitigation:**
```typespec
// In client.tsp — restore the original client name
@@clientName(Microsoft.Devices, "IotDpsClient", "python");
@@clientName(Microsoft.Devices, "IotDpsClient", "java");
```

---

### 16. Resource Base Type Changed (.NET-specific)

**Detection:** .NET ApiCompat shows `CannotRemoveBaseTypeOrInterface` error (e.g., `Type 'X' does not inherit from base type 'Azure.ResourceManager.Models.ResourceData'`).

**Per-Language Impact:**
- **.NET:** ❌ Breaking — resource model no longer inherits expected base class
- **Other languages:** Usually unaffected

**Mitigation (.NET — hierarchyBuilding):**
```typespec
// In client.tsp — restore the correct base type
// Requires: using Azure.ClientGenerator.Core.Legacy;
#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "Change base type back for backward compatibility"
@@Azure.ClientGenerator.Core.Legacy.hierarchyBuilding(
  MyService.MyResource,
  Azure.ResourceManager.Foundations.TrackedResource,
  "csharp"
);
```

**Common target base types:**
- `Azure.ResourceManager.Foundations.TrackedResource` → generates `TrackedResourceData`
- `Azure.ResourceManager.Foundations.ProxyResource` → generates `ResourceData`

---

### 17. WirePathAttribute Missing (.NET MPG-specific)

**Detection:** .NET ApiCompat shows `CannotRemoveAttribute` errors referencing `WirePathAttribute` on model properties.

**Per-Language Impact:**
- **.NET:** ❌ Breaking — Azure.Provisioning libraries depend on `WirePathAttribute`
- **Other languages:** Not affected

**Mitigation:**

Add to `tspconfig.yaml` (not `client.tsp`):
```yaml
options:
  "@azure-typespec/http-client-csharp-mgmt":
    enable-wire-path-attribute: true
```

**Note:** Do NOT use `ApiCompatBaseline.txt` to suppress these — the emitter option is the correct fix.

---

### 18. Common Types Upgrade (Accept)

**Detection:** SDK changelog shows changes to common infrastructure types like `SystemData`, `IdentityType`, `ManagedServiceIdentity`.

**Per-Language Impact:**
- **All languages:** ⚠️ Low impact — these are common infrastructure types rarely used directly

**Mitigation:** Accept these breaking changes. Common types are upgraded to latest versions during TypeSpec migration and are not user-facing.

---

### 19. Unreferenced Models Removed (Accept)

**Detection:** SDK changelog shows removal of models not referenced by any operation (e.g., `ProxyResourceWithoutSystemData`, `Resource`).

**Per-Language Impact:**
- **All languages:** ⚠️ Low impact — typically not used directly by users

**Mitigation:** Accept these breaking changes.

---

### 20. Multi-Level Flattened Properties Unflattened (Python-specific)

**Detection:** Python SDK changelog shows property removed and `properties` added (e.g., `Model 'VaultExtendedInfoResource' deleted instance variable 'integrity_key'` / `Model 'VaultExtendedInfoResource' added property 'properties'`).

**Per-Language Impact:**
- **Python:** ❌ Breaking — previously flattened properties now require accessing via `.properties.xxx`
- **Other languages:** May vary

**Root Cause:** TypeSpec does not support multi-level flattening and preserves the actual REST API hierarchy.

**Mitigation:** Accept these breaking changes. Users access properties following the actual model structure matching the REST API documentation.

---

### 21. Property Name Conflicts with Base Methods (Python-specific)

**Detection:** Python SDK changelog shows property renamed with `_property` suffix (e.g., `Model 'ExceptionEntry' deleted instance variable 'values'` / `Model 'ExceptionEntry' added property 'values_property'`).

**Per-Language Impact:**
- **Python:** ❌ Breaking — property access changes from `.values` to `.values_property`
- **Other languages:** Not affected

**Root Cause:** Python base model class reserves names: `keys`, `items`, `values`, `popitem`, `clear`, `update`, `setdefault`, `pop`, `get`, `copy`. Properties using these names get `_property` suffix automatically.

**Mitigation:** Accept these breaking changes. The renaming is required to avoid conflicts with base model methods.

---

### 22. LRO/Paging Operation Type Changed (Go-specific)

**Detection:** Go SDK changelog shows operation changed between LRO and non-LRO, or between paged and non-paged.

**Per-Language Changelog Pattern:**
- **Go:** `Operation '*xxx.A' has been changed to LRO, use '*xxx.BeginA' instead` or `Function '*xxx.NewListAPager' has been removed` / `New function '*xxx.A(xxx) (xxx, error)'`

**Per-Language Impact:**
- **Go:** ❌ Breaking — method names and return types change (direct result ↔ poller/pager)
- **Other languages:** Usually handled automatically

**Mitigation:** Cannot be resolved through `client.tsp` customizations in Go. The spec change must be reconsidered if backward compatibility is required.

---

## Detection Sources

| Source | What It Detects | When Available |
|--------|----------------|----------------|
| **TypeSpec diff** | Structural changes: renames, type changes, removals, enum→union | During authoring (inner loop) |
| **SDK changelog** | Language-specific breaks: setter removal, constructor access, pagination changes | After SDK generation (requires build) |
| **Both combined** | Most comprehensive detection | When SDK repo is available locally |

## Language-Specific Breaking Change Policies

### Java
- **Detection:** RevApi checks, changelog-based detection
- **Customization:** `*Customization.java` classes, `partial-update` mode in tspconfig.yaml
- **Strict:** Most changes are breaking. Uses RevApi suppression in `revapi.json` for accepted breaks.
- **Reference:** [Java TypeSpec Quickstart](https://github.com/Azure/azure-sdk-for-java/blob/main/docs/contributor/typespec-quickstart.md)

### .NET
- **Detection:** ApiCompat rules, analyzer rules (AZC0030 naming, AZC0012 generic types)
- **Customization:** Partial classes (`Custom/*.cs`), `[CodeGenType]`, `[CodeGenSuppress]`, `[CodeGenMember]`
- **Special decorators:** `@@markAsPageable`, `@@hierarchyBuilding`, `@@alternateType` with CommonTypes
- **Some changes safe** due to partial class override capability
- **Reference:** [.NET Breaking Changes Skill](https://github.com/Azure/azure-sdk-for-net/blob/main/.github/skills/mitigate-breaking-changes/SKILL.md)

### Python
- **Detection:** Changelog diff, mypy/flake8 type checks
- **Customization:** `_patch.py` files for customization, `client.tsp` decorators
- **Duck typing** makes many changes safe. Key patterns: numeric name changes, directive renames, parameter reordering via `@@override`
- **Accept patterns:** Common types upgrade, pageable model removal, multi-level unflattening, base method name conflicts
- **Reference:** [Python Breaking Changes Guide](https://github.com/Azure/azure-sdk-for-python/blob/main/doc/dev/mgmt/sdk-breaking-changes-guide.md)

### Go
- **Detection:** Changelog pattern detection, exported symbol changes
- **Customization:** `client.tsp` decorators only — Go has NO SDK-side customization mechanism
- **Strict:** Most changes are breaking. Many breaking change types (property type changes, LRO/paging changes, parameter additions, property/operation deletions) **cannot be resolved through client customizations** — the spec change itself must be reconsidered.
- **Reference:** [Go Breaking Changes Guide](https://github.com/Azure/azure-sdk-for-go/blob/main/documentation/development/breaking-changes/sdk-breaking-changes-guide.md)

### JavaScript
- **Detection:** Changelog diff
- **Customization:** Three-way merge workflow via `dev-tool customization apply` (edits in `src/` merged against regenerated `generated/`)
- **TypeSpec-first:** JS recommends TypeSpec customizations (`client.tsp`) over SDK-side customizations
- **Reference:** [JS Customization Guide](https://aka.ms/azsdk/js/customization)
