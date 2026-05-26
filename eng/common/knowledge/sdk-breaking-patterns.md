# SDK Breaking Change Patterns

This document catalogs known TypeSpec changes that cause SDK breaking changes, organized by detection source, per-language impact, and recommended `client.tsp` mitigations. It is used by `azsdk_typespec_generate_authoring_plan` to warn developers about SDK impact during TypeSpec authoring.

## How to Use This Document

**Important:** The patterns below are **SDK breaking changes**, not API breaking changes. These TypeSpec changes may be perfectly valid from an API/wire-protocol perspective, but they cause breaking changes in the generated SDK surface (e.g., class renames, removed methods) that affect downstream SDK consumers. API breaking changes (changes to the wire contract) should be caught by TypeSpec API-level validation, not this document.

When generating an authoring plan for TypeSpec changes, check if the planned changes match any pattern below. If so, include an **SDK IMPACT** warning in the plan with the recommended mitigation. The developer can then apply the `client.tsp` fix in the same session, before merge.

## Pattern Catalog

### 1. Enum Changed to Extensible Union

**Detection:** TypeSpec diff shows `enum` keyword replaced by `union` or extensible enum pattern.

**Note:** This change should generally use version decorators (`@added`) to introduce the union in a new API version rather than modifying the existing enum in place. If version decorators are used correctly, the SDK will handle versioning automatically. However, if the change does occur (e.g., during TypeSpec restructuring), the SDK impact is:

**Per-Language Impact:**
- **Java:** ❌ Breaking — enum ordinal values change, deserialization breaks
- **.NET:** ❌ Breaking — cannot be fully fixed by `client.tsp`; may require .NET customization code
- **Python:** ✅ Usually safe — duck typing, string comparison
- **Go:** ❌ Breaking — type assertion fails on new union type

**Mitigation:**
```typespec
// In client.tsp — Define a new enum with all original enum values, then use @@alternateType to map to the new enum type for affected languages.
enum FooStatusEnum
{
 // ... all values from original FooStatus Enum
}
@@alternateType(MyService.FooStatus, FooStatusEnum, "java");
@@alternateType(MyService.FooStatus, FooStatusEnum, "go");
```

**Note (.NET):** `@@alternateType` may not fully resolve this for .NET. .NET may need customization code (partial classes) to preserve backward compatibility.

---

### 4. Model Renamed

**Detection:** TypeSpec diff shows a model definition's name changed while its structure remains the same or similar. This is distinct from Pattern 5 (Model Removed) — a rename has a clear old→new mapping, while a removal has no replacement.

This pattern covers two scenarios:
1. **Explicit rename:** A model is renamed across API versions (detectable via `@renamedFrom` decorator or paired model removal + addition in TypeSpec diff)
2. **Migration naming divergence:** During Swagger→TypeSpec migration, TypeSpec default naming conventions produce different SDK class names than the old Swagger-generated SDK had (e.g., TypeSpec `AccessMode` generates `AccessMode` in C#, but the Swagger SDK used `ContainerAppAccessMode`)

Both scenarios use the same mitigation (`@@clientName`).

**How to distinguish from Pattern 5:** If a model disappears from the changelog AND a new model with similar properties appears, this is a rename (Pattern 4). If a model disappears with no replacement, that's a removal (Pattern 5).

**TypeSpec pattern**
```
@renamedFrom(Versions.v2, "OldModelName")
model NewModelName {
  prop: string
}
```

**Per-Language Impact:**
- **All languages:** ❌ Breaking — client code references the old name
- **.NET:** .NET may keep the old model available via customization code (partial classes) rather than `client.tsp`

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

**Detection:** TypeSpec diff shows model definition deleted with no replacement. If a replacement model with similar properties exists, this is a rename — see Pattern 4 (Model Renamed) instead.

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

**Note:** Not all type changes can be mitigated by `client.tsp`. If the type change is fundamental (e.g., switching between incompatible model hierarchies), the spec change itself may need to be reconsidered.

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

### 8. Operation Renamed

**Detection:** TypeSpec diff shows operation name changed, or changelog shows paired method removal + addition. This is distinct from Pattern 10 (Operation Removed) — a rename has a clear old→new mapping, while a removal has no replacement.

**How to distinguish from Pattern 10:** If a method disappears from the changelog AND a new method with similar parameters/return type appears, this is a rename (Pattern 8). If a method disappears with no replacement, that's a removal (Pattern 10).

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

### 9. Operation Signature Changed (Parameters Added/Removed/Reordered)

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

### 10. Operation Removed or Hidden

**Detection:** TypeSpec diff shows operation deleted or `@removed` decorator added, with no replacement operation. If a replacement operation with similar parameters exists, this is a rename — see Pattern 8 (Operation Renamed) instead.

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

### 11. Combine multiple model properties into one

**Detection:** TypeSpec diff shows that one or more properties in a model are combined into a new model, and a new property of that model is added.

**Per-Language Impact:**
- **All languages:** ❌ Breaking — missing properties and new property added in a model

**Mitigation:** This can be resolved by applying `@flattenProperty` to the new combined property in `client.tsp`.

**Note:** The legacy `@flattenProperty` decorator is generally only used during TypeSpec conversion from Swagger. For new TypeSpec APIs, prefer restructuring the model hierarchy instead of relying on flatten.

---

### 12. Interface Renamed (DataPlane only)

**Detection:** TypeSpec diff shows interface name changed.

**Per-Language Impact:**
- **All languages:** ❌ Breaking — client name changed

**Mitigation:**
```typespec
// In client.tsp — restore the original interface name
@@clientName(MyService.newInterfaceName, "oldInterfaceName");
```

---

## Detection Sources

| Source | What It Detects | When Available |
|--------|----------------|----------------|
| **TypeSpec diff** | Structural changes: renames, type changes, removals, enum→union | During authoring (inner loop) |