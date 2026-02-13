# Handling Rename Mappings from autorest.md

## Goal

Migrate the `rename-mapping` entries from `autorest.md.back` into TypeSpec decorators
(`@@clientName` and `@@alternateType`) placed in the `client.tsp` file under the spec path.
The spec path is defined in `info.txt`.
****
---

## Input Format

Each rename-mapping entry is a key-value pair:
****
```
<Key>: <Value>
```

- **Key** identifies a model or a model property.
- **Value** has the format `<NewName>|<NewType>`, where either part may be omitted.

---

## How to Parse a Key

| Key pattern                          | Target                                                   |
|--------------------------------------|----------------------------------------------------------|
| `ModelName`                          | The model itself.                                        |
| `ModelName.propertyName`             | Property `propertyName` on `ModelName`.                  |
| `ModelName.properties.propertyName`  | A special swagger-style key. It translates to property `propertyName` on the model `ModelNameProperties` (i.e., append `Properties` to `ModelName` and drop the `.properties.` segment). |

### Resolving the `.properties.` Pattern

When the key contains `.properties.` (e.g., `HostPool.properties.ssoadfsAuthority`), convert it by:
1. Taking the part before `.properties.` (`HostPool`) and appending `Properties` → `HostPoolProperties`.
2. Taking the part after `.properties.` as the property name → `ssoadfsAuthority`.
3. The result is `HostPoolProperties.ssoadfsAuthority`.

In general: `X.properties.y` → `XProperties.y`.

---

## How to Parse a Value

The value has the format `<NewName>|<NewType>`. There are four cases:

| Value form         | Meaning                                               | Action                                    |
|--------------------|-------------------------------------------------------|-------------------------------------------|
| `NewName`          | Rename only (no pipe character).                      | Apply `@@clientName`.                     |
| `-\|NewType`       | Type change only (`-` means "keep original name").    | Apply `@@alternateType`.                  |
| `NewName\|NewType` | Both rename and type change.                          | Apply both `@@clientName` **and** `@@alternateType`. |
| `NewName.EnumValue`| Rename an enum member.                                | Apply `@@clientName` to the enum member.  |

---

## Decorator Syntax

### `@@clientName`

Renames a model or property for the C# client.

```typespec
// Rename a model
@@clientName(SourceModelName, "TargetName", "csharp");

// Rename a property on a model
@@clientName(ModelName.propertyName, "TargetPropertyName", "csharp");

// Rename an enum member
@@clientName(EnumName.MemberName, "TargetMemberName", "csharp");
```

### `@@alternateType`

Changes the wire type of a property for the C# client.

```typespec
@@alternateType(ModelName.propertyName, <TypeSpecType>, "csharp");
```

---
********
## Type Mappings

When the value contains a type part, map it to the corresponding TypeSpec type:

| autorest type | TypeSpec type                       |
|---------------|-------------------------------------|
| `arm-id`      | `Azure.Core.armResourceIdentifier`  |
| `uri`         | `url`                      |
| `any`         | `unknown`                           |

> **If the type is not listed above, skip the type-change portion of that entry (do nothing for the type).**

---

## Worked Examples

Below are concrete examples showing how rename-mapping entries translate to decorators.

### Example 1 — Rename a property

```
AgentUpdatePatchProperties.useSessionHostLocalTime: DoesUseSessionHostLocalTime
```

- Key: property `useSessionHostLocalTime` on model `AgentUpdatePatchProperties`
- Value: rename to `DoesUseSessionHostLocalTime` (no type change)
- Result:

```typespec
@@clientName(AgentUpdatePatchProperties.useSessionHostLocalTime, "DoesUseSessionHostLocalTime", "csharp");
```

### Example 2 — Rename a model

```
ApplicationType: VirtualApplicationType
```

- Key: the model `ApplicationType`
- Value: rename to `VirtualApplicationType`
- Result:

```typespec
@@clientName(ApplicationType, "VirtualApplicationType", "csharp");
```

### Example 3 — Key with `.properties.` segment

```
HostPool.properties.ssoadfsAuthority: SsoAdfsAuthority
```

- Key: `HostPool.properties.ssoadfsAuthority` → convert to `HostPoolProperties.ssoadfsAuthority`
- Target: property `ssoadfsAuthority` on model `HostPoolProperties`
- Value: rename to `SsoAdfsAuthority`
- Result:

```typespec
@@clientName(HostPoolProperties.ssoadfsAuthority, "SsoAdfsAuthority", "csharp");
```

### Example 4 — Type change only (keep original name)

```
ResourceModelWithAllowedPropertySet.managedBy: -|arm-id
```

- Key: property `managedBy` on `ResourceModelWithAllowedPropertySet`
- Value: `-` means keep name; `arm-id` → `Azure.Core.armResourceIdentifier`
- Result:

```typespec
@@alternateType(ResourceModelWithAllowedPropertySet.managedBy, Azure.Core.armResourceIdentifier, "csharp");
```

### Example 5 — Both rename and type change

```
ScalingHostPoolReference.hostPoolArmPath: HostPoolId|arm-id
```

- Key: property `hostPoolArmPath` on `ScalingHostPoolReference`
- Value: rename to `HostPoolId` **and** change type to `Azure.Core.armResourceIdentifier`
- Result:

```typespec
@@clientName(ScalingHostPoolReference.hostPoolArmPath, "HostPoolId", "csharp");
@@alternateType(ScalingHostPoolReference.hostPoolArmPath, Azure.Core.armResourceIdentifier, "csharp");
```

### Example 6 — Rename an enum member

```
AppAttachPackageArchitectures.ALL: All
```

- Key: enum member `ALL` on enum `AppAttachPackageArchitectures`
- Value: rename to `All`
- Result:

```typespec
@@clientName(AppAttachPackageArchitectures.ALL, "All", "csharp");
```

---

## Rules (IMPORTANT — read before writing any decorator)

1. **Output file**: Write all decorators into `client.tsp` under the spec path (see `info.txt` for the path).
2. **Validate the key exists**: Before emitting a decorator, confirm the model/property/enum member actually exists in the TypeSpec spec files. If it does not exist, **skip that entry silently**.
3. **Validate the type mapping**: If the value contains a type part that is **not** in the type-mapping table above, **skip the type-change portion** (still apply the rename if one exists).
4. **Do not modify any other file** — only `client.tsp` and `back-compat.tsp` should be created or edited.
5. **Idempotency**: If the decorator already exists in `client.tsp`, do not add a duplicate.
6. **Always include the `"csharp"` scope**: Every `@@clientName` and `@@alternateType` decorator added to `client.tsp` must include `"csharp"` as the last argument. Never omit the scope parameter.
7. **Conflict resolution with `back-compat.tsp`**: Before adding a decorator to `client.tsp`, check whether the same target (model, property, or enum member) already has a `@@clientName` or `@@alternateType` decorator **in the spec files** (without a language scope, or with a different scope). If the existing decorator's name or type **differs** from what the rename-mapping entry requires, then:
   - Still add the new decorator with scope `"csharp"` to `client.tsp` as normal.
   - Additionally, copy the **original** decorator into `back-compat.tsp` but change its scope to `"!csharp"`, so that non-C# clients continue to use the original name/type.

   **Example**: Suppose the spec already has:
   ```typespec
   @@clientName(Foo, "Bar");
   ```
   But the rename-mapping says `Foo: Baz`. Then:
   - In `client.tsp`: `@@clientName(Foo, "Baz", "csharp");`
   - In `back-compat.tsp`: `@@clientName(Foo, "Bar", "!csharp");`

8. **Do not add comments above newly added decorators**: When adding decorators in `client.tsp` or `back-compat.tsp`, do not insert `//` comment lines immediately above those newly added decorators.


