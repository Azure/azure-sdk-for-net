# Handling Model Diffs

This guide explains how to resolve model diffs reported by `diff_model.py` when migrating an Azure SDK package from AutoRest to TypeSpec.

## Prerequisites

- Run `diff_model.py` to generate `model_diff_result.txt`
- Have access to the TypeSpec spec files (path in `info.txt`)
- Have `client.tsp` in the spec folder for adding customizations

## Diff Categories and How to Handle Them

### 1. FLATTENED → PROPERTIES

**Symptom:** The baseline SDK had properties flattened directly on the model, but the new generated code wraps them in a `Properties` object.

```
ExpandMsixImage  →  ExpandMsixImageProperties
HostPoolPatch  →  HostPoolPatchProperties
```

**Root Cause:** TypeSpec models use a `properties` bag pattern (e.g., `model Foo { properties?: FooProperties; }`), while the old AutoRest-generated SDK flattened those properties onto the parent model.

**Fix:** Add `flattenProperty` directives in `client.tsp`:

```typespec
#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "Back compatibility"
@@Azure.ClientGenerator.Core.Legacy.flattenProperty(ExpandMsixImage.properties,
  "csharp"
);
```

**Steps:**
1. Find the TypeSpec model name. Check `tspCodeModel.json` for `crossLanguageDefinitionId` or search the `.tsp` files directly.
2. Add the `flattenProperty` decorator to `client.tsp` for each model.
3. Regenerate with `gen.sh`.
4. Re-run `diff_model.py` to verify.

**Known Limitation:** Models from ARM common types (e.g., `PrivateEndpointConnection` from `Azure.ResourceManager.CommonTypes`) cannot be flattened via `client.tsp` because they are defined externally. The flatten directive only works on models defined in the local spec's namespace.

### 2. Property Renamed (Casing Changes)

**Symptom:** A property name changed casing, e.g., `AppUserModelId` → `AppUserModelID`, or `SxsStackListenerCheck` → `SxSStackListenerCheck`.

```
+ public string AppUserModelID { ... }
- public string AppUserModelId { ... }
```

**Fix:** Add `@@clientName` in `client.tsp` to preserve the old name:

```typespec
@@clientName(MsixPackageApplications.appUserModelID,
  "AppUserModelId",
  "csharp"
);
```

**Steps:**
1. Find the TypeSpec property name (usually in `models.tsp` or `tspCodeModel.json`).
2. Add a `@@clientName` directive mapping the new name back to the old name.
3. Regenerate and verify.

### 3. Property Renamed (Semantic Changes)

**Symptom:** A property's meaning is the same but the name changed, e.g., `UpdateType` → `Type`, `StartVmOnConnect` → `StartVMOnConnect`.

```
+ public SessionHostComponentUpdateType? Type { ... }
- public SessionHostComponentUpdateType? UpdateType { ... }
```

**Fix:** Use `@@clientName` in `client.tsp`:

```typespec
@@clientName(AgentUpdatePatchProperties.type, "UpdateType", "csharp");
```

### 4. Added Members (New API features)

**Symptom:** New properties appear that didn't exist in the baseline.

```
+ public HostPoolLoadBalancerType MultiplePersistent { ... }
+ public ManagedServiceIdentity Identity { ... }
```

**Action:** These are typically expected additions from new API versions. No fix needed unless they break backward compatibility.

### 5. Removed Members

**Symptom:** Properties/constructors that existed in the baseline are gone.

```
- public DesktopVirtualizationPrivateEndpointConnection()
- public IDictionary<string, string> Tags { ... }
```

**Action:** Investigate whether this is intentional (API change) or a generation issue. Public constructors becoming internal is common when moving from AutoRest to TypeSpec. For missing `Tags`, check if the TypeSpec model definition is missing the property.

### 6. Missing Setters (Output-only model)

**Symptom:** A property had `{ get; set; }` in the baseline but only has `{ get; }` in the current generated code. The diff tool reports these under **MISSING SETTERS**.

```
MISSING SETTERS (baseline had { get; set; } but current only has { get; })
  DesktopVirtualizationStartMenuItem
    - AppAlias
    - FilePath
    - CommandLineArguments
    - IconPath
    - IconIndex
```

**Root Cause:** The TypeSpec code generator determines property mutability based on **model usage**. If a model is only used as an operation response (output), its properties are generated as read-only (getter-only). In the old AutoRest-generated SDK, all properties got `{ get; set; }` regardless of whether the model was input or output.

In the `tspCodeModel.json`, these models will show `usage: "Output,Json"` instead of `usage: "Input,Output,Json"`.

**Fix:** Add a `@@usage` decorator in `client.tsp` to mark the model as also having `Input` usage for C#:

```typespec
@@usage(StartMenuItem, Usage.input, "csharp");
```

This changes the model's usage from `Output,Json` to `Input,Output,Json`, causing the generator to produce `{ get; set; }` properties matching the baseline.

**Steps:**
1. Find the TypeSpec model name (may differ from the SDK name due to `@@clientName`). Search `client.tsp` for `@@clientName` mappings or check `tspCodeModel.json`.
2. Verify the model's current usage in `tspCodeModel.json` — it should be `Output,Json` (missing `Input`).
3. Add `@@usage(TypeSpecModelName, Usage.input, "csharp");` to the end of `client.tsp`.
4. Regenerate with `gen.sh`.
5. Re-run `diff_model.py` to verify the setters are restored.

**Example:** `DesktopVirtualizationStartMenuItem` maps to TypeSpec model `StartMenuItem` (via `@@clientName`). Adding `@@usage(StartMenuItem, Usage.input, "csharp")` restores `{ get; set; }` on all its properties.

### 7. Type Changes

**Symptom:** A property's type changed, e.g., `IList<T>` → `T?`, or `struct` → `enum`.

```
~ property DaysOfWeek
  OLD: public IList<ScalingScheduleDaysOfWeekItem> DaysOfWeek { ... }
  NEW: public ScalingScheduleDaysOfWeekItem? DaysOfWeek { ... }
```

**Fix:** Use `@@alternateType` in `client.tsp` to override the generated type:

```typespec
@@alternateType(ScalingSchedule.daysOfWeek,
  ScalingScheduleDaysOfWeekItem,
  "csharp"
);
```

### 8. Removed Models

**Symptom:** A model existed in the baseline but is completely absent now.

```
MsixImageUri (class)
MsixPackagePatch (class)
```

**Action:** Check if the model was renamed (look for `@@clientName`) or replaced by a different model. If removed from the API spec, it's expected.

### 9. Added Models

**Symptom:** New models appear that didn't exist in the baseline.

**Action:** These are expected from new API features or from un-flattened properties bags. After applying `flattenProperty`, the associated `*Properties` models that were only needed as wrappers will no longer appear as separate public models.

## Quick Reference: Finding TypeSpec Model Names

1. **From tspCodeModel.json:** Search for the SDK model name → read `crossLanguageDefinitionId`
   ```bash
   grep -n '"YourModelName"' tspCodeModel.json
   ```

2. **From .tsp files:** Search directly in the spec folder
   ```bash
   grep -n "model YourModelName" *.tsp
   ```

3. **Mapping convention:** SDK name → TypeSpec name examples:
   - `DesktopVirtualizationPrivateEndpointConnectionData` → `PrivateEndpointConnectionWithSystemData`
   - `VirtualApplicationPatch` → `ApplicationPatch`
   - `HostPoolPatch` → `HostPoolPatch`

## Workflow

```
1. Run diff_model.py
2. Review model_diff_result.txt
3. Identify diff category for each item
4. Add fixes to client.tsp (flattenProperty, clientName, alternateType)
5. Regenerate: gen.sh
6. Re-run diff_model.py to verify
7. Repeat until only expected/acceptable diffs remain
```
