# Handling prepend-rp-prefix from autorest.md

## Goal

Migrate the `prepend-rp-prefix` entries from `autorest.md.bak` into `@@clientName` decorators
placed in the `client.tsp` file under the spec path.
The spec path is defined in `info.txt`.

---

## Background

In autorest, the `prepend-rp-prefix` configuration prepends the resource provider (RP) name
to a model/enum name to avoid conflicts with common .NET types (e.g., `DayOfWeek` collides
with `System.DayOfWeek`).

The RP prefix is derived from the `namespace` or `library-name` setting in `autorest.md`.
For example, if `library-name: DesktopVirtualization`, then the RP prefix is `DesktopVirtualization`.

---

## Input Format

```yaml
prepend-rp-prefix:
  - TypeName1
  - TypeName2
```

Each entry is a type name (model or enum) that should be prefixed with the RP name.

---

## How to Derive the Prefixed Name

1. Read the `library-name` from `autorest.md.bak` (e.g., `DesktopVirtualization`).
2. For each entry, the new client name is `<library-name><TypeName>`.

**Example**: `DayOfWeek` → `DesktopVirtualizationDayOfWeek`

---

## Decorator Syntax

Use `@@clientName` to rename the type for the C# client:

```typespec
@@clientName(TypeName, "<RpPrefix><TypeName>", "csharp");
```

**Example**:

```typespec
@@clientName(DayOfWeek, "DesktopVirtualizationDayOfWeek", "csharp");
```

---

## Rules (IMPORTANT — read before writing any decorator)

1. **Output file**: Write all decorators into `client.tsp` under the spec path (see `info.txt` for the path).
2. **Validate the type exists**: Before emitting a decorator, confirm the model/enum actually exists in the TypeSpec spec files. If it does not exist, **skip that entry silently**.
3. **Do not modify any other file** — only `client.tsp` and `back-compat.tsp` should be created or edited.
4. **Idempotency**: If the decorator already exists in `client.tsp`, do not add a duplicate.
5. **Always include the `"csharp"` scope**: Every `@@clientName` decorator must include `"csharp"` as the last argument. Never omit the scope parameter.
6. **Conflict resolution with `back-compat.tsp`**: Before adding a decorator to `client.tsp`, check whether the same target already has a `@@clientName` decorator **in the spec files** (without a language scope, or with a different scope). If the existing decorator's name **differs** from what the prepend-rp-prefix entry requires, then:
   - Still add the new decorator with scope `"csharp"` to `client.tsp` as normal.
   - Additionally, copy the **original** decorator into `back-compat.tsp` but change its scope to `"!csharp"`, so that non-C# clients continue to use the original name.
7. **Do not add comments above newly added decorators**: When adding decorators in `client.tsp` or `back-compat.tsp`, do not insert `//` comment lines immediately above those newly added decorators.

---

## Worked Example

Given the following `autorest.md.bak` snippet:

```yaml
library-name: DesktopVirtualization

prepend-rp-prefix:
  - DayOfWeek
```

And given that `DayOfWeek` is defined as an enum in the TypeSpec spec (`models.tsp`):

```typespec
enum DayOfWeek {
  Sunday,
  Monday,
  ...
}
```

The resulting decorator in `client.tsp`:

```typespec
@@clientName(DayOfWeek, "DesktopVirtualizationDayOfWeek", "csharp");
```
