# Handling format-by-name-rules from autorest.md

## Goal

Migrate the `format-by-name-rules` entries from `autorest.md.bak` into `@@alternateType`
decorators placed in the `client.tsp` file under the spec path.
The spec path is defined in `info.txt`.

---

## Background

In autorest, `format-by-name-rules` automatically changes the serialization format of
properties based on their name (exact match or wildcard suffix/prefix match). This causes
the C# generator to emit a richer .NET type instead of `string`.

In TypeSpec, properties may already use the correct type (e.g., `url`, `uuid`). When they
do, **no action is needed**. When the TypeSpec property is still `string` but the old
autorest config would have changed its C# type, an `@@alternateType` decorator is required.

---

## Input Format

```yaml
format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
```

Each entry is a key-value pair:

- **Key**: A property name pattern. A leading `*` means suffix match; otherwise it is an
  exact match on the property name.
- **Value**: The autorest format string that maps to a .NET / TypeSpec type.

---

## Pattern Matching Rules

| Pattern      | Matches                                                    |
|--------------|------------------------------------------------------------|
| `'name'`     | Properties whose name is exactly `name`.                   |
| `'*Suffix'`  | Properties whose name **ends with** `Suffix`.              |

For example:
- `'tenantId'` matches only properties named exactly `tenantId` (not `oboTenantId`).
- `'*Uri'` matches `storageUri`, `keyVaultSecretUri`, `redirectUri`, etc.
- `'*Uris'` matches `redirectUris`, `replyUris`, etc.

---

## Format-to-Type Mappings

| autorest format   | .NET type              | TypeSpec type                          |
|-------------------|------------------------|----------------------------------------|
| `uuid`            | `System.Guid`          | `Azure.Core.uuid`                                 |
| `etag`            | `Azure.ETag`           | `Azure.Core.eTag`                      |
| `azure-location`  | `Azure.Core.AzureLocation` | `Azure.Core.azureLocation`         |
| `Uri`             | `System.Uri`           | `url`                         |

---

## When to Act

For each property that matches a `format-by-name-rules` pattern:

1. **Find the property in the TypeSpec spec files** (`.tsp` files under the spec path).
2. **Check its current TypeSpec type**:
   - If the property already uses the target TypeSpec type (e.g., `url`, `uuid`,
     `Azure.Core.eTag`, `Azure.Core.azureLocation`), **no action is needed** — skip it.
   - If the property uses `string` (or another non-matching type), add an
     `@@alternateType` decorator.
3. **Properties inherited from ARM common types** (e.g., `location` on tracked resources,
   `etag` on resource envelopes) are typically already typed correctly by the ARM TypeSpec
   library. These generally do **not** need explicit decorators.

---

## Decorator Syntax

### `@@alternateType`

Changes the wire type of a property for the C# client:

```typespec
@@alternateType(ModelName.propertyName, <TypeSpecType>, "csharp");
```

---

## Worked Examples

### Example 1 — `tenantId` → `uuid`

Given this spec property:

```typespec
model RegistrationInfo {
  tenantId?: string;
}
```

The property `tenantId` matches the exact-name pattern `'tenantId'` with format `uuid`.
Since the TypeSpec type is `string` (not `uuid`), add:

```typespec
@@alternateType(RegistrationInfo.tenantId, uuid, "csharp");
```

### Example 2 — `*Uri` suffix match (already correct type)

Given this spec property:

```typespec
model DomainJoinCredentials {
  usernameKeyVaultSecretUri: url;
}
```

The property `usernameKeyVaultSecretUri` matches the suffix pattern `'*Uri'` with format
`Uri`. Since the TypeSpec type is already `url`, **no action is needed** — skip it.

### Example 3 — `ETag` → `etag`

Given this spec property:

```typespec
model ResourceModelWithAllowedPropertySet {
  etag?: string;
}
```

If the property name in the wire format is `ETag` (matching the exact pattern `'ETag'`) and
the TypeSpec type is `string`, add:

```typespec
@@alternateType(ResourceModelWithAllowedPropertySet.etag, Azure.Core.eTag, "csharp");
```

However, if `etag` is inherited from an ARM common type that already types it correctly,
**skip it**.

### Example 4 — `location` → `azure-location`

The `location` property on ARM tracked resources is typically inherited from
`TrackedResource` in the ARM TypeSpec library, which already types it as
`Azure.Core.azureLocation`. In that case, **no action is needed**.

If a custom model defines its own `location` property typed as `string`:

```typespec
model CustomModel {
  location?: string;
}
```

Then add:

```typespec
@@alternateType(CustomModel.location, Azure.Core.azureLocation, "csharp");
```

---

## Rules (IMPORTANT — read before writing any decorator)

1. **Output file**: Write all decorators into `client.tsp` under the spec path (see `info.txt` for the path).
2. **Validate the property exists**: Before emitting a decorator, confirm the model and property actually exist in the TypeSpec spec files. If they do not exist, **skip that entry silently**.
3. **Check the existing TypeSpec type**: If the property already uses the correct TypeSpec type, **skip it** — do not add a redundant `@@alternateType`.
4. **Skip inherited ARM common-type properties**: Properties like `location` (from `TrackedResource`) and `etag` (from resource envelopes) are already correctly typed by the ARM library. Do not add decorators for these.
5. **Do not modify any other file** — only `client.tsp` and `back-compat.tsp` should be created or edited.
6. **Idempotency**: If the decorator already exists in `client.tsp`, do not add a duplicate.
7. **Always include the `"csharp"` scope**: Every `@@alternateType` decorator must include `"csharp"` as the last argument.
8. **Do not add comments above newly added decorators**: When adding decorators in `client.tsp` or `back-compat.tsp`, do not insert `//` comment lines immediately above those newly added decorators.
