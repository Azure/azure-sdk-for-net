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
// In client.tsp — use @@alternateType to preserve enum behavior for affected languages
@@alternateType(MyService.FooStatus, string, "java");
@@alternateType(MyService.FooStatus, string, "go");
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

This is a complex multi-step case. The mitigation combines `@@alternateType` and `@@clientName`:

```typespec
// In client.tsp
// Step 1: Keep the original enum name for the property that changed return type
@@alternateType(
  MyService.StorageTaskAssignmentProperties.provisioningState,
  MyService.ProvisioningState,
  "java"
);

// Step 2: Add missing members back to the original enum via clientName
// if members were moved to a new enum, use @@clientName to alias them
@@clientName(MyService.StorageTaskAssignmentProvisioningState.Succeeded, "Succeeded");
```

**Known limitation:** The exact mitigation depends on how the enum was split and which members moved. Review the specific changelog entries to determine the correct decorator combination.

---

### 3. Model Renamed

**Detection:** TypeSpec diff or changelog shows model name changed between versions.

**Per-Language Impact:**
- **All languages:** ❌ Breaking — client code references the old name

**Mitigation:**
```typespec
// In client.tsp — preserve the old name for all languages
@@clientName(MyService.NewModelName, "OldModelName");

// Or scope to specific languages if only some need backward compat
@@clientName(MyService.NewModelName, "OldModelName", "java");
```

---

### 4. Model Removed

**Detection:** TypeSpec diff shows model definition deleted, or changelog shows model no longer available.

**Per-Language Impact:**
- **All languages:** ❌ Breaking — any code referencing the model fails to compile

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

### 5. Property Type Changed

**Detection:** TypeSpec diff shows property type changed (e.g., `int32` → `duration`, `string` → custom model).

**Per-Language Impact:**
- **Java:** ❌ Breaking — deserialization and getter return type change
- **.NET:** ❌ Breaking — analyzer AZC0030 flags type mismatches
- **Python:** ⚠️ May break — mypy type check fails
- **Go:** ❌ Breaking — type assertion fails

**Mitigation:**
```typespec
// In client.tsp — use @@alternateType to keep old type for affected languages
@@alternateType(MyService.MyModel.timeout, int32, "java");
@@alternateType(MyService.MyModel.timeout, int32, "go");
```

---

### 6. Property Renamed

**Detection:** TypeSpec diff shows property name changed, or changelog shows renamed getter/setter.

**Per-Language Impact:**
- **All languages:** ❌ Breaking — getter/setter name changes, customization code drifts
- **Java/Python:** Additional risk — customization files (`*Customization.java`, `*_patch.py`) may reference old name

**Mitigation:**
```typespec
// In client.tsp — preserve old property name
@@clientName(MyService.MyModel.newPropertyName, "oldPropertyName");
```

---

### 7. Property or Model Made Read-Only (Setters Removed)

**Detection:** SDK changelog shows setter methods (`withXyz`) removed from models, or constructors changed to private.

**Per-Language Impact:**
- **Java:** ❌ Breaking — immutable models, no setters
- **.NET:** ✅ Safe — partial classes can add setters
- **Python:** ✅ Safe — `_patch.py` can override
- **Go:** ❌ Breaking — exported fields become unexported

**Mitigation:**
```typespec
// In client.tsp — restore input usage for affected languages
@@usage(MyService.MyModel, Usage.input, "java");
@@usage(MyService.MyModel, Usage.input, "go");
```

---

### 8. Operation Signature Changed

**Detection:** TypeSpec diff shows operation parameters added/removed/retyped, or return type changed.

**Per-Language Impact:**
- **All languages:** ❌ Breaking — method signatures change in generated clients

**Mitigation:**
```typespec
// In client.tsp — rename the operation to preserve old signature
@@clientName(MyService.MyInterface.newOpName, "oldOpName");

// Or hide the new operation and keep old one
@@access(MyService.MyInterface.internalOp, Access.internal, "python");
```

---

### 9. Operation Removed or Hidden

**Detection:** TypeSpec diff shows operation deleted or `@removed` decorator added.

**Per-Language Impact:**
- **All languages:** ❌ Breaking — method no longer exists in client

**Mitigation:**
```typespec
// In main.tsp — use version gating instead of deletion
@removed(Versions.v2026_07_01)
op oldOperation(): void;
```

---

### 10. List/Page Wrapper Models Removed

**Detection:** SDK changelog shows list wrapper models removed (e.g., `ListQueueResource`, `StorageAccountListResult`, `FileShareItems`).

**Per-Language Impact:**
- **Java:** ❌ Breaking — pagination model types changed
- **.NET:** ⚠️ May break — depends on how pagination is consumed
- **Python:** ⚠️ May break — list response type changes
- **Go:** ❌ Breaking — response type assertion fails

**Mitigation:**
```typespec
// In client.tsp — preserve old wrapper model names
@@clientName(MyService.NewPagedResponse, "OldListResult", "java");
```

---

## Detection Sources

| Source | What It Detects | When Available |
|--------|----------------|----------------|
| **TypeSpec diff** | Structural changes: renames, type changes, removals, enum→union | During authoring (inner loop) |
| **SDK changelog** | Language-specific breaks: setter removal, constructor access, pagination changes | After SDK generation (requires build) |
| **Both combined** | Most comprehensive detection | When SDK repo is available locally |

## Language-Specific Breaking Change Policies

Each SDK language has different sensitivity and handling mechanisms:

- **Java:** Changelog-based detection. Customization via `*Customization.java` classes. Strict backward compatibility — most changes are breaking.
- **.NET:** Analyzer rules (AZC0030 naming, AZC0012 generic types). Customization via partial classes. Some changes safe due to partial class override capability.
- **Python:** `_patch.py` files for customization. Duck typing makes many changes safe. mypy/flake8 checks catch type changes.
- **Go:** Changelog pattern detection maps to `client.tsp` decorators. Breaking changes detected via exported symbol changes. Strict — most changes are breaking.
